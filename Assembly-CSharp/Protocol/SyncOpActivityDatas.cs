using System;

namespace Protocol
{
	// Token: 0x02000A34 RID: 2612
	[Protocol]
	public class SyncOpActivityDatas : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007339 RID: 29497 RVA: 0x0014EBED File Offset: 0x0014CFED
		public uint GetMsgID()
		{
			return 501145U;
		}

		// Token: 0x0600733A RID: 29498 RVA: 0x0014EBF4 File Offset: 0x0014CFF4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600733B RID: 29499 RVA: 0x0014EBFC File Offset: 0x0014CFFC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600733C RID: 29500 RVA: 0x0014EC08 File Offset: 0x0014D008
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.datas.Length);
			for (int i = 0; i < this.datas.Length; i++)
			{
				this.datas[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600733D RID: 29501 RVA: 0x0014EC50 File Offset: 0x0014D050
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.datas = new OpActivityData[(int)num];
			for (int i = 0; i < this.datas.Length; i++)
			{
				this.datas[i] = new OpActivityData();
				this.datas[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600733E RID: 29502 RVA: 0x0014ECAC File Offset: 0x0014D0AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.datas.Length);
			for (int i = 0; i < this.datas.Length; i++)
			{
				this.datas[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600733F RID: 29503 RVA: 0x0014ECF4 File Offset: 0x0014D0F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.datas = new OpActivityData[(int)num];
			for (int i = 0; i < this.datas.Length; i++)
			{
				this.datas[i] = new OpActivityData();
				this.datas[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007340 RID: 29504 RVA: 0x0014ED50 File Offset: 0x0014D150
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.datas.Length; i++)
			{
				num += this.datas[i].getLen();
			}
			return num;
		}

		// Token: 0x04003580 RID: 13696
		public const uint MsgID = 501145U;

		// Token: 0x04003581 RID: 13697
		public uint Sequence;

		// Token: 0x04003582 RID: 13698
		public OpActivityData[] datas = new OpActivityData[0];
	}
}
