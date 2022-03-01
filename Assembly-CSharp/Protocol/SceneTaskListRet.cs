using System;

namespace Protocol
{
	// Token: 0x02000C57 RID: 3159
	[Protocol]
	public class SceneTaskListRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600831A RID: 33562 RVA: 0x00170CE1 File Offset: 0x0016F0E1
		public uint GetMsgID()
		{
			return 501106U;
		}

		// Token: 0x0600831B RID: 33563 RVA: 0x00170CE8 File Offset: 0x0016F0E8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600831C RID: 33564 RVA: 0x00170CF0 File Offset: 0x0016F0F0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600831D RID: 33565 RVA: 0x00170CFC File Offset: 0x0016F0FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600831E RID: 33566 RVA: 0x00170D44 File Offset: 0x0016F144
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

		// Token: 0x0600831F RID: 33567 RVA: 0x00170DA0 File Offset: 0x0016F1A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008320 RID: 33568 RVA: 0x00170DE8 File Offset: 0x0016F1E8
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

		// Token: 0x06008321 RID: 33569 RVA: 0x00170E44 File Offset: 0x0016F244
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

		// Token: 0x04003EBA RID: 16058
		public const uint MsgID = 501106U;

		// Token: 0x04003EBB RID: 16059
		public uint Sequence;

		// Token: 0x04003EBC RID: 16060
		public MissionInfo[] tasks = new MissionInfo[0];
	}
}
