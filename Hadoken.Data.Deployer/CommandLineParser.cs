#region Using References

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Hadoken.Data.Deployer
{
    internal class CommandLineParser
    {
        public CommandLineParser(string[] arguments)
        {
            _commandLineParts = new List<CommandLinePart>();

            if ((arguments != null) && (arguments.Length > 0) && (arguments.Length % 2 == 0))
            {
                //  -d
                //  True

                for (int i = 0, j = 1; i < (arguments.Length / 2); i++, j++)
                {
                    if (arguments[i].StartsWith("-") == true)
                    {
                        string key = arguments[i].Substring(1).Trim().ToUpper();
                        string value = arguments[j].Trim();

                        _commandLineParts.Add(new CommandLinePart(key, value));
                    }
                }
            }
        }

        private const string DropKey = "D";

        private readonly List<CommandLinePart> _commandLineParts;

        public bool IsDrop
        {
            get
            {
                bool isDrop = false;

                CommandLinePart commandLinePart = GetCommandLinePart(DropKey);

                if (commandLinePart != null)
                {
                    Boolean.TryParse(commandLinePart.Value, out isDrop);
                }

                return isDrop;
            }
        }

        private CommandLinePart GetCommandLinePart(string key)
        {
            return _commandLineParts.Where(m => (m.Key == key)).FirstOrDefault();
        }
    }
}