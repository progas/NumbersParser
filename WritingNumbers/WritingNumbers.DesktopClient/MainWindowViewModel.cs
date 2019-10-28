
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WritingNumbers.DesktopClient
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string numberToConvert;
        private string conversionResult;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Number for conversion
        /// </summary>
        public string NumberToConvert
        {
            get { return numberToConvert; }
            set
            {
                numberToConvert = value;
                this.OnPropertyChanged();
                this.OnNumberToConvertChanged();
            }
        }

        /// <summary>
        /// Result of number conversion
        /// </summary>
        public string ConversionResult
        {
            get { return conversionResult; }
            set
            {
                conversionResult = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Update result with parsed words
        /// </summary>
        private async Task OnNumberToConvertChanged()
        {
            // ..ServiceReferenceManager serviceManager = new ServiceReferenceManager();

            this.ConversionResult = await ServiceReferenceManager.ConvertNumberToWritingAsync(this.numberToConvert);
        }

        /// <summary>
        /// OnOpropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
