using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlaceOneTakenForWhiteCrossBottomSideWallLayerPackage
{
    class OnePlaceTakenCrossBottomRedSide : OnePlaceTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private Color centroidColor;

        public OnePlaceTakenCrossBottomRedSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.centroidColor = mainSideColor;
            
        }

        public override void create()
        {
            rotateLastLayerRelativeCentroidAndYellowNaighbourSquare(rubicCubeSides, centroidColor);
            Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.U_PRIM, rubicCubeSides);
            movement = new Movement(MovementType.B, rubicCubeSides);
            movement = new Movement(MovementType.U, rubicCubeSides);
           
        }
    }
}