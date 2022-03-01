using System;

namespace Protocol
{
	// Token: 0x02000983 RID: 2435
	[Protocol]
	public class SceneItemDepositGetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DED RID: 28141 RVA: 0x0013ED65 File Offset: 0x0013D165
		public uint GetMsgID()
		{
			return 501052U;
		}

		// Token: 0x06006DEE RID: 28142 RVA: 0x0013ED6C File Offset: 0x0013D16C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DEF RID: 28143 RVA: 0x0013ED74 File Offset: 0x0013D174
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DF0 RID: 28144 RVA: 0x0013ED7D File Offset: 0x0013D17D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
		}

		// Token: 0x06006DF1 RID: 28145 RVA: 0x0013ED8D File Offset: 0x0013D18D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
		}

		// Token: 0x06006DF2 RID: 28146 RVA: 0x0013ED9D File Offset: 0x0013D19D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
		}

		// Token: 0x06006DF3 RID: 28147 RVA: 0x0013EDAD File Offset: 0x0013D1AD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
		}

		// Token: 0x06006DF4 RID: 28148 RVA: 0x0013EDC0 File Offset: 0x0013D1C0
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040031C6 RID: 12742
		public const uint MsgID = 501052U;

		// Token: 0x040031C7 RID: 12743
		public uint Sequence;

		// Token: 0x040031C8 RID: 12744
		public ulong guid;
	}
}
