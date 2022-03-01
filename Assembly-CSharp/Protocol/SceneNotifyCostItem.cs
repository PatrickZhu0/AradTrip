using System;

namespace Protocol
{
	// Token: 0x02000921 RID: 2337
	[Protocol]
	public class SceneNotifyCostItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A96 RID: 27286 RVA: 0x00138D20 File Offset: 0x00137120
		public uint GetMsgID()
		{
			return 500949U;
		}

		// Token: 0x06006A97 RID: 27287 RVA: 0x00138D27 File Offset: 0x00137127
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A98 RID: 27288 RVA: 0x00138D2F File Offset: 0x0013712F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A99 RID: 27289 RVA: 0x00138D38 File Offset: 0x00137138
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemid);
			BaseDLL.encode_int8(buffer, ref pos_, this.quality);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006A9A RID: 27290 RVA: 0x00138D64 File Offset: 0x00137164
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.quality);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006A9B RID: 27291 RVA: 0x00138D90 File Offset: 0x00137190
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemid);
			BaseDLL.encode_int8(buffer, ref pos_, this.quality);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006A9C RID: 27292 RVA: 0x00138DBC File Offset: 0x001371BC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.quality);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006A9D RID: 27293 RVA: 0x00138DE8 File Offset: 0x001371E8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 2;
		}

		// Token: 0x04003052 RID: 12370
		public const uint MsgID = 500949U;

		// Token: 0x04003053 RID: 12371
		public uint Sequence;

		// Token: 0x04003054 RID: 12372
		public uint itemid;

		// Token: 0x04003055 RID: 12373
		public byte quality;

		// Token: 0x04003056 RID: 12374
		public ushort num;
	}
}
