using System;

namespace Protocol
{
	// Token: 0x0200084F RID: 2127
	[Protocol]
	public class WorldGuildTableDelMember : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006439 RID: 25657 RVA: 0x0012B72E File Offset: 0x00129B2E
		public uint GetMsgID()
		{
			return 601939U;
		}

		// Token: 0x0600643A RID: 25658 RVA: 0x0012B735 File Offset: 0x00129B35
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600643B RID: 25659 RVA: 0x0012B73D File Offset: 0x00129B3D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600643C RID: 25660 RVA: 0x0012B746 File Offset: 0x00129B46
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x0600643D RID: 25661 RVA: 0x0012B756 File Offset: 0x00129B56
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600643E RID: 25662 RVA: 0x0012B766 File Offset: 0x00129B66
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x0600643F RID: 25663 RVA: 0x0012B776 File Offset: 0x00129B76
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06006440 RID: 25664 RVA: 0x0012B788 File Offset: 0x00129B88
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002CEC RID: 11500
		public const uint MsgID = 601939U;

		// Token: 0x04002CED RID: 11501
		public uint Sequence;

		// Token: 0x04002CEE RID: 11502
		public ulong id;
	}
}
