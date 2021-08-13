using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using DataGridExtensions;

namespace EquipmentList.Controls
{
    public partial class IntegerGreatherThanFilterControl
    {
        private TextBox _textBox;

        public IntegerGreatherThanFilterControl()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _textBox = Template.FindName("textBox", this) as TextBox;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;

            //Filter = !int.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out var threshold) ? null : new ContentFilter(threshold);

            Filter = new ContentFilter(DateTime.Parse(text,
                          System.Globalization.CultureInfo.InvariantCulture));
        }

        public IContentFilter Filter
        {
            get => (IContentFilter)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }
        /// <summary>
        /// Identifies the Filter dependency property
        /// </summary>
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(IContentFilter), typeof(IntegerGreatherThanFilterControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (o, args) => ((IntegerGreatherThanFilterControl)o).Filter_Changed(args.NewValue)));

        private void Filter_Changed(object newValue)
        {
            var textBox = _textBox;
            if (textBox == null)
                return;

            textBox.Text = (newValue as ContentFilter)?.Value ?? string.Empty;
        }

        class ContentFilter : IContentFilter
        {
            readonly DateTime _threshold;

            public ContentFilter(DateTime threshold)
            {
                _threshold = threshold;
            }

            public bool IsMatch(object value)
            {
                if (value == null)
                    return false;

                //return int.TryParse(value.ToString(), out var i) && (i > _threshold);
                return true;
            }

            public string Value => _threshold.ToString(CultureInfo.CurrentCulture);
        }
    }
}
