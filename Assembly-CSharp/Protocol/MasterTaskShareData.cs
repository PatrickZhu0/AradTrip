using System;

namespace Protocol
{
	// Token: 0x02000C70 RID: 3184
	public class MasterTaskShareData : IProtocolStream
	{
		// Token: 0x060083FB RID: 33787 RVA: 0x0017238C File Offset: 0x0017078C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.academicTotalGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterDailyTaskGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterAcademicTaskGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterUplevelGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterGiveEquipGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterGiveGiftGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterTeamClearDungeonGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodTeachValue);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dailyTasks.Length);
			for (int i = 0; i < this.dailyTasks.Length; i++)
			{
				this.dailyTasks[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.academicTasks.Length);
			for (int j = 0; j < this.academicTasks.Length; j++)
			{
				this.academicTasks[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083FC RID: 33788 RVA: 0x0017247C File Offset: 0x0017087C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.academicTotalGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterDailyTaskGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterAcademicTaskGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterUplevelGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterGiveEquipGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterGiveGiftGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterTeamClearDungeonGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodTeachValue);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dailyTasks = new MissionInfo[(int)num];
			for (int i = 0; i < this.dailyTasks.Length; i++)
			{
				this.dailyTasks[i] = new MissionInfo();
				this.dailyTasks[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.academicTasks = new MissionInfo[(int)num2];
			for (int j = 0; j < this.academicTasks.Length; j++)
			{
				this.academicTasks[j] = new MissionInfo();
				this.academicTasks[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060083FD RID: 33789 RVA: 0x00172594 File Offset: 0x00170994
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.academicTotalGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterDailyTaskGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterAcademicTaskGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterUplevelGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterGiveEquipGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterGiveGiftGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.masterTeamClearDungeonGrowth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodTeachValue);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dailyTasks.Length);
			for (int i = 0; i < this.dailyTasks.Length; i++)
			{
				this.dailyTasks[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.academicTasks.Length);
			for (int j = 0; j < this.academicTasks.Length; j++)
			{
				this.academicTasks[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083FE RID: 33790 RVA: 0x00172684 File Offset: 0x00170A84
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.academicTotalGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterDailyTaskGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterAcademicTaskGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterUplevelGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterGiveEquipGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterGiveGiftGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.masterTeamClearDungeonGrowth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodTeachValue);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dailyTasks = new MissionInfo[(int)num];
			for (int i = 0; i < this.dailyTasks.Length; i++)
			{
				this.dailyTasks[i] = new MissionInfo();
				this.dailyTasks[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.academicTasks = new MissionInfo[(int)num2];
			for (int j = 0; j < this.academicTasks.Length; j++)
			{
				this.academicTasks[j] = new MissionInfo();
				this.academicTasks[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060083FF RID: 33791 RVA: 0x0017279C File Offset: 0x00170B9C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.dailyTasks.Length; i++)
			{
				num += this.dailyTasks[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.academicTasks.Length; j++)
			{
				num += this.academicTasks[j].getLen();
			}
			return num;
		}

		// Token: 0x04003F0A RID: 16138
		public uint academicTotalGrowth;

		// Token: 0x04003F0B RID: 16139
		public uint masterDailyTaskGrowth;

		// Token: 0x04003F0C RID: 16140
		public uint masterAcademicTaskGrowth;

		// Token: 0x04003F0D RID: 16141
		public uint masterUplevelGrowth;

		// Token: 0x04003F0E RID: 16142
		public uint masterGiveEquipGrowth;

		// Token: 0x04003F0F RID: 16143
		public uint masterGiveGiftGrowth;

		// Token: 0x04003F10 RID: 16144
		public uint masterTeamClearDungeonGrowth;

		// Token: 0x04003F11 RID: 16145
		public uint goodTeachValue;

		// Token: 0x04003F12 RID: 16146
		public MissionInfo[] dailyTasks = new MissionInfo[0];

		// Token: 0x04003F13 RID: 16147
		public MissionInfo[] academicTasks = new MissionInfo[0];
	}
}
