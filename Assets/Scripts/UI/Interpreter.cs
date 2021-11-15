using System;
using UnityEngine.UI;
using System.Collections.Generic;


namespace Asteroids
{
    class Interpreter
    {
        private Text _score;
        private long _oldScore = 0;
        private long _inter;
        private List<char> _charsToRemove = new List<char>() { 'K', 'M', 'B' };

        public Interpreter(Text score)
        {
            _score = score;
        }

        public void Scoring(string value)
        {
            long.TryParse(value, out _inter);
            _score.text = "Score: " + Interpretation(_inter);
        }

        private string Interpretation(long inter)
        {
            //if (_score.text != String.Empty)
            //{
            //    long.TryParse(EditStringScore(_score.text), out _oldScore);
            //}
                
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

        private string EditStringScore(string score)
        {
            foreach(char sss in score)
            {
                if (sss == 'B')
                {
                    Filter(score, _charsToRemove);
                    return score + 000000000;
                }
                else if (sss == 'M')
                {
                    Filter(score, _charsToRemove);
                    return score + 000000;
                }
                else if (sss == 'K')
                {
                    Filter(score, _charsToRemove);
                    return score + "000";
                }
            }
            return score;
        }

        private string Filter(string score, List<char> charsToRemove)
        {
            foreach(char c in charsToRemove)
            {
                score = score.Replace(c.ToString(), String.Empty);
            }
            return score;
        }

    }
}
