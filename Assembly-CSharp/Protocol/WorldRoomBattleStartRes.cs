using System;

namespace Protocol
{
	// Token: 0x02000AF1 RID: 2801
	[Protocol]
	public class WorldRoomBattleStartRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078C4 RID: 30916 RVA: 0x0015C990 File Offset: 0x0015AD90
		public uint GetMsgID()
		{
			return 607836U;
		}

		// Token: 0x060078C5 RID: 30917 RVA: 0x0015C997 File Offset: 0x0015AD97
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078C6 RID: 30918 RVA: 0x0015C99F File Offset: 0x0015AD9F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078C7 RID: 30919 RVA: 0x0015C9A8 File Offset: 0x0015ADA8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078C8 RID: 30920 RVA: 0x0015C9B8 File Offset: 0x0015ADB8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078C9 RID: 30921 RVA: 0x0015C9C8 File Offset: 0x0015ADC8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060078CA RID: 30922 RVA: 0x0015C9D8 File Offset: 0x0015ADD8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060078CB RID: 30923 RVA: 0x0015C9E8 File Offset: 0x0015ADE8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040038FD RID: 14589
		public const uint MsgID = 607836U;

		// Token: 0x040038FE RID: 14590
		public uint Sequence;

		// Token: 0x040038FF RID: 14591
		public uint result;
	}
}
