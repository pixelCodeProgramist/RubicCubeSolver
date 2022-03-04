
using RubicCube.Business;
using System;
using System.Collections.Generic;

namespace RubicCube
{
    class Program
    {
        static void Main(string[] args)
        {
            LayerByLayerMethod layerByLayerMethod = new LayerByLayerMethod();
            layerByLayerMethod.solve();
           
        }
        
        
    }
}
