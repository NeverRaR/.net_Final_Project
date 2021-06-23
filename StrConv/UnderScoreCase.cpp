// UnderScoreCase.cpp: CUnderScoreCase 的实现

#include "pch.h"
#include "UnderScoreCase.h"
#include <atlstr.h>

// CUnderScoreCase





STDMETHODIMP CUnderScoreCase::Convert(BSTR name, BSTR* retVal)
{
	CString nameStr(name);
	int len = nameStr.GetLength();
	int i;
	CString retStr;
	retStr.Empty();
	;	for (i = 0; i < len; ++i) {
		if (iswupper(nameStr[i])&&i>0) {
			retStr.AppendChar('_');
		}
		retStr.AppendChar(towlower(nameStr[i]));
	}
	*retVal = retStr.AllocSysString();

	return S_OK;
}
