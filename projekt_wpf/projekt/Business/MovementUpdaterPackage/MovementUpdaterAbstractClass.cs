using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business
{
    abstract class MovementUpdaterAbstractClass
    {
        public abstract void update();

        protected void rorateMainSide(Dictionary<Color, Side> rubicCubeSides, Color mainSideColor, bool isReverse)
        {
            Side copySide = rubicCubeSides[mainSideColor].clone();
            
            if(isReverse)
            {
                rubicCubeSides[mainSideColor].fields[0][0] = copySide.fields[0][2];
                rubicCubeSides[mainSideColor].fields[0][1] = copySide.fields[1][2];
                rubicCubeSides[mainSideColor].fields[0][2] = copySide.fields[2][2];
                rubicCubeSides[mainSideColor].fields[1][0] = copySide.fields[0][1];
                rubicCubeSides[mainSideColor].fields[1][1] = copySide.fields[1][1];
                rubicCubeSides[mainSideColor].fields[1][2] = copySide.fields[2][1];
                rubicCubeSides[mainSideColor].fields[2][0] = copySide.fields[0][0];
                rubicCubeSides[mainSideColor].fields[2][1] = copySide.fields[1][0];
                rubicCubeSides[mainSideColor].fields[2][2] = copySide.fields[2][0];
            } else
            {
                rubicCubeSides[mainSideColor].fields[0][0] = copySide.fields[2][0];
                rubicCubeSides[mainSideColor].fields[0][1] = copySide.fields[1][0];
                rubicCubeSides[mainSideColor].fields[0][2] = copySide.fields[0][0];
                rubicCubeSides[mainSideColor].fields[1][0] = copySide.fields[2][1];
                rubicCubeSides[mainSideColor].fields[1][1] = copySide.fields[1][1];
                rubicCubeSides[mainSideColor].fields[1][2] = copySide.fields[0][1];
                rubicCubeSides[mainSideColor].fields[2][0] = copySide.fields[2][2];
                rubicCubeSides[mainSideColor].fields[2][1] = copySide.fields[1][2];
                rubicCubeSides[mainSideColor].fields[2][2] = copySide.fields[0][2];
            }
        }
    }
}
