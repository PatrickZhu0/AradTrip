using System;

namespace Protocol
{
	// Token: 0x020009A8 RID: 2472
	[Protocol]
	public class SceneMoveItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F34 RID: 28468 RVA: 0x001414EA File Offset: 0x0013F8EA
		public uint GetMsgID()
		{
			return 500963U;
		}

		// Token: 0x06006F35 RID: 28469 RVA: 0x001414F1 File Offset: 0x0013F8F1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F36 RID: 28470 RVA: 0x001414F9 File Offset: 0x0013F8F9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F37 RID: 28471 RVA: 0x00141502 File Offset: 0x0013F902
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006F38 RID: 28472 RVA: 0x00141512 File Offset: 0x0013F912
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006F39 RID: 28473 RVA: 0x00141522 File Offset: 0x0013F922
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006F3A RID: 28474 RVA: 0x00141532 File Offset: 0x0013F932
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006F3B RID: 28475 RVA: 0x00141544 File Offset: 0x0013F944
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003274 RID: 12916
		public const uint MsgID = 500963U;

		// Token: 0x04003275 RID: 12917
		public uint Sequence;

		// Token: 0x04003276 RID: 12918
		public uint code;
	}
}
