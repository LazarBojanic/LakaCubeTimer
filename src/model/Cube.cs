using WinterCubeTimer.util;

namespace WinterCubeTimer.model {
    public class Cube {
        public List<Side> sides { get; set; }
        public Cube() {
            this.sides = new List<Side> {
                new Side("WHITE", Util.SIDE_UP, Util.COLOR_WHITE),
                new Side("RED", Util.SIDE_RIGHT, Util.COLOR_RED),
                new Side("GREEN", Util.SIDE_FRONT, Util.COLOR_GREEN),
                new Side("YELLOW",Util.SIDE_DOWN, Util.COLOR_YELLOW),
                new Side("ORANGE", Util.SIDE_LEFT, Util.COLOR_ORANGE),
                new Side("BLUE", Util.SIDE_BACK, Util.COLOR_BLUE)
            };
        }
        public Cube(List<Side> newSides) {
            this.sides = newSides;
        }
    }
}