using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisplaySelector.ServiceDisplayMode;
using System;
using System.Runtime.InteropServices;
namespace DisplaySelector
{
    class ChangeDetector : ISixModeServiceCallback
    {

        public ChangeDetector()
        {
            DISPLAY_DEVICE d = new DISPLAY_DEVICE();
            d.cb = Marshal.SizeOf(d);
            for (uint id = 0; NativeMethods.EnumDisplayDevices(null, id, ref d, 0); id++)
            {
                if (d.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop))
                {
                    Console.Write("");
                }
                    
            }
        }

        public void NotifySensorSixModeStates(int rotationState)
        {
            Console.Write(rotationState);
            DEVMODE dm = new DEVMODE();
            // dm.dmDeviceName = new string(new char[32]);
            ///  dm.dmFormName = new string(new char[32]);
            //   dm.dmSize = (short)Marshal.SizeOf(dm);

            DISPLAY_DEVICE d = new DISPLAY_DEVICE();
            d.cb = Marshal.SizeOf(d);
            for (uint id = 0; NativeMethods.EnumDisplayDevices(null, id, ref d, 0); id++)
            {
                if (d.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop))
                {
                   // Change(d.DeviceName,id!=0);
                }

            }

            if (0 != NativeMethods.EnumDisplaySettings(
            null,
            NativeMethods.ENUM_CURRENT_SETTINGS,
            ref dm))
            {
                // swap width and height
                int temp = dm.dmPelsHeight;
                dm.dmPelsHeight = dm.dmPelsWidth;
                dm.dmPelsWidth = temp;

                // determine new orientation
                switch (dm.dmDisplayOrientation)
                {
                    case NativeMethods.DMDO_DEFAULT:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_180;
                        break;
                    case NativeMethods.DMDO_270:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_180;
                        break;
                    case NativeMethods.DMDO_180:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_90;
                        break;
                    case NativeMethods.DMDO_90:
                       dm.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
                       break;
                    default:

                        dm.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
                        // unknown orientation value
                        // add exception handling here

                        break;
                }

                int iRet = NativeMethods.ChangeDisplaySettings(ref dm, 0);

            }




        }

        public void Change(string name,bool isExternal)
        {
            DEVMODE dm = new DEVMODE();
            if (0 != NativeMethods.EnumDisplaySettings(
          name,
          NativeMethods.ENUM_CURRENT_SETTINGS,
          ref dm))
            {
                // swap width and height
                int temp = dm.dmPelsHeight;
                dm.dmPelsHeight = dm.dmPelsWidth;
                dm.dmPelsWidth = temp;

                // determine new orientation
                switch (dm.dmDisplayOrientation)
                {
                    case NativeMethods.DMDO_DEFAULT:
                        dm.dmDisplayOrientation = NativeMethods.DMDO_270;
                        break;
                    //case NativeMethods.DMDO_270:
                    //    dm.dmDisplayOrientation = NativeMethods.DMDO_180;
                    //    break;
                    //case NativeMethods.DMDO_180:
                    //    dm.dmDisplayOrientation = NativeMethods.DMDO_90;
                    //    break;
                    //case NativeMethods.DMDO_90:
                    //    dm.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
                    //    break;
                    default:

                        dm.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
                        // unknown orientation value
                        // add exception handling here

                        break;
                }
                DISP_CHANGE iRet;
                if (!isExternal)
                {
                    iRet=(DISP_CHANGE) NativeMethods.ChangeDisplaySettings(ref dm, 1);
                }
                else
                {
                    iRet= NativeMethods.ChangeDisplaySettingsEx(name, ref dm, IntPtr.Zero,DisplaySettingsFlags.CDS_UPDATEREGISTRY, IntPtr.Zero);
                }
                if (iRet != DISP_CHANGE.Successful)
                {

                }

            }
        }

    }

  
    

    //public class NativeMethods
    //    {
    //        // PInvoke declaration for EnumDisplaySettings Win32 API
    //        [DllImport("user32.dll",CharSet = CharSet.Ansi)]
    //        public static extern int EnumDisplaySettings(string lpszDeviceName, int iModeNum,ref DEVMODE lpDevMode);

    //        // PInvoke declaration for ChangeDisplaySettings Win32 API
    //        [DllImport("user32.dll", CharSet=CharSet.Ansi)]
    //        public static extern int ChangeDisplaySettings( ref DEVMODE lpDevMode, int dwFlags);

    //        [DllImport("user32.dll")]
    //        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

    //        [DllImport("user32.dll")]
    //        internal static extern DISP_CHANGE ChangeDisplaySettingsEx( string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd, DisplaySettingsFlags dwflags, IntPtr lParam);

    //    // add more functions as needed …

    //    // constants
    //    public const int ENUM_CURRENT_SETTINGS = -1;
    //        public const int DMDO_DEFAULT = 0;
    //        public const int DMDO_90 = 1;
    //        public const int DMDO_180 = 2;
    //        public const int DMDO_270 = 3;
    //        // add more constants as needed …
    //    }

    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    //public struct DEVMODE
    //{
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //    public string dmDeviceName;

    //    public short dmSpecVersion;
    //    public short dmDriverVersion;
    //    public short dmSize;
    //    public short dmDriverExtra;
    //    public int dmFields;
    //    public int dmPositionX;
    //    public int dmPositionY;
    //    public int dmDisplayOrientation;
    //    public int dmDisplayFixedOutput;
    //    public short dmColor;
    //    public short dmDuplex;
    //    public short dmYResolution;
    //    public short dmTTOption;
    //    public short dmCollate;

    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //    public string dmFormName;

    //    public short dmLogPixels;
    //    public short dmBitsPerPel;
    //    public int dmPelsWidth;
    //    public int dmPelsHeight;
    //    public int dmDisplayFlags;
    //    public int dmDisplayFrequency;
    //    public int dmICMMethod;
    //    public int dmICMIntent;
    //    public int dmMediaType;
    //    public int dmDitherType;
    //    public int dmReserved1;
    //    public int dmReserved2;
    //    public int dmPanningWidth;
    //    public int dmPanningHeight;
    //};

    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    //public struct DISPLAY_DEVICE
    //{
    //    [MarshalAs(UnmanagedType.U4)]
    //    public int cb;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //    public string DeviceName;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    //    public string DeviceString;
    //    [MarshalAs(UnmanagedType.U4)]
    //    public DisplayDeviceStateFlags StateFlags;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    //    public string DeviceID;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    //    public string DeviceKey;
    //}

    //[Flags()]
    //public enum DisplayDeviceStateFlags : int
    //{
    //    /// <summary>The device is part of the desktop.</summary>
    //    AttachedToDesktop = 0x1,
    //    MultiDriver = 0x2,
    //    /// <summary>The device is part of the desktop.</summary>
    //    PrimaryDevice = 0x4,
    //    /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
    //    MirroringDriver = 0x8,
    //    /// <summary>The device is VGA compatible.</summary>
    //    VGACompatible = 0x10,
    //    /// <summary>The device is removable; it cannot be the primary display.</summary>
    //    Removable = 0x20,
    //    /// <summary>The device has more display modes than its output devices support.</summary>
    //    ModesPruned = 0x8000000,
    //    Remote = 0x4000000,
    //    Disconnect = 0x2000000
    //}

    //enum DisplaySettingsFlags : int
    //{
    //    CDS_UPDATEREGISTRY = 1,
    //    CDS_TEST = 2,
    //    CDS_FULLSCREEN = 4,
    //    CDS_GLOBAL = 8,
    //    CDS_SET_PRIMARY = 0x10,
    //    CDS_RESET = 0x40000000,
    //    CDS_NORESET = 0x10000000
    //}

    //enum DISP_CHANGE : int
    //{
    //    Successful = 0,
    //    Restart = 1,
    //    Failed = -1,
    //    BadMode = -2,
    //    NotUpdated = -3,
    //    BadFlags = -4,
    //    BadParam = -5,
    //    BadDualView = -6
    //}
}
