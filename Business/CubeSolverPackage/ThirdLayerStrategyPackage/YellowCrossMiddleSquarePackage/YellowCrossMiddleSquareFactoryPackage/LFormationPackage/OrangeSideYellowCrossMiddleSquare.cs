using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage.LFormationPackage
{
    class OrangeSideYellowCrossMiddleSquare : IYellowCrossMiddleSquareFactory
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private List<Step> steps;
        public OrangeSideYellowCrossMiddleSquare(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.B, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.B, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.D, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
        }
    }
}
