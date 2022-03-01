using System;

namespace Protocol
{
	// Token: 0x020009AE RID: 2478
	[Protocol]
	public class SceneEquipConvertRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F67 RID: 28519 RVA: 0x00141DF8 File Offset: 0x001401F8
		public uint GetMsgID()
		{
			return 501093U;
		}

		// Token: 0x06006F68 RID: 28520 RVA: 0x00141DFF File Offset: 0x001401FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F69 RID: 28521 RVA: 0x00141E07 File Offset: 0x00140207
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F6A RID: 28522 RVA: 0x00141E10 File Offset: 0x00140210
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.eqGuid);
		}

		// Token: 0x06006F6B RID: 28523 RVA: 0x00141E2E File Offset: 0x0014022E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.eqGuid);
		}

		// Token: 0x06006F6C RID: 28524 RVA: 0x00141E4C File Offset: 0x0014024C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.eqGuid);
		}

		// Token: 0x06006F6D RID: 28525 RVA: 0x00141E6A File Offset: 0x0014026A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.eqGuid);
		}

		// Token: 0x06006F6E RID: 28526 RVA: 0x00141E88 File Offset: 0x00140288
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003291 RID: 12945
		public const uint MsgID = 501093U;

		// Token: 0x04003292 RID: 12946
		public uint Sequence;

		// Token: 0x04003293 RID: 12947
		public uint retCode;

		// Token: 0x04003294 RID: 12948
		public ulong eqGuid;
	}
}
