using System;

namespace Protocol
{
	// Token: 0x020007AD RID: 1965
	[Protocol]
	public class SceneDungeonUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005FAD RID: 24493 RVA: 0x0011E454 File Offset: 0x0011C854
		public uint GetMsgID()
		{
			return 506802U;
		}

		// Token: 0x06005FAE RID: 24494 RVA: 0x0011E45B File Offset: 0x0011C85B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005FAF RID: 24495 RVA: 0x0011E463 File Offset: 0x0011C863
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005FB0 RID: 24496 RVA: 0x0011E46C File Offset: 0x0011C86C
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005FB1 RID: 24497 RVA: 0x0011E47B File Offset: 0x0011C87B
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005FB2 RID: 24498 RVA: 0x0011E48A File Offset: 0x0011C88A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005FB3 RID: 24499 RVA: 0x0011E499 File Offset: 0x0011C899
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005FB4 RID: 24500 RVA: 0x0011E4A8 File Offset: 0x0011C8A8
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x0400279E RID: 10142
		public const uint MsgID = 506802U;

		// Token: 0x0400279F RID: 10143
		public uint Sequence;

		// Token: 0x040027A0 RID: 10144
		public SceneDungeonInfo info = new SceneDungeonInfo();
	}
}
