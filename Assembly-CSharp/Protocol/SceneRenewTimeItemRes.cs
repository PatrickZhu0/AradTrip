using System;

namespace Protocol
{
	// Token: 0x02000931 RID: 2353
	[Protocol]
	public class SceneRenewTimeItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B23 RID: 27427 RVA: 0x00139B1C File Offset: 0x00137F1C
		public uint GetMsgID()
		{
			return 500967U;
		}

		// Token: 0x06006B24 RID: 27428 RVA: 0x00139B23 File Offset: 0x00137F23
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B25 RID: 27429 RVA: 0x00139B2B File Offset: 0x00137F2B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B26 RID: 27430 RVA: 0x00139B34 File Offset: 0x00137F34
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006B27 RID: 27431 RVA: 0x00139B44 File Offset: 0x00137F44
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006B28 RID: 27432 RVA: 0x00139B54 File Offset: 0x00137F54
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006B29 RID: 27433 RVA: 0x00139B64 File Offset: 0x00137F64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006B2A RID: 27434 RVA: 0x00139B74 File Offset: 0x00137F74
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003093 RID: 12435
		public const uint MsgID = 500967U;

		// Token: 0x04003094 RID: 12436
		public uint Sequence;

		// Token: 0x04003095 RID: 12437
		public uint code;
	}
}
