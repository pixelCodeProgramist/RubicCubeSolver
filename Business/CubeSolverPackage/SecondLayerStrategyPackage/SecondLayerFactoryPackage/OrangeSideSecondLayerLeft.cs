using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class OrangeSideSecondLayerLeft : ISecondLayerForFactory
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public OrangeSideSecondLayerLeft(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.F_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.F, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.L, rubicCubeSides);
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
        }
    }
}
