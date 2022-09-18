namespace LakaCubeTimer.model {
    public class Time {
        public int id { get; set; }
        public int session { get; set; }
        public long timeInMilliseconds { get; set; }
        public long initialTimeInMilliseconds { get; set; }
        public string time { get; set; }      
        public bool isPlusTwo { get; set; }
        public bool isDNF { get; set; }
        public string scramble { get; set; }
        public DateTime date { get; set; }
        public Time(int id, int session, long timeInMilliseconds, long initialTimeInMilliseconds, string time, bool isPlusTwo, bool isDNF, string scramble, DateTime date) {
            this.id = id;
            this.session = session;
            this.timeInMilliseconds = timeInMilliseconds;
            this.initialTimeInMilliseconds = initialTimeInMilliseconds;
            this.time = time;
            this.isPlusTwo = isPlusTwo;
            this.isDNF = isDNF;
            this.scramble = scramble;
            this.date = date;
        }
    }
}