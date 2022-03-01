using System;

namespace Protocol
{
	// Token: 0x020006E8 RID: 1768
	[Protocol]
	public class GateSyncServerTime : IProtocolStream, IGetMsgID
	{
		// Token: 0x060059B6 RID: 22966 RVA: 0x001108C0 File Offset: 0x0010ECC0
		public uint GetMsgID()
		{
			return 300309U;
		}

		// Token: 0x060059B7 RID: 22967 RVA: 0x001108C7 File Offset: 0x0010ECC7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060059B8 RID: 22968 RVA: 0x001108CF File Offset: 0x0010ECCF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060059B9 RID: 22969 RVA: 0x001108D8 File Offset: 0x0010ECD8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x060059BA RID: 22970 RVA: 0x001108E8 File Offset: 0x0010ECE8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x060059BB RID: 22971 RVA: 0x001108F8 File Offset: 0x0010ECF8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x060059BC RID: 22972 RVA: 0x00110908 File Offset: 0x0010ED08
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x060059BD RID: 22973 RVA: 0x00110918 File Offset: 0x0010ED18
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400243C RID: 9276
		public const uint MsgID = 300309U;

		// Token: 0x0400243D RID: 9277
		public uint Sequence;

		// Token: 0x0400243E RID: 9278
		public uint time;
	}
}
