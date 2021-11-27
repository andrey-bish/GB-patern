using System;


namespace Asteroids
{
    class Interpreter
    {
        private long _score;
        private long _oldScore = 0;

        private static Interpreter obj;
        public static Interpreter Get()
        {
            if (obj == null)
                obj = new Interpreter();
            return obj;
        }

        public string Scoring(string value)
        {
            long.TryParse(value, out _score);
            return Interpretation(_score);
        }

        private string Interpretation(long score)
        {
            score += _oldScore;
            _oldScore = score;

            if (score < 0) 
                throw new ArgumentException("Zero in interpreter");
            if (score >= 1_000_000_000)
                return (score / 1_000_000_000) + "B";
            if (score >= 1_000_000)
                return (score / 1_000_000) + "M";
            if (score >= 1000) 
                return (score / 1000) + "K";
            return score.ToString();
        }
    }
}
