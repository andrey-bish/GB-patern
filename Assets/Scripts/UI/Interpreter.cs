using System;


namespace Asteroids
{
    class Interpreter
    {
        private long _inter;
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
            long.TryParse(value, out _inter);
            return Interpretation(_inter);
        }

        private string Interpretation(long inter)
        {
            inter += _oldScore;
            _oldScore = inter;

            if (inter < 0) 
                throw new ArgumentException("Zero in interpreter");
            if (inter >= 1_000_000_000)
                return (inter / 1_000_000_000) + "B";
            if (inter >= 1_000_000)
                return (inter / 1_000_000) + "M";
            if (inter >= 1000) 
                return (inter / 1000) + "K";
            return inter.ToString();
        }
    }
}
