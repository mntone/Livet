using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Livet
{
    /// <summary>
    /// 変更通知オブジェクトの基底クラスです。
    /// </summary>
#if !WINRT
    [Serializable]
#endif
    public class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティ変更通知イベントです。
        /// </summary>
#if !WINRT
       [field: NonSerialized]   
#endif
       public event PropertyChangedEventHandler PropertyChanged;

#if NET45 || WINRT
		/// <summary>
        /// プロパティが既に目的の値と一致しているかどうかを確認します。必要な場合のみ、
        /// プロパティを設定し、リスナーに通知します。
        /// </summary>
        /// <typeparam name="T">プロパティの型。</typeparam>
        /// <param name="storage">get アクセス操作子と set アクセス操作子両方を使用したプロパティへの参照。</param>
        /// <param name="value">プロパティに必要な値。</param>
        /// <param name="propertyName">リスナーに通知するために使用するプロパティの名前。
        /// この値は省略可能で、
        /// CallerMemberName をサポートするコンパイラから呼び出す場合に自動的に指定できます。</param>
        /// <returns>値が変更された場合は true、既存の値が目的の値に一致した場合は
        /// false です。</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.RaisePropertyChanged( propertyName );
            return true;
        }
#endif
        /// <summary>
        /// プロパティ変更通知イベントを発生させます。
        /// </summary>
        /// <param name="propertyExpression">() => プロパティ形式のラムダ式</param>
        /// <exception cref="NotSupportedException">() => プロパティ 以外の形式のラムダ式が指定されました。</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null) throw new ArgumentNullException("propertyExpression");

            if (!(propertyExpression.Body is MemberExpression)) throw new NotSupportedException("このメソッドでは ()=>プロパティ の形式のラムダ式以外許可されません");

            var memberExpression = (MemberExpression)propertyExpression.Body;
            RaisePropertyChanged(memberExpression.Member.Name);
        }

        /// <summary>
        /// プロパティ変更通知イベントを発生させます
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
#if NET4
        protected virtual void RaisePropertyChanged(string propertyName)
#elif NET45 || WINRT
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName="")
#endif
        {
            var threadSafeHandler = Interlocked.CompareExchange(ref PropertyChanged,null,null);
            if (threadSafeHandler != null)
            {
                var e = EventArgsFactory.GetPropertyChangedEventArgs(propertyName);
                threadSafeHandler(this, e);
            }
        }

    }

}
