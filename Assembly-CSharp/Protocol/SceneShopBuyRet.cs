using System;

namespace Protocol
{
	// Token: 0x020008EF RID: 2287
	[Protocol]
	public class SceneShopBuyRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068D7 RID: 26839 RVA: 0x00136179 File Offset: 0x00134579
		public uint GetMsgID()
		{
			return 500925U;
		}

		// Token: 0x060068D8 RID: 26840 RVA: 0x00136180 File Offset: 0x00134580
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068D9 RID: 26841 RVA: 0x00136188 File Offset: 0x00134588
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068DA RID: 26842 RVA: 0x00136191 File Offset: 0x00134591
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.newNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.leaseEndTimeStamp);
		}

		// Token: 0x060068DB RID: 26843 RVA: 0x001361CB File Offset: 0x001345CB
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.newNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.leaseEndTimeStamp);
		}

		// Token: 0x060068DC RID: 26844 RVA: 0x00136205 File Offset: 0x00134605
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.newNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.leaseEndTimeStamp);
		}

		// Token: 0x060068DD RID: 26845 RVA: 0x0013623F File Offset: 0x0013463F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.newNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.leaseEndTimeStamp);
		}

		// Token: 0x060068DE RID: 26846 RVA: 0x0013627C File Offset: 0x0013467C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			return num + 4;
		}

		// Token: 0x04002F8F RID: 12175
		public const uint MsgID = 500925U;

		// Token: 0x04002F90 RID: 12176
		public uint Sequence;

		// Token: 0x04002F91 RID: 12177
		public uint code;

		// Token: 0x04002F92 RID: 12178
		public uint shopItemId;

		// Token: 0x04002F93 RID: 12179
		public ushort newNum;

		// Token: 0x04002F94 RID: 12180
		public uint leaseEndTimeStamp;
	}
}
