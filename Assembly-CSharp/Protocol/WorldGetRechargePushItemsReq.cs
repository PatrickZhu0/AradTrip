using System;

namespace Protocol
{
	// Token: 0x0200097C RID: 2428
	[Protocol]
	public class WorldGetRechargePushItemsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DB1 RID: 28081 RVA: 0x0013E5A0 File Offset: 0x0013C9A0
		public uint GetMsgID()
		{
			return 602827U;
		}

		// Token: 0x06006DB2 RID: 28082 RVA: 0x0013E5A7 File Offset: 0x0013C9A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DB3 RID: 28083 RVA: 0x0013E5AF File Offset: 0x0013C9AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DB4 RID: 28084 RVA: 0x0013E5B8 File Offset: 0x0013C9B8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006DB5 RID: 28085 RVA: 0x0013E5BA File Offset: 0x0013C9BA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006DB6 RID: 28086 RVA: 0x0013E5BC File Offset: 0x0013C9BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006DB7 RID: 28087 RVA: 0x0013E5BE File Offset: 0x0013C9BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006DB8 RID: 28088 RVA: 0x0013E5C0 File Offset: 0x0013C9C0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040031AF RID: 12719
		public const uint MsgID = 602827U;

		// Token: 0x040031B0 RID: 12720
		public uint Sequence;
	}
}
