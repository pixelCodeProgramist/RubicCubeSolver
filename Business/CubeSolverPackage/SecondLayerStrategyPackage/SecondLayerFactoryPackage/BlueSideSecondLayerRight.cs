using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class BlueSideSecondLayerRight : ISecondLayerForFactory
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public BlueSideSecondLayerRight(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.R, rubicCubeSides);
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.B, rubicCubeSides);
        }
    }
}
