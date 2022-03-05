using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromUpSideWallNonWhiteAndYellowPackage
{
    class WhiteCrossFromUpSideWallNonWhiteAndYellowFromGreen : IWhiteCrossFromUpSideWallNonWhiteAndYellow
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;

        public WhiteCrossFromUpSideWallNonWhiteAndYellowFromGreen(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
            while (true)
            {
                bool isWhite = rubicCubeSides[Color.YELLOW].fields[0][1] == Color.WHITE || rubicCubeSides[Color.GREEN].fields[2][1] == Color.WHITE;
                if (!isWhite) break;
                Movement currMovement = new Movement(MovementType.D, rubicCubeSides);
                this.steps.Add(new Step(currMovement, rubicCubeSides));
            }

            Movement movement = new Movement(MovementType.F, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.F, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
          
        }
    }
}