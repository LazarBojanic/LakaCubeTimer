namespace LakaCubeTimer.model {
    public class Time {
        public int id;
        public int session;
        public string time;
        public double timeInMilliseconds;
        public DateTime date;
        
        public Time(int id, int session, string time, double timeInMilliseconds, DateTime date) {
            this.id = id;
            this.session = session;
            this.time = time;
            this.timeInMilliseconds = timeInMilliseconds;
            this.date = date;
        }
    }
}
