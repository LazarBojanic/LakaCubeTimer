using LakaCubeTimer.model;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.Numerics;
using System.Reflection;

namespace LakaCubeTimer.util {
    public static class Util {
        private static Random random = new Random();
        private static string[] turns = new string[] { "U", "D", "L", "R", "F", "B" };
        public static Color COLOR_WHITE = Color.FromArgb(255, 255, 255);
        public static Color COLOR_YELLOW = Color.FromArgb(255, 249, 46);
        public static Color COLOR_ORANGE = Color.FromArgb(255, 119, 0);
        public static Color COLOR_RED = Color.FromArgb(227, 7, 7);
        public static Color COLOR_GREEN = Color.FromArgb(52, 196, 8);
        public static Color COLOR_BLUE = Color.FromArgb(2, 91, 181);
        public static string SIDE_UP = "U";
        public static string SIDE_DOWN = "D";
        public static string SIDE_LEFT = "L";
        public static string SIDE_RIGHT = "R";
        public static string SIDE_FRONT = "F";
        public static string SIDE_BACK = "B";
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
        public static string turnSequenceListToString(List<string> scramble) {
            string scrambleString = "";
            foreach (string turn in scramble) {
                scrambleString += turn + " ";
            }
            return scrambleString.Trim();
        }
        public static List<string> turnSequenceToList(string scramble) {
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
                    return initializeSide(side);
                    //return side;
                }
            }
            return new Side("WHITE", "U", COLOR_WHITE);
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
            Side currentUpSide = getSide(cube, "U");
            Side currentDownSide = getSide(cube, "D");
            Side currentLeftSide = getSide(cube, "L");
            Side currentRightSide = getSide(cube, "R");
            Side currentFrontSide = getSide(cube, "F");
            Side currentBackSide = getSide(cube, "B");

            /*
            THIS DOESNT WORK FOR SOME REASON, I HAVE TO EXPLICITLY INITIALIZE THE SIDE BY COPYING VALUES
            Side newUpSide = currentUpSide;
            Side newDownSide = currentDownSide;
            Side newLeftSide = currentLeftSide;
            Side newRightSide = currentRightSide;
            Side newFrontSide = currentFrontSide;
            Side newBackSide = currentBackSide;
            */

            Side newUpSide = initializeSide(currentUpSide);
            Side newDownSide = initializeSide(currentDownSide);
            Side newLeftSide = initializeSide(currentLeftSide);
            Side newRightSide = initializeSide(currentRightSide);
            Side newFrontSide = initializeSide(currentFrontSide);
            Side newBackSide = initializeSide(currentBackSide);

