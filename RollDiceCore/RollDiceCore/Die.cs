namespace RollDiceCore
{
    /// <summary>
    /// This visualizes what a single die[example: D6] used in any games.
    /// </summary>
    public class Die
    {
        /// <summary>
        /// Enum version of the Die in question
        /// </summary>
        protected DiceTypes _Die { get; set; } = DiceTypes.None;

        /// <summary>
        /// The number of sides
        /// </summary>
        protected int Sides { get; set; }

        /// <summary>
        /// Amount for when the dice is actaully rolled
        /// </summary>
        protected int Amount { get; set; }

        public Die(int sides)
        {
            Sides = sides;
            _Die = Extensions.ConvertToTypes(Sides);
        }

        public Die(DiceTypes die)
        {
            Sides = die.ConvertToInt();
            _Die = die;
        }
    }
}