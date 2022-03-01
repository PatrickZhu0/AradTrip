using System;
using System.Runtime.InteropServices;

// Token: 0x02000104 RID: 260
public class BaseDLL
{
	// Token: 0x0600057C RID: 1404
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_int8(byte[] buf, ref int pos, byte val);

	// Token: 0x0600057D RID: 1405
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_int8(byte[] buf, ref int pos, ref byte val);

	// Token: 0x0600057E RID: 1406
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_uint16(byte[] buf, ref int pos, ushort val);

	// Token: 0x0600057F RID: 1407
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_uint16(byte[] buf, ref int pos, ref ushort val);

	// Token: 0x06000580 RID: 1408
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_int16(byte[] buf, ref int pos, short val);

	// Token: 0x06000581 RID: 1409
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_int16(byte[] buf, ref int pos, ref short val);

	// Token: 0x06000582 RID: 1410
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_uint32(byte[] buf, ref int pos, uint val);

	// Token: 0x06000583 RID: 1411
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_uint32(byte[] buf, ref int pos, ref uint val);

	// Token: 0x06000584 RID: 1412
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_int32(byte[] buf, ref int pos, int val);

	// Token: 0x06000585 RID: 1413
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_int32(byte[] buf, ref int pos, ref int val);

	// Token: 0x06000586 RID: 1414
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_uint64(byte[] buf, ref int pos, ulong val);

	// Token: 0x06000587 RID: 1415
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_uint64(byte[] buf, ref int pos, ref ulong val);

	// Token: 0x06000588 RID: 1416
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_int64(byte[] buf, ref int pos, long val);

	// Token: 0x06000589 RID: 1417
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_int64(byte[] buf, ref int pos, ref long val);

	// Token: 0x0600058A RID: 1418
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int encode_string(byte[] buf, ref int pos, byte[] str, ushort max_length);

	// Token: 0x0600058B RID: 1419
	[DllImport("base", CallingConvention = CallingConvention.Cdecl)]
	public static extern int decode_string(byte[] buf, ref int pos, byte[] str, ushort max_length);

	// Token: 0x0600058C RID: 1420 RVA: 0x000243A4 File Offset: 0x000227A4
	public static int encode_int8(MapViewStream st, ref int pos, byte val)
	{
		st.encode_int8(val);
		return 0;
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x000243AF File Offset: 0x000227AF
	public static int decode_int8(MapViewStream st, ref int pos, ref byte val)
	{
		st.decode_int8(ref val);
		return 0;
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x000243BA File Offset: 0x000227BA
	public static int encode_uint16(MapViewStream st, ref int pos, ushort val)
	{
		st.encode_uint16(val);
		return 0;
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x000243C5 File Offset: 0x000227C5
	public static int decode_uint16(MapViewStream st, ref int pos, ref ushort val)
	{
		st.decode_uint16(ref val);
		return 0;
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x000243D0 File Offset: 0x000227D0
	public static int encode_int16(MapViewStream st, ref int pos, short val)
	{
		st.encode_int16(val);
		return 0;
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x000243DB File Offset: 0x000227DB
	public static int decode_int16(MapViewStream st, ref int pos, ref short val)
	{
		st.decode_int16(ref val);
		return 0;
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x000243E6 File Offset: 0x000227E6
	public static int encode_uint32(MapViewStream st, ref int pos, uint val)
	{
		st.encode_uint32(val);
		return 0;
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x000243F1 File Offset: 0x000227F1
	public static int decode_uint32(MapViewStream st, ref int pos, ref uint val)
	{
		st.decode_uint32(ref val);
		return 0;
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x000243FC File Offset: 0x000227FC
	public static int encode_int32(MapViewStream st, ref int pos, int val)
	{
		st.encode_int32(val);
		return 0;
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00024407 File Offset: 0x00022807
	public static int decode_int32(MapViewStream st, ref int pos, ref int val)
	{
		st.decode_int32(ref val);
		return 0;
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x00024412 File Offset: 0x00022812
	public static int encode_uint64(MapViewStream st, ref int pos, ulong val)
	{
		st.encode_uint64(val);
		return 0;
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x0002441D File Offset: 0x0002281D
	public static int decode_uint64(MapViewStream st, ref int pos, ref ulong val)
	{
		st.decode_uint64(ref val);
		return 0;
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x00024428 File Offset: 0x00022828
	public static int encode_int64(MapViewStream st, ref int pos, long val)
	{
		st.encode_int64(val);
		return 0;
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00024433 File Offset: 0x00022833
	public static int decode_int64(MapViewStream st, ref int pos, ref long val)
	{
		st.decode_int64(ref val);
		return 0;
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x0002443E File Offset: 0x0002283E
	public static int encode_string(MapViewStream st, ref int pos, byte[] str, ushort max_length)
	{
		st.encode_string(str);
		return 0;
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x00024449 File Offset: 0x00022849
	public static int decode_string(MapViewStream st, ref int pos, byte[] str, ushort max_length)
	{
		st.decode_string(str);
		return 0;
	}

	// Token: 0x040004ED RID: 1261
	private const string baseDLL = "base";
}
