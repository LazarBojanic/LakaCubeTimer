namespace LakaCubeTimer.model {
    public class Side {
        public List<Sticker> stickers { get; set; }
        public Side(Color color) {
            stickers = new List<Sticker>();
            for (int i = 0; i < 9; i++) {
                stickers.Add(new Sticker(i, color));
            }
        }
        public Side(List<Sticker> stickers) {
            this.stickers = stickers;
        }
        public Side(Side side) {

        }
    }
}