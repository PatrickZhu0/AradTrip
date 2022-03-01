using System;

namespace Protocol
{
	// Token: 0x0200071A RID: 1818
	[Protocol]
	public class SceneBattleOpenBoxReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B5D RID: 23389 RVA: 0x00115060 File Offset: 0x00113460
		public uint GetMsgID()
		{
			return 508935U;
		}

		// Token: 0x06005B5E RID: 23390 RVA: 0x00115067 File Offset: 0x00113467
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B5F RID: 23391 RVA: 0x0011506F File Offset: 0x0011346F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B60 RID: 23392 RVA: 0x00115078 File Offset: 0x00113478
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06005B61 RID: 23393 RVA: 0x00115096 File Offset: 0x00113496
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06005B62 RID: 23394 RVA: 0x001150B4 File Offset: 0x001134B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06005B63 RID: 23395 RVA: 0x001150D2 File Offset: 0x001134D2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06005B64 RID: 23396 RVA: 0x001150F0 File Offset: 0x001134F0
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400253E RID: 9534
		public const uint MsgID = 508935U;

		// Token: 0x0400253F RID: 9535
		public uint Sequence;

		// Token: 0x04002540 RID: 9536
		public ulong itemGuid;

		// Token: 0x04002541 RID: 9537
		public uint param;
	}
}
