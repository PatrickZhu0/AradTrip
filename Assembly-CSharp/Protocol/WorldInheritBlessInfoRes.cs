using System;

namespace Protocol
{
	// Token: 0x0200069B RID: 1691
	[Protocol]
	public class WorldInheritBlessInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005786 RID: 22406 RVA: 0x0010AF70 File Offset: 0x00109370
		public uint GetMsgID()
		{
			return 608606U;
		}

		// Token: 0x06005787 RID: 22407 RVA: 0x0010AF77 File Offset: 0x00109377
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005788 RID: 22408 RVA: 0x0010AF7F File Offset: 0x0010937F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005789 RID: 22409 RVA: 0x0010AF88 File Offset: 0x00109388
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownInheritBlessNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownInheritBlessExp);
		}

		// Token: 0x0600578A RID: 22410 RVA: 0x0010AFB4 File Offset: 0x001093B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownInheritBlessNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownInheritBlessExp);
		}

		// Token: 0x0600578B RID: 22411 RVA: 0x0010AFE0 File Offset: 0x001093E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownInheritBlessNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownInheritBlessExp);
		}

		// Token: 0x0600578C RID: 22412 RVA: 0x0010B00C File Offset: 0x0010940C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownInheritBlessNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownInheritBlessExp);
		}

		// Token: 0x0600578D RID: 22413 RVA: 0x0010B038 File Offset: 0x00109438
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x040022CC RID: 8908
		public const uint MsgID = 608606U;

		// Token: 0x040022CD RID: 8909
		public uint Sequence;

		// Token: 0x040022CE RID: 8910
		public uint resCode;

		// Token: 0x040022CF RID: 8911
		public uint ownInheritBlessNum;

		// Token: 0x040022D0 RID: 8912
		public ulong ownInheritBlessExp;
	}
}
