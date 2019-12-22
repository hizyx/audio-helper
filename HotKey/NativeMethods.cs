using System;
using System.Runtime.InteropServices;

/// <summary>
/// 管理、注册全局热键。
/// </summary>
namespace AudioHelper.HotKey
{
/// <summary>
/// 导入注册热键、撤销热键的 Windows API 方法。
/// </summary>
    internal static class NativeMethods
    {
/// <summary>
/// 注册全局热键。
/// </summary>
/// <param name="hWnd">关联的窗口句柄。如果此值为零，则与当前县城关联， WM_HOTKEY 消息会放到当前县城的消息队列。</param>
/// <param name="id">用来标识热键的标识符。</param>
/// <param name="fsModifiers">修饰键的值。</param>
/// <param name="vk">虚拟键代码。</param>
/// <returns>成功返回 true， 失败返回 false。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, VirtualKeys vk);

/// <summary>
/// 撤销已经注册的全局热键。
/// </summary>
/// <param name="hWnd">关联的窗口句柄。如果没有与任何窗口关联，则必须为零。</param>
/// <param name="id">需要撤销的热键的标识符。</param>
/// <returns>成功返回 true， 失败返回 false。</returns>
                [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public  static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
