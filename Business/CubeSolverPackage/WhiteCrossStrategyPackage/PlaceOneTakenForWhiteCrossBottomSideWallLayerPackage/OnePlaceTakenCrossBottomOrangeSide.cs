using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomOrangeSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public OnePlaceTakenCrossBottomOrangeSide(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public override void create()
        {
            throw new System.NotImplementedException();
        }
    }
}