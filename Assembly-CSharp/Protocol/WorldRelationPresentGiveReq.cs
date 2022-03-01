using System;

namespace Protocol
{
	// Token: 0x02000C91 RID: 3217
	[Protocol]
	public class WorldRelationPresentGiveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084D3 RID: 34003 RVA: 0x0017509E File Offset: 0x0017349E
		public uint GetMsgID()
		{
			return 601711U;
		}

		// Token: 0x060084D4 RID: 34004 RVA: 0x001750A5 File Offset: 0x001734A5
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084D5 RID: 34005 RVA: 0x001750AD File Offset: 0x001734AD
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060084D6 RID: 34006 RVA: 0x001750B6 File Offset: 0x001734B6
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendUID);
		}

		// Token: 0x060084D7 RID: 34007 RVA: 0x001750C6 File Offset: 0x001734C6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendUID);
		}

		// Token: 0x060084D8 RID: 34008 RVA: 0x001750D6 File Offset: 0x001734D6
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendUID);
		}

		// Token: 0x060084D9 RID: 34009 RVA: 0x001750E6 File Offset: 0x001734E6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendUID);
		}

		// Token: 0x060084DA RID: 34010 RVA: 0x001750F8 File Offset: 0x001734F8
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003FB1 RID: 16305
		public const uint MsgID = 601711U;

		// Token: 0x04003FB2 RID: 16306
		public uint Sequence;

		// Token: 0x04003FB3 RID: 16307
		public ulong friendUID;
	}
}
