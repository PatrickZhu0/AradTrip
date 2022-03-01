using System;

namespace Protocol
{
	// Token: 0x02000AAA RID: 2730
	public class ReplayInfo : IProtocolStream
	{
		// Token: 0x060076BD RID: 30397 RVA: 0x00157260 File Offset: 0x00155660
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.version);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.evaluation);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recordTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.fighters.Length);
			for (int i = 0; i < this.fighters.Length; i++)
			{
				this.fighters[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.viewNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x060076BE RID: 30398 RVA: 0x00157318 File Offset: 0x00155718
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.version);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.evaluation);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recordTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.fighters = new ReplayFighterInfo[(int)num];
			for (int i = 0; i < this.fighters.Length; i++)
			{
				this.fighters[i] = new ReplayFighterInfo();
				this.fighters[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.viewNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x060076BF RID: 30399 RVA: 0x001573E4 File Offset: 0x001557E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.version);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.evaluation);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recordTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.fighters.Length);
			for (int i = 0; i < this.fighters.Length; i++)
			{
				this.fighters[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.viewNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x060076C0 RID: 30400 RVA: 0x0015749C File Offset: 0x0015589C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.version);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.evaluation);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recordTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.fighters = new ReplayFighterInfo[(int)num];
			for (int i = 0; i < this.fighters.Length; i++)
			{
				this.fighters[i] = new ReplayFighterInfo();
				this.fighters[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.viewNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x060076C1 RID: 30401 RVA: 0x00157568 File Offset: 0x00155968
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num++;
			num++;
			num += 4;
			num++;
			num += 2;
			for (int i = 0; i < this.fighters.Length; i++)
			{
				num += this.fighters[i].getLen();
			}
			num += 4;
			return num + 4;
		}

		// Token: 0x0400378E RID: 14222
		public uint version;

		// Token: 0x0400378F RID: 14223
		public ulong raceId;

		// Token: 0x04003790 RID: 14224
		public byte type;

		// Token: 0x04003791 RID: 14225
		public byte evaluation;

		// Token: 0x04003792 RID: 14226
		public uint recordTime;

		// Token: 0x04003793 RID: 14227
		public byte result;

		// Token: 0x04003794 RID: 14228
		public ReplayFighterInfo[] fighters = new ReplayFighterInfo[0];

		// Token: 0x04003795 RID: 14229
		public uint viewNum;

		// Token: 0x04003796 RID: 14230
		public uint score;
	}
}
