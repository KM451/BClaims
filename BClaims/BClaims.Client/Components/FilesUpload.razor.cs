using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace BClaims.Client.Components
{
    public partial class FilesUpload
    {
        RadzenUpload upload;


        
        void OnChange(UploadChangeEventArgs args, string name)
        {
        }

        void OnProgress(UploadProgressArgs args, string name)
        {
        }

        async Task OnUpload(MouseEventArgs args)
        {
            await upload.Upload();
        }


    }
}
