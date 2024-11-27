using System;
using Xamarin.Forms;
using Detector_de_suelos.Controlador;

namespace Detector_de_suelos
{
    public partial class Inicio : ContentPage
    {
        cInicio ob;

        public Inicio()
        {
            InitializeComponent();
            ob = new cInicio();
        }

        private async void ElegirImage(object sender, EventArgs e)
        {
            await ob.ElegirImage(sender, e);
            await Navigation.PushAsync(new Analisis(ob.foto));
        }

        private async void TomarFoto(object sender, EventArgs e)
        {
            await ob.TomarFoto(sender, e);
            await Navigation.PushAsync(new Analisis(ob.foto));
        }
    }   
}
