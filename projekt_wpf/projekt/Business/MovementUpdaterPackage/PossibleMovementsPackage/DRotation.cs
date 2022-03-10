using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube.Business.MovementUpdaterPackage
{
    class DRotation : MovementUpdaterAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;

        private bool isReverse;
        public DRotation(Dictionary<Color, Side> rubicCubeSides, bool isReverse)
        {
            this.rubicCubeSides = rubicCubeSides;
            this.isReverse = isReverse;
        }

        public override void update()
        {
            Side copyOrangeSide = rubicCubeSides[Color.ORANGE].clone();
            Side copyGreenSide = rubicCubeSides[Color.GREEN].clone();
            Side copyRedSide = rubicCubeSides[Color.RED].clone();
            Side copyBlueSide = rubicCubeSides[Color.BLUE].clone();
            if (this.isReverse)
            {
                rubicCubeSides[Color.ORANGE].fields[2][0] = copyGreenSide.fields[2][0];
                rubicCubeSides[Color.ORANGE].fields[2][1] = copyGreenSide.fields[2][1];
                rubicCubeSides[Color.ORANGE].fields[2][2] = copyGreenSide.fields[2][2];

                rubicCubeSides[Color.GREEN].fields[2][0] = copyRedSide.fields[2][0];
                rubicCubeSides[Color.GREEN].fields[2][1] = copyRedSide.fields[2][1];
                rubicCubeSides[Color.GREEN].fields[2][2] = copyRedSide.fields[2][2];

                rubicCubeSides[Color.RED].fields[2][0] = copyBlueSide.fields[2][0];
                rubicCubeSides[Color.RED].fields[2][1] = copyBlueSide.fields[2][1];
                rubicCubeSides[Color.RED].fields[2][2] = copyBlueSide.fields[2][2];

                rubicCubeSides[Color.BLUE].fields[2][0] = copyOrangeSide.fields[2][0];
                rubicCubeSides[Color.BLUE].fields[2][1] = copyOrangeSide.fields[2][1];
                rubicCubeSides[Color.BLUE].fields[2][2] = copyOrangeSide.fields[2][2];
            }
            else
            {
                rubicCubeSides[Color.ORANGE].fields[2][0] = copyBlueSide.fields[2][0];
                rubicCubeSides[Color.ORANGE].fields[2][1] = copyBlueSide.fields[2][1];
                rubicCubeSides[Color.ORANGE].fields[2][2] = copyBlueSide.fields[2][2];

                rubicCubeSides[Color.GREEN].fields[2][0] = copyOrangeSide.fields[2][0];
                rubicCubeSides[Color.GREEN].fields[2][1] = copyOrangeSide.fields[2][1];
                rubicCubeSides[Color.GREEN].fields[2][2] = copyOrangeSide.fields[2][2];

                rubicCubeSides[Color.RED].fields[2][0] = copyGreenSide.fields[2][0];
                rubicCubeSides[Color.RED].fields[2][1] = copyGreenSide.fields[2][1];
                rubicCubeSides[Color.RED].fields[2][2] = copyGreenSide.fields[2][2];

                rubicCubeSides[Color.BLUE].fields[2][0] = copyRedSide.fields[2][0];
                rubicCubeSides[Color.BLUE].fields[2][1] = copyRedSide.fields[2][1];
                rubicCubeSides[Color.BLUE].fields[2][2] = copyRedSide.fields[2][2];
            }

            rorateMainSide(rubicCubeSides, Color.YELLOW, isReverse);
        }
    }
}