using System;

namespace Protocol
{
	// Token: 0x02000BD1 RID: 3025
	[Protocol]
	public class TeamCopyStageEnd : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EFD RID: 32509 RVA: 0x00168918 File Offset: 0x00166D18
		public uint GetMsgID()
		{
			return 1100022U;
		}

		// Token: 0x06007EFE RID: 32510 RVA: 0x0016891F File Offset: 0x00166D1F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EFF RID: 32511 RVA: 0x00168927 File Offset: 0x00166D27
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F00 RID: 32512 RVA: 0x00168930 File Offset: 0x00166D30
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.passType);
		}

		// Token: 0x06007F01 RID: 32513 RVA: 0x0016894E File Offset: 0x00166D4E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.passType);
		}

		// Token: 0x06007F02 RID: 32514 RVA: 0x0016896C File Offset: 0x00166D6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.passType);
		}

		// Token: 0x06007F03 RID: 32515 RVA: 0x0016898A File Offset: 0x00166D8A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.passType);
		}

		// Token: 0x06007F04 RID: 32516 RVA: 0x001689A8 File Offset: 0x00166DA8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003CA3 RID: 15523
		public const uint MsgID = 1100022U;

		// Token: 0x04003CA4 RID: 15524
		public uint Sequence;

		// Token: 0x04003CA5 RID: 15525
		public uint stageId;

		// Token: 0x04003CA6 RID: 15526
		public uint passType;
	}
}
