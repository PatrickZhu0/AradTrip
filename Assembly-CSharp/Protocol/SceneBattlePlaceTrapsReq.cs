using System;

namespace Protocol
{
	// Token: 0x02000718 RID: 1816
	[Protocol]
	public class SceneBattlePlaceTrapsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B4B RID: 23371 RVA: 0x00114EC4 File Offset: 0x001132C4
		public uint GetMsgID()
		{
			return 508933U;
		}

		// Token: 0x06005B4C RID: 23372 RVA: 0x00114ECB File Offset: 0x001132CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B4D RID: 23373 RVA: 0x00114ED3 File Offset: 0x001132D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B4E RID: 23374 RVA: 0x00114EDC File Offset: 0x001132DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x06005B4F RID: 23375 RVA: 0x00114F16 File Offset: 0x00113316
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06005B50 RID: 23376 RVA: 0x00114F50 File Offset: 0x00113350
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x06005B51 RID: 23377 RVA: 0x00114F8A File Offset: 0x0011338A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06005B52 RID: 23378 RVA: 0x00114FC4 File Offset: 0x001133C4
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002535 RID: 9525
		public const uint MsgID = 508933U;

		// Token: 0x04002536 RID: 9526
		public uint Sequence;

		// Token: 0x04002537 RID: 9527
		public ulong itemGuid;

		// Token: 0x04002538 RID: 9528
		public uint itemCount;

		// Token: 0x04002539 RID: 9529
		public uint x;

		// Token: 0x0400253A RID: 9530
		public uint y;
	}
}
