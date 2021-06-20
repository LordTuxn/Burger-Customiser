using System;
using System.Collections.Generic;
using System.Text;

namespace Burger_Customiser.Messages {
    public class ChangeToTakeAwayOptionMessage {

        public bool ToTakeAway { get; set; }

        public ChangeToTakeAwayOptionMessage(bool toTakeAway) {
            ToTakeAway = toTakeAway;
        }
    }
}
