using System;

namespace Protocol
{
	// Token: 0x02000A21 RID: 2593
	[Protocol]
	public class WorldNewTitleTakeOffRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072DC RID: 29404 RVA: 0x0014C49C File Offset: 0x0014A89C
		public uint GetMsgID()
		{
			return 609205U;
		}

		// Token: 0x060072DD RID: 29405 RVA: 0x0014C4A3 File Offset: 0x0014A8A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072DE RID: 29406 RVA: 0x0014C4AB File Offset: 0x0014A8AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072DF RID: 29407 RVA: 0x0014C4B4 File Offset: 0x0014A8B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.res);
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
		}

		// Token: 0x060072E0 RID: 29408 RVA: 0x0014C4D2 File Offset: 0x0014A8D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.res);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
		}

		// Token: 0x060072E1 RID: 29409 RVA: 0x0014C4F0 File Offset: 0x0014A8F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.res);
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
		}

		// Token: 0x060072E2 RID: 29410 RVA: 0x0014C50E File Offset: 0x0014A90E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.res);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
		}

		// Token: 0x060072E3 RID: 29411 RVA: 0x0014C52C File Offset: 0x0014A92C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040034C8 RID: 13512
		public const uint MsgID = 609205U;

		// Token: 0x040034C9 RID: 13513
		public uint Sequence;

		// Token: 0x040034CA RID: 13514
		public uint res;

		// Token: 0x040034CB RID: 13515
		public ulong titleGuid;
	}
}
