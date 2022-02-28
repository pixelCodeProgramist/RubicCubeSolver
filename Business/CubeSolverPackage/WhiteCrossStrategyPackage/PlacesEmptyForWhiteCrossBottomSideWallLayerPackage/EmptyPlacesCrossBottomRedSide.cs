using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottmSideWallLayerPackage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage
{
    class EmptyPlacesCrossBottomRedSide : EmptyPlacesCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public EmptyPlacesCrossBottomRedSide(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public override void create()
        {
            Movement movement = new Movement(MovementType.R_PRIM, this.rubicCubeSides);
            movement = new Movement(MovementType.B, this.rubicCubeSides);
            rotateWhiteSideToOtherCentroids(rubicCubeSides);
        }
    }
}
