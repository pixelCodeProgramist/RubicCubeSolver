using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossPackage.YellowCrossColorFactoryPackage
{
    class YellowCrossColorFromOrange : IYellowCrossColor
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private List<Step> steps;
        public YellowCrossColorFromOrange(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void move()
        {
            Movement movement = new Movement(MovementType.L, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.B, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
        }
    }
}