            if (turn.Equals("U")) {
                newUpSide.stickers[2].update(currentUpSide.stickers[0]);
                newUpSide.stickers[8].update(currentUpSide.stickers[2]);
                newUpSide.stickers[6].update(currentUpSide.stickers[8]);
                newUpSide.stickers[0].update(currentUpSide.stickers[6]);
                newUpSide.stickers[5].update(currentUpSide.stickers[1]);
                newUpSide.stickers[7].update(currentUpSide.stickers[5]);
                newUpSide.stickers[3].update(currentUpSide.stickers[7]);
                newUpSide.stickers[1].update(currentUpSide.stickers[3]);

                newRightSide.stickers[0].update(currentBackSide.stickers[0]);
                newRightSide.stickers[2].update(currentBackSide.stickers[2]);
                newRightSide.stickers[1].update(currentBackSide.stickers[1]);

                newFrontSide.stickers[0].update(currentRightSide.stickers[0]);
                newFrontSide.stickers[2].update(currentRightSide.stickers[2]);
                newFrontSide.stickers[1].update(currentRightSide.stickers[1]);

                newLeftSide.stickers[0].update(currentFrontSide.stickers[0]);
                newLeftSide.stickers[2].update(currentFrontSide.stickers[2]);
                newLeftSide.stickers[1].update(currentFrontSide.stickers[1]);

                newBackSide.stickers[0].update(currentLeftSide.stickers[0]);
                newBackSide.stickers[2].update(currentLeftSide.stickers[2]);
                newBackSide.stickers[1].update(currentLeftSide.stickers[1]);
            }
            if (turn.Equals("U'")) {
                newUpSide.stickers[0].update(currentUpSide.stickers[2]);
                newUpSide.stickers[6].update(currentUpSide.stickers[0]);
                newUpSide.stickers[8].update(currentUpSide.stickers[6]);
                newUpSide.stickers[2].update(currentUpSide.stickers[8]);
                newUpSide.stickers[3].update(currentUpSide.stickers[1]);
                newUpSide.stickers[7].update(currentUpSide.stickers[3]);
                newUpSide.stickers[5].update(currentUpSide.stickers[7]);
                newUpSide.stickers[1].update(currentUpSide.stickers[5]);

                newLeftSide.stickers[0].update(currentBackSide.stickers[0]);
                newLeftSide.stickers[2].update(currentBackSide.stickers[2]);
                newLeftSide.stickers[1].update(currentBackSide.stickers[1]);

                newFrontSide.stickers[0].update(currentLeftSide.stickers[0]);
                newFrontSide.stickers[2].update(currentLeftSide.stickers[2]);
                newFrontSide.stickers[1].update(currentLeftSide.stickers[1]);

                newRightSide.stickers[0].update(currentFrontSide.stickers[0]);
                newRightSide.stickers[2].update(currentFrontSide.stickers[2]);
                newRightSide.stickers[1].update(currentFrontSide.stickers[1]);

                newBackSide.stickers[0].update(currentRightSide.stickers[0]);
                newBackSide.stickers[2].update(currentRightSide.stickers[2]);
                newBackSide.stickers[1].update(currentRightSide.stickers[1]);
            }
            if (turn.Equals("U2")) {
                newUpSide.stickers[8].update(currentUpSide.stickers[0]);
                newUpSide.stickers[0].update(currentUpSide.stickers[8]);
                newUpSide.stickers[6].update(currentUpSide.stickers[2]);
                newUpSide.stickers[2].update(currentUpSide.stickers[6]);
                newUpSide.stickers[5].update(currentUpSide.stickers[3]);
                newUpSide.stickers[3].update(currentUpSide.stickers[5]);
                newUpSide.stickers[7].update(currentUpSide.stickers[1]);
                newUpSide.stickers[1].update(currentUpSide.stickers[7]);

                newRightSide.stickers[0].update(currentLeftSide.stickers[0]);
                newRightSide.stickers[2].update(currentLeftSide.stickers[2]);
                newRightSide.stickers[1].update(currentLeftSide.stickers[1]);

                newLeftSide.stickers[0].update(currentRightSide.stickers[0]);
                newLeftSide.stickers[2].update(currentRightSide.stickers[2]);
                newLeftSide.stickers[1].update(currentRightSide.stickers[1]);

                newBackSide.stickers[0].update(currentFrontSide.stickers[0]);
                newBackSide.stickers[2].update(currentFrontSide.stickers[2]);
                newBackSide.stickers[1].update(currentFrontSide.stickers[1]);

                newFrontSide.stickers[0].update(currentBackSide.stickers[0]);
                newFrontSide.stickers[2].update(currentBackSide.stickers[2]);
                newFrontSide.stickers[1].update(currentBackSide.stickers[1]);
            }
            if (turn.Equals("D")) {
                newDownSide.stickers[2].update(currentDownSide.stickers[0]);
                newDownSide.stickers[8].update(currentDownSide.stickers[2]);
                newDownSide.stickers[6].update(currentDownSide.stickers[8]);
                newDownSide.stickers[0].update(currentDownSide.stickers[6]);
                newDownSide.stickers[5].update(currentDownSide.stickers[1]);
                newDownSide.stickers[7].update(currentDownSide.stickers[5]);
                newDownSide.stickers[3].update(currentDownSide.stickers[7]);
                newDownSide.stickers[1].update(currentDownSide.stickers[3]);

                newRightSide.stickers[6].update(currentFrontSide.stickers[6]);
                newRightSide.stickers[8].update(currentFrontSide.stickers[8]);
                newRightSide.stickers[7].update(currentFrontSide.stickers[7]);

                newBackSide.stickers[6].update(currentRightSide.stickers[6]);
                newBackSide.stickers[8].update(currentRightSide.stickers[8]);
                newBackSide.stickers[7].update(currentRightSide.stickers[7]);

                newLeftSide.stickers[6].update(currentBackSide.stickers[6]);
                newLeftSide.stickers[8].update(currentBackSide.stickers[8]);
                newLeftSide.stickers[7].update(currentBackSide.stickers[7]);

                newFrontSide.stickers[6].update(currentLeftSide.stickers[6]);
                newFrontSide.stickers[8].update(currentLeftSide.stickers[8]);
                newFrontSide.stickers[7].update(currentLeftSide.stickers[7]);
            }
            if (turn.Equals("D'")) {
                newDownSide.stickers[0].update(currentDownSide.stickers[2]);
                newDownSide.stickers[6].update(currentDownSide.stickers[0]);
                newDownSide.stickers[8].update(currentDownSide.stickers[6]);
                newDownSide.stickers[2].update(currentDownSide.stickers[8]);
                newDownSide.stickers[3].update(currentDownSide.stickers[1]);
                newDownSide.stickers[7].update(currentDownSide.stickers[3]);
                newDownSide.stickers[5].update(currentDownSide.stickers[7]);
                newDownSide.stickers[1].update(currentDownSide.stickers[5]);

                newRightSide.stickers[6].update(currentBackSide.stickers[6]);
                newRightSide.stickers[8].update(currentBackSide.stickers[8]);
                newRightSide.stickers[7].update(currentBackSide.stickers[7]);

                newFrontSide.stickers[6].update(currentRightSide.stickers[6]);
                newFrontSide.stickers[8].update(currentRightSide.stickers[8]);
                newFrontSide.stickers[7].update(currentRightSide.stickers[7]);

                newLeftSide.stickers[6].update(currentFrontSide.stickers[6]);
                newLeftSide.stickers[8].update(currentFrontSide.stickers[8]);
                newLeftSide.stickers[7].update(currentFrontSide.stickers[7]);

                newBackSide.stickers[6].update(currentLeftSide.stickers[6]);
                newBackSide.stickers[8].update(currentLeftSide.stickers[8]);
                newBackSide.stickers[7].update(currentLeftSide.stickers[7]);
            }
            if (turn.Equals("D2")) {
                newDownSide.stickers[8].update(currentDownSide.stickers[0]);
                newDownSide.stickers[0].update(currentDownSide.stickers[8]);
                newDownSide.stickers[6].update(currentDownSide.stickers[2]);
                newDownSide.stickers[2].update(currentDownSide.stickers[6]);
                newDownSide.stickers[5].update(currentDownSide.stickers[3]);
                newDownSide.stickers[3].update(currentDownSide.stickers[5]);
                newDownSide.stickers[7].update(currentDownSide.stickers[1]);
                newDownSide.stickers[1].update(currentDownSide.stickers[7]);

                newRightSide.stickers[6].update(currentLeftSide.stickers[6]);
                newRightSide.stickers[8].update(currentLeftSide.stickers[8]);
                newRightSide.stickers[7].update(currentLeftSide.stickers[7]);

                newLeftSide.stickers[6].update(currentRightSide.stickers[6]);
                newLeftSide.stickers[8].update(currentRightSide.stickers[8]);
                newLeftSide.stickers[7].update(currentRightSide.stickers[7]);

                newBackSide.stickers[6].update(currentFrontSide.stickers[6]);
                newBackSide.stickers[8].update(currentFrontSide.stickers[8]);
                newBackSide.stickers[7].update(currentFrontSide.stickers[7]);

                newFrontSide.stickers[6].update(currentBackSide.stickers[6]);
                newFrontSide.stickers[8].update(currentBackSide.stickers[8]);
                newFrontSide.stickers[7].update(currentBackSide.stickers[7]);
            }
            if (turn.Equals("L")) {
                newLeftSide.stickers[2].update(currentLeftSide.stickers[0]);
                newLeftSide.stickers[8].update(currentLeftSide.stickers[2]);
                newLeftSide.stickers[6].update(currentLeftSide.stickers[8]);
                newLeftSide.stickers[0].update(currentLeftSide.stickers[6]);
                newLeftSide.stickers[5].update(currentLeftSide.stickers[1]);
                newLeftSide.stickers[7].update(currentLeftSide.stickers[5]);
                newLeftSide.stickers[3].update(currentLeftSide.stickers[7]);
                newLeftSide.stickers[1].update(currentLeftSide.stickers[3]);

                newFrontSide.stickers[6].update(currentUpSide.stickers[6]);
                newFrontSide.stickers[0].update(currentUpSide.stickers[0]);
                newFrontSide.stickers[3].update(currentUpSide.stickers[3]);

                newDownSide.stickers[6].update(currentFrontSide.stickers[6]);
                newDownSide.stickers[0].update(currentFrontSide.stickers[0]);
                newDownSide.stickers[3].update(currentFrontSide.stickers[3]);

                newBackSide.stickers[2].update(currentDownSide.stickers[6]);
                newBackSide.stickers[8].update(currentDownSide.stickers[0]);
                newBackSide.stickers[5].update(currentDownSide.stickers[3]);

                newUpSide.stickers[6].update(currentBackSide.stickers[2]);
                newUpSide.stickers[0].update(currentBackSide.stickers[8]);
                newUpSide.stickers[3].update(currentBackSide.stickers[5]);
            }
            if (turn.Equals("L'")) {
                newLeftSide.stickers[0].update(currentLeftSide.stickers[2]);
                newLeftSide.stickers[6].update(currentLeftSide.stickers[0]);
                newLeftSide.stickers[8].update(currentLeftSide.stickers[6]);
                newLeftSide.stickers[2].update(currentLeftSide.stickers[8]);
                newLeftSide.stickers[3].update(currentLeftSide.stickers[1]);
                newLeftSide.stickers[7].update(currentLeftSide.stickers[3]);
                newLeftSide.stickers[5].update(currentLeftSide.stickers[7]);
                newLeftSide.stickers[1].update(currentLeftSide.stickers[5]);

                newBackSide.stickers[2].update(currentUpSide.stickers[6]);
                newBackSide.stickers[8].update(currentUpSide.stickers[0]);
                newBackSide.stickers[5].update(currentUpSide.stickers[3]);

                newDownSide.stickers[6].update(currentBackSide.stickers[2]);
                newDownSide.stickers[0].update(currentBackSide.stickers[8]);
                newDownSide.stickers[3].update(currentBackSide.stickers[5]);

                newFrontSide.stickers[6].update(currentDownSide.stickers[6]);
                newFrontSide.stickers[0].update(currentDownSide.stickers[0]);
                newFrontSide.stickers[3].update(currentDownSide.stickers[3]);

                newUpSide.stickers[6].update(currentFrontSide.stickers[6]);
                newUpSide.stickers[0].update(currentFrontSide.stickers[0]);
                newUpSide.stickers[3].update(currentFrontSide.stickers[3]);
            }
            if (turn.Equals("L2")) {
                newLeftSide.stickers[8].update(currentLeftSide.stickers[0]);
                newLeftSide.stickers[0].update(currentLeftSide.stickers[8]);
                newLeftSide.stickers[6].update(currentLeftSide.stickers[2]);
                newLeftSide.stickers[2].update(currentLeftSide.stickers[6]);
                newLeftSide.stickers[5].update(currentLeftSide.stickers[3]);
                newLeftSide.stickers[3].update(currentLeftSide.stickers[5]);
                newLeftSide.stickers[7].update(currentLeftSide.stickers[1]);
                newLeftSide.stickers[1].update(currentLeftSide.stickers[7]);

                newDownSide.stickers[6].update(currentUpSide.stickers[6]);
                newDownSide.stickers[0].update(currentUpSide.stickers[0]);
                newDownSide.stickers[3].update(currentUpSide.stickers[3]);

                newUpSide.stickers[6].update(currentDownSide.stickers[6]);
                newUpSide.stickers[0].update(currentDownSide.stickers[0]);
                newUpSide.stickers[3].update(currentDownSide.stickers[3]);

                newBackSide.stickers[2].update(currentFrontSide.stickers[6]);
                newBackSide.stickers[8].update(currentFrontSide.stickers[0]);
                newBackSide.stickers[5].update(currentFrontSide.stickers[3]);

                newFrontSide.stickers[6].update(currentBackSide.stickers[2]);
                newFrontSide.stickers[0].update(currentBackSide.stickers[8]);
                newFrontSide.stickers[3].update(currentBackSide.stickers[5]);
            }
            if (turn.Equals("R")) {
                newRightSide.stickers[2].update(currentRightSide.stickers[0]);
                newRightSide.stickers[8].update(currentRightSide.stickers[2]);
                newRightSide.stickers[6].update(currentRightSide.stickers[8]);
                newRightSide.stickers[0].update(currentRightSide.stickers[6]);
                newRightSide.stickers[5].update(currentRightSide.stickers[1]);
                newRightSide.stickers[7].update(currentRightSide.stickers[5]);
                newRightSide.stickers[3].update(currentRightSide.stickers[7]);
                newRightSide.stickers[1].update(currentRightSide.stickers[3]);

                newBackSide.stickers[6].update(currentUpSide.stickers[2]);
                newBackSide.stickers[0].update(currentUpSide.stickers[8]);
                newBackSide.stickers[3].update(currentUpSide.stickers[5]);

                newDownSide.stickers[2].update(currentBackSide.stickers[6]);
                newDownSide.stickers[8].update(currentBackSide.stickers[0]);
                newDownSide.stickers[5].update(currentBackSide.stickers[3]);

                newFrontSide.stickers[2].update(currentDownSide.stickers[2]);
                newFrontSide.stickers[8].update(currentDownSide.stickers[8]);
                newFrontSide.stickers[5].update(currentDownSide.stickers[5]);

                newUpSide.stickers[2].update(currentFrontSide.stickers[2]);
                newUpSide.stickers[8].update(currentFrontSide.stickers[8]);
                newUpSide.stickers[5].update(currentFrontSide.stickers[5]);
            }
            if (turn.Equals("R'")) {
                newRightSide.stickers[0].update(currentRightSide.stickers[2]);
                newRightSide.stickers[6].update(currentRightSide.stickers[0]);
                newRightSide.stickers[8].update(currentRightSide.stickers[6]);
                newRightSide.stickers[2].update(currentRightSide.stickers[8]);
                newRightSide.stickers[3].update(currentRightSide.stickers[1]);
                newRightSide.stickers[7].update(currentRightSide.stickers[3]);
                newRightSide.stickers[5].update(currentRightSide.stickers[7]);
                newRightSide.stickers[1].update(currentRightSide.stickers[5]);

                newFrontSide.stickers[2].update(currentUpSide.stickers[2]);
                newFrontSide.stickers[8].update(currentUpSide.stickers[8]);
                newFrontSide.stickers[5].update(currentUpSide.stickers[5]);

                newDownSide.stickers[2].update(currentFrontSide.stickers[2]);
                newDownSide.stickers[8].update(currentFrontSide.stickers[8]);
                newDownSide.stickers[5].update(currentFrontSide.stickers[5]);

                newBackSide.stickers[6].update(currentDownSide.stickers[2]);
                newBackSide.stickers[0].update(currentDownSide.stickers[8]);
                newBackSide.stickers[3].update(currentDownSide.stickers[5]);

                newUpSide.stickers[2].update(currentBackSide.stickers[6]);
                newUpSide.stickers[8].update(currentBackSide.stickers[0]);
                newUpSide.stickers[5].update(currentBackSide.stickers[3]);
            }
            if (turn.Equals("R2")) {
                newRightSide.stickers[8].update(currentRightSide.stickers[0]);
                newRightSide.stickers[0].update(currentRightSide.stickers[8]);
                newRightSide.stickers[6].update(currentRightSide.stickers[2]);
                newRightSide.stickers[2].update(currentRightSide.stickers[6]);
                newRightSide.stickers[5].update(currentRightSide.stickers[3]);
                newRightSide.stickers[3].update(currentRightSide.stickers[5]);
                newRightSide.stickers[7].update(currentRightSide.stickers[1]);
                newRightSide.stickers[1].update(currentRightSide.stickers[7]);

                newDownSide.stickers[2].update(currentUpSide.stickers[2]);
                newDownSide.stickers[8].update(currentUpSide.stickers[8]);
                newDownSide.stickers[5].update(currentUpSide.stickers[5]);

                newUpSide.stickers[2].update(currentDownSide.stickers[2]);
                newUpSide.stickers[8].update(currentDownSide.stickers[8]);
                newUpSide.stickers[5].update(currentDownSide.stickers[5]);

                newBackSide.stickers[6].update(currentFrontSide.stickers[2]);
                newBackSide.stickers[0].update(currentFrontSide.stickers[8]);
                newBackSide.stickers[3].update(currentFrontSide.stickers[5]);

                newFrontSide.stickers[2].update(currentBackSide.stickers[6]);
                newFrontSide.stickers[8].update(currentBackSide.stickers[0]);
                newFrontSide.stickers[5].update(currentBackSide.stickers[3]);
            }
            if (turn.Equals("F")) {
                newFrontSide.stickers[2].update(currentFrontSide.stickers[0]);
                newFrontSide.stickers[8].update(currentFrontSide.stickers[2]);
                newFrontSide.stickers[6].update(currentFrontSide.stickers[8]);
                newFrontSide.stickers[0].update(currentFrontSide.stickers[6]);
                newFrontSide.stickers[5].update(currentFrontSide.stickers[1]);
                newFrontSide.stickers[7].update(currentFrontSide.stickers[5]);
                newFrontSide.stickers[3].update(currentFrontSide.stickers[7]);
                newFrontSide.stickers[1].update(currentFrontSide.stickers[3]);

                newRightSide.stickers[6].update(currentUpSide.stickers[8]);
                newRightSide.stickers[0].update(currentUpSide.stickers[6]);
                newRightSide.stickers[3].update(currentUpSide.stickers[7]);

                newDownSide.stickers[0].update(currentRightSide.stickers[6]);
                newDownSide.stickers[2].update(currentRightSide.stickers[0]);
                newDownSide.stickers[1].update(currentRightSide.stickers[3]);

                newLeftSide.stickers[2].update(currentDownSide.stickers[0]);
                newLeftSide.stickers[8].update(currentDownSide.stickers[2]);
                newLeftSide.stickers[5].update(currentDownSide.stickers[1]);

                newUpSide.stickers[8].update(currentLeftSide.stickers[2]);
                newUpSide.stickers[6].update(currentLeftSide.stickers[8]);
                newUpSide.stickers[7].update(currentLeftSide.stickers[5]);
            }
            if (turn.Equals("F'")) {
                newFrontSide.stickers[0].update(currentFrontSide.stickers[2]);
                newFrontSide.stickers[6].update(currentFrontSide.stickers[0]);
                newFrontSide.stickers[8].update(currentFrontSide.stickers[6]);
                newFrontSide.stickers[2].update(currentFrontSide.stickers[8]);
                newFrontSide.stickers[3].update(currentFrontSide.stickers[1]);
                newFrontSide.stickers[7].update(currentFrontSide.stickers[3]);
                newFrontSide.stickers[5].update(currentFrontSide.stickers[7]);
                newFrontSide.stickers[1].update(currentFrontSide.stickers[5]);

                newLeftSide.stickers[2].update(currentUpSide.stickers[8]);
                newLeftSide.stickers[8].update(currentUpSide.stickers[6]);
                newLeftSide.stickers[5].update(currentUpSide.stickers[7]);

                newDownSide.stickers[0].update(currentLeftSide.stickers[2]);
                newDownSide.stickers[2].update(currentLeftSide.stickers[8]);
                newDownSide.stickers[1].update(currentLeftSide.stickers[5]);

                newRightSide.stickers[6].update(currentDownSide.stickers[0]);
                newRightSide.stickers[0].update(currentDownSide.stickers[2]);
                newRightSide.stickers[3].update(currentDownSide.stickers[1]);

                newUpSide.stickers[6].update(currentRightSide.stickers[0]);
                newUpSide.stickers[8].update(currentRightSide.stickers[6]);
                newUpSide.stickers[7].update(currentRightSide.stickers[3]);
            }
            if (turn.Equals("F2")) {
                newFrontSide.stickers[8].update(currentFrontSide.stickers[0]);
                newFrontSide.stickers[0].update(currentFrontSide.stickers[8]);
                newFrontSide.stickers[6].update(currentFrontSide.stickers[2]);
                newFrontSide.stickers[2].update(currentFrontSide.stickers[6]);
                newFrontSide.stickers[5].update(currentFrontSide.stickers[3]);
                newFrontSide.stickers[3].update(currentFrontSide.stickers[5]);
                newFrontSide.stickers[7].update(currentFrontSide.stickers[1]);
                newFrontSide.stickers[1].update(currentFrontSide.stickers[7]);

                newDownSide.stickers[0].update(currentUpSide.stickers[8]);
                newDownSide.stickers[2].update(currentUpSide.stickers[6]);
                newDownSide.stickers[1].update(currentUpSide.stickers[7]);

                newUpSide.stickers[8].update(currentDownSide.stickers[0]);
                newUpSide.stickers[6].update(currentDownSide.stickers[2]);
                newUpSide.stickers[7].update(currentDownSide.stickers[1]);

                newRightSide.stickers[0].update(currentLeftSide.stickers[8]);
                newRightSide.stickers[6].update(currentLeftSide.stickers[2]);
                newRightSide.stickers[3].update(currentLeftSide.stickers[5]);

                newLeftSide.stickers[8].update(currentRightSide.stickers[0]);
                newLeftSide.stickers[2].update(currentRightSide.stickers[6]);
                newLeftSide.stickers[5].update(currentRightSide.stickers[3]);
            }
            if (turn.Equals("B")) {
                newBackSide.stickers[2].update(currentBackSide.stickers[0]);
                newBackSide.stickers[8].update(currentBackSide.stickers[2]);
                newBackSide.stickers[6].update(currentBackSide.stickers[8]);
                newBackSide.stickers[0].update(currentBackSide.stickers[6]);
                newBackSide.stickers[5].update(currentBackSide.stickers[1]);
                newBackSide.stickers[7].update(currentBackSide.stickers[5]);
                newBackSide.stickers[3].update(currentBackSide.stickers[7]);
                newBackSide.stickers[1].update(currentBackSide.stickers[3]);

                newLeftSide.stickers[6].update(currentUpSide.stickers[0]);
                newLeftSide.stickers[0].update(currentUpSide.stickers[2]);
                newLeftSide.stickers[3].update(currentUpSide.stickers[1]);

                newDownSide.stickers[8].update(currentLeftSide.stickers[6]);
                newDownSide.stickers[6].update(currentLeftSide.stickers[0]);
                newDownSide.stickers[7].update(currentLeftSide.stickers[3]);

                newRightSide.stickers[2].update(currentDownSide.stickers[8]);
                newRightSide.stickers[8].update(currentDownSide.stickers[6]);
                newRightSide.stickers[5].update(currentDownSide.stickers[7]);

                newUpSide.stickers[0].update(currentRightSide.stickers[2]);
                newUpSide.stickers[2].update(currentRightSide.stickers[8]);
                newUpSide.stickers[1].update(currentRightSide.stickers[5]);
            }
            if (turn.Equals("B'")) {
                newBackSide.stickers[0].update(currentBackSide.stickers[2]);
                newBackSide.stickers[6].update(currentBackSide.stickers[0]);
                newBackSide.stickers[8].update(currentBackSide.stickers[6]);
                newBackSide.stickers[2].update(currentBackSide.stickers[8]);
                newBackSide.stickers[3].update(currentBackSide.stickers[1]);
                newBackSide.stickers[7].update(currentBackSide.stickers[3]);
                newBackSide.stickers[5].update(currentBackSide.stickers[7]);
                newBackSide.stickers[1].update(currentBackSide.stickers[5]);

                newRightSide.stickers[2].update(currentUpSide.stickers[0]);
                newRightSide.stickers[8].update(currentUpSide.stickers[2]);
                newRightSide.stickers[5].update(currentUpSide.stickers[1]);

                newDownSide.stickers[8].update(currentRightSide.stickers[2]);
                newDownSide.stickers[6].update(currentRightSide.stickers[8]);
                newDownSide.stickers[7].update(currentRightSide.stickers[5]);

                newLeftSide.stickers[6].update(currentDownSide.stickers[8]);
                newLeftSide.stickers[0].update(currentDownSide.stickers[6]);
                newLeftSide.stickers[3].update(currentDownSide.stickers[7]);

                newUpSide.stickers[0].update(currentLeftSide.stickers[6]);
                newUpSide.stickers[2].update(currentLeftSide.stickers[0]);
                newUpSide.stickers[1].update(currentLeftSide.stickers[3]);
            }
            if (turn.Equals("B2")) {
                newBackSide.stickers[8].update(currentBackSide.stickers[0]);
                newBackSide.stickers[0].update(currentBackSide.stickers[8]);
                newBackSide.stickers[6].update(currentBackSide.stickers[2]);
                newBackSide.stickers[2].update(currentBackSide.stickers[6]);
                newBackSide.stickers[5].update(currentBackSide.stickers[3]);
                newBackSide.stickers[3].update(currentBackSide.stickers[5]);
                newBackSide.stickers[7].update(currentBackSide.stickers[1]);
                newBackSide.stickers[1].update(currentBackSide.stickers[7]);

                newDownSide.stickers[8].update(currentUpSide.stickers[0]);
                newDownSide.stickers[6].update(currentUpSide.stickers[2]);
                newDownSide.stickers[7].update(currentUpSide.stickers[1]);

                newUpSide.stickers[0].update(currentDownSide.stickers[8]);
                newUpSide.stickers[2].update(currentDownSide.stickers[6]);
                newUpSide.stickers[1].update(currentDownSide.stickers[7]);

                newRightSide.stickers[2].update(currentLeftSide.stickers[6]);
                newRightSide.stickers[8].update(currentLeftSide.stickers[0]);
                newRightSide.stickers[5].update(currentLeftSide.stickers[3]);

                newLeftSide.stickers[6].update(currentRightSide.stickers[2]);
                newLeftSide.stickers[0].update(currentRightSide.stickers[8]);
                newLeftSide.stickers[3].update(currentRightSide.stickers[5]);
            }
            List<Side> newSides = new List<Side> { newUpSide, newRightSide, newFrontSide, newDownSide, newLeftSide, newBackSide };
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
            List<string> tempScrambleList = Util.turnSequenceToList("L F2 R2 L' F B2 R2 L2 U' F' D L' B D' R2 L2 R2 F D2 F");
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
            List<string> scramble = new List<string>();
            int numOfTurns = random.Next(18, 23); // Random value between 18 and 22 (inclusive)

