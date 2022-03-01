using System;

namespace Protocol
{
	// Token: 0x0200070A RID: 1802
	[Protocol]
	public class SceneBattleNotifySpoilsItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AD0 RID: 23248 RVA: 0x00113D68 File Offset: 0x00112168
		public uint GetMsgID()
		{
			return 508915U;
		}

		// Token: 0x06005AD1 RID: 23249 RVA: 0x00113D6F File Offset: 0x0011216F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AD2 RID: 23250 RVA: 0x00113D77 File Offset: 0x00112177
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AD3 RID: 23251 RVA: 0x00113D80 File Offset: 0x00112180
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.detailItems.Length);
			for (int i = 0; i < this.detailItems.Length; i++)
			{
				this.detailItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005AD4 RID: 23252 RVA: 0x00113DE4 File Offset: 0x001121E4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.detailItems = new DetailItem[(int)num];
			for (int i = 0; i < this.detailItems.Length; i++)
			{
				this.detailItems[i] = new DetailItem();
				this.detailItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005AD5 RID: 23253 RVA: 0x00113E5C File Offset: 0x0011225C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.detailItems.Length);
			for (int i = 0; i < this.detailItems.Length; i++)
			{
				this.detailItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005AD6 RID: 23254 RVA: 0x00113EC0 File Offset: 0x001122C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.detailItems = new DetailItem[(int)num];
			for (int i = 0; i < this.detailItems.Length; i++)
			{
				this.detailItems[i] = new DetailItem();
				this.detailItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005AD7 RID: 23255 RVA: 0x00113F38 File Offset: 0x00112338
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 2;
			for (int i = 0; i < this.detailItems.Length; i++)
			{
				num += this.detailItems[i].getLen();
			}
			return num;
		}

		// Token: 0x040024F2 RID: 9458
		public const uint MsgID = 508915U;

		// Token: 0x040024F3 RID: 9459
		public uint Sequence;

		// Token: 0x040024F4 RID: 9460
		public uint battleID;

		// Token: 0x040024F5 RID: 9461
		public ulong playerID;

		// Token: 0x040024F6 RID: 9462
		public DetailItem[] detailItems = new DetailItem[0];
	}
}
