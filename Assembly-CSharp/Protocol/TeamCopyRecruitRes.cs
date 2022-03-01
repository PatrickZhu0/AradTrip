using System;

namespace Protocol
{
	// Token: 0x02000BF8 RID: 3064
	[Protocol]
	public class TeamCopyRecruitRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008053 RID: 32851 RVA: 0x0016B7BC File Offset: 0x00169BBC
		public uint GetMsgID()
		{
			return 1100061U;
		}

		// Token: 0x06008054 RID: 32852 RVA: 0x0016B7C3 File Offset: 0x00169BC3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008055 RID: 32853 RVA: 0x0016B7CB File Offset: 0x00169BCB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008056 RID: 32854 RVA: 0x0016B7D4 File Offset: 0x00169BD4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06008057 RID: 32855 RVA: 0x0016B7E4 File Offset: 0x00169BE4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06008058 RID: 32856 RVA: 0x0016B7F4 File Offset: 0x00169BF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06008059 RID: 32857 RVA: 0x0016B804 File Offset: 0x00169C04
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x0600805A RID: 32858 RVA: 0x0016B814 File Offset: 0x00169C14
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D46 RID: 15686
		public const uint MsgID = 1100061U;

		// Token: 0x04003D47 RID: 15687
		public uint Sequence;

		// Token: 0x04003D48 RID: 15688
		public uint retCode;
	}
}
