using System;

namespace Protocol
{
	// Token: 0x02000B81 RID: 2945
	[Protocol]
	public class WorldNotifyMemberLeave : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CE4 RID: 31972 RVA: 0x00164308 File Offset: 0x00162708
		public uint GetMsgID()
		{
			return 601604U;
		}

		// Token: 0x06007CE5 RID: 31973 RVA: 0x0016430F File Offset: 0x0016270F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CE6 RID: 31974 RVA: 0x00164317 File Offset: 0x00162717
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CE7 RID: 31975 RVA: 0x00164320 File Offset: 0x00162720
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007CE8 RID: 31976 RVA: 0x00164330 File Offset: 0x00162730
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007CE9 RID: 31977 RVA: 0x00164340 File Offset: 0x00162740
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007CEA RID: 31978 RVA: 0x00164350 File Offset: 0x00162750
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007CEB RID: 31979 RVA: 0x00164360 File Offset: 0x00162760
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003B3D RID: 15165
		public const uint MsgID = 601604U;

		// Token: 0x04003B3E RID: 15166
		public uint Sequence;

		// Token: 0x04003B3F RID: 15167
		public ulong id;
	}
}
