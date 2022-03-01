using System;

namespace Protocol
{
	// Token: 0x0200074C RID: 1868
	[Protocol]
	public class SceneChampionReliveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CDA RID: 23770 RVA: 0x001178AC File Offset: 0x00115CAC
		public uint GetMsgID()
		{
			return 509807U;
		}

		// Token: 0x06005CDB RID: 23771 RVA: 0x001178B3 File Offset: 0x00115CB3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CDC RID: 23772 RVA: 0x001178BB File Offset: 0x00115CBB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CDD RID: 23773 RVA: 0x001178C4 File Offset: 0x00115CC4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005CDE RID: 23774 RVA: 0x001178D4 File Offset: 0x00115CD4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005CDF RID: 23775 RVA: 0x001178E4 File Offset: 0x00115CE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005CE0 RID: 23776 RVA: 0x001178F4 File Offset: 0x00115CF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005CE1 RID: 23777 RVA: 0x00117904 File Offset: 0x00115D04
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002609 RID: 9737
		public const uint MsgID = 509807U;

		// Token: 0x0400260A RID: 9738
		public uint Sequence;

		// Token: 0x0400260B RID: 9739
		public uint errorCode;
	}
}
