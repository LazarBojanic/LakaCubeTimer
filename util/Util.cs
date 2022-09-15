using LakaCubeTimer.model;
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
    }
}
