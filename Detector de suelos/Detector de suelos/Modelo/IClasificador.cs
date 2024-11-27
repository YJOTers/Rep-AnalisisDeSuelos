using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detector_de_suelos
{
    public interface IClasificador
    {
        event EventHandler<ClassificationEventArgs> ClassificationCompleted;

        Task Classify(byte[] bytes);
    }

    public class ClassificationEventArgs : EventArgs
    {
        public List<Prediccion> Predictions { get; private set; }

        public ClassificationEventArgs(List<Prediccion> predictions)
        {
            Predictions = predictions;
        }
    }
}
