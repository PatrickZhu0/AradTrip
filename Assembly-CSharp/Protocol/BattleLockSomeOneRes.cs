using System;

namespace Protocol
{
	// Token: 0x020006FC RID: 1788
	[Protocol]
	public class BattleLockSomeOneRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A58 RID: 23128 RVA: 0x00112D8C File Offset: 0x0011118C
		public uint GetMsgID()
		{
			return 2200014U;
		}

		// Token: 0x06005A59 RID: 23129 RVA: 0x00112D93 File Offset: 0x00111193
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A5A RID: 23130 RVA: 0x00112D9B File Offset: 0x0011119B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A5B RID: 23131 RVA: 0x00112DA4 File Offset: 0x001111A4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
		}

		// Token: 0x06005A5C RID: 23132 RVA: 0x00112DD0 File Offset: 0x001111D0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
		}

		// Token: 0x06005A5D RID: 23133 RVA: 0x00112DFC File Offset: 0x001111FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
		}

		// Token: 0x06005A5E RID: 23134 RVA: 0x00112E28 File Offset: 0x00111228
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
		}

		// Token: 0x06005A5F RID: 23135 RVA: 0x00112E54 File Offset: 0x00111254
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x040024AD RID: 9389
		public const uint MsgID = 2200014U;

		// Token: 0x040024AE RID: 9390
		public uint Sequence;

		// Token: 0x040024AF RID: 9391
		public uint retCode;

		// Token: 0x040024B0 RID: 9392
		public ulong roleId;

		// Token: 0x040024B1 RID: 9393
		public ulong dstId;
	}
}
