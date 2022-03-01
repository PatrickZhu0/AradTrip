using System;

namespace Protocol
{
	// Token: 0x020008C5 RID: 2245
	public class PreciousBeadMountHole : IProtocolStream
	{
		// Token: 0x06006793 RID: 26515 RVA: 0x001317B4 File Offset: 0x0012FBB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionCoolTimeStamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.extirpeCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.replaceCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionTransTimes);
		}

		// Token: 0x06006794 RID: 26516 RVA: 0x00131834 File Offset: 0x0012FC34
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionCoolTimeStamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.extirpeCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.replaceCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionTransTimes);
		}

		// Token: 0x06006795 RID: 26517 RVA: 0x001318B4 File Offset: 0x0012FCB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionCoolTimeStamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.extirpeCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.replaceCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionTransTimes);
		}

		// Token: 0x06006796 RID: 26518 RVA: 0x00131934 File Offset: 0x0012FD34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionCoolTimeStamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.extirpeCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.replaceCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionTransTimes);
		}

		// Token: 0x06006797 RID: 26519 RVA: 0x001319B4 File Offset: 0x0012FDB4
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002EAF RID: 11951
		public byte index;

		// Token: 0x04002EB0 RID: 11952
		public byte type;

		// Token: 0x04002EB1 RID: 11953
		public uint preciousBeadId;

		// Token: 0x04002EB2 RID: 11954
		public uint buffId;

		// Token: 0x04002EB3 RID: 11955
		public uint auctionCoolTimeStamp;

		// Token: 0x04002EB4 RID: 11956
		public uint extirpeCnt;

		// Token: 0x04002EB5 RID: 11957
		public uint replaceCnt;

		// Token: 0x04002EB6 RID: 11958
		public uint auctionTransTimes;
	}
}
