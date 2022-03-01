using System;

namespace Protocol
{
	// Token: 0x0200071F RID: 1823
	[Protocol]
	public class BattleChoiceSkillReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B87 RID: 23431 RVA: 0x001154F5 File Offset: 0x001138F5
		public uint GetMsgID()
		{
			return 508940U;
		}

		// Token: 0x06005B88 RID: 23432 RVA: 0x001154FC File Offset: 0x001138FC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B89 RID: 23433 RVA: 0x00115504 File Offset: 0x00113904
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B8A RID: 23434 RVA: 0x0011550D File Offset: 0x0011390D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
		}

		// Token: 0x06005B8B RID: 23435 RVA: 0x0011551D File Offset: 0x0011391D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
		}

		// Token: 0x06005B8C RID: 23436 RVA: 0x0011552D File Offset: 0x0011392D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
		}

		// Token: 0x06005B8D RID: 23437 RVA: 0x0011553D File Offset: 0x0011393D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
		}

		// Token: 0x06005B8E RID: 23438 RVA: 0x00115550 File Offset: 0x00113950
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002550 RID: 9552
		public const uint MsgID = 508940U;

		// Token: 0x04002551 RID: 9553
		public uint Sequence;

		// Token: 0x04002552 RID: 9554
		public uint skillId;
	}
}
