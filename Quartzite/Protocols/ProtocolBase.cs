using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartzite
{
    public class ProtocolBase
    {
        #region Fields
        protected IrcParser Parser;
        protected IrcServices Services;
        public delegate void IrcHandler(String command, String[] args);
        #endregion

        #region Constructor
        public ProtocolBase(IrcServices services, IrcParser parser)
        {
            Parser = parser;
            Services = services;
        }
        #endregion

        #region Methods
        public virtual void Setup()
        {

        }
        #endregion
        
    }
}
