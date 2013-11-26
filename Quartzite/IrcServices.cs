using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLog;

namespace Quartzite
{
    public class IrcServices
    {
        #region Fields
        /// <summary>
        /// The config object for this connection
        /// </summary>
        public IrcServicesConfig Config;

        /// <summary>
        /// Network connectivity object, super exciting
        /// </summary>
        private Net net;

        /// <summary>
        /// Message parser
        /// </summary>
        private IrcParser Parser;

        /// <summary>
        /// Known channels
        /// </summary>
        private Dictionary<String, Channel> Channels;

        /// <summary>
        /// Known users
        /// </summary>
        private Dictionary<String, User> Users;

        /// <summary>
        /// Users emulated
        /// </summary>
        private Dictionary<String, PseudoUser> PseudoUsers;

        private Logger logger = LogManager.GetCurrentClassLogger();
        #endregion
        
        public IrcServices(IrcServicesConfig config)
        {
            Config = config;

            //If a bind address has been given, bind to it, otherwise use default behavior.
            if (Config.LocalHost == String.Empty) {
                net = new Net();
            } else {
                net = new Net(Config.LocalHost);
            }

            Parser = new IrcParser();
            Unreal unreal = new Unreal(this, Parser);
            unreal.Setup();
            
        }

        #region Methods
        /// <summary>
        /// Initiate connection to the remote server.
        /// </summary>
        public void Connect()
        {
            net.Connect(Config.RemoteHost, Config.Port, Config.Ssl);
            //Authenticate link
            Raw("PASS :{0}", Config.Password);
            //Set protocol options for the link
            Raw("PROTOCTL NOQUIT NICKv2 UMODE2 VL NS TKLEXT NICKIP CHANMODES CLK");
            Raw("SERVER {0} 1 :U2311-0-{1} {2}",Config.Name,Config.Numeric,Config.Description);
        }

        public void Run()
        {
            String line;
            while (true)
            {
                line = net.Read();
                if (line != null)
                {
                    Parser.Parse(line);
                }
                
            }
        }

        public void Raw(String message, params object[] args)
        {
            net.Write(message, args);

            //if (EventRawOut != null)
            //{
            //    EventRawOut(this, String.Format(message, args));
            //}
        }

        public void handlePass(String source, String[] args)
        {

        }

        public void handleProtoctl(String source, String[] args)
        {

        }

        public void handleServer(String source, String[] args)
        {
            //If origin, pass to handle serverIntro, else serverNegotiation
        }

        public void handleEos(String source, String[] args)
        {

        }

        public void handleNetinfo(String source, String[] args)
        {

        }

        public void handleNick(String source, String[] args)
        {
            logger.Trace("handleNick called");
        }

        public void handleMode(String source, String[] args)
        {
            
        }

        public void handleQuit(String source, String[] args)
        {

        }

        public void handleKill(String source, String[] args)
        {

        }

        public void handleSquit(String source, String[] args)
        {

        }

        public void handleSdesc(String source, String[] args)
        {

        }

        public void handlePing(String source, String[] args)
        {

        }

        public void handlePong(String source, String[] args)
        {

        }

        public void handleStats(String source, String[] args)
        {

        }

        public void handleSjoin(String source, String[] args)
        {

        }

        public void handleJoin(String source, String[] args)
        {

        }

        public void handlePart(String source, String[] args)
        {

        }

        public void handleKick(String source, String[] args)
        {

        }

        public void handleMode(String source, String[] args)
        {

        }

        public void handleInvite(String source, String[] args)
        {

        }

        public void handleSajoin(String source, String[] args)
        {

        }
        #endregion
    }
}
