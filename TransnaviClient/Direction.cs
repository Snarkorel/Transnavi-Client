using System;

namespace Snarkorel.transnavi.client
{
    public enum Direction : byte
    {
        /// <summary>
        /// A
        /// </summary>
        Forward,
        /// <summary>
        /// B
        /// </summary>
        Backward
    }

    public static class DirectionHelper
    {
        private const string DirA = "A";
        private const string DirB = "B";

        public static string GetDirectionString(Direction dir)
        {
            switch (dir)
            {
                case Direction.Forward:
                    return DirA;
                case Direction.Backward:
                    return DirB;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir));
            }
        }
    }
}
