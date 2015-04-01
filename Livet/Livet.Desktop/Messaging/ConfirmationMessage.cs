﻿using System.Windows;

namespace Livet.Messaging
{
    /// <summary>
    /// 確認相互作用メッセージを表します。
    /// </summary>
    public class ConfirmationMessage : ResponsiveInteractionMessage<bool?>
    {

        /// <summary>
        /// 表示するメッセージ・キャプション・メッセージボックスイメージ・メッセージボックスボタン・メッセージキーを指定して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="text">表示するメッセージ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="image">メッセージボックスイメージ</param>
        /// <param name="button">メッセージボックスボタン</param>
        /// <param name="defaultResult">既定の結果</param>
        /// <param name="messageKey">メッセージキー</param>
        public ConfirmationMessage(string text, string caption, MessageBoxImage image, MessageBoxButton button, MessageBoxResult defaultResult, string messageKey)
            : base(messageKey)
        {
            Text = text;
            Caption = caption;
            Image = image;
            Button = button;
            DefaultResult = defaultResult;
        }

        /// <summary>
        /// 表示するメッセージ・キャプション・メッセージボックスイメージ・メッセージボックスボタン・メッセージキーを指定して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="text">表示するメッセージ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="image">メッセージボックスイメージ</param>
        /// <param name="button">メッセージボックスボタン</param>
        /// <param name="messageKey">メッセージキー</param>
        public ConfirmationMessage(string text, string caption, MessageBoxImage image,MessageBoxButton button, string messageKey)
            : this(text, caption, image, button, MessageBoxResult.OK, messageKey) { }

        /// <summary>
        /// 表示するメッセージ・キャプション・メッセージボックスイメージ・メッセージキーを指定して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="text">表示するメッセージ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="image">メッセージボックスイメージ</param>
        /// <param name="messageKey">メッセージキー</param>
        public ConfirmationMessage(string text, string caption, MessageBoxImage image, string messageKey)
            : this(text, caption, image, MessageBoxButton.OK, messageKey) { }

        /// <summary>
        /// 表示するメッセージ・キャプション・メッセージキーを指定して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="text">表示するメッセージ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="messageKey">メッセージキー</param>
        public ConfirmationMessage(string text, string caption, string messageKey)
            : this(text, caption, MessageBoxImage.None, messageKey) { }

        /// <summary>
        /// 表示するメッセージ・キャプションを指定して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="text">表示するメッセージ</param>
        /// <param name="caption">キャプション</param>
        public ConfirmationMessage(string text, string caption)
            : this(text, caption, null) { }

        public ConfirmationMessage() { }

        /// <summary>
        /// 派生クラスでは必ずオーバーライドしてください。Freezableオブジェクトとして必要な実装です。<br/>
        /// 通常このメソッドは、自身の新しいインスタンスを返すように実装します。
        /// </summary>
        /// <returns>自身の新しいインスタンス</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new ConfirmationMessage(Text, Caption, Image, Button, DefaultResult, MessageKey);
        }

        /// <summary>
        /// 表示するメッセージを指定、または取得します。
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ConfirmationMessage), new PropertyMetadata(null));


        /// <summary>
        /// キャプションを指定、または取得します。
        /// </summary>
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(ConfirmationMessage), new PropertyMetadata(null));



        /// <summary>
        /// メッセージボックスイメージを指定、または取得します。
        /// </summary>
        public MessageBoxImage Image
        {
            get { return (MessageBoxImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(MessageBoxImage), typeof(ConfirmationMessage), new PropertyMetadata());


        /// <summary>
        /// メッセージボックスボタンを指定、または取得します。
        /// </summary>
        public MessageBoxButton Button
        {
            get { return (MessageBoxButton)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Button.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register("Button", typeof(MessageBoxButton), typeof(ConfirmationMessage), new PropertyMetadata(MessageBoxButton.OKCancel));  

        /// <summary>
        /// メッセージボックスの既定の結果を指定、または取得します。
        /// </summary>
        public MessageBoxResult DefaultResult
        {
            get { return (MessageBoxResult)GetValue(DefaultResultProperty); }
            set { SetValue(DefaultResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultResultProperty =
            DependencyProperty.Register("DefaultResult", typeof(MessageBoxResult), typeof(ConfirmationMessage), new PropertyMetadata(MessageBoxResult.OK));
    }
}