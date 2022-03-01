using System;

namespace Protocol
{
	// Token: 0x02000684 RID: 1668
	[Protocol]
	public class SceneUpdateNotifyList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056CC RID: 22220 RVA: 0x001098D8 File Offset: 0x00107CD8
		public uint GetMsgID()
		{
			return 501154U;
		}

		// Token: 0x060056CD RID: 22221 RVA: 0x001098DF File Offset: 0x00107CDF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056CE RID: 22222 RVA: 0x001098E7 File Offset: 0x00107CE7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056CF RID: 22223 RVA: 0x001098F0 File Offset: 0x00107CF0
		public void encode(byte[] buffer, ref int pos_)
		{
			this.notify.encode(buffer, ref pos_);
		}

		// Token: 0x060056D0 RID: 22224 RVA: 0x001098FF File Offset: 0x00107CFF
		public void decode(byte[] buffer, ref int pos_)
		{
			this.notify.decode(buffer, ref pos_);
		}

		// Token: 0x060056D1 RID: 22225 RVA: 0x0010990E File Offset: 0x00107D0E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.notify.encode(buffer, ref pos_);
		}

		// Token: 0x060056D2 RID: 22226 RVA: 0x0010991D File Offset: 0x00107D1D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.notify.decode(buffer, ref pos_);
		}

		// Token: 0x060056D3 RID: 22227 RVA: 0x0010992C File Offset: 0x00107D2C
		public int getLen()
		{
			int num = 0;
			return num + this.notify.getLen();
		}

		// Token: 0x0400227A RID: 8826
		public const uint MsgID = 501154U;

		// Token: 0x0400227B RID: 8827
		public uint Sequence;

		// Token: 0x0400227C RID: 8828
		public NotifyInfo notify = new NotifyInfo();
	}
}
