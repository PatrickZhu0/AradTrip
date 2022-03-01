using System;

namespace Protocol
{
	// Token: 0x0200095D RID: 2397
	[Protocol]
	public class SceneStrengthenTicketFuseRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CA9 RID: 27817 RVA: 0x0013C364 File Offset: 0x0013A764
		public uint GetMsgID()
		{
			return 501038U;
		}

		// Token: 0x06006CAA RID: 27818 RVA: 0x0013C36B File Offset: 0x0013A76B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CAB RID: 27819 RVA: 0x0013C373 File Offset: 0x0013A773
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CAC RID: 27820 RVA: 0x0013C37C File Offset: 0x0013A77C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006CAD RID: 27821 RVA: 0x0013C38C File Offset: 0x0013A78C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006CAE RID: 27822 RVA: 0x0013C39C File Offset: 0x0013A79C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006CAF RID: 27823 RVA: 0x0013C3AC File Offset: 0x0013A7AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006CB0 RID: 27824 RVA: 0x0013C3BC File Offset: 0x0013A7BC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400312B RID: 12587
		public const uint MsgID = 501038U;

		// Token: 0x0400312C RID: 12588
		public uint Sequence;

		// Token: 0x0400312D RID: 12589
		public uint ret;
	}
}
