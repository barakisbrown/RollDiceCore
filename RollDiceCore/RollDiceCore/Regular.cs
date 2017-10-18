using System;

namespace RollDiceCore
{
    /// <summary>
    /// Dice roller used for most cases where a dice needs to be rolled.
    /// Yes, u could use rand function yourself but this wrap around it
    /// and automatically give u a result between 1 and N.
    /// </summary>
    public class Regular
    {
        private readonly Roller _diceRoller = Roller.GetInstance();
        private readonly DiceTypes _die;
        private readonly int _sides;

        public Regular(DiceTypes type)
        {
            _die = type;
            _sides = type.ConvertToInt();
        }

        /// <summary>
        /// Simple rolls a die and returns it
        /// </summary>
        /// <returns>1 to N where N is the dice rolled</returns>
        public int Roll()
        {
            return _diceRoller.RAND.Next(1, _sides);
        }

        /// <summary>
        /// Rolls the same dice a predefined number of times based on the argument supplied
        /// IE: numberOfTimes = 5, then it will roll the dice 5 times and then return the result
        /// </summary>
        /// <returns>Amount rolled</returns>
        /// <param name="numberOfTimes">The number of dice rolled. Has to be greater than 1</param>
        public int Roll(int numberOfTimes)
        {
            if (numberOfTimes < 1)
                throw new System.ArgumentException("Number of dice has to be greater than 1");

            int resultReturned = 0;
            for (int i = 0; i < numberOfTimes; i++)
            {
                resultReturned += Roll();
            }

            return resultReturned;
        }

        /// <summary>
        /// Rolls the same dice a predefined number of times based on the argument supplied
        /// IE: numberOfTimes = 5, then it will roll the dice 5 times and then return the result
        /// This method also returns an array of values should the user need the results for display,etc.
        /// </summary>
        /// <param name="numberOfTimes">The number of dice rolled. Has to be greater than 1</param>
        /// <param name="results">Integer Array where results are returned back to the caller function. Please note, 
        ///                       the array being returned will have been recreated.</param>
        /// <returns>Amount Rolled</returns>
        public int Roll(int numberOfTimes, out int[]results)
        {
            if (numberOfTimes < 1)
                throw new ArgumentException("Number of dice has to be greater than 1");

            results = new int[numberOfTimes];
            int resultReturned = 0;
            for (int I = 0; I < numberOfTimes; I++)
            {
                var tempRolled = Roll();
                resultReturned += tempRolled;
                results[I] = tempRolled;
            }

            return resultReturned;
        }
    }
}
