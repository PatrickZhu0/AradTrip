using System;

namespace Protocol
{
	// Token: 0x02000B86 RID: 2950
	[Protocol]
	public class WorldTransferTeammaster : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D11 RID: 32017 RVA: 0x00164878 File Offset: 0x00162C78
		public uint GetMsgID()
		{
			return 601608U;
		}

		// Token: 0x06007D12 RID: 32018 RVA: 0x0016487F File Offset: 0x00162C7F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D13 RID: 32019 RVA: 0x00164887 File Offset: 0x00162C87
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D14 RID: 32020 RVA: 0x00164890 File Offset: 0x00162C90
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007D15 RID: 32021 RVA: 0x001648A0 File Offset: 0x00162CA0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007D16 RID: 32022 RVA: 0x001648B0 File Offset: 0x00162CB0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007D17 RID: 32023 RVA: 0x001648C0 File Offset: 0x00162CC0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007D18 RID: 32024 RVA: 0x001648D0 File Offset: 0x00162CD0
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003B53 RID: 15187
		public const uint MsgID = 601608U;

		// Token: 0x04003B54 RID: 15188
		public uint Sequence;

		// Token: 0x04003B55 RID: 15189
		public ulong id;
	}
}
