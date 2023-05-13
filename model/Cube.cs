using LakaCubeTimer.util;

namespace LakaCubeTimer.model {
    public class Cube {
        public List<Side> sides { get; set; }
        public Cube() {
            this.sides = new List<Side>();
            this.sides.Add(new Side("WHITE", "U", Util.colorWhite));
            this.sides.Add(new Side("YELLOW", "D", Util.colorYellow));
            this.sides.Add(new Side("ORANGE", "L", Util.colorOrange));
            this.sides.Add(new Side("RED", "R", Util.colorRed));
            this.sides.Add(new Side("GREEN", "G", Util.colorGreen));
            this.sides.Add(new Side("BLUE", "B", Util.colorBlue));
        }
        public Cube(List<Side> newSides) {
            this.sides = newSides;
        }
    }
}