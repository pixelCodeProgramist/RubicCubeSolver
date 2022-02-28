using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    internal class TwoPlacesTakenCrossBottomRedSide : TwoPlacesTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isStraightLine;
        private Color centroidColorOfWhiteSquare;

        public TwoPlacesTakenCrossBottomRedSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, bool isStraightLine)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isStraightLine = isStraightLine;
            this.centroidColorOfWhiteSquare = mainSideColor;
        }

        public override void create()
        {
            if (isStraightLine) setTwoInOneLineWhiteSquare(this.centroidColorOfWhiteSquare);
        }

        private void setTwoInOneLineWhiteSquare(Color centroidColorOfWhiteSquare)
        {
            Color colorOnYellowSide = getColorFromYellowSide(centroidColorOfWhiteSquare, rubicCubeSides);

            Movement movement = new Movement(MovementType.R_PRIM, rubicCubeSides);

            comleteMovementForSetTwoInOneLineWhiteSquare(colorOnYellowSide, centroidColorOfWhiteSquare, rubicCubeSides, isStraightLine);

        }
    }
}