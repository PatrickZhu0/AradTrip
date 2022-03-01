using System;

namespace Protocol
{
	// Token: 0x02000B63 RID: 2915
	[Protocol]
	public class SceneRecommendSkillsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C1E RID: 31774 RVA: 0x00162E3C File Offset: 0x0016123C
		public uint GetMsgID()
		{
			return 500716U;
		}

		// Token: 0x06007C1F RID: 31775 RVA: 0x00162E43 File Offset: 0x00161243
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C20 RID: 31776 RVA: 0x00162E4B File Offset: 0x0016124B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C21 RID: 31777 RVA: 0x00162E54 File Offset: 0x00161254
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C22 RID: 31778 RVA: 0x00162E64 File Offset: 0x00161264
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C23 RID: 31779 RVA: 0x00162E74 File Offset: 0x00161274
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C24 RID: 31780 RVA: 0x00162E84 File Offset: 0x00161284
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C25 RID: 31781 RVA: 0x00162E94 File Offset: 0x00161294
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003ACC RID: 15052
		public const uint MsgID = 500716U;

		// Token: 0x04003ACD RID: 15053
		public uint Sequence;

		// Token: 0x04003ACE RID: 15054
		public uint result;
	}
}
