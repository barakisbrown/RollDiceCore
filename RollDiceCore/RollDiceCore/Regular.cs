namespace RollDiceCore
{
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

        public int Roll()
        {
            return _diceRoller.RAND.Next(1, _sides);
        }
    }
}
