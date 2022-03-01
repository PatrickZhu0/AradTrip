using System;

namespace Protocol
{
	// Token: 0x02000BFB RID: 3067
	[Protocol]
	public class TeamCopyFieldStatusNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600806E RID: 32878 RVA: 0x0016B954 File Offset: 0x00169D54
		public uint GetMsgID()
		{
			return 1100064U;
		}

		// Token: 0x0600806F RID: 32879 RVA: 0x0016B95B File Offset: 0x00169D5B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008070 RID: 32880 RVA: 0x0016B963 File Offset: 0x00169D63
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008071 RID: 32881 RVA: 0x0016B96C File Offset: 0x00169D6C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldStatus);
		}

		// Token: 0x06008072 RID: 32882 RVA: 0x0016B98A File Offset: 0x00169D8A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldStatus);
		}

		// Token: 0x06008073 RID: 32883 RVA: 0x0016B9A8 File Offset: 0x00169DA8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldStatus);
		}

		// Token: 0x06008074 RID: 32884 RVA: 0x0016B9C6 File Offset: 0x00169DC6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldStatus);
		}

		// Token: 0x06008075 RID: 32885 RVA: 0x0016B9E4 File Offset: 0x00169DE4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D50 RID: 15696
		public const uint MsgID = 1100064U;

		// Token: 0x04003D51 RID: 15697
		public uint Sequence;

		// Token: 0x04003D52 RID: 15698
		public uint fieldId;

		// Token: 0x04003D53 RID: 15699
		public uint fieldStatus;
	}
}
