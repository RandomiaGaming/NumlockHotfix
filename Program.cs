using System.Runtime.InteropServices;
namespace NumlockHotfix
{
    public static class NumlockHotfix
    {
        private const byte VK_NUMLOCK = 144;
        private const byte VK_CAPITAL = 20;
        private const uint KeyDown = 0;
        private const uint KeyUp = 2;
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern short GetKeyState(int keyCode);
        public static void Main()
        {
            if ((((ushort)GetKeyState(VK_CAPITAL)) & 0xffff) != 0)
            {
                keybd_event(VK_CAPITAL, 0, KeyDown, 0);
                keybd_event(VK_CAPITAL, 0, KeyUp, 0);
            }
            if ((((ushort)GetKeyState(VK_NUMLOCK)) & 0xffff) == 0)
            {
                keybd_event(VK_NUMLOCK, 0, KeyDown, 0);
                keybd_event(VK_NUMLOCK, 0, KeyUp, 0);
            }
        }
    }
}