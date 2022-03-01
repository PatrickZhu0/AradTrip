using System;

namespace Protocol
{
	// Token: 0x02000CA3 RID: 3235
	[Protocol]
	public class AddPayData : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008572 RID: 34162 RVA: 0x0017672C File Offset: 0x00174B2C
		public uint GetMsgID()
		{
			return 601723U;
		}

		// Token: 0x06008573 RID: 34163 RVA: 0x00176733 File Offset: 0x00174B33
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008574 RID: 34164 RVA: 0x0017673B File Offset: 0x00174B3B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008575 RID: 34165 RVA: 0x00176744 File Offset: 0x00174B44
		public void encode(byte[] buffer, ref int pos_)
		{
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x06008576 RID: 34166 RVA: 0x00176753 File Offset: 0x00174B53
		public void decode(byte[] buffer, ref int pos_)
		{
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x06008577 RID: 34167 RVA: 0x00176762 File Offset: 0x00174B62
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x06008578 RID: 34168 RVA: 0x00176771 File Offset: 0x00174B71
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x06008579 RID: 34169 RVA: 0x00176780 File Offset: 0x00174B80
		public int getLen()
		{
			int num = 0;
			return num + this.data.getLen();
		}

		// Token: 0x04003FF9 RID: 16377
		public const uint MsgID = 601723U;

		// Token: 0x04003FFA RID: 16378
		public uint Sequence;

		// Token: 0x04003FFB RID: 16379
		public AddonPayData data = new AddonPayData();
	}
}
