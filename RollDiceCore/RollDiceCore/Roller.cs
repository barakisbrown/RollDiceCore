using System;

namespace RollDiceCore
{
    public class Roller
    {
        private static Roller _rollerInstance = null;
        private Random _random;

        private Roller()
        {
            _random = new Random();
        }

        public static Roller GetInstance()
        {
            if (_rollerInstance == null)
            {
                _rollerInstance = new Roller();                
            }

            return _rollerInstance;
        }

        public Random RAND => _random;
    }
}
