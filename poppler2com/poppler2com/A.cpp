
#include <pdfdoc.h>
#include <splashoutputdev.h>
#include <splash/splashbitmap.h>
#include "GlobalParams.h"
#include "errorcodes.h"

#include <atlbase.h>
#include <atlcom.h>
#include <atlstr.h>

#include "B_h.h"

#define DLLEXP extern "C" __declspec(dllexport) 

LONG g_cntOb = 0;

#ifndef __RPC__deref_out
#define __RPC__deref_out
#endif

class CCntOb {
public:
	CCntOb() {
		InterlockedIncrement(&g_cntOb);
	}
	virtual ~CCntOb() {
		InterlockedDecrement(&g_cntOb);
	}
};

// -*- CMySplashOutputDev
// -*- CMySplashOutputDev

class CMySplashOutputDev : public IMySplashOutputDev, CCntOb {
public:
	ULONG refc;
	SplashOutputDev *pDev;

	CMySplashOutputDev(): refc(0), pDev(NULL) {

	}
	virtual ~CMySplashOutputDev() {
		delete pDev;
	}

	// IUnknown
public:
    virtual HRESULT STDMETHODCALLTYPE QueryInterface( 
        /* [in] */ REFIID riid,
        /* [iid_is][out] */ __RPC__deref_out void __RPC_FAR *__RPC_FAR *ppvObject)
	{
		if (ppvObject == NULL)
			return E_POINTER;
		*ppvObject = NULL;
		if (riid == IID_IUnknown || riid == IID_IMySplashOutputDev) {
			*ppvObject = static_cast<IMySplashOutputDev *>(this);
		}
		else {
			return E_NOINTERFACE;
		}
		AddRef();
		return S_OK;
	}

    virtual ULONG STDMETHODCALLTYPE AddRef( void)
	{
		return ++refc;
	}

    virtual ULONG STDMETHODCALLTYPE Release( void)
	{
		ULONG c = --refc;
		if (c == 0)
			delete this;
		return c;
	}

	// IMySplashOutputDev : public IUnknown
public:
    virtual /* [propget][id] */ HRESULT STDMETHODCALLTYPE get_BitmapWidth( 
        /* [retval][out] */ int *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		*prv = pDev->getBitmapWidth();
		return S_OK;
	}
    
    virtual /* [propget][id] */ HRESULT STDMETHODCALLTYPE get_BitmapHeight( 
        /* [retval][out] */ int *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		*prv = pDev->getBitmapHeight();
		return S_OK;
	}
    
    virtual /* [local][propget][id] */ HRESULT STDMETHODCALLTYPE get_DataPtr( 
        /* [retval][out] */ void **ppv)
	{
		if (ppv == NULL)
			return E_POINTER;
		*ppv = pDev->getBitmap()->getDataPtr();
		return S_OK;
	}

};


// -*- CMyPDFDoc
// -*- CMyPDFDoc


class CMyPDFDoc : public IMyPDFDoc, CCntOb {
public:
	ULONG refc;
	PDFDoc *pDoc;

	CMyPDFDoc(): refc(0), pDoc(NULL) {
	}
	virtual ~CMyPDFDoc() {
		delete pDoc;
	}
	// IUnknown
public:
    virtual HRESULT STDMETHODCALLTYPE QueryInterface( 
        /* [in] */ REFIID riid,
        /* [iid_is][out] */ __RPC__deref_out void __RPC_FAR *__RPC_FAR *ppvObject)
	{
		if (ppvObject == NULL)
			return E_POINTER;
		*ppvObject = NULL;
		if (riid == IID_IUnknown || riid == IID_IMyPDFDoc) {
			*ppvObject = static_cast<IMyPDFDoc *>(this);
		}
		else {
			return E_NOINTERFACE;
		}
		AddRef();
		return S_OK;
	}

    virtual ULONG STDMETHODCALLTYPE AddRef( void)
	{
		return ++refc;
	}

    virtual ULONG STDMETHODCALLTYPE Release( void)
	{
		ULONG c = --refc;
		if (c == 0)
			delete this;
		return c;
	}

