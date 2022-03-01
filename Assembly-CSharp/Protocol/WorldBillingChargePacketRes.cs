using System;

namespace Protocol
{
	// Token: 0x02000C32 RID: 3122
	[Protocol]
	public class WorldBillingChargePacketRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600822A RID: 33322 RVA: 0x0016F118 File Offset: 0x0016D518
		public uint GetMsgID()
		{
			return 604010U;
		}

		// Token: 0x0600822B RID: 33323 RVA: 0x0016F11F File Offset: 0x0016D51F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600822C RID: 33324 RVA: 0x0016F127 File Offset: 0x0016D527
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600822D RID: 33325 RVA: 0x0016F130 File Offset: 0x0016D530
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.goods.Length);
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600822E RID: 33326 RVA: 0x0016F178 File Offset: 0x0016D578
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.goods = new ChargePacket[(int)num];
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i] = new ChargePacket();
				this.goods[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600822F RID: 33327 RVA: 0x0016F1D4 File Offset: 0x0016D5D4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.goods.Length);
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008230 RID: 33328 RVA: 0x0016F21C File Offset: 0x0016D61C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.goods = new ChargePacket[(int)num];
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i] = new ChargePacket();
				this.goods[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06008231 RID: 33329 RVA: 0x0016F278 File Offset: 0x0016D678
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.goods.Length; i++)
			{
				num += this.goods[i].getLen();
			}
			return num;
		}

		// Token: 0x04003E30 RID: 15920
		public const uint MsgID = 604010U;

		// Token: 0x04003E31 RID: 15921
		public uint Sequence;

		// Token: 0x04003E32 RID: 15922
		public ChargePacket[] goods = new ChargePacket[0];
	}
}
