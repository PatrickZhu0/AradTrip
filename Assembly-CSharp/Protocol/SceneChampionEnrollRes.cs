using System;

namespace Protocol
{
	// Token: 0x02000748 RID: 1864
	[Protocol]
	public class SceneChampionEnrollRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CB6 RID: 23734 RVA: 0x00117754 File Offset: 0x00115B54
		public uint GetMsgID()
		{
			return 509803U;
		}

		// Token: 0x06005CB7 RID: 23735 RVA: 0x0011775B File Offset: 0x00115B5B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CB8 RID: 23736 RVA: 0x00117763 File Offset: 0x00115B63
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CB9 RID: 23737 RVA: 0x0011776C File Offset: 0x00115B6C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005CBA RID: 23738 RVA: 0x0011777C File Offset: 0x00115B7C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005CBB RID: 23739 RVA: 0x0011778C File Offset: 0x00115B8C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005CBC RID: 23740 RVA: 0x0011779C File Offset: 0x00115B9C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005CBD RID: 23741 RVA: 0x001177AC File Offset: 0x00115BAC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040025FF RID: 9727
		public const uint MsgID = 509803U;

		// Token: 0x04002600 RID: 9728
		public uint Sequence;

		// Token: 0x04002601 RID: 9729
		public uint errorCode;
	}
}
