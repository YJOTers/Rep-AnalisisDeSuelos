using System;
using System.Linq;
using Xamarin.Forms;
using Acr.UserDialogs;
using Plugin.Media.Abstractions;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detector_de_suelos.Controlador
{
    public class cAnalisis
    {
        private readonly MediaFile _foto;
        public string descripcionDelSuelo;
        public List<Prediccion> lista;
        public ImageSource imagen;

        public cAnalisis(MediaFile foto)
        {
            _foto = foto;
            imagen = ImageSource.FromFile(_foto.Path);
        }

        public async Task Clasificar(object sender, EventArgs e)
        {
            try
            {
                using (UserDialogs.Instance.Loading("Analizando..."))
                {
                    var stream = _foto.GetStream();
                    var memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();

                    DependencyService.Get<IClasificador>().ClassificationCompleted += Classifier_ClassificationCompleted;
                    await DependencyService.Get<IClasificador>().Classify(bytes);
                }
                UserDialogs.Instance.Toast("Analisis terminado");
            }
            catch (Exception) { }
        }

        public void Classifier_ClassificationCompleted(object sender, ClassificationEventArgs e)
        {
            var sortedList = e.Predictions.OrderByDescending(x => x.Probability);
            var arreglo = sortedList.ToList();

            if (arreglo == null)
            {
                UserDialogs.Instance.Toast("Imagen no reconocida");
                return;
            }

            descripcionDelSuelo = $"El terreno se considera {arreglo[0].TagName} con una certeza del {arreglo[0].Probability}%";
            lista = arreglo;

            var classifier = (IClasificador)sender;
            classifier.ClassificationCompleted -= Classifier_ClassificationCompleted;
        }
    }
}
