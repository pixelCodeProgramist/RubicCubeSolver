using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomOrangeSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private Color centroidColor;
        private List<Step> steps;
        public OnePlaceTakenCrossBottomOrangeSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.centroidColor = mainSideColor;
            this.steps = steps;
        }

        public override void create()
        {
            rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(rubicCubeSides, centroidColor, steps);
            Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.F, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
            movement = new Movement(MovementType.U, rubicCubeSides);
            steps.Add(new Step(movement, rubicCubeSides));
        }
    }
}