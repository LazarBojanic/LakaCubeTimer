namespace WinterCubeTimer.model {
    public class SolveTime {
        public int id { get; set; }
        public int solveSession { get; set; }
        public long solveTimeInMilliseconds { get; set; }
        public long solveInitialTimeInMilliseconds { get; set; }
        public string solveTime { get; set; }      
        public bool isPlusTwo { get; set; }
        public bool isDNF { get; set; }
        public string solveScramble { get; set; }
        public DateTime solveDate { get; set; }
        public SolveTime(int id, int solveSession, long solveTimeInMilliseconds, long solveInitialTimeInMilliseconds, string solveTime, bool isPlusTwo, bool isDNF, string solveScramble, DateTime solveDate) {
            this.id = id;
            this.solveSession = solveSession;
            this.solveTimeInMilliseconds = solveTimeInMilliseconds;
            this.solveInitialTimeInMilliseconds = solveInitialTimeInMilliseconds;
            this.solveTime = solveTime;
            this.isPlusTwo = isPlusTwo;
            this.isDNF = isDNF;
            this.solveScramble = solveScramble;
            this.solveDate = solveDate;
        }
    }
}