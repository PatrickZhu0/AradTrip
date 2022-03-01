using System;

namespace Protocol
{
	// Token: 0x02000C5F RID: 3167
	[Protocol]
	public class SceneAchievementTaskList : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008362 RID: 33634 RVA: 0x001715A8 File Offset: 0x0016F9A8
		public uint GetMsgID()
		{
			return 501125U;
		}

		// Token: 0x06008363 RID: 33635 RVA: 0x001715AF File Offset: 0x0016F9AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008364 RID: 33636 RVA: 0x001715B7 File Offset: 0x0016F9B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008365 RID: 33637 RVA: 0x001715C0 File Offset: 0x0016F9C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008366 RID: 33638 RVA: 0x00171608 File Offset: 0x0016FA08
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

		// Token: 0x06008367 RID: 33639 RVA: 0x00171664 File Offset: 0x0016FA64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008368 RID: 33640 RVA: 0x001716AC File Offset: 0x0016FAAC
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

		// Token: 0x06008369 RID: 33641 RVA: 0x00171708 File Offset: 0x0016FB08
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

		// Token: 0x04003ED7 RID: 16087
		public const uint MsgID = 501125U;

		// Token: 0x04003ED8 RID: 16088
		public uint Sequence;

		// Token: 0x04003ED9 RID: 16089
		public MissionInfo[] tasks = new MissionInfo[0];
	}
}
