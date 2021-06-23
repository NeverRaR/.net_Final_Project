// dllmain.h: 模块类的声明。

class CStrConvModule : public ATL::CAtlDllModuleT< CStrConvModule >
{
public :
	DECLARE_LIBID(LIBID_StrConvLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_STRCONV, "{fbd8cc6d-3fc8-4e85-9c03-9fb2e065d0ea}")
};

extern class CStrConvModule _AtlModule;
