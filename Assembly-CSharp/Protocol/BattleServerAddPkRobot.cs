using System;

namespace Protocol
{
	// Token: 0x02000703 RID: 1795
	[Protocol]
	public class BattleServerAddPkRobot : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A94 RID: 23188 RVA: 0x00113748 File Offset: 0x00111B48
		public uint GetMsgID()
		{
			return 2200012U;
		}

		// Token: 0x06005A95 RID: 23189 RVA: 0x0011374F File Offset: 0x00111B4F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A96 RID: 23190 RVA: 0x00113757 File Offset: 0x00111B57
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A97 RID: 23191 RVA: 0x00113760 File Offset: 0x00111B60
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005A98 RID: 23192 RVA: 0x00113762 File Offset: 0x00111B62
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005A99 RID: 23193 RVA: 0x00113764 File Offset: 0x00111B64
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005A9A RID: 23194 RVA: 0x00113766 File Offset: 0x00111B66
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005A9B RID: 23195 RVA: 0x00113768 File Offset: 0x00111B68
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040024D3 RID: 9427
		public const uint MsgID = 2200012U;

		// Token: 0x040024D4 RID: 9428
		public uint Sequence;
	}
}
