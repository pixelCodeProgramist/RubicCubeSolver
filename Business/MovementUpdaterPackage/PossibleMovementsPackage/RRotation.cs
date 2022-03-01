using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube.Business.MovementUpdaterPackage
{
    class RRotation : MovementUpdaterAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isReverse;

        public RRotation(Dictionary<Color, Side> rubicCubeSides, bool isReverse)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isReverse = isReverse;
        }

        public override void update()
        {
            Side copyBlueSide = rubicCubeSides[Color.BLUE].clone();
            Side copyWhiteSide = rubicCubeSides[Color.WHITE].clone();
            Side copyGreenSide = rubicCubeSides[Color.GREEN].clone();
            Side copyYellowSide = rubicCubeSides[Color.YELLOW].clone();
            Side copyRedSide = rubicCubeSides[Color.RED].clone();
            if (this.isReverse)
            {
                rubicCubeSides[Color.GREEN].fields[0][2] = copyWhiteSide.fields[0][2];
                rubicCubeSides[Color.GREEN].fields[1][2] = copyWhiteSide.fields[1][2];
                rubicCubeSides[Color.GREEN].fields[2][2] = copyWhiteSide.fields[2][2];

                rubicCubeSides[Color.YELLOW].fields[0][2] = copyGreenSide.fields[0][2];
                rubicCubeSides[Color.YELLOW].fields[1][2] = copyGreenSide.fields[1][2];
                rubicCubeSides[Color.YELLOW].fields[2][2] = copyGreenSide.fields[2][2];

                rubicCubeSides[Color.WHITE].fields[0][2] = copyBlueSide.fields[2][0];
                rubicCubeSides[Color.WHITE].fields[1][2] = copyBlueSide.fields[1][0];
                rubicCubeSides[Color.WHITE].fields[2][2] = copyBlueSide.fields[0][0];

                rubicCubeSides[Color.BLUE].fields[0][0] = copyYellowSide.fields[2][2];
                rubicCubeSides[Color.BLUE].fields[1][0] = copyYellowSide.fields[1][2];
                rubicCubeSides[Color.BLUE].fields[2][0] = copyYellowSide.fields[0][2];

                rubicCubeSides[Color.RED].fields[0][0] = copyRedSide.fields[0][2];
                rubicCubeSides[Color.RED].fields[0][1] = copyRedSide.fields[1][2];
                rubicCubeSides[Color.RED].fields[0][2] = copyRedSide.fields[2][2];
                rubicCubeSides[Color.RED].fields[1][0] = copyRedSide.fields[0][1];
                rubicCubeSides[Color.RED].fields[1][1] = copyRedSide.fields[1][1];
                rubicCubeSides[Color.RED].fields[1][2] = copyRedSide.fields[2][1];
                rubicCubeSides[Color.RED].fields[2][0] = copyRedSide.fields[0][0];
                rubicCubeSides[Color.RED].fields[2][1] = copyRedSide.fields[1][0];
                rubicCubeSides[Color.RED].fields[2][2] = copyRedSide.fields[2][0];
            }
            else
            {
                rubicCubeSides[Color.GREEN].fields[0][2] = copyYellowSide.fields[0][2];
                rubicCubeSides[Color.GREEN].fields[1][2] = copyYellowSide.fields[1][2];
                rubicCubeSides[Color.GREEN].fields[2][2] = copyYellowSide.fields[2][2];

                rubicCubeSides[Color.YELLOW].fields[0][2] = copyBlueSide.fields[2][0];
                rubicCubeSides[Color.YELLOW].fields[1][2] = copyBlueSide.fields[1][0];
                rubicCubeSides[Color.YELLOW].fields[2][2] = copyBlueSide.fields[0][0];

                rubicCubeSides[Color.WHITE].fields[0][2] = copyGreenSide.fields[0][2];
                rubicCubeSides[Color.WHITE].fields[1][2] = copyGreenSide.fields[1][2];
                rubicCubeSides[Color.WHITE].fields[2][2] = copyGreenSide.fields[2][2];

                rubicCubeSides[Color.BLUE].fields[0][0] = copyWhiteSide.fields[2][2];
                rubicCubeSides[Color.BLUE].fields[1][0] = copyWhiteSide.fields[1][2];
                rubicCubeSides[Color.BLUE].fields[2][0] = copyWhiteSide.fields[0][2];

                rubicCubeSides[Color.RED].fields[0][0] = copyRedSide.fields[2][0];
                rubicCubeSides[Color.RED].fields[0][1] = copyRedSide.fields[1][0];
                rubicCubeSides[Color.RED].fields[0][2] = copyRedSide.fields[0][0];
                rubicCubeSides[Color.RED].fields[1][0] = copyRedSide.fields[2][1];
                rubicCubeSides[Color.RED].fields[1][1] = copyRedSide.fields[1][1];
                rubicCubeSides[Color.RED].fields[1][2] = copyRedSide.fields[0][1];
                rubicCubeSides[Color.RED].fields[2][0] = copyRedSide.fields[2][2];
                rubicCubeSides[Color.RED].fields[2][1] = copyRedSide.fields[1][2];
                rubicCubeSides[Color.RED].fields[2][2] = copyRedSide.fields[0][2];
            }


        }
    }
}