using System;

namespace Protocol
{
	// Token: 0x0200078C RID: 1932
	[Protocol]
	public class WorldGetPlayerDailyTodosRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005EE1 RID: 24289 RVA: 0x0011C7BC File Offset: 0x0011ABBC
		public uint GetMsgID()
		{
			return 609302U;
		}

		// Token: 0x06005EE2 RID: 24290 RVA: 0x0011C7C3 File Offset: 0x0011ABC3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005EE3 RID: 24291 RVA: 0x0011C7CB File Offset: 0x0011ABCB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005EE4 RID: 24292 RVA: 0x0011C7D4 File Offset: 0x0011ABD4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dailyTodos.Length);
			for (int i = 0; i < this.dailyTodos.Length; i++)
			{
				this.dailyTodos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EE5 RID: 24293 RVA: 0x0011C81C File Offset: 0x0011AC1C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dailyTodos = new DailyTodoInfo[(int)num];
			for (int i = 0; i < this.dailyTodos.Length; i++)
			{
				this.dailyTodos[i] = new DailyTodoInfo();
				this.dailyTodos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EE6 RID: 24294 RVA: 0x0011C878 File Offset: 0x0011AC78
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dailyTodos.Length);
			for (int i = 0; i < this.dailyTodos.Length; i++)
			{
				this.dailyTodos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EE7 RID: 24295 RVA: 0x0011C8C0 File Offset: 0x0011ACC0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dailyTodos = new DailyTodoInfo[(int)num];
			for (int i = 0; i < this.dailyTodos.Length; i++)
			{
				this.dailyTodos[i] = new DailyTodoInfo();
				this.dailyTodos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EE8 RID: 24296 RVA: 0x0011C91C File Offset: 0x0011AD1C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.dailyTodos.Length; i++)
			{
				num += this.dailyTodos[i].getLen();
			}
			return num;
		}

		// Token: 0x04002717 RID: 10007
		public const uint MsgID = 609302U;

		// Token: 0x04002718 RID: 10008
		public uint Sequence;

		// Token: 0x04002719 RID: 10009
		public DailyTodoInfo[] dailyTodos = new DailyTodoInfo[0];
	}
}
