CALL "C:\Program Files (x86)\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86
"C:\Program Files (x86)\CMake 2.8\bin\cmake.exe" . .
MSBUILD libpng.sln
PAUSE