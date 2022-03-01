using System;

namespace Protocol
{
	// Token: 0x02000801 RID: 2049
	[Protocol]
	public class SceneGoldConsignmentDealNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006250 RID: 25168 RVA: 0x00125D14 File Offset: 0x00124114
		public uint GetMsgID()
		{
			return 510103U;
		}

		// Token: 0x06006251 RID: 25169 RVA: 0x00125D1B File Offset: 0x0012411B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006252 RID: 25170 RVA: 0x00125D23 File Offset: 0x00124123
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006253 RID: 25171 RVA: 0x00125D2C File Offset: 0x0012412C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.redPointTime);
		}

		// Token: 0x06006254 RID: 25172 RVA: 0x00125D4A File Offset: 0x0012414A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.redPointTime);
		}

		// Token: 0x06006255 RID: 25173 RVA: 0x00125D68 File Offset: 0x00124168
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.redPointTime);
		}

		// Token: 0x06006256 RID: 25174 RVA: 0x00125D86 File Offset: 0x00124186
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.redPointTime);
		}

		// Token: 0x06006257 RID: 25175 RVA: 0x00125DA4 File Offset: 0x001241A4
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04002B69 RID: 11113
		public const uint MsgID = 510103U;

		// Token: 0x04002B6A RID: 11114
		public uint Sequence;

		// Token: 0x04002B6B RID: 11115
		public ulong roldId;

		// Token: 0x04002B6C RID: 11116
		public uint redPointTime;
	}
}
