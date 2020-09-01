using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ideal
{
    public class CsvWriter
    {
        private static int _fileCounter, _arbitrageCounter;
        
        private static List<ArbitrageOpportunity> _buffer = new List<ArbitrageOpportunity>(10001);

        private static ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();

        public void WriteOpportunityToCsv(ArbitrageOpportunity opportunity)
        {
            if (!Parameters.IsWritingToCsv) return;

            ThreadPool.QueueUserWorkItem(stateInfo => Write(opportunity));
        }
        
        public void AddOpportunityToBuffer(ArbitrageOpportunity opportunity)
        {
            if (!Parameters.IsWritingToCsv) return;

            if (_buffer.Count == 10000)
            {
                var copyList = _buffer.ToList();

                Task.Run(() => WriteBufferToCsv(copyList));

                _buffer.Clear();
                _buffer.TrimExcess();

                _buffer = new List<ArbitrageOpportunity>(10001);
            }

            _buffer.Add(opportunity);
        }

        private static void Write(ArbitrageOpportunity opportunity)
        {
            string path = GetCsvPath();

            _locker.EnterWriteLock();

            if (_arbitrageCounter++ % 10000 == 0)
            {
                File.WriteAllText(path, ArbitrageOpportunity.CsvTitles);

                _arbitrageCounter = 1;
                _fileCounter++;
            }

            File.AppendAllText(path, opportunity.ToCsvString());

            _locker.ExitWriteLock();
        }

        private static Task Write(string filePath, string text)
        {
            return WriteAsync(filePath, text);
        }

        private static async Task WriteAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        private static void WriteBuffer(List<ArbitrageOpportunity> buffer)
        {
            string path = GetCsvPath();

            File.WriteAllText(path, ArbitrageOpportunity.CsvTitles);

            string toWrite = string.Join("", buffer.Select(opportunity => opportunity.ToCsvString()));

            File.AppendAllText(path, toWrite);
        }

        private static string GetCsvPath() => string.Concat("ArbitrageOpportunities_", _fileCounter
                                                    .ToString()
                                                    .PadLeft(7, '0'), ".csv");
    }
}
