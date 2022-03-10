using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromUpSideWallNonWhiteAndYellowPackage
{
    class WhiteCrossFromUpSideWallNonWhiteAndYellowFromBlue : IWhiteCrossFromUpSideWallNonWhiteAndYellow
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;

        public WhiteCrossFromUpSideWallNonWhiteAndYellowFromBlue(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
           
            while (true)
            {
                bool isWhite = rubicCubeSides[Color.YELLOW].fields[2][1] == Color.WHITE || rubicCubeSides[Color.BLUE].fields[2][1] == Color.WHITE;
                if (!isWhite) break;
                Movement currMovement = new Movement(MovementType.D, rubicCubeSides, steps);
               
            }

            Movement movement = new Movement(MovementType.B, rubicCubeSides, steps);
          
            movement = new Movement(MovementType.B, rubicCubeSides, steps);
           
        }
    }
}