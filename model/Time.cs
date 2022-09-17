namespace LakaCubeTimer.model {
    public class Time {
        public int id { get; set; }
        public int session { get; set; }
        public string time { get; set; }
        public long timeInMilliseconds { get; set; }
        public bool isPlusTwo { get; set; }
        public bool isDNF { get; set; }
        public string scramble { get; set; }
        public DateTime date { get; set; }
        public Time(int id, int session, string time, long timeInMilliseconds, bool isPlusTwo, bool isDNF, string scramble, DateTime date) {
            this.id = id;
            this.session = session;
            this.time = time;
            this.timeInMilliseconds = timeInMilliseconds;
            this.isPlusTwo = isPlusTwo;
            this.isDNF = isDNF;
            this.scramble = scramble;
            this.date = date;
        }
    }
}