using System;

namespace Protocol
{
	// Token: 0x02000A35 RID: 2613
	[Protocol]
	public class SyncOpActivityTasks : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007342 RID: 29506 RVA: 0x0014EDA1 File Offset: 0x0014D1A1
		public uint GetMsgID()
		{
			return 501146U;
		}

		// Token: 0x06007343 RID: 29507 RVA: 0x0014EDA8 File Offset: 0x0014D1A8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007344 RID: 29508 RVA: 0x0014EDB0 File Offset: 0x0014D1B0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007345 RID: 29509 RVA: 0x0014EDBC File Offset: 0x0014D1BC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007346 RID: 29510 RVA: 0x0014EE04 File Offset: 0x0014D204
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.tasks = new OpActTask[(int)num];
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i] = new OpActTask();
				this.tasks[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007347 RID: 29511 RVA: 0x0014EE60 File Offset: 0x0014D260
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007348 RID: 29512 RVA: 0x0014EEA8 File Offset: 0x0014D2A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.tasks = new OpActTask[(int)num];
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i] = new OpActTask();
				this.tasks[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007349 RID: 29513 RVA: 0x0014EF04 File Offset: 0x0014D304
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

		// Token: 0x04003583 RID: 13699
		public const uint MsgID = 501146U;

		// Token: 0x04003584 RID: 13700
		public uint Sequence;

		// Token: 0x04003585 RID: 13701
		public OpActTask[] tasks = new OpActTask[0];
	}
}
