namespace TwitterFeederApp.Library.Notifications
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public class NotifierBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Generic Implementation of PropertyChanged EventHandler..
        /// </summary>
        /// <typeparam name="T">Property Information</typeparam>
        /// <param name="exp">Lambda Expression</param>
        protected void OnPropertyChanged<T>(Expression<Func<T>> exp)
        {
            MemberExpression memberExpression = (MemberExpression)exp.Body;
            string propertyName = memberExpression.Member.Name;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
