using System;

namespace Protocol
{
	// Token: 0x020007E1 RID: 2017
	[Protocol]
	public class SceneDungeonResetAreaIndexReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006154 RID: 24916 RVA: 0x00123BC8 File Offset: 0x00121FC8
		public uint GetMsgID()
		{
			return 506833U;
		}

		// Token: 0x06006155 RID: 24917 RVA: 0x00123BCF File Offset: 0x00121FCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006156 RID: 24918 RVA: 0x00123BD7 File Offset: 0x00121FD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006157 RID: 24919 RVA: 0x00123BE0 File Offset: 0x00121FE0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06006158 RID: 24920 RVA: 0x00123BF0 File Offset: 0x00121FF0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06006159 RID: 24921 RVA: 0x00123C00 File Offset: 0x00122000
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x0600615A RID: 24922 RVA: 0x00123C10 File Offset: 0x00122010
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x0600615B RID: 24923 RVA: 0x00123C20 File Offset: 0x00122020
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400288F RID: 10383
		public const uint MsgID = 506833U;

		// Token: 0x04002890 RID: 10384
		public uint Sequence;

		// Token: 0x04002891 RID: 10385
		public uint dungeonId;
	}
}
