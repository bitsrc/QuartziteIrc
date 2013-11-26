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

        /// <summary>
        /// Begin reading input and looping
        /// </summary>
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

        /// <summary>
        /// Write a line to the connected IRC server
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void Raw(String message, params object[] args)
        {
            net.Write(message, args);

            //if (EventRawOut != null)
            //{
            //    EventRawOut(this, String.Format(message, args));
            //}
        }
        #region Server Negotiation
        /// <summary>
        /// Password command upon link
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handlePass(String source, String[] args)
        {

        }

        /// <summary>
        /// Protocol negotiation at link
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleProtoctl(String source, String[] args)
        {

        }

        /// <summary>
        /// This is called for either server negotiation at link or the introduction of a server elsewhere in the network
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleServer(String source, String[] args)
        {
            //If origin, pass to handle serverIntro, else serverNegotiation
        }

        /// <summary>
        /// Server is indicating the end of sync
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleEos(String source, String[] args)
        {

        }

        /// <summary>
        /// A server conveying information on its network config
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleNetinfo(String source, String[] args)
        {

        }
        #endregion
        #region User
        /// <summary>
        /// Either introduction of a new user, or a name change
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleNick(String source, String[] args)
        {
            logger.Trace("handleNick called");
        }

        /// <summary>
        /// Called when a mode change happens either on a user or a channel
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleMode(String source, String[] args)
        {
            //Break into user mode and channel mode
            //User mode: check for umode2 vs mode
        }

        /// <summary>
        /// Called when a user quits or disconnects from the network
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleQuit(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a user is killed by an oper
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleKill(String source, String[] args)
        {

        }
        #endregion

        /// <summary>
        /// Called when a user changes their own host
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSethost(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a user's host is changed by another party
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleChghost(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a user changes their own ident
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSetident(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a user's ident is changed by another party
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleChgident(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a user changes their own realname
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSetname(String source, String[] args)
        {
            
        }
        
        /// <summary>
        /// Called when a user's realname is changed by another party
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleChgname(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a whois is requested on a user
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleWhois(String source, String[] args)
        {

        }
        #region Server
        /// <summary>
        /// Called when a server quits or is forced to quit
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSquit(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a server's description is changed
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSdesc(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a ping is received
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handlePing(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a pong is received
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handlePong(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when stats are requested
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleStats(String source, String[] args)
        {

        }
        #endregion
        #region Channels
        /// <summary>
        /// Called for a channel burst
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSjoin(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a user joins a channel
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleJoin(String source, String[] args)
        {

        }
        
        /// <summary>
        /// Called when a user parts a channel
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handlePart(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a user is kicked from a channel
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleKick(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a mode is changed on a channel
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleChannelMode(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when an invite is sent for a channel
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleInvite(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when an admin forces a channel join
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSajoin(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when an admin forces a channel part
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSapart(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when an admin forces a mode change upon a channel
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSamode(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a topic is changed
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleTopic(String source, String[] args)
        {

        }
        #endregion

        #region Services
        
        /// <summary>
        /// Called when services forcibly disconnects a user
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvskill(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services force a mode change
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvsmode(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services force a mode change upon a user with notification
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvs2mode(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services force a snomask change
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvssno(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services force a nick change
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvsnick(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services force a channel join
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvsjoin(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services force a channel part
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvspart(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services add or remove an oper's privileges
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvso(String source, String[] args)
        {
        
        }

        /// <summary>
        /// Called when services No Op a server
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvsnoop(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services set a realname ban
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvsnline(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when services set a file ban
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSvsfline(String source, String[] args)
        {

        }

        #endregion
        #region Messaging

        /// <summary>
        /// Called when a message is sent
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handlePrivmsg(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when a notice is sent
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleNotice(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when someone wants to a send a message to everyone with a specific umode
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSendumode(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when someone wants to send a message to everyone with a specific snomask
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleSendsno(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when someone sends a chatops message
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleChatops(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when someone sends a wallops message
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleWallops(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when someone sends a globops message
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleGlobops(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when someone sends an adchat message
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleAdchat(String source, String[] args)
        {

        }

        /// <summary>
        /// Called when someone sends a nachat message
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void handleNachat(String source, String[] args)
        {

        }
        #endregion
        /// <summary>
        /// Called when a ban is set
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        #region TKL
        public void handleTkl(String source, String[] args)
        {

        }
        #endregion
        #endregion
    }
}
