using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace WPFUnityPlayer.Utils.Unity
{
    public class UnityWindowHost : HwndHost
    {
        public IntPtr HwndHost { get; private set; }
        private int hostHeight, hostWidth;

        private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const int HOST_ID = 0x00000002;

        public UnityWindowHost(double width, double height)
        {
            this.hostWidth = (int)width;
            this.hostHeight = (int)height;
        }

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            HwndHost = IntPtr.Zero;

            HwndHost = CreateWindowEx(0, "static", "",
                                      WS_CHILD | WS_VISIBLE,
                                      0, 0,
                                      hostWidth, hostHeight,
                                      hwndParent.Handle,
                                      (IntPtr)HOST_ID,
                                      IntPtr.Zero,
                                      0);

            {
                try
                {
                    process = new Process();
                    process.StartInfo.FileName = "UnityPlayer.exe";
                    process.StartInfo.Arguments = "-parentHWND " + HwndHost.ToInt32() + " " + Environment.CommandLine;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    process.WaitForInputIdle();

                    EnumChildWindows(HwndHost, WindowEnum, IntPtr.Zero);
                }
                catch (Exception ex)
                {
                }
            }

            return new HandleRef(this, HwndHost);
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            try
            {
                process.CloseMainWindow();

                System.Threading.Thread.Sleep(1000);
                while (process.HasExited == false)
                    process.Kill();
            }
            catch (Exception)
            {

            }

            DestroyWindow(hwnd.Handle);
        }

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            unityHWND = hwnd;
            return 0;
        }

        #region P/Invoke
        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                              string lpszClassName,
                                              string lpszWindowName,
                                              int style,
                                              int x, int y,
                                              int width, int height,
                                              IntPtr hwndParent,
                                              IntPtr hMenu,
                                              IntPtr hInst,
                                              [MarshalAs(UnmanagedType.AsAny)] object pvParam);


        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        internal static extern bool DestroyWindow(IntPtr hwnd);
        #endregion
    }
}