	// IMyPDFDoc : public IUnknown
public:
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE isOk( 
        /* [retval][out] */ BOOL *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		*prv = pDoc->isOk() ? TRUE : FALSE;
		return S_OK;
	}
    
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE getNumPages( 
        /* [retval][out] */ int *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		*prv = pDoc->getNumPages();
		return S_OK;
	}

    virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageMediaWidth( 
        int page,
        /* [retval][out] */ double *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		if (pDoc->getPage(page) == NULL)
			return E_INVALIDARG;
		*prv = pDoc->getPageMediaWidth(page);
		return S_OK;
	}
    
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageMediaHeight( 
        int page,
        /* [retval][out] */ double *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		if (pDoc->getPage(page) == NULL)
			return E_INVALIDARG;
		*prv = pDoc->getPageMediaHeight(page);
		return S_OK;
	}
    
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageCropWidth( 
        int page,
        /* [retval][out] */ double *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		if (pDoc->getPage(page) == NULL)
			return E_INVALIDARG;
		*prv = pDoc->getPageCropWidth(page);
		return S_OK;
	}
    
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageCropHeight( 
        int page,
        /* [retval][out] */ double *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		if (pDoc->getPage(page) == NULL)
			return E_INVALIDARG;
		*prv = pDoc->getPageCropHeight(page);
		return S_OK;
	}
    
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE getPageRotate( 
        int page,
        /* [retval][out] */ int *prv)
	{
		if (prv == NULL)
			return E_POINTER;
		if (pDoc->getPage(page) == NULL)
			return E_INVALIDARG;
		*prv = pDoc->getPageRotate(page);
		return S_OK;
	}
    
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE displayPage( 
        int page,
        double hDPI,
        double vDPI,
        int rotate,
        BOOL useMediaBox,
        BOOL crop,
        BOOL printing,
        /* [retval][out] */ IMySplashOutputDev **pprv) 
	{
		if (pprv == NULL)
			return E_POINTER;
		if (pDoc->getPage(page) == NULL)
			return E_INVALIDARG;

		SplashColor backColor = {255, 255, 255, 255};
		SplashOutputDev *pDev = new SplashOutputDev(splashModeRGB8, 4, gFalse, backColor);
		double pg_w = 0, pg_h = 0;
		if (!useMediaBox) {
			pg_w = pDoc->getPageCropWidth(page);
			pg_h = pDoc->getPageCropHeight(page);
		}
		else {
			pg_w = pDoc->getPageMediaWidth(page);
			pg_h = pDoc->getPageMediaHeight(page);
		}

		pg_w *= hDPI / 72.0;
		pg_h *= vDPI / 72.0;

		if ((pDoc->getPageRotate(page) == 90) || (pDoc->getPageRotate(page) == 270)) {
			double tmp = pg_w;
			pg_w = pg_h;
			pg_h = tmp;
		}

		pDev->startDoc(pDoc->getXRef());

		pDoc->displayPageSlice(pDev, 
			page, hDPI, vDPI, 
			0,
			useMediaBox, crop ? gTrue : gFalse, printing ? gTrue : gFalse,
			0, 0, pg_w, pg_h
		);

		CMySplashOutputDev *prv = new CMySplashOutputDev();
		*pprv = prv;
		prv->AddRef();
		prv->pDev = pDev;
		return S_OK;
	}

    virtual /* [id] */ HRESULT STDMETHODCALLTYPE savePageAs( 
        BSTR name,
        int page)
	{
		GooString fpOut(static_cast<const char *>(CW2A(name)));
		return EUt::ToHR(pDoc->savePageAs(&fpOut, page));
	}

	class EUt {
	public:
		static HRESULT ToHR(int errc) {
			switch (errc) {
			case errNone: return S_OK;
			case errOpenFile: return E_FAIL;
			case errBadCatalog: return E_FAIL;
			case errDamaged: return E_FAIL;
			case errEncrypted: return HRESULT_FROM_WIN32(ERROR_FILE_ENCRYPTED);
			case errHighlightFile: return E_FAIL;
			case errBadPrinter: return E_FAIL;
			case errPrinting: return E_FAIL;
			case errPermission: return E_ACCESSDENIED;
			case errBadPageNum: return E_INVALIDARG;
			case errFileIO: return E_FAIL;
			}
			return E_UNEXPECTED;
		}
	};
};


