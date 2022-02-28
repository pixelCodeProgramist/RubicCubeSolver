using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomBlueSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private Color centroidColor;
        public OnePlaceTakenCrossBottomBlueSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.centroidColor = mainSideColor;
        }

        public override void create()
        {
            rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(rubicCubeSides, centroidColor);

            Movement movement = new Movement(MovementType.B_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.L, rubicCubeSides);
            movement = new Movement(MovementType.U, rubicCubeSides);
        }
    }
}