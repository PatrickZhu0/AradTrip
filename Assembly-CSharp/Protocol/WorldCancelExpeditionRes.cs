using System;

namespace Protocol
{
	// Token: 0x020006A7 RID: 1703
	[Protocol]
	public class WorldCancelExpeditionRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057F2 RID: 22514 RVA: 0x0010BD30 File Offset: 0x0010A130
		public uint GetMsgID()
		{
			return 608618U;
		}

		// Token: 0x060057F3 RID: 22515 RVA: 0x0010BD37 File Offset: 0x0010A137
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057F4 RID: 22516 RVA: 0x0010BD3F File Offset: 0x0010A13F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057F5 RID: 22517 RVA: 0x0010BD48 File Offset: 0x0010A148
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
		}

		// Token: 0x060057F6 RID: 22518 RVA: 0x0010BD74 File Offset: 0x0010A174
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
		}

		// Token: 0x060057F7 RID: 22519 RVA: 0x0010BDA0 File Offset: 0x0010A1A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
		}

		// Token: 0x060057F8 RID: 22520 RVA: 0x0010BDCC File Offset: 0x0010A1CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
		}

		// Token: 0x060057F9 RID: 22521 RVA: 0x0010BDF8 File Offset: 0x0010A1F8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 1;
		}

		// Token: 0x040022FF RID: 8959
		public const uint MsgID = 608618U;

		// Token: 0x04002300 RID: 8960
		public uint Sequence;

		// Token: 0x04002301 RID: 8961
		public uint resCode;

		// Token: 0x04002302 RID: 8962
		public byte mapId;

		// Token: 0x04002303 RID: 8963
		public byte expeditionStatus;
	}
}
