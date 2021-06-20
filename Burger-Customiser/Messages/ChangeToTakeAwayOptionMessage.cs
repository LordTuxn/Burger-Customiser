namespace Burger_Customiser.Messages {

    public class ChangeToTakeAwayOptionMessage {
        public bool ToTakeAway { get; set; }

        public ChangeToTakeAwayOptionMessage(bool toTakeAway) {
            ToTakeAway = toTakeAway;
        }
    }
}