using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomFactory
    {
        public OnePlaceTakenCrossBottomAbstractClass createMovementUpdater(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor)
        {
            OnePlaceTakenCrossBottomAbstractClass onePlaceTakenCrossBottomAbstractClass = null;
            switch (mainSideColor)
            {
                case Color.GREEN:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomGreenSide(rubicCubeSides);
                    break;
                case Color.RED:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomRedSide(rubicCubeSides);
                    break;
                case Color.BLUE:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomBlueSide(rubicCubeSides);
                    break;
                case Color.ORANGE:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomOrangeSide(rubicCubeSides);
                    break;
                default:
                    break;
            }
            return onePlaceTakenCrossBottomAbstractClass;
        }
    }
}
