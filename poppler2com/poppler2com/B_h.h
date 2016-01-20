

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Wed Mar 28 14:45:32 2012
 */
/* Compiler settings for .\B.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __B_h_h__
#define __B_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IMySplashOutputDev_FWD_DEFINED__
#define __IMySplashOutputDev_FWD_DEFINED__
typedef interface IMySplashOutputDev IMySplashOutputDev;
#endif 	/* __IMySplashOutputDev_FWD_DEFINED__ */


#ifndef __IMyPDFDoc_FWD_DEFINED__
#define __IMyPDFDoc_FWD_DEFINED__
typedef interface IMyPDFDoc IMyPDFDoc;
#endif 	/* __IMyPDFDoc_FWD_DEFINED__ */


#ifndef __IMyPoppler_FWD_DEFINED__
#define __IMyPoppler_FWD_DEFINED__
typedef interface IMyPoppler IMyPoppler;
#endif 	/* __IMyPoppler_FWD_DEFINED__ */


#ifndef __MyPoppler_FWD_DEFINED__
#define __MyPoppler_FWD_DEFINED__

#ifdef __cplusplus
typedef class MyPoppler MyPoppler;
#else
typedef struct MyPoppler MyPoppler;
#endif /* __cplusplus */

#endif 	/* __MyPoppler_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IMySplashOutputDev_INTERFACE_DEFINED__
#define __IMySplashOutputDev_INTERFACE_DEFINED__

/* interface IMySplashOutputDev */
/* [unique][uuid][object] */ 


