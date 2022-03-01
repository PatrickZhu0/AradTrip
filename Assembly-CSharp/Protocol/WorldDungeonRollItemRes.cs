using System;

namespace Protocol
{
	// Token: 0x020007EE RID: 2030
	[Protocol]
	public class WorldDungeonRollItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061C9 RID: 25033 RVA: 0x001244A4 File Offset: 0x001228A4
		public uint GetMsgID()
		{
			return 606818U;
		}

		// Token: 0x060061CA RID: 25034 RVA: 0x001244AB File Offset: 0x001228AB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061CB RID: 25035 RVA: 0x001244B3 File Offset: 0x001228B3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061CC RID: 25036 RVA: 0x001244BC File Offset: 0x001228BC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.dropIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.point);
		}

		// Token: 0x060061CD RID: 25037 RVA: 0x001244F6 File Offset: 0x001228F6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.dropIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.point);
		}

		// Token: 0x060061CE RID: 25038 RVA: 0x00124530 File Offset: 0x00122930
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.dropIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.point);
		}

		// Token: 0x060061CF RID: 25039 RVA: 0x0012456A File Offset: 0x0012296A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.dropIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.point);
		}

		// Token: 0x060061D0 RID: 25040 RVA: 0x001245A4 File Offset: 0x001229A4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x040028B9 RID: 10425
		public const uint MsgID = 606818U;

		// Token: 0x040028BA RID: 10426
		public uint Sequence;

		// Token: 0x040028BB RID: 10427
		public uint result;

		// Token: 0x040028BC RID: 10428
		public byte dropIndex;

		// Token: 0x040028BD RID: 10429
		public byte opType;

		// Token: 0x040028BE RID: 10430
		public uint point;
	}
}
