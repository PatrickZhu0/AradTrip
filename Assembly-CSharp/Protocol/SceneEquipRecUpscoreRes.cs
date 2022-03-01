using System;

namespace Protocol
{
	// Token: 0x02000940 RID: 2368
	[Protocol]
	public class SceneEquipRecUpscoreRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BA4 RID: 27556 RVA: 0x0013A9AC File Offset: 0x00138DAC
		public uint GetMsgID()
		{
			return 501013U;
		}

		// Token: 0x06006BA5 RID: 27557 RVA: 0x0013A9B3 File Offset: 0x00138DB3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BA6 RID: 27558 RVA: 0x0013A9BB File Offset: 0x00138DBB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BA7 RID: 27559 RVA: 0x0013A9C4 File Offset: 0x00138DC4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.upscore);
		}

		// Token: 0x06006BA8 RID: 27560 RVA: 0x0013A9E2 File Offset: 0x00138DE2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.upscore);
		}

		// Token: 0x06006BA9 RID: 27561 RVA: 0x0013AA00 File Offset: 0x00138E00
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.upscore);
		}

		// Token: 0x06006BAA RID: 27562 RVA: 0x0013AA1E File Offset: 0x00138E1E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.upscore);
		}

		// Token: 0x06006BAB RID: 27563 RVA: 0x0013AA3C File Offset: 0x00138E3C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040030C5 RID: 12485
		public const uint MsgID = 501013U;

		// Token: 0x040030C6 RID: 12486
		public uint Sequence;

		// Token: 0x040030C7 RID: 12487
		public uint code;

		// Token: 0x040030C8 RID: 12488
		public uint upscore;
	}
}