EXTERN_C const IID IID_IMySplashOutputDev;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("c1e415cd-c560-43a6-9437-d1622ff08b6c")
    IMySplashOutputDev : public IUnknown
    {
    public:
        virtual /* [propget][id] */ HRESULT STDMETHODCALLTYPE get_BitmapWidth( 
            /* [retval][out] */ int *prv) = 0;
        
        virtual /* [propget][id] */ HRESULT STDMETHODCALLTYPE get_BitmapHeight( 
            /* [retval][out] */ int *prv) = 0;
        
        virtual /* [local][propget][id] */ HRESULT STDMETHODCALLTYPE get_DataPtr( 
            /* [retval][out] */ void **ppv) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMySplashOutputDevVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMySplashOutputDev * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMySplashOutputDev * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMySplashOutputDev * This);
        
        /* [propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BitmapWidth )( 
            IMySplashOutputDev * This,
            /* [retval][out] */ int *prv);
        
        /* [propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BitmapHeight )( 
            IMySplashOutputDev * This,
            /* [retval][out] */ int *prv);
        
        /* [local][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_DataPtr )( 
            IMySplashOutputDev * This,
            /* [retval][out] */ void **ppv);
        
        END_INTERFACE
    } IMySplashOutputDevVtbl;

    interface IMySplashOutputDev
    {
        CONST_VTBL struct IMySplashOutputDevVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMySplashOutputDev_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IMySplashOutputDev_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IMySplashOutputDev_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IMySplashOutputDev_get_BitmapWidth(This,prv)	\
    ( (This)->lpVtbl -> get_BitmapWidth(This,prv) ) 

#define IMySplashOutputDev_get_BitmapHeight(This,prv)	\
    ( (This)->lpVtbl -> get_BitmapHeight(This,prv) ) 

#define IMySplashOutputDev_get_DataPtr(This,ppv)	\
    ( (This)->lpVtbl -> get_DataPtr(This,ppv) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMySplashOutputDev_INTERFACE_DEFINED__ */


#ifndef __IMyPDFDoc_INTERFACE_DEFINED__
#define __IMyPDFDoc_INTERFACE_DEFINED__

/* interface IMyPDFDoc */
/* [unique][uuid][object] */ 


EXTERN_C const IID IID_IMyPDFDoc;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("e15697b8-9a72-415c-bf50-3c9e59d58160")
    IMyPDFDoc : public IUnknown
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE isOk( 
            /* [retval][out] */ BOOL *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getNumPages( 
            /* [retval][out] */ int *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageMediaWidth( 
            int page,
            /* [retval][out] */ double *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageMediaHeight( 
            int page,
            /* [retval][out] */ double *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageCropWidth( 
            int page,
            /* [retval][out] */ double *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageCropHeight( 
            int page,
            /* [retval][out] */ double *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageRotate( 
            int page,
            /* [retval][out] */ int *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE displayPage( 
            int page,
            double hDPI,
            double vDPI,
            int rotate,
            BOOL useMediaBox,
            BOOL crop,
            BOOL printing,
            /* [retval][out] */ IMySplashOutputDev **pprv) = 0;
        
        virtual /* [local][id] */ HRESULT STDMETHODCALLTYPE savePageAs( 
            BSTR name,
            int page) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMyPDFDocVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMyPDFDoc * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMyPDFDoc * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMyPDFDoc * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *isOk )( 
            IMyPDFDoc * This,
            /* [retval][out] */ BOOL *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getNumPages )( 
            IMyPDFDoc * This,
            /* [retval][out] */ int *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getPageMediaWidth )( 
            IMyPDFDoc * This,
            int page,
            /* [retval][out] */ double *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getPageMediaHeight )( 
            IMyPDFDoc * This,
            int page,
            /* [retval][out] */ double *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getPageCropWidth )( 
            IMyPDFDoc * This,
            int page,
            /* [retval][out] */ double *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getPageCropHeight )( 
            IMyPDFDoc * This,
            int page,
            /* [retval][out] */ double *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getPageRotate )( 
            IMyPDFDoc * This,
            int page,
            /* [retval][out] */ int *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *displayPage )( 
            IMyPDFDoc * This,
            int page,
            double hDPI,
            double vDPI,
            int rotate,
            BOOL useMediaBox,
            BOOL crop,
            BOOL printing,
            /* [retval][out] */ IMySplashOutputDev **pprv);
        
        /* [local][id] */ HRESULT ( STDMETHODCALLTYPE *savePageAs )( 
            IMyPDFDoc * This,
            BSTR name,
            int page);
        
        END_INTERFACE
    } IMyPDFDocVtbl;

    interface IMyPDFDoc
    {
        CONST_VTBL struct IMyPDFDocVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMyPDFDoc_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IMyPDFDoc_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IMyPDFDoc_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IMyPDFDoc_isOk(This,prv)	\
    ( (This)->lpVtbl -> isOk(This,prv) ) 

#define IMyPDFDoc_getNumPages(This,prv)	\
    ( (This)->lpVtbl -> getNumPages(This,prv) ) 

#define IMyPDFDoc_getPageMediaWidth(This,page,prv)	\
    ( (This)->lpVtbl -> getPageMediaWidth(This,page,prv) ) 

#define IMyPDFDoc_getPageMediaHeight(This,page,prv)	\
    ( (This)->lpVtbl -> getPageMediaHeight(This,page,prv) ) 

#define IMyPDFDoc_getPageCropWidth(This,page,prv)	\
    ( (This)->lpVtbl -> getPageCropWidth(This,page,prv) ) 

#define IMyPDFDoc_getPageCropHeight(This,page,prv)	\
    ( (This)->lpVtbl -> getPageCropHeight(This,page,prv) ) 

#define IMyPDFDoc_getPageRotate(This,page,prv)	\
    ( (This)->lpVtbl -> getPageRotate(This,page,prv) ) 

#define IMyPDFDoc_displayPage(This,page,hDPI,vDPI,rotate,useMediaBox,crop,printing,pprv)	\
    ( (This)->lpVtbl -> displayPage(This,page,hDPI,vDPI,rotate,useMediaBox,crop,printing,pprv) ) 

#define IMyPDFDoc_savePageAs(This,name,page)	\
    ( (This)->lpVtbl -> savePageAs(This,name,page) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMyPDFDoc_INTERFACE_DEFINED__ */


#ifndef __IMyPoppler_INTERFACE_DEFINED__
#define __IMyPoppler_INTERFACE_DEFINED__

/* interface IMyPoppler */
/* [unique][uuid][object] */ 


EXTERN_C const IID IID_IMyPoppler;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("acb65d57-dc88-4d06-916e-295b91c384f1")
    IMyPoppler : public IUnknown
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE NewPDFDoc( 
            BSTR fileName,
            /* [retval][out] */ IMyPDFDoc **ppDoc) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE NewGlobalParams( 
            BSTR baseDir) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMyPopplerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMyPoppler * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMyPoppler * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMyPoppler * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *NewPDFDoc )( 
            IMyPoppler * This,
            BSTR fileName,
            /* [retval][out] */ IMyPDFDoc **ppDoc);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *NewGlobalParams )( 
            IMyPoppler * This,
            BSTR baseDir);
        
        END_INTERFACE
    } IMyPopplerVtbl;

    interface IMyPoppler
    {
        CONST_VTBL struct IMyPopplerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMyPoppler_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IMyPoppler_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IMyPoppler_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IMyPoppler_NewPDFDoc(This,fileName,ppDoc)	\
    ( (This)->lpVtbl -> NewPDFDoc(This,fileName,ppDoc) ) 

#define IMyPoppler_NewGlobalParams(This,baseDir)	\
    ( (This)->lpVtbl -> NewGlobalParams(This,baseDir) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMyPoppler_INTERFACE_DEFINED__ */



#ifndef __poppler2com_LIBRARY_DEFINED__
#define __poppler2com_LIBRARY_DEFINED__

/* library poppler2com */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_poppler2com;

EXTERN_C const CLSID CLSID_MyPoppler;

#ifdef __cplusplus

class DECLSPEC_UUID("57f30b72-7211-48d6-b28c-4c70e958c166")
MyPoppler;
#endif
#endif /* __poppler2com_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


