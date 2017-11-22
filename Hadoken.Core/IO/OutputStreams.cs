#region Using References

using System;
using System.Diagnostics;

#endregion

namespace Hadoken.Core.IO
{
    public static class OutputStreams
    {
        private static bool _isWriteToConsole = true;
        private static bool _isWriteToDiagnostics = true;

        public static bool IsWriteToConsole
        {
            get
            {
                return _isWriteToConsole;
            }
            set
            {
                _isWriteToConsole = value;
            }
        }

        public static bool IsWriteToDiagnostics
        {
            get
            {
                return _isWriteToDiagnostics;
            }
            set
            {
                _isWriteToDiagnostics = value;
            }
        }

        public static void Write(string Value)
        {
            if (_isWriteToConsole == true)
            {
                Console.Write(Value);
            }

            if (_isWriteToDiagnostics == true)
            {
                Debug.Write(Value);
            }
        }

        public static void WriteLine()
        {
            WriteLine("");
        }

        public static void WriteLine(string Value)
        {
            WriteLine(Value, true);
        }

        public static void WriteLine(object Value)
        {
            WriteLine(((Value == null) ? "" : Value.ToString()), true);
        }

        public static void WriteLine(string Value, bool IsWriteTimeStamp)
        {
            if (String.IsNullOrEmpty(Value) == false)
            {
                if (IsWriteTimeStamp == true)
                {
                    WriteTimeStamp();
                }

                Write(Value);
            }

            Write(Environment.NewLine);
        }

        public static void WriteTimeStamp()
        {
            Write(DateTime.Now.ToString("dd-MMM-yy @ HH:mm:ss"));
            Write(" ");
        }
    }
}
