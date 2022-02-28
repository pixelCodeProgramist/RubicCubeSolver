using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    class TwoPlacesTakenCrossBottomGreenSide : TwoPlacesTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isStraightLine;
        private Color centroidColorOfWhiteSquare;

        public TwoPlacesTakenCrossBottomGreenSide(Dictionary<Color, Side> rubicCubeSides, Color centroidColorOfWhiteSquare, bool isStraightLine)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isStraightLine = isStraightLine;
            this.centroidColorOfWhiteSquare = centroidColorOfWhiteSquare;
        }

        public override void create()
        {
            if (isStraightLine) setTwoInOneLineWhiteSquare(this.centroidColorOfWhiteSquare);
        }

        private void setTwoInOneLineWhiteSquare(Color centroidColorOfWhiteSquare)
        {
            Color colorOnYellowSide = getColorFromYellowSide(centroidColorOfWhiteSquare, rubicCubeSides);
            
            Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides);

            comleteMovementForSetTwoInOneLineWhiteSquare(colorOnYellowSide, centroidColorOfWhiteSquare, rubicCubeSides, isStraightLine);

        }
    }
}