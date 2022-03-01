using System;

namespace Protocol
{
	// Token: 0x02000713 RID: 1811
	public class BattleNpc : IProtocolStream
	{
		// Token: 0x06005B21 RID: 23329 RVA: 0x001147B7 File Offset: 0x00112BB7
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.npcGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			this.pos.encode(buffer, ref pos_);
		}

		// Token: 0x06005B22 RID: 23330 RVA: 0x001147F0 File Offset: 0x00112BF0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.npcGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			this.pos.decode(buffer, ref pos_);
		}

		// Token: 0x06005B23 RID: 23331 RVA: 0x00114829 File Offset: 0x00112C29
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.npcGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			this.pos.encode(buffer, ref pos_);
		}

		// Token: 0x06005B24 RID: 23332 RVA: 0x00114862 File Offset: 0x00112C62
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.npcGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			this.pos.decode(buffer, ref pos_);
		}

		// Token: 0x06005B25 RID: 23333 RVA: 0x0011489C File Offset: 0x00112C9C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			return num + this.pos.getLen();
		}

		// Token: 0x0400251E RID: 9502
		public ulong npcGuid;

		// Token: 0x0400251F RID: 9503
		public uint npcId;

		// Token: 0x04002520 RID: 9504
		public uint opType;

		// Token: 0x04002521 RID: 9505
		public ScenePosition pos = new ScenePosition();
	}
}
