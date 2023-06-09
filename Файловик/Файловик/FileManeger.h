#pragma once
#include <vector>
#include "AllComands.h"
#include "FileWay.h"
using namespace std;
class FileManeger : FilePyt
{
	vector<Comand*> comands;
	void contextMenu(int viborPolzovatelya)
	{
		int input;
		for (int index = 0; index < comands.size(); index++)
			cout << index + 1 << ": " << comands[index]->GetName() << endl;
		cout << "=> ";
		cin >> input;
		path copy = "";
		if (katalog.empty() == false)
			copy = katalog[(viborPolzovatelya / 10) - 1];
		comands[input-1]->OnComand(&pyt, &copy);
		//system("pause");
		katalog.clear();
	}
	void AddComands()
	{
		comands.push_back(new CreateFolder());
		comands.push_back(new CreateFilee());
		comands.push_back(new DeleteFilee());
		comands.push_back(new CopyFolder());
		comands.push_back(new MoveFolder());
		comands.push_back(new RenameFolder());
		comands.push_back(new SizeFolder());
		comands.push_back(new Search());
		comands.push_back(new Ñancellation());
	}
	

	int UseDirectoryProverka(int max)
	{
		int input;
		while (true)
		{
			cout << "=> ";
			cin >> input;
			if (input < 1 && input > max)
			{
				if (input % 10 == 0)
					return input;
				else cout << "Òàêîãî íîìåðà ôàéëà èëè ïàïêè íå ñóùåñòâóåò" << endl;
			}
			else
				return input;
		}
	}
public:
	FileManeger()
	{
		AddComands();
	}
	FileManeger(string toFile, path pyt, string deistvie) : FilePyt(pyt)
	{
		if(deistvie == "Êîïèÿ")
			comands.push_back(new CopyFolder(toFile));
		else 
			comands.push_back(new MoveFolder(toFile));
		comands.push_back(new CreateFolder());
		comands.push_back(new Search());
		comands.push_back(new Ñancellation());
	}
	~FileManeger()
	{

	}
	void Body(bool cykle)
	{
		while (true)
		{
			//system("pause");
			system("cls");
			PrintÑontentDirectory();
			int viborPolzovatelya = UseDirectoryProverka(katalog.size());
			if (viborPolzovatelya == 0)
				EarlyDirectory();
			else if (viborPolzovatelya >= 1 && viborPolzovatelya <= katalog.size())
				NextDirectory(viborPolzovatelya);
			else
			{
				contextMenu(viborPolzovatelya);
				if (cykle == false)
					break;
			}
				
		}
	}
};
void pathTo(path pyt, string deistvie)
{
	FileManeger("Âñòàâèòü", pyt, deistvie).Body(false);
}

