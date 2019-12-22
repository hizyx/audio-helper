using System;
using System.Windows.Forms;

namespace AudioHelper
{
    class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 把消息筛选器加入消息泵并设置相关事件。
            HotKey.HotKeyMessageFilter hotKeyMessageFilter = new HotKey.HotKeyMessageFilter();
            Application.AddMessageFilter(hotKeyMessageFilter);
            hotKeyMessageFilter.HotKeyDown += (x, y) =>
            {
                if (MessageBox.Show("你真的要退出吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            };

            // 注册热键，失败直接退出。
            if (!HotKey.NativeMethods.RegisterHotKey(IntPtr.Zero, 1, HotKey.KeyModifiers.Control | HotKey.KeyModifiers.Shift | HotKey.KeyModifiers.Alt | HotKey.KeyModifiers.NoRepeat, HotKey.VirtualKeys.OEM2))
            {
                MessageBox.Show("注册退出热键失败，程序将会退出！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 读取配置、加载声音文件。
            PlayMode playMode = AppConfig.PlayMode;
            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer($"{Application.StartupPath}\\audio.wav");
            try
            {
                soundPlayer.Load();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.Fail("加载声音文件发生了错误！", e.Message);
            }

            // 判断命令行，决定是否发出提示信息。
            if (!(Environment.CommandLine.ToLower().Contains("-startup") || Environment.CommandLine.ToLower().Contains("auto")))
            {
                switch (MessageBox.Show("本程序用于解决笔记本扬声器/耳机等设备停止输出后自动睡眠的问题。\n点击 “是” 跟随默认声音设备； 点击 “否” 锁定当前默认音频输出设备。\n退出请按下 Shift +Ctrl + Alt + /。\n程序作者： 好奇的 01\n网站： https://www.bitglow.cn\n程序完全免费并开源： https://github.com/hizyx/Audio-Helper 。\n祝你使用愉快！", "欢迎使用哟！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, playMode == PlayMode.Locking ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        playMode = PlayMode.Following;
                        break;
                    case DialogResult.No:
                        playMode = PlayMode.Locking;
                        break;
                    case DialogResult.Cancel:
                        return;
                }
                AppConfig.PlayMode = playMode;
            }

            // Following 模式的代码存放在此委托类型变量中。
            Action playTask = () =>
            {
                while (true)
                {
                    try
                    {
                        soundPlayer.PlaySync();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Trace.Fail("播放声音文件发生了错误！", e.Message);
                        Application.Exit();
                        return;
                    }
                }
            };

            // 根据不同模式选择不同的播放模式。
            switch (playMode)
            {
                case PlayMode.Following:
                    playTask.BeginInvoke(null, null);
                    break;
                case PlayMode.Locking:
                    try
                    {
                        soundPlayer.PlayLooping();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Trace.Fail("播放声音发生了错误！", e.Message);
                    }
                    break;
            }

            // 开始处理消息。
            Application.Run();
        }
    }
}
