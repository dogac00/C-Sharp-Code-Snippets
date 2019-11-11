using System;

namespace ConsoleApp1
{
    class MyStringBuilder
    {
        private char[] m_chars;
        private int m_index;

        public MyStringBuilder(string value)
        {
            m_chars = value.ToCharArray();
            m_index = value.Length;
        }

        public MyStringBuilder() : this(16)
        {

        }

        public MyStringBuilder(int capacity)
        {
            m_chars = new char[16];
        }

        private void CheckCapacity(int capacity)
        {
            if (m_chars.Length > capacity)
                return;

            char[] oldChars = m_chars;
            m_chars = new char[capacity * 2];

            Array.Copy(oldChars, m_chars, oldChars.Length);
        }

        public void Append(string value)
        {
            CheckCapacity(m_index + value.Length);

            foreach (char ch in value)
            {
                m_chars[m_index++] = ch;
            }
        }

        public override string ToString()
        {
            return new String(m_chars);
        }
    }
}
