using System;

namespace Protocol
{
	// Token: 0x0200088F RID: 2191
	[Protocol]
	public class WorldGuildDungeonStatueRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006667 RID: 26215 RVA: 0x0012F80C File Offset: 0x0012DC0C
		public uint GetMsgID()
		{
			return 608511U;
		}

		// Token: 0x06006668 RID: 26216 RVA: 0x0012F813 File Offset: 0x0012DC13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006669 RID: 26217 RVA: 0x0012F81B File Offset: 0x0012DC1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600666A RID: 26218 RVA: 0x0012F824 File Offset: 0x0012DC24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.figureStatue.Length);
			for (int i = 0; i < this.figureStatue.Length; i++)
			{
				this.figureStatue[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600666B RID: 26219 RVA: 0x0012F86C File Offset: 0x0012DC6C
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

		// Token: 0x0600666C RID: 26220 RVA: 0x0012F8C8 File Offset: 0x0012DCC8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.figureStatue.Length);
			for (int i = 0; i < this.figureStatue.Length; i++)
			{
				this.figureStatue[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600666D RID: 26221 RVA: 0x0012F910 File Offset: 0x0012DD10
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

		// Token: 0x0600666E RID: 26222 RVA: 0x0012F96C File Offset: 0x0012DD6C
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

		// Token: 0x04002DCD RID: 11725
		public const uint MsgID = 608511U;

		// Token: 0x04002DCE RID: 11726
		public uint Sequence;

		// Token: 0x04002DCF RID: 11727
		public FigureStatueInfo[] figureStatue = new FigureStatueInfo[0];
	}
}
