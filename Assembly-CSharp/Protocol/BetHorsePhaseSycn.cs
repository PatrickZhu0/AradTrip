using System;

namespace Protocol
{
	// Token: 0x0200073B RID: 1851
	[Protocol]
	public class BetHorsePhaseSycn : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C5C RID: 23644 RVA: 0x00116D48 File Offset: 0x00115148
		public uint GetMsgID()
		{
			return 708309U;
		}

		// Token: 0x06005C5D RID: 23645 RVA: 0x00116D4F File Offset: 0x0011514F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C5E RID: 23646 RVA: 0x00116D57 File Offset: 0x00115157
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C5F RID: 23647 RVA: 0x00116D60 File Offset: 0x00115160
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.phaseSycn);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stamp);
		}

		// Token: 0x06005C60 RID: 23648 RVA: 0x00116D7E File Offset: 0x0011517E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phaseSycn);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stamp);
		}

		// Token: 0x06005C61 RID: 23649 RVA: 0x00116D9C File Offset: 0x0011519C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.phaseSycn);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stamp);
		}

		// Token: 0x06005C62 RID: 23650 RVA: 0x00116DBA File Offset: 0x001151BA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phaseSycn);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stamp);
		}

		// Token: 0x06005C63 RID: 23651 RVA: 0x00116DD8 File Offset: 0x001151D8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040025B6 RID: 9654
		public const uint MsgID = 708309U;

		// Token: 0x040025B7 RID: 9655
		public uint Sequence;

		// Token: 0x040025B8 RID: 9656
		public uint phaseSycn;

		// Token: 0x040025B9 RID: 9657
		public uint stamp;
	}
}
