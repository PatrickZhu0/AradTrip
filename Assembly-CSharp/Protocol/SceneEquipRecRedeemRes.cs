using System;

namespace Protocol
{
	// Token: 0x0200093E RID: 2366
	[Protocol]
	public class SceneEquipRecRedeemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B92 RID: 27538 RVA: 0x0013A888 File Offset: 0x00138C88
		public uint GetMsgID()
		{
			return 501011U;
		}

		// Token: 0x06006B93 RID: 27539 RVA: 0x0013A88F File Offset: 0x00138C8F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B94 RID: 27540 RVA: 0x0013A897 File Offset: 0x00138C97
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B95 RID: 27541 RVA: 0x0013A8A0 File Offset: 0x00138CA0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.consScore);
		}

		// Token: 0x06006B96 RID: 27542 RVA: 0x0013A8BE File Offset: 0x00138CBE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.consScore);
		}

		// Token: 0x06006B97 RID: 27543 RVA: 0x0013A8DC File Offset: 0x00138CDC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.consScore);
		}

		// Token: 0x06006B98 RID: 27544 RVA: 0x0013A8FA File Offset: 0x00138CFA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.consScore);
		}

		// Token: 0x06006B99 RID: 27545 RVA: 0x0013A918 File Offset: 0x00138D18
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040030BE RID: 12478
		public const uint MsgID = 501011U;

		// Token: 0x040030BF RID: 12479
		public uint Sequence;

		// Token: 0x040030C0 RID: 12480
		public uint code;

		// Token: 0x040030C1 RID: 12481
		public uint consScore;
	}
}
