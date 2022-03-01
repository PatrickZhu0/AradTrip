using System;

namespace Protocol
{
	// Token: 0x02000C10 RID: 3088
	[Protocol]
	public class TeamCopyGridMoveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008122 RID: 33058 RVA: 0x0016D088 File Offset: 0x0016B488
		public uint GetMsgID()
		{
			return 1100082U;
		}

		// Token: 0x06008123 RID: 33059 RVA: 0x0016D08F File Offset: 0x0016B48F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008124 RID: 33060 RVA: 0x0016D097 File Offset: 0x0016B497
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008125 RID: 33061 RVA: 0x0016D0A0 File Offset: 0x0016B4A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetObjId);
		}

		// Token: 0x06008126 RID: 33062 RVA: 0x0016D0BE File Offset: 0x0016B4BE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetObjId);
		}

		// Token: 0x06008127 RID: 33063 RVA: 0x0016D0DC File Offset: 0x0016B4DC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetObjId);
		}

		// Token: 0x06008128 RID: 33064 RVA: 0x0016D0FA File Offset: 0x0016B4FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetObjId);
		}

		// Token: 0x06008129 RID: 33065 RVA: 0x0016D118 File Offset: 0x0016B518
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003DA2 RID: 15778
		public const uint MsgID = 1100082U;

		// Token: 0x04003DA3 RID: 15779
		public uint Sequence;

		// Token: 0x04003DA4 RID: 15780
		public uint targetGridId;

		// Token: 0x04003DA5 RID: 15781
		public uint targetObjId;
	}
}
