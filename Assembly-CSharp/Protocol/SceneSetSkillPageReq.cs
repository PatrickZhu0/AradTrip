using System;

namespace Protocol
{
	// Token: 0x02000B65 RID: 2917
	[Protocol]
	public class SceneSetSkillPageReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C30 RID: 31792 RVA: 0x00162F24 File Offset: 0x00161324
		public uint GetMsgID()
		{
			return 500718U;
		}

		// Token: 0x06007C31 RID: 31793 RVA: 0x00162F2B File Offset: 0x0016132B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C32 RID: 31794 RVA: 0x00162F33 File Offset: 0x00161333
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C33 RID: 31795 RVA: 0x00162F3C File Offset: 0x0016133C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
			BaseDLL.encode_int8(buffer, ref pos_, this.page);
		}

		// Token: 0x06007C34 RID: 31796 RVA: 0x00162F5A File Offset: 0x0016135A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.page);
		}

		// Token: 0x06007C35 RID: 31797 RVA: 0x00162F78 File Offset: 0x00161378
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
			BaseDLL.encode_int8(buffer, ref pos_, this.page);
		}

		// Token: 0x06007C36 RID: 31798 RVA: 0x00162F96 File Offset: 0x00161396
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.page);
		}

		// Token: 0x06007C37 RID: 31799 RVA: 0x00162FB4 File Offset: 0x001613B4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003AD2 RID: 15058
		public const uint MsgID = 500718U;

		// Token: 0x04003AD3 RID: 15059
		public uint Sequence;

		// Token: 0x04003AD4 RID: 15060
		public uint configType;

		// Token: 0x04003AD5 RID: 15061
		public byte page;
	}
}
