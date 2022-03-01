using System;

namespace Protocol
{
	// Token: 0x020007D7 RID: 2007
	[Protocol]
	public class SceneTowerWipeoutQueryResultReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060FA RID: 24826 RVA: 0x00123491 File Offset: 0x00121891
		public uint GetMsgID()
		{
			return 507211U;
		}

		// Token: 0x060060FB RID: 24827 RVA: 0x00123498 File Offset: 0x00121898
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060FC RID: 24828 RVA: 0x001234A0 File Offset: 0x001218A0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060FD RID: 24829 RVA: 0x001234A9 File Offset: 0x001218A9
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.beginFloor);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endFloor);
		}

		// Token: 0x060060FE RID: 24830 RVA: 0x001234C7 File Offset: 0x001218C7
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beginFloor);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endFloor);
		}

		// Token: 0x060060FF RID: 24831 RVA: 0x001234E5 File Offset: 0x001218E5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.beginFloor);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endFloor);
		}

		// Token: 0x06006100 RID: 24832 RVA: 0x00123503 File Offset: 0x00121903
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beginFloor);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endFloor);
		}

		// Token: 0x06006101 RID: 24833 RVA: 0x00123524 File Offset: 0x00121924
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002870 RID: 10352
		public const uint MsgID = 507211U;

		// Token: 0x04002871 RID: 10353
		public uint Sequence;

		// Token: 0x04002872 RID: 10354
		public uint beginFloor;

		// Token: 0x04002873 RID: 10355
		public uint endFloor;
	}
}
