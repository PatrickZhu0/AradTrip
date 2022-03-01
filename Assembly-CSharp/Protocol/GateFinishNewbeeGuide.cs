using System;

namespace Protocol
{
	// Token: 0x020009D5 RID: 2517
	[Protocol]
	public class GateFinishNewbeeGuide : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070A5 RID: 28837 RVA: 0x00145A9C File Offset: 0x00143E9C
		public uint GetMsgID()
		{
			return 300313U;
		}

		// Token: 0x060070A6 RID: 28838 RVA: 0x00145AA3 File Offset: 0x00143EA3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070A7 RID: 28839 RVA: 0x00145AAB File Offset: 0x00143EAB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070A8 RID: 28840 RVA: 0x00145AB4 File Offset: 0x00143EB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x060070A9 RID: 28841 RVA: 0x00145AD2 File Offset: 0x00143ED2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060070AA RID: 28842 RVA: 0x00145AF0 File Offset: 0x00143EF0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x060070AB RID: 28843 RVA: 0x00145B0E File Offset: 0x00143F0E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060070AC RID: 28844 RVA: 0x00145B2C File Offset: 0x00143F2C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400334E RID: 13134
		public const uint MsgID = 300313U;

		// Token: 0x0400334F RID: 13135
		public uint Sequence;

		// Token: 0x04003350 RID: 13136
		public ulong roleId;

		// Token: 0x04003351 RID: 13137
		public uint id;
	}
}
