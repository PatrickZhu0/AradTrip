using System;

namespace Protocol
{
	// Token: 0x02000891 RID: 2193
	[Protocol]
	public class WorldGuildDungeonEndNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006679 RID: 26233 RVA: 0x0012FA28 File Offset: 0x0012DE28
		public uint GetMsgID()
		{
			return 608520U;
		}

		// Token: 0x0600667A RID: 26234 RVA: 0x0012FA2F File Offset: 0x0012DE2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600667B RID: 26235 RVA: 0x0012FA37 File Offset: 0x0012DE37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600667C RID: 26236 RVA: 0x0012FA40 File Offset: 0x0012DE40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x0600667D RID: 26237 RVA: 0x0012FA50 File Offset: 0x0012DE50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x0600667E RID: 26238 RVA: 0x0012FA60 File Offset: 0x0012DE60
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x0600667F RID: 26239 RVA: 0x0012FA70 File Offset: 0x0012DE70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06006680 RID: 26240 RVA: 0x0012FA80 File Offset: 0x0012DE80
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002DD3 RID: 11731
		public const uint MsgID = 608520U;

		// Token: 0x04002DD4 RID: 11732
		public uint Sequence;

		// Token: 0x04002DD5 RID: 11733
		public uint dungeonId;
	}
}
