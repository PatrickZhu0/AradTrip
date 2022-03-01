using System;
using System.Runtime.InteropServices;

namespace LibZip
{
	// Token: 0x020001A5 RID: 421
	public class LibZip
	{
		// Token: 0x06000DA0 RID: 3488
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr zip_open(string strZipPath, int iMode, IntPtr ptrDefaultNull);

		// Token: 0x06000DA1 RID: 3489
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_get_num_files(IntPtr ptrZip);

		// Token: 0x06000DA2 RID: 3490
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr zip_fopen(IntPtr ptrZip, string strFileName, int iMode);

		// Token: 0x06000DA3 RID: 3491
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_stat(IntPtr ptrZip, string strFileName, int iMode, ref zip_stat refZipState);

		// Token: 0x06000DA4 RID: 3492
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern long zip_fread(IntPtr ptrZipFile, byte[] ptrBuffer, long iBufferSize);

		// Token: 0x06000DA5 RID: 3493
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_fclose(IntPtr ptrZipFile);

		// Token: 0x06000DA6 RID: 3494
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_close(IntPtr ptrZip);

		// Token: 0x06000DA7 RID: 3495
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern IntPtr zip_get_name(IntPtr ptrZip, long iFile, int iMode);

		// Token: 0x06000DA8 RID: 3496
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern long zip_get_num_entries(IntPtr ptrZip, int flag);

		// Token: 0x06000DA9 RID: 3497
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_stat_index(IntPtr ptrZip, long iSize, int iFlag, ref zip_stat refZipState);

		// Token: 0x06000DAA RID: 3498
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr zip_fopen_index(IntPtr ptrZip, long iIndex, int iFlag);

		// Token: 0x06000DAB RID: 3499
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern long zip_file_add(IntPtr ptrZip, string name, IntPtr source, int iFlag);

		// Token: 0x06000DAC RID: 3500
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr zip_source_buffer(IntPtr ptrZip, byte[] data, long len, int freep);

		// Token: 0x06000DAD RID: 3501
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_source_write(IntPtr sourcePtr, byte[] data, long len);

		// Token: 0x06000DAE RID: 3502
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_source_begin_write(IntPtr sourcePtr);

		// Token: 0x06000DAF RID: 3503
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr zip_source_file(IntPtr zipPtr, string fname, long start, long len);

		// Token: 0x06000DB0 RID: 3504
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_source_commit_write(IntPtr sourcePtr);

		// Token: 0x06000DB1 RID: 3505
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern int zip_source_free(IntPtr sourcePtr);

		// Token: 0x06000DB2 RID: 3506
		[DllImport("zip", CallingConvention = CallingConvention.Cdecl)]
		public static extern void zip_source_rollback_write(IntPtr sourcePtr);

		// Token: 0x04000998 RID: 2456
		private const string LIBZIP_DLL = "zip";
	}
}
