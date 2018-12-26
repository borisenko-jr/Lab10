using System;
using System.Security.Principal;
using System.Xml;

namespace CustomSecurity
{
	/// <summary>
	/// Класс CustomPrincipal, описывающий роль, наследует от класса IPrincipal
	/// </summary>
	public class CustomPrincipal :IPrincipal
	{
		private CustomIdentity _indentity;
		private string _role;
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="identity">Определяем личность пользователя пользователя.</param>
		public CustomPrincipal(CustomIdentity identity)
		{ 
			// Инициализируем личность
			this._indentity = identity;
			// Инициализируем переменную только один раз. Если роль измениться в процессе выполнения приложения, то 
			// изменения вступят в силу только после перезагрузки приложения.
			this._role = this.GetUserRole();
		}
		#region IPrincipal Members
		/// <summary>
		/// Свойство личности пользователя.
		/// </summary>
		public IIdentity Identity
		{
			get
			{
				// Реализуем свойство интерфейса.
				return this._indentity;
			}
		}
		/// <summary>
		/// Проверяет, прнадлежит ли пользователь к заданной роли.
		/// </summary>
		/// <param name="role">Роль.</param>
		/// <returns></returns>
		public bool IsInRole(string role)
		{
			// Реализуем метод интерфейса.
			return role == this._role;


			// Если необходимо реагировать на изменение роли без перезагрузки приложения, то это можно сделать так:
			//return role == this.GetUserRole();
		}

		#endregion
		/// <summary>
		/// Возвращаем  роль пользователя.
		/// </summary>
		/// <returns></returns>
		private string GetUserRole()
		{
			// Считываем и сравниваем имя пользователя.
			XmlTextReader xmlReader = new XmlTextReader("Users.xml");
			xmlReader.WhitespaceHandling = WhitespaceHandling.None;
			while(xmlReader.Read())
			{
				if(xmlReader["name"] == this._indentity.Name)
					return xmlReader["role"];				 
			}
			// Если роль пользователя не найдена, генерируем исключение.
			throw new System.Security.SecurityException(String.Format("Роль пользователя {0} не найдена в базе данных.",
				this._indentity.Name));			
		}
	}
}
