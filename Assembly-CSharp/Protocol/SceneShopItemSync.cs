using System;

namespace Protocol
{
	// Token: 0x020008F1 RID: 2289
	[Protocol]
	public class SceneShopItemSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068E9 RID: 26857 RVA: 0x001362DC File Offset: 0x001346DC
		public uint GetMsgID()
		{
			return 500927U;
		}

		// Token: 0x060068EA RID: 26858 RVA: 0x001362E3 File Offset: 0x001346E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068EB RID: 26859 RVA: 0x001362EB File Offset: 0x001346EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068EC RID: 26860 RVA: 0x001362F4 File Offset: 0x001346F4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060068ED RID: 26861 RVA: 0x001362F6 File Offset: 0x001346F6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060068EE RID: 26862 RVA: 0x001362F8 File Offset: 0x001346F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060068EF RID: 26863 RVA: 0x001362FA File Offset: 0x001346FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060068F0 RID: 26864 RVA: 0x001362FC File Offset: 0x001346FC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002F97 RID: 12183
		public const uint MsgID = 500927U;

		// Token: 0x04002F98 RID: 12184
		public uint Sequence;
	}
}
