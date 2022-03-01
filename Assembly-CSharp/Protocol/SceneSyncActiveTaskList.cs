using System;

namespace Protocol
{
	// Token: 0x02000675 RID: 1653
	[Protocol]
	public class SceneSyncActiveTaskList : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005648 RID: 22088 RVA: 0x00108C44 File Offset: 0x00107044
		public uint GetMsgID()
		{
			return 501129U;
		}

		// Token: 0x06005649 RID: 22089 RVA: 0x00108C4B File Offset: 0x0010704B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600564A RID: 22090 RVA: 0x00108C53 File Offset: 0x00107053
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600564B RID: 22091 RVA: 0x00108C5C File Offset: 0x0010705C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600564C RID: 22092 RVA: 0x00108CA4 File Offset: 0x001070A4
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

		// Token: 0x0600564D RID: 22093 RVA: 0x00108D00 File Offset: 0x00107100
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600564E RID: 22094 RVA: 0x00108D48 File Offset: 0x00107148
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

		// Token: 0x0600564F RID: 22095 RVA: 0x00108DA4 File Offset: 0x001071A4
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

		// Token: 0x04002246 RID: 8774
		public const uint MsgID = 501129U;

		// Token: 0x04002247 RID: 8775
		public uint Sequence;

		// Token: 0x04002248 RID: 8776
		public MissionInfo[] tasks = new MissionInfo[0];
	}
}
