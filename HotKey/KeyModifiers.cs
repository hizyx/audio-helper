using System;

namespace AudioHelper.HotKey
{
    /// <summary>
    /// 为热键提供修饰键的枚举。
    /// </summary>
    [Flags]
    public enum KeyModifiers : uint
    {
        None = 0X00,
        /// <summary>
        /// 必须按下 Alt 键
        /// </summary>
        Alt = 0X01,

/// <summary>
/// 必须按下 Ctrl 键
/// </summary>
        Control = 0X02,

        /// <summary>
        /// 必须按下 Shift 键
        /// </summary>
        Shift = 0X04,

/// <summary>
/// 必须按下 Windows 徽标键。注意： Windows 徽标键组成的热键被系统占用了。
/// </summary>
        Windows = 0X08,

        /// <summary>
        /// 热键按下时禁止重复发出消息
        /// </summary>
        NoRepeat = 0X4000
    }
}
