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

        private List<Step> steps;
        public EmptyPlacesCrossBottomRedSide(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public override void create()
        {
            Movement movement = new Movement(MovementType.R_PRIM, this.rubicCubeSides, steps);
            
            movement = new Movement(MovementType.B, this.rubicCubeSides, steps);
            
            rotateWhiteSideToOtherCentroids(rubicCubeSides, steps);
        }
    }
}
