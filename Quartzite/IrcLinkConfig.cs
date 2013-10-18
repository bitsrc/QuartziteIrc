using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartzite
{
    public class IrcLinkConfig
    {
        #region Properties
        /// <summary>
        /// The address of the server to connect to
        /// </summary>
        public String RemoteHost { get; set; }

        /// <summary>
        /// The address on which to connect from
        /// </summary>
        public String LocalHost { get; set; }

        /// <summary>
        /// The port on which to connect
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The password to use when linking
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// Whether or not to use SSL when connecting
        /// </summary>
        public Boolean Ssl { get; set; }

        /// <summary>
        /// The name to use for the server. Example: services.seersirc.net
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// A short description of the server to be used in map/links. Examples: "SeersIRC - Even Freedom needs a home.", "SeersIRC Services"
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// The string to be returned when a /version command is used against the server
        /// </summary>
        public String Version { get; set; }

        /// <summary>
        /// Whether or not to use debug mode
        /// </summary>
        public Boolean Debug { get; set; }

        /// <summary>
        /// If in debug mode, the channel in which log notices should be displayed
        /// </summary>
        public String DebugChannel { get; set; }
        #endregion

        #region Constructor
        public IrcLinkConfig(String remoteHost, int port, String password,  String name, String description, String version)
        {
            RemoteHost = remoteHost;
            LocalHost = String.Empty;
            Port = port;
            Ssl = true;
            Password = password;
            Name = name;
            Description = description;
            Version = version;

            Debug = false;
            DebugChannel = String.Empty;
        }
        #endregion
    }
}
