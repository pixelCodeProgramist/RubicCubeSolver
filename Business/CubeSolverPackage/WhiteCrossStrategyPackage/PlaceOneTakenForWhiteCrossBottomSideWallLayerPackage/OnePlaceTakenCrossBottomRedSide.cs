using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomRedSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public OnePlaceTakenCrossBottomRedSide(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public override void create()
        {
            throw new System.NotImplementedException();
        }
    }
}