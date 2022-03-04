using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPakage.PlacesEmptyForWhiteCrossBottomSideWallLayerPackage
{
    class EmptyPlacesCrossBottomBlueSide : EmptyPlacesCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private List<Step> steps;
        public EmptyPlacesCrossBottomBlueSide(Dictionary<Color, Side> rubicCubeSides, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.steps = steps;
        }

        public override void create()
        {
            Movement movement = new Movement(MovementType.B_PRIM, this.rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.L, this.rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            rotateWhiteSideToOtherCentroids(rubicCubeSides, steps);
        }
    }
}