// -*- CMyPoppler
// -*- CMyPoppler


class CMyPoppler : public IMyPoppler {
public:
	ULONG refc;

	CMyPoppler(): refc(0) {
	}
	virtual ~CMyPoppler() {
	}

	// IUnknown
public:
    virtual HRESULT STDMETHODCALLTYPE QueryInterface( 
        /* [in] */ REFIID riid,
        /* [iid_is][out] */ __RPC__deref_out void __RPC_FAR *__RPC_FAR *ppvObject)
	{
		if (ppvObject == NULL)
			return E_POINTER;
		*ppvObject = NULL;
		if (riid == IID_IUnknown || riid == IID_IMyPoppler) {
			*ppvObject = static_cast<IMyPoppler *>(this);
		}
		else {
			return E_NOINTERFACE;
		}
		AddRef();
		return S_OK;
	}

    virtual ULONG STDMETHODCALLTYPE AddRef( void)
	{
		return ++refc;
	}

    virtual ULONG STDMETHODCALLTYPE Release( void)
	{
		ULONG c = --refc;
		if (c == 0)
			delete this;
		return c;
	}

	// IMyPoppler : public IUnknown
public:
    virtual /* [id] */ HRESULT STDMETHODCALLTYPE NewPDFDoc( 
        BSTR fileName,
        /* [retval][out] */ IMyPDFDoc **ppDoc)
	{
		if (ppDoc == NULL)
			return E_POINTER;
		if (globalParams == NULL)
			globalParams = new GlobalParams();
		CMyPDFDoc *prv = new CMyPDFDoc();
		prv->AddRef();
		prv->pDoc = new PDFDoc(fileName, SysStringLen(fileName));
		*ppDoc = prv;
		return S_OK;
	}

    virtual /* [id] */ HRESULT STDMETHODCALLTYPE NewGlobalParams( 
    BSTR baseDir)
	{
		if (globalParams != NULL)
			delete globalParams;
		globalParams = new GlobalParams((baseDir != NULL) ? CW2A(baseDir) : NULL);
		return S_OK;
	}

};

DLLEXP HRESULT __stdcall GetMyPoppler(IMyPoppler **pprv) {
	if (pprv == NULL)
		return E_POINTER;

	*pprv = new CMyPoppler();
	(*pprv)->AddRef();
	return S_OK;
}

class CCf : public IClassFactory, CCntOb { 
public:
	ULONG refc;

	CCf(): refc(0) {

	}
	virtual ~CCf() {

	}

	// IUnknown
public:
    virtual HRESULT STDMETHODCALLTYPE QueryInterface( 
        /* [in] */ REFIID riid,
        /* [iid_is][out] */ __RPC__deref_out void __RPC_FAR *__RPC_FAR *ppvObject)
	{
		if (ppvObject == NULL)
			return E_POINTER;
		*ppvObject = NULL;
		if (riid == IID_IUnknown || riid == IID_IClassFactory) {
			*ppvObject = static_cast<IClassFactory *>(this);
		}
		else {
			return E_NOINTERFACE;
		}
		AddRef();
		return S_OK;
	}

    virtual ULONG STDMETHODCALLTYPE AddRef( void)
	{
		return ++refc;
	}

    virtual ULONG STDMETHODCALLTYPE Release( void)
	{
		ULONG c = --refc;
		if (c == 0)
			delete this;
		return c;
	}

	 //IClassFactory : public IUnknown
public:
    virtual /* [local] */ HRESULT STDMETHODCALLTYPE CreateInstance( 
        /* [unique][in] */ IUnknown *pUnkOuter,
        /* [in] */ REFIID riid,
        /* [iid_is][out] */ void **ppvObject)
	{
		if (pUnkOuter != NULL)
			return CLASS_E_NOAGGREGATION ;
		if (ppvObject == NULL)
			return E_POINTER;
		CMyPoppler *prv = new CMyPoppler();
		prv->AddRef();
		HRESULT hr = prv->QueryInterface(riid, ppvObject);
		prv->Release();
		return hr;
	}
    
