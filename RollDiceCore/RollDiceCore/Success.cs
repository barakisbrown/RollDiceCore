namespace RollDiceCore
{
    /// <summary>
    /// An success is when dice a rolled against a target number to determine if the action
    /// was good or not. Games such as Storyteller, Shadowrun, others
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
    }
}