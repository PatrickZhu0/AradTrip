using System;

namespace Protocol
{
	// Token: 0x02000B5D RID: 2909
	[Protocol]
	public class SceneChangeSkillsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007BE8 RID: 31720 RVA: 0x00162B81 File Offset: 0x00160F81
		public uint GetMsgID()
		{
			return 500702U;
		}

		// Token: 0x06007BE9 RID: 31721 RVA: 0x00162B88 File Offset: 0x00160F88
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007BEA RID: 31722 RVA: 0x00162B90 File Offset: 0x00160F90
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007BEB RID: 31723 RVA: 0x00162B99 File Offset: 0x00160F99
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007BEC RID: 31724 RVA: 0x00162BA9 File Offset: 0x00160FA9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007BED RID: 31725 RVA: 0x00162BB9 File Offset: 0x00160FB9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007BEE RID: 31726 RVA: 0x00162BC9 File Offset: 0x00160FC9
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007BEF RID: 31727 RVA: 0x00162BDC File Offset: 0x00160FDC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003ABA RID: 15034
		public const uint MsgID = 500702U;

		// Token: 0x04003ABB RID: 15035
		public uint Sequence;

		// Token: 0x04003ABC RID: 15036
		public uint result;
	}
}
