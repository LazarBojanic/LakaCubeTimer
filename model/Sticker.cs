
namespace LakaCubeTimer.model {
    public class Sticker {
        public int id { get; set; }
        public string colorName { get; set; }
        public string colorNameAsSide { get; set; }
        public Color color { get; set; }
        public Sticker() { 
            
        }
        public Sticker(int id, string colorName, string colorNameAsSide, Color color) {
            this.id = id;
            this.colorName = colorName;
            this.colorNameAsSide = colorNameAsSide;
            this.color = color;
        }
        public void update(Sticker sticker) {
            this.colorName = sticker.colorName;
            this.colorNameAsSide = sticker.colorNameAsSide;
            this.color = sticker.color;
        }
    }
}
