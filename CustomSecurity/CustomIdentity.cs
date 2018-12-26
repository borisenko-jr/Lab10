using System;
using System.Security.Principal;
using System.Xml;

namespace CustomSecurity
{
	/// <summary>
	/// Класс CustomIdentity , описывающий "Личность", наследует от класса IIdentity
	/// </summary>
	public class CustomIdentity : IIdentity
	{
		//Вводим переменные  аутентификации
		private bool _isAuth;
		private string _name;
		private string _authType;
		private int _id;
		/// <summary>
		/// Конструктор.
		/// </summary>
		public CustomIdentity()
		{
			this._isAuth = false;
			this._authType = String.Empty;
			this._name = String.Empty;
			this._id = -1;
		}
		/// <summary>
		///Создаем конструктор, принимающий имя пользователя.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		public CustomIdentity(string userName)
		{
			this._id = this.AuthUserName(userName);
			this._name = userName;
			this._isAuth = true;
			this._authType = "Частный тип аутентификации.";
		}
		/// <summary>
		/// Определяем уникальный идентификатор пользователя. 
		/// </summary>
		public int ID
		{
			get { return this._id; }
		}
		#region IIdentity Members
		/// <summary>
		/// Проверка аутентификации пользователя.
		/// </summary>
		public bool IsAuthenticated
		{
			get
			{
				// Реализуем свойство интерфейса.
				return this._isAuth;
			}
		}
		/// <summary>
		/// Определяем имя пользователя.
		/// </summary>
		public string Name
		{
			get
			{
				// Реализуем свойство интерфейса.
				return this._name;
			}
		}
		/// <summary>
		/// Определяем тип аутентификации.
		/// </summary>
		public string AuthenticationType
		{
			get
			{
				// Реализуем свойство интерфейса.
				return this._authType;
			}
		}

		#endregion
		/// <summary>
		/// Проверяет, существует ли имя пользователя  в  базе данных - файле XML.
		/// </summary>
		/// <param name="name">Имя пользователя.</param>
		/// <returns>ID пользователя.</returns>
		private int AuthUserName(string name)
		{		
			// Считываем и сравниваем имя пользователя.
			XmlTextReader xmlReader = new XmlTextReader("Users.xml");
			xmlReader.WhitespaceHandling = WhitespaceHandling.None;
			while(xmlReader.Read())
			{
				if(xmlReader["name"] == name)
					return Int32.Parse(xmlReader["id"]);				 
			}
			// Если пользователь не найден, генерируем исключение.
			throw new System.Security.SecurityException(String.Format("Пользователь {0} не найден в базе  данных.", name));
		}
	}
}
