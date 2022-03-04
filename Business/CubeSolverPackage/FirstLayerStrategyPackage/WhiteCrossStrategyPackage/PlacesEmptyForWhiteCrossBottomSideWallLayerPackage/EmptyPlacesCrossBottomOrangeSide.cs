using RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage;
using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottmSideWallLayerPackage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage
{
    class EmptyPlacesCrossBottomOrangeSide : EmptyPlacesCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private List<Step> steps;
        public EmptyPlacesCrossBottomOrangeSide(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public override void create()
        {
            Movement movement = new Movement(MovementType.L_PRIM, this.rubicCubeSides);
            movement = new Movement(MovementType.F, this.rubicCubeSides);
            rotateWhiteSideToOtherCentroids(rubicCubeSides, steps);
        }
    }
}
