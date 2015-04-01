using Livet.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Livet.UITest
{
    public class PageViewModel: ViewModel
    {
        public void PopupAsync()
        {
            this.PopupAsync("これはMethodParameterなしのLiveCallMethodActionからの呼び出しです");
        }

        public async void PopupAsync(string str)
        {
            var md = new MessageDialog(str);
            await md.ShowAsync();
        }

        public string Text
        {
            get { return _Text; }
            set { this.SetProperty(ref this._Text, value); }
        }
        private string _Text = "初期文字列";


        public bool IsCommandEnabled
        {
            get { return _IsCommandEnabled; }
            set
            {
                if (this.SetProperty(ref this._IsCommandEnabled, value))
                {
                    ViewModelCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool _IsCommandEnabled = true;

        
        #region コマンドテスト

        public ViewModelCommand ViewModelCommand
        {
            get
            {
                return _ViewModelCommand ?? (_ViewModelCommand = new ViewModelCommand(
                    () => PopupAsync( "これはViewModelCommandからの呼び出しです" ), () => IsCommandEnabled));
            }
        }
        private ViewModelCommand _ViewModelCommand;

        #endregion
        
    }
}
