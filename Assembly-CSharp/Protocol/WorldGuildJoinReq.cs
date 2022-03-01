using System;

namespace Protocol
{
	// Token: 0x0200082D RID: 2093
	[Protocol]
	public class WorldGuildJoinReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006307 RID: 25351 RVA: 0x00129DB4 File Offset: 0x001281B4
		public uint GetMsgID()
		{
			return 601905U;
		}

		// Token: 0x06006308 RID: 25352 RVA: 0x00129DBB File Offset: 0x001281BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006309 RID: 25353 RVA: 0x00129DC3 File Offset: 0x001281C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600630A RID: 25354 RVA: 0x00129DCC File Offset: 0x001281CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x0600630B RID: 25355 RVA: 0x00129DDC File Offset: 0x001281DC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600630C RID: 25356 RVA: 0x00129DEC File Offset: 0x001281EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x0600630D RID: 25357 RVA: 0x00129DFC File Offset: 0x001281FC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600630E RID: 25358 RVA: 0x00129E0C File Offset: 0x0012820C
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002C7F RID: 11391
		public const uint MsgID = 601905U;

		// Token: 0x04002C80 RID: 11392
		public uint Sequence;

		// Token: 0x04002C81 RID: 11393
		public ulong id;
	}
}
