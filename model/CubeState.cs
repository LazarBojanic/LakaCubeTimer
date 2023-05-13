
using LakaCubeTimer.model;

public class CubeState {
    public string scramble { get; set; }
    public List<Side> sides { get; set; }

    public CubeState() {
    }

    public CubeState(string scramble, List<Side> sides) {
        this.scramble = scramble;
        this.sides = sides;
    }
}
