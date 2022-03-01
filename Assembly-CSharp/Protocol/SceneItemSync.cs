using System;

namespace Protocol
{
	// Token: 0x02000B19 RID: 2841
	[Protocol]
	public class SceneItemSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079F0 RID: 31216 RVA: 0x0015EA22 File Offset: 0x0015CE22
		public uint GetMsgID()
		{
			return 500629U;
		}

		// Token: 0x060079F1 RID: 31217 RVA: 0x0015EA29 File Offset: 0x0015CE29
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079F2 RID: 31218 RVA: 0x0015EA31 File Offset: 0x0015CE31
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079F3 RID: 31219 RVA: 0x0015EA3A File Offset: 0x0015CE3A
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x060079F4 RID: 31220 RVA: 0x0015EA4A File Offset: 0x0015CE4A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x060079F5 RID: 31221 RVA: 0x0015EA5A File Offset: 0x0015CE5A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x060079F6 RID: 31222 RVA: 0x0015EA6A File Offset: 0x0015CE6A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x060079F7 RID: 31223 RVA: 0x0015EA7C File Offset: 0x0015CE7C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003980 RID: 14720
		public const uint MsgID = 500629U;

		// Token: 0x04003981 RID: 14721
		public uint Sequence;

		// Token: 0x04003982 RID: 14722
		public uint battleID;
	}
}
