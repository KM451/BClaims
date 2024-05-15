using Microsoft.AspNetCore.Components;

namespace BClaims.Client.Components
{
    public partial class SerialNumbersInput
    {
        [Parameter]
        public List<string> SerialsList {  get; set; } = new List<string>();

        [Parameter]
        public EventCallback<List<string>> NewSerialsList { get; set; }

        string selectedValue = string.Empty;
        string newSerialNo = string.Empty;

        private async Task AddSerial()
        {
            SerialsList.Add(newSerialNo);
            newSerialNo = string.Empty;
            await NewSerialsList.InvokeAsync(SerialsList);
        }

        private async Task RemoveSerial()
        {
            SerialsList.Remove(selectedValue);
            await NewSerialsList.InvokeAsync(SerialsList);
        }
    }
}
