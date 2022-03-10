using RubicCube.Models;
using System.Collections.Generic;

namespace RubicCube.Business.CubeSolverPackage.WhiteCrossStrategyPackage.PlacesTwoTakenForWhiteCrossBottomSideWallLayerPackage
{
    class TwoPlacesTakenCrossBottomGreenSide : TwoPlacesTakenCrossBottomAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isStraightLine;
        private Color centroidColorOfWhiteSquare;
        private List<Step> steps;
        public TwoPlacesTakenCrossBottomGreenSide(Dictionary<Color, Side> rubicCubeSides, Color centroidColorOfWhiteSquare, bool isStraightLine, List<Step> steps)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isStraightLine = isStraightLine;
            this.centroidColorOfWhiteSquare = centroidColorOfWhiteSquare;
            this.steps = steps;
        }

        public override void create()
        {
            setTwoInOneLineWhiteSquare(this.centroidColorOfWhiteSquare);
        }

        private void setTwoInOneLineWhiteSquare(Color centroidColorOfWhiteSquare)
        {
            Color colorOnYellowSide = getColorFromYellowSide(centroidColorOfWhiteSquare, rubicCubeSides);
            
            Movement movement = new Movement(MovementType.F_PRIM, rubicCubeSides, steps);
            

            comleteSettingSquare(colorOnYellowSide, centroidColorOfWhiteSquare, rubicCubeSides, isStraightLine, steps);

        }
    }
}