using System;

namespace Protocol
{
	// Token: 0x02000876 RID: 2166
	[Protocol]
	public class WorldFigureStatueSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006598 RID: 26008 RVA: 0x0012E040 File Offset: 0x0012C440
		public uint GetMsgID()
		{
			return 600108U;
		}

		// Token: 0x06006599 RID: 26009 RVA: 0x0012E047 File Offset: 0x0012C447
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600659A RID: 26010 RVA: 0x0012E04F File Offset: 0x0012C44F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600659B RID: 26011 RVA: 0x0012E058 File Offset: 0x0012C458
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.figureStatue.Length);
			for (int i = 0; i < this.figureStatue.Length; i++)
			{
				this.figureStatue[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600659C RID: 26012 RVA: 0x0012E0A0 File Offset: 0x0012C4A0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.figureStatue = new FigureStatueInfo[(int)num];
			for (int i = 0; i < this.figureStatue.Length; i++)
			{
				this.figureStatue[i] = new FigureStatueInfo();
				this.figureStatue[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600659D RID: 26013 RVA: 0x0012E0FC File Offset: 0x0012C4FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.figureStatue.Length);
			for (int i = 0; i < this.figureStatue.Length; i++)
			{
				this.figureStatue[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600659E RID: 26014 RVA: 0x0012E144 File Offset: 0x0012C544
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.figureStatue = new FigureStatueInfo[(int)num];
			for (int i = 0; i < this.figureStatue.Length; i++)
			{
				this.figureStatue[i] = new FigureStatueInfo();
				this.figureStatue[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600659F RID: 26015 RVA: 0x0012E1A0 File Offset: 0x0012C5A0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.figureStatue.Length; i++)
			{
				num += this.figureStatue[i].getLen();
			}
			return num;
		}

		// Token: 0x04002D81 RID: 11649
		public const uint MsgID = 600108U;

		// Token: 0x04002D82 RID: 11650
		public uint Sequence;

		// Token: 0x04002D83 RID: 11651
		public FigureStatueInfo[] figureStatue = new FigureStatueInfo[0];
	}
}
