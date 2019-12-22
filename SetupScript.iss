; 此脚本生成该程序的安装文件。

#define MyAppName "声音小助手"
#define MyAppVersion "1.0"
#define MyAppPublisher "BitGlow Software"
#define MyProduct "AudioHelper"
#define MyCompany "BitGlow"
#define MyAppURL "https://www.bitglow.cn"
#define MyAppExeName "AudioHelper.exe"

[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (若要生成新的 GUID，可在菜单中点击 "工具|生成 GUID"。)
AppId={{0FD4D79B-6132-4EAD-AEA2-21BB9A3D4C61}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\BitGlow\AudioHelper
DisableProgramGroupPage=yes
LicenseFile=Output\License.txt
InfoAfterFile=Output\ReadMe.txt
; 以下行取消注释，以在非管理安装模式下运行（仅为当前用户安装）。
;PrivilegesRequired=lowest
OutputBaseFilename=mysetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Tasks]
Name: "startuprun"; Description: "{cm:addstartuprun}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Output\AudioHelper.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Output\audio.wav"; DestDir: "{app}"; Flags: ignoreversion
Source: "Output\ReadMe.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "Output\License.txt"; DestDir: "{app}"; Flags: ignoreversion
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Registry]
Root: HKCU32; Subkey: "SOFTWARE\{#MyCompany}"; Flags: uninsdeletekeyifempty
Root: HKCU32; Subkey: "SOFTWARE\{#MyCompany}\{#MyProduct}"; Flags: uninsdeletekey
Root: HKLM32; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "{#MyProduct}"; ValueData: "{app}\{#MyAppExeName} -startup"; Flags: uninsdeletevalue; Tasks: startuprun

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[CustomMessages]
addstartuprun=启动电脑后自动运行(&S)
