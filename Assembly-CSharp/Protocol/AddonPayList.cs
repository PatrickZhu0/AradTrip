using System;

namespace Protocol
{
	// Token: 0x02000CA2 RID: 3234
	[Protocol]
	public class AddonPayList : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008569 RID: 34153 RVA: 0x0017657C File Offset: 0x0017497C
		public uint GetMsgID()
		{
			return 601724U;
		}

		// Token: 0x0600856A RID: 34154 RVA: 0x00176583 File Offset: 0x00174983
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600856B RID: 34155 RVA: 0x0017658B File Offset: 0x0017498B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600856C RID: 34156 RVA: 0x00176594 File Offset: 0x00174994
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600856D RID: 34157 RVA: 0x001765DC File Offset: 0x001749DC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new AddonPayData[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new AddonPayData();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600856E RID: 34158 RVA: 0x00176638 File Offset: 0x00174A38
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600856F RID: 34159 RVA: 0x00176680 File Offset: 0x00174A80
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new AddonPayData[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new AddonPayData();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06008570 RID: 34160 RVA: 0x001766DC File Offset: 0x00174ADC
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.data.Length; i++)
			{
				num += this.data[i].getLen();
			}
			return num;
		}

		// Token: 0x04003FF6 RID: 16374
		public const uint MsgID = 601724U;

		// Token: 0x04003FF7 RID: 16375
		public uint Sequence;

		// Token: 0x04003FF8 RID: 16376
		public AddonPayData[] data = new AddonPayData[0];
	}
}
