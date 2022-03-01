using System;

namespace Protocol
{
	// Token: 0x02000707 RID: 1799
	[Protocol]
	public class SceneBattleSelectOccuReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AB8 RID: 23224 RVA: 0x00113BA0 File Offset: 0x00111FA0
		public uint GetMsgID()
		{
			return 508913U;
		}

		// Token: 0x06005AB9 RID: 23225 RVA: 0x00113BA7 File Offset: 0x00111FA7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005ABA RID: 23226 RVA: 0x00113BAF File Offset: 0x00111FAF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005ABB RID: 23227 RVA: 0x00113BB8 File Offset: 0x00111FB8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x06005ABC RID: 23228 RVA: 0x00113BC8 File Offset: 0x00111FC8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x06005ABD RID: 23229 RVA: 0x00113BD8 File Offset: 0x00111FD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x06005ABE RID: 23230 RVA: 0x00113BE8 File Offset: 0x00111FE8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x06005ABF RID: 23231 RVA: 0x00113BF8 File Offset: 0x00111FF8
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x040024E9 RID: 9449
		public const uint MsgID = 508913U;

		// Token: 0x040024EA RID: 9450
		public uint Sequence;

		// Token: 0x040024EB RID: 9451
		public byte occu;
	}
}
