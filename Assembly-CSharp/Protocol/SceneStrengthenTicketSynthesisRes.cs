using System;

namespace Protocol
{
	// Token: 0x0200095B RID: 2395
	[Protocol]
	public class SceneStrengthenTicketSynthesisRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C97 RID: 27799 RVA: 0x0013C240 File Offset: 0x0013A640
		public uint GetMsgID()
		{
			return 501032U;
		}

		// Token: 0x06006C98 RID: 27800 RVA: 0x0013C247 File Offset: 0x0013A647
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C99 RID: 27801 RVA: 0x0013C24F File Offset: 0x0013A64F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C9A RID: 27802 RVA: 0x0013C258 File Offset: 0x0013A658
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006C9B RID: 27803 RVA: 0x0013C268 File Offset: 0x0013A668
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006C9C RID: 27804 RVA: 0x0013C278 File Offset: 0x0013A678
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006C9D RID: 27805 RVA: 0x0013C288 File Offset: 0x0013A688
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006C9E RID: 27806 RVA: 0x0013C298 File Offset: 0x0013A698
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003124 RID: 12580
		public const uint MsgID = 501032U;

		// Token: 0x04003125 RID: 12581
		public uint Sequence;

		// Token: 0x04003126 RID: 12582
		public uint ret;
	}
}
