using System;

namespace Protocol
{
	// Token: 0x02000A54 RID: 2644
	[Protocol]
	public class SceneFeedPetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600744A RID: 29770 RVA: 0x001512AF File Offset: 0x0014F6AF
		public uint GetMsgID()
		{
			return 502207U;
		}

		// Token: 0x0600744B RID: 29771 RVA: 0x001512B6 File Offset: 0x0014F6B6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600744C RID: 29772 RVA: 0x001512BE File Offset: 0x0014F6BE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600744D RID: 29773 RVA: 0x001512C7 File Offset: 0x0014F6C7
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.feedType);
		}

		// Token: 0x0600744E RID: 29774 RVA: 0x001512E5 File Offset: 0x0014F6E5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.feedType);
		}

		// Token: 0x0600744F RID: 29775 RVA: 0x00151303 File Offset: 0x0014F703
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.feedType);
		}

		// Token: 0x06007450 RID: 29776 RVA: 0x00151321 File Offset: 0x0014F721
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.feedType);
		}

		// Token: 0x06007451 RID: 29777 RVA: 0x00151340 File Offset: 0x0014F740
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003600 RID: 13824
		public const uint MsgID = 502207U;

		// Token: 0x04003601 RID: 13825
		public uint Sequence;

		// Token: 0x04003602 RID: 13826
		public ulong id;

		// Token: 0x04003603 RID: 13827
		public byte feedType;
	}
}
