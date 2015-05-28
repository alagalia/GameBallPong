using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace WindowsFormsApplication1
{
    class Public_Properties
    {
        private static Color player1Color;
        private static Color player2Color;
        private static string player1Name;
        private static string player2Name;
        private static int difficulty;
        private static int player1Score;
        private static int player2Score;
        private static int ballSpeed;
        private static bool helpEnabled;

        public static bool HelpEnabled
        {
            get { return helpEnabled; }
            set { helpEnabled = value; }
        }
        public static int BallSpeed
        {
            get { return ballSpeed; }
            set { ballSpeed = value; }
        }

        public static int Player1Score
        {
            get { return player1Score; }
            set { player1Score = value; }
        }
        public static int Player2Score
        {
            get { return player2Score; }
            set { player2Score = value; }
        }
        public static int Difficulty
        {
            get { return difficulty;}
            set { difficulty = value; }
        }
        public static Color Player1Color
        {
            get { return player1Color; }
            set { player1Color = value; }
        }
        public static Color Player2Color
        {
            get { return player2Color; }
            set { player2Color = value; }
        }

        public static string Player1Name
        {
            get { return player1Name; }
            set { player1Name = value; }
        }
        public static string Player2Name
        {
            get { return player2Name; }
            set { player2Name = value; }
        }
    }
}
