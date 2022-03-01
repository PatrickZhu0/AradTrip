using System;

namespace Protocol
{
	// Token: 0x02000A5A RID: 2650
	[Protocol]
	public class SceneSetPetFollowReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007480 RID: 29824 RVA: 0x0015170C File Offset: 0x0014FB0C
		public uint GetMsgID()
		{
			return 502213U;
		}

		// Token: 0x06007481 RID: 29825 RVA: 0x00151713 File Offset: 0x0014FB13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007482 RID: 29826 RVA: 0x0015171B File Offset: 0x0014FB1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007483 RID: 29827 RVA: 0x00151724 File Offset: 0x0014FB24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007484 RID: 29828 RVA: 0x00151734 File Offset: 0x0014FB34
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007485 RID: 29829 RVA: 0x00151744 File Offset: 0x0014FB44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007486 RID: 29830 RVA: 0x00151754 File Offset: 0x0014FB54
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007487 RID: 29831 RVA: 0x00151764 File Offset: 0x0014FB64
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003619 RID: 13849
		public const uint MsgID = 502213U;

		// Token: 0x0400361A RID: 13850
		public uint Sequence;

		// Token: 0x0400361B RID: 13851
		public ulong id;
	}
}
