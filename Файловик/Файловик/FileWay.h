#pragma once
#include <iostream>
#include <filesystem>
#include <vector>
using namespace std;
using namespace std::filesystem;

class FilePyt
{
protected:
	path pyt;
	vector <path> katalog;
public:
	FilePyt()
	{
		(this->pyt) = "C:\\" ;
	}
	FilePyt(path pyt)
	{
		this->pyt = pyt;
	}
	~FilePyt()
	{
		//cout << "Диструктор" << endl;
	}
	void PrintСontentDirectory()
	{
		cout << "Расположение: " << this->pyt << endl;
		int caunt = 1;
		for (const auto& entry : directory_iterator(pyt))
		{
			katalog.push_back(entry.path());
			path copyPyt = entry;
			cout << caunt << ". " << (copyPyt.filename()) << endl;
			caunt++;
		}
		cout << "	Для входа в папку введите её номер" << endl;
		cout << "	Для выхода в подпапку введите 0" << endl;
		cout << "	Для вызова контекстного меню необходимо прописать номер папки/файла и добавить 0." << endl
			<< "	На пример: 120, где 12 - номер папки, 0 - вызов контекстного меню"<<endl<<endl;
	}

	void NextDirectory(int number)
	{
		(pyt) = katalog[number - 1];
		katalog.clear();
	}
	void EarlyDirectory()
	{
		string earlyDirectory = (pyt).string();
		int size = earlyDirectory.size();
		if (pyt == "C:\\")
			cout << "Глубже корневой спуститься нельзя" << endl;
		else
		{
			while (true)
			{
				if (earlyDirectory[size] != '\\')
				{
					earlyDirectory.erase(size, 1);
					size--;
				}
				else
				{
					earlyDirectory.erase(size, 1);
					(this->pyt) = earlyDirectory;
					break;
				}
			}
			if (pyt == "C:")
				pyt = "C:\\";
		}
		katalog.clear();
	}
};

