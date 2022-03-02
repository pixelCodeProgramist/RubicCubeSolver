using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomOrangeSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private Color centroidColor;
        public OnePlaceTakenCrossBottomOrangeSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.centroidColor = mainSideColor;
        }

        public override void create()
        {
            rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(rubicCubeSides, centroidColor);
            Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.F, rubicCubeSides);
            movement = new Movement(MovementType.U, rubicCubeSides);
        }
    }
}