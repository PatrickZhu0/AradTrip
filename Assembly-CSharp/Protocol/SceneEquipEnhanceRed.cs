using System;

namespace Protocol
{
	// Token: 0x0200098E RID: 2446
	[Protocol]
	public class SceneEquipEnhanceRed : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E50 RID: 28240 RVA: 0x0013F978 File Offset: 0x0013DD78
		public uint GetMsgID()
		{
			return 501064U;
		}

		// Token: 0x06006E51 RID: 28241 RVA: 0x0013F97F File Offset: 0x0013DD7F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E52 RID: 28242 RVA: 0x0013F987 File Offset: 0x0013DD87
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E53 RID: 28243 RVA: 0x0013F990 File Offset: 0x0013DD90
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stuffID);
		}

		// Token: 0x06006E54 RID: 28244 RVA: 0x0013F9AE File Offset: 0x0013DDAE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stuffID);
		}

		// Token: 0x06006E55 RID: 28245 RVA: 0x0013F9CC File Offset: 0x0013DDCC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stuffID);
		}

		// Token: 0x06006E56 RID: 28246 RVA: 0x0013F9EA File Offset: 0x0013DDEA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stuffID);
		}

		// Token: 0x06006E57 RID: 28247 RVA: 0x0013FA08 File Offset: 0x0013DE08
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040031FA RID: 12794
		public const uint MsgID = 501064U;

		// Token: 0x040031FB RID: 12795
		public uint Sequence;

		// Token: 0x040031FC RID: 12796
		public ulong euqipUid;

		// Token: 0x040031FD RID: 12797
		public uint stuffID;
	}
}
