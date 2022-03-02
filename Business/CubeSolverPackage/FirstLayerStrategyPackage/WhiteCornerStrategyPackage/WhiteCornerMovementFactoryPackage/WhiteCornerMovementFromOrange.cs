using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage
{
    class WhiteCornerMovementFromOrange : IWhiteCornerMovement
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public WhiteCornerMovementFromOrange(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void move()
        {
            while (true)
            {
                Color whiteSide = rubicCubeSides[Color.WHITE].fields[2][0];
                Color greenSide = rubicCubeSides[Color.GREEN].fields[0][0];
                Color orangeSide = rubicCubeSides[Color.ORANGE].fields[0][2];

                if (whiteSide == Color.WHITE && greenSide == Color.GREEN && orangeSide == Color.ORANGE) break;

                Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides);
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                movement = new Movement(MovementType.F, rubicCubeSides);
                movement = new Movement(MovementType.D, rubicCubeSides);
            }
        }
    }
}