using LakaCubeTimer.util;

namespace LakaCubeTimer.model {
    public class Cube {
        public List<Side> sides { get; set; }
        public Cube() {
            this.sides = new List<Side> {
                new Side("WHITE", "U", Util.COLOR_WHITE),
                new Side("YELLOW", "D", Util.COLOR_YELLOW),
                new Side("ORANGE", "L", Util.COLOR_ORANGE),
                new Side("RED", "R", Util.COLOR_RED),
                new Side("GREEN", "G", Util.COLOR_GREEN),
                new Side("BLUE", "B", Util.COLOR_BLUE)
            };
        }
        public Cube(List<Side> newSides) {
            this.sides = newSides;
        }
    }
}