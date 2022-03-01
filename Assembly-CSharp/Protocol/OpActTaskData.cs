using System;

namespace Protocol
{
	// Token: 0x02000A30 RID: 2608
	public class OpActTaskData : IProtocolStream
	{
		// Token: 0x06007321 RID: 29473 RVA: 0x0014CE5C File Offset: 0x0014B25C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.completeNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewards.Length);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.variables.Length);
			for (int j = 0; j < this.variables.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.variables[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.variables2.Length);
			for (int k = 0; k < this.variables2.Length; k++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.variables2[k]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.counters.Length);
			for (int l = 0; l < this.counters.Length; l++)
			{
				this.counters[l].encode(buffer, ref pos_);
			}
			byte[] str = StringHelper.StringToUTF8Bytes(this.taskName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.varProgressName.Length);
			for (int m = 0; m < this.varProgressName.Length; m++)
			{
				byte[] str2 = StringHelper.StringToUTF8Bytes(this.varProgressName[m]);
				BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevelLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountDailySubmitLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountTotalSubmitLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.resetType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cantAccept);
			BaseDLL.encode_uint32(buffer, ref pos_, this.eventType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.subType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountWeeklySubmitLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountTask);
		}

		// Token: 0x06007322 RID: 29474 RVA: 0x0014D058 File Offset: 0x0014B458
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.completeNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewards = new OpTaskReward[(int)num];
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i] = new OpTaskReward();
				this.rewards[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.variables = new uint[(int)num2];
			for (int j = 0; j < this.variables.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.variables[j]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.variables2 = new uint[(int)num3];
			for (int k = 0; k < this.variables2.Length; k++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.variables2[k]);
			}
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.counters = new CounterItem[(int)num4];
			for (int l = 0; l < this.counters.Length; l++)
			{
				this.counters[l] = new CounterItem();
				this.counters[l].decode(buffer, ref pos_);
			}
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[m]);
			}
			this.taskName = StringHelper.BytesToString(array);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.varProgressName = new string[(int)num6];
			for (int n = 0; n < this.varProgressName.Length; n++)
			{
				ushort num7 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
				byte[] array2 = new byte[(int)num7];
				for (int num8 = 0; num8 < (int)num7; num8++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array2[num8]);
				}
				this.varProgressName[n] = StringHelper.BytesToString(array2);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevelLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountDailySubmitLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountTotalSubmitLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resetType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cantAccept);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.eventType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.subType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountWeeklySubmitLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountTask);
		}

		// Token: 0x06007323 RID: 29475 RVA: 0x0014D304 File Offset: 0x0014B704
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.completeNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewards.Length);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.variables.Length);
			for (int j = 0; j < this.variables.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.variables[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.variables2.Length);
			for (int k = 0; k < this.variables2.Length; k++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.variables2[k]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.counters.Length);
			for (int l = 0; l < this.counters.Length; l++)
			{
				this.counters[l].encode(buffer, ref pos_);
			}
			byte[] str = StringHelper.StringToUTF8Bytes(this.taskName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.varProgressName.Length);
			for (int m = 0; m < this.varProgressName.Length; m++)
			{
				byte[] str2 = StringHelper.StringToUTF8Bytes(this.varProgressName[m]);
				BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevelLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountDailySubmitLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountTotalSubmitLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.resetType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cantAccept);
			BaseDLL.encode_uint32(buffer, ref pos_, this.eventType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.subType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountWeeklySubmitLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountTask);
		}

		// Token: 0x06007324 RID: 29476 RVA: 0x0014D504 File Offset: 0x0014B904
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.completeNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewards = new OpTaskReward[(int)num];
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i] = new OpTaskReward();
				this.rewards[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.variables = new uint[(int)num2];
			for (int j = 0; j < this.variables.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.variables[j]);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.variables2 = new uint[(int)num3];
			for (int k = 0; k < this.variables2.Length; k++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.variables2[k]);
			}
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.counters = new CounterItem[(int)num4];
			for (int l = 0; l < this.counters.Length; l++)
			{
				this.counters[l] = new CounterItem();
				this.counters[l].decode(buffer, ref pos_);
			}
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[m]);
			}
			this.taskName = StringHelper.BytesToString(array);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.varProgressName = new string[(int)num6];
			for (int n = 0; n < this.varProgressName.Length; n++)
			{
				ushort num7 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
				byte[] array2 = new byte[(int)num7];
				for (int num8 = 0; num8 < (int)num7; num8++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array2[num8]);
				}
				this.varProgressName[n] = StringHelper.BytesToString(array2);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevelLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountDailySubmitLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountTotalSubmitLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resetType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cantAccept);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.eventType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.subType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountWeeklySubmitLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountTask);
		}

		// Token: 0x06007325 RID: 29477 RVA: 0x0014D7B0 File Offset: 0x0014BBB0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.rewards.Length; i++)
			{
				num += this.rewards[i].getLen();
			}
			num += 2 + 4 * this.variables.Length;
			num += 2 + 4 * this.variables2.Length;
			num += 2;
			for (int j = 0; j < this.counters.Length; j++)
			{
				num += this.counters[j].getLen();
			}
			byte[] array = StringHelper.StringToUTF8Bytes(this.taskName);
			num += 2 + array.Length;
			num += 2;
			for (int k = 0; k < this.varProgressName.Length; k++)
			{
				byte[] array2 = StringHelper.StringToUTF8Bytes(this.varProgressName[k]);
				num += 2 + array2.Length;
			}
			num += 2;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003553 RID: 13651
		public uint dataid;

		// Token: 0x04003554 RID: 13652
		public uint completeNum;

		// Token: 0x04003555 RID: 13653
		public OpTaskReward[] rewards = new OpTaskReward[0];

		// Token: 0x04003556 RID: 13654
		public uint[] variables = new uint[0];

		// Token: 0x04003557 RID: 13655
		public uint[] variables2 = new uint[0];

		// Token: 0x04003558 RID: 13656
		public CounterItem[] counters = new CounterItem[0];

		// Token: 0x04003559 RID: 13657
		public string taskName;

		// Token: 0x0400355A RID: 13658
		public string[] varProgressName = new string[0];

		// Token: 0x0400355B RID: 13659
		public ushort playerLevelLimit;

		// Token: 0x0400355C RID: 13660
		public uint accountDailySubmitLimit;

		// Token: 0x0400355D RID: 13661
		public uint accountTotalSubmitLimit;

		// Token: 0x0400355E RID: 13662
		public uint resetType;

		// Token: 0x0400355F RID: 13663
		public uint cantAccept;

		// Token: 0x04003560 RID: 13664
		public uint eventType;

		// Token: 0x04003561 RID: 13665
		public uint subType;

		// Token: 0x04003562 RID: 13666
		public uint accountWeeklySubmitLimit;

		// Token: 0x04003563 RID: 13667
		public uint accountTask;
	}
}
