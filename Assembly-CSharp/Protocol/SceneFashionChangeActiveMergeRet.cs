using System;

namespace Protocol
{
	// Token: 0x02000959 RID: 2393
	[Protocol]
	public class SceneFashionChangeActiveMergeRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C85 RID: 27781 RVA: 0x0013C038 File Offset: 0x0013A438
		public uint GetMsgID()
		{
			return 501030U;
		}

		// Token: 0x06006C86 RID: 27782 RVA: 0x0013C03F File Offset: 0x0013A43F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C87 RID: 27783 RVA: 0x0013C047 File Offset: 0x0013A447
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C88 RID: 27784 RVA: 0x0013C050 File Offset: 0x0013A450
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.commonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.advanceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.allMerged);
		}

		// Token: 0x06006C89 RID: 27785 RVA: 0x0013C0A4 File Offset: 0x0013A4A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.commonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.advanceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.allMerged);
		}

		// Token: 0x06006C8A RID: 27786 RVA: 0x0013C0F8 File Offset: 0x0013A4F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.commonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.advanceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.allMerged);
		}

		// Token: 0x06006C8B RID: 27787 RVA: 0x0013C14C File Offset: 0x0013A54C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.commonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.advanceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.allMerged);
		}

		// Token: 0x06006C8C RID: 27788 RVA: 0x0013C1A0 File Offset: 0x0013A5A0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400311A RID: 12570
		public const uint MsgID = 501030U;

		// Token: 0x0400311B RID: 12571
		public uint Sequence;

		// Token: 0x0400311C RID: 12572
		public uint ret;

		// Token: 0x0400311D RID: 12573
		public byte type;

		// Token: 0x0400311E RID: 12574
		public uint commonId;

		// Token: 0x0400311F RID: 12575
		public uint advanceId;

		// Token: 0x04003120 RID: 12576
		public byte allMerged;
	}
}
