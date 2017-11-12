#region Using References

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Hadoken.Data.Deployer
{
    internal class CommandLineParser
    {
        public CommandLineParser(string applicationName, string[] arguments)
        {
            List<string> argumentList = arguments.ToList();

            if ((argumentList.Count > 0) && (argumentList[0] == applicationName))
            {
                argumentList = argumentList.Skip(1).ToList();
            }

            _commandLineParts = new List<CommandLinePart>();

            if ((argumentList.Count > 0) && (argumentList.Count % 2 == 0))
            {
                //  -d
                //  True

                for (int i = 0, j = 1; i < (argumentList.Count / 2); i++, j++)
                {
                    if (argumentList[i].StartsWith("-") == true)
                    {
                        string key = argumentList[i].Substring(1).Trim().ToUpper();
                        string value = argumentList[j].Trim();

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