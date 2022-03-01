using System;

namespace Protocol
{
	// Token: 0x02000B61 RID: 2913
	[Protocol]
	public class SceneInitSkillsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C0C RID: 31756 RVA: 0x00162D54 File Offset: 0x00161154
		public uint GetMsgID()
		{
			return 500714U;
		}

		// Token: 0x06007C0D RID: 31757 RVA: 0x00162D5B File Offset: 0x0016115B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C0E RID: 31758 RVA: 0x00162D63 File Offset: 0x00161163
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C0F RID: 31759 RVA: 0x00162D6C File Offset: 0x0016116C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C10 RID: 31760 RVA: 0x00162D7C File Offset: 0x0016117C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C11 RID: 31761 RVA: 0x00162D8C File Offset: 0x0016118C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C12 RID: 31762 RVA: 0x00162D9C File Offset: 0x0016119C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C13 RID: 31763 RVA: 0x00162DAC File Offset: 0x001611AC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003AC6 RID: 15046
		public const uint MsgID = 500714U;

		// Token: 0x04003AC7 RID: 15047
		public uint Sequence;

		// Token: 0x04003AC8 RID: 15048
		public uint result;
	}
}
