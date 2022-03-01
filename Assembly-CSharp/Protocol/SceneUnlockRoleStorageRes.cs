using System;

namespace Protocol
{
	// Token: 0x020009B4 RID: 2484
	[Protocol]
	public class SceneUnlockRoleStorageRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F9D RID: 28573 RVA: 0x00142038 File Offset: 0x00140438
		public uint GetMsgID()
		{
			return 501099U;
		}

		// Token: 0x06006F9E RID: 28574 RVA: 0x0014203F File Offset: 0x0014043F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F9F RID: 28575 RVA: 0x00142047 File Offset: 0x00140447
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FA0 RID: 28576 RVA: 0x00142050 File Offset: 0x00140450
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curOpenNum);
		}

		// Token: 0x06006FA1 RID: 28577 RVA: 0x0014206E File Offset: 0x0014046E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curOpenNum);
		}

		// Token: 0x06006FA2 RID: 28578 RVA: 0x0014208C File Offset: 0x0014048C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curOpenNum);
		}

		// Token: 0x06006FA3 RID: 28579 RVA: 0x001420AA File Offset: 0x001404AA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curOpenNum);
		}

		// Token: 0x06006FA4 RID: 28580 RVA: 0x001420C8 File Offset: 0x001404C8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040032A1 RID: 12961
		public const uint MsgID = 501099U;

		// Token: 0x040032A2 RID: 12962
		public uint Sequence;

		// Token: 0x040032A3 RID: 12963
		public uint retCode;

		// Token: 0x040032A4 RID: 12964
		public uint curOpenNum;
	}
}
