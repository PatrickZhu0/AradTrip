using System;

namespace Protocol
{
	// Token: 0x02000B18 RID: 2840
	[Protocol]
	public class SceneItemUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079E7 RID: 31207 RVA: 0x0015E96A File Offset: 0x0015CD6A
		public uint GetMsgID()
		{
			return 500628U;
		}

		// Token: 0x060079E8 RID: 31208 RVA: 0x0015E971 File Offset: 0x0015CD71
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079E9 RID: 31209 RVA: 0x0015E979 File Offset: 0x0015CD79
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079EA RID: 31210 RVA: 0x0015E982 File Offset: 0x0015CD82
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x060079EB RID: 31211 RVA: 0x0015E99F File Offset: 0x0015CD9F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x060079EC RID: 31212 RVA: 0x0015E9BC File Offset: 0x0015CDBC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			this.data.encode(buffer, ref pos_);
		}

		// Token: 0x060079ED RID: 31213 RVA: 0x0015E9D9 File Offset: 0x0015CDD9
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			this.data.decode(buffer, ref pos_);
		}

		// Token: 0x060079EE RID: 31214 RVA: 0x0015E9F8 File Offset: 0x0015CDF8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.data.getLen();
		}

		// Token: 0x0400397C RID: 14716
		public const uint MsgID = 500628U;

		// Token: 0x0400397D RID: 14717
		public uint Sequence;

		// Token: 0x0400397E RID: 14718
		public uint battleID;

		// Token: 0x0400397F RID: 14719
		public SceneItemInfo data = new SceneItemInfo();
	}
}
