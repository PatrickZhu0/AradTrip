using System;

namespace Protocol
{
	// Token: 0x0200067D RID: 1661
	[Protocol]
	public class SceneNewSignInCollectRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005690 RID: 22160 RVA: 0x001093C8 File Offset: 0x001077C8
		public uint GetMsgID()
		{
			return 501166U;
		}

		// Token: 0x06005691 RID: 22161 RVA: 0x001093CF File Offset: 0x001077CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005692 RID: 22162 RVA: 0x001093D7 File Offset: 0x001077D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005693 RID: 22163 RVA: 0x001093E0 File Offset: 0x001077E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005694 RID: 22164 RVA: 0x001093F0 File Offset: 0x001077F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005695 RID: 22165 RVA: 0x00109400 File Offset: 0x00107800
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005696 RID: 22166 RVA: 0x00109410 File Offset: 0x00107810
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005697 RID: 22167 RVA: 0x00109420 File Offset: 0x00107820
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002264 RID: 8804
		public const uint MsgID = 501166U;

		// Token: 0x04002265 RID: 8805
		public uint Sequence;

		// Token: 0x04002266 RID: 8806
		public uint errorCode;
	}
}
