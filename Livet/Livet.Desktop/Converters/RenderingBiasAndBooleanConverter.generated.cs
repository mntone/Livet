﻿//このコードはT4 Templateによって自動生成されています。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Windows.Interop;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Annotations;
using System.Windows.Ink;
using System.Windows.Automation.Peers;
using System.Windows.Markup.Localizer;
using System.Windows.Media.Imaging;
using System.IO.Packaging;
using System.Security.RightsManagement;
using System.Windows.Threading;
using System.Windows.Media.Effects;
using System.Windows.Shell;
using System.Security.Permissions;
using System.Windows.Annotations.Storage;
using System.Diagnostics;

namespace Livet.Converters
{
	/// <summary>
    /// RenderingBias列挙体とbool値の相互変換を行うIValueConverterです。
    /// </summary>
    public class RenderingBiasAndBooleanConverter : IValueConverter
    {
        //VM→View
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool)) throw new ArgumentException();

            if ((bool)value)
            {
                if (_isConvertWhenTrueSet)
                {
                    return ConvertWhenTrue;
                }
            }
            else
            {
                if (_isConvertWhenFalseSet)
                {
                    return ConvertWhenFalse;
                }
            }

            return DependencyProperty.UnsetValue;
        }

        private bool _isConvertWhenTrueSet;
        private RenderingBias _convertWhenTrue;
		/// <summary>
        /// ソース値がTrueの際にどのRenderingBias列挙体メンバーに変換するかを指定、または取得します。
        /// </summary>
        public RenderingBias ConvertWhenTrue
        {
            get
            {
                return _convertWhenTrue;
            }
            set
            {
                _convertWhenTrue = value;
                _isConvertWhenTrueSet = true;
            }
        }

        private bool _isConvertWhenFalseSet;
        private RenderingBias _convertWhenFalse;
		/// <summary>
        /// ソース値がFalseの際にどのRenderingBias列挙体メンバーに変換するかを指定、または取得します。
        /// </summary>
        public RenderingBias ConvertWhenFalse
        {
            get
            {
                return _convertWhenFalse;
            }
            set
            {
                _convertWhenFalse = value;
                _isConvertWhenFalseSet = true;
            }
        }

        //View→VM
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is RenderingBias)) throw new ArgumentException();

            var enumValue = (RenderingBias)value;

			switch(enumValue.ToString())
			{
				case "Performance":
					if (_isConvertBackWhenPerformanceSet)
					{
						return ConvertBackWhenPerformance;
					}
					break;
				case "Quality":
					if (_isConvertBackWhenQualitySet)
					{
						return ConvertBackWhenQuality;
					}
					break;
				default:
					throw new ArgumentException();
			}

            if (_isConvertBackDefaultBooleanValueSet)
            {
                return ConvertBackDefaultBooleanValue;
            }

            return DependencyProperty.UnsetValue;
        }

        private bool _isConvertBackDefaultBooleanValueSet;
        private bool _convertBackDefaultBooleanValue;
		/// <summary>
        /// RenderingBiasの値をbool値に変換する際のデフォルト値を指定、または取得します。
        /// </summary>
        public bool ConvertBackDefaultBooleanValue
        {
            get
            {
                return _convertBackDefaultBooleanValue;
            }
            set
            {
                _convertBackDefaultBooleanValue = value;
				_isConvertBackDefaultBooleanValueSet = true;
            }
        }

        private bool _isConvertBackWhenPerformanceSet;
        private bool _convertBackWhenPerformance;
		/// <summary>
        /// RenderingBiasの値がPerformanceの際True/Falseいずれに変換するのかを指定、または取得します。<br/>
        /// この値が設定されておらず、ConvertBackDefaultBooleanValueが設定されている場合はConvertBackDefaultBooleanValueに従います。
        /// </summary>
        public bool ConvertBackWhenPerformance
        {
            get
            {
                return _convertBackWhenPerformance;
            }
            set
            {
                _convertBackWhenPerformance = value;
                _isConvertBackWhenPerformanceSet = true;
            }
        }
        private bool _isConvertBackWhenQualitySet;
        private bool _convertBackWhenQuality;
		/// <summary>
        /// RenderingBiasの値がQualityの際True/Falseいずれに変換するのかを指定、または取得します。<br/>
        /// この値が設定されておらず、ConvertBackDefaultBooleanValueが設定されている場合はConvertBackDefaultBooleanValueに従います。
        /// </summary>
        public bool ConvertBackWhenQuality
        {
            get
            {
                return _convertBackWhenQuality;
            }
            set
            {
                _convertBackWhenQuality = value;
                _isConvertBackWhenQualitySet = true;
            }
        }
    }
}