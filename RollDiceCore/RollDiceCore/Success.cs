namespace RollDiceCore
{
    /// <summary>
    /// An success is when dice a rolled against a target number to determine if the action
    /// was good or not. Games such as Storyteller, Shadowrun, others.
    /// NOTE: This is a single die based success dice roller 
    ///       Example: D10 with TN 8 [Chronicles of Darkness]
    ///                D6  with TN 5 [Shadownrun 5th]
    ///                DX  with TN X [Generic Success based roll]
    /// </summary>
    public class Success
    {
        private readonly Regular _dice;
        private readonly DiceTypes _die;
        private readonly int _targetNumber;

        public Success(DiceTypes die, int targetNumber)
        {
            _die = die;
            _targetNumber = targetNumber;   
            _dice = new Regular(_die);
        }

        /// <summary>
        /// Determines if what is rolled is a success. Sucess == rolled &gt;= TN
        /// </summary>
        /// <returns>true if success, false otherwise</returns>
        public bool Roll()
        {
            var diceRolled = _dice.Roll();
            return (diceRolled >= _targetNumber);
        }

        /// <summary>
        /// Determines if what is rolled is a success. Sucess == rolled &gt;= TN
        /// This function returns the results also if needed
        /// </summary>
        /// <param name="needResult">The result that was actually rolled</param>
        /// <returns>true if a success, false otherwise</returns>
        public bool Roll(out int needResult)
        {
            var diceRolled = _dice.Roll();
            needResult = diceRolled;
            return (diceRolled >= _targetNumber);
        }

        /// <summary>
        /// This overloaded version of Roll lets the GM Roll multiple dice
        /// and get their results back for both if they succeeded and what
        /// was rolled
        /// </summary>
        /// <param name="results">Array of boolean values for success</param>
        /// <param name="rolled">Array of integers valuea of actual results
        /// <returns>Number of success rolled</returns>
        public int Roll(int numberTimes, out bool []results, out int []rolled)
        {
            
            // Initalize arrays that need to be returned
            if (numberTimes < 1)
                throw new System.ArgumentOutOfRangeException("numberTimes can not be less than 1");
            results = new bool[numberTimes];
            rolled = new int[numberTimes];

            int successRolled = 0;
            // Start Iterating and return how many successes where rolled if any

            for (int i = 0; i < numberTimes; i++)
            {
                bool success;
                int resultRolled;
                success = Roll(out resultRolled);
                if (success)
                    successRolled++;
                results[i] = success;
                rolled[i] = resultRolled;
            }

            return successRolled;
        }
    }
}