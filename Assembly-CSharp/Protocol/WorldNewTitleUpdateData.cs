using System;

namespace Protocol
{
	// Token: 0x02000A23 RID: 2595
	[Protocol]
	public class WorldNewTitleUpdateData : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072EE RID: 29422 RVA: 0x0014C81C File Offset: 0x0014AC1C
		public uint GetMsgID()
		{
			return 609207U;
		}

		// Token: 0x060072EF RID: 29423 RVA: 0x0014C823 File Offset: 0x0014AC23
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072F0 RID: 29424 RVA: 0x0014C82B File Offset: 0x0014AC2B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072F1 RID: 29425 RVA: 0x0014C834 File Offset: 0x0014AC34
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.updates.Length);
			for (int i = 0; i < this.updates.Length; i++)
			{
				this.updates[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060072F2 RID: 29426 RVA: 0x0014C87C File Offset: 0x0014AC7C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.updates = new PlayerTitleInfo[(int)num];
			for (int i = 0; i < this.updates.Length; i++)
			{
				this.updates[i] = new PlayerTitleInfo();
				this.updates[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060072F3 RID: 29427 RVA: 0x0014C8D8 File Offset: 0x0014ACD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.updates.Length);
			for (int i = 0; i < this.updates.Length; i++)
			{
				this.updates[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060072F4 RID: 29428 RVA: 0x0014C920 File Offset: 0x0014AD20
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.updates = new PlayerTitleInfo[(int)num];
			for (int i = 0; i < this.updates.Length; i++)
			{
				this.updates[i] = new PlayerTitleInfo();
				this.updates[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060072F5 RID: 29429 RVA: 0x0014C97C File Offset: 0x0014AD7C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.updates.Length; i++)
			{
				num += this.updates[i].getLen();
			}
			return num;
		}

		// Token: 0x040034D0 RID: 13520
		public const uint MsgID = 609207U;

		// Token: 0x040034D1 RID: 13521
		public uint Sequence;

		// Token: 0x040034D2 RID: 13522
		public PlayerTitleInfo[] updates = new PlayerTitleInfo[0];
	}
}
