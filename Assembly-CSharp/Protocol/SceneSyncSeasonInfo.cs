using System;

namespace Protocol
{
	// Token: 0x02000A09 RID: 2569
	[Protocol]
	public class SceneSyncSeasonInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007216 RID: 29206 RVA: 0x0014B00C File Offset: 0x0014940C
		public uint GetMsgID()
		{
			return 506713U;
		}

		// Token: 0x06007217 RID: 29207 RVA: 0x0014B013 File Offset: 0x00149413
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007218 RID: 29208 RVA: 0x0014B01B File Offset: 0x0014941B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007219 RID: 29209 RVA: 0x0014B024 File Offset: 0x00149424
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonAttrEndTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonAttrLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonAttr);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonExp);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonStatus);
		}

		// Token: 0x0600721A RID: 29210 RVA: 0x0014B0B0 File Offset: 0x001494B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonAttrEndTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonAttrLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonAttr);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonExp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonStatus);
		}

		// Token: 0x0600721B RID: 29211 RVA: 0x0014B13C File Offset: 0x0014953C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonAttrEndTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonAttrLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonAttr);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonExp);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonStatus);
		}

		// Token: 0x0600721C RID: 29212 RVA: 0x0014B1C8 File Offset: 0x001495C8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonAttrEndTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonAttrLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonAttr);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonExp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonStatus);
		}

		// Token: 0x0600721D RID: 29213 RVA: 0x0014B254 File Offset: 0x00149654
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400346F RID: 13423
		public const uint MsgID = 506713U;

		// Token: 0x04003470 RID: 13424
		public uint Sequence;

		// Token: 0x04003471 RID: 13425
		public uint seasonId;

		// Token: 0x04003472 RID: 13426
		public uint endTime;

		// Token: 0x04003473 RID: 13427
		public uint seasonAttrEndTime;

		// Token: 0x04003474 RID: 13428
		public uint seasonAttrLevel;

		// Token: 0x04003475 RID: 13429
		public byte seasonAttr;

		// Token: 0x04003476 RID: 13430
		public uint seasonLevel;

		// Token: 0x04003477 RID: 13431
		public uint seasonStar;

		// Token: 0x04003478 RID: 13432
		public uint seasonExp;

		// Token: 0x04003479 RID: 13433
		public byte seasonStatus;
	}
}
