using System;

namespace Protocol
{
	// Token: 0x02000C5D RID: 3165
	[Protocol]
	public class SceneDailyTaskList : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008350 RID: 33616 RVA: 0x00171380 File Offset: 0x0016F780
		public uint GetMsgID()
		{
			return 501123U;
		}

		// Token: 0x06008351 RID: 33617 RVA: 0x00171387 File Offset: 0x0016F787
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008352 RID: 33618 RVA: 0x0017138F File Offset: 0x0016F78F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008353 RID: 33619 RVA: 0x00171398 File Offset: 0x0016F798
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008354 RID: 33620 RVA: 0x001713E0 File Offset: 0x0016F7E0
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

		// Token: 0x06008355 RID: 33621 RVA: 0x0017143C File Offset: 0x0016F83C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008356 RID: 33622 RVA: 0x00171484 File Offset: 0x0016F884
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

		// Token: 0x06008357 RID: 33623 RVA: 0x001714E0 File Offset: 0x0016F8E0
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

		// Token: 0x04003ED1 RID: 16081
		public const uint MsgID = 501123U;

		// Token: 0x04003ED2 RID: 16082
		public uint Sequence;

		// Token: 0x04003ED3 RID: 16083
		public MissionInfo[] tasks = new MissionInfo[0];
	}
}
