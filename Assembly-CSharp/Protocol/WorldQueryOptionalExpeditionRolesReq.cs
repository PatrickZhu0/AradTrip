using System;

namespace Protocol
{
	// Token: 0x020006A2 RID: 1698
	[Protocol]
	public class WorldQueryOptionalExpeditionRolesReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057C5 RID: 22469 RVA: 0x0010B5C5 File Offset: 0x001099C5
		public uint GetMsgID()
		{
			return 608613U;
		}

		// Token: 0x060057C6 RID: 22470 RVA: 0x0010B5CC File Offset: 0x001099CC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057C7 RID: 22471 RVA: 0x0010B5D4 File Offset: 0x001099D4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057C8 RID: 22472 RVA: 0x0010B5DD File Offset: 0x001099DD
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060057C9 RID: 22473 RVA: 0x0010B5DF File Offset: 0x001099DF
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060057CA RID: 22474 RVA: 0x0010B5E1 File Offset: 0x001099E1
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060057CB RID: 22475 RVA: 0x0010B5E3 File Offset: 0x001099E3
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060057CC RID: 22476 RVA: 0x0010B5E8 File Offset: 0x001099E8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040022E9 RID: 8937
		public const uint MsgID = 608613U;

		// Token: 0x040022EA RID: 8938
		public uint Sequence;
	}
}
