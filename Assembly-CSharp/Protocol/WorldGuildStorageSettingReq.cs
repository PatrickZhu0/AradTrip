using System;

namespace Protocol
{
	// Token: 0x0200086A RID: 2154
	[Protocol]
	public class WorldGuildStorageSettingReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600652C RID: 25900 RVA: 0x0012D2C9 File Offset: 0x0012B6C9
		public uint GetMsgID()
		{
			return 601965U;
		}

		// Token: 0x0600652D RID: 25901 RVA: 0x0012D2D0 File Offset: 0x0012B6D0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600652E RID: 25902 RVA: 0x0012D2D8 File Offset: 0x0012B6D8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600652F RID: 25903 RVA: 0x0012D2E1 File Offset: 0x0012B6E1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06006530 RID: 25904 RVA: 0x0012D2FF File Offset: 0x0012B6FF
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06006531 RID: 25905 RVA: 0x0012D31D File Offset: 0x0012B71D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06006532 RID: 25906 RVA: 0x0012D33B File Offset: 0x0012B73B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06006533 RID: 25907 RVA: 0x0012D35C File Offset: 0x0012B75C
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04002D59 RID: 11609
		public const uint MsgID = 601965U;

		// Token: 0x04002D5A RID: 11610
		public uint Sequence;

		// Token: 0x04002D5B RID: 11611
		public byte type;

		// Token: 0x04002D5C RID: 11612
		public uint value;
	}
}
