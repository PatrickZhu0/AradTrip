using System;

namespace Protocol
{
	// Token: 0x02000971 RID: 2417
	[Protocol]
	public class WorldBlackMarketSyncType : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D51 RID: 27985 RVA: 0x0013DC90 File Offset: 0x0013C090
		public uint GetMsgID()
		{
			return 609001U;
		}

		// Token: 0x06006D52 RID: 27986 RVA: 0x0013DC97 File Offset: 0x0013C097
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D53 RID: 27987 RVA: 0x0013DC9F File Offset: 0x0013C09F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D54 RID: 27988 RVA: 0x0013DCA8 File Offset: 0x0013C0A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x06006D55 RID: 27989 RVA: 0x0013DCB8 File Offset: 0x0013C0B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06006D56 RID: 27990 RVA: 0x0013DCC8 File Offset: 0x0013C0C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x06006D57 RID: 27991 RVA: 0x0013DCD8 File Offset: 0x0013C0D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06006D58 RID: 27992 RVA: 0x0013DCE8 File Offset: 0x0013C0E8
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003185 RID: 12677
		public const uint MsgID = 609001U;

		// Token: 0x04003186 RID: 12678
		public uint Sequence;

		// Token: 0x04003187 RID: 12679
		public byte type;
	}
}
