using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage
{
    class WhiteCornerMovementFromRed : IWhiteCornerMovement
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public WhiteCornerMovementFromRed(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void move()
        {
            while (true)
            {
                Color whiteSide = rubicCubeSides[Color.WHITE].fields[0][2];
                Color blueSide = rubicCubeSides[Color.BLUE].fields[0][0];
                Color redSide = rubicCubeSides[Color.RED].fields[0][2];

                if (whiteSide == Color.WHITE && blueSide == Color.BLUE && redSide == Color.RED) break;

                Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                movement = new Movement(MovementType.B, rubicCubeSides);
                movement = new Movement(MovementType.D, rubicCubeSides);
            }
        }
    }
}