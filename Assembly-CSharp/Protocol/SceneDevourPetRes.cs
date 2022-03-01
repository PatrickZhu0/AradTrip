using System;

namespace Protocol
{
	// Token: 0x02000A5D RID: 2653
	[Protocol]
	public class SceneDevourPetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600749B RID: 29851 RVA: 0x001519EF File Offset: 0x0014FDEF
		public uint GetMsgID()
		{
			return 502216U;
		}

		// Token: 0x0600749C RID: 29852 RVA: 0x001519F6 File Offset: 0x0014FDF6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600749D RID: 29853 RVA: 0x001519FE File Offset: 0x0014FDFE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600749E RID: 29854 RVA: 0x00151A07 File Offset: 0x0014FE07
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
		}

		// Token: 0x0600749F RID: 29855 RVA: 0x00151A25 File Offset: 0x0014FE25
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
		}

		// Token: 0x060074A0 RID: 29856 RVA: 0x00151A43 File Offset: 0x0014FE43
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
		}

		// Token: 0x060074A1 RID: 29857 RVA: 0x00151A61 File Offset: 0x0014FE61
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
		}

		// Token: 0x060074A2 RID: 29858 RVA: 0x00151A80 File Offset: 0x0014FE80
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003624 RID: 13860
		public const uint MsgID = 502216U;

		// Token: 0x04003625 RID: 13861
		public uint Sequence;

		// Token: 0x04003626 RID: 13862
		public uint result;

		// Token: 0x04003627 RID: 13863
		public uint exp;
	}
}
