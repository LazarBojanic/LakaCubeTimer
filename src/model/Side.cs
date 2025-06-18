using WinterCubeTimer.util;

namespace WinterCubeTimer.model {
    public class Side {
        public List<Sticker> stickers { get; set; }
        public Side(string colorName, string colorNameAsSide, Color color) {
            stickers = new List<Sticker>();
            for (int i = 0; i < 9; i++) {
                stickers.Add(new Sticker(i, colorName, colorNameAsSide, color));
            }
        }
        public Side(List<Sticker> stickers) {
            this.stickers = stickers;
        }
        public Side(Side side) {
            this.stickers = side.stickers;
        }
    }
}