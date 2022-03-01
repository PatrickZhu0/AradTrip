using System;

namespace Protocol
{
	// Token: 0x02000924 RID: 2340
	[Protocol]
	public class SceneFashionMergeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006AB1 RID: 27313 RVA: 0x00138F30 File Offset: 0x00137330
		public uint GetMsgID()
		{
			return 500952U;
		}

		// Token: 0x06006AB2 RID: 27314 RVA: 0x00138F37 File Offset: 0x00137337
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AB3 RID: 27315 RVA: 0x00138F3F File Offset: 0x0013733F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AB4 RID: 27316 RVA: 0x00138F48 File Offset: 0x00137348
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.leftid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.rightid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.composer);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skySuitID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.selFashionID);
		}

		// Token: 0x06006AB5 RID: 27317 RVA: 0x00138F9C File Offset: 0x0013739C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.leftid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.rightid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.composer);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skySuitID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.selFashionID);
		}

		// Token: 0x06006AB6 RID: 27318 RVA: 0x00138FF0 File Offset: 0x001373F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.leftid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.rightid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.composer);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skySuitID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.selFashionID);
		}

		// Token: 0x06006AB7 RID: 27319 RVA: 0x00139044 File Offset: 0x00137444
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.leftid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.rightid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.composer);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skySuitID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.selFashionID);
		}

		// Token: 0x06006AB8 RID: 27320 RVA: 0x00139098 File Offset: 0x00137498
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400305E RID: 12382
		public const uint MsgID = 500952U;

		// Token: 0x0400305F RID: 12383
		public uint Sequence;

		// Token: 0x04003060 RID: 12384
		public ulong leftid;

		// Token: 0x04003061 RID: 12385
		public ulong rightid;

		// Token: 0x04003062 RID: 12386
		public ulong composer;

		// Token: 0x04003063 RID: 12387
		public uint skySuitID;

		// Token: 0x04003064 RID: 12388
		public uint selFashionID;
	}
}
