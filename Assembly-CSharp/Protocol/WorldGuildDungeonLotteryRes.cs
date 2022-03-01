using System;

namespace Protocol
{
	// Token: 0x0200088C RID: 2188
	[Protocol]
	public class WorldGuildDungeonLotteryRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600664C RID: 26188 RVA: 0x0012F578 File Offset: 0x0012D978
		public uint GetMsgID()
		{
			return 608508U;
		}

		// Token: 0x0600664D RID: 26189 RVA: 0x0012F57F File Offset: 0x0012D97F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600664E RID: 26190 RVA: 0x0012F587 File Offset: 0x0012D987
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600664F RID: 26191 RVA: 0x0012F590 File Offset: 0x0012D990
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.lotteryItemVec.Length);
			for (int i = 0; i < this.lotteryItemVec.Length; i++)
			{
				this.lotteryItemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006650 RID: 26192 RVA: 0x0012F5E4 File Offset: 0x0012D9E4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.lotteryItemVec = new GuildDungeonLotteryItem[(int)num];
			for (int i = 0; i < this.lotteryItemVec.Length; i++)
			{
				this.lotteryItemVec[i] = new GuildDungeonLotteryItem();
				this.lotteryItemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006651 RID: 26193 RVA: 0x0012F64C File Offset: 0x0012DA4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.lotteryItemVec.Length);
			for (int i = 0; i < this.lotteryItemVec.Length; i++)
			{
				this.lotteryItemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006652 RID: 26194 RVA: 0x0012F6A0 File Offset: 0x0012DAA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.lotteryItemVec = new GuildDungeonLotteryItem[(int)num];
			for (int i = 0; i < this.lotteryItemVec.Length; i++)
			{
				this.lotteryItemVec[i] = new GuildDungeonLotteryItem();
				this.lotteryItemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006653 RID: 26195 RVA: 0x0012F708 File Offset: 0x0012DB08
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.lotteryItemVec.Length; i++)
			{
				num += this.lotteryItemVec[i].getLen();
			}
			return num;
		}

		// Token: 0x04002DC4 RID: 11716
		public const uint MsgID = 608508U;

		// Token: 0x04002DC5 RID: 11717
		public uint Sequence;

		// Token: 0x04002DC6 RID: 11718
		public uint result;

		// Token: 0x04002DC7 RID: 11719
		public GuildDungeonLotteryItem[] lotteryItemVec = new GuildDungeonLotteryItem[0];
	}
}
