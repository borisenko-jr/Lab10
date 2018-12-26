using System;
using System.IO;

namespace BinaryReadWrite
{
	
	class Class1
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			//Добавляем блок обработки исключений 
			try
			{
				//Создаем новый поток Chtenie  и указываем  файл для чтения - music.mp3
				FileStream Chtenie = new FileStream("music.mp3", FileMode.Open);

				//Создаем экземпляр  br класса BinaryReader и связываем  его с потоком Chtenie
				BinaryReader br = new BinaryReader(Chtenie);

				// Создаем массив типа байтов и 
				//передаем ему размер в байтах - (например1000000 ) записываемого файла
				byte[] n = br.ReadBytes(1000000);
				//Закрываем поток
				br.Close();
				//Создаем новый поток Zapis  и указываем  название файла для записи sozdanajamuzika.mp3
				FileStream Zapis = new FileStream("newmusic.mp3", FileMode.CreateNew, FileAccess.Write);
				//Создаем экземпляр  wr класса BinaryWriter и связываем  его с потоком Zapis
				BinaryWriter wr = new BinaryWriter(Zapis);
				// Можно связывать объект wr с потоком создавая его без названия:
				//BinaryWriter wr = new BinaryWriter(new FileStream("sozdanajamuzika.mp3", FileMode.CreateNew, FileAccess.Write));
				//Передаем в поток массив байтов n
				wr.Write(n);
				//Закрываем поток
				br.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
                Console.ReadKey();
			}
			
		}
	}
}
