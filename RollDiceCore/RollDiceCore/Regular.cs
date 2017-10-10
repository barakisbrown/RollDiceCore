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
                throw new System.ArgumentException("Number of dice has to be at least 1");

            int resultReturned = 0;
            for (int i = 0; i < numberOfTimes; i++)
            {
                resultReturned += Roll();
            }

            return resultReturned;
        }
    }
}
