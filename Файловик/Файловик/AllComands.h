#pragma once
#include "FileManeger.h"
#include <iostream>
#include <filesystem>
#include <fstream>
#include "Comand.h"
#include "io.h"
#include <fileapi.h>
#include <windows.h>

using namespace std;
using namespace std::filesystem;

void pathTo(path pyt, string deistvie);

class CreateFolder : public Comand
{
public:
	CreateFolder() : Comand("������� �����") {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		string newPath = "\\";
		string namePath;
		cout << "�������� �����: " << endl
			<< "	������� �������� �����" << endl;
		cin >> namePath;
		newPath += namePath;
		*obj += newPath;
		create_directory(*obj);
	}
};

class CreateFilee : public Comand
{
public:
	CreateFilee() :Comand("������� ����") {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		string text;
		string pyth = (*obj).string();
		pyth += "\\";
		cout << "�������� �����:" << endl;
		cout << "	������� �������� �����" << endl;
		cin >> text;
		text += ".txt";
		pyth += text;
		ofstream file(pyth);
		if (file.is_open())
		{
			cout << "�������� � ����:" << endl;
			cin >> text;
			file << text;
			file.close();
		}
		else
			cout << "���� �� ������" << endl;
	}
};

class DeleteFilee : public Comand
{
public:
	DeleteFilee() : Comand("�������") {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		if (exists(*viborPolzovatelya))
			remove_all(*viborPolzovatelya);
		else
			remove(*viborPolzovatelya);
	}
};

class CopyFolder : public Comand
{
public:
	CopyFolder() : Comand("����������") {}
	CopyFolder(string to) : Comand(to) {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		if (FromFile == " ")
		{
			FromFile = *viborPolzovatelya;
			pathTo(*obj, "�����");
		}
		else
		{
			if (exists(FromFile))
			{
				*obj += "\\";
				*obj += FromFile.filename();
				if (*obj == FromFile)
				{
					string pyt = (*obj).string();
					pyt.erase(pyt.size(), 4);
					pyt += "Copy.txt";
					*obj = pyt;
				}
				copy(FromFile, *obj);
			}
			else
			{
				*obj += "\\";
				*obj += FromFile.filename();
				if (*obj == FromFile)
					*obj += "Copy";
				copy(FromFile, *obj, copy_options::recursive);
			}
			
			FromFile = " ";
		}
	}
};

class MoveFolder : public Comand
{
public:
	MoveFolder() : Comand("���������") {}
	MoveFolder(string to) : Comand(to) {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		if (FromFile == " ")
		{
			FromFile = *viborPolzovatelya;
			pathTo(*obj, "�����������");
		}
		else
		{
			if (exists(FromFile))
			{
				*obj += "\\";
				*obj += FromFile.filename();
				if (*obj == FromFile)
				{
					string pyt = (*obj).string();
					pyt.erase(pyt.size(), 4);
					pyt += "Copy.txt";
					*obj = pyt;
				}
				copy(FromFile, *obj);
			}
			else
			{
				*obj += "\\";
				*obj += FromFile.filename();
				if (*obj == FromFile)
					*obj += "Copy";
				copy(FromFile, *obj, copy_options::recursive);
			}
			if (exists(FromFile))
				remove_all(FromFile);
			else
				remove(FromFile);
			FromFile = " ";
		}
	}

};


class RenameFolder : public Comand
{
public:
	RenameFolder() :Comand("�������������") {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		string newPath = (*viborPolzovatelya).string();;
		string newName;
		cout << "����� ��������" << endl;
		cin >> newName;
		newName += ".txt";
		int size = newPath.size();
		while (true)
		{
			if (newPath[size] != '\\')
			{
				newPath.erase(size, 1);
				size--;
			}
			else
			{
				newPath += newName;
				break;
			}

		}
		rename(*viborPolzovatelya, newPath);
	}
};

class SizeFolder : public Comand
{
public:
	SizeFolder() : Comand("������") {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		cout << file_size(*viborPolzovatelya) << " ������ " << endl;
		system("pause");
	}
};

class Search : public Comand
{
public:
	Search() : Comand("�����") {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{
		path poisk1;
		cout << "������: " << endl;
		cin >> poisk1;
		wstring poisk = poisk1.generic_wstring();
		FindFile(*obj, poisk);
		//*obj = FromFile;
		cout << endl;
		system("pause");
	}
	void FindFile(const wstring& directory, wstring poisk)
	{
		wstring tmp = directory + L"\\*";
		WIN32_FIND_DATAW file;
		HANDLE search_handle = FindFirstFileW(tmp.c_str(), &file);
		if (search_handle != INVALID_HANDLE_VALUE)
		{
			vector<wstring> directories;
			do
			{
				if (file.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
				{
					if ((!lstrcmpW(file.cFileName, L".")) || (!lstrcmpW(file.cFileName, L"..")))
						continue;
				}
				tmp = directory + L"\\" + wstring(file.cFileName);
				//wcout << tmp << endl;
				if (wstring(file.cFileName) == poisk)
				{
					wcout << tmp << endl;
					FromFile == tmp;
				}
					
				if (file.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
					directories.push_back(tmp);
			} while (FindNextFileW(search_handle, &file));
			FindClose(search_handle);
			for (vector<wstring>::iterator iter = directories.begin(), end = directories.end(); iter != end; ++iter)
				FindFile(*iter, poisk);
		}
	}
};

class �ancellation : public Comand
{
public:
	�ancellation() : Comand("������") {}
	void OnComand(path* obj, path* viborPolzovatelya) override
	{

	}
};







