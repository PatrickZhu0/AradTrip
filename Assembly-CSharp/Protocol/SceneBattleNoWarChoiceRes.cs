using System;

namespace Protocol
{
	// Token: 0x02000723 RID: 1827
	[Protocol]
	public class SceneBattleNoWarChoiceRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BAB RID: 23467 RVA: 0x00115840 File Offset: 0x00113C40
		public uint GetMsgID()
		{
			return 508944U;
		}

		// Token: 0x06005BAC RID: 23468 RVA: 0x00115847 File Offset: 0x00113C47
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BAD RID: 23469 RVA: 0x0011584F File Offset: 0x00113C4F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BAE RID: 23470 RVA: 0x00115858 File Offset: 0x00113C58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005BAF RID: 23471 RVA: 0x00115868 File Offset: 0x00113C68
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005BB0 RID: 23472 RVA: 0x00115878 File Offset: 0x00113C78
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005BB1 RID: 23473 RVA: 0x00115888 File Offset: 0x00113C88
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005BB2 RID: 23474 RVA: 0x00115898 File Offset: 0x00113C98
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400255F RID: 9567
		public const uint MsgID = 508944U;

		// Token: 0x04002560 RID: 9568
		public uint Sequence;

		// Token: 0x04002561 RID: 9569
		public uint retCode;
	}
}
