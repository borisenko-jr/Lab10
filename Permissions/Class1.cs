using System;
using System.IO;

namespace BinaryReadWrite
{
	
	class Class1
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			//��������� ���� ��������� ���������� 
			try
			{
				//������� ����� ����� Chtenie  � ���������  ���� ��� ������ - music.mp3
				FileStream Chtenie = new FileStream("music.mp3", FileMode.Open);

				//������� ���������  br ������ BinaryReader � ���������  ��� � ������� Chtenie
				BinaryReader br = new BinaryReader(Chtenie);

				// ������� ������ ���� ������ � 
				//�������� ��� ������ � ������ - (��������1000000 ) ������������� �����
				byte[] n = br.ReadBytes(1000000);
				//��������� �����
				br.Close();
				//������� ����� ����� Zapis  � ���������  �������� ����� ��� ������ sozdanajamuzika.mp3
				FileStream Zapis = new FileStream("newmusic.mp3", FileMode.CreateNew, FileAccess.Write);
				//������� ���������  wr ������ BinaryWriter � ���������  ��� � ������� Zapis
				BinaryWriter wr = new BinaryWriter(Zapis);
				// ����� ��������� ������ wr � ������� �������� ��� ��� ��������:
				//BinaryWriter wr = new BinaryWriter(new FileStream("sozdanajamuzika.mp3", FileMode.CreateNew, FileAccess.Write));
				//�������� � ����� ������ ������ n
				wr.Write(n);
				//��������� �����
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