    virtual /* [local] */ HRESULT STDMETHODCALLTYPE LockServer( 
        /* [in] */ BOOL fLock)
	{
		if (fLock)
			InterlockedIncrement(&g_cntOb);
		else
			InterlockedDecrement(&g_cntOb);
		return S_OK;
	}
};

STDAPI  DllGetClassObject(__in REFCLSID rclsid, __in REFIID riid, __deref_out LPVOID FAR* ppv)
{
	if (ppv == NULL)
		return E_POINTER;
	*ppv = NULL;
	if (rclsid == CLSID_MyPoppler) {
		CCf *prv = new CCf();
		prv->AddRef();
		HRESULT hr = prv->QueryInterface(riid, ppv);
		prv->Release();
		return hr;
	}
	return CLASS_E_CLASSNOTAVAILABLE;
}

STDAPI  DllCanUnloadNow(void)
{
	return g_cntOb == 0;
}

class RUt {
public:
	static bool WriteRegStr(HKEY rootKey, LPCTSTR subkey, LPCTSTR keyName, LPCTSTR value) {
		CRegKey rk;
		LONG res;
		CString str = subkey;
		int i = str.Find(_T('\\'));
		if (i < 0) {
			if (0 == (res = rk.Create(rootKey, subkey))) {
				if (0 == (res = rk.SetStringValue(keyName, value))) {
					return true;
				}
			}
		}
		else {
			if (0 == (res = rk.Create(rootKey, str.Left(i)))) {
				return WriteRegStr(rk, str.Mid(i +1), keyName, value);
			}
		}
		return false;
	}

	static bool DeleteRegKey(HKEY rootKey, LPCTSTR subkey, bool ifempty = false) {
		CRegKey rk(rootKey);
		LONG res = ifempty
			? rk.DeleteSubKey(subkey)
			: rk.RecurseDeleteKey(subkey)
			;
		if (res == 0 || res == ERROR_FILE_NOT_FOUND || res == ERROR_PATH_NOT_FOUND)
			return true;
		return false;
	}
};

extern HMODULE hmodule;

STDAPI DllRegisterServer(void)
{
	TCHAR tcMe[MAX_PATH] = {0};
	GetModuleFileName(hmodule, tcMe, MAX_PATH);

	bool f = true
		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("LibPoppler.MyPoppler\\CLSID"), NULL, _T("{57f30b72-7211-48d6-b28c-4c70e958c166}"))

		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("CLSID\\{57f30b72-7211-48d6-b28c-4c70e958c166}"), NULL, _T("MyPoppler"))
		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("CLSID\\{57f30b72-7211-48d6-b28c-4c70e958c166}\\InprocServer32"), NULL, tcMe)
		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("CLSID\\{57f30b72-7211-48d6-b28c-4c70e958c166}\\ProgID"), NULL, _T("LibPoppler.MyPoppler"))
		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("CLSID\\{57f30b72-7211-48d6-b28c-4c70e958c166}\\TypeLib"), NULL, _T("{787992eb-f9d7-4d23-8218-3ea98c851a3b}"))

		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("TypeLib\\{787992eb-f9d7-4d23-8218-3ea98c851a3b}\\1.0"), NULL, _T("MyPoppler typelib"))
		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("TypeLib\\{787992eb-f9d7-4d23-8218-3ea98c851a3b}\\1.0\\0\\win32"), NULL, tcMe)
		&& RUt::WriteRegStr(HKEY_CLASSES_ROOT, _T("TypeLib\\{787992eb-f9d7-4d23-8218-3ea98c851a3b}\\1.0\\FLAGS"), NULL, _T("0"))
		;

	if (f)
		return S_OK;

	return E_ACCESSDENIED;
}

STDAPI DllUnregisterServer(void)
{
	bool f = true
		&& RUt::DeleteRegKey(HKEY_CLASSES_ROOT, _T("LibPoppler.MyPoppler"))

		&& RUt::DeleteRegKey(HKEY_CLASSES_ROOT, _T("CLSID\\{57f30b72-7211-48d6-b28c-4c70e958c166}"))

		&& RUt::DeleteRegKey(HKEY_CLASSES_ROOT, _T("TypeLib\\{787992eb-f9d7-4d23-8218-3ea98c851a3b}"))
		;

	if (f)
		return S_OK;

	return E_ACCESSDENIED;
}
