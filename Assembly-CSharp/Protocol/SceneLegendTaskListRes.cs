using System;

namespace Protocol
{
	// Token: 0x02000C66 RID: 3174
	[Protocol]
	public class SceneLegendTaskListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083A1 RID: 33697 RVA: 0x00171AE8 File Offset: 0x0016FEE8
		public uint GetMsgID()
		{
			return 501114U;
		}

		// Token: 0x060083A2 RID: 33698 RVA: 0x00171AEF File Offset: 0x0016FEEF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083A3 RID: 33699 RVA: 0x00171AF7 File Offset: 0x0016FEF7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083A4 RID: 33700 RVA: 0x00171B00 File Offset: 0x0016FF00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083A5 RID: 33701 RVA: 0x00171B48 File Offset: 0x0016FF48
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

		// Token: 0x060083A6 RID: 33702 RVA: 0x00171BA4 File Offset: 0x0016FFA4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060083A7 RID: 33703 RVA: 0x00171BEC File Offset: 0x0016FFEC
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

		// Token: 0x060083A8 RID: 33704 RVA: 0x00171C48 File Offset: 0x00170048
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

		// Token: 0x04003EEB RID: 16107
		public const uint MsgID = 501114U;

		// Token: 0x04003EEC RID: 16108
		public uint Sequence;

		// Token: 0x04003EED RID: 16109
		public MissionInfo[] tasks = new MissionInfo[0];
	}
}
