using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartzite
{
    public class Channel
    {
        #region Fields
        public List<UserBase> Users;
        public List<Mode> Modes;
        #endregion

        #region Properties
        #endregion

        #region Events

        public event EventHandler OnMessage;
        public event EventHandler OnNotice;
        public event EventHandler OnJoin;
        public event EventHandler OnPart;
        public event EventHandler OnMode;
        public event EventHandler OnTopicChange;

        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion
    }
}
