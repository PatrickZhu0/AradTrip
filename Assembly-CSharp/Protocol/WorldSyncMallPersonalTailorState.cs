using System;

namespace Protocol
{
	// Token: 0x0200090E RID: 2318
	[Protocol]
	public class WorldSyncMallPersonalTailorState : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069EE RID: 27118 RVA: 0x00137900 File Offset: 0x00135D00
		public uint GetMsgID()
		{
			return 602818U;
		}

		// Token: 0x060069EF RID: 27119 RVA: 0x00137907 File Offset: 0x00135D07
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069F0 RID: 27120 RVA: 0x0013790F File Offset: 0x00135D0F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069F1 RID: 27121 RVA: 0x00137918 File Offset: 0x00135D18
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodsId);
		}

		// Token: 0x060069F2 RID: 27122 RVA: 0x00137936 File Offset: 0x00135D36
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodsId);
		}

		// Token: 0x060069F3 RID: 27123 RVA: 0x00137954 File Offset: 0x00135D54
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goodsId);
		}

		// Token: 0x060069F4 RID: 27124 RVA: 0x00137972 File Offset: 0x00135D72
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goodsId);
		}

		// Token: 0x060069F5 RID: 27125 RVA: 0x00137990 File Offset: 0x00135D90
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04003005 RID: 12293
		public const uint MsgID = 602818U;

		// Token: 0x04003006 RID: 12294
		public uint Sequence;

		// Token: 0x04003007 RID: 12295
		public byte state;

		// Token: 0x04003008 RID: 12296
		public uint goodsId;
	}
}
