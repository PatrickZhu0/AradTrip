using System;

namespace Protocol
{
	// Token: 0x02000797 RID: 1943
	[Protocol]
	public class WorldDigRecordInfoSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F23 RID: 24355 RVA: 0x0011D49B File Offset: 0x0011B89B
		public uint GetMsgID()
		{
			return 608204U;
		}

		// Token: 0x06005F24 RID: 24356 RVA: 0x0011D4A2 File Offset: 0x0011B8A2
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F25 RID: 24357 RVA: 0x0011D4AA File Offset: 0x0011B8AA
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F26 RID: 24358 RVA: 0x0011D4B3 File Offset: 0x0011B8B3
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005F27 RID: 24359 RVA: 0x0011D4C2 File Offset: 0x0011B8C2
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005F28 RID: 24360 RVA: 0x0011D4D1 File Offset: 0x0011B8D1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005F29 RID: 24361 RVA: 0x0011D4E0 File Offset: 0x0011B8E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005F2A RID: 24362 RVA: 0x0011D4F0 File Offset: 0x0011B8F0
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04002743 RID: 10051
		public const uint MsgID = 608204U;

		// Token: 0x04002744 RID: 10052
		public uint Sequence;

		// Token: 0x04002745 RID: 10053
		public DigRecordInfo info = new DigRecordInfo();
	}
}
