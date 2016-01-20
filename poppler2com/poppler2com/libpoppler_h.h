

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* at Tue Mar 27 09:39:00 2012
 */
/* Compiler settings for B.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

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

#ifndef __libpoppler_h_h__
#define __libpoppler_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IMySplashOutputDev_FWD_DEFINED__
#define __IMySplashOutputDev_FWD_DEFINED__
typedef interface IMySplashOutputDev IMySplashOutputDev;
#endif 	/* __IMySplashOutputDev_FWD_DEFINED__ */


#ifndef __IMyPage_FWD_DEFINED__
#define __IMyPage_FWD_DEFINED__
typedef interface IMyPage IMyPage;
#endif 	/* __IMyPage_FWD_DEFINED__ */


#ifndef __IMyPDFDoc_FWD_DEFINED__
#define __IMyPDFDoc_FWD_DEFINED__
typedef interface IMyPDFDoc IMyPDFDoc;
#endif 	/* __IMyPDFDoc_FWD_DEFINED__ */


#ifndef __IMyPoppler_FWD_DEFINED__
#define __IMyPoppler_FWD_DEFINED__
typedef interface IMyPoppler IMyPoppler;
#endif 	/* __IMyPoppler_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

/* interface __MIDL_itf_B_0000 */
/* [local] */ 

typedef /* [public][public][public] */ struct __MIDL___MIDL_itf_B_0000_0001
    {
    double x1;
    double y1;
    double x2;
    double y2;
    } 	PDFRect;



extern RPC_IF_HANDLE __MIDL_itf_B_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_B_0000_v0_0_s_ifspec;

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
            /* [iid_is][out] */ void **ppvObject);
        
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
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMySplashOutputDev_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMySplashOutputDev_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMySplashOutputDev_get_BitmapWidth(This,prv)	\
    (This)->lpVtbl -> get_BitmapWidth(This,prv)

#define IMySplashOutputDev_get_BitmapHeight(This,prv)	\
    (This)->lpVtbl -> get_BitmapHeight(This,prv)

#define IMySplashOutputDev_get_DataPtr(This,ppv)	\
    (This)->lpVtbl -> get_DataPtr(This,ppv)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [propget][id] */ HRESULT STDMETHODCALLTYPE IMySplashOutputDev_get_BitmapWidth_Proxy( 
    IMySplashOutputDev * This,
    /* [retval][out] */ int *prv);


void __RPC_STUB IMySplashOutputDev_get_BitmapWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [propget][id] */ HRESULT STDMETHODCALLTYPE IMySplashOutputDev_get_BitmapHeight_Proxy( 
    IMySplashOutputDev * This,
    /* [retval][out] */ int *prv);


void __RPC_STUB IMySplashOutputDev_get_BitmapHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [local][propget][id] */ HRESULT STDMETHODCALLTYPE IMySplashOutputDev_get_DataPtr_Proxy( 
    IMySplashOutputDev * This,
    /* [retval][out] */ void **ppv);


void __RPC_STUB IMySplashOutputDev_get_DataPtr_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMySplashOutputDev_INTERFACE_DEFINED__ */


#ifndef __IMyPage_INTERFACE_DEFINED__
#define __IMyPage_INTERFACE_DEFINED__

/* interface IMyPage */
/* [unique][uuid][object] */ 


