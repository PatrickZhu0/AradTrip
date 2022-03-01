using System;

namespace Protocol
{
	// Token: 0x02000AAE RID: 2734
	public class ReplayHeader : IProtocolStream
	{
		// Token: 0x060076DE RID: 30430 RVA: 0x001578AC File Offset: 0x00155CAC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.magicCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.version);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
			BaseDLL.encode_int8(buffer, ref pos_, this.raceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pkDungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.battleFlag);
		}

		// Token: 0x060076DF RID: 30431 RVA: 0x00157964 File Offset: 0x00155D64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magicCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.version);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.raceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pkDungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new RacePlayerInfo[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new RacePlayerInfo();
				this.players[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.battleFlag);
		}

		// Token: 0x060076E0 RID: 30432 RVA: 0x00157A30 File Offset: 0x00155E30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.magicCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.version);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
			BaseDLL.encode_int8(buffer, ref pos_, this.raceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pkDungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.battleFlag);
		}

		// Token: 0x060076E1 RID: 30433 RVA: 0x00157AE8 File Offset: 0x00155EE8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magicCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.version);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.raceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pkDungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new RacePlayerInfo[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new RacePlayerInfo();
				this.players[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.battleFlag);
		}

		// Token: 0x060076E2 RID: 30434 RVA: 0x00157BB4 File Offset: 0x00155FB4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 8;
			num++;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.players.Length; i++)
			{
				num += this.players[i].getLen();
			}
			return num + 8;
		}

		// Token: 0x040037A1 RID: 14241
		public uint magicCode;

		// Token: 0x040037A2 RID: 14242
		public uint version;

		// Token: 0x040037A3 RID: 14243
		public uint startTime;

		// Token: 0x040037A4 RID: 14244
		public ulong sessionId;

		// Token: 0x040037A5 RID: 14245
		public byte raceType;

		// Token: 0x040037A6 RID: 14246
		public uint pkDungeonId;

		// Token: 0x040037A7 RID: 14247
		public uint duration;

		// Token: 0x040037A8 RID: 14248
		public RacePlayerInfo[] players = new RacePlayerInfo[0];

		// Token: 0x040037A9 RID: 14249
		public ulong battleFlag;
	}
}
