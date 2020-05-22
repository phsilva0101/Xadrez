using System;
namespace tabuleiro
{
    public class TabuleiroException : Exception
    {
        public TabuleiroException(string message) : base (message)
        {
        }
    }
}
