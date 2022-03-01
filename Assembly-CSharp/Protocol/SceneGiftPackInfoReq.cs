using System;

namespace Protocol
{
	// Token: 0x02000951 RID: 2385
	[Protocol]
	public class SceneGiftPackInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C3D RID: 27709 RVA: 0x0013B963 File Offset: 0x00139D63
		public uint GetMsgID()
		{
			return 503211U;
		}

		// Token: 0x06006C3E RID: 27710 RVA: 0x0013B96A File Offset: 0x00139D6A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C3F RID: 27711 RVA: 0x0013B972 File Offset: 0x00139D72
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C40 RID: 27712 RVA: 0x0013B97C File Offset: 0x00139D7C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.giftPackIds.Length);
			for (int i = 0; i < this.giftPackIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.giftPackIds[i]);
			}
		}

		// Token: 0x06006C41 RID: 27713 RVA: 0x0013B9C4 File Offset: 0x00139DC4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.giftPackIds = new uint[(int)num];
			for (int i = 0; i < this.giftPackIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftPackIds[i]);
			}
		}

		// Token: 0x06006C42 RID: 27714 RVA: 0x0013BA18 File Offset: 0x00139E18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.giftPackIds.Length);
			for (int i = 0; i < this.giftPackIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.giftPackIds[i]);
			}
		}

		// Token: 0x06006C43 RID: 27715 RVA: 0x0013BA60 File Offset: 0x00139E60
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.giftPackIds = new uint[(int)num];
			for (int i = 0; i < this.giftPackIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftPackIds[i]);
			}
		}

		// Token: 0x06006C44 RID: 27716 RVA: 0x0013BAB4 File Offset: 0x00139EB4
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.giftPackIds.Length);
		}

		// Token: 0x040030FE RID: 12542
		public const uint MsgID = 503211U;

		// Token: 0x040030FF RID: 12543
		public uint Sequence;

		// Token: 0x04003100 RID: 12544
		public uint[] giftPackIds = new uint[0];
	}
}
