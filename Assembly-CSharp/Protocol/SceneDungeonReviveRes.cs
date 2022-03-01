using System;

namespace Protocol
{
	// Token: 0x020007CB RID: 1995
	[Protocol]
	public class SceneDungeonReviveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006091 RID: 24721 RVA: 0x00122674 File Offset: 0x00120A74
		public uint GetMsgID()
		{
			return 506818U;
		}

		// Token: 0x06006092 RID: 24722 RVA: 0x0012267B File Offset: 0x00120A7B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006093 RID: 24723 RVA: 0x00122683 File Offset: 0x00120A83
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006094 RID: 24724 RVA: 0x0012268C File Offset: 0x00120A8C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006095 RID: 24725 RVA: 0x0012269C File Offset: 0x00120A9C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006096 RID: 24726 RVA: 0x001226AC File Offset: 0x00120AAC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006097 RID: 24727 RVA: 0x001226BC File Offset: 0x00120ABC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006098 RID: 24728 RVA: 0x001226CC File Offset: 0x00120ACC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002848 RID: 10312
		public const uint MsgID = 506818U;

		// Token: 0x04002849 RID: 10313
		public uint Sequence;

		// Token: 0x0400284A RID: 10314
		public uint result;
	}
}
