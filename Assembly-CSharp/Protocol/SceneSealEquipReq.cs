using System;

namespace Protocol
{
	// Token: 0x020008FC RID: 2300
	[Protocol]
	public class SceneSealEquipReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600694C RID: 26956 RVA: 0x00136814 File Offset: 0x00134C14
		public uint GetMsgID()
		{
			return 500937U;
		}

		// Token: 0x0600694D RID: 26957 RVA: 0x0013681B File Offset: 0x00134C1B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600694E RID: 26958 RVA: 0x00136823 File Offset: 0x00134C23
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600694F RID: 26959 RVA: 0x0013682C File Offset: 0x00134C2C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006950 RID: 26960 RVA: 0x0013683C File Offset: 0x00134C3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006951 RID: 26961 RVA: 0x0013684C File Offset: 0x00134C4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006952 RID: 26962 RVA: 0x0013685C File Offset: 0x00134C5C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006953 RID: 26963 RVA: 0x0013686C File Offset: 0x00134C6C
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002FB9 RID: 12217
		public const uint MsgID = 500937U;

		// Token: 0x04002FBA RID: 12218
		public uint Sequence;

		// Token: 0x04002FBB RID: 12219
		public ulong uid;
	}
}
