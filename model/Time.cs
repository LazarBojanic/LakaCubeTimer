namespace LakaCubeTimer.model {
    public class Time {
        public int id;
        public string time;
        public DateTime date;
        public Time(int id, string time, DateTime date) {
            this.id = id;
            this.time = time;
            this.date = date;
        }
    }
}
