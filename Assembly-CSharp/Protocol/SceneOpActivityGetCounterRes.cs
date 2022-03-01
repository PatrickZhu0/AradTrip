using System;

namespace Protocol
{
	// Token: 0x02000A4B RID: 2635
	[Protocol]
	public class SceneOpActivityGetCounterRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007402 RID: 29698 RVA: 0x00150664 File Offset: 0x0014EA64
		public uint GetMsgID()
		{
			return 507413U;
		}

		// Token: 0x06007403 RID: 29699 RVA: 0x0015066B File Offset: 0x0014EA6B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007404 RID: 29700 RVA: 0x00150673 File Offset: 0x0014EA73
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007405 RID: 29701 RVA: 0x0015067C File Offset: 0x0014EA7C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.counterId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.counterValue);
		}

		// Token: 0x06007406 RID: 29702 RVA: 0x001506A8 File Offset: 0x0014EAA8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.counterId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.counterValue);
		}

		// Token: 0x06007407 RID: 29703 RVA: 0x001506D4 File Offset: 0x0014EAD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.counterId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.counterValue);
		}

		// Token: 0x06007408 RID: 29704 RVA: 0x00150700 File Offset: 0x0014EB00
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.counterId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.counterValue);
		}

		// Token: 0x06007409 RID: 29705 RVA: 0x0015072C File Offset: 0x0014EB2C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040035D6 RID: 13782
		public const uint MsgID = 507413U;

		// Token: 0x040035D7 RID: 13783
		public uint Sequence;

		// Token: 0x040035D8 RID: 13784
		public uint opActId;

		// Token: 0x040035D9 RID: 13785
		public uint counterId;

		// Token: 0x040035DA RID: 13786
		public uint counterValue;
	}
}
