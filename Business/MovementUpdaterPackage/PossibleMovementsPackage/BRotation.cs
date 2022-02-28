using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube.Business.MovementUpdaterPackage
{
    class BRotation : MovementUpdaterAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isReverse;

        public BRotation(Dictionary<Color, Side> rubicCubeSides, bool isReverse)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isReverse = isReverse;
        }

        public override void update()
        {
            Side copyRedSide = rubicCubeSides[Color.RED].clone();
            Side copyWhiteSide = rubicCubeSides[Color.WHITE].clone();
            Side copyOrangeSide = rubicCubeSides[Color.ORANGE].clone();
            Side copyYellowSide = rubicCubeSides[Color.YELLOW].clone();
            
            if (this.isReverse)
            {
                rubicCubeSides[Color.RED].fields[0][2] = copyWhiteSide.fields[0][0];
                rubicCubeSides[Color.RED].fields[1][2] = copyWhiteSide.fields[0][1];
                rubicCubeSides[Color.RED].fields[2][2] = copyWhiteSide.fields[0][2];

                rubicCubeSides[Color.YELLOW].fields[2][0] = copyRedSide.fields[2][2];
                rubicCubeSides[Color.YELLOW].fields[2][1] = copyRedSide.fields[1][2];
                rubicCubeSides[Color.YELLOW].fields[2][2] = copyRedSide.fields[0][2];

                rubicCubeSides[Color.ORANGE].fields[0][0] = copyYellowSide.fields[2][0];
                rubicCubeSides[Color.ORANGE].fields[1][0] = copyYellowSide.fields[2][1];
                rubicCubeSides[Color.ORANGE].fields[2][0] = copyYellowSide.fields[2][2];

                rubicCubeSides[Color.WHITE].fields[0][0] = copyOrangeSide.fields[2][0];
                rubicCubeSides[Color.WHITE].fields[0][1] = copyOrangeSide.fields[1][0];
                rubicCubeSides[Color.WHITE].fields[0][2] = copyOrangeSide.fields[0][0];
            }
            else
            {
                rubicCubeSides[Color.RED].fields[0][2] = copyYellowSide.fields[2][2];
                rubicCubeSides[Color.RED].fields[1][2] = copyYellowSide.fields[2][1];
                rubicCubeSides[Color.RED].fields[2][2] = copyYellowSide.fields[2][0];

                rubicCubeSides[Color.YELLOW].fields[2][0] = copyOrangeSide.fields[0][0];
                rubicCubeSides[Color.YELLOW].fields[2][1] = copyOrangeSide.fields[1][0];
                rubicCubeSides[Color.YELLOW].fields[2][2] = copyOrangeSide.fields[2][0];

                rubicCubeSides[Color.ORANGE].fields[0][0] = copyWhiteSide.fields[0][2];
                rubicCubeSides[Color.ORANGE].fields[1][0] = copyWhiteSide.fields[0][1];
                rubicCubeSides[Color.ORANGE].fields[2][0] = copyWhiteSide.fields[0][0];

                rubicCubeSides[Color.WHITE].fields[0][0] = copyRedSide.fields[0][2];
                rubicCubeSides[Color.WHITE].fields[0][1] = copyRedSide.fields[1][2];
                rubicCubeSides[Color.WHITE].fields[0][2] = copyRedSide.fields[2][2];

            }

            rorateMainSide(rubicCubeSides, Color.BLUE, isReverse);

        }
    }
}