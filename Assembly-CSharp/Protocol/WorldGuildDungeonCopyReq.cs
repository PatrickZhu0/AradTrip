using System;

namespace Protocol
{
	// Token: 0x02000886 RID: 2182
	[Protocol]
	public class WorldGuildDungeonCopyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600661F RID: 26143 RVA: 0x0012EF91 File Offset: 0x0012D391
		public uint GetMsgID()
		{
			return 608505U;
		}

		// Token: 0x06006620 RID: 26144 RVA: 0x0012EF98 File Offset: 0x0012D398
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006621 RID: 26145 RVA: 0x0012EFA0 File Offset: 0x0012D3A0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006622 RID: 26146 RVA: 0x0012EFA9 File Offset: 0x0012D3A9
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006623 RID: 26147 RVA: 0x0012EFAB File Offset: 0x0012D3AB
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006624 RID: 26148 RVA: 0x0012EFAD File Offset: 0x0012D3AD
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006625 RID: 26149 RVA: 0x0012EFAF File Offset: 0x0012D3AF
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006626 RID: 26150 RVA: 0x0012EFB4 File Offset: 0x0012D3B4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002DB4 RID: 11700
		public const uint MsgID = 608505U;

		// Token: 0x04002DB5 RID: 11701
		public uint Sequence;
	}
}
