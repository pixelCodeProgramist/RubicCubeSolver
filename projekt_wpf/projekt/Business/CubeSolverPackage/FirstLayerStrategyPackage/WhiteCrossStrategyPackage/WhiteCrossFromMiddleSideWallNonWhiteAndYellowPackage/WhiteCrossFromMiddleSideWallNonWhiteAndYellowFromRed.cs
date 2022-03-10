using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromMiddleSideWallNonWhiteAndYellowPackage
{
    internal class WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromRed : IWhiteCrossFromMiddleSideWallNonWhiteAndYellow
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;

        public WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromRed(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
            Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides, steps);
           
            movement = new Movement(MovementType.B, rubicCubeSides, steps);
            
            movement = new Movement(MovementType.D, rubicCubeSides, steps);
          
        }
    }
}