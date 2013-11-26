using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartzite
{
    public class Unreal : ProtocolBase
    {
        #region Fields
        #endregion

        #region Constructor
        public Unreal(IrcServices services, IrcParser parser)
            : base(services, parser)
        {

        }
        #endregion

        #region Methods
        public override void Setup()
        {
            //Server Negotiation
            Parser.AddCommand("PASS", Services.handlePass);
            Parser.AddCommand("PROTOCTL", Services.handleProtoctl);
            Parser.AddCommand("SERVER", Services.handleServer);
            Parser.AddCommand("EOS", Services.handleEos);
            Parser.AddCommand("NETINFO", Services.handleNetinfo);
            //User
            Parser.AddCommand("NICK", Services.handleNick);
            Parser.AddCommand("MODE", Services.handleMode);
            Parser.AddCommand("UMODE2", Services.handleMode);
            Parser.AddCommand("QUIT", Services.handleQuit);
            Parser.AddCommand("KILL", Services.handleKill);
            Parser.AddCommand("SETHOST", Services.handleSethost);
            Parser.AddCommand("CHGHOST", Services.handleChghost);
            Parser.AddCommand("SETIDENT", Services.handleSetident);
            Parser.AddCommand("CHGIDENT", Services.handleChgident);
            Parser.AddCommand("SETNAME", Services.handleSetname);
            Parser.AddCommand("CHGNAME", Services.handleChgname);
            Parser.AddCommand("WHOIS", Services.handleWhois);
            //Server
            Parser.AddCommand("SQUIT", Services.handleSquit);
            Parser.AddCommand("SDESC", Services.handleSdesc);
            Parser.AddCommand("PING", Services.handlePing);
            Parser.AddCommand("PONG", Services.handlePong);
            Parser.AddCommand("STATS", Services.handleStats);
            //Channel
            Parser.AddCommand("SJOIN", Services.handleSjoin);
            Parser.AddCommand("JOIN", Services.handleJoin);
            Parser.AddCommand("PART", Services.handlePart);
            Parser.AddCommand("KICK", Services.handleKick);
            Parser.AddCommand("INVITE", Services.handleInvite);
            Parser.AddCommand("SAJOIN", Services.handleSajoin);
            Parser.AddCommand("SAPART", Services.handleSapart);
            Parser.AddCommand("SAMODE", Services.handleSamode);
            Parser.AddCommand("TOPIC", Services.handleTopic);
            //Services
            Parser.AddCommand("SVSKILL", Services.handleSvskill);
            Parser.AddCommand("SVSMODE", Services.handleSvsmode);
            Parser.AddCommand("SVS2MODE", Services.handleSvs2mode);
            Parser.AddCommand("SVSSNO", Services.handleSvssno);
            Parser.AddCommand("SVS2SNO", Services.handleSvssno);
            Parser.AddCommand("SVSNICK", Services.handleSvsnick);
            Parser.AddCommand("SVSJOIN", Services.handleSvsjoin);
            Parser.AddCommand("SVSPART", Services.handleSvspart);
            Parser.AddCommand("SVSO", Services.handleSvso);
            Parser.AddCommand("SVSNOOP", Services.handleSvsnoop);
            Parser.AddCommand("SVSNLINE", Services.handleSvsnline);
            Parser.AddCommand("SVSFLINE", Services.handleSvsfline);
            //Messaging
            Parser.AddCommand("PRIVMSG", Services.handlePrivmsg);
            Parser.AddCommand("NOTICE", Services.handleNotice);
            Parser.AddCommand("SENDUMODE", Services.handleSendumode);
            Parser.AddCommand("SMO", Services.handleSendumode);
            Parser.AddCommand("SENDSNO", Services.handleSendsno);
            Parser.AddCommand("CHATOPS", Services.handleChatops);
            Parser.AddCommand("WALLOPS", Services.handleWallops);
            Parser.AddCommand("GLOBOPS", Services.handleGlobops);
            Parser.AddCommand("ADCHAT", Services.handleAdchat);
            Parser.AddCommand("NACHAT", Services.handleNachat);
            //TKL
            Parser.AddCommand("TKL", Services.handleTkl);

        }
        #endregion
    }
}
