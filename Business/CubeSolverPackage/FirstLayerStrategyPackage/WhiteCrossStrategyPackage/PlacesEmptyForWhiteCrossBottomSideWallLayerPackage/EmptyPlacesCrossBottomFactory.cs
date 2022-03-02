using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottmSideWallLayerPackage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage;

using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage
{
    class EmptyPlacesCrossBottomFactory
    {
        public EmptyPlacesCrossBottomAbstractClass createMovementUpdater(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor)
        {
            EmptyPlacesCrossBottomAbstractClass emptyPlacesCrossBottom = null;
            switch (mainSideColor)
            {
                case Color.GREEN:
                    emptyPlacesCrossBottom = new EmptyPlacesCrossBottomGreenSide(rubicCubeSides);
                    break;
                case Color.RED:
                    emptyPlacesCrossBottom = new EmptyPlacesCrossBottomRedSide(rubicCubeSides);
                    break;
                case Color.BLUE:
                    emptyPlacesCrossBottom = new EmptyPlacesCrossBottomBlueSide(rubicCubeSides);
                    break;
                case Color.ORANGE:
                    emptyPlacesCrossBottom = new EmptyPlacesCrossBottomOrangeSide(rubicCubeSides);
                    break;
                default:
                    break;
            }
            return emptyPlacesCrossBottom;
        }
    }
}
