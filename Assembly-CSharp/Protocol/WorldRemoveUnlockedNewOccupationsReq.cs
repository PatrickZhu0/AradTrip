using System;

namespace Protocol
{
	// Token: 0x020006AF RID: 1711
	[Protocol]
	public class WorldRemoveUnlockedNewOccupationsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600583A RID: 22586 RVA: 0x0010C7B9 File Offset: 0x0010ABB9
		public uint GetMsgID()
		{
			return 608626U;
		}

		// Token: 0x0600583B RID: 22587 RVA: 0x0010C7C0 File Offset: 0x0010ABC0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600583C RID: 22588 RVA: 0x0010C7C8 File Offset: 0x0010ABC8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600583D RID: 22589 RVA: 0x0010C7D4 File Offset: 0x0010ABD4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.newOccus.Length);
			for (int i = 0; i < this.newOccus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.newOccus[i]);
			}
		}

		// Token: 0x0600583E RID: 22590 RVA: 0x0010C81C File Offset: 0x0010AC1C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.newOccus = new byte[(int)num];
			for (int i = 0; i < this.newOccus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.newOccus[i]);
			}
		}

		// Token: 0x0600583F RID: 22591 RVA: 0x0010C870 File Offset: 0x0010AC70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.newOccus.Length);
			for (int i = 0; i < this.newOccus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.newOccus[i]);
			}
		}

		// Token: 0x06005840 RID: 22592 RVA: 0x0010C8B8 File Offset: 0x0010ACB8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.newOccus = new byte[(int)num];
			for (int i = 0; i < this.newOccus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.newOccus[i]);
			}
		}

		// Token: 0x06005841 RID: 22593 RVA: 0x0010C90C File Offset: 0x0010AD0C
		public int getLen()
		{
			int num = 0;
			return num + (2 + this.newOccus.Length);
		}

		// Token: 0x0400231D RID: 8989
		public const uint MsgID = 608626U;

		// Token: 0x0400231E RID: 8990
		public uint Sequence;

		// Token: 0x0400231F RID: 8991
		public byte[] newOccus = new byte[0];
	}
}
