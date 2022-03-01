using System;

namespace Protocol
{
	// Token: 0x02000C83 RID: 3203
	[Protocol]
	public class WorldNotifyNewRelation : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008464 RID: 33892 RVA: 0x00173014 File Offset: 0x00171414
		public uint GetMsgID()
		{
			return 601705U;
		}

		// Token: 0x06008465 RID: 33893 RVA: 0x0017301B File Offset: 0x0017141B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008466 RID: 33894 RVA: 0x00173023 File Offset: 0x00171423
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008467 RID: 33895 RVA: 0x0017302C File Offset: 0x0017142C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008468 RID: 33896 RVA: 0x0017302E File Offset: 0x0017142E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008469 RID: 33897 RVA: 0x00173030 File Offset: 0x00171430
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600846A RID: 33898 RVA: 0x00173032 File Offset: 0x00171432
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600846B RID: 33899 RVA: 0x00173034 File Offset: 0x00171434
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003F58 RID: 16216
		public const uint MsgID = 601705U;

		// Token: 0x04003F59 RID: 16217
		public uint Sequence;
	}
}
