﻿namespace TexasHoldem.Logic.Players
{
    public class PlayerAction
    {
        private static readonly PlayerAction FoldObject = new PlayerAction(PlayerActionType.Fold);
        private static readonly PlayerAction CheckCallObject = new PlayerAction(PlayerActionType.CheckCall);

        private PlayerAction(PlayerActionType type)
        {
            this.Type = type;
        }

        private PlayerAction(int money)
        {
            this.Type = PlayerActionType.Raise;
            this.Money = money;
        }

        public PlayerActionType Type { get; internal set; }

        public int Money { get; internal set; }

        public static PlayerAction Fold()
        {
            return FoldObject;
        }

        public static PlayerAction CheckOrCall()
        {
            return CheckCallObject;
        }

        /// <summary>
        /// Creates a new object containing information about the player action and the raise amount
        /// </summary>
        /// <param name="toAmount">
        /// The amount to raise with.
        /// If amount is less than the minimum amount for raising then the game will take this minimum amount from the players money.
        /// If amount is more or equal to the players money the player will be in all-in state
        /// </param>
        /// <returns>A new player action object containing information about the player action and the raise amount</returns>
        public static PlayerAction Raise(int toAmount)
        {
            return new PlayerAction(toAmount);
        }

        public override string ToString()
        {
            return $"{this.Type}({this.Money})";
        }
    }
}
