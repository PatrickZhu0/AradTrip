using System;

namespace Protocol
{
	// Token: 0x02000989 RID: 2441
	[Protocol]
	public class SceneMagicCardCompOneKeyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E23 RID: 28195 RVA: 0x0013F2B4 File Offset: 0x0013D6B4
		public uint GetMsgID()
		{
			return 501058U;
		}

		// Token: 0x06006E24 RID: 28196 RVA: 0x0013F2BB File Offset: 0x0013D6BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E25 RID: 28197 RVA: 0x0013F2C3 File Offset: 0x0013D6C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E26 RID: 28198 RVA: 0x0013F2CC File Offset: 0x0013D6CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_int8(buffer, ref pos_, this.endReason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.compTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.consumeBindGolds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.comsumeGolds);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E27 RID: 28199 RVA: 0x0013F358 File Offset: 0x0013D758
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.endReason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.compTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.consumeBindGolds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.comsumeGolds);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E28 RID: 28200 RVA: 0x0013F3F8 File Offset: 0x0013D7F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_int8(buffer, ref pos_, this.endReason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.compTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.consumeBindGolds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.comsumeGolds);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E29 RID: 28201 RVA: 0x0013F484 File Offset: 0x0013D884
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.endReason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.compTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.consumeBindGolds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.comsumeGolds);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E2A RID: 28202 RVA: 0x0013F524 File Offset: 0x0013D924
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x040031E2 RID: 12770
		public const uint MsgID = 501058U;

		// Token: 0x040031E3 RID: 12771
		public uint Sequence;

		// Token: 0x040031E4 RID: 12772
		public uint code;

		// Token: 0x040031E5 RID: 12773
		public byte endReason;

		// Token: 0x040031E6 RID: 12774
		public uint compTimes;

		// Token: 0x040031E7 RID: 12775
		public uint consumeBindGolds;

		// Token: 0x040031E8 RID: 12776
		public uint comsumeGolds;

		// Token: 0x040031E9 RID: 12777
		public ItemReward[] items = new ItemReward[0];
	}
}
