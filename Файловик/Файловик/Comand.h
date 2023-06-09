#pragma once
#include <iostream>
#include <filesystem>
using namespace std;
using namespace std::filesystem;

class Comand
{
protected:
	string name;
	static path FromFile;
	Comand(string name)
	{
		this->name = name;
	}
public:
	string GetName() const
	{
		return name;
	}
	void SetTo(string toPuth)
	{
		FromFile = toPuth;
	}
	virtual void OnComand(path *obj, path *viborPolzovatelya) = 0;
};
path Comand::FromFile = " ";
