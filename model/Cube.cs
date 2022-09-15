namespace LakaCubeTimer.model {
    public class Cube {
        public List<Side> sides { get; set; }
        public Cube() {
            this.sides = new List<Side>();
            this.sides.Add(new Side(Color.White));
            this.sides.Add(new Side(Color.Yellow));
            this.sides.Add(new Side(Color.Orange));
            this.sides.Add(new Side(Color.Red));
            this.sides.Add(new Side(Color.Green));
            this.sides.Add(new Side(Color.Blue));
        }
        public Cube(List<Side> newSides) {
            this.sides = newSides;
        }
    }
}