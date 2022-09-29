namespace LakaCubeTimer.model {
    public class SolveTimeInMillisecondsWithIsDNF {
        public long solveTimeInMilliseconds { get; set; }
        public bool isDNF { get; set; }
        public SolveTimeInMillisecondsWithIsDNF(long solveTimeInMilliseconds, bool isDNF) {
            this.solveTimeInMilliseconds = solveTimeInMilliseconds;
            this.isDNF = isDNF;
        }
    }
}
