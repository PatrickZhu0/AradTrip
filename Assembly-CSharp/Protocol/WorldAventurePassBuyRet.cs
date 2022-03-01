using System;

namespace Protocol
{
	// Token: 0x02000C24 RID: 3108
	[Protocol]
	public class WorldAventurePassBuyRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081C4 RID: 33220 RVA: 0x0016E1B4 File Offset: 0x0016C5B4
		public uint GetMsgID()
		{
			return 609504U;
		}

		// Token: 0x060081C5 RID: 33221 RVA: 0x0016E1BB File Offset: 0x0016C5BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081C6 RID: 33222 RVA: 0x0016E1C3 File Offset: 0x0016C5C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081C7 RID: 33223 RVA: 0x0016E1CC File Offset: 0x0016C5CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060081C8 RID: 33224 RVA: 0x0016E1DC File Offset: 0x0016C5DC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060081C9 RID: 33225 RVA: 0x0016E1EC File Offset: 0x0016C5EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x060081CA RID: 33226 RVA: 0x0016E1FC File Offset: 0x0016C5FC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x060081CB RID: 33227 RVA: 0x0016E20C File Offset: 0x0016C60C
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003DF0 RID: 15856
		public const uint MsgID = 609504U;

		// Token: 0x04003DF1 RID: 15857
		public uint Sequence;

		// Token: 0x04003DF2 RID: 15858
		public byte type;
	}
}
