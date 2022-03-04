using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.FirstLayerStrategyPackage.WhiteCrossStrategyPackage.WhiteCrossFromMiddleSideWallNonWhiteAndYellowPackage
{
    internal class WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromBlue : IWhiteCrossFromMiddleSideWallNonWhiteAndYellow
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;

        public WhiteCrossFromMiddleSideWallNonWhiteAndYellowFromBlue(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
            Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.L, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            this.steps.Add(new Step(movement, rubicCubeSides));
        }
    }
}