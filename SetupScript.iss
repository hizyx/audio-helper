; �˽ű����ɸó���İ�װ�ļ���

#define MyAppName "����С����"
#define MyAppVersion "1.0"
#define MyAppPublisher "BitGlow Software"
#define MyProduct "AudioHelper"
#define MyCompany "BitGlow"
#define MyAppURL "https://www.bitglow.cn"
#define MyAppExeName "AudioHelper.exe"

[Setup]
; ע: AppId��ֵΪ������ʶ��Ӧ�ó���
; ��ҪΪ������װ����ʹ����ͬ��AppIdֵ��
; (��Ҫ�����µ� GUID�����ڲ˵��е�� "����|���� GUID"��)
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
; ������ȡ��ע�ͣ����ڷǹ���װģʽ�����У���Ϊ��ǰ�û���װ����
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
; ע��: ��Ҫ���κι���ϵͳ�ļ���ʹ�á�Flags: ignoreversion��

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Registry]
Root: HKCU32; Subkey: "SOFTWARE\{#MyCompany}"; Flags: uninsdeletekeyifempty
Root: HKCU32; Subkey: "SOFTWARE\{#MyCompany}\{#MyProduct}"; Flags: uninsdeletekey
Root: HKLM32; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "{#MyProduct}"; ValueData: "{app}\{#MyAppExeName} -startup"; Flags: uninsdeletevalue; Tasks: startuprun

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[CustomMessages]
addstartuprun=�������Ժ��Զ�����(&S)
