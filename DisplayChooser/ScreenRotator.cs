using DisplaySelector.ServiceDisplayMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DisplaySelector
{
    public static class ScreenRotator
    {
        static DEVMODE mainDevice;
        static DEVMODE remoteDevice;
        static string remoteDisplayName;

        static ScreenRotator()
        {
            DISPLAY_DEVICE display = new DISPLAY_DEVICE();
            display.cb = Marshal.SizeOf(display);

            for (uint id = 0; NativeMethods.EnumDisplayDevices(null, id, ref display, 0); id++)
            {
                if (display.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop))
                {
                    if (id == 0)
                    {
                        mainDevice=getDeviceByName(display.DeviceName);
                    }
                    else
                    {
                        remoteDevice = getDeviceByName(display.DeviceName);
                        remoteDisplayName = display.DeviceName;
                        break;
                    }
                }
            }
          
        }


        static DEVMODE getDeviceByName(string name)
        {
            DEVMODE deviceMode = new DEVMODE();
            if (0 != NativeMethods.EnumDisplaySettings(name, NativeMethods.ENUM_CURRENT_SETTINGS, ref deviceMode))
            {
                return deviceMode;
            }
            else
            {
                throw new Exception("Devicenot found");
            }
        }

        static void adjustScreenSize(ref DEVMODE deviceMode,DisplayOrientation orientation)
        {

            if (deviceMode.dmDisplayOrientation + (int)orientation % 2 >0)
            {
                // swap width and height
                int temp = deviceMode.dmPelsHeight;
                deviceMode.dmPelsHeight = deviceMode.dmPelsWidth;
                deviceMode.dmPelsWidth = temp;
            }

            deviceMode.dmDisplayOrientation = (int)orientation;
        }

        public static void Rotate(RotationStates state)
        {
            DisplayOrientation orientation_main= DisplayOrientation.UNKNOWN;
            DisplayOrientation orientation_cast= DisplayOrientation.UNKNOWN;

            switch (state)
            {
                case RotationStates.MODE_LAPTOP:
                    orientation_main = orientation_cast = DisplayOrientation.LANDSCAPE;
                    break;

                
                case RotationStates.MODE_BOOK:
                    orientation_main = orientation_cast = DisplayOrientation.PORTRAIT;
                    break;

                case RotationStates.MODE_TENT:
                    orientation_main = DisplayOrientation.LANDSCAPE;
                    orientation_cast = DisplayOrientation.LANDSCAPE_FLIPPED;
                    break;

                case RotationStates.MODE_WEDGE:
                    orientation_main = DisplayOrientation.LANDSCAPE_FLIPPED;
                    orientation_cast = DisplayOrientation.LANDSCAPE;
                    break;

                case RotationStates.MODE_MOBILE:
                    orientation_main = orientation_cast = DisplayOrientation.PORTRAIT;
                    break;


                case RotationStates.MODE_LAYFLAT:
                default:
                    return;
            }
            if(orientation_main!= DisplayOrientation.UNKNOWN && orientation_cast != DisplayOrientation.UNKNOWN)
            {
                SetOrientation(orientation_main, orientation_cast);
            }
           
        }

        public static void RotateMain()
        {
            int value=(mainDevice.dmDisplayOrientation + 1)%4;
            DisplayOrientation orientation = (DisplayOrientation)value;
            adjustScreenSize(ref mainDevice, orientation);
            NativeMethods.ChangeDisplaySettings(ref mainDevice, 1);
        }
        public static void RotateRemote()
        {
            int value = (remoteDevice.dmDisplayOrientation + 1) % 4;
            DisplayOrientation orientation = (DisplayOrientation)value;
            adjustScreenSize(ref remoteDevice, orientation);
            NativeMethods.ChangeDisplaySettingsEx(remoteDisplayName, ref remoteDevice, IntPtr.Zero, DisplaySettingsFlags.CDS_UPDATEREGISTRY, IntPtr.Zero);
        }
        
        static void SetOrientation(DisplayOrientation main,DisplayOrientation cast)
        {
               

               adjustScreenSize(ref mainDevice, main);
               adjustScreenSize(ref remoteDevice, cast);
               NativeMethods.ChangeDisplaySettings(ref mainDevice, 1);
               NativeMethods.ChangeDisplaySettingsEx(remoteDisplayName, ref remoteDevice, IntPtr.Zero, DisplaySettingsFlags.CDS_UPDATEREGISTRY, IntPtr.Zero);
            


        }




    }

    public class NativeMethods
    {
        // PInvoke declaration for EnumDisplaySettings Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern int EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

        // PInvoke declaration for ChangeDisplaySettings Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern int ChangeDisplaySettings(ref DEVMODE lpDevMode, int dwFlags);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("user32.dll")]
        internal static extern DISP_CHANGE ChangeDisplaySettingsEx(string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd, DisplaySettingsFlags dwflags, IntPtr lParam);

        // add more functions as needed …

        // constants
        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int DMDO_DEFAULT = 0;
        public const int DMDO_90 = 1;
        public const int DMDO_180 = 2;
        public const int DMDO_270 = 3;
        // add more constants as needed …
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;

        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;
        public int dmPositionX;
        public int dmPositionY;
        public int dmDisplayOrientation;
        public int dmDisplayFixedOutput;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;

        public short dmLogPixels;
        public short dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
        public int dmICMMethod;
        public int dmICMIntent;
        public int dmMediaType;
        public int dmDitherType;
        public int dmReserved1;
        public int dmReserved2;
        public int dmPanningWidth;
        public int dmPanningHeight;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DISPLAY_DEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public DisplayDeviceStateFlags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }

    [Flags()]
    public enum DisplayDeviceStateFlags : int
    {
        /// <summary>The device is part of the desktop.</summary>
        AttachedToDesktop = 0x1,
        MultiDriver = 0x2,
        /// <summary>The device is part of the desktop.</summary>
        PrimaryDevice = 0x4,
        /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
        MirroringDriver = 0x8,
        /// <summary>The device is VGA compatible.</summary>
        VGACompatible = 0x10,
        /// <summary>The device is removable; it cannot be the primary display.</summary>
        Removable = 0x20,
        /// <summary>The device has more display modes than its output devices support.</summary>
        ModesPruned = 0x8000000,
        Remote = 0x4000000,
        Disconnect = 0x2000000
    }

    enum DisplaySettingsFlags : int
    {
        CDS_UPDATEREGISTRY = 1,
        CDS_TEST = 2,
        CDS_FULLSCREEN = 4,
        CDS_GLOBAL = 8,
        CDS_SET_PRIMARY = 0x10,
        CDS_RESET = 0x40000000,
        CDS_NORESET = 0x10000000
    }

    enum DISP_CHANGE : int
    {
        Successful = 0,
        Restart = 1,
        Failed = -1,
        BadMode = -2,
        NotUpdated = -3,
        BadFlags = -4,
        BadParam = -5,
        BadDualView = -6
    }

    enum DisplayOrientation : int
    {
        LANDSCAPE =0,
        PORTRAIT = 1,
        LANDSCAPE_FLIPPED =2,
        PORTRAIT_FLIPPED =3,
        UNKNOWN=-1
    }
}
