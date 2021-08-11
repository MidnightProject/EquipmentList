using System.Windows;
using DataGridExtensions;
using System;
using System.Windows.Input;
using TomsToolbox.Wpf;

namespace EquipmentList.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy FilterWithPopupControl.xaml
    /// </summary>
    public partial class FilterWithPopupControl 
    {
        public FilterWithPopupControl()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        /// <summary>
        /// Identifies the Minimum dependency property
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(FilterWithPopupControl)
                , new FrameworkPropertyMetadata("Enter the limits:", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public DateTime Minimum
        {
            get => (DateTime)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }
        /// <summary>
        /// Identifies the Minimum dependency property
        /// </summary>
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(DateTime), typeof(FilterWithPopupControl)
                , new FrameworkPropertyMetadata(DateTime.Today, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (sender, e) => ((FilterWithPopupControl)sender).Range_Changed()));

        public DateTime Maximum
        {
            get => (DateTime)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        /// <summary>
        /// Identifies the Maximum dependency property
        /// </summary>
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(DateTime), typeof(FilterWithPopupControl)
                , new FrameworkPropertyMetadata(DateTime.Today, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (sender, e) => ((FilterWithPopupControl)sender).Range_Changed()));


        public bool IsPopupVisible
        {
            get => (bool)GetValue(IsPopupVisibleProperty);
            set => SetValue(IsPopupVisibleProperty, value);
        }
        /// <summary>
        /// Identifies the IsPopupVisible dependency property
        /// </summary>
        public static readonly DependencyProperty IsPopupVisibleProperty =
            DependencyProperty.Register("IsPopupVisible", typeof(bool), typeof(FilterWithPopupControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        private void Range_Changed()
        {
            Filter = Maximum > Minimum ? new ContentFilter(Minimum, Maximum) : null;
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
            DependencyProperty.Register("Filter", typeof(IContentFilter), typeof(FilterWithPopupControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (sender, e) => ((FilterWithPopupControl)sender).Filter_Changed()));


        private void Filter_Changed()
        {
            if (!(Filter is ContentFilter filter))
                return;

            Minimum = filter.Min;
            Maximum = filter.Max;
        }

        public class ContentFilter : IContentFilter
        {
            public ContentFilter(DateTime min, DateTime max)
            {
                Min = min;
                Max = max;
            }

            public DateTime Min { get; }

            public DateTime Max { get; }

            public bool IsMatch(object value)
            {
                if (value == null)
                {
                    return false;
                }
                    
                if (!DateTime.TryParse(value.ToString(), out var date))
                {
                    return false;
                }

                return (date >= Min) && (date <= Max);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filter = null;
        }
    }
}
