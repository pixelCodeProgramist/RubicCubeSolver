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
            Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.B, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
        }
    }
}