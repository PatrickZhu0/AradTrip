using System;

namespace Protocol
{
	// Token: 0x02000708 RID: 1800
	[Protocol]
	public class SceneBattleSelectOccuRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AC1 RID: 23233 RVA: 0x00113C14 File Offset: 0x00112014
		public uint GetMsgID()
		{
			return 508914U;
		}

		// Token: 0x06005AC2 RID: 23234 RVA: 0x00113C1B File Offset: 0x0011201B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AC3 RID: 23235 RVA: 0x00113C23 File Offset: 0x00112023
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AC4 RID: 23236 RVA: 0x00113C2C File Offset: 0x0011202C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005AC5 RID: 23237 RVA: 0x00113C3C File Offset: 0x0011203C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005AC6 RID: 23238 RVA: 0x00113C4C File Offset: 0x0011204C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005AC7 RID: 23239 RVA: 0x00113C5C File Offset: 0x0011205C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005AC8 RID: 23240 RVA: 0x00113C6C File Offset: 0x0011206C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040024EC RID: 9452
		public const uint MsgID = 508914U;

		// Token: 0x040024ED RID: 9453
		public uint Sequence;

		// Token: 0x040024EE RID: 9454
		public uint retCode;
	}
}
