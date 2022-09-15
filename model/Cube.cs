namespace LakaCubeTimer.model {
    public class Cube {
        public List<Side> sides;
        public Cube() {
            sides = new List<Side>();
            Side whiteSide = new Side(Color.White);
            Side yellowSide = new Side(Color.Yellow);
            Side orangeSide = new Side(Color.Orange);
            Side redSide = new Side(Color.Red);
            Side greenSide = new Side(Color.Green);
            Side blueSide = new Side(Color.Blue);
            sides.Add(whiteSide);
            sides.Add(yellowSide);
            sides.Add(orangeSide);
            sides.Add(redSide);
            sides.Add(greenSide);
            sides.Add(blueSide);
        }
        public Cube(List<Side> newSides) {
            this.sides = newSides;
        }
        public Side getSide(Color color) {
            foreach (Side side in sides) {
                if (side.stickers[4].color.Equals(color)) {
                    return side;
                }
            }
            return getSide(Color.White);
        }
        public Cube turnCube(String turn) {
            //TURN WHITE SIDE
            if (turn.Equals("U")) {
                Side newWhiteSide = getSide(Color.White);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newOrangeSide = getSide(Color.Orange);
                Side newBlueSide = getSide(Color.Blue);
                //yellow side stays the same
                Side newYellowSide = getSide(Color.Yellow);

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(Color.White).stickers[0].color;
                newWhiteSide.stickers[8].color = getSide(Color.White).stickers[2].color;
                newWhiteSide.stickers[6].color = getSide(Color.White).stickers[8].color;
                newWhiteSide.stickers[0].color = getSide(Color.White).stickers[6].color;

                //turn edge stickers of white side
                newWhiteSide.stickers[8].color = getSide(Color.White).stickers[1].color;
                newWhiteSide.stickers[7].color = getSide(Color.White).stickers[8].color;
                newWhiteSide.stickers[3].color = getSide(Color.White).stickers[7].color;
                newWhiteSide.stickers[1].color = getSide(Color.White).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(Color.Blue).stickers[0].color;
                newRedSide.stickers[2].color = getSide(Color.Blue).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[1].color = getSide(Color.Blue).stickers[1].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(Color.Red).stickers[0].color;
                newGreenSide.stickers[2].color = getSide(Color.Red).stickers[2].color;
                //turn edge stickers of green side
                newGreenSide.stickers[1].color = getSide(Color.Red).stickers[1].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(Color.Green).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(Color.Green).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[1].color = getSide(Color.Green).stickers[1].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(Color.Orange).stickers[0].color;
                newBlueSide.stickers[2].color = getSide(Color.Orange).stickers[2].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[1].color = getSide(Color.Orange).stickers[1].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("U'")) {
                Side newWhiteSide = getSide(Color.White);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newOrangeSide = getSide(Color.Orange);
                Side newBlueSide = getSide(Color.Blue);
                //yellow side stays the same
                Side newYellowSide = getSide(Color.Yellow);

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(Color.White).stickers[2].color;
                newWhiteSide.stickers[6].color = getSide(Color.White).stickers[0].color;
                newWhiteSide.stickers[8].color = getSide(Color.White).stickers[6].color;
                newWhiteSide.stickers[2].color = getSide(Color.White).stickers[8].color;

                //turn edge stickers of white side
                newWhiteSide.stickers[3].color = getSide(Color.White).stickers[1].color;
                newWhiteSide.stickers[7].color = getSide(Color.White).stickers[3].color;
                newWhiteSide.stickers[8].color = getSide(Color.White).stickers[7].color;
                newWhiteSide.stickers[1].color = getSide(Color.White).stickers[8].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(Color.Blue).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(Color.Blue).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[1].color = getSide(Color.Blue).stickers[1].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(Color.Orange).stickers[0].color;
                newGreenSide.stickers[2].color = getSide(Color.Orange).stickers[2].color;
                //turn edge stickers of green side
                newGreenSide.stickers[1].color = getSide(Color.Orange).stickers[1].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(Color.Green).stickers[0].color;
                newRedSide.stickers[2].color = getSide(Color.Green).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[1].color = getSide(Color.Green).stickers[1].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(Color.Red).stickers[0].color;
                newBlueSide.stickers[2].color = getSide(Color.Red).stickers[2].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[1].color = getSide(Color.Red).stickers[1].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("U2")) {
                Side newWhiteSide = getSide(Color.White);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newOrangeSide = getSide(Color.Orange);
                Side newBlueSide = getSide(Color.Blue);
                //yellow side stays the same
                Side newYellowSide = getSide(Color.Yellow);

                //turn corner stickers of white side
                newWhiteSide.stickers[8].color = getSide(Color.White).stickers[0].color;
                newWhiteSide.stickers[0].color = getSide(Color.White).stickers[8].color;
                newWhiteSide.stickers[6].color = getSide(Color.White).stickers[2].color;
                newWhiteSide.stickers[2].color = getSide(Color.White).stickers[6].color;

                //turn edge stickers of white side
                newWhiteSide.stickers[8].color = getSide(Color.White).stickers[3].color;
                newWhiteSide.stickers[3].color = getSide(Color.White).stickers[8].color;
                newWhiteSide.stickers[7].color = getSide(Color.White).stickers[1].color;
                newWhiteSide.stickers[1].color = getSide(Color.White).stickers[7].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(Color.Orange).stickers[0].color;
                newRedSide.stickers[2].color = getSide(Color.Orange).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[1].color = getSide(Color.Orange).stickers[1].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(Color.Blue).stickers[0].color;
                newGreenSide.stickers[2].color = getSide(Color.Blue).stickers[2].color;
                //turn edge stickers of green side
                newGreenSide.stickers[1].color = getSide(Color.Blue).stickers[1].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(Color.Red).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(Color.Red).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[1].color = getSide(Color.Red).stickers[1].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(Color.Green).stickers[0].color;
                newBlueSide.stickers[2].color = getSide(Color.Green).stickers[2].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[1].color = getSide(Color.Green).stickers[1].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            //TURN YELLOW SIDE
            if (turn.Equals("D")) {
                //white side stays the same
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(Color.Yellow).stickers[0].color;
                newYellowSide.stickers[8].color = getSide(Color.Yellow).stickers[2].color;
                newYellowSide.stickers[6].color = getSide(Color.Yellow).stickers[8].color;
                newYellowSide.stickers[0].color = getSide(Color.Yellow).stickers[6].color;

                //turn edge stickers of yellow side
                newYellowSide.stickers[8].color = getSide(Color.Yellow).stickers[1].color;
                newYellowSide.stickers[7].color = getSide(Color.Yellow).stickers[8].color;
                newYellowSide.stickers[3].color = getSide(Color.Yellow).stickers[7].color;
                newYellowSide.stickers[1].color = getSide(Color.Yellow).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(Color.Blue).stickers[6].color;
                newRedSide.stickers[8].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of red side
                newRedSide.stickers[7].color = getSide(Color.Blue).stickers[7].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(Color.Red).stickers[6].color;
                newGreenSide.stickers[8].color = getSide(Color.Red).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[7].color = getSide(Color.Red).stickers[7].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(Color.Green).stickers[6].color;
                newOrangeSide.stickers[8] = getSide(Color.Green).stickers[8];
                //turn edge stickers of orange side
                newOrangeSide.stickers[7].color = getSide(Color.Green).stickers[7].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(Color.Orange).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(Color.Orange).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[7].color = getSide(Color.Orange).stickers[7].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("D'")) {
                //white side stays the same
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of white side
                newYellowSide.stickers[0].color = getSide(Color.Yellow).stickers[2].color;
                newYellowSide.stickers[6].color = getSide(Color.Yellow).stickers[0].color;
                newYellowSide.stickers[8].color = getSide(Color.Yellow).stickers[6].color;
                newYellowSide.stickers[2].color = getSide(Color.Yellow).stickers[8].color;

                //turn edge stickers of white side
                newYellowSide.stickers[3].color = getSide(Color.Yellow).stickers[1].color;
                newYellowSide.stickers[7].color = getSide(Color.Yellow).stickers[3].color;
                newYellowSide.stickers[8].color = getSide(Color.Yellow).stickers[7].color;
                newYellowSide.stickers[1].color = getSide(Color.Yellow).stickers[8].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(Color.Blue).stickers[6].color;
                newOrangeSide.stickers[8].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[7].color = getSide(Color.Blue).stickers[7].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(Color.Orange).stickers[6].color;
                newGreenSide.stickers[8].color = getSide(Color.Orange).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[7].color = getSide(Color.Orange).stickers[7].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(Color.Green).stickers[6].color;
                newRedSide.stickers[8].color = getSide(Color.Green).stickers[8].color;
                //turn edge stickers of red side
                newRedSide.stickers[6].color = getSide(Color.Green).stickers[7].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(Color.Red).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(Color.Red).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[7].color = getSide(Color.Red).stickers[7].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("D2")) {
                //white side stays the same
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of white side
                newYellowSide.stickers[8].color = getSide(Color.Yellow).stickers[0].color;
                newYellowSide.stickers[0].color = getSide(Color.Yellow).stickers[8].color;
                newYellowSide.stickers[6].color = getSide(Color.Yellow).stickers[2].color;
                newYellowSide.stickers[2].color = getSide(Color.Yellow).stickers[6].color;

                //turn edge stickers of white side
                newYellowSide.stickers[8].color = getSide(Color.Yellow).stickers[3].color;
                newYellowSide.stickers[3].color = getSide(Color.Yellow).stickers[8].color;
                newYellowSide.stickers[7].color = getSide(Color.Yellow).stickers[1].color;
                newYellowSide.stickers[1].color = getSide(Color.Yellow).stickers[7].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(Color.Orange).stickers[6].color;
                newRedSide.stickers[8].color = getSide(Color.Orange).stickers[8].color;
                //turn edge stickers of red side
                newRedSide.stickers[7].color = getSide(Color.Orange).stickers[7].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(Color.Blue).stickers[6].color;
                newGreenSide.stickers[8].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[7].color = getSide(Color.Blue).stickers[7].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(Color.Red).stickers[6].color;
                newOrangeSide.stickers[8].color = getSide(Color.Red).stickers[8].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[7].color = getSide(Color.Red).stickers[7].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(Color.Green).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(Color.Green).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[7].color = getSide(Color.Green).stickers[7].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            //TURN ORANGE SIDE
            if (turn.Equals("L")) {   
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                //red side stays the same
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of orange side
                newOrangeSide.stickers[2].color = getSide(Color.Orange).stickers[0].color;
                newOrangeSide.stickers[8].color = getSide(Color.Orange).stickers[2].color;
                newOrangeSide.stickers[6].color = getSide(Color.Orange).stickers[8].color;
                newOrangeSide.stickers[0].color = getSide(Color.Orange).stickers[6].color;

                //turn edge stickers of orange side
                newOrangeSide.stickers[8].color = getSide(Color.Orange).stickers[1].color;
                newOrangeSide.stickers[7].color = getSide(Color.Orange).stickers[8].color;
                newOrangeSide.stickers[3].color = getSide(Color.Orange).stickers[7].color;
                newOrangeSide.stickers[1].color = getSide(Color.Orange).stickers[3].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(Color.White).stickers[0].color;
                newGreenSide.stickers[6].color = getSide(Color.White).stickers[6].color;
                //turn edge stickers of green side
                newGreenSide.stickers[3].color = getSide(Color.White).stickers[3].color;

                //turn corner stickers of red side
                newYellowSide.stickers[0].color = getSide(Color.Green).stickers[0].color;
                newYellowSide.stickers[6].color = getSide(Color.Green).stickers[6].color;
                //turn edge stickers of red side
                newYellowSide.stickers[3].color = getSide(Color.Green).stickers[3].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(Color.Yellow).stickers[0].color;
                newBlueSide.stickers[6].color = getSide(Color.Yellow).stickers[6].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[3].color = getSide(Color.Yellow).stickers[3].color;

                //turn corner stickers of orange side
                newWhiteSide.stickers[0].color = getSide(Color.Blue).stickers[0].color;
                newWhiteSide.stickers[6].color = getSide(Color.Blue).stickers[6].color;
                //turn edge stickers of orange side
                newWhiteSide.stickers[3].color = getSide(Color.Blue).stickers[3].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("L'")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                //red side stays the same
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(Color.Orange).stickers[2].color;
                newOrangeSide.stickers[6].color = getSide(Color.Orange).stickers[0].color;
                newOrangeSide.stickers[8].color = getSide(Color.Orange).stickers[6].color;
                newOrangeSide.stickers[2].color = getSide(Color.Orange).stickers[8].color;

                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(Color.Orange).stickers[1].color;
                newOrangeSide.stickers[7].color = getSide(Color.Orange).stickers[3].color;
                newOrangeSide.stickers[8].color = getSide(Color.Orange).stickers[7].color;
                newOrangeSide.stickers[1].color = getSide(Color.Orange).stickers[7].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(Color.White).stickers[2].color;
                newBlueSide.stickers[8].color = getSide(Color.White).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(Color.White).stickers[5].color;

                //turn corner stickers of red side
                newYellowSide.stickers[2].color = getSide(Color.Blue).stickers[2].color;
                newYellowSide.stickers[8].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of red side
                newYellowSide.stickers[5].color = getSide(Color.Blue).stickers[5].color;

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(Color.Yellow).stickers[2].color;
                newGreenSide.stickers[8].color = getSide(Color.Yellow).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(Color.Yellow).stickers[5].color;

                //turn corner stickers of orange side
                newWhiteSide.stickers[2].color = getSide(Color.Green).stickers[2].color;
                newWhiteSide.stickers[8].color = getSide(Color.Green).stickers[8].color;
                //turn edge stickers of orange side
                newWhiteSide.stickers[5].color = getSide(Color.Green).stickers[5].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("L2")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                //red side stays the same
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of white side
                newOrangeSide.stickers[8].color = getSide(Color.Orange).stickers[0].color;
                newOrangeSide.stickers[0].color = getSide(Color.Orange).stickers[8].color;
                newOrangeSide.stickers[6].color = getSide(Color.Orange).stickers[2].color;
                newOrangeSide.stickers[2].color = getSide(Color.Orange).stickers[6].color;

                //turn edge stickers of white side
                newOrangeSide.stickers[8].color = getSide(Color.Orange).stickers[3].color;
                newOrangeSide.stickers[3].color = getSide(Color.Orange).stickers[8].color;
                newOrangeSide.stickers[7].color = getSide(Color.Orange).stickers[1].color;
                newOrangeSide.stickers[1].color = getSide(Color.Orange).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(Color.White).stickers[0].color;
                newYellowSide.stickers[6].color = getSide(Color.White).stickers[6].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[3].color = getSide(Color.White).stickers[3].color;

                //turn corner stickers of yellow side
                newWhiteSide.stickers[0].color = getSide(Color.Yellow).stickers[0].color;
                newWhiteSide.stickers[6].color = getSide(Color.Yellow).stickers[6].color;
                //turn edge stickers of yellow side
                newWhiteSide.stickers[3].color = getSide(Color.Yellow).stickers[3].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(Color.Blue).stickers[0].color;
                newGreenSide.stickers[6].color = getSide(Color.Blue).stickers[6].color;
                //turn edge stickers of green side
                newGreenSide.stickers[3].color = getSide(Color.Blue).stickers[3].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(Color.Green).stickers[0].color;
                newBlueSide.stickers[6].color = getSide(Color.Green).stickers[6].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[3].color = getSide(Color.Green).stickers[3].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }

            //TURN RED SIDE
            if (turn.Equals("R")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                //orange side stays the same
                Side newOrangeSide = getSide(Color.Orange);           
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(Color.Red).stickers[0].color;
                newRedSide.stickers[8].color = getSide(Color.Red).stickers[2].color;
                newRedSide.stickers[6].color = getSide(Color.Red).stickers[8].color;
                newRedSide.stickers[0].color = getSide(Color.Red).stickers[6].color;

                //turn edge stickers of red side
                newRedSide.stickers[8].color = getSide(Color.Red).stickers[1].color;
                newRedSide.stickers[7].color = getSide(Color.Red).stickers[8].color;
                newRedSide.stickers[3].color = getSide(Color.Red).stickers[7].color;
                newRedSide.stickers[1].color = getSide(Color.Red).stickers[3].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(Color.White).stickers[2].color;
                newBlueSide.stickers[8].color = getSide(Color.White).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(Color.White).stickers[5].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(Color.Blue).stickers[2].color;
                newYellowSide.stickers[8].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(Color.Blue).stickers[5].color;

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(Color.Yellow).stickers[2].color;
                newGreenSide.stickers[8].color = getSide(Color.Yellow).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(Color.Yellow).stickers[5].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(Color.Green).stickers[2].color;
                newWhiteSide.stickers[8].color = getSide(Color.Green).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(Color.Green).stickers[5].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("R'")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                //orange side stays the same
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(Color.Red).stickers[2].color;
                newRedSide.stickers[6].color = getSide(Color.Red).stickers[0].color;
                newRedSide.stickers[8].color = getSide(Color.Red).stickers[6].color;
                newRedSide.stickers[2].color = getSide(Color.Red).stickers[8].color;

                //turn edge stickers of red side
                newRedSide.stickers[3].color = getSide(Color.Red).stickers[1].color;
                newRedSide.stickers[7].color = getSide(Color.Red).stickers[3].color;
                newRedSide.stickers[8].color = getSide(Color.Red).stickers[7].color;
                newRedSide.stickers[1].color = getSide(Color.Red).stickers[8].color;     

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(Color.White).stickers[2].color;
                newGreenSide.stickers[8].color = getSide(Color.White).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(Color.White).stickers[5].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(Color.Green).stickers[2].color;
                newYellowSide.stickers[8].color = getSide(Color.Green).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(Color.Green).stickers[5].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(Color.Yellow).stickers[2].color;
                newBlueSide.stickers[8].color = getSide(Color.Yellow).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(Color.Yellow).stickers[5].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(Color.Blue).stickers[2].color;
                newWhiteSide.stickers[8].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(Color.Blue).stickers[5].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("R2")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                //orange side stays the same
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of white side
                newRedSide.stickers[8].color = getSide(Color.Red).stickers[0].color;
                newRedSide.stickers[0].color = getSide(Color.Red).stickers[8].color;
                newRedSide.stickers[6].color = getSide(Color.Red).stickers[2].color;
                newRedSide.stickers[2].color = getSide(Color.Red).stickers[6].color;

                //turn edge stickers of white side
                newRedSide.stickers[8].color = getSide(Color.Red).stickers[3].color;
                newRedSide.stickers[3].color = getSide(Color.Red).stickers[8].color;
                newRedSide.stickers[7].color = getSide(Color.Red).stickers[1].color;
                newRedSide.stickers[1].color = getSide(Color.Red).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(Color.White).stickers[2].color;
                newYellowSide.stickers[8].color = getSide(Color.White).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(Color.White).stickers[5].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(Color.Yellow).stickers[2].color;
                newWhiteSide.stickers[8].color = getSide(Color.Yellow).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(Color.Yellow).stickers[5].color;

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(Color.Blue).stickers[2].color;
                newGreenSide.stickers[8].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(Color.Blue).stickers[5].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(Color.Green).stickers[2].color;
                newBlueSide.stickers[8].color = getSide(Color.Green).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(Color.Green).stickers[5].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }

            //TURN GREEN SIDE
            if (turn.Equals("F")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                //blue side stays the same
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(Color.Green).stickers[0].color;
                newGreenSide.stickers[8].color = getSide(Color.Green).stickers[2].color;
                newGreenSide.stickers[6].color = getSide(Color.Green).stickers[8].color;
                newGreenSide.stickers[0].color = getSide(Color.Green).stickers[6].color;

                //turn edge stickers of green side
                newGreenSide.stickers[8].color = getSide(Color.Green).stickers[1].color;
                newGreenSide.stickers[7].color = getSide(Color.Green).stickers[8].color;
                newGreenSide.stickers[3].color = getSide(Color.Green).stickers[7].color;
                newGreenSide.stickers[1].color = getSide(Color.Green).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(Color.White).stickers[6].color;
                newRedSide.stickers[6].color = getSide(Color.White).stickers[8].color;
                //turn edge stickers of red side
                newRedSide.stickers[3].color = getSide(Color.White).stickers[7].color;

                //turn corner stickers of green side
                newYellowSide.stickers[0].color = getSide(Color.Red).stickers[0].color;
                newYellowSide.stickers[2].color = getSide(Color.Red).stickers[6].color;
                //turn edge stickers of green side
                newYellowSide.stickers[1].color = getSide(Color.Red).stickers[3].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[2].color = getSide(Color.Yellow).stickers[0].color;
                newOrangeSide.stickers[8].color = getSide(Color.Yellow).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(Color.Yellow).stickers[1].color;

                //turn corner stickers of blue side
                newWhiteSide.stickers[6].color = getSide(Color.Orange).stickers[2].color;
                newWhiteSide.stickers[8].color = getSide(Color.Orange).stickers[8].color;
                //turn edge stickers of blue side
                newWhiteSide.stickers[7].color = getSide(Color.Orange).stickers[5].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("F'")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                //blue side stays the same
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of red side
                newGreenSide.stickers[0].color = getSide(Color.Green).stickers[2].color;
                newGreenSide.stickers[6].color = getSide(Color.Green).stickers[0].color;
                newGreenSide.stickers[8].color = getSide(Color.Green).stickers[6].color;
                newGreenSide.stickers[2].color = getSide(Color.Green).stickers[8].color;

                //turn edge stickers of red side
                newGreenSide.stickers[3].color = getSide(Color.Green).stickers[1].color;
                newGreenSide.stickers[7].color = getSide(Color.Green).stickers[3].color;
                newGreenSide.stickers[8].color = getSide(Color.Green).stickers[7].color;
                newGreenSide.stickers[1].color = getSide(Color.Green).stickers[8].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[2].color = getSide(Color.White).stickers[8].color;
                newOrangeSide.stickers[8].color = getSide(Color.White).stickers[6].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(Color.White).stickers[7].color;

                //turn corner stickers of green side
                newYellowSide.stickers[0].color = getSide(Color.Orange).stickers[2].color;
                newYellowSide.stickers[2].color = getSide(Color.Orange).stickers[8].color;
                //turn edge stickers of green side
                newYellowSide.stickers[1].color = getSide(Color.Orange).stickers[5].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(Color.Yellow).stickers[0].color;
                newRedSide.stickers[8].color = getSide(Color.Yellow).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[7].color = getSide(Color.Yellow).stickers[1].color;

                //turn corner stickers of blue side
                newWhiteSide.stickers[6].color = getSide(Color.Red).stickers[0].color;
                newWhiteSide.stickers[8].color = getSide(Color.Red).stickers[6].color;
                //turn edge stickers of blue side
                newWhiteSide.stickers[7].color = getSide(Color.Red).stickers[3].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("F2")) {
                Side newWhiteSide = getSide(Color.White);
                Side newRedSide = getSide(Color.Red);
                Side newGreenSide = getSide(Color.Green);
                Side newOrangeSide = getSide(Color.Orange);
                Side newBlueSide = getSide(Color.Blue);
                //yellow side stays the same
                Side newYellowSide = getSide(Color.Yellow);

                //turn corner stickers of white side
                newGreenSide.stickers[8].color = getSide(Color.Green).stickers[0].color;
                newGreenSide.stickers[0].color = getSide(Color.Green).stickers[8].color;
                newGreenSide.stickers[6].color = getSide(Color.Green).stickers[2].color;
                newGreenSide.stickers[2].color = getSide(Color.Green).stickers[6].color;

                //turn edge stickers of white side
                newGreenSide.stickers[8].color = getSide(Color.Green).stickers[3].color;
                newGreenSide.stickers[3].color = getSide(Color.Green).stickers[8].color;
                newGreenSide.stickers[7].color = getSide(Color.Green).stickers[1].color;
                newGreenSide.stickers[1].color = getSide(Color.Green).stickers[7].color;

                //turn corner stickers of green side
                newYellowSide.stickers[0].color = getSide(Color.White).stickers[6].color;
                newYellowSide.stickers[2].color = getSide(Color.White).stickers[8].color;
                //turn edge stickers of green side
                newYellowSide.stickers[1].color = getSide(Color.White).stickers[7].color;

                //turn corner stickers of blue side
                newWhiteSide.stickers[6].color = getSide(Color.Yellow).stickers[0].color;
                newWhiteSide.stickers[8].color = getSide(Color.Yellow).stickers[2].color;
                //turn edge stickers of blue side
                newWhiteSide.stickers[7].color = getSide(Color.Yellow).stickers[1].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(Color.Orange).stickers[8].color;
                newRedSide.stickers[6].color = getSide(Color.Orange).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[3].color = getSide(Color.Orange).stickers[5].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[8].color = getSide(Color.Red).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(Color.Red).stickers[6].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(Color.Red).stickers[3].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }

            //TURN BLUE SIDE
            if (turn.Equals("B")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                //green side stays the same
                Side newGreenSide = getSide(Color.Green);      
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(Color.Blue).stickers[0].color;
                newBlueSide.stickers[8].color = getSide(Color.Blue).stickers[2].color;
                newBlueSide.stickers[6].color = getSide(Color.Blue).stickers[8].color;
                newBlueSide.stickers[0].color = getSide(Color.Blue).stickers[6].color;

                //turn edge stickers of blue side
                newBlueSide.stickers[8].color = getSide(Color.Blue).stickers[1].color;
                newBlueSide.stickers[7].color = getSide(Color.Blue).stickers[8].color;
                newBlueSide.stickers[3].color = getSide(Color.Blue).stickers[7].color;
                newBlueSide.stickers[1].color = getSide(Color.Blue).stickers[3].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(Color.White).stickers[2].color;
                newOrangeSide.stickers[6].color = getSide(Color.White).stickers[0].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(Color.White).stickers[1].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(Color.Orange).stickers[6].color;
                newYellowSide.stickers[2].color = getSide(Color.Orange).stickers[0].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[1].color = getSide(Color.Orange).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(Color.Yellow).stickers[0].color;
                newRedSide.stickers[8].color = getSide(Color.Yellow).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(Color.Yellow).stickers[1].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(Color.Blue).stickers[2].color;
                newWhiteSide.stickers[2].color = getSide(Color.Blue).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[1].color = getSide(Color.Blue).stickers[5].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("B'")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                //green side stays the same
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of red side
                newBlueSide.stickers[0].color = getSide(Color.Blue).stickers[2].color;
                newBlueSide.stickers[6].color = getSide(Color.Blue).stickers[0].color;
                newBlueSide.stickers[8].color = getSide(Color.Blue).stickers[6].color;
                newBlueSide.stickers[2].color = getSide(Color.Blue).stickers[8].color;

                //turn edge stickers of red side
                newBlueSide.stickers[3].color = getSide(Color.Blue).stickers[1].color;
                newBlueSide.stickers[7].color = getSide(Color.Blue).stickers[3].color;
                newBlueSide.stickers[8].color = getSide(Color.Blue).stickers[7].color;
                newBlueSide.stickers[1].color = getSide(Color.Blue).stickers[8].color;

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(Color.White).stickers[0].color;
                newRedSide.stickers[8].color = getSide(Color.White).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(Color.White).stickers[1].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(Color.Red).stickers[2].color;
                newYellowSide.stickers[2].color = getSide(Color.Red).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[1].color = getSide(Color.Red).stickers[5].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(Color.Yellow).stickers[0].color;
                newOrangeSide.stickers[0].color = getSide(Color.Yellow).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(Color.Yellow).stickers[1].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(Color.Orange).stickers[6].color;
                newWhiteSide.stickers[2].color = getSide(Color.Orange).stickers[0].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[1].color = getSide(Color.Orange).stickers[3].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            if (turn.Equals("B2")) {
                Side newWhiteSide = getSide(Color.White);
                Side newYellowSide = getSide(Color.Yellow);
                Side newOrangeSide = getSide(Color.Orange);
                Side newRedSide = getSide(Color.Red);
                //green side stays the same
                Side newGreenSide = getSide(Color.Green);
                Side newBlueSide = getSide(Color.Blue);

                //turn corner stickers of white side
                newBlueSide.stickers[8].color = getSide(Color.Blue).stickers[0].color;
                newBlueSide.stickers[0].color = getSide(Color.Blue).stickers[8].color;
                newBlueSide.stickers[6].color = getSide(Color.Blue).stickers[2].color;
                newBlueSide.stickers[2].color = getSide(Color.Blue).stickers[6].color;

                //turn edge stickers of white side
                newBlueSide.stickers[8].color = getSide(Color.Blue).stickers[3].color;
                newBlueSide.stickers[3].color = getSide(Color.Blue).stickers[8].color;
                newBlueSide.stickers[7].color = getSide(Color.Blue).stickers[1].color;
                newBlueSide.stickers[1].color = getSide(Color.Blue).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(Color.White).stickers[0].color;
                newYellowSide.stickers[2].color = getSide(Color.White).stickers[2].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[1].color = getSide(Color.White).stickers[1].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(Color.Yellow).stickers[0].color;
                newWhiteSide.stickers[2].color = getSide(Color.Yellow).stickers[2].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[1].color = getSide(Color.Yellow).stickers[1].color;

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(Color.Orange).stickers[0].color;
                newRedSide.stickers[8].color = getSide(Color.Orange).stickers[6].color;
                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(Color.Orange).stickers[3].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(Color.Red).stickers[2].color;
                newOrangeSide.stickers[6].color = getSide(Color.Red).stickers[8].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(Color.Red).stickers[5].color;

                List<Side> newSides = new List<Side>();
                newSides.Add(newWhiteSide);
                newSides.Add(newYellowSide);
                newSides.Add(newOrangeSide);
                newSides.Add(newRedSide);
                newSides.Add(newGreenSide);
                newSides.Add(newBlueSide);
                return new Cube(newSides);
            }
            return new Cube();
        }
    }
}