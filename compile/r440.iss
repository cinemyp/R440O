;------------------------------------------------------------------------------
;
;       ������ ������������� ������� ��� Inno Setup 5.5.5
;       (c) maisvendoo, 15.04.2015
;
;------------------------------------------------------------------------------

;------------------------------------------------------------------------------
;   ���������� ��������� ���������
;------------------------------------------------------------------------------

; ��� ����������
#define   Name       "R440O"
; ������ ����������
#define   Version    "0.0.3"
; �����-�����������
#define   Publisher  "VUC ISPU"
; ���� ����� ������������
#define   URL        "http://vuc.ispu.ru/"
; ��� ������������ ������
#define   ExeName    "R440O.exe"
;------------------------------------------------------------------------------
;   ��������� ���������
;------------------------------------------------------------------------------
[Setup]

; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{32C80C0E-3CEE-47D2-84BA-983A7D531D9F}}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=.\setup
OutputBaseFileName=setup

; ���� ������
SetupIconFile=C:\Users\User\source\repos\R440O\R440O\car.ico

; ��������� ������
Compression=lzma
SolidCompression=yes


                             ;------------------------------------------------------------------------------
;   ����������� - ��������� ������, ������� ���� ��������� ��� ���������
;------------------------------------------------------------------------------
[Tasks]
; �������� ������ �� ������� �����
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

;------------------------------------------------------------------------------
;   �����, ������� ���� �������� � ����� �����������
;------------------------------------------------------------------------------
[Files]

; ����������� ����
Source: "..\R440O\bin\Release\R440O.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "..\R440O\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; ������
Source: "..\RetranslatorWPF\bin\Release\*"; DestDir: "{app}\Server"; Flags: ignoreversion recursesubdirs createallsubdirs

; .NET Framework 4.0
Source: ".\dotNetFx40_Full_x86_x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected

;------------------------------------------------------------------------------
;   ��������� �����������, ��� �� ������ ����� ������
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon

;------------------------------------------------------------------------------
;   ������ ���� ���������� �� ���������� �����
;------------------------------------------------------------------------------
[Code]
#include "dotnet.pas"

[Run]
;------------------------------------------------------------------------------
;   ������ ������� ����� �����������
;------------------------------------------------------------------------------
Filename: {tmp}\dotNetFx40_Full_x86_x64.exe; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: Microsoft Framework 4.0 is installed. Please wait...