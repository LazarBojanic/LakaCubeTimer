namespace LakaCubeTimer.model {
    public class Sticker {
        public int id { get; set; }
        public Color color { get; set; }
        public Sticker(int id, Color color) {
            this.id = id;
            this.color = color;
        }

    }
}
