using System;

namespace Protocol
{
	// Token: 0x02000772 RID: 1906
	[Protocol]
	public class SceneChampionAllGambleInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E15 RID: 24085 RVA: 0x0011A3F8 File Offset: 0x001187F8
		public uint GetMsgID()
		{
			return 509835U;
		}

		// Token: 0x06005E16 RID: 24086 RVA: 0x0011A3FF File Offset: 0x001187FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E17 RID: 24087 RVA: 0x0011A407 File Offset: 0x00118807
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E18 RID: 24088 RVA: 0x0011A410 File Offset: 0x00118810
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E19 RID: 24089 RVA: 0x0011A458 File Offset: 0x00118858
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new GambleInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new GambleInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E1A RID: 24090 RVA: 0x0011A4B4 File Offset: 0x001188B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E1B RID: 24091 RVA: 0x0011A4FC File Offset: 0x001188FC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new GambleInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new GambleInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E1C RID: 24092 RVA: 0x0011A558 File Offset: 0x00118958
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.infos.Length; i++)
			{
				num += this.infos[i].getLen();
			}
			return num;
		}

		// Token: 0x04002695 RID: 9877
		public const uint MsgID = 509835U;

		// Token: 0x04002696 RID: 9878
		public uint Sequence;

		// Token: 0x04002697 RID: 9879
		public GambleInfo[] infos = new GambleInfo[0];
	}
}
