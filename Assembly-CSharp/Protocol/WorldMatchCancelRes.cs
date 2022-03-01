using System;

namespace Protocol
{
	// Token: 0x020009EF RID: 2543
	[Protocol]
	public class WorldMatchCancelRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007153 RID: 29011 RVA: 0x00146E94 File Offset: 0x00145294
		public uint GetMsgID()
		{
			return 606703U;
		}

		// Token: 0x06007154 RID: 29012 RVA: 0x00146E9B File Offset: 0x0014529B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007155 RID: 29013 RVA: 0x00146EA3 File Offset: 0x001452A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007156 RID: 29014 RVA: 0x00146EAC File Offset: 0x001452AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007157 RID: 29015 RVA: 0x00146EBC File Offset: 0x001452BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007158 RID: 29016 RVA: 0x00146ECC File Offset: 0x001452CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007159 RID: 29017 RVA: 0x00146EDC File Offset: 0x001452DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600715A RID: 29018 RVA: 0x00146EEC File Offset: 0x001452EC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040033C7 RID: 13255
		public const uint MsgID = 606703U;

		// Token: 0x040033C8 RID: 13256
		public uint Sequence;

		// Token: 0x040033C9 RID: 13257
		public uint result;
	}
}
