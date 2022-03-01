using System;

namespace Protocol
{
	// Token: 0x020009FB RID: 2555
	[Protocol]
	public class WorldNotifyRaceStart : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600719E RID: 29086 RVA: 0x00149EEF File Offset: 0x001482EF
		public uint GetMsgID()
		{
			return 606701U;
		}

		// Token: 0x0600719F RID: 29087 RVA: 0x00149EF6 File Offset: 0x001482F6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071A0 RID: 29088 RVA: 0x00149EFE File Offset: 0x001482FE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071A1 RID: 29089 RVA: 0x00149F08 File Offset: 0x00148308
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
			this.addr.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.raceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordLog);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordReplay);
			BaseDLL.encode_uint64(buffer, ref pos_, this.battleFlag);
		}

		// Token: 0x060071A2 RID: 29090 RVA: 0x00149FC0 File Offset: 0x001483C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
			this.addr.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.raceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new RacePlayerInfo[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new RacePlayerInfo();
				this.players[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordLog);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordReplay);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.battleFlag);
		}

		// Token: 0x060071A3 RID: 29091 RVA: 0x0014A08C File Offset: 0x0014848C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
			this.addr.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.raceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordLog);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordReplay);
			BaseDLL.encode_uint64(buffer, ref pos_, this.battleFlag);
		}

		// Token: 0x060071A4 RID: 29092 RVA: 0x0014A144 File Offset: 0x00148544
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
			this.addr.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.raceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new RacePlayerInfo[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new RacePlayerInfo();
				this.players[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordLog);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordReplay);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.battleFlag);
		}

		// Token: 0x060071A5 RID: 29093 RVA: 0x0014A210 File Offset: 0x00148610
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num += this.addr.getLen();
			num++;
			num += 4;
			num += 2;
			for (int i = 0; i < this.players.Length; i++)
			{
				num += this.players[i].getLen();
			}
			num++;
			num++;
			return num + 8;
		}

		// Token: 0x0400342B RID: 13355
		public const uint MsgID = 606701U;

		// Token: 0x0400342C RID: 13356
		public uint Sequence;

		// Token: 0x0400342D RID: 13357
		public ulong roleId;

		// Token: 0x0400342E RID: 13358
		public ulong sessionId;

		// Token: 0x0400342F RID: 13359
		public SockAddr addr = new SockAddr();

		// Token: 0x04003430 RID: 13360
		public byte raceType;

		// Token: 0x04003431 RID: 13361
		public uint dungeonId;

		// Token: 0x04003432 RID: 13362
		public RacePlayerInfo[] players = new RacePlayerInfo[0];

		// Token: 0x04003433 RID: 13363
		public byte isRecordLog;

		// Token: 0x04003434 RID: 13364
		public byte isRecordReplay;

		// Token: 0x04003435 RID: 13365
		public ulong battleFlag;
	}
}
