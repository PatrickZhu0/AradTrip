using System;

namespace Protocol
{
	// Token: 0x02000C74 RID: 3188
	[Protocol]
	public class WorldReceiveMasterDailyTaskRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600841C RID: 33820 RVA: 0x00172A18 File Offset: 0x00170E18
		public uint GetMsgID()
		{
			return 601765U;
		}

		// Token: 0x0600841D RID: 33821 RVA: 0x00172A1F File Offset: 0x00170E1F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600841E RID: 33822 RVA: 0x00172A27 File Offset: 0x00170E27
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600841F RID: 33823 RVA: 0x00172A30 File Offset: 0x00170E30
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipeleId);
		}

		// Token: 0x06008420 RID: 33824 RVA: 0x00172A4E File Offset: 0x00170E4E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipeleId);
		}

		// Token: 0x06008421 RID: 33825 RVA: 0x00172A6C File Offset: 0x00170E6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipeleId);
		}

		// Token: 0x06008422 RID: 33826 RVA: 0x00172A8A File Offset: 0x00170E8A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipeleId);
		}

		// Token: 0x06008423 RID: 33827 RVA: 0x00172AA8 File Offset: 0x00170EA8
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x04003F1F RID: 16159
		public const uint MsgID = 601765U;

		// Token: 0x04003F20 RID: 16160
		public uint Sequence;

		// Token: 0x04003F21 RID: 16161
		public byte type;

		// Token: 0x04003F22 RID: 16162
		public ulong discipeleId;
	}
}
