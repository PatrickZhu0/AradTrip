using System;

namespace Protocol
{
	// Token: 0x02000685 RID: 1669
	[Protocol]
	public class SceneDeleteNotifyList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056D5 RID: 22229 RVA: 0x0010995D File Offset: 0x00107D5D
		public uint GetMsgID()
		{
			return 501155U;
		}

		// Token: 0x060056D6 RID: 22230 RVA: 0x00109964 File Offset: 0x00107D64
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056D7 RID: 22231 RVA: 0x0010996C File Offset: 0x00107D6C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056D8 RID: 22232 RVA: 0x00109975 File Offset: 0x00107D75
		public void encode(byte[] buffer, ref int pos_)
		{
			this.notify.encode(buffer, ref pos_);
		}

		// Token: 0x060056D9 RID: 22233 RVA: 0x00109984 File Offset: 0x00107D84
		public void decode(byte[] buffer, ref int pos_)
		{
			this.notify.decode(buffer, ref pos_);
		}

		// Token: 0x060056DA RID: 22234 RVA: 0x00109993 File Offset: 0x00107D93
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.notify.encode(buffer, ref pos_);
		}

		// Token: 0x060056DB RID: 22235 RVA: 0x001099A2 File Offset: 0x00107DA2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.notify.decode(buffer, ref pos_);
		}

		// Token: 0x060056DC RID: 22236 RVA: 0x001099B4 File Offset: 0x00107DB4
		public int getLen()
		{
			int num = 0;
			return num + this.notify.getLen();
		}

		// Token: 0x0400227D RID: 8829
		public const uint MsgID = 501155U;

		// Token: 0x0400227E RID: 8830
		public uint Sequence;

		// Token: 0x0400227F RID: 8831
		public NotifyInfo notify = new NotifyInfo();
	}
}
