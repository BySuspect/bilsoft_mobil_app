using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bilsoft_mobil_app.CustomItems
{
    public class SimplePopupAlert : Frame
    {
        Label _title;
        Label _description;
        StackLayout _stackLayout;
        StackLayout _content;
        Button _btnCancel;
        Button _btnOk;

        bool btnResult = false;

        string title = "Title",
            description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur sagittis elit sit amet augue rutrum, nec vestibulum tortor aliquet. Vestibulum eleifend vulputate maximus. Nam vel convallis lorem. Vivamus ut hendrerit augue, in convallis lorem. Interdum et malesuada fames ac ante ipsum primis in faucibus",
            btnCancelText = "Cancel",
            btnOkText = "Ok";

        int _titleFontSize = 20,
            _descriptionFontSize = 18,
            _cancelButtonFontSize = 16,
            _okButtonFontSize = 16;

        Color _titleColor = Color.Black,
            _descriptionColor = Color.Black,
            _btnOkColor = Color.Transparent,
            _btnCancelColor = Color.Transparent;

        public SimplePopupAlert() : base()
        {
            this.hide();
            _title = new Label();
            _description = new Label();
            _stackLayout = new StackLayout();
            _content = new StackLayout();
            _btnCancel = new Button();
            _btnOk = new Button();

            //title
            _title.Text = title;
            _title.FontSize = _titleFontSize;
            _title.TextColor = _titleColor;

            //description
            _description.Text = description;
            _description.FontSize = _descriptionFontSize;
            _description.TextColor = _descriptionColor;
            _description.Margin = new Thickness(10, 0);

            //button cancel
            _btnCancel.BackgroundColor = _btnCancelColor;
            _btnCancel.Text = btnCancelText;
            _btnCancel.FontSize = _cancelButtonFontSize;
            _btnCancel.Clicked += (sender, args) =>
            {
                OnCancelClicked(args);
                this.hide();
            };

            //button accept
            _btnOk.BackgroundColor = _btnOkColor;
            _btnOk.Text = btnOkText;
            _btnOk.FontSize = _okButtonFontSize;
            _btnOk.Clicked += (sender, args) =>
            {
                OnOkClicked(args);
                this.hide();
            };

            //stackLayout
            _stackLayout.Orientation = StackOrientation.Horizontal;
            _stackLayout.HorizontalOptions = LayoutOptions.End;
            _stackLayout.Children.Add(_btnOk);
            _stackLayout.Children.Add(_btnCancel);

            //Content
            _content.Children.Add(_title);
            _content.Children.Add(_description);
            _content.Children.Add(_stackLayout);

            //Frame
            this.Margin = new Thickness(30, 0);
            this.VerticalOptions = LayoutOptions.Center;
            this.BackgroundColor = Color.White;
            this.CornerRadius = 15;
            this.Content = _content;
        }
        public event EventHandler<EventArgs> OkClicked;
        protected virtual void OnOkClicked(EventArgs e)
        {
            EventHandler<EventArgs> handler = OkClicked;
            handler?.Invoke(this, e);
        }

        public event EventHandler<EventArgs> CancelClicked;
        protected virtual void OnCancelClicked(EventArgs e)
        {
            EventHandler<EventArgs> handler = CancelClicked;
            handler?.Invoke(this, e);
        }
        public async Task<bool> showAsync(string title, string descrption, string accept, string cancel)
        {
            _title.Text = title;
            _description.Text = descrption;
            _btnOk.Text = accept;
            _btnCancel.Text = cancel;
            this.IsVisible = true;
            btnResult = false;
            _btnOk.Clicked += (s, args) => btnResult = true;

        repeat:

            if (!btnResult)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                goto repeat;
            }
            else
            {
                btnResult = false;
                return true;
            }
        }
        public async Task<bool> showAsync(string title, string descrption, string destroy)
        {
            _title.Text = title;
            _description.Text = descrption;
            _btnCancel.Text = destroy;
            _btnOk.IsVisible = false;
            this.IsVisible = true;
            btnResult = false;
            _btnCancel.Clicked += (s, args) => btnResult = true;

        repeat:

            if (!btnResult)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                goto repeat;
            }
            else
            {
                btnResult = false;
                return false;
            }
        }

        public void show(string title, string descrption, string accept, string cancel)
        {
            _title.Text = title;
            _description.Text = descrption;
            _btnOk.Text = accept;
            _btnCancel.Text = cancel;
            this.IsVisible = true;
        }
        public void show(string title, string descrption, string cancel)
        {
            _title.Text = title;
            _description.Text = descrption;
            _btnCancel.Text = cancel;
            _btnOk.IsVisible = false;
            this.IsVisible = true;
        }
        public void show(string title, string descrption)
        {
            _title.Text = title;
            _description.Text = descrption;
            _btnCancel.IsVisible = false;
            _btnOk.IsVisible = false;
            this.IsVisible = true;
        }

        public void hide()
        {
            this.IsVisible = false;
            btnResult = true;
        }
    }
}
