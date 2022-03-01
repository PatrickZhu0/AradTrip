using System;

namespace Protocol
{
	// Token: 0x02000ABD RID: 2749
	[Protocol]
	public class SceneRetinueUpLevelReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600774A RID: 30538 RVA: 0x00158D30 File Offset: 0x00157130
		public uint GetMsgID()
		{
			return 507009U;
		}

		// Token: 0x0600774B RID: 30539 RVA: 0x00158D37 File Offset: 0x00157137
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600774C RID: 30540 RVA: 0x00158D3F File Offset: 0x0015713F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600774D RID: 30541 RVA: 0x00158D48 File Offset: 0x00157148
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x0600774E RID: 30542 RVA: 0x00158D66 File Offset: 0x00157166
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600774F RID: 30543 RVA: 0x00158D84 File Offset: 0x00157184
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007750 RID: 30544 RVA: 0x00158DA2 File Offset: 0x001571A2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007751 RID: 30545 RVA: 0x00158DC0 File Offset: 0x001571C0
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x040037DA RID: 14298
		public const uint MsgID = 507009U;

		// Token: 0x040037DB RID: 14299
		public uint Sequence;

		// Token: 0x040037DC RID: 14300
		public byte type;

		// Token: 0x040037DD RID: 14301
		public ulong id;
	}
}
