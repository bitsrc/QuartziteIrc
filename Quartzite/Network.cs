using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartzite
{
    class Network
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Events
        /// <summary>
        /// Triggered when a user connects to the network.
        /// </summary>
        public event EventHandler OnUserConnect;

        /// <summary>
        /// Triggered when a user disconnects from the network.
        /// </summary>
        public event EventHandler OnUserQuit;

        /// <summary>
        /// Triggered when a server connects to the network.
        /// </summary>
        public event EventHandler OnServerConnect;

        /// <summary>
        /// Triggered when a server disconnects from the network.
        /// </summary>
        public event EventHandler OnServerQuit;
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion
    }
}
