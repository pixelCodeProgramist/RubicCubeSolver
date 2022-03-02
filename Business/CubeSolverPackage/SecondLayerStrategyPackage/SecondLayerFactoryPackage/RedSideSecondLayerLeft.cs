using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class RedSideSecondLayerLeft : ISecondLayerForFactory
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public RedSideSecondLayerLeft(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.B, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.R, rubicCubeSides);
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
        }
    }
}
