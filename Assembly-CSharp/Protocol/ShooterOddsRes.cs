using System;

namespace Protocol
{
	// Token: 0x02000735 RID: 1845
	[Protocol]
	public class ShooterOddsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C29 RID: 23593 RVA: 0x001166D4 File Offset: 0x00114AD4
		public uint GetMsgID()
		{
			return 708304U;
		}

		// Token: 0x06005C2A RID: 23594 RVA: 0x001166DB File Offset: 0x00114ADB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C2B RID: 23595 RVA: 0x001166E3 File Offset: 0x00114AE3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C2C RID: 23596 RVA: 0x001166EC File Offset: 0x00114AEC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.oddsList.Length);
			for (int i = 0; i < this.oddsList.Length; i++)
			{
				this.oddsList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C2D RID: 23597 RVA: 0x00116734 File Offset: 0x00114B34
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.oddsList = new OddsRateInfo[(int)num];
			for (int i = 0; i < this.oddsList.Length; i++)
			{
				this.oddsList[i] = new OddsRateInfo();
				this.oddsList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C2E RID: 23598 RVA: 0x00116790 File Offset: 0x00114B90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.oddsList.Length);
			for (int i = 0; i < this.oddsList.Length; i++)
			{
				this.oddsList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C2F RID: 23599 RVA: 0x001167D8 File Offset: 0x00114BD8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.oddsList = new OddsRateInfo[(int)num];
			for (int i = 0; i < this.oddsList.Length; i++)
			{
				this.oddsList[i] = new OddsRateInfo();
				this.oddsList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C30 RID: 23600 RVA: 0x00116834 File Offset: 0x00114C34
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.oddsList.Length; i++)
			{
				num += this.oddsList[i].getLen();
			}
			return num;
		}

		// Token: 0x040025A0 RID: 9632
		public const uint MsgID = 708304U;

		// Token: 0x040025A1 RID: 9633
		public uint Sequence;

		// Token: 0x040025A2 RID: 9634
		public OddsRateInfo[] oddsList = new OddsRateInfo[0];
	}
}
