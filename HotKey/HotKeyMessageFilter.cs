using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AudioHelper.HotKey
{
    /// <summary>
    /// 筛选处理 WM_HOTKEY 热键消息的类。
    /// </summary>
    public class HotKeyMessageFilter : System.Windows.Forms.IMessageFilter
    {
        /// <summary>
        /// WM_HOTKEY 热键消息常量。
        /// </summary>
        private const int WM_HOTKEY = 0X0312;

        /// <summary>
        /// 筛选处理 WM_HOTKEY 热键消息。
        /// </summary>
        /// <param name="m">要处理的消息结构</param>
        /// <returns>返回 true 禁止消息被继续处理， false 允许消息进一步处理</returns>
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                HotKeyMessage hotKeyMessage = new HotKeyMessage() { KeyModifiers = (KeyModifiers)(m.LParam.ToInt32() & 0X0000FFFF), VirtualKey = (VirtualKeys)(m.LParam.ToInt32() >> 16) };
                HotKeyEventArgs eventArgs = new HotKeyEventArgs() { Id = m.WParam.ToInt32(), HWnd = m.HWnd, HotKeyMessage = hotKeyMessage };
                this.HotKeyDown?.Invoke(this, eventArgs);
            }
            return false;
        }

        /// <summary>
        /// 当关联到此县城的热键按下时触发此事件。
        /// </summary>
        public event EventHandler<HotKeyEventArgs> HotKeyDown;
    }

    /// <summary>
    /// 包含修饰键和虚拟键代码的结构。
    /// </summary>
    public struct HotKeyMessage
    {
        public KeyModifiers KeyModifiers;
        public VirtualKeys VirtualKey;
    }

    /// <summary>
    /// 为 HotKeyDown 事件提供数据的类。
    /// </summary>
    public class HotKeyEventArgs : EventArgs
    {
        public int Id { get; set; }
        public IntPtr HWnd { get; set; }
        public HotKeyMessage HotKeyMessage { get; set; }
    }
}
