﻿using LakaCubeTimer.model;
using System.Data.OleDb;

namespace LakaCubeTimer.util {
    public static class Util {
        public static string[] turns = new string[] { "U", "D", "L", "R", "F", "B" };
        public static OleDbConnection GetConnection() {
            return new OleDbConnection(Properties.Settings.Default.timesConnectionString);
        }

        public static DateTime dateTimeWithoutMilliseconds(DateTime date) {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
        }
        public static List<string> generateScramble() {
            int numOfDoubleTurns = 0;
            const int MAX_DOUBLE_TURNS = 8;
            bool isDoubleTurn = false;
            bool isPrimeTurn = false;
            List<string> scramble = new List<string>();
            string currentTurn = "";
            string prevTurn = turns[new Random().Next(0, turns.Length)];
            for (int i = 0; i < 18; i++) {
                int indexCurrentTurn = new Random().Next(0, turns.Length);
                if (!prevTurn.Equals(turns[indexCurrentTurn])) {
                    currentTurn = turns[indexCurrentTurn];
                }
                else {
                    if (indexCurrentTurn == turns.Length - 1) {
                        currentTurn = turns[0];
                    }
                    else {
                        currentTurn = turns[indexCurrentTurn + 1];
                    }
                }
                prevTurn = currentTurn;
                isDoubleTurn = new Random().Next(0, 100) <= 50;

                isPrimeTurn = new Random().Next(0, 100) <= 50;

                if (isDoubleTurn) {
                    if (numOfDoubleTurns < MAX_DOUBLE_TURNS) {
                        scramble.Add(currentTurn + "2");
                    }
                    else {
                        scramble.Add(currentTurn);
                    }
                    numOfDoubleTurns++;
                }
                else if (isPrimeTurn) {
                    scramble.Add(currentTurn + "'");
                }
                else {
                    scramble.Add(currentTurn);
                }
            }
            return scramble;
        }
        public static string scrambleToString(List<string> scramble) {
            string scrambleString = "";
            foreach (string turn in scramble) {
                scrambleString += turn + " ";
            }
            return scrambleString.Trim();
        }
        public static string sideToString(Side side) {
            string stickersString = "";
            stickersString += " " + side.stickers[0].color.Name[0] + " " + side.stickers[1].color.Name[0] + " " + side.stickers[2].color.Name[0] + "\n";
            stickersString += " " + side.stickers[3].color.Name[0] + " " + side.stickers[4].color.Name[0] + " " + side.stickers[5].color.Name[0] + "\n";
            stickersString += " " + side.stickers[6].color.Name[0] + " " + side.stickers[7].color.Name[0] + " " + side.stickers[8].color.Name[0] + "\n";
            return stickersString;
        }
        public static Side getSide(Cube cube, Color color) {
            foreach (Side side in cube.sides) {
                if (side.stickers[4].color.Equals(color)) {
                    return initializeSide(side);
                }
            }
            return new Side(Color.White);
        }
        public static Side initializeSide(Side side) {
            List<Sticker> newStickers = new List<Sticker>();
            foreach(Sticker sticker in side.stickers) {
                Sticker newSticker = new Sticker(sticker.id, sticker.color);
                newStickers.Add(newSticker);
            }
            return new Side(newStickers);
        }
        public static Cube turnCube(Cube cube, String turn) {
            //TURN WHITE SIDE
            if (turn.Equals("U")) {
                Side newWhiteSide = initializeSide(cube.sides[0]);
                //yellow side stays the same
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(cube, Color.White).stickers[0].color;
                newWhiteSide.stickers[8].color = getSide(cube, Color.White).stickers[2].color;
                newWhiteSide.stickers[6].color = getSide(cube, Color.White).stickers[8].color;
                newWhiteSide.stickers[0].color = getSide(cube, Color.White).stickers[6].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(cube, Color.White).stickers[1].color;
                newWhiteSide.stickers[7].color = getSide(cube, Color.White).stickers[5].color;
                newWhiteSide.stickers[3].color = getSide(cube, Color.White).stickers[7].color;
                newWhiteSide.stickers[1].color = getSide(cube, Color.White).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(cube, Color.Blue).stickers[0].color;
                newRedSide.stickers[2].color = getSide(cube, Color.Blue).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[1].color = getSide(cube, Color.Blue).stickers[1].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(cube, Color.Red).stickers[0].color;
                newGreenSide.stickers[2].color = getSide(cube, Color.Red).stickers[2].color;
                //turn edge stickers of green side
                newGreenSide.stickers[1].color = getSide(cube, Color.Red).stickers[1].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(cube, Color.Green).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(cube, Color.Green).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[1].color = getSide(cube, Color.Green).stickers[1].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(cube, Color.Orange).stickers[0].color;
                newBlueSide.stickers[2].color = getSide(cube, Color.Orange).stickers[2].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[1].color = getSide(cube, Color.Orange).stickers[1].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                //yellow side stays the same
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(cube, Color.White).stickers[2].color;
                newWhiteSide.stickers[6].color = getSide(cube, Color.White).stickers[0].color;
                newWhiteSide.stickers[8].color = getSide(cube, Color.White).stickers[6].color;
                newWhiteSide.stickers[2].color = getSide(cube, Color.White).stickers[8].color;

                //turn edge stickers of white side
                newWhiteSide.stickers[3].color = getSide(cube, Color.White).stickers[1].color;
                newWhiteSide.stickers[7].color = getSide(cube, Color.White).stickers[3].color;
                newWhiteSide.stickers[5].color = getSide(cube, Color.White).stickers[7].color;
                newWhiteSide.stickers[1].color = getSide(cube, Color.White).stickers[5].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(cube, Color.Blue).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(cube, Color.Blue).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[1].color = getSide(cube, Color.Blue).stickers[1].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(cube, Color.Orange).stickers[0].color;
                newGreenSide.stickers[2].color = getSide(cube, Color.Orange).stickers[2].color;
                //turn edge stickers of green side
                newGreenSide.stickers[1].color = getSide(cube, Color.Orange).stickers[1].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(cube, Color.Green).stickers[0].color;
                newRedSide.stickers[2].color = getSide(cube, Color.Green).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[1].color = getSide(cube, Color.Green).stickers[1].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(cube, Color.Red).stickers[0].color;
                newBlueSide.stickers[2].color = getSide(cube, Color.Red).stickers[2].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[1].color = getSide(cube, Color.Red).stickers[1].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                //yellow side stays the same
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of white side
                newWhiteSide.stickers[8].color = getSide(cube, Color.White).stickers[0].color;
                newWhiteSide.stickers[0].color = getSide(cube, Color.White).stickers[8].color;
                newWhiteSide.stickers[6].color = getSide(cube, Color.White).stickers[2].color;
                newWhiteSide.stickers[2].color = getSide(cube, Color.White).stickers[6].color;

                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(cube, Color.White).stickers[3].color;
                newWhiteSide.stickers[3].color = getSide(cube, Color.White).stickers[5].color;
                newWhiteSide.stickers[7].color = getSide(cube, Color.White).stickers[1].color;
                newWhiteSide.stickers[1].color = getSide(cube, Color.White).stickers[7].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(cube, Color.Orange).stickers[0].color;
                newRedSide.stickers[2].color = getSide(cube, Color.Orange).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[1].color = getSide(cube, Color.Orange).stickers[1].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(cube, Color.Red).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(cube, Color.Red).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[1].color = getSide(cube, Color.Red).stickers[1].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(cube, Color.Green).stickers[0].color;
                newBlueSide.stickers[2].color = getSide(cube, Color.Green).stickers[2].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[1].color = getSide(cube, Color.Green).stickers[1].color;

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(cube, Color.Blue).stickers[0].color;
                newGreenSide.stickers[2].color = getSide(cube, Color.Blue).stickers[2].color;
                //turn edge stickers of green side
                newGreenSide.stickers[1].color = getSide(cube, Color.Blue).stickers[1].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);    
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[0].color;
                newYellowSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[2].color;
                newYellowSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[8].color;
                newYellowSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[6].color;

                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[1].color;
                newYellowSide.stickers[7].color = getSide(cube, Color.Yellow).stickers[5].color;
                newYellowSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[7].color;
                newYellowSide.stickers[1].color = getSide(cube, Color.Yellow).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(cube, Color.Green).stickers[6].color;
                newRedSide.stickers[8].color = getSide(cube, Color.Green).stickers[8].color;
                //turn edge stickers of red side
                newRedSide.stickers[7].color = getSide(cube, Color.Green).stickers[7].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(cube, Color.Red).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.Red).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[7].color = getSide(cube, Color.Red).stickers[7].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(cube, Color.Blue).stickers[6].color;
                newOrangeSide.stickers[8].color = getSide(cube, Color.Blue).stickers[8].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[7].color = getSide(cube, Color.Blue).stickers[7].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(cube, Color.Orange).stickers[6].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.Orange).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[7].color = getSide(cube, Color.Orange).stickers[7].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[2].color;
                newYellowSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[0].color;
                newYellowSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[6].color;
                newYellowSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[8].color;

