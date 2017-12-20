using System;
using Android.App;
using Android.Content;
using Android.Util;

namespace VirtualEvent.Droid
{
    public class CustomProgress
    {
        ProgressDialog _myProgressBar;
        private readonly Context _context;
        public CustomProgress(Context context)
        {
            _context = context;
            ShowDialog();
        }

        public bool IsVisible()
        {
            if (_myProgressBar != null)
                return _myProgressBar.IsShowing;
            else
            {
                return false;
            }
        }

        private void ShowDialog()
        {
            try
            {
                if (_myProgressBar == null)
                    _myProgressBar = new ProgressDialog(_context);
                _myProgressBar.Indeterminate = true;
                _myProgressBar.SetProgressStyle(ProgressDialogStyle.Spinner);
                _myProgressBar.SetMessage("Please wait...");
                _myProgressBar.SetCancelable(false);
                _myProgressBar.Show();
            }
            catch (Exception ex){
                Log.Error("ProgressDialog Show Exception: {0}.", ex.StackTrace);
            }
        }

        public void DismissDialog()
        {
            try
            {
                if (_myProgressBar != null && _myProgressBar.IsShowing)
                    _myProgressBar.Hide();
            }
            catch (Exception ex) {
                Log.Error("ProgressDialog Dismiss Exception: {0}.", ex.StackTrace);
            }
        }
    }
}