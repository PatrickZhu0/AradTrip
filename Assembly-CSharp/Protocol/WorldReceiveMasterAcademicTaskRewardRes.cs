using System;

namespace Protocol
{
	// Token: 0x02000C77 RID: 3191
	[Protocol]
	public class WorldReceiveMasterAcademicTaskRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008437 RID: 33847 RVA: 0x00172BB0 File Offset: 0x00170FB0
		public uint GetMsgID()
		{
			return 601768U;
		}

		// Token: 0x06008438 RID: 33848 RVA: 0x00172BB7 File Offset: 0x00170FB7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008439 RID: 33849 RVA: 0x00172BBF File Offset: 0x00170FBF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600843A RID: 33850 RVA: 0x00172BC8 File Offset: 0x00170FC8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600843B RID: 33851 RVA: 0x00172BD8 File Offset: 0x00170FD8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600843C RID: 33852 RVA: 0x00172BE8 File Offset: 0x00170FE8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600843D RID: 33853 RVA: 0x00172BF8 File Offset: 0x00170FF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600843E RID: 33854 RVA: 0x00172C08 File Offset: 0x00171008
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003F29 RID: 16169
		public const uint MsgID = 601768U;

		// Token: 0x04003F2A RID: 16170
		public uint Sequence;

		// Token: 0x04003F2B RID: 16171
		public uint code;
	}
}
