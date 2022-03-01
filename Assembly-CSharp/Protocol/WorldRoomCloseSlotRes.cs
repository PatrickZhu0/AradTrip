using System;

namespace Protocol
{
	// Token: 0x02000AEB RID: 2795
	[Protocol]
	public class WorldRoomCloseSlotRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600788E RID: 30862 RVA: 0x0015C5E8 File Offset: 0x0015A9E8
		public uint GetMsgID()
		{
			return 607830U;
		}

		// Token: 0x0600788F RID: 30863 RVA: 0x0015C5EF File Offset: 0x0015A9EF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007890 RID: 30864 RVA: 0x0015C5F7 File Offset: 0x0015A9F7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007891 RID: 30865 RVA: 0x0015C600 File Offset: 0x0015AA00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007892 RID: 30866 RVA: 0x0015C610 File Offset: 0x0015AA10
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007893 RID: 30867 RVA: 0x0015C620 File Offset: 0x0015AA20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007894 RID: 30868 RVA: 0x0015C630 File Offset: 0x0015AA30
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007895 RID: 30869 RVA: 0x0015C640 File Offset: 0x0015AA40
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040038E7 RID: 14567
		public const uint MsgID = 607830U;

		// Token: 0x040038E8 RID: 14568
		public uint Sequence;

		// Token: 0x040038E9 RID: 14569
		public uint result;
	}
}
