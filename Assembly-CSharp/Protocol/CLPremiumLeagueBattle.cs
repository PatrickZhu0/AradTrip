using System;

namespace Protocol
{
	// Token: 0x02000A66 RID: 2662
	public class CLPremiumLeagueBattle : IProtocolStream
	{
		// Token: 0x060074C8 RID: 29896 RVA: 0x00152488 File Offset: 0x00150888
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			this.fighter1.encode(buffer, ref pos_);
			this.fighter2.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.isEnd);
			BaseDLL.encode_uint64(buffer, ref pos_, this.winnerId);
			this.relayAddr.encode(buffer, ref pos_);
		}

		// Token: 0x060074C9 RID: 29897 RVA: 0x001524F4 File Offset: 0x001508F4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			this.fighter1.decode(buffer, ref pos_);
			this.fighter2.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isEnd);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.winnerId);
			this.relayAddr.decode(buffer, ref pos_);
		}

		// Token: 0x060074CA RID: 29898 RVA: 0x00152560 File Offset: 0x00150960
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			this.fighter1.encode(buffer, ref pos_);
			this.fighter2.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.isEnd);
			BaseDLL.encode_uint64(buffer, ref pos_, this.winnerId);
			this.relayAddr.encode(buffer, ref pos_);
		}

		// Token: 0x060074CB RID: 29899 RVA: 0x001525CC File Offset: 0x001509CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			this.fighter1.decode(buffer, ref pos_);
			this.fighter2.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isEnd);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.winnerId);
			this.relayAddr.decode(buffer, ref pos_);
		}

		// Token: 0x060074CC RID: 29900 RVA: 0x00152638 File Offset: 0x00150A38
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num += this.fighter1.getLen();
			num += this.fighter2.getLen();
			num++;
			num += 8;
			return num + this.relayAddr.getLen();
		}

		// Token: 0x04003652 RID: 13906
		public ulong raceId;

		// Token: 0x04003653 RID: 13907
		public byte type;

		// Token: 0x04003654 RID: 13908
		public PremiumLeagueBattleFighter fighter1 = new PremiumLeagueBattleFighter();

		// Token: 0x04003655 RID: 13909
		public PremiumLeagueBattleFighter fighter2 = new PremiumLeagueBattleFighter();

		// Token: 0x04003656 RID: 13910
		public byte isEnd;

		// Token: 0x04003657 RID: 13911
		public ulong winnerId;

		// Token: 0x04003658 RID: 13912
		public SockAddr relayAddr = new SockAddr();
	}
}
