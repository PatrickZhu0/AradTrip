using System;

namespace Protocol
{
	// Token: 0x02000ABA RID: 2746
	[Protocol]
	public class SceneRetinueChangeSkillRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600772F RID: 30511 RVA: 0x00158B97 File Offset: 0x00156F97
		public uint GetMsgID()
		{
			return 507006U;
		}

		// Token: 0x06007730 RID: 30512 RVA: 0x00158B9E File Offset: 0x00156F9E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007731 RID: 30513 RVA: 0x00158BA6 File Offset: 0x00156FA6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007732 RID: 30514 RVA: 0x00158BAF File Offset: 0x00156FAF
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007733 RID: 30515 RVA: 0x00158BBF File Offset: 0x00156FBF
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007734 RID: 30516 RVA: 0x00158BCF File Offset: 0x00156FCF
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007735 RID: 30517 RVA: 0x00158BDF File Offset: 0x00156FDF
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007736 RID: 30518 RVA: 0x00158BF0 File Offset: 0x00156FF0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040037D0 RID: 14288
		public const uint MsgID = 507006U;

		// Token: 0x040037D1 RID: 14289
		public uint Sequence;

		// Token: 0x040037D2 RID: 14290
		public uint result;
	}
}
