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
		//cout << "����������" << endl;
	}
	void Print�ontentDirectory()
	{
		cout << "������������: " << this->pyt << endl;
		int caunt = 1;
		for (const auto& entry : directory_iterator(pyt))
		{
			katalog.push_back(entry.path());
			path copyPyt = entry;
			cout << caunt << ". " << (copyPyt.filename()) << endl;
			caunt++;
		}
		cout << "	��� ����� � ����� ������� � �����" << endl;
		cout << "	��� ������ � �������� ������� 0" << endl;
		cout << "	��� ������ ������������ ���� ���������� ��������� ����� �����/����� � �������� 0." << endl
			<< "	�� ������: 120, ��� 12 - ����� �����, 0 - ����� ������������ ����"<<endl<<endl;
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
			cout << "������ �������� ���������� ������" << endl;
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

