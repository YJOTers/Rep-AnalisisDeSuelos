using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;
using Detector_de_suelos.Controlador;

namespace Detector_de_suelos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Analisis : ContentPage
    {
        cAnalisis ob;

        public Analisis(MediaFile foto)
        {
            InitializeComponent();
            ob = new cAnalisis(foto);
            Imagen.Source = ob.imagen;
        }

        private async void Clasificar(object sender, EventArgs e)
        {
            await ob.Clasificar(sender, e);
            Respuesta.Text = ob.descripcionDelSuelo;
            Lista.ItemsSource = ob.lista;
        }
    }
}