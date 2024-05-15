using BClaims.Client.HttpRepository.Interfaces;
using BClaims.Shared.AttachmentUrls.Commands.AddAttachmentUrl;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen.Blazor;

namespace BClaims.Client.Components
{
    public partial class FilesInput
    {
        RadzenDataGrid<AddAttachmentUrlCommand> filesGrid;
        private bool inProgres = false;
        List<AddAttachmentUrlCommand> _selectedFiles = new();
        private AddAttachmentUrlCommand selectedFile;


        [Inject]
        IAttachmentRepository AttachmentRepo { get; set; }
                
        private async Task LoadFile(InputFileChangeEventArgs e)
        {
            try
            {
                inProgres = true;
                var buffer = new byte[e.File.Size];
                await e.File.OpenReadStream(e.File.Size).ReadAsync(buffer);
                
                _selectedFiles.Add(new AddAttachmentUrlCommand { FileName = e.File.Name, ReportId = 1, Content = buffer });  
            }
            finally
            {
                
                await filesGrid.RefreshDataAsync();
                inProgres = false;
            }
            
        }
        private async Task RemoveFile(AddAttachmentUrlCommand file)
        {
            _selectedFiles.Remove(file);
            await filesGrid.RefreshDataAsync();
        }

        private async Task UploadFiles()
        {
            foreach(var command in _selectedFiles)
            {
                await AttachmentRepo.Upload(command);
            }

        }
    }   
}
