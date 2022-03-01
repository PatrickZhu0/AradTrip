using System;

namespace Protocol
{
	// Token: 0x02000B9D RID: 2973
	[Protocol]
	public class WorldTeamMatchCancelRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DE0 RID: 32224 RVA: 0x00165B1C File Offset: 0x00163F1C
		public uint GetMsgID()
		{
			return 601651U;
		}

		// Token: 0x06007DE1 RID: 32225 RVA: 0x00165B23 File Offset: 0x00163F23
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DE2 RID: 32226 RVA: 0x00165B2B File Offset: 0x00163F2B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DE3 RID: 32227 RVA: 0x00165B34 File Offset: 0x00163F34
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007DE4 RID: 32228 RVA: 0x00165B44 File Offset: 0x00163F44
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007DE5 RID: 32229 RVA: 0x00165B54 File Offset: 0x00163F54
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007DE6 RID: 32230 RVA: 0x00165B64 File Offset: 0x00163F64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007DE7 RID: 32231 RVA: 0x00165B74 File Offset: 0x00163F74
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003BA6 RID: 15270
		public const uint MsgID = 601651U;

		// Token: 0x04003BA7 RID: 15271
		public uint Sequence;

		// Token: 0x04003BA8 RID: 15272
		public uint result;
	}
}
