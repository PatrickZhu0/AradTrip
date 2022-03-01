using System;

namespace Protocol
{
	// Token: 0x02000AE6 RID: 2790
	[Protocol]
	public class WorldChangeRoomOwnerReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007861 RID: 30817 RVA: 0x0015C264 File Offset: 0x0015A664
		public uint GetMsgID()
		{
			return 607825U;
		}

		// Token: 0x06007862 RID: 30818 RVA: 0x0015C26B File Offset: 0x0015A66B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007863 RID: 30819 RVA: 0x0015C273 File Offset: 0x0015A673
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007864 RID: 30820 RVA: 0x0015C27C File Offset: 0x0015A67C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007865 RID: 30821 RVA: 0x0015C28C File Offset: 0x0015A68C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007866 RID: 30822 RVA: 0x0015C29C File Offset: 0x0015A69C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007867 RID: 30823 RVA: 0x0015C2AC File Offset: 0x0015A6AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007868 RID: 30824 RVA: 0x0015C2BC File Offset: 0x0015A6BC
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040038D3 RID: 14547
		public const uint MsgID = 607825U;

		// Token: 0x040038D4 RID: 14548
		public uint Sequence;

		// Token: 0x040038D5 RID: 14549
		public ulong playerId;
	}
}
