CALL "C:\Program Files (x86)\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86
nmake -f win32\Makefile.msc clean
nmake -f win32\Makefile.msc
PAUSE