class MyEnumerable : IEnumerable<char>
    {
        private readonly string _value;

        public MyEnumerable(string value)
        {
            _value = value;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return new MyEnumerator(_value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class MyEnumerator : IEnumerator<char>
    {
        private int _index;
        private char _current;
        private string _string;

        public MyEnumerator(string str)
        {
            _index = -1;
            _string = str;
            _current = char.MinValue;
        }

        public bool MoveNext()
        {
            if (_index < this._string.Length - 1)
            {
                _index++;
                _current = this._string[_index];
                return true;
            }

            _index = _string.Length;

            return false;
        }

        public void Reset()
        {
            _index = -1;
            _current = char.MinValue;
        }

        public char Current => _current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            if (_string != null)
                _index = _string.Length;

            _string = null;
        }
    }
