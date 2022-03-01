using System;

namespace Protocol
{
	// Token: 0x020007ED RID: 2029
	[Protocol]
	public class WorldDungeonRollItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061C0 RID: 25024 RVA: 0x001243F4 File Offset: 0x001227F4
		public uint GetMsgID()
		{
			return 606817U;
		}

		// Token: 0x060061C1 RID: 25025 RVA: 0x001243FB File Offset: 0x001227FB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061C2 RID: 25026 RVA: 0x00124403 File Offset: 0x00122803
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061C3 RID: 25027 RVA: 0x0012440C File Offset: 0x0012280C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.dropIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x060061C4 RID: 25028 RVA: 0x0012442A File Offset: 0x0012282A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.dropIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x060061C5 RID: 25029 RVA: 0x00124448 File Offset: 0x00122848
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.dropIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x060061C6 RID: 25030 RVA: 0x00124466 File Offset: 0x00122866
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.dropIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x060061C7 RID: 25031 RVA: 0x00124484 File Offset: 0x00122884
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x040028B5 RID: 10421
		public const uint MsgID = 606817U;

		// Token: 0x040028B6 RID: 10422
		public uint Sequence;

		// Token: 0x040028B7 RID: 10423
		public byte dropIndex;

		// Token: 0x040028B8 RID: 10424
		public byte opType;
	}
}
