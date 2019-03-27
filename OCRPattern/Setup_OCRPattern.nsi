; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

;--------------------------------

Unicode true

XPStyle on

!define APP "OCRPattern"
!define TTL "OCRPattern"
!define COM "HIRAOKA HYPERS TOOLS, Inc."
!system 'DefineAsmVer.exe bin\x86\DEBUG\${APP}.exe "!define VER ""[SVER]"" " > Ver.nsh'
!include "Ver.nsh"
!searchreplace APV ${VER} "." "_"

!system 'MySign "bin\x86\DEBUG\${APP}".exe'
!finalize 'MySign "%1"'

!define EXT ".OCR-Settei"
!define PROGID "OCR-Settei"

!define EXT2 ".OCR-Task"
!define PROGID2 "OCR-Task"

; bin\x86\DEBUG

; The name of the installer
Name "${TTL} ${VER}"

; The file to write
OutFile "Setup_${APP}_${APV}.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\${APP}"

; Registry key to check for directory (so if you install again, it will
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\${COM}\${APP}" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

!include "DotNetVer.nsh"
!include "LogicLib.nsh"

;--------------------------------

; Pages

Page license
Page directory
Page instfiles

LicenseData "GNUGPL2.txt"

;--------------------------------

!ifdef SHCNE_ASSOCCHANGED
!undef SHCNE_ASSOCCHANGED
!endif
!define SHCNE_ASSOCCHANGED 0x08000000

!ifdef SHCNF_FLUSH
!undef SHCNF_FLUSH
!endif
!define SHCNF_FLUSH        0x1000

!ifdef SHCNF_IDLIST
!undef SHCNF_IDLIST
!endif
!define SHCNF_IDLIST       0x0000

!macro UPDATEFILEASSOC
  IntOp $1 ${SHCNE_ASSOCCHANGED} | 0
  IntOp $0 ${SHCNF_IDLIST} | ${SHCNF_FLUSH}
; Using the system.dll plugin to call the SHChangeNotify Win32 API function so we
; can update the shell.
  System::Call "shell32::SHChangeNotify(i,i,i,i) (${SHCNE_ASSOCCHANGED}, $0, 0, 0)"
!macroend

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  SectionIn RO

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  ${IfNot} ${HasDotNet4.0}
    StrCpy $0 "Microsoft .NET Framework 4"
    StrCpy $1 "https://www.microsoft.com/en-us/download/details.aspx?id=17851"
    MessageBox MB_ICONEXCLAMATION|MB_YESNO "Install $0$\n$\n$1" IDNO +2
      ExecShell "open" "$1"
    Abort "Install $0"
  ${EndIf}

  ReadRegStr $0 HKCU "Software\Tesseract-OCR" "InstallDir"
  ReadRegStr $1 HKLM "Software\Tesseract-OCR" "InstallDir"
  ${If} $0 != ""
  ${AndIf} ${FileExists} "$0\*.*"
  ${ElseIf} $1 != ""
  ${AndIf} ${FileExists} "$1\*.*"
  ${Else}
    MessageBox MB_ICONEXCLAMATION|MB_OKCANCEL "Tesseract-OCR 3.01以上が必要です。$\n$\n見付かりませんでした。$\n$\nOCRを使用する為に、予め入手・インストールしておいてください。" IDOK +2
      Abort "Tesseract-OCR 3.01以上が必要です。"
  ${EndIf}

  ReadRegStr $0 HKLM "SOFTWARE\ImageMagick\Current" "BinPath"
  ${If} $0 != ""
  ${AndIf} ${FileExists} "$0\*.*"
  ${Else}
    MessageBox MB_ICONEXCLAMATION|MB_OKCANCEL "ImageMagick 6.7.6以上が必要です。$\n$\n見付かりませんでした。$\n$\n画像処理を使用する為に、予め入手・インストールしておいてください。" IDOK +2
      Abort "ImageMagick 6.7.6以上が必要です。"
  ${EndIf}

  ; Put file there
  File /r /x "*.vshost.*" "bin\x86\DEBUG\*.*"

  ; EXT
  WriteRegStr HKCR "${EXT}" "" "${PROGID}"
  WriteRegStr HKCR "${EXT}\ShellNew" "ItemName" "OCRPattern テンプレート"
  WriteRegStr HKCR "${EXT}\ShellNew" "NullFile" ""

  WriteRegStr HKCR "${PROGID}" "" "OCRPattern テンプレート"
  
  WriteRegStr HKCR "${PROGID}\DefaultIcon" "" "$INSTDIR\e.ico"
  WriteRegStr HKCR "${PROGID}\shell\open\command" "" '"$INSTDIR\OCRPattern.exe" /e "%1"'

  ; EXT2
  WriteRegStr HKCR "${EXT2}" "" "${PROGID2}"
  WriteRegStr HKCR "${EXT2}\ShellNew" "ItemName" "OCRPattern タスク"
  WriteRegStr HKCR "${EXT2}\ShellNew" "NullFile" ""

  WriteRegStr HKCR "${PROGID2}" "" "OCRPattern タスク"

  WriteRegStr HKCR "${PROGID2}\DefaultIcon" "" "$INSTDIR\t.ico"
  WriteRegStr HKCR "${PROGID2}\shell\open"         "" "開く"
  WriteRegStr HKCR "${PROGID2}\shell\open\command" "" '"$INSTDIR\OCRPattern.exe" /t "%1"'
  WriteRegStr HKCR "${PROGID2}\shell\edit"         "" "編集する"
  WriteRegStr HKCR "${PROGID2}\shell\edit\command" "" '"$INSTDIR\OCRPattern.exe" /t "%1"'
  WriteRegStr HKCR "${PROGID2}\shell\run"         "" "実行する"
  WriteRegStr HKCR "${PROGID2}\shell\run\command" "" '"$INSTDIR\OCRPattern.exe" /t "%1" /run'

  ; Update
  DetailPrint "関連付け更新中..."
  !insertmacro UPDATEFILEASSOC

  ; Write the installation path into the registry
  WriteRegStr HKLM "Software\${COM}\${APP}" "Install_Dir" "$INSTDIR"

  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "DisplayName" "${TTL}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "NoRepair" 1
  WriteUninstaller "uninstall.exe"

SectionEnd ; end the section

;--------------------------------

; Uninstaller

Section "Uninstall"
  DeleteRegKey HKCR "${EXT}"
  DeleteRegKey HKCR "${PROGID}"
  DeleteRegKey HKCR "${EXT2}"
  DeleteRegKey HKCR "${PROGID2}"

  DetailPrint "関連付け更新中..."
  !insertmacro UPDATEFILEASSOC

  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}"
  DeleteRegKey HKLM "Software\${COM}\${APP}"

  ; Remove files and uninstaller
  Delete "$INSTDIR\1.ico"
  Delete "$INSTDIR\OCRPattern.exe"
  Delete "$INSTDIR\OCRPattern.pdb"
  Delete "$INSTDIR\OCRPattern.vshost.exe"
  Delete "$INSTDIR\zxing.dll"
  Delete "$INSTDIR\zxing.pdb"
  Delete "$INSTDIR\zxing.xml"
  Delete "$INSTDIR\t.ico"

  Delete "$INSTDIR\uninstall.exe"

  ; Remove shortcuts, if any

  ; Remove directories used
  RMDir "$INSTDIR"

SectionEnd
