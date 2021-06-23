#include "pch.h"

#include "CLRLogger.h"

void CLRLogger::Logger::Log(String^% s)
{
		Console::WriteLine("CLRLogger::"+s);
}
