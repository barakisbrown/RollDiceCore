namespace RollDiceCore.Src
{
    public enum DiceTypes
    {
        None = 0,
        D3 = 3,
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D30 = 30,
        D100 = 100
    }

    /// <summary>
    /// Static Class to house my extension method for me to test weather a certain type is allowed or not
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Determine if the Dice asked to be rolled is allowed
        /// </summary>
        /// <param name="type">DiceType</param>
        /// <returns>bool true if allowed or false otherwise</returns>
        public static bool Allowed(this DiceTypes type)
        {
            bool retValue = false;
            switch (type)
            {
                case DiceTypes.None:
                    break;
                case DiceTypes.D3:
                case DiceTypes.D4:
                case DiceTypes.D6:
                case DiceTypes.D8:
                case DiceTypes.D10:
                case DiceTypes.D12:
                case DiceTypes.D20:
                case DiceTypes.D30:
                case DiceTypes.D100:
                {
                    retValue = true;
                    break;
                }
            }

            return retValue;
        }

        /// <summary>
        /// Helper funtion that will take a number and convert it to
        /// DiceType.
        /// </summary>
        /// <param name="value">Int being converted to DiceType</param>
        /// <returns>DiceType</returns>
        public static DiceTypes ConvertToTypes(int value)
        {
            switch (value)
            {
                case 3:
                    return DiceTypes.D3;
                case 4:
                    return DiceTypes.D4;
                case 6:
                    return DiceTypes.D6;
                case 8:
                    return DiceTypes.D8;
                case 10:
                    return DiceTypes.D10;
                case 12:
                    return DiceTypes.D12;
                case 20:
                    return DiceTypes.D20;
                case 30:
                    return DiceTypes.D30;
                case 100:
                    return DiceTypes.D100;
                default:
                    return DiceTypes.None;
            }
        }

        /// <summary>
        /// Converts the DiceType from enum to int
        /// </summary>
        /// <param name="type">DiceType</param>
        /// <returns>int value of the DiceType</returns>
        public static int ConvertToInt(this DiceTypes type) => (int)type;
    }
}