using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCornerStrategyPackage
{
    class WhiteCornerMovementFromBlue : IWhiteCornerMovement
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;

        public WhiteCornerMovementFromBlue(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
            while (true)
            {
                Color whiteSide = rubicCubeSides[Color.WHITE].fields[0][0];
                Color orangeSide = rubicCubeSides[Color.ORANGE].fields[0][0];
                Color blueSide = rubicCubeSides[Color.BLUE].fields[0][2];

                if (whiteSide == Color.WHITE && orangeSide == Color.ORANGE && blueSide == Color.BLUE) break;
                
                Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.L, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
                movement = new Movement(MovementType.D, rubicCubeSides);
                steps.Add(new Step(movement, rubicCubeSides));
            }
        }
    }
}