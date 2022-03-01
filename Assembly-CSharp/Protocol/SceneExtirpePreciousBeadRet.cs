using System;

namespace Protocol
{
	// Token: 0x02000961 RID: 2401
	[Protocol]
	public class SceneExtirpePreciousBeadRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CCD RID: 27853 RVA: 0x0013C6D8 File Offset: 0x0013AAD8
		public uint GetMsgID()
		{
			return 501036U;
		}

		// Token: 0x06006CCE RID: 27854 RVA: 0x0013C6DF File Offset: 0x0013AADF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CCF RID: 27855 RVA: 0x0013C6E7 File Offset: 0x0013AAE7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CD0 RID: 27856 RVA: 0x0013C6F0 File Offset: 0x0013AAF0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006CD1 RID: 27857 RVA: 0x0013C700 File Offset: 0x0013AB00
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006CD2 RID: 27858 RVA: 0x0013C710 File Offset: 0x0013AB10
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006CD3 RID: 27859 RVA: 0x0013C720 File Offset: 0x0013AB20
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006CD4 RID: 27860 RVA: 0x0013C730 File Offset: 0x0013AB30
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400313E RID: 12606
		public const uint MsgID = 501036U;

		// Token: 0x0400313F RID: 12607
		public uint Sequence;

		// Token: 0x04003140 RID: 12608
		public uint code;
	}
}
