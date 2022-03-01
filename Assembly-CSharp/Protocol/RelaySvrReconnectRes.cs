using System;

namespace Protocol
{
	// Token: 0x02000AA0 RID: 2720
	[Protocol]
	public class RelaySvrReconnectRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007681 RID: 30337 RVA: 0x00156AAC File Offset: 0x00154EAC
		public uint GetMsgID()
		{
			return 1300013U;
		}

		// Token: 0x06007682 RID: 30338 RVA: 0x00156AB3 File Offset: 0x00154EB3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007683 RID: 30339 RVA: 0x00156ABB File Offset: 0x00154EBB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007684 RID: 30340 RVA: 0x00156AC4 File Offset: 0x00154EC4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007685 RID: 30341 RVA: 0x00156AD4 File Offset: 0x00154ED4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007686 RID: 30342 RVA: 0x00156AE4 File Offset: 0x00154EE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007687 RID: 30343 RVA: 0x00156AF4 File Offset: 0x00154EF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007688 RID: 30344 RVA: 0x00156B04 File Offset: 0x00154F04
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003764 RID: 14180
		public const uint MsgID = 1300013U;

		// Token: 0x04003765 RID: 14181
		public uint Sequence;

		// Token: 0x04003766 RID: 14182
		public uint result;
	}
}
