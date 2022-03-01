using System;

namespace Protocol
{
	// Token: 0x02000785 RID: 1925
	[Protocol]
	public class WorldChatHorn : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005EA8 RID: 24232 RVA: 0x0011BF37 File Offset: 0x0011A337
		public uint GetMsgID()
		{
			return 600815U;
		}

		// Token: 0x06005EA9 RID: 24233 RVA: 0x0011BF3E File Offset: 0x0011A33E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005EAA RID: 24234 RVA: 0x0011BF46 File Offset: 0x0011A346
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005EAB RID: 24235 RVA: 0x0011BF4F File Offset: 0x0011A34F
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005EAC RID: 24236 RVA: 0x0011BF5E File Offset: 0x0011A35E
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005EAD RID: 24237 RVA: 0x0011BF6D File Offset: 0x0011A36D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005EAE RID: 24238 RVA: 0x0011BF7C File Offset: 0x0011A37C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005EAF RID: 24239 RVA: 0x0011BF8C File Offset: 0x0011A38C
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x040026F9 RID: 9977
		public const uint MsgID = 600815U;

		// Token: 0x040026FA RID: 9978
		public uint Sequence;

		// Token: 0x040026FB RID: 9979
		public HornInfo info = new HornInfo();
	}
}
