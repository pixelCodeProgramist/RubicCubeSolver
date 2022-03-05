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
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomGreenSide(rubicCubeSides, ref mainSideColor, steps);
                    break;
                case Color.RED:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomRedSide(rubicCubeSides,ref mainSideColor, steps);
                    break;
                case Color.BLUE:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomBlueSide(rubicCubeSides,ref mainSideColor, steps);
                    break;
                case Color.ORANGE:
                    onePlaceTakenCrossBottomAbstractClass = new OnePlaceTakenCrossBottomOrangeSide(rubicCubeSides,ref mainSideColor, steps);
                    break;
                default:
                    break;
            }
            return onePlaceTakenCrossBottomAbstractClass;
        }
    }
}