            int doubleTurns = random.Next(numOfTurns / 2 + 1); // Maximum double turns allowed

            string previousTurn = "";

            for (int i = 0; i < numOfTurns; i++) {
                // Randomly select a face
                string face = turns[random.Next(turns.Length)];

                // Check for consecutive turns on the same face and parallel faces
                while (face == previousTurn || IsParallel(face, previousTurn)) {
                    face = turns[random.Next(turns.Length)];
                }

                // Randomly select the type of turn (normal, prime, or double)
                string turnType = GetTurnType(doubleTurns > 0);

                // Add the move to the scramble
                scramble.Add(face + turnType);

                // Update the previous turn and decrease the count of double turns
                previousTurn = face;
                if (turnType == "2") {
                    doubleTurns--;
                }
            }

            return scramble;
        }

        private static string GetTurnType(bool allowDoubleTurn) {
            if (allowDoubleTurn && random.Next(3) == 0) // 1/3 chance for a double turn
            {
                return "2";
            }
            else {
                return random.Next(2) == 0 ? "'" : ""; // 1/2 chance for prime
            }
        }

        private static bool IsParallel(string face1, string face2) {
            // Check if two faces are parallel
            return (face1 == "U" && face2 == "D") || (face1 == "D" && face2 == "U") ||
                   (face1 == "L" && face2 == "R") || (face1 == "R" && face2 == "L") ||
                   (face1 == "F" && face2 == "B") || (face1 == "B" && face2 == "F");
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