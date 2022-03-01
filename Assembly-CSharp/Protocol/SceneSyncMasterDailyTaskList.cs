using System;

namespace Protocol
{
	// Token: 0x02000C6B RID: 3179
	[Protocol]
	public class SceneSyncMasterDailyTaskList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083CE RID: 33742 RVA: 0x00171E80 File Offset: 0x00170280
		public uint GetMsgID()
		{
			return 501159U;
		}

		// Token: 0x060083CF RID: 33743 RVA: 0x00171E87 File Offset: 0x00170287
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083D0 RID: 33744 RVA: 0x00171E8F File Offset: 0x0017028F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083D1 RID: 33745 RVA: 0x00171E98 File Offset: 0x00170298
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083D2 RID: 33746 RVA: 0x00171EE0 File Offset: 0x001702E0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.tasks = new MissionInfo[(int)num];
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i] = new MissionInfo();
				this.tasks[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060083D3 RID: 33747 RVA: 0x00171F3C File Offset: 0x0017033C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083D4 RID: 33748 RVA: 0x00171F84 File Offset: 0x00170384
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.tasks = new MissionInfo[(int)num];
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i] = new MissionInfo();
				this.tasks[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060083D5 RID: 33749 RVA: 0x00171FE0 File Offset: 0x001703E0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.tasks.Length; i++)
			{
				num += this.tasks[i].getLen();
			}
			return num;
		}

		// Token: 0x04003EFA RID: 16122
		public const uint MsgID = 501159U;

		// Token: 0x04003EFB RID: 16123
		public uint Sequence;

		// Token: 0x04003EFC RID: 16124
		public MissionInfo[] tasks = new MissionInfo[0];
	}
}
