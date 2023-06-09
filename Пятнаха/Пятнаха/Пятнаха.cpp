
#include <iostream>
#include <windows.h>
#include <chrono>
#include <conio.h>

using namespace std;
int viborPolzovatelya;
const int sizePole9 = 9;
const int sizePole16 = 16;

bool proverkaWin(string* pole, int regim)
{
	bool win = true;
	if (regim == 1)
	{
		string* yslovieWin=new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", " " };
		for (int i = 0; i < 9; i++)
		{
			if ((pole[i]) == (yslovieWin[i]));
			else return false;
		}
	}
	else
	{
		string yslovieWin[16] = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", " " };
		for (int i = 0; i < 16; i++)
		{
			if (pole[i] == yslovieWin[i]);
			else return false;
		}
	}
	return win;
}
void pokazPolya(string* pole, int regim)
{
	int schetchik = 0;
	if (regim == 1)
	{
		for (int i = 0; i < 9; i++)
		{
			schetchik++;
			cout << pole[i] << " ";
			if (schetchik == 3)
			{
				schetchik = 0;
				cout << endl;
			}
		}
	}
	else
	{
		for (int i = 0; i < 16; i++)
		{
			schetchik++;
			cout << pole[i] << " ";
			if (pole[i].length() == 1)
				cout << " ";
			if (schetchik == 4)
			{
				schetchik = 0;
				cout << endl;
			}
		}
	}
}
void down_move(string* pole, int regim)
{
	if (regim == 1)
	{
		for (int i = 0; i < sizePole9; i++)
		{
			if (pole[i] == " ")
			{
				if (i - 3 >= 0)
				{
					pole[i] = pole[i - 3];
					pole[i - 3] = { " " };
					break;
					
				}
				else
				{
					pole[i] = pole[i + 6];
					pole[i + 6] = {" "};
					break;
				}
			}
		}
	}
	else
	{
		for (int i = 0; i < sizePole16; i++)
		{
			if (pole[i] == " ")
			{
				if (i - 4 >= 0)
				{
					pole[i] = pole[i - 4];
					pole[i - 4] = { " " };
					break;

				}
				else
				{
					pole[i] = pole[i + 12];
					pole[i + 12] = { " " };
					break;
				}
			}
		}
	}

}
void up_move(string* pole, int regim)
{
	if (regim == 1)
	{
		for (int i = 0; i < sizePole9; i++)
		{
			if (pole[i] == " ")
			{
				if (i + 3 < 9)
				{
					pole[i] = pole[i + 3];
					pole[i + 3] = {" "};
					break;

				}
				else
				{
					pole[i] = pole[i - 6];
					pole[i - 6] = {" "};
					break;
				}
			}
		}
	}
	else
	{
		for (int i = 0; i < sizePole16; i++)
		{
			if (pole[i] == " ")
			{
				if (i + 4 < 16)
				{
					pole[i] = pole[i + 4];
					pole[i + 4] = { " " };
					break;

				}
				else
				{
					pole[i] = pole[i - 12];
					pole[i - 12] = { " " };
					break;
				}
			}
		}
	}
}
void left_move(string* pole, int regim)
{
	if (regim == 1)
	{
		for (int i = 0; i < sizePole9; i++)
		{
			if (pole[i] == " ")
			{
				
					if (3>(i % 3)+1)
					{
						pole[i] = pole[i + 1];
						pole[i + 1] = { " " };
						break;
					}
					else
					{
						pole[i] = pole[i - 2];
						pole[i - 2] = { " " };
						break;
					}
				
			}
		}
	}
	else
	{
		for (int i = 0; i < sizePole16; i++)
		{
			if (pole[i] == " ")
			{
					if (4 > (i % 4) + 1)
					{
						pole[i] = pole[i + 1];
						pole[i + 1] = { " " };
						break;
					}
					else
					{
						pole[i] = pole[i - 3];
						pole[i - 3] = { " " };
						break;
					}
				
			}
		}
	}
}
void right_move(string* pole, int regim)
{
	if (regim == 1)
	{
		for (int i = 0; i < sizePole9; i++)
		{
			if (pole[i] == " ")
			{
					if (0 < (i % 3))
					{
						pole[i] = pole[i - 1];
						pole[i - 1] = { " " };
						break;
					}
					else
					{
						pole[i] = pole[i + 2];
						pole[i + 2] = { " " };
						break;
					}
			}
		}
	}
	else
	{
		for (int i = 0; i < sizePole16; i++)
		{
			if (pole[i] == " ")
			{
				
					if (4 >= 4 - (i % 4) + 1)
					{
						pole[i] = pole[i - 1];
						pole[i - 1] = { " " };
						break;
					}
					else
					{
						pole[i] = pole[i + 3];
						pole[i + 3] = { " " };
						break;
					}
			}
		}
	}
}
void get_direction(string* pole, int regim)
{
	int move = static_cast<int> (_getch()); // UP = 72, DOWN = 80, RIGHT = 77, LEFT = 75
	switch(move)
	{
	case 72:
	{
		up_move(pole, regim); break;
	}
	case 80:
	{
		down_move(pole, regim); break;
	}
	case 77:
	{
		right_move(pole, regim); break;
	}
	case 75:
	{
		left_move(pole, regim); break;
	}
	default:
	{
		get_direction(pole, regim);
	}
	}
}
void gameCore(string* pole, int regim)
{
	int deystviya = 0;
	int time = clock();
	do
	{
		system("cls");
		pokazPolya(pole, regim);
		get_direction(pole, regim);
		deystviya++;
	} while (proverkaWin(pole, regim) == false);
	time = clock()-time;
	system("cls");
	cout << "Игра пройдена" << endl
		<< "Ходов сделано: " << deystviya << "." << endl
		<< "Времени со старта игры прошло: " << (time/1000)/60 << ":"<< (time / 1000);
}

