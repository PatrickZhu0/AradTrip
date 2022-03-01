using System;

namespace Protocol
{
	// Token: 0x0200067F RID: 1663
	[Protocol]
	public class SceneActiveRestTimeRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056A2 RID: 22178 RVA: 0x00109474 File Offset: 0x00107874
		public uint GetMsgID()
		{
			return 501137U;
		}

		// Token: 0x060056A3 RID: 22179 RVA: 0x0010947B File Offset: 0x0010787B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056A4 RID: 22180 RVA: 0x00109483 File Offset: 0x00107883
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056A5 RID: 22181 RVA: 0x0010948C File Offset: 0x0010788C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.time1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time2);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time3);
		}

		// Token: 0x060056A6 RID: 22182 RVA: 0x001094B8 File Offset: 0x001078B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time3);
		}

		// Token: 0x060056A7 RID: 22183 RVA: 0x001094E4 File Offset: 0x001078E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.time1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time2);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time3);
		}

		// Token: 0x060056A8 RID: 22184 RVA: 0x00109510 File Offset: 0x00107910
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time3);
		}

		// Token: 0x060056A9 RID: 22185 RVA: 0x0010953C File Offset: 0x0010793C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002269 RID: 8809
		public const uint MsgID = 501137U;

		// Token: 0x0400226A RID: 8810
		public uint Sequence;

		// Token: 0x0400226B RID: 8811
		public uint time1;

		// Token: 0x0400226C RID: 8812
		public uint time2;

		// Token: 0x0400226D RID: 8813
		public uint time3;
	}
}
