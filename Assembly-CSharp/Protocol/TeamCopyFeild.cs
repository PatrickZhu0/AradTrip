using System;

namespace Protocol
{
	// Token: 0x02000BCD RID: 3021
	public class TeamCopyFeild : IProtocolStream
	{
		// Token: 0x06007EDC RID: 32476 RVA: 0x00168148 File Offset: 0x00166548
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.feildId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oddNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rebornTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.energyReviveTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.attackSquadList.Length);
			for (int i = 0; i < this.attackSquadList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.attackSquadList[i]);
			}
		}

		// Token: 0x06007EDD RID: 32477 RVA: 0x001681D8 File Offset: 0x001665D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.feildId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oddNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rebornTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.energyReviveTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.attackSquadList = new uint[(int)num];
			for (int i = 0; i < this.attackSquadList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.attackSquadList[i]);
			}
		}

		// Token: 0x06007EDE RID: 32478 RVA: 0x00168270 File Offset: 0x00166670
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.feildId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oddNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rebornTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.energyReviveTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.attackSquadList.Length);
			for (int i = 0; i < this.attackSquadList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.attackSquadList[i]);
			}
		}

		// Token: 0x06007EDF RID: 32479 RVA: 0x00168300 File Offset: 0x00166700
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.feildId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oddNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rebornTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.energyReviveTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.attackSquadList = new uint[(int)num];
			for (int i = 0; i < this.attackSquadList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.attackSquadList[i]);
			}
		}

		// Token: 0x06007EE0 RID: 32480 RVA: 0x00168398 File Offset: 0x00166798
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + (2 + 4 * this.attackSquadList.Length);
		}

		// Token: 0x04003C8F RID: 15503
		public uint feildId;

		// Token: 0x04003C90 RID: 15504
		public uint oddNum;

		// Token: 0x04003C91 RID: 15505
		public uint state;

		// Token: 0x04003C92 RID: 15506
		public uint rebornTime;

		// Token: 0x04003C93 RID: 15507
		public uint energyReviveTime;

		// Token: 0x04003C94 RID: 15508
		public uint[] attackSquadList = new uint[0];
	}
}
