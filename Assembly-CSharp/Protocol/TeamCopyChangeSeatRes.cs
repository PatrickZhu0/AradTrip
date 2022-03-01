using System;

namespace Protocol
{
	// Token: 0x02000BE4 RID: 3044
	[Protocol]
	public class TeamCopyChangeSeatRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FA2 RID: 32674 RVA: 0x00169EAC File Offset: 0x001682AC
		public uint GetMsgID()
		{
			return 1100042U;
		}

		// Token: 0x06007FA3 RID: 32675 RVA: 0x00169EB3 File Offset: 0x001682B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FA4 RID: 32676 RVA: 0x00169EBB File Offset: 0x001682BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FA5 RID: 32677 RVA: 0x00169EC4 File Offset: 0x001682C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007FA6 RID: 32678 RVA: 0x00169ED4 File Offset: 0x001682D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007FA7 RID: 32679 RVA: 0x00169EE4 File Offset: 0x001682E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007FA8 RID: 32680 RVA: 0x00169EF4 File Offset: 0x001682F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007FA9 RID: 32681 RVA: 0x00169F04 File Offset: 0x00168304
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003CEC RID: 15596
		public const uint MsgID = 1100042U;

		// Token: 0x04003CED RID: 15597
		public uint Sequence;

		// Token: 0x04003CEE RID: 15598
		public uint retCode;
	}
}
