using System;

namespace Protocol
{
	// Token: 0x020007E0 RID: 2016
	[Protocol]
	public class SceneDungeonBuyTimesRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600614B RID: 24907 RVA: 0x00123B54 File Offset: 0x00121F54
		public uint GetMsgID()
		{
			return 506832U;
		}

		// Token: 0x0600614C RID: 24908 RVA: 0x00123B5B File Offset: 0x00121F5B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600614D RID: 24909 RVA: 0x00123B63 File Offset: 0x00121F63
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600614E RID: 24910 RVA: 0x00123B6C File Offset: 0x00121F6C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600614F RID: 24911 RVA: 0x00123B7C File Offset: 0x00121F7C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006150 RID: 24912 RVA: 0x00123B8C File Offset: 0x00121F8C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006151 RID: 24913 RVA: 0x00123B9C File Offset: 0x00121F9C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006152 RID: 24914 RVA: 0x00123BAC File Offset: 0x00121FAC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400288C RID: 10380
		public const uint MsgID = 506832U;

		// Token: 0x0400288D RID: 10381
		public uint Sequence;

		// Token: 0x0400288E RID: 10382
		public uint result;
	}
}
