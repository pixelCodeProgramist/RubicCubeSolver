using RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage.LFormationPackage;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.CubeSolverPackage.ThirdLayerStrategyPackage.YellowCrossMiddleSquarePackage.YellowCrossMiddleSquareFactoryPackage
{
    class YellowCrossMiddleSquareFactoryProvider
    {
        public static YellowCrossMiddleSquareFactory getFactory(YellowCrossMiddleSquareFactoryMode mode)
        {
            if (YellowCrossMiddleSquareFactoryMode.L_FORMATION == mode)
                return new LFactory();
            if (YellowCrossMiddleSquareFactoryMode.STRAIGHT_FORMATION == mode)
                return new StraightFactory();
            return null;
        }

        public enum YellowCrossMiddleSquareFactoryMode
        {
            L_FORMATION, STRAIGHT_FORMATION
        }
    }
}
