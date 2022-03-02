using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.SecondLayerStrategyPackage.SecondLayerFactoryPackage
{
    class SecondLayerFactoryProvider
    {
        public static SecondLayerFactory getFactory(SecondLayerFactoryMode mode)
        {
            if (SecondLayerFactoryMode.Left == mode) 
                return new LeftFactory();
            if (SecondLayerFactoryMode.Right == mode)
                return new RightFactory();
            return null;
        }

        public enum SecondLayerFactoryMode
        {
            Right, Left
        }


    }

}
