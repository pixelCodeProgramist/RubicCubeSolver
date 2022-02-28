using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage
{
    class EmptyPlacesCrossBottomBlueSide : EmptyPlacesCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        public EmptyPlacesCrossBottomBlueSide(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public override void create()
        {
            Movement movement = new Movement(MovementType.B_PRIM, this.rubicCubeSides);
            movement = new Movement(MovementType.L, this.rubicCubeSides);
            rotateWhiteSideToOtherCentroids(rubicCubeSides);
        }
    }
}