                //turn edge stickers of yellow side
                newYellowSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[1].color;
                newYellowSide.stickers[7].color = getSide(cube, Color.Yellow).stickers[3].color;
                newYellowSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[7].color;
                newYellowSide.stickers[1].color = getSide(cube, Color.Yellow).stickers[5].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(cube, Color.Blue).stickers[6].color;
                newRedSide.stickers[8].color = getSide(cube, Color.Blue).stickers[8].color;
                //turn edge stickers of red side
                newRedSide.stickers[7].color = getSide(cube, Color.Blue).stickers[7].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(cube, Color.Red).stickers[6].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.Red).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[7].color = getSide(cube, Color.Red).stickers[7].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(cube, Color.Green).stickers[6].color;
                newOrangeSide.stickers[8].color = getSide(cube, Color.Green).stickers[8].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[7].color = getSide(cube, Color.Green).stickers[7].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(cube, Color.Orange).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.Orange).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[7].color = getSide(cube, Color.Orange).stickers[7].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of yellow side
                newYellowSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[0].color;
                newYellowSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[8].color;
                newYellowSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[2].color;
                newYellowSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[6].color;

                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[3].color;
                newYellowSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[5].color;
                newYellowSide.stickers[7].color = getSide(cube, Color.Yellow).stickers[1].color;
                newYellowSide.stickers[1].color = getSide(cube, Color.Yellow).stickers[7].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(cube, Color.Orange).stickers[6].color;
                newRedSide.stickers[8].color = getSide(cube, Color.Orange).stickers[8].color;
                //turn edge stickers of red side
                newRedSide.stickers[7].color = getSide(cube, Color.Orange).stickers[7].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(cube, Color.Red).stickers[6].color;
                newOrangeSide.stickers[8].color = getSide(cube, Color.Red).stickers[8].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[7].color = getSide(cube, Color.Red).stickers[7].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(cube, Color.Green).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.Green).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[7].color = getSide(cube, Color.Green).stickers[7].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(cube, Color.Blue).stickers[6].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.Blue).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[7].color = getSide(cube, Color.Blue).stickers[7].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                //red side stays the same
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of orange side
                newOrangeSide.stickers[2].color = getSide(cube, Color.Orange).stickers[0].color;
                newOrangeSide.stickers[8].color = getSide(cube, Color.Orange).stickers[2].color;
                newOrangeSide.stickers[6].color = getSide(cube, Color.Orange).stickers[8].color;
                newOrangeSide.stickers[0].color = getSide(cube, Color.Orange).stickers[6].color;

                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(cube, Color.Orange).stickers[1].color;
                newOrangeSide.stickers[7].color = getSide(cube, Color.Orange).stickers[5].color;
                newOrangeSide.stickers[3].color = getSide(cube, Color.Orange).stickers[7].color;
                newOrangeSide.stickers[1].color = getSide(cube, Color.Orange).stickers[3].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(cube, Color.White).stickers[6].color;
                newGreenSide.stickers[0].color = getSide(cube, Color.White).stickers[0].color;
                //turn edge stickers of green side
                newGreenSide.stickers[3].color = getSide(cube, Color.White).stickers[3].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[6].color = getSide(cube, Color.Green).stickers[6].color;
                newYellowSide.stickers[0].color = getSide(cube, Color.Green).stickers[0].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[3].color = getSide(cube, Color.Green).stickers[3].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[0].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[3].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[6].color = getSide(cube, Color.Blue).stickers[2].color;
                newWhiteSide.stickers[0].color = getSide(cube, Color.Blue).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[3].color = getSide(cube, Color.Blue).stickers[5].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                //red side stays the same
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of orange side
                newOrangeSide.stickers[0].color = getSide(cube, Color.Orange).stickers[2].color;
                newOrangeSide.stickers[6].color = getSide(cube, Color.Orange).stickers[0].color;
                newOrangeSide.stickers[8].color = getSide(cube, Color.Orange).stickers[6].color;
                newOrangeSide.stickers[2].color = getSide(cube, Color.Orange).stickers[8].color;

                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(cube, Color.Orange).stickers[1].color;
                newOrangeSide.stickers[7].color = getSide(cube, Color.Orange).stickers[3].color;
                newOrangeSide.stickers[5].color = getSide(cube, Color.Orange).stickers[7].color;
                newOrangeSide.stickers[1].color = getSide(cube, Color.Orange).stickers[5].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(cube, Color.White).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.White).stickers[0].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(cube, Color.White).stickers[3].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[6].color = getSide(cube, Color.Blue).stickers[2].color;
                newYellowSide.stickers[0].color = getSide(cube, Color.Blue).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[3].color = getSide(cube, Color.Blue).stickers[5].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[6].color;
                newGreenSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[0].color;
                //turn edge stickers of green side
                newGreenSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[3].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[6].color = getSide(cube, Color.Green).stickers[6].color;
                newWhiteSide.stickers[0].color = getSide(cube, Color.Green).stickers[0].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[3].color = getSide(cube, Color.Green).stickers[3].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                //red side stays the same
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of orange side
                newOrangeSide.stickers[8].color = getSide(cube, Color.Orange).stickers[0].color;
                newOrangeSide.stickers[0].color = getSide(cube, Color.Orange).stickers[8].color;
                newOrangeSide.stickers[6].color = getSide(cube, Color.Orange).stickers[2].color;
                newOrangeSide.stickers[2].color = getSide(cube, Color.Orange).stickers[6].color;

                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(cube, Color.Orange).stickers[3].color;
                newOrangeSide.stickers[3].color = getSide(cube, Color.Orange).stickers[5].color;
                newOrangeSide.stickers[7].color = getSide(cube, Color.Orange).stickers[1].color;
                newOrangeSide.stickers[1].color = getSide(cube, Color.Orange).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[6].color = getSide(cube, Color.White).stickers[6].color;
                newYellowSide.stickers[0].color = getSide(cube, Color.White).stickers[0].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[3].color = getSide(cube, Color.White).stickers[3].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[6].color;
                newWhiteSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[0].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[3].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(cube, Color.Green).stickers[6].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.Green).stickers[0].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(cube, Color.Green).stickers[3].color;

                //turn corner stickers of green side
                newGreenSide.stickers[6].color = getSide(cube, Color.Blue).stickers[2].color;
                newGreenSide.stickers[0].color = getSide(cube, Color.Blue).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[3].color = getSide(cube, Color.Blue).stickers[5].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                //orange side stays the same
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(cube, Color.Red).stickers[0].color;
                newRedSide.stickers[8].color = getSide(cube, Color.Red).stickers[2].color;
                newRedSide.stickers[6].color = getSide(cube, Color.Red).stickers[8].color;
                newRedSide.stickers[0].color = getSide(cube, Color.Red).stickers[6].color;

                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(cube, Color.Red).stickers[1].color;
                newRedSide.stickers[7].color = getSide(cube, Color.Red).stickers[5].color;
                newRedSide.stickers[3].color = getSide(cube, Color.Red).stickers[7].color;
                newRedSide.stickers[1].color = getSide(cube, Color.Red).stickers[3].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(cube, Color.White).stickers[2].color;
                newBlueSide.stickers[0].color = getSide(cube, Color.White).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[3].color = getSide(cube, Color.White).stickers[5].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(cube, Color.Blue).stickers[6].color;
                newYellowSide.stickers[8].color = getSide(cube, Color.Blue).stickers[0].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(cube, Color.Blue).stickers[3].color;

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[2].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[5].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(cube, Color.Green).stickers[2].color;
                newWhiteSide.stickers[8].color = getSide(cube, Color.Green).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(cube, Color.Green).stickers[5].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                //orange side stays the same
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(cube, Color.Red).stickers[2].color;
                newRedSide.stickers[6].color = getSide(cube, Color.Red).stickers[0].color;
                newRedSide.stickers[8].color = getSide(cube, Color.Red).stickers[6].color;
                newRedSide.stickers[2].color = getSide(cube, Color.Red).stickers[8].color;

                //turn edge stickers of red side
                newRedSide.stickers[3].color = getSide(cube, Color.Red).stickers[1].color;
                newRedSide.stickers[7].color = getSide(cube, Color.Red).stickers[3].color;
                newRedSide.stickers[5].color = getSide(cube, Color.Red).stickers[7].color;
                newRedSide.stickers[1].color = getSide(cube, Color.Red).stickers[5].color;

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(cube, Color.White).stickers[2].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.White).stickers[8].color;
                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(cube, Color.White).stickers[5].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(cube, Color.Green).stickers[2].color;
                newYellowSide.stickers[8].color = getSide(cube, Color.Green).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(cube, Color.Green).stickers[5].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[2].color;
                newBlueSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[8].color;      
                //turn edge stickers of blue side
                newBlueSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[5].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(cube, Color.Blue).stickers[6].color;
                newWhiteSide.stickers[8].color = getSide(cube, Color.Blue).stickers[0].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(cube, Color.Blue).stickers[3].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                //orange side stays the same
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of red side
                newRedSide.stickers[8].color = getSide(cube, Color.Red).stickers[0].color;
                newRedSide.stickers[0].color = getSide(cube, Color.Red).stickers[8].color;
                newRedSide.stickers[6].color = getSide(cube, Color.Red).stickers[2].color;
                newRedSide.stickers[2].color = getSide(cube, Color.Red).stickers[6].color;

                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(cube, Color.Red).stickers[3].color;
                newRedSide.stickers[3].color = getSide(cube, Color.Red).stickers[5].color;
                newRedSide.stickers[7].color = getSide(cube, Color.Red).stickers[1].color;
                newRedSide.stickers[1].color = getSide(cube, Color.Red).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[2].color = getSide(cube, Color.White).stickers[2].color;
                newYellowSide.stickers[8].color = getSide(cube, Color.White).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[5].color = getSide(cube, Color.White).stickers[5].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[2].color;
                newWhiteSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[5].color;

                //turn corner stickers of blue side
                newBlueSide.stickers[6].color = getSide(cube, Color.Green).stickers[2].color;
                newBlueSide.stickers[0].color = getSide(cube, Color.Green).stickers[8].color;
                //turn edge stickers of blue side
                newBlueSide.stickers[3].color = getSide(cube, Color.Green).stickers[5].color;

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(cube, Color.Blue).stickers[6].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.Blue).stickers[0].color;
                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(cube, Color.Blue).stickers[3].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);       
                Side newGreenSide = initializeSide(cube.sides[4]);
                //blue side stays the same
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of green side
                newGreenSide.stickers[2].color = getSide(cube, Color.Green).stickers[0].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.Green).stickers[2].color;
                newGreenSide.stickers[6].color = getSide(cube, Color.Green).stickers[8].color;
                newGreenSide.stickers[0].color = getSide(cube, Color.Green).stickers[6].color;

                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(cube, Color.Green).stickers[1].color;
                newGreenSide.stickers[7].color = getSide(cube, Color.Green).stickers[5].color;
                newGreenSide.stickers[3].color = getSide(cube, Color.Green).stickers[7].color;
                newGreenSide.stickers[1].color = getSide(cube, Color.Green).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(cube, Color.White).stickers[8].color;
                newRedSide.stickers[0].color = getSide(cube, Color.White).stickers[6].color;
                //turn edge stickers of red side
                newRedSide.stickers[3].color = getSide(cube, Color.White).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(cube, Color.Red).stickers[6].color;
                newYellowSide.stickers[2].color = getSide(cube, Color.Red).stickers[0].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[1].color = getSide(cube, Color.Red).stickers[3].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[0].color;
                newOrangeSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[1].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[8].color = getSide(cube, Color.Orange).stickers[2].color;
                newWhiteSide.stickers[6].color = getSide(cube, Color.Orange).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[7].color = getSide(cube, Color.Orange).stickers[5].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                //blue side stays the same
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of green side
                newGreenSide.stickers[0].color = getSide(cube, Color.Green).stickers[2].color;
                newGreenSide.stickers[6].color = getSide(cube, Color.Green).stickers[0].color;
                newGreenSide.stickers[8].color = getSide(cube, Color.Green).stickers[6].color;
                newGreenSide.stickers[2].color = getSide(cube, Color.Green).stickers[8].color;

                //turn edge stickers of green side
                newGreenSide.stickers[3].color = getSide(cube, Color.Green).stickers[1].color;
                newGreenSide.stickers[7].color = getSide(cube, Color.Green).stickers[3].color;
                newGreenSide.stickers[5].color = getSide(cube, Color.Green).stickers[7].color;
                newGreenSide.stickers[1].color = getSide(cube, Color.Green).stickers[5].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[2].color = getSide(cube, Color.White).stickers[8].color;
                newOrangeSide.stickers[8].color = getSide(cube, Color.White).stickers[6].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(cube, Color.White).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(cube, Color.Orange).stickers[2].color;
                newYellowSide.stickers[2].color = getSide(cube, Color.Orange).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[1].color = getSide(cube, Color.Orange).stickers[5].color;

                //turn corner stickers of red side
                newRedSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[0].color;
                newRedSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[1].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[6].color = getSide(cube, Color.Red).stickers[0].color;
                newWhiteSide.stickers[8].color = getSide(cube, Color.Red).stickers[6].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[7].color = getSide(cube, Color.Red).stickers[3].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                Side newGreenSide = initializeSide(cube.sides[4]);
                //blue side stays the same
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of green side
                newGreenSide.stickers[8].color = getSide(cube, Color.Green).stickers[0].color;
                newGreenSide.stickers[0].color = getSide(cube, Color.Green).stickers[8].color;
                newGreenSide.stickers[6].color = getSide(cube, Color.Green).stickers[2].color;
                newGreenSide.stickers[2].color = getSide(cube, Color.Green).stickers[6].color;

                //turn edge stickers of green side
                newGreenSide.stickers[5].color = getSide(cube, Color.Green).stickers[3].color;
                newGreenSide.stickers[3].color = getSide(cube, Color.Green).stickers[5].color;
                newGreenSide.stickers[7].color = getSide(cube, Color.Green).stickers[1].color;
                newGreenSide.stickers[1].color = getSide(cube, Color.Green).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[0].color = getSide(cube, Color.White).stickers[8].color;
                newYellowSide.stickers[2].color = getSide(cube, Color.White).stickers[6].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[1].color = getSide(cube, Color.White).stickers[7].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[0].color;
                newWhiteSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[2].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[7].color = getSide(cube, Color.Yellow).stickers[1].color;

                //turn corner stickers of red side
                newRedSide.stickers[0].color = getSide(cube, Color.Orange).stickers[8].color;
                newRedSide.stickers[6].color = getSide(cube, Color.Orange).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[3].color = getSide(cube, Color.Orange).stickers[5].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[8].color = getSide(cube, Color.Red).stickers[0].color;
                newOrangeSide.stickers[2].color = getSide(cube, Color.Red).stickers[6].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[5].color = getSide(cube, Color.Red).stickers[3].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                //green side stays the same
                Side newGreenSide = initializeSide(cube.sides[4]);             
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of blue side
                newBlueSide.stickers[2].color = getSide(cube, Color.Blue).stickers[0].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.Blue).stickers[2].color;
                newBlueSide.stickers[6].color = getSide(cube, Color.Blue).stickers[8].color;
                newBlueSide.stickers[0].color = getSide(cube, Color.Blue).stickers[6].color;

                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(cube, Color.Blue).stickers[1].color;
                newBlueSide.stickers[7].color = getSide(cube, Color.Blue).stickers[5].color;
                newBlueSide.stickers[3].color = getSide(cube, Color.Blue).stickers[7].color;
                newBlueSide.stickers[1].color = getSide(cube, Color.Blue).stickers[3].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(cube, Color.White).stickers[0].color;
                newOrangeSide.stickers[0].color = getSide(cube, Color.White).stickers[2].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(cube, Color.White).stickers[1].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[8].color = getSide(cube, Color.Orange).stickers[6].color;
                newYellowSide.stickers[6].color = getSide(cube, Color.Orange).stickers[0].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[7].color = getSide(cube, Color.Orange).stickers[3].color;

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[8].color;
                newRedSide.stickers[8].color = getSide(cube, Color.Yellow).stickers[6].color;
                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(cube, Color.Yellow).stickers[7].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(cube, Color.Red).stickers[2].color;
                newWhiteSide.stickers[2].color = getSide(cube, Color.Red).stickers[8].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[1].color = getSide(cube, Color.Red).stickers[5].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                //green side stays the same
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of blue side
                newBlueSide.stickers[0].color = getSide(cube, Color.Blue).stickers[2].color;
                newBlueSide.stickers[6].color = getSide(cube, Color.Blue).stickers[0].color;
                newBlueSide.stickers[8].color = getSide(cube, Color.Blue).stickers[6].color;
                newBlueSide.stickers[2].color = getSide(cube, Color.Blue).stickers[8].color;

                //turn edge stickers of blue side
                newBlueSide.stickers[3].color = getSide(cube, Color.Blue).stickers[1].color;
                newBlueSide.stickers[7].color = getSide(cube, Color.Blue).stickers[3].color;
                newBlueSide.stickers[5].color = getSide(cube, Color.Blue).stickers[7].color;
                newBlueSide.stickers[1].color = getSide(cube, Color.Blue).stickers[5].color;

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(cube, Color.White).stickers[0].color;
                newRedSide.stickers[8].color = getSide(cube, Color.White).stickers[2].color;
                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(cube, Color.White).stickers[1].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[8].color = getSide(cube, Color.Red).stickers[2].color;
                newYellowSide.stickers[6].color = getSide(cube, Color.Red).stickers[8].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[7].color = getSide(cube, Color.Red).stickers[5].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(cube, Color.Yellow).stickers[8].color;
                newOrangeSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[6].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(cube, Color.Yellow).stickers[7].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(cube, Color.Orange).stickers[6].color;
                newWhiteSide.stickers[2].color = getSide(cube, Color.Orange).stickers[0].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[1].color = getSide(cube, Color.Orange).stickers[3].color;

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
                Side newWhiteSide = initializeSide(cube.sides[0]);
                Side newYellowSide = initializeSide(cube.sides[1]);
                Side newOrangeSide = initializeSide(cube.sides[2]);
                Side newRedSide = initializeSide(cube.sides[3]);
                //green side stays the same
                Side newGreenSide = initializeSide(cube.sides[4]);
                Side newBlueSide = initializeSide(cube.sides[5]);

                //turn corner stickers of blue side
                newBlueSide.stickers[8].color = getSide(cube, Color.Blue).stickers[0].color;
                newBlueSide.stickers[0].color = getSide(cube, Color.Blue).stickers[8].color;
                newBlueSide.stickers[6].color = getSide(cube, Color.Blue).stickers[2].color;
                newBlueSide.stickers[2].color = getSide(cube, Color.Blue).stickers[6].color;

                //turn edge stickers of blue side
                newBlueSide.stickers[5].color = getSide(cube, Color.Blue).stickers[3].color;
                newBlueSide.stickers[3].color = getSide(cube, Color.Blue).stickers[5].color;
                newBlueSide.stickers[7].color = getSide(cube, Color.Blue).stickers[1].color;
                newBlueSide.stickers[1].color = getSide(cube, Color.Blue).stickers[7].color;

                //turn corner stickers of yellow side
                newYellowSide.stickers[8].color = getSide(cube, Color.White).stickers[0].color;
                newYellowSide.stickers[6].color = getSide(cube, Color.White).stickers[2].color;
                //turn edge stickers of yellow side
                newYellowSide.stickers[7].color = getSide(cube, Color.White).stickers[1].color;

                //turn corner stickers of white side
                newWhiteSide.stickers[0].color = getSide(cube, Color.Yellow).stickers[8].color;
                newWhiteSide.stickers[2].color = getSide(cube, Color.Yellow).stickers[6].color;
                //turn edge stickers of white side
                newWhiteSide.stickers[1].color = getSide(cube, Color.Yellow).stickers[7].color;

                //turn corner stickers of red side
                newRedSide.stickers[2].color = getSide(cube, Color.Orange).stickers[6].color;
                newRedSide.stickers[8].color = getSide(cube, Color.Orange).stickers[0].color;
                //turn edge stickers of red side
                newRedSide.stickers[5].color = getSide(cube, Color.Orange).stickers[3].color;

                //turn corner stickers of orange side
                newOrangeSide.stickers[6].color = getSide(cube, Color.Red).stickers[2].color;
                newOrangeSide.stickers[0].color = getSide(cube, Color.Red).stickers[8].color;
                //turn edge stickers of orange side
                newOrangeSide.stickers[3].color = getSide(cube, Color.Red).stickers[5].color;

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

        public static string cubeToString(Cube cube) {
            string cubeString = "";
            //white side
            cubeString += " -  -  -  " + cube.sides[0].stickers[0].color.Name[0] + " " + cube.sides[0].stickers[1].color.Name[0] + " " + cube.sides[0].stickers[2].color.Name[0] + "\n";
            cubeString += " -  -  -  " + cube.sides[0].stickers[3].color.Name[0] + " " + cube.sides[0].stickers[4].color.Name[0] + " " + cube.sides[0].stickers[5].color.Name[0] + "\n";
            cubeString += " -  -  -  " + cube.sides[0].stickers[6].color.Name[0] + " " + cube.sides[0].stickers[7].color.Name[0] + " " + cube.sides[0].stickers[8].color.Name[0] + "\n";
            //orange, green, red, blue sides
            cubeString += " " + cube.sides[2].stickers[0].color.Name[0] + " " + cube.sides[2].stickers[1].color.Name[0] + " " + cube.sides[2].stickers[2].color.Name[0] + 
                          " " + cube.sides[4].stickers[0].color.Name[0] + " " + cube.sides[4].stickers[1].color.Name[0] + " " + cube.sides[4].stickers[2].color.Name[0] + 
                          " " + cube.sides[3].stickers[0].color.Name[0] + " " + cube.sides[3].stickers[1].color.Name[0] + " " + cube.sides[3].stickers[2].color.Name[0] + 
                          " " + cube.sides[5].stickers[0].color.Name[0] + " " + cube.sides[5].stickers[1].color.Name[0] + " " + cube.sides[5].stickers[2].color.Name[0] + "\n";
            cubeString += " " + cube.sides[2].stickers[3].color.Name[0] + " " + cube.sides[2].stickers[4].color.Name[0] + " " + cube.sides[2].stickers[5].color.Name[0] +
                          " " + cube.sides[4].stickers[3].color.Name[0] + " " + cube.sides[4].stickers[4].color.Name[0] + " " + cube.sides[4].stickers[5].color.Name[0] +
                          " " + cube.sides[3].stickers[3].color.Name[0] + " " + cube.sides[3].stickers[4].color.Name[0] + " " + cube.sides[3].stickers[5].color.Name[0] +
                          " " + cube.sides[5].stickers[3].color.Name[0] + " " + cube.sides[5].stickers[4].color.Name[0] + " " + cube.sides[5].stickers[5].color.Name[0] + "\n";
            cubeString += " " + cube.sides[2].stickers[6].color.Name[0] + " " + cube.sides[2].stickers[7].color.Name[0] + " " + cube.sides[2].stickers[8].color.Name[0] + 
                          " " + cube.sides[4].stickers[6].color.Name[0] + " " + cube.sides[4].stickers[7].color.Name[0] + " " + cube.sides[4].stickers[8].color.Name[0] + 
                          " " + cube.sides[3].stickers[6].color.Name[0] + " " + cube.sides[3].stickers[7].color.Name[0] + " " + cube.sides[3].stickers[8].color.Name[0] + 
                          " " + cube.sides[5].stickers[6].color.Name[0] + " " + cube.sides[5].stickers[7].color.Name[0] + " " + cube.sides[5].stickers[8].color.Name[0] + "\n";
            //yellow side
            cubeString += " -  -  -  " + cube.sides[1].stickers[0].color.Name[0] + " " + cube.sides[1].stickers[1].color.Name[0] + " " + cube.sides[1].stickers[2].color.Name[0] + "\n";
            cubeString += " -  -  -  " + cube.sides[1].stickers[3].color.Name[0] + " " + cube.sides[1].stickers[4].color.Name[0] + " " + cube.sides[1].stickers[5].color.Name[0] + "\n";
            cubeString += " -  -  -  " + cube.sides[1].stickers[6].color.Name[0] + " " + cube.sides[1].stickers[7].color.Name[0] + " " + cube.sides[1].stickers[8].color.Name[0] + "\n";
            return cubeString;
        }
        public static Cube scrambleCube(Cube cube, List<string> scramble) {
            foreach (string turn in scramble) {
                cube = Util.turnCube(cube, turn);
            }
            return cube;
        }
    }
}