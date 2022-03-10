using RubicCube.Models;
using System;
using System.Collections.Generic;

namespace RubicCube.Business.MovementUpdaterPackage
{
    class URotation : MovementUpdaterAbstractClass
    {
        private Dictionary<Color, Side> rubicCubeSides;
        private bool isReverse;

        public URotation(Dictionary<Color, Side> rubicCubeSides, bool isReverse)
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
                rubicCubeSides[Color.ORANGE].fields[0][0] = copyBlueSide.fields[0][0];
                rubicCubeSides[Color.ORANGE].fields[0][1] = copyBlueSide.fields[0][1];
                rubicCubeSides[Color.ORANGE].fields[0][2] = copyBlueSide.fields[0][2];

                rubicCubeSides[Color.GREEN].fields[0][0] = copyOrangeSide.fields[0][0];
                rubicCubeSides[Color.GREEN].fields[0][1] = copyOrangeSide.fields[0][1];
                rubicCubeSides[Color.GREEN].fields[0][2] = copyOrangeSide.fields[0][2];

                rubicCubeSides[Color.RED].fields[0][0] = copyGreenSide.fields[0][0];
                rubicCubeSides[Color.RED].fields[0][1] = copyGreenSide.fields[0][1];
                rubicCubeSides[Color.RED].fields[0][2] = copyGreenSide.fields[0][2];

                rubicCubeSides[Color.BLUE].fields[0][0] = copyRedSide.fields[0][0];
                rubicCubeSides[Color.BLUE].fields[0][1] = copyRedSide.fields[0][1];
                rubicCubeSides[Color.BLUE].fields[0][2] = copyRedSide.fields[0][2];
            }
            else
            {
                rubicCubeSides[Color.ORANGE].fields[0][0] = copyGreenSide.fields[0][0];
                rubicCubeSides[Color.ORANGE].fields[0][1] = copyGreenSide.fields[0][1];
                rubicCubeSides[Color.ORANGE].fields[0][2] = copyGreenSide.fields[0][2];

                rubicCubeSides[Color.GREEN].fields[0][0] = copyRedSide.fields[0][0];
                rubicCubeSides[Color.GREEN].fields[0][1] = copyRedSide.fields[0][1];
                rubicCubeSides[Color.GREEN].fields[0][2] = copyRedSide.fields[0][2];

                rubicCubeSides[Color.RED].fields[0][0] = copyBlueSide.fields[0][0];
                rubicCubeSides[Color.RED].fields[0][1] = copyBlueSide.fields[0][1];
                rubicCubeSides[Color.RED].fields[0][2] = copyBlueSide.fields[0][2];

                rubicCubeSides[Color.BLUE].fields[0][0] = copyOrangeSide.fields[0][0];
                rubicCubeSides[Color.BLUE].fields[0][1] = copyOrangeSide.fields[0][1];
                rubicCubeSides[Color.BLUE].fields[0][2] = copyOrangeSide.fields[0][2];
            }

            rorateMainSide(rubicCubeSides, Color.WHITE, isReverse);

        }
    }
}