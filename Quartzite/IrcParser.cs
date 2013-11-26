using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLog;

namespace Quartzite
{
    public class IrcParser
    {
        #region Fields
        public Dictionary<String, IrcHandler> Commands;
        public delegate void IrcHandler(String command, String[] args);
        private Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        public IrcParser()
        {
            Commands = new Dictionary<string, IrcHandler>();
        }
        #endregion

        #region Methods
        public void Parse(String line)
        {
            String origin = String.Empty;
            String command = String.Empty;
            String[] message;

            String[] tokens = line.Split(' ');
            if (tokens.First().StartsWith(":"))
            {
                origin = tokens[0];
                command = tokens[1];
                //Message = String.Join(" ", tokens.Skip(2));
                message = tokens.Skip(2).ToArray();
                logger.Debug("Origin: {0} Command: {1} Args: {2}", origin, command, String.Join(" ", message));
            }
            else
            {
                command = tokens[0];
                //Message = String.Join(" ", tokens.Skip(1));
                message = tokens.Skip(1).ToArray();
                logger.Debug("Command: {0} Args: {1}", command, String.Join(" ", message));
            }


            if (Commands.ContainsKey(command))
            {
                Commands[command](command, message);
            }
        }

        public void AddCommand(String command, IrcHandler handler)
        {
            Commands.Add(command, handler);
        }
        #endregion
    }
}
