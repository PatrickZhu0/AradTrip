using System;

namespace Protocol
{
	// Token: 0x02000A2E RID: 2606
	[Protocol]
	public class SceneCdkRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007312 RID: 29458 RVA: 0x0014CBAC File Offset: 0x0014AFAC
		public uint GetMsgID()
		{
			return 501152U;
		}

		// Token: 0x06007313 RID: 29459 RVA: 0x0014CBB3 File Offset: 0x0014AFB3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007314 RID: 29460 RVA: 0x0014CBBB File Offset: 0x0014AFBB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007315 RID: 29461 RVA: 0x0014CBC4 File Offset: 0x0014AFC4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06007316 RID: 29462 RVA: 0x0014CBD4 File Offset: 0x0014AFD4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06007317 RID: 29463 RVA: 0x0014CBE4 File Offset: 0x0014AFE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06007318 RID: 29464 RVA: 0x0014CBF4 File Offset: 0x0014AFF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06007319 RID: 29465 RVA: 0x0014CC04 File Offset: 0x0014B004
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003549 RID: 13641
		public const uint MsgID = 501152U;

		// Token: 0x0400354A RID: 13642
		public uint Sequence;

		// Token: 0x0400354B RID: 13643
		public uint code;
	}
}