EXTERN_C const IID IID_IMyPage;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1c59e150-7717-4e7a-b2b2-7c52a8b4d8cd")
    IMyPage : public IUnknown
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getMediaBox( 
            /* [retval][out] */ PDFRect *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getCropBox( 
            /* [retval][out] */ PDFRect *prv) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE display( 
            double hDPI,
            double vDPI,
            int rotate,
            BOOL useMediaBox,
            BOOL crop,
            BOOL printing,
            /* [retval][out] */ IMySplashOutputDev **ppDev) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMyPageVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMyPage * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMyPage * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMyPage * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getMediaBox )( 
            IMyPage * This,
            /* [retval][out] */ PDFRect *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getCropBox )( 
            IMyPage * This,
            /* [retval][out] */ PDFRect *prv);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *display )( 
            IMyPage * This,
            double hDPI,
            double vDPI,
            int rotate,
            BOOL useMediaBox,
            BOOL crop,
            BOOL printing,
            /* [retval][out] */ IMySplashOutputDev **ppDev);
        
        END_INTERFACE
    } IMyPageVtbl;

    interface IMyPage
    {
        CONST_VTBL struct IMyPageVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMyPage_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMyPage_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMyPage_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMyPage_getMediaBox(This,prv)	\
    (This)->lpVtbl -> getMediaBox(This,prv)

#define IMyPage_getCropBox(This,prv)	\
    (This)->lpVtbl -> getCropBox(This,prv)

#define IMyPage_display(This,hDPI,vDPI,rotate,useMediaBox,crop,printing,ppDev)	\
    (This)->lpVtbl -> display(This,hDPI,vDPI,rotate,useMediaBox,crop,printing,ppDev)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMyPage_getMediaBox_Proxy( 
    IMyPage * This,
    /* [retval][out] */ PDFRect *prv);


void __RPC_STUB IMyPage_getMediaBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMyPage_getCropBox_Proxy( 
    IMyPage * This,
    /* [retval][out] */ PDFRect *prv);


void __RPC_STUB IMyPage_getCropBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMyPage_display_Proxy( 
    IMyPage * This,
    double hDPI,
    double vDPI,
    int rotate,
    BOOL useMediaBox,
    BOOL crop,
    BOOL printing,
    /* [retval][out] */ IMySplashOutputDev **ppDev);


void __RPC_STUB IMyPage_display_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMyPage_INTERFACE_DEFINED__ */


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
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPage( 
            int page,
            /* [retval][out] */ IMyPage **ppPage) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMyPDFDocVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMyPDFDoc * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
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
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *getPage )( 
            IMyPDFDoc * This,
            int page,
            /* [retval][out] */ IMyPage **ppPage);
        
        END_INTERFACE
    } IMyPDFDocVtbl;

    interface IMyPDFDoc
    {
        CONST_VTBL struct IMyPDFDocVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMyPDFDoc_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMyPDFDoc_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMyPDFDoc_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMyPDFDoc_isOk(This,prv)	\
    (This)->lpVtbl -> isOk(This,prv)

#define IMyPDFDoc_getNumPages(This,prv)	\
    (This)->lpVtbl -> getNumPages(This,prv)

#define IMyPDFDoc_getPage(This,page,ppPage)	\
    (This)->lpVtbl -> getPage(This,page,ppPage)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMyPDFDoc_isOk_Proxy( 
    IMyPDFDoc * This,
    /* [retval][out] */ BOOL *prv);


void __RPC_STUB IMyPDFDoc_isOk_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMyPDFDoc_getNumPages_Proxy( 
    IMyPDFDoc * This,
    /* [retval][out] */ int *prv);


void __RPC_STUB IMyPDFDoc_getNumPages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IMyPDFDoc_getPage_Proxy( 
    IMyPDFDoc * This,
    int page,
    /* [retval][out] */ IMyPage **ppPage);


void __RPC_STUB IMyPDFDoc_getPage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



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
        
    };
    
#else 	/* C style interface */

    typedef struct IMyPopplerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMyPoppler * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMyPoppler * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMyPoppler * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *NewPDFDoc )( 
            IMyPoppler * This,
            BSTR fileName,
            /* [retval][out] */ IMyPDFDoc **ppDoc);
        
        END_INTERFACE
    } IMyPopplerVtbl;

    interface IMyPoppler
    {
        CONST_VTBL struct IMyPopplerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMyPoppler_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMyPoppler_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMyPoppler_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMyPoppler_NewPDFDoc(This,fileName,ppDoc)	\
    (This)->lpVtbl -> NewPDFDoc(This,fileName,ppDoc)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMyPoppler_NewPDFDoc_Proxy( 
    IMyPoppler * This,
    BSTR fileName,
    /* [retval][out] */ IMyPDFDoc **ppDoc);


void __RPC_STUB IMyPoppler_NewPDFDoc_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMyPoppler_INTERFACE_DEFINED__ */


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


