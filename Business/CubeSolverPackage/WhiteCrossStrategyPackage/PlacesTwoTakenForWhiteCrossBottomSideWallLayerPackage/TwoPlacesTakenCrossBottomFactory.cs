using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    class TwoPlacesTakenCrossBottomFactory
    {
        public TwoPlacesTakenCrossBottomAbstractClass createMovementUpdater(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, bool isStraightLine)
        {
            TwoPlacesTakenCrossBottomAbstractClass emptyPlacesCrossBottom = null;
            switch (mainSideColor)
            {
                case Color.GREEN:
                    emptyPlacesCrossBottom = new TwoPlacesTakenCrossBottomGreenSide(rubicCubeSides, mainSideColor, isStraightLine);
                    break;
                case Color.RED:
                    emptyPlacesCrossBottom = new TwoPlacesTakenCrossBottomRedSide(rubicCubeSides, mainSideColor, isStraightLine);
                    break;
                case Color.BLUE:
                    emptyPlacesCrossBottom = new TwoPlacesTakenCrossBottomBlueSide(rubicCubeSides, mainSideColor, isStraightLine);
                    break;
                case Color.ORANGE:
                    emptyPlacesCrossBottom = new TwoPlacesTakenCrossBottomOrangeSide(rubicCubeSides, mainSideColor, isStraightLine);
                    break;
                default:
                    break;
            }
            return emptyPlacesCrossBottom;
        }
    }
}
