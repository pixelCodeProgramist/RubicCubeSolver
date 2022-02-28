using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    internal class TwoPlacesTakenCrossBottomOrangeSide : TwoPlacesTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isStraightLine;
        private Color centroidColorOfWhiteSquare;

        public TwoPlacesTakenCrossBottomOrangeSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, bool isStraightLine)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isStraightLine = isStraightLine;
            this.centroidColorOfWhiteSquare = mainSideColor;
        }

        public override void create()
        {
            setTwoInOneLineWhiteSquare(this.centroidColorOfWhiteSquare);
        }

        private void setTwoInOneLineWhiteSquare(Color centroidColorOfWhiteSquare)
        {
            Color colorOnYellowSide = getColorFromYellowSide(centroidColorOfWhiteSquare, rubicCubeSides);

            Movement movement = new Movement(MovementType.L_PRIM, rubicCubeSides);
            comleteSettingSquare(colorOnYellowSide, centroidColorOfWhiteSquare, rubicCubeSides, isStraightLine);
        }
    }
}