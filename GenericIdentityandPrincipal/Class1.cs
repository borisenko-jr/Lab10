using System;
using System.Threading;
using System.Security.Principal;

namespace GenericIdentityandPrincipal
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{		
		[STAThread]
		static void Main(string[] args)
		{
			// Создаем и прикрепляем объект роли.
			CreateGenericPrincipalAndIdentity(Roles.PowerUser);
			// Вводим один из способов осуществления проверки роли.
			if(Thread.CurrentPrincipal.IsInRole("User"))
			{
				Console.WriteLine("У вас нет прав для работы с этим приложением");
			}
			else if(Thread.CurrentPrincipal.IsInRole("PowerUser"))
			{
				Console.WriteLine("Добро пожаловать, {0}. Ваша роль - Продвинутый пользователь", Thread.CurrentPrincipal.Identity.Name);
			}
			else // Administrator
			{
				Console.WriteLine("Добро пожаловать, {0}. Ваша роль - Администратор", Thread.CurrentPrincipal.Identity.Name);
			}
            Console.ReadKey();
            Console.ReadKey();
        }
	
		// Создание объектов личности и роли 
		
		static void CreateGenericPrincipalAndIdentity(Roles role)
		{
			// Создаем и инициализируем именем пользователя 
			// объект класса GenericIdentity
			GenericIdentity identity = new GenericIdentity("Username");
			// Создаем строковый массив, содержащий роли пользователя.
			string[] userRoles = new string[]{role.ToString()};
			//  Создаем объект класса GenericPrincipal и инициализируем его 
			// объектом класса GenericIdentity identity и строковым массивом с ролями.
			GenericPrincipal principal = new GenericPrincipal(identity, userRoles);
			// Прикрепляем объект роли к текущему процессу. 
			// Этот и все дочерние процессы будут иметь данную роль.
			Thread.CurrentPrincipal = principal;
		}
		enum Roles
		{
			Administrator, 
			PowerUser, 
			User
		}
	}
}
