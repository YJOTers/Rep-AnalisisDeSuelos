using System;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.Threading.Tasks;

namespace Detector_de_suelos.Controlador
{
    public class cInicio
    {
        public MediaFile foto;

        public async Task ElegirImage(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                foto = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());
            }
            catch (Exception) { }
        }

        public async Task TomarFoto(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                foto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    Directory = "Vision",
                    Name = "Target.jpg"
                });
            }
            catch (Exception) { }
        }
    }
}
