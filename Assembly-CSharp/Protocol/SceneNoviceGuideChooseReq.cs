using System;

namespace Protocol
{
	// Token: 0x020009D8 RID: 2520
	[Protocol]
	public class SceneNoviceGuideChooseReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070C0 RID: 28864 RVA: 0x00145D34 File Offset: 0x00144134
		public uint GetMsgID()
		{
			return 300205U;
		}

		// Token: 0x060070C1 RID: 28865 RVA: 0x00145D3B File Offset: 0x0014413B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070C2 RID: 28866 RVA: 0x00145D43 File Offset: 0x00144143
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070C3 RID: 28867 RVA: 0x00145D4C File Offset: 0x0014414C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.chooseFlag);
		}

		// Token: 0x060070C4 RID: 28868 RVA: 0x00145D6A File Offset: 0x0014416A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.chooseFlag);
		}

		// Token: 0x060070C5 RID: 28869 RVA: 0x00145D88 File Offset: 0x00144188
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.chooseFlag);
		}

		// Token: 0x060070C6 RID: 28870 RVA: 0x00145DA6 File Offset: 0x001441A6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.chooseFlag);
		}

		// Token: 0x060070C7 RID: 28871 RVA: 0x00145DC4 File Offset: 0x001441C4
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003359 RID: 13145
		public const uint MsgID = 300205U;

		// Token: 0x0400335A RID: 13146
		public uint Sequence;

		// Token: 0x0400335B RID: 13147
		public ulong roleId;

		// Token: 0x0400335C RID: 13148
		public byte chooseFlag;
	}
}
