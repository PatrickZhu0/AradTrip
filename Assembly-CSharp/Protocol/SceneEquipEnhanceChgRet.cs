using System;

namespace Protocol
{
	// Token: 0x02000991 RID: 2449
	[Protocol]
	public class SceneEquipEnhanceChgRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E6B RID: 28267 RVA: 0x0013FB88 File Offset: 0x0013DF88
		public uint GetMsgID()
		{
			return 501067U;
		}

		// Token: 0x06006E6C RID: 28268 RVA: 0x0013FB8F File Offset: 0x0013DF8F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E6D RID: 28269 RVA: 0x0013FB97 File Offset: 0x0013DF97
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E6E RID: 28270 RVA: 0x0013FBA0 File Offset: 0x0013DFA0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E6F RID: 28271 RVA: 0x0013FBB0 File Offset: 0x0013DFB0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E70 RID: 28272 RVA: 0x0013FBC0 File Offset: 0x0013DFC0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E71 RID: 28273 RVA: 0x0013FBD0 File Offset: 0x0013DFD0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E72 RID: 28274 RVA: 0x0013FBE0 File Offset: 0x0013DFE0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003206 RID: 12806
		public const uint MsgID = 501067U;

		// Token: 0x04003207 RID: 12807
		public uint Sequence;

		// Token: 0x04003208 RID: 12808
		public uint code;
	}
}
