using System;

namespace Protocol
{
	// Token: 0x02000877 RID: 2167
	[Protocol]
	public class WorldGuildSetJoinLevelReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065A1 RID: 26017 RVA: 0x0012E1E5 File Offset: 0x0012C5E5
		public uint GetMsgID()
		{
			return 601988U;
		}

		// Token: 0x060065A2 RID: 26018 RVA: 0x0012E1EC File Offset: 0x0012C5EC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065A3 RID: 26019 RVA: 0x0012E1F4 File Offset: 0x0012C5F4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065A4 RID: 26020 RVA: 0x0012E1FD File Offset: 0x0012C5FD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinLevel);
		}

		// Token: 0x060065A5 RID: 26021 RVA: 0x0012E20D File Offset: 0x0012C60D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinLevel);
		}

		// Token: 0x060065A6 RID: 26022 RVA: 0x0012E21D File Offset: 0x0012C61D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinLevel);
		}

		// Token: 0x060065A7 RID: 26023 RVA: 0x0012E22D File Offset: 0x0012C62D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinLevel);
		}

		// Token: 0x060065A8 RID: 26024 RVA: 0x0012E240 File Offset: 0x0012C640
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D84 RID: 11652
		public const uint MsgID = 601988U;

		// Token: 0x04002D85 RID: 11653
		public uint Sequence;

		// Token: 0x04002D86 RID: 11654
		public uint joinLevel;
	}
}
