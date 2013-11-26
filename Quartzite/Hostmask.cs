using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartzite
{
    class Hostmask
    {
        #region Fields
        #endregion

        #region Properties
        /// <summary>
        /// The nick represented by the hostmask
        /// </summary>
        public String Nick
        {
            get;
            set;
        }

        /// <summary>
        /// The ident of the hostmask
        /// </summary>
        public String Ident
        {
            get;
            set;
        }

        /// <summary>
        /// The hostname of the hostmask
        /// </summary>
        public String Host
        {
            get;
            set;
        }
        #endregion

        #region Events
        #endregion

        #region Constructor

        /// <summary>
        /// Create a new hostmask from components
        /// </summary>
        /// <param name="nick">User's nickname</param>
        /// <param name="ident">User's ident</param>
        /// <param name="host">User's host</param>
        public Hostmask(String nick, String ident, String host)
        {
            Nick = nick;
            Ident = ident;
            Host = host;
        }

        /// <summary>
        /// Create a new hostmask from a string representation
        /// </summary>
        /// <param name="hostmask">Hostmask in the form "nick!ident@host"</param>
        public Hostmask(String hostmask)
        {
            int iIndex = 0;
            int hIndex = 0;
            iIndex = hostmask.IndexOf('!');
            hIndex = hostmask.IndexOf('@');
            Nick = hostmask.Substring(0, iIndex);
            Ident = hostmask.Substring(iIndex + 1, hIndex - iIndex - 1);
            Host = hostmask.Substring(hIndex + 1);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Represents the hostmask as a string
        /// </summary>
        /// <returns>Hostmask in the format of: "nick!ident@host"</returns>
        public override string ToString()
        {
            return String.Format("{0}!{1}@{2}", Nick, Ident, Host);
        }

        public static implicit operator string(Hostmask h)
        {
            return h.ToString();
        }

        /// <summary>
        /// Retrieves the nick component from a hostmask string
        /// </summary>
        /// <param name="hostmask">Hostmask in the form "nick!ident@host"</param>
        /// <returns>Nick out of the given hostmask</returns>
        public static String ToNick(String hostmask)
        {
            int index = hostmask.IndexOf('!');
            if (index > 0)
            {
                return hostmask.Substring(0, index);
            }
            return hostmask;
        }

        /// <summary>
        /// Retrieves the ident component from a hostmask string
        /// </summary>
        /// <param name="hostmask">Hostmask in the form "nick!ident@host"</param>
        /// <returns>Ident out of the given hostmask</returns>
        public static String ToIdent(String hostmask)
        {
            int index = hostmask.IndexOf('!');
            return hostmask.Substring(index, hostmask.IndexOf('@') - index - 1);
        }

        /// <summary>
        /// Retrieves the host component from a hostmask string
        /// </summary>
        /// <param name="hostmask">Hostmask in the form "nick!ident@host"</param>
        /// <returns>Host out of the given hostmask</returns>
        public static String ToHost(String hostmask)
        {
            int index = hostmask.IndexOf('@');
            if (index > 0)
            {
                return hostmask.Substring(index);
            }
            return hostmask;
        }

        #endregion
    }
}
