using System;

namespace Protocol
{
	// Token: 0x02000A25 RID: 2597
	[Protocol]
	public class WorldNewTitleTakeUpGuildPostRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007300 RID: 29440 RVA: 0x0014C9FC File Offset: 0x0014ADFC
		public uint GetMsgID()
		{
			return 609212U;
		}

		// Token: 0x06007301 RID: 29441 RVA: 0x0014CA03 File Offset: 0x0014AE03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007302 RID: 29442 RVA: 0x0014CA0B File Offset: 0x0014AE0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007303 RID: 29443 RVA: 0x0014CA14 File Offset: 0x0014AE14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.res);
		}

		// Token: 0x06007304 RID: 29444 RVA: 0x0014CA24 File Offset: 0x0014AE24
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.res);
		}

		// Token: 0x06007305 RID: 29445 RVA: 0x0014CA34 File Offset: 0x0014AE34
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.res);
		}

		// Token: 0x06007306 RID: 29446 RVA: 0x0014CA44 File Offset: 0x0014AE44
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.res);
		}

		// Token: 0x06007307 RID: 29447 RVA: 0x0014CA54 File Offset: 0x0014AE54
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040034D5 RID: 13525
		public const uint MsgID = 609212U;

		// Token: 0x040034D6 RID: 13526
		public uint Sequence;

		// Token: 0x040034D7 RID: 13527
		public uint res;
	}
}
