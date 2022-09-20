using LakaCubeTimer.util;

namespace LakaCubeTimer.model {
    public class Cube {
        public List<Side> sides { get; set; }
        public Cube() {
            this.sides = new List<Side>();
            this.sides.Add(new Side(Util.colorWhite));
            this.sides.Add(new Side(Util.colorYellow));
            this.sides.Add(new Side(Util.colorOrange));
            this.sides.Add(new Side(Util.colorRed));
            this.sides.Add(new Side(Util.colorGreen));
            this.sides.Add(new Side(Util.colorBlue));
        }
        public Cube(List<Side> newSides) {
            this.sides = newSides;
        }
    }
}