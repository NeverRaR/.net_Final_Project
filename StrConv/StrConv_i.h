

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 11:14:07 2038
 */
/* Compiler settings for StrConv.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.01.0622 
    protocol : all , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __StrConv_i_h__
#define __StrConv_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IUnderScoreCase_FWD_DEFINED__
#define __IUnderScoreCase_FWD_DEFINED__
typedef interface IUnderScoreCase IUnderScoreCase;

#endif 	/* __IUnderScoreCase_FWD_DEFINED__ */


#ifndef __UnderScoreCase_FWD_DEFINED__
#define __UnderScoreCase_FWD_DEFINED__

#ifdef __cplusplus
typedef class UnderScoreCase UnderScoreCase;
#else
typedef struct UnderScoreCase UnderScoreCase;
#endif /* __cplusplus */

#endif 	/* __UnderScoreCase_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "shobjidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IUnderScoreCase_INTERFACE_DEFINED__
#define __IUnderScoreCase_INTERFACE_DEFINED__

/* interface IUnderScoreCase */
/* [unique][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IUnderScoreCase;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("d5625f80-dadb-4261-81de-5f1bd3afa1cd")
    IUnderScoreCase : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Convert( 
            /* [in] */ BSTR name,
            /* [retval][out] */ BSTR *retVal) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IUnderScoreCaseVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IUnderScoreCase * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IUnderScoreCase * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IUnderScoreCase * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IUnderScoreCase * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IUnderScoreCase * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IUnderScoreCase * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IUnderScoreCase * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Convert )( 
            IUnderScoreCase * This,
            /* [in] */ BSTR name,
            /* [retval][out] */ BSTR *retVal);
        
        END_INTERFACE
    } IUnderScoreCaseVtbl;

    interface IUnderScoreCase
    {
        CONST_VTBL struct IUnderScoreCaseVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IUnderScoreCase_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IUnderScoreCase_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IUnderScoreCase_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IUnderScoreCase_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IUnderScoreCase_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IUnderScoreCase_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IUnderScoreCase_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IUnderScoreCase_Convert(This,name,retVal)	\
    ( (This)->lpVtbl -> Convert(This,name,retVal) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IUnderScoreCase_INTERFACE_DEFINED__ */



#ifndef __StrConvLib_LIBRARY_DEFINED__
#define __StrConvLib_LIBRARY_DEFINED__

/* library StrConvLib */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_StrConvLib;

EXTERN_C const CLSID CLSID_UnderScoreCase;

#ifdef __cplusplus

class DECLSPEC_UUID("3bc5c63c-ee60-4176-ada8-bcf253f5e6f9")
UnderScoreCase;
#endif
#endif /* __StrConvLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

unsigned long             __RPC_USER  BSTR_UserSize64(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal64(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal64(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree64(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


