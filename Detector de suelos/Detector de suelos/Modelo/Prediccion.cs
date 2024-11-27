using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Detector_de_suelos
{
    public class PredictionResult
    {
        public List<Prediccion> Predictions { get; set; }
    }

    public class Prediccion
    {
        public float Probability { get; set; }

        public string TagName { get; set; }

        public Prediccion(string tagName, float probability)
        {
            TagName = tagName;
            Probability = probability * 100;
        }
    }
}
