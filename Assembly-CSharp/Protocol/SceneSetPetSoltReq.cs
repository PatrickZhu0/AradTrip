using System;

namespace Protocol
{
	// Token: 0x02000A52 RID: 2642
	[Protocol]
	public class SceneSetPetSoltReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007438 RID: 29752 RVA: 0x00151004 File Offset: 0x0014F404
		public uint GetMsgID()
		{
			return 502205U;
		}

		// Token: 0x06007439 RID: 29753 RVA: 0x0015100B File Offset: 0x0014F40B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600743A RID: 29754 RVA: 0x00151013 File Offset: 0x0014F413
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600743B RID: 29755 RVA: 0x0015101C File Offset: 0x0014F41C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.petType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.petId);
		}

		// Token: 0x0600743C RID: 29756 RVA: 0x0015103A File Offset: 0x0014F43A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.petType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.petId);
		}

		// Token: 0x0600743D RID: 29757 RVA: 0x00151058 File Offset: 0x0014F458
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.petType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.petId);
		}

		// Token: 0x0600743E RID: 29758 RVA: 0x00151076 File Offset: 0x0014F476
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.petType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.petId);
		}

		// Token: 0x0600743F RID: 29759 RVA: 0x00151094 File Offset: 0x0014F494
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x040035F7 RID: 13815
		public const uint MsgID = 502205U;

		// Token: 0x040035F8 RID: 13816
		public uint Sequence;

		// Token: 0x040035F9 RID: 13817
		public byte petType;

		// Token: 0x040035FA RID: 13818
		public ulong petId;
	}
}
