using System;

namespace Protocol
{
	// Token: 0x0200075F RID: 1887
	public class ChampionBattleRecord : IProtocolStream
	{
		// Token: 0x06005D7C RID: 23932 RVA: 0x00118BDC File Offset: 0x00116FDC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.order);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.winner);
			BaseDLL.encode_int8(buffer, ref pos_, this.isEnd);
		}

		// Token: 0x06005D7D RID: 23933 RVA: 0x00118C16 File Offset: 0x00117016
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.order);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.winner);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isEnd);
		}

		// Token: 0x06005D7E RID: 23934 RVA: 0x00118C50 File Offset: 0x00117050
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.order);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.winner);
			BaseDLL.encode_int8(buffer, ref pos_, this.isEnd);
		}

		// Token: 0x06005D7F RID: 23935 RVA: 0x00118C8A File Offset: 0x0011708A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.order);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.winner);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isEnd);
		}

		// Token: 0x06005D80 RID: 23936 RVA: 0x00118CC4 File Offset: 0x001170C4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			return num + 1;
		}

		// Token: 0x04002651 RID: 9809
		public uint order;

		// Token: 0x04002652 RID: 9810
		public ulong raceID;

		// Token: 0x04002653 RID: 9811
		public ulong winner;

		// Token: 0x04002654 RID: 9812
		public byte isEnd;
	}
}
