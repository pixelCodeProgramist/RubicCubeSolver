using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomFactory
    {
        public OnePlaceTakenCrossBottomAbstractClass createMovementUpdater(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, List<Step> steps)
        {
            OnePlaceTakenCrossBottomAbstractClass onePlaceTakenCrossBottomAbstractClass = null;
            switch (mainSideColor)
            {
                case Color.GREEN:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomGreenSide(rubicCubeSides, mainSideColor, steps);
                    break;
                case Color.RED:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomRedSide(rubicCubeSides, mainSideColor, steps);
                    break;
                case Color.BLUE:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomBlueSide(rubicCubeSides, mainSideColor, steps);
                    break;
                case Color.ORANGE:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomOrangeSide(rubicCubeSides, mainSideColor, steps);
                    break;
                default:
                    break;
            }
            return onePlaceTakenCrossBottomAbstractClass;
        }
    }
}
