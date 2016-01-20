CALL "C:\Program Files (x86)\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86
nmake -f makefile.vc clean
nmake -f makefile.vc nodebug=1
pause