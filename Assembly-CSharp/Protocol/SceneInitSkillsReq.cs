using System;

namespace Protocol
{
	// Token: 0x02000B60 RID: 2912
	[Protocol]
	public class SceneInitSkillsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C03 RID: 31747 RVA: 0x00162CE0 File Offset: 0x001610E0
		public uint GetMsgID()
		{
			return 500713U;
		}

		// Token: 0x06007C04 RID: 31748 RVA: 0x00162CE7 File Offset: 0x001610E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C05 RID: 31749 RVA: 0x00162CEF File Offset: 0x001610EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C06 RID: 31750 RVA: 0x00162CF8 File Offset: 0x001610F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
		}

		// Token: 0x06007C07 RID: 31751 RVA: 0x00162D08 File Offset: 0x00161108
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
		}

		// Token: 0x06007C08 RID: 31752 RVA: 0x00162D18 File Offset: 0x00161118
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
		}

		// Token: 0x06007C09 RID: 31753 RVA: 0x00162D28 File Offset: 0x00161128
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
		}

		// Token: 0x06007C0A RID: 31754 RVA: 0x00162D38 File Offset: 0x00161138
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003AC3 RID: 15043
		public const uint MsgID = 500713U;

		// Token: 0x04003AC4 RID: 15044
		public uint Sequence;

		// Token: 0x04003AC5 RID: 15045
		public uint configType;
	}
}
