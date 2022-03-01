using System;

namespace Protocol
{
	// Token: 0x020009E2 RID: 2530
	[Protocol]
	public class WorldGetMailItems : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600710B RID: 28939 RVA: 0x0014680C File Offset: 0x00144C0C
		public uint GetMsgID()
		{
			return 601506U;
		}

		// Token: 0x0600710C RID: 28940 RVA: 0x00146813 File Offset: 0x00144C13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600710D RID: 28941 RVA: 0x0014681B File Offset: 0x00144C1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600710E RID: 28942 RVA: 0x00146824 File Offset: 0x00144C24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mailType);
		}

		// Token: 0x0600710F RID: 28943 RVA: 0x00146850 File Offset: 0x00144C50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mailType);
		}

		// Token: 0x06007110 RID: 28944 RVA: 0x0014687C File Offset: 0x00144C7C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mailType);
		}

		// Token: 0x06007111 RID: 28945 RVA: 0x001468A8 File Offset: 0x00144CA8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mailType);
		}

		// Token: 0x06007112 RID: 28946 RVA: 0x001468D4 File Offset: 0x00144CD4
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003382 RID: 13186
		public const uint MsgID = 601506U;

		// Token: 0x04003383 RID: 13187
		public uint Sequence;

		// Token: 0x04003384 RID: 13188
		public byte type;

		// Token: 0x04003385 RID: 13189
		public ulong id;

		// Token: 0x04003386 RID: 13190
		public uint mailType;
	}
}
