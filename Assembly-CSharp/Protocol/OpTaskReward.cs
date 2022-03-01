using System;

namespace Protocol
{
	// Token: 0x02000A2F RID: 2607
	public class OpTaskReward : IProtocolStream
	{
		// Token: 0x0600731B RID: 29467 RVA: 0x0014CC20 File Offset: 0x0014B020
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.qualityLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionCoolTimeStamp);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionTransTimes);
		}

		// Token: 0x0600731C RID: 29468 RVA: 0x0014CC90 File Offset: 0x0014B090
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.qualityLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionCoolTimeStamp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionTransTimes);
		}

		// Token: 0x0600731D RID: 29469 RVA: 0x0014CD00 File Offset: 0x0014B100
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.qualityLv);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionCoolTimeStamp);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auctionTransTimes);
		}

		// Token: 0x0600731E RID: 29470 RVA: 0x0014CD70 File Offset: 0x0014B170
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.qualityLv);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionCoolTimeStamp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auctionTransTimes);
		}

		// Token: 0x0600731F RID: 29471 RVA: 0x0014CDE0 File Offset: 0x0014B1E0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			num++;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x0400354C RID: 13644
		public uint id;

		// Token: 0x0400354D RID: 13645
		public uint num;

		// Token: 0x0400354E RID: 13646
		public byte qualityLv;

		// Token: 0x0400354F RID: 13647
		public byte strenth;

		// Token: 0x04003550 RID: 13648
		public uint auctionCoolTimeStamp;

		// Token: 0x04003551 RID: 13649
		public byte equipType;

		// Token: 0x04003552 RID: 13650
		public uint auctionTransTimes;
	}
}