int menu()
{
	int regim = 0;
	int sozdaniePolya = 0;
	cout << "Режим игры" << endl
		<< "1) 8(3x3)" << endl
		<< "2) 15(4x4)" << endl;
	cin >> regim;
	cout << "Составитель поля" << endl
		<< "1) Ручной" << endl
		<< "2) Авто" << endl;
	cin >> sozdaniePolya;
	viborPolzovatelya = regim * sozdaniePolya;
	if (regim == 1 && sozdaniePolya == 1)
		return 1;
	else if (regim == 2 && sozdaniePolya == 1)
		return 2;
	else if (regim == 1 && sozdaniePolya == 2)
		return 3;
	else if (regim == 2 && sozdaniePolya == 2)
		return 4;
}
void avtoSostavitelPolya9()
{
	int regim = 1;
	string* pole = new string[sizePole9]{ "1", "2", "3", "4", "5", "6", "7", "8", " " };
	for (int i = 0; i <= sizePole9; i++)
	{
		swap(pole[sizePole9 - 1], pole[rand() % sizePole9]);
	}
	gameCore(pole, regim);
}
void avtoSostavitelPolya16()
{
	int regim = 2;
	string* pole = new string[sizePole16]{ "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", " " };
	for (int i = 0; i <= sizePole16; i++)
	{
		swap(pole[sizePole16 - 1], pole[rand() % sizePole16]);
	}
	gameCore(pole, regim);
}
void sostavitelPolya9()
{
	int regim = 1;
	int schetchik = 0;
	string* pole = new string[sizePole9];
	string cifra;
	for (int i = 0; i < 8; i++)
	{
		bool yslovie = false;
		do
		{
			yslovie = false;
			cout << "цифра" << endl;
			cin >> cifra;
			for (int j = 0; j < i; j++)
			{
				if (pole[j] == cifra)
				{
					yslovie = true;
					cout << "Такая цифра уже есть" << endl;
				}
			}
		} while (yslovie == true);
		system("cls");
		pole[i] = cifra;
		for (int j = 0; j <= i; j++)
		{
			schetchik++;
			cout << pole[j] << " ";
			if (schetchik == 3)
			{
				schetchik = 0;
				cout << endl;
			}
		}
		schetchik = 0;
		cout << endl;
		pole[sizePole9 - 1] = { " " };
	}
	gameCore(pole, regim);
}
void sostavitelPolya16()
{
	int regim = 2;
	int schetchik = 0;
	string* pole = new string[sizePole16];
	string cifra;
	for (int i = 0; i < 15; i++)
	{
		bool yslovie = false;
		do
		{
			yslovie = false;
			cout << "цифра" << endl;
			cin >> cifra;
			for (int j = 0; j < i; j++)
			{
				if (pole[j] == cifra)
				{
					yslovie = true;
					cout << "Такая цифра уже есть" << endl;
				}
			}
		} while (yslovie == true);
		system("cls");
		pole[i] = cifra;
		for (int j = 0; j <= i; j++)
		{
			schetchik++;
			cout << pole[j] << " ";
			if (schetchik == 4)
			{
				schetchik = 0;
				cout << endl;
			}
		}
		schetchik = 0;
		cout << endl;
		pole[sizePole16 - 1] = { " " };
	}
	gameCore(pole, regim);
}

int main()
{
	srand(time(0));
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	do
	{
		int regim = menu();
		system("cls");
		if (regim == 1)
			sostavitelPolya9();
		else if (regim == 2)
			sostavitelPolya16();
		else if (regim == 3)
			avtoSostavitelPolya9();
		else
			avtoSostavitelPolya16();
		cout << endl << endl;
		cout << "Начать новую игру?" << endl
			<< "1) Да" << endl
			<< "2) Нет" << endl;
		cin >> viborPolzovatelya;
		system("cls");
	} while (viborPolzovatelya==1);
}