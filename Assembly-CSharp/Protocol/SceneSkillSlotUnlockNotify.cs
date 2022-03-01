using System;

namespace Protocol
{
	// Token: 0x02000B64 RID: 2916
	[Protocol]
	public class SceneSkillSlotUnlockNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C27 RID: 31783 RVA: 0x00162EB0 File Offset: 0x001612B0
		public uint GetMsgID()
		{
			return 500717U;
		}

		// Token: 0x06007C28 RID: 31784 RVA: 0x00162EB7 File Offset: 0x001612B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C29 RID: 31785 RVA: 0x00162EBF File Offset: 0x001612BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C2A RID: 31786 RVA: 0x00162EC8 File Offset: 0x001612C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.slot);
		}

		// Token: 0x06007C2B RID: 31787 RVA: 0x00162ED8 File Offset: 0x001612D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.slot);
		}

		// Token: 0x06007C2C RID: 31788 RVA: 0x00162EE8 File Offset: 0x001612E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.slot);
		}

		// Token: 0x06007C2D RID: 31789 RVA: 0x00162EF8 File Offset: 0x001612F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.slot);
		}

		// Token: 0x06007C2E RID: 31790 RVA: 0x00162F08 File Offset: 0x00161308
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003ACF RID: 15055
		public const uint MsgID = 500717U;

		// Token: 0x04003AD0 RID: 15056
		public uint Sequence;

		// Token: 0x04003AD1 RID: 15057
		public uint slot;
	}
}
