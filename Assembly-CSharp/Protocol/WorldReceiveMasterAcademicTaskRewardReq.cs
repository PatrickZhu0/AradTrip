using System;

namespace Protocol
{
	// Token: 0x02000C76 RID: 3190
	[Protocol]
	public class WorldReceiveMasterAcademicTaskRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600842E RID: 33838 RVA: 0x00172B3C File Offset: 0x00170F3C
		public uint GetMsgID()
		{
			return 601767U;
		}

		// Token: 0x0600842F RID: 33839 RVA: 0x00172B43 File Offset: 0x00170F43
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008430 RID: 33840 RVA: 0x00172B4B File Offset: 0x00170F4B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008431 RID: 33841 RVA: 0x00172B54 File Offset: 0x00170F54
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftDataId);
		}

		// Token: 0x06008432 RID: 33842 RVA: 0x00172B64 File Offset: 0x00170F64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftDataId);
		}

		// Token: 0x06008433 RID: 33843 RVA: 0x00172B74 File Offset: 0x00170F74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftDataId);
		}

		// Token: 0x06008434 RID: 33844 RVA: 0x00172B84 File Offset: 0x00170F84
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftDataId);
		}

		// Token: 0x06008435 RID: 33845 RVA: 0x00172B94 File Offset: 0x00170F94
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003F26 RID: 16166
		public const uint MsgID = 601767U;

		// Token: 0x04003F27 RID: 16167
		public uint Sequence;

		// Token: 0x04003F28 RID: 16168
		public uint giftDataId;
	}
}
