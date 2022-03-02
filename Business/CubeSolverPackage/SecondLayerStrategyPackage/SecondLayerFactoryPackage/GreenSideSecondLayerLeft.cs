using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class GreenSideSecondLayerLeft : ISecondLayerForFactory
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public GreenSideSecondLayerLeft(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void solve()
        {
            Movement movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.R, rubicCubeSides);
            movement = new Movement(MovementType.D, rubicCubeSides);
            movement = new Movement(MovementType.F, rubicCubeSides);
            movement = new Movement(MovementType.D_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.F_PRIM, rubicCubeSides);
        }
    }
}
