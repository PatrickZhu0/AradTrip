using System;

namespace Protocol
{
	// Token: 0x02000843 RID: 2115
	[Protocol]
	public class WorldGuildUpgradeBuilding : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063CD RID: 25549 RVA: 0x0012B0D0 File Offset: 0x001294D0
		public uint GetMsgID()
		{
			return 601927U;
		}

		// Token: 0x060063CE RID: 25550 RVA: 0x0012B0D7 File Offset: 0x001294D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063CF RID: 25551 RVA: 0x0012B0DF File Offset: 0x001294DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063D0 RID: 25552 RVA: 0x0012B0E8 File Offset: 0x001294E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060063D1 RID: 25553 RVA: 0x0012B0F8 File Offset: 0x001294F8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060063D2 RID: 25554 RVA: 0x0012B108 File Offset: 0x00129508
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060063D3 RID: 25555 RVA: 0x0012B118 File Offset: 0x00129518
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060063D4 RID: 25556 RVA: 0x0012B128 File Offset: 0x00129528
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002CCA RID: 11466
		public const uint MsgID = 601927U;

		// Token: 0x04002CCB RID: 11467
		public uint Sequence;

		// Token: 0x04002CCC RID: 11468
		public byte type;
	}
}
