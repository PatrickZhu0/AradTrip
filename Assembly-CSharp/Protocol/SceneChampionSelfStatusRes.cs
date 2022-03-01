using System;

namespace Protocol
{
	// Token: 0x02000758 RID: 1880
	[Protocol]
	public class SceneChampionSelfStatusRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D40 RID: 23872 RVA: 0x00118568 File Offset: 0x00116968
		public uint GetMsgID()
		{
			return 509820U;
		}

		// Token: 0x06005D41 RID: 23873 RVA: 0x0011856F File Offset: 0x0011696F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D42 RID: 23874 RVA: 0x00118577 File Offset: 0x00116977
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D43 RID: 23875 RVA: 0x00118580 File Offset: 0x00116980
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
		}

		// Token: 0x06005D44 RID: 23876 RVA: 0x00118590 File Offset: 0x00116990
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06005D45 RID: 23877 RVA: 0x001185A0 File Offset: 0x001169A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
		}

		// Token: 0x06005D46 RID: 23878 RVA: 0x001185B0 File Offset: 0x001169B0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06005D47 RID: 23879 RVA: 0x001185C0 File Offset: 0x001169C0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400263B RID: 9787
		public const uint MsgID = 509820U;

		// Token: 0x0400263C RID: 9788
		public uint Sequence;

		// Token: 0x0400263D RID: 9789
		public uint status;
	}
}
