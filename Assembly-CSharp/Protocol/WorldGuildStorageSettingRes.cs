using System;

namespace Protocol
{
	// Token: 0x0200086B RID: 2155
	[Protocol]
	public class WorldGuildStorageSettingRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006535 RID: 25909 RVA: 0x0012D37C File Offset: 0x0012B77C
		public uint GetMsgID()
		{
			return 601966U;
		}

		// Token: 0x06006536 RID: 25910 RVA: 0x0012D383 File Offset: 0x0012B783
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006537 RID: 25911 RVA: 0x0012D38B File Offset: 0x0012B78B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006538 RID: 25912 RVA: 0x0012D394 File Offset: 0x0012B794
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006539 RID: 25913 RVA: 0x0012D3A4 File Offset: 0x0012B7A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600653A RID: 25914 RVA: 0x0012D3B4 File Offset: 0x0012B7B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600653B RID: 25915 RVA: 0x0012D3C4 File Offset: 0x0012B7C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600653C RID: 25916 RVA: 0x0012D3D4 File Offset: 0x0012B7D4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D5D RID: 11613
		public const uint MsgID = 601966U;

		// Token: 0x04002D5E RID: 11614
		public uint Sequence;

		// Token: 0x04002D5F RID: 11615
		public uint result;
	}
}
