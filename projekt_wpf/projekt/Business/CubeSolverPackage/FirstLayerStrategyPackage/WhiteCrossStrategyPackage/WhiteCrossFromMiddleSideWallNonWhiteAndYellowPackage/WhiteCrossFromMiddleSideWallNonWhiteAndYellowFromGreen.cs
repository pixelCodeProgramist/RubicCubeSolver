using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromMiddleSideWallNonWhiteAndYellowPackage
{
    internal class WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromGreen : IWhiteCrossFromMiddleSideWallNonWhiteAndYellow
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;

        public WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromGreen(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
            Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides, steps);
           
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
           
            movement = new Movement(MovementType.R, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
          
        }
    }
}