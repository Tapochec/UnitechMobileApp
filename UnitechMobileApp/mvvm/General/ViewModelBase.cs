using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace UnitechMobileApp.mvvm.General
{
    /// <summary>
    /// Содержит реализацию <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
		/// <summary>
		/// Устанавливает значение поля
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="property">Поле, в котрое заносится значениею</param>
		/// <param name="value">Новое значение поля.</param>
		/// <param name="propertyName">Название поля.</param>
		/// <param name="onChanged">Метод, который будет вызван при изменении значения поля.</param>
		/// <returns></returns>
		protected virtual bool SetProperty<T>(
			ref T property, T value,
			[CallerMemberName]string propertyName = "",
			Action onChanged = null)
		{
			// Если значение не изменилось
			if (EqualityComparer<T>.Default.Equals(property, value))
				return false;

			property = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
