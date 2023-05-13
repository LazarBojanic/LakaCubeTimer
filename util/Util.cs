using LakaCubeTimer.model;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.Numerics;
using System.Reflection;

namespace LakaCubeTimer.util {
    public static class Util {
        private static int MAX_DOUBLE_TURNS = 9;
        private static string[] turns = new string[] { "U", "D", "L", "R", "F", "B" };
        public static Color colorWhite = Color.FromArgb(255, 255, 255);
        public static Color colorYellow = Color.FromArgb(255, 249, 46);
        public static Color colorOrange = Color.FromArgb(255, 119, 0);
        public static Color colorRed = Color.FromArgb(227, 7, 7);
        public static Color colorGreen = Color.FromArgb(52, 196, 8);
        public static Color colorBlue = Color.FromArgb(2, 91, 181);
        public static DateTime dateTimeWithoutMilliseconds(DateTime date) {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
        }
        public static long calculateAverage(List<SolveTimeInMillisecondsWithIsDNF> times) {
            int numOfDNFs = 0;
            int indexOfDNF = 0;
            List<SolveTimeInMillisecondsWithIsDNF> sortedTimes = times.OrderBy(o => o.solveTimeInMilliseconds).ToList();
            long bestTime = sortedTimes[0].solveTimeInMilliseconds;
            long worstTime = sortedTimes[sortedTimes.Count - 1].solveTimeInMilliseconds;
            long secondWorstTime = sortedTimes[sortedTimes.Count - 2].solveTimeInMilliseconds;
            long sumOfTimes = 0;
            int numOfTimesWithoutBestAndWorst = sortedTimes.Count - 2;
            for(int i = 0; i < sortedTimes.Count; i++) {
                if (sortedTimes[i].isDNF) {
                    numOfDNFs++;
                    if (numOfDNFs > 1) {
                        return 0;
                    }
                    indexOfDNF = i;
                    continue;
                }
                else {
                    sumOfTimes += sortedTimes[i].solveTimeInMilliseconds;
                }
            }
            if (numOfDNFs == 1) {
                if (indexOfDNF == 0) {
                    sumOfTimes -= sortedTimes[1].solveTimeInMilliseconds;
                }
                else {
                    sumOfTimes -= bestTime;
                }
            }
            else {
                sumOfTimes -= (bestTime + worstTime);
            }
            return sumOfTimes / numOfTimesWithoutBestAndWorst;
        }
        public static string listToString(List<SolveTimeInMillisecondsWithIsDNF> times) {
            string listString = "";
            foreach (SolveTimeInMillisecondsWithIsDNF time in times) {
                listString += time.solveTimeInMilliseconds + "\n";
            }
            return listString;
        }
        public static string timeToString(SolveTime time) {
            return time.solveTime + " | " + time.solveDate;
        }
        public static string scrambleToString(List<string> scramble) {
            string scrambleString = "";
            foreach (string turn in scramble) {
                scrambleString += turn + " ";
            }
            return scrambleString.Trim();
        }
        public static List<string> scrambleToList(string scramble) {
            List<string> scrambleList = new List<string>();
            foreach (string turn in scramble.Split(" ")) {
                scrambleList.Add(turn);
            }
            return scrambleList;
        }
        public static string sideToString(Side side) {
            string stickersString = "";
            stickersString += " " + side.stickers[0].colorNameAsSide + " " + side.stickers[1].colorNameAsSide + " " + side.stickers[2].colorNameAsSide + "\n";
            stickersString += " " + side.stickers[3].colorNameAsSide + " " + side.stickers[4].colorNameAsSide + " " + side.stickers[5].colorNameAsSide + "\n";
            stickersString += " " + side.stickers[6].colorNameAsSide + " " + side.stickers[7].colorNameAsSide + " " + side.stickers[8].colorNameAsSide + "\n";
            return stickersString;
        }
        public static Side getSide(Cube cube, string colorNameAsSide) {
            foreach (Side side in cube.sides) {
                if (side.stickers[4].colorNameAsSide.Equals(colorNameAsSide)) {
                    //return initializeSide(side);
                    return side;
                }
            }
            return new Side("WHITE", "U", colorWhite);
        }
        public static Side initializeSide(Side side) {
            List<Sticker> newStickers = new List<Sticker>();
            foreach (Sticker sticker in side.stickers) {
                Sticker newSticker = new Sticker(sticker.id, sticker.colorName, sticker.colorNameAsSide, sticker.color);
                newStickers.Add(newSticker);
            }
            return new Side(newStickers);
        }
        public static Cube turnCube(Cube cube, string turn) {
            Side currentUpSide = initializeSide(getSide(cube, "U"));
            Side currentDownSide = initializeSide(getSide(cube, "D"));
            Side currentLeftSide = initializeSide(getSide(cube, "L"));
            Side currentRightSide = initializeSide(getSide(cube, "R"));
            Side currentFrontSide = initializeSide(getSide(cube, "F"));
            Side currentBackSide = initializeSide(getSide(cube, "B"));

            Side newUpSide = currentUpSide;
            Side newDownSide = currentDownSide;
            Side newLeftSide = currentLeftSide;
            Side newRightSide = currentRightSide;
            Side newFrontSide = currentFrontSide;
            Side newBackSide = currentBackSide;
            if (turn.Equals("U")) {
                newUpSide.stickers[2].update(currentUpSide.stickers[0]);
                newUpSide.stickers[8].update(currentUpSide.stickers[2]);
                newUpSide.stickers[6].update(currentUpSide.stickers[8]);
                newUpSide.stickers[0].update(currentUpSide.stickers[6]);
                newUpSide.stickers[5].update(currentUpSide.stickers[1]);
                newUpSide.stickers[7].update(currentUpSide.stickers[5]);
                newUpSide.stickers[3].update(currentUpSide.stickers[7]);
                newUpSide.stickers[1].update(currentUpSide.stickers[3]);

                newRightSide.stickers[0].color = currentBackSide.stickers[0].color;
                newRightSide.stickers[2].color = currentBackSide.stickers[2].color;
                newRightSide.stickers[1].color = currentBackSide.stickers[1].color;

                newFrontSide.stickers[0].color = currentRightSide.stickers[0].color;
                newFrontSide.stickers[2].color = currentRightSide.stickers[2].color;
                newFrontSide.stickers[1].color = currentRightSide.stickers[1].color;

                newLeftSide.stickers[0].color = currentFrontSide.stickers[0].color;
                newLeftSide.stickers[2].color = currentFrontSide.stickers[2].color;
                newLeftSide.stickers[1].color = currentFrontSide.stickers[1].color;

                newBackSide.stickers[0].color = currentLeftSide.stickers[0].color;
                newBackSide.stickers[2].color = currentLeftSide.stickers[2].color;
                newBackSide.stickers[1].color = currentLeftSide.stickers[1].color;
            }
            if (turn.Equals("U'")) {
                newUpSide.stickers[0].color = currentUpSide.stickers[2].color;
                newUpSide.stickers[6].color = currentUpSide.stickers[0].color;
                newUpSide.stickers[8].color = currentUpSide.stickers[6].color;
                newUpSide.stickers[2].color = currentUpSide.stickers[8].color;
                newUpSide.stickers[3].color = currentUpSide.stickers[1].color;
                newUpSide.stickers[7].color = currentUpSide.stickers[3].color;
                newUpSide.stickers[5].color = currentUpSide.stickers[7].color;
                newUpSide.stickers[1].color = currentUpSide.stickers[5].color;

                newLeftSide.stickers[0].color = currentBackSide.stickers[0].color;
                newLeftSide.stickers[2].color = currentBackSide.stickers[2].color;
                newLeftSide.stickers[1].color = currentBackSide.stickers[1].color;

                newFrontSide.stickers[0].color = currentLeftSide.stickers[0].color;
                newFrontSide.stickers[2].color = currentLeftSide.stickers[2].color;
                newFrontSide.stickers[1].color = currentLeftSide.stickers[1].color;

                newRightSide.stickers[0].color = currentFrontSide.stickers[0].color;
                newRightSide.stickers[2].color = currentFrontSide.stickers[2].color;
                newRightSide.stickers[1].color = currentFrontSide.stickers[1].color;

                newBackSide.stickers[0].color = currentRightSide.stickers[0].color;
                newBackSide.stickers[2].color = currentRightSide.stickers[2].color;
                newBackSide.stickers[1].color = currentRightSide.stickers[1].color;
            }
            if (turn.Equals("U2")) {
                newUpSide.stickers[8].color = currentUpSide.stickers[0].color;
                newUpSide.stickers[0].color = currentUpSide.stickers[8].color;
                newUpSide.stickers[6].color = currentUpSide.stickers[2].color;
                newUpSide.stickers[2].color = currentUpSide.stickers[6].color;
                newUpSide.stickers[5].color = currentUpSide.stickers[3].color;
                newUpSide.stickers[3].color = currentUpSide.stickers[5].color;
                newUpSide.stickers[7].color = currentUpSide.stickers[1].color;
                newUpSide.stickers[1].color = currentUpSide.stickers[7].color;

                newRightSide.stickers[0].color = currentLeftSide.stickers[0].color;
                newRightSide.stickers[2].color = currentLeftSide.stickers[2].color;
                newRightSide.stickers[1].color = currentLeftSide.stickers[1].color;

                newLeftSide.stickers[0].color = currentRightSide.stickers[0].color;
                newLeftSide.stickers[2].color = currentRightSide.stickers[2].color;
                newLeftSide.stickers[1].color = currentRightSide.stickers[1].color;

                newBackSide.stickers[0].color = currentFrontSide.stickers[0].color;
                newBackSide.stickers[2].color = currentFrontSide.stickers[2].color;
                newBackSide.stickers[1].color = currentFrontSide.stickers[1].color;

                newFrontSide.stickers[0].color = currentBackSide.stickers[0].color;
                newFrontSide.stickers[2].color = currentBackSide.stickers[2].color;
                newFrontSide.stickers[1].color = currentBackSide.stickers[1].color;
            }
            if (turn.Equals("D")) {
                newDownSide.stickers[2].color = currentDownSide.stickers[0].color;
                newDownSide.stickers[8].color = currentDownSide.stickers[2].color;
                newDownSide.stickers[6].color = currentDownSide.stickers[8].color;
                newDownSide.stickers[0].color = currentDownSide.stickers[6].color;

                newDownSide.stickers[5].color = currentDownSide.stickers[1].color;
                newDownSide.stickers[7].color = currentDownSide.stickers[5].color;
                newDownSide.stickers[3].color = currentDownSide.stickers[7].color;
                newDownSide.stickers[1].color = currentDownSide.stickers[3].color;

                newRightSide.stickers[6].color = currentFrontSide.stickers[6].color;
                newRightSide.stickers[8].color = currentFrontSide.stickers[8].color;
                newRightSide.stickers[7].color = currentFrontSide.stickers[7].color;

                newBackSide.stickers[6].color = currentRightSide.stickers[6].color;
                newBackSide.stickers[8].color = currentRightSide.stickers[8].color;
                newBackSide.stickers[7].color = currentRightSide.stickers[7].color;

                newLeftSide.stickers[6].color = currentBackSide.stickers[6].color;
                newLeftSide.stickers[8].color = currentBackSide.stickers[8].color;
                newLeftSide.stickers[7].color = currentBackSide.stickers[7].color;

                newFrontSide.stickers[6].color = currentLeftSide.stickers[6].color;
                newFrontSide.stickers[8].color = currentLeftSide.stickers[8].color;
                newFrontSide.stickers[7].color = currentLeftSide.stickers[7].color;
            }
            if (turn.Equals("D'")) {
                newDownSide.stickers[0].color = currentDownSide.stickers[2].color;
                newDownSide.stickers[6].color = currentDownSide.stickers[0].color;
                newDownSide.stickers[8].color = currentDownSide.stickers[6].color;
                newDownSide.stickers[2].color = currentDownSide.stickers[8].color;

                newDownSide.stickers[3].color = currentDownSide.stickers[1].color;
                newDownSide.stickers[7].color = currentDownSide.stickers[3].color;
                newDownSide.stickers[5].color = currentDownSide.stickers[7].color;
                newDownSide.stickers[1].color = currentDownSide.stickers[5].color;

                newRightSide.stickers[6].color = currentBackSide.stickers[6].color;
                newRightSide.stickers[8].color = currentBackSide.stickers[8].color;
                newRightSide.stickers[7].color = currentBackSide.stickers[7].color;

                newFrontSide.stickers[6].color = currentRightSide.stickers[6].color;
                newFrontSide.stickers[8].color = currentRightSide.stickers[8].color;
                newFrontSide.stickers[7].color = currentRightSide.stickers[7].color;

                newLeftSide.stickers[6].color = currentFrontSide.stickers[6].color;
                newLeftSide.stickers[8].color = currentFrontSide.stickers[8].color;
                newLeftSide.stickers[7].color = currentFrontSide.stickers[7].color;

                newBackSide.stickers[6].color = currentLeftSide.stickers[6].color;
                newBackSide.stickers[8].color = currentLeftSide.stickers[8].color;
                newBackSide.stickers[7].color = currentLeftSide.stickers[7].color;
            }
            if (turn.Equals("D2")) {
                newDownSide.stickers[8].color = currentDownSide.stickers[0].color;
                newDownSide.stickers[0].color = currentDownSide.stickers[8].color;
                newDownSide.stickers[6].color = currentDownSide.stickers[2].color;
                newDownSide.stickers[2].color = currentDownSide.stickers[6].color;

                newDownSide.stickers[5].color = currentDownSide.stickers[3].color;
                newDownSide.stickers[3].color = currentDownSide.stickers[5].color;
                newDownSide.stickers[7].color = currentDownSide.stickers[1].color;
                newDownSide.stickers[1].color = currentDownSide.stickers[7].color;

                newRightSide.stickers[6].color = currentLeftSide.stickers[6].color;
                newRightSide.stickers[8].color = currentLeftSide.stickers[8].color;
                newRightSide.stickers[7].color = currentLeftSide.stickers[7].color;

                newLeftSide.stickers[6].color = currentRightSide.stickers[6].color;
                newLeftSide.stickers[8].color = currentRightSide.stickers[8].color;
                newLeftSide.stickers[7].color = currentRightSide.stickers[7].color;

                newBackSide.stickers[6].color = currentFrontSide.stickers[6].color;
                newBackSide.stickers[8].color = currentFrontSide.stickers[8].color;
                newBackSide.stickers[7].color = currentFrontSide.stickers[7].color;

                newFrontSide.stickers[6].color = currentBackSide.stickers[6].color;
                newFrontSide.stickers[8].color = currentBackSide.stickers[8].color;
                newFrontSide.stickers[7].color = currentBackSide.stickers[7].color;
            }
            if (turn.Equals("L")) {
                newLeftSide.stickers[2].color = currentLeftSide.stickers[0].color;
                newLeftSide.stickers[8].color = currentLeftSide.stickers[2].color;
                newLeftSide.stickers[6].color = currentLeftSide.stickers[8].color;
                newLeftSide.stickers[0].color = currentLeftSide.stickers[6].color;

                newLeftSide.stickers[5].color = currentLeftSide.stickers[1].color;
                newLeftSide.stickers[7].color = currentLeftSide.stickers[5].color;
                newLeftSide.stickers[3].color = currentLeftSide.stickers[7].color;
                newLeftSide.stickers[1].color = currentLeftSide.stickers[3].color;

                newFrontSide.stickers[6].color = currentUpSide.stickers[6].color;
                newFrontSide.stickers[0].color = currentUpSide.stickers[0].color;
                newFrontSide.stickers[3].color = currentUpSide.stickers[3].color;

                newDownSide.stickers[6].color = currentFrontSide.stickers[6].color;
                newDownSide.stickers[0].color = currentFrontSide.stickers[0].color;
                newDownSide.stickers[3].color = currentFrontSide.stickers[3].color;

                newBackSide.stickers[2].color = currentDownSide.stickers[6].color;
                newBackSide.stickers[8].color = currentDownSide.stickers[0].color;
                newBackSide.stickers[5].color = currentDownSide.stickers[3].color;

                newUpSide.stickers[6].color = currentBackSide.stickers[2].color;
                newUpSide.stickers[0].color = currentBackSide.stickers[8].color;
                newUpSide.stickers[3].color = currentBackSide.stickers[5].color;
            }
            if (turn.Equals("L'")) {
                newLeftSide.stickers[0].color = currentLeftSide.stickers[2].color;
                newLeftSide.stickers[6].color = currentLeftSide.stickers[0].color;
                newLeftSide.stickers[8].color = currentLeftSide.stickers[6].color;
                newLeftSide.stickers[2].color = currentLeftSide.stickers[8].color;

                newLeftSide.stickers[3].color = currentLeftSide.stickers[1].color;
                newLeftSide.stickers[7].color = currentLeftSide.stickers[3].color;
                newLeftSide.stickers[5].color = currentLeftSide.stickers[7].color;
                newLeftSide.stickers[1].color = currentLeftSide.stickers[5].color;

                newBackSide.stickers[2].color = currentUpSide.stickers[6].color;
                newBackSide.stickers[8].color = currentUpSide.stickers[0].color;
                newBackSide.stickers[5].color = currentUpSide.stickers[3].color;

                newDownSide.stickers[6].color = currentBackSide.stickers[2].color;
                newDownSide.stickers[0].color = currentBackSide.stickers[8].color;
                newDownSide.stickers[3].color = currentBackSide.stickers[5].color;

                newFrontSide.stickers[6].color = currentDownSide.stickers[6].color;
                newFrontSide.stickers[0].color = currentDownSide.stickers[0].color;
                newFrontSide.stickers[3].color = currentDownSide.stickers[3].color;

                newUpSide.stickers[6].color = currentFrontSide.stickers[6].color;
                newUpSide.stickers[0].color = currentFrontSide.stickers[0].color;
                newUpSide.stickers[3].color = currentFrontSide.stickers[3].color;
            }
            if (turn.Equals("L2")) {
                newLeftSide.stickers[8].color = currentLeftSide.stickers[0].color;
                newLeftSide.stickers[0].color = currentLeftSide.stickers[8].color;
                newLeftSide.stickers[6].color = currentLeftSide.stickers[2].color;
                newLeftSide.stickers[2].color = currentLeftSide.stickers[6].color;

                newLeftSide.stickers[5].color = currentLeftSide.stickers[3].color;
                newLeftSide.stickers[3].color = currentLeftSide.stickers[5].color;
                newLeftSide.stickers[7].color = currentLeftSide.stickers[1].color;
                newLeftSide.stickers[1].color = currentLeftSide.stickers[7].color;

                newDownSide.stickers[6].color = currentUpSide.stickers[6].color;
                newDownSide.stickers[0].color = currentUpSide.stickers[0].color;
                newDownSide.stickers[3].color = currentUpSide.stickers[3].color;

                newUpSide.stickers[6].color = currentDownSide.stickers[6].color;
                newUpSide.stickers[0].color = currentDownSide.stickers[0].color;
                newUpSide.stickers[3].color = currentDownSide.stickers[3].color;

                newBackSide.stickers[2].color = currentFrontSide.stickers[6].color;
                newBackSide.stickers[8].color = currentFrontSide.stickers[0].color;
                newBackSide.stickers[5].color = currentFrontSide.stickers[3].color;

                newFrontSide.stickers[6].color = currentBackSide.stickers[2].color;
                newFrontSide.stickers[0].color = currentBackSide.stickers[8].color;
                newFrontSide.stickers[3].color = currentBackSide.stickers[5].color;
            }
            if (turn.Equals("R")) {
                newRightSide.stickers[2].color = currentRightSide.stickers[0].color;
                newRightSide.stickers[8].color = currentRightSide.stickers[2].color;
                newRightSide.stickers[6].color = currentRightSide.stickers[8].color;
                newRightSide.stickers[0].color = currentRightSide.stickers[6].color;

                newRightSide.stickers[5].color = currentRightSide.stickers[1].color;
                newRightSide.stickers[7].color = currentRightSide.stickers[5].color;
                newRightSide.stickers[3].color = currentRightSide.stickers[7].color;
                newRightSide.stickers[1].color = currentRightSide.stickers[3].color;

                newBackSide.stickers[6].color = currentUpSide.stickers[2].color;
                newBackSide.stickers[0].color = currentUpSide.stickers[8].color;
                newBackSide.stickers[3].color = currentUpSide.stickers[5].color;

                newDownSide.stickers[2].color = currentBackSide.stickers[6].color;
                newDownSide.stickers[8].color = currentBackSide.stickers[0].color;
                newDownSide.stickers[5].color = currentBackSide.stickers[3].color;

                newFrontSide.stickers[2].color = currentDownSide.stickers[2].color;
                newFrontSide.stickers[8].color = currentDownSide.stickers[8].color;
                newFrontSide.stickers[5].color = currentDownSide.stickers[5].color;

                newUpSide.stickers[2].color = currentFrontSide.stickers[2].color;
                newUpSide.stickers[8].color = currentFrontSide.stickers[8].color;
                newUpSide.stickers[5].color = currentFrontSide.stickers[5].color;
            }
            if (turn.Equals("R'")) {
                newRightSide.stickers[0].color = currentRightSide.stickers[2].color;
                newRightSide.stickers[6].color = currentRightSide.stickers[0].color;
                newRightSide.stickers[8].color = currentRightSide.stickers[6].color;
                newRightSide.stickers[2].color = currentRightSide.stickers[8].color;

                newRightSide.stickers[3].color = currentRightSide.stickers[1].color;
                newRightSide.stickers[7].color = currentRightSide.stickers[3].color;
                newRightSide.stickers[5].color = currentRightSide.stickers[7].color;
                newRightSide.stickers[1].color = currentRightSide.stickers[5].color;

                newFrontSide.stickers[2].color = currentUpSide.stickers[2].color;
                newFrontSide.stickers[8].color = currentUpSide.stickers[8].color;
                newFrontSide.stickers[5].color = currentUpSide.stickers[5].color;

                newDownSide.stickers[2].color = currentFrontSide.stickers[2].color;
                newDownSide.stickers[8].color = currentFrontSide.stickers[8].color;
                newDownSide.stickers[5].color = currentFrontSide.stickers[5].color;

                newBackSide.stickers[6].color = currentDownSide.stickers[2].color;
                newBackSide.stickers[0].color = currentDownSide.stickers[8].color;
                newBackSide.stickers[3].color = currentDownSide.stickers[5].color;

                newUpSide.stickers[2].color = currentBackSide.stickers[6].color;
                newUpSide.stickers[8].color = currentBackSide.stickers[0].color;
                newUpSide.stickers[5].color = currentBackSide.stickers[3].color;
            }
            if (turn.Equals("R2")) {
                newRightSide.stickers[8].color = currentRightSide.stickers[0].color;
                newRightSide.stickers[0].color = currentRightSide.stickers[8].color;
                newRightSide.stickers[6].color = currentRightSide.stickers[2].color;
                newRightSide.stickers[2].color = currentRightSide.stickers[6].color;

                newRightSide.stickers[5].color = currentRightSide.stickers[3].color;
                newRightSide.stickers[3].color = currentRightSide.stickers[5].color;
                newRightSide.stickers[7].color = currentRightSide.stickers[1].color;
                newRightSide.stickers[1].color = currentRightSide.stickers[7].color;

                newDownSide.stickers[2].color = currentUpSide.stickers[2].color;
                newDownSide.stickers[8].color = currentUpSide.stickers[8].color;
                newDownSide.stickers[5].color = currentUpSide.stickers[5].color;

                newUpSide.stickers[2].color = currentDownSide.stickers[2].color;
                newUpSide.stickers[8].color = currentDownSide.stickers[8].color;
                newUpSide.stickers[5].color = currentDownSide.stickers[5].color;

                newBackSide.stickers[6].color = currentFrontSide.stickers[2].color;
                newBackSide.stickers[0].color = currentFrontSide.stickers[8].color;
                newBackSide.stickers[3].color = currentFrontSide.stickers[5].color;

                newFrontSide.stickers[2].color = currentBackSide.stickers[6].color;
                newFrontSide.stickers[8].color = currentBackSide.stickers[0].color;
                newFrontSide.stickers[5].color = currentBackSide.stickers[3].color;
            }
            if (turn.Equals("F")) {
                newFrontSide.stickers[2].color = currentFrontSide.stickers[0].color;
                newFrontSide.stickers[8].color = currentFrontSide.stickers[2].color;
                newFrontSide.stickers[6].color = currentFrontSide.stickers[8].color;
                newFrontSide.stickers[0].color = currentFrontSide.stickers[6].color;

                newFrontSide.stickers[5].color = currentFrontSide.stickers[1].color;
                newFrontSide.stickers[7].color = currentFrontSide.stickers[5].color;
                newFrontSide.stickers[3].color = currentFrontSide.stickers[7].color;
                newFrontSide.stickers[1].color = currentFrontSide.stickers[3].color;

                newRightSide.stickers[6].color = currentUpSide.stickers[8].color;
                newRightSide.stickers[0].color = currentUpSide.stickers[6].color;
                newRightSide.stickers[3].color = currentUpSide.stickers[7].color;

                newDownSide.stickers[0].color = currentRightSide.stickers[6].color;
                newDownSide.stickers[2].color = currentRightSide.stickers[0].color;
                newDownSide.stickers[1].color = currentRightSide.stickers[3].color;

                newLeftSide.stickers[2].color = currentDownSide.stickers[0].color;
                newLeftSide.stickers[8].color = currentDownSide.stickers[2].color;
                newLeftSide.stickers[5].color = currentDownSide.stickers[1].color;

                newUpSide.stickers[8].color = currentLeftSide.stickers[2].color;
                newUpSide.stickers[6].color = currentLeftSide.stickers[8].color;
                newUpSide.stickers[7].color = currentLeftSide.stickers[5].color;
            }
            if (turn.Equals("F'")) {
                newFrontSide.stickers[0].color = currentFrontSide.stickers[2].color;
                newFrontSide.stickers[6].color = currentFrontSide.stickers[0].color;
                newFrontSide.stickers[8].color = currentFrontSide.stickers[6].color;
                newFrontSide.stickers[2].color = currentFrontSide.stickers[8].color;

                newFrontSide.stickers[3].color = currentFrontSide.stickers[1].color;
                newFrontSide.stickers[7].color = currentFrontSide.stickers[3].color;
                newFrontSide.stickers[5].color = currentFrontSide.stickers[7].color;
                newFrontSide.stickers[1].color = currentFrontSide.stickers[5].color;

                newLeftSide.stickers[2].color = currentUpSide.stickers[8].color;
                newLeftSide.stickers[8].color = currentUpSide.stickers[6].color;
                newLeftSide.stickers[5].color = currentUpSide.stickers[7].color;

                newDownSide.stickers[0].color = currentLeftSide.stickers[2].color;
                newDownSide.stickers[2].color = currentLeftSide.stickers[8].color;
                newDownSide.stickers[1].color = currentLeftSide.stickers[5].color;

                newRightSide.stickers[6].color = currentDownSide.stickers[0].color;
                newRightSide.stickers[0].color = currentDownSide.stickers[2].color;
                newRightSide.stickers[3].color = currentDownSide.stickers[1].color;

                newUpSide.stickers[6].color = currentRightSide.stickers[0].color;
                newUpSide.stickers[8].color = currentRightSide.stickers[6].color;
                newUpSide.stickers[7].color = currentRightSide.stickers[3].color;
            }
            if (turn.Equals("F2")) {
                newFrontSide.stickers[8].color = currentFrontSide.stickers[0].color;
                newFrontSide.stickers[0].color = currentFrontSide.stickers[8].color;
                newFrontSide.stickers[6].color = currentFrontSide.stickers[2].color;
                newFrontSide.stickers[2].color = currentFrontSide.stickers[6].color;

                newFrontSide.stickers[5].color = currentFrontSide.stickers[3].color;
                newFrontSide.stickers[3].color = currentFrontSide.stickers[5].color;
                newFrontSide.stickers[7].color = currentFrontSide.stickers[1].color;
                newFrontSide.stickers[1].color = currentFrontSide.stickers[7].color;

                newDownSide.stickers[0].color = currentUpSide.stickers[8].color;
                newDownSide.stickers[2].color = currentUpSide.stickers[6].color;
                newDownSide.stickers[1].color = currentUpSide.stickers[7].color;

                newUpSide.stickers[8].color = currentDownSide.stickers[0].color;
                newUpSide.stickers[6].color = currentDownSide.stickers[2].color;
                newUpSide.stickers[7].color = currentDownSide.stickers[1].color;

                newRightSide.stickers[0].color = currentLeftSide.stickers[8].color;
                newRightSide.stickers[6].color = currentLeftSide.stickers[2].color;
                newRightSide.stickers[3].color = currentLeftSide.stickers[5].color;

                newLeftSide.stickers[8].color = currentRightSide.stickers[0].color;
                newLeftSide.stickers[2].color = currentRightSide.stickers[6].color;
                newLeftSide.stickers[5].color = currentRightSide.stickers[3].color;
            }
            if (turn.Equals("B")) {
                newBackSide.stickers[2].color = currentBackSide.stickers[0].color;
                newBackSide.stickers[8].color = currentBackSide.stickers[2].color;
                newBackSide.stickers[6].color = currentBackSide.stickers[8].color;
                newBackSide.stickers[0].color = currentBackSide.stickers[6].color;

                newBackSide.stickers[5].color = currentBackSide.stickers[1].color;
                newBackSide.stickers[7].color = currentBackSide.stickers[5].color;
                newBackSide.stickers[3].color = currentBackSide.stickers[7].color;
                newBackSide.stickers[1].color = currentBackSide.stickers[3].color;

                newLeftSide.stickers[6].color = currentUpSide.stickers[0].color;
                newLeftSide.stickers[0].color = currentUpSide.stickers[2].color;
                newLeftSide.stickers[3].color = currentUpSide.stickers[1].color;

                newDownSide.stickers[8].color = currentLeftSide.stickers[6].color;
                newDownSide.stickers[6].color = currentLeftSide.stickers[0].color;
                newDownSide.stickers[7].color = currentLeftSide.stickers[3].color;

                newRightSide.stickers[2].color = currentDownSide.stickers[8].color;
                newRightSide.stickers[8].color = currentDownSide.stickers[6].color;
                newRightSide.stickers[5].color = currentDownSide.stickers[7].color;

                newUpSide.stickers[0].color = currentRightSide.stickers[2].color;
                newUpSide.stickers[2].color = currentRightSide.stickers[8].color;
                newUpSide.stickers[1].color = currentRightSide.stickers[5].color;
            }
            if (turn.Equals("B'")) {
                newBackSide.stickers[0].color = currentBackSide.stickers[2].color;
                newBackSide.stickers[6].color = currentBackSide.stickers[0].color;
                newBackSide.stickers[8].color = currentBackSide.stickers[6].color;
                newBackSide.stickers[2].color = currentBackSide.stickers[8].color;

                newBackSide.stickers[3].color = currentBackSide.stickers[1].color;
                newBackSide.stickers[7].color = currentBackSide.stickers[3].color;
                newBackSide.stickers[5].color = currentBackSide.stickers[7].color;
                newBackSide.stickers[1].color = currentBackSide.stickers[5].color;

                newRightSide.stickers[2].color = currentUpSide.stickers[0].color;
                newRightSide.stickers[8].color = currentUpSide.stickers[2].color;
                newRightSide.stickers[5].color = currentUpSide.stickers[1].color;

                newDownSide.stickers[8].color = currentRightSide.stickers[2].color;
                newDownSide.stickers[6].color = currentRightSide.stickers[8].color;
                newDownSide.stickers[7].color = currentRightSide.stickers[5].color;

                newLeftSide.stickers[6].color = currentDownSide.stickers[8].color;
                newLeftSide.stickers[0].color = currentDownSide.stickers[6].color;
                newLeftSide.stickers[3].color = currentDownSide.stickers[7].color;

                newUpSide.stickers[0].color = currentLeftSide.stickers[6].color;
                newUpSide.stickers[2].color = currentLeftSide.stickers[0].color;
                newUpSide.stickers[1].color = currentLeftSide.stickers[3].color;
            }
            if (turn.Equals("B2")) {
                newBackSide.stickers[8].color = currentBackSide.stickers[0].color;
                newBackSide.stickers[0].color = currentBackSide.stickers[8].color;
                newBackSide.stickers[6].color = currentBackSide.stickers[2].color;
                newBackSide.stickers[2].color = currentBackSide.stickers[6].color;

                newBackSide.stickers[5].color = currentBackSide.stickers[3].color;
                newBackSide.stickers[3].color = currentBackSide.stickers[5].color;
                newBackSide.stickers[7].color = currentBackSide.stickers[1].color;
                newBackSide.stickers[1].color = currentBackSide.stickers[7].color;

                newDownSide.stickers[8].color = currentUpSide.stickers[0].color;
                newDownSide.stickers[6].color = currentUpSide.stickers[2].color;
                newDownSide.stickers[7].color = currentUpSide.stickers[1].color;

                newUpSide.stickers[0].color = currentDownSide.stickers[8].color;
                newUpSide.stickers[2].color = currentDownSide.stickers[6].color;
                newUpSide.stickers[1].color = currentDownSide.stickers[7].color;

                newRightSide.stickers[2].color = currentLeftSide.stickers[6].color;
                newRightSide.stickers[8].color = currentLeftSide.stickers[0].color;
                newRightSide.stickers[5].color = currentLeftSide.stickers[3].color;

                newLeftSide.stickers[6].color = currentRightSide.stickers[2].color;
                newLeftSide.stickers[0].color = currentRightSide.stickers[8].color;
                newLeftSide.stickers[3].color = currentRightSide.stickers[5].color;
            }
            List<Side> newSides = new List<Side> { newUpSide, newDownSide, newLeftSide, newRightSide, newFrontSide, newBackSide };
            return new Cube(newSides);
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
                cube = turnCube(cube, turn);
            }
            return cube;
        }
        public static string longMillisecondsToString(long elapsedMilliseconds) {
            string millisecondsString = "";
            string secondsString = "";
            string minutesString = "";
            int milliseconds = (int)elapsedMilliseconds % 1000 / 10;
            int seconds = (int)(elapsedMilliseconds / 1000) % 60;
            int minutes = (int)(elapsedMilliseconds / (1000 * 60) % 60);
            if (milliseconds < 10) {
                millisecondsString = "0" + milliseconds;
            }
            else {
                millisecondsString = milliseconds.ToString();
            }
            if (seconds < 10) {
                secondsString = "0" + seconds;
            }
            else {
                secondsString = seconds.ToString();
            }
            if (minutes < 10) {
                minutesString = "0" + minutes;
            }
            else {
                minutesString = minutes.ToString();
            }
            return minutesString + " : " + secondsString + " . " + millisecondsString;
        }
        public static List<string> generateScramble() {
            List<string> scrambleList = new List<string>();
            string secondPrevTurn = turns[new Random().Next(turns.Length)];
            string prevTurn = generateOtherTurn(secondPrevTurn);
            string turnOne = "";
            string turnTwo = "";
            string turnThree = "";
            int numberOfTurns = new Random().Next(18, 22);
            int numberOfDoubleTurns = 0;
            MAX_DOUBLE_TURNS = numberOfTurns / 2;
            for (int i = 0; i < numberOfTurns; i += 3) {
                turnOne = generateOtherThirdTurn(prevTurn, secondPrevTurn);
                turnTwo = generateOtherTurn(turnOne);
                turnThree = generateOtherThirdTurn(turnOne, turnTwo);
                if (numberOfTurns % 3 != 0) {
                    if (numberOfTurns - i == 2) {
                        numberOfDoubleTurns = addValidatedTurn(turnOne, scrambleList, numberOfDoubleTurns);
                        numberOfDoubleTurns = addValidatedTurn(turnTwo, scrambleList, numberOfDoubleTurns);
                        return scrambleList;
                    }
                    else if (numberOfTurns - i == 1) {
                        numberOfDoubleTurns = addValidatedTurn(turnOne, scrambleList, numberOfDoubleTurns);
                        return scrambleList;
                    }
                }
                numberOfDoubleTurns = addValidatedTurn(turnOne, scrambleList, numberOfDoubleTurns);
                numberOfDoubleTurns = addValidatedTurn(turnTwo, scrambleList, numberOfDoubleTurns);
                numberOfDoubleTurns = addValidatedTurn(turnThree, scrambleList, numberOfDoubleTurns);
                secondPrevTurn = turnTwo;
                prevTurn = turnThree;
            }
            return scrambleList;
        }
        public static string generateOtherTurn(string turn) {
            int turnOneIndex = Array.IndexOf(turns, turn);
            List<int> otherTurns = new List<int>();
            for (int i = 0; i < 6; i++) {
                if (i == turnOneIndex) {
                    continue;
                }
                else {
                    otherTurns.Add(i);
                }
            }
            return turns[otherTurns[new Random().Next(otherTurns.Count)]];
        }
        public static string generateOtherThirdTurn(string turnOne, string turnTwo) {
            int turnOneIndex = Array.IndexOf(turns, turnOne);
            int turnTwoIndex = Array.IndexOf(turns, turnTwo);
            List<int> otherTurns = new List<int>();
            for (int i = 0; i < 6; i++) {
                if (i == turnOneIndex || i == turnTwoIndex) {
                    continue;
                }
                else {
                    otherTurns.Add(i);
                }
            }
            return turns[otherTurns[new Random().Next(otherTurns.Count)]];
        }
        public static int addValidatedTurn(string currentTurn, List<string> validatedScramble, int numOfDoubleTurns) {
            bool isDoubleTurn = new Random().Next(0, 100) <= 50;
            bool isPrimeTurn = new Random().Next(0, 100) <= 50;
            if (isDoubleTurn && numOfDoubleTurns < MAX_DOUBLE_TURNS) {
                validatedScramble.Add(currentTurn + "2");
                numOfDoubleTurns++;
            }
            else if (isPrimeTurn) {
                validatedScramble.Add(currentTurn + "'");
            }
            else {
                validatedScramble.Add(currentTurn);
            }
            return numOfDoubleTurns;
        }
        public static string colorNameToSideName(string colorName) {
            switch(colorName) {
                case "W":
                    return "U";
                case "Y":
                    return "D";
                case "O":
                    return "L";
                case "R":
                    return "R";
                case "B":
                    return "F";
                case "G":
                    return "B";
            }
            return "";
        }
    }
}