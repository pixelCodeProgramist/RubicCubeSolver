using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage
{
    class WhiteCornerMovementFromGreen : IWhiteCornerMovement
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public WhiteCornerMovementFromGreen(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
            while (true)
            {
                Color whiteSide = rubicCubeSides[Color.WHITE].fields[2][2];
                Color redSide = rubicCubeSides[Color.RED].fields[0][0];
                Color greenSide = rubicCubeSides[Color.GREEN].fields[0][2];

                if (whiteSide == Color.WHITE && redSide == Color.RED && greenSide == Color.GREEN) break;

                Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.R, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.D, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }
        }
    }
}