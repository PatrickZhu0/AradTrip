using System;

namespace Protocol
{
	// Token: 0x0200090F RID: 2319
	[Protocol]
	public class WorldMallQueryItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069F7 RID: 27127 RVA: 0x001379B0 File Offset: 0x00135DB0
		public uint GetMsgID()
		{
			return 602803U;
		}

		// Token: 0x060069F8 RID: 27128 RVA: 0x001379B7 File Offset: 0x00135DB7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069F9 RID: 27129 RVA: 0x001379BF File Offset: 0x00135DBF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069FA RID: 27130 RVA: 0x001379C8 File Offset: 0x00135DC8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.tagType);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.subType);
			BaseDLL.encode_int8(buffer, ref pos_, this.moneyType);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.updateTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPersonalTailor);
		}

		// Token: 0x060069FB RID: 27131 RVA: 0x00137A38 File Offset: 0x00135E38
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tagType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.subType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.moneyType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.updateTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPersonalTailor);
		}

		// Token: 0x060069FC RID: 27132 RVA: 0x00137AA8 File Offset: 0x00135EA8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.tagType);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.subType);
			BaseDLL.encode_int8(buffer, ref pos_, this.moneyType);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.updateTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPersonalTailor);
		}

		// Token: 0x060069FD RID: 27133 RVA: 0x00137B18 File Offset: 0x00135F18
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tagType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.subType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.moneyType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.updateTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPersonalTailor);
		}

		// Token: 0x060069FE RID: 27134 RVA: 0x00137B88 File Offset: 0x00135F88
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num++;
			num++;
			num++;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003009 RID: 12297
		public const uint MsgID = 602803U;

		// Token: 0x0400300A RID: 12298
		public uint Sequence;

		// Token: 0x0400300B RID: 12299
		public byte tagType;

		// Token: 0x0400300C RID: 12300
		public byte type;

		// Token: 0x0400300D RID: 12301
		public byte subType;

		// Token: 0x0400300E RID: 12302
		public byte moneyType;

		// Token: 0x0400300F RID: 12303
		public byte occu;

		// Token: 0x04003010 RID: 12304
		public uint updateTime;

		// Token: 0x04003011 RID: 12305
		public byte isPersonalTailor;
	}
}
