using System;

namespace Protocol
{
	// Token: 0x02000A5B RID: 2651
	[Protocol]
	public class SceneSetPetFollowRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007489 RID: 29833 RVA: 0x00151780 File Offset: 0x0014FB80
		public uint GetMsgID()
		{
			return 502214U;
		}

		// Token: 0x0600748A RID: 29834 RVA: 0x00151787 File Offset: 0x0014FB87
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600748B RID: 29835 RVA: 0x0015178F File Offset: 0x0014FB8F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600748C RID: 29836 RVA: 0x00151798 File Offset: 0x0014FB98
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.petId);
		}

		// Token: 0x0600748D RID: 29837 RVA: 0x001517B6 File Offset: 0x0014FBB6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.petId);
		}

		// Token: 0x0600748E RID: 29838 RVA: 0x001517D4 File Offset: 0x0014FBD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.petId);
		}

		// Token: 0x0600748F RID: 29839 RVA: 0x001517F2 File Offset: 0x0014FBF2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.petId);
		}

		// Token: 0x06007490 RID: 29840 RVA: 0x00151810 File Offset: 0x0014FC10
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x0400361C RID: 13852
		public const uint MsgID = 502214U;

		// Token: 0x0400361D RID: 13853
		public uint Sequence;

		// Token: 0x0400361E RID: 13854
		public uint result;

		// Token: 0x0400361F RID: 13855
		public ulong petId;
	}
}
