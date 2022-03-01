using System;

namespace Protocol
{
	// Token: 0x02000905 RID: 2309
	[Protocol]
	public class SceneAddMagicReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600699D RID: 27037 RVA: 0x00137120 File Offset: 0x00135520
		public uint GetMsgID()
		{
			return 500944U;
		}

		// Token: 0x0600699E RID: 27038 RVA: 0x00137127 File Offset: 0x00135527
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600699F RID: 27039 RVA: 0x0013712F File Offset: 0x0013552F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069A0 RID: 27040 RVA: 0x00137138 File Offset: 0x00135538
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060069A1 RID: 27041 RVA: 0x00137156 File Offset: 0x00135556
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060069A2 RID: 27042 RVA: 0x00137174 File Offset: 0x00135574
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060069A3 RID: 27043 RVA: 0x00137192 File Offset: 0x00135592
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060069A4 RID: 27044 RVA: 0x001371B0 File Offset: 0x001355B0
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04002FDF RID: 12255
		public const uint MsgID = 500944U;

		// Token: 0x04002FE0 RID: 12256
		public uint Sequence;

		// Token: 0x04002FE1 RID: 12257
		public ulong cardUid;

		// Token: 0x04002FE2 RID: 12258
		public ulong itemUid;
	}
}
