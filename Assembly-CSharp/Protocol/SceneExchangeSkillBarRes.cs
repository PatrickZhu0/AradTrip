using System;

namespace Protocol
{
	// Token: 0x02000B37 RID: 2871
	[Protocol]
	public class SceneExchangeSkillBarRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AB6 RID: 31414 RVA: 0x0016024E File Offset: 0x0015E64E
		public uint GetMsgID()
		{
			return 501202U;
		}

		// Token: 0x06007AB7 RID: 31415 RVA: 0x00160255 File Offset: 0x0015E655
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007AB8 RID: 31416 RVA: 0x0016025D File Offset: 0x0015E65D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007AB9 RID: 31417 RVA: 0x00160266 File Offset: 0x0015E666
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007ABA RID: 31418 RVA: 0x00160276 File Offset: 0x0015E676
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007ABB RID: 31419 RVA: 0x00160286 File Offset: 0x0015E686
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007ABC RID: 31420 RVA: 0x00160296 File Offset: 0x0015E696
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007ABD RID: 31421 RVA: 0x001602A8 File Offset: 0x0015E6A8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A2E RID: 14894
		public const uint MsgID = 501202U;

		// Token: 0x04003A2F RID: 14895
		public uint Sequence;

		// Token: 0x04003A30 RID: 14896
		public uint result;
	}
}
