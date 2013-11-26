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
            Parser.AddCommand("NICK", Services.handleNick);
        }
        #endregion
    }
}
