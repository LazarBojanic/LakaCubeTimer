
using LakaCubeTimer.model;

public class CubeState {
    public string scramble { get; set; }
    public List<Side> sides { get; set; }
    public string cubeStateString { get; set; }
    public CubeState() {
    }

    public CubeState(string scramble, List<Side> sides, string cubeStateString) {
        this.scramble = scramble;
        this.sides = sides;
        this.cubeStateString = cubeStateString;
    }
}
