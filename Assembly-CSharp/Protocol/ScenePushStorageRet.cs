using System;

namespace Protocol
{
	// Token: 0x020008E1 RID: 2273
	[Protocol]
	public class ScenePushStorageRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006859 RID: 26713 RVA: 0x00135448 File Offset: 0x00133848
		public uint GetMsgID()
		{
			return 500911U;
		}

		// Token: 0x0600685A RID: 26714 RVA: 0x0013544F File Offset: 0x0013384F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600685B RID: 26715 RVA: 0x00135457 File Offset: 0x00133857
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600685C RID: 26716 RVA: 0x00135460 File Offset: 0x00133860
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600685D RID: 26717 RVA: 0x00135470 File Offset: 0x00133870
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600685E RID: 26718 RVA: 0x00135480 File Offset: 0x00133880
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600685F RID: 26719 RVA: 0x00135490 File Offset: 0x00133890
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006860 RID: 26720 RVA: 0x001354A0 File Offset: 0x001338A0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F5C RID: 12124
		public const uint MsgID = 500911U;

		// Token: 0x04002F5D RID: 12125
		public uint Sequence;

		// Token: 0x04002F5E RID: 12126
		public uint code;
	}
}
