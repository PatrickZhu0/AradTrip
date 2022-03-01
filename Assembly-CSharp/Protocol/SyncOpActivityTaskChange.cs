using System;

namespace Protocol
{
	// Token: 0x02000A36 RID: 2614
	[Protocol]
	public class SyncOpActivityTaskChange : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600734B RID: 29515 RVA: 0x0014EF55 File Offset: 0x0014D355
		public uint GetMsgID()
		{
			return 501147U;
		}

		// Token: 0x0600734C RID: 29516 RVA: 0x0014EF5C File Offset: 0x0014D35C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600734D RID: 29517 RVA: 0x0014EF64 File Offset: 0x0014D364
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600734E RID: 29518 RVA: 0x0014EF70 File Offset: 0x0014D370
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600734F RID: 29519 RVA: 0x0014EFB8 File Offset: 0x0014D3B8
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

		// Token: 0x06007350 RID: 29520 RVA: 0x0014F014 File Offset: 0x0014D414
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007351 RID: 29521 RVA: 0x0014F05C File Offset: 0x0014D45C
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

		// Token: 0x06007352 RID: 29522 RVA: 0x0014F0B8 File Offset: 0x0014D4B8
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

		// Token: 0x04003586 RID: 13702
		public const uint MsgID = 501147U;

		// Token: 0x04003587 RID: 13703
		public uint Sequence;

		// Token: 0x04003588 RID: 13704
		public OpActTask[] tasks = new OpActTask[0];
	}
}
