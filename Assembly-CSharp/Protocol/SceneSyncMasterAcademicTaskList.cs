using System;

namespace Protocol
{
	// Token: 0x02000C6C RID: 3180
	[Protocol]
	public class SceneSyncMasterAcademicTaskList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083D7 RID: 33751 RVA: 0x00172031 File Offset: 0x00170431
		public uint GetMsgID()
		{
			return 501160U;
		}

		// Token: 0x060083D8 RID: 33752 RVA: 0x00172038 File Offset: 0x00170438
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083D9 RID: 33753 RVA: 0x00172040 File Offset: 0x00170440
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083DA RID: 33754 RVA: 0x0017204C File Offset: 0x0017044C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083DB RID: 33755 RVA: 0x00172094 File Offset: 0x00170494
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

		// Token: 0x060083DC RID: 33756 RVA: 0x001720F0 File Offset: 0x001704F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083DD RID: 33757 RVA: 0x00172138 File Offset: 0x00170538
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

		// Token: 0x060083DE RID: 33758 RVA: 0x00172194 File Offset: 0x00170594
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

		// Token: 0x04003EFD RID: 16125
		public const uint MsgID = 501160U;

		// Token: 0x04003EFE RID: 16126
		public uint Sequence;

		// Token: 0x04003EFF RID: 16127
		public MissionInfo[] tasks = new MissionInfo[0];
	}
}
