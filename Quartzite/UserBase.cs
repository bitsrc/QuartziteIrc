using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartzite
{
    public class UserBase
    {
        #region Fields
        public List<Channel> Channels;
        public List<Mode> Modes;
        #endregion

        #region Properties
        #endregion

        #region Events

        /// <summary>
        /// Triggered when the user joins a channel.
        /// </summary>
        public event EventHandler OnJoin;

        /// <summary>
        /// Triggered when the user parts a channel.
        /// </summary>
        public event EventHandler OnPart;

        /// <summary>
        /// Triggered when the user quits the network.
        /// </summary>
        public event EventHandler OnQuit;

        /// <summary>
        /// Triggered when a mode change is performed on the user.
        /// </summary>
        public event EventHandler OnMode;

        /// <summary>
        /// Triggered when the user changes nicks.
        /// </summary>
        public event EventHandler OnNickChange;

        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion
    }
}
