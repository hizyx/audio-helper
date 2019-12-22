using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AudioHelper
{
/// <summary>
/// 读取、设置程序中的配置信息的静态类。
/// </summary>
    internal static class AppConfig
    {
        private static RegistryKey registryKey = Registry.CurrentUser.CreateSubKey($"SOFTWARE\\{Application.CompanyName}\\{Application.ProductName}");

/// <summary>
/// 获取或设置播放类型。数据存放在注册表中。
/// </summary>
        public static PlayMode PlayMode
        {
            get
            {
                PlayMode pm;
                Enum.TryParse<PlayMode>(registryKey.GetValue("PlayMode", PlayMode.Following).ToString(), out pm);

                pm = Enum.IsDefined(typeof(PlayMode), pm.ToString()) ? pm : PlayMode.Following;
                return pm;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("设置一个值");
                registryKey.SetValue("PlayMode", value);
                registryKey.Flush();
            }
        }
    }

    /// <summary>
    /// 空白文件的播放方式。
    /// </summary>
    enum PlayMode
    {
        /// <summary>
        /// 跟随系统默认输出设备。
        /// </summary>
        Following = 0,

        /// <summary>
        /// 锁定一个设备。
        /// </summary>
        Locking = 1
    }
}
