using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube.Business.MovementUpdaterPackage
{
    class LRotation : MovementUpdaterAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private bool isReverse;
        public LRotation(Dictionary<Color, Side> rubicCubeSides, bool isReverse)
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
            if (this.isReverse)
            {
                rubicCubeSides[Color.GREEN].fields[0][0] = copyYellowSide.fields[0][0];
                rubicCubeSides[Color.GREEN].fields[1][0] = copyYellowSide.fields[1][0];
                rubicCubeSides[Color.GREEN].fields[2][0] = copyYellowSide.fields[2][0];

                rubicCubeSides[Color.YELLOW].fields[0][0] = copyBlueSide.fields[2][2];
                rubicCubeSides[Color.YELLOW].fields[1][0] = copyBlueSide.fields[1][2];
                rubicCubeSides[Color.YELLOW].fields[2][0] = copyBlueSide.fields[0][2];

                rubicCubeSides[Color.WHITE].fields[0][0] = copyGreenSide.fields[0][0];
                rubicCubeSides[Color.WHITE].fields[1][0] = copyGreenSide.fields[1][0];
                rubicCubeSides[Color.WHITE].fields[2][0] = copyGreenSide.fields[2][0];

                rubicCubeSides[Color.BLUE].fields[0][2] = copyWhiteSide.fields[2][0];
                rubicCubeSides[Color.BLUE].fields[1][2] = copyWhiteSide.fields[1][0];
                rubicCubeSides[Color.BLUE].fields[2][2] = copyWhiteSide.fields[0][0];
                
            }
            else
            {
                rubicCubeSides[Color.GREEN].fields[0][0] = copyWhiteSide.fields[0][0];
                rubicCubeSides[Color.GREEN].fields[1][0] = copyWhiteSide.fields[1][0];
                rubicCubeSides[Color.GREEN].fields[2][0] = copyWhiteSide.fields[2][0];

                rubicCubeSides[Color.YELLOW].fields[0][0] = copyGreenSide.fields[0][0];
                rubicCubeSides[Color.YELLOW].fields[1][0] = copyGreenSide.fields[1][0];
                rubicCubeSides[Color.YELLOW].fields[2][0] = copyGreenSide.fields[2][0];

                rubicCubeSides[Color.WHITE].fields[0][0] = copyBlueSide.fields[2][2];
                rubicCubeSides[Color.WHITE].fields[1][0] = copyBlueSide.fields[1][2];
                rubicCubeSides[Color.WHITE].fields[2][0] = copyBlueSide.fields[0][2];

                rubicCubeSides[Color.BLUE].fields[0][2] = copyYellowSide.fields[2][0];
                rubicCubeSides[Color.BLUE].fields[1][2] = copyYellowSide.fields[1][0];
                rubicCubeSides[Color.BLUE].fields[2][2] = copyYellowSide.fields[0][0];

            }

            rorateMainSide(rubicCubeSides, Color.ORANGE, isReverse);

        }
    }
}