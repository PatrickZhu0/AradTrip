using System;

namespace Protocol
{
	// Token: 0x02000BDB RID: 3035
	[Protocol]
	public class TeamCopyInvitePlayer : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F54 RID: 32596 RVA: 0x00169551 File Offset: 0x00167951
		public uint GetMsgID()
		{
			return 1100031U;
		}

		// Token: 0x06007F55 RID: 32597 RVA: 0x00169558 File Offset: 0x00167958
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F56 RID: 32598 RVA: 0x00169560 File Offset: 0x00167960
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F57 RID: 32599 RVA: 0x0016956C File Offset: 0x0016796C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inviteList.Length);
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.inviteList[i]);
			}
		}

		// Token: 0x06007F58 RID: 32600 RVA: 0x001695B4 File Offset: 0x001679B4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inviteList = new ulong[(int)num];
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.inviteList[i]);
			}
		}

		// Token: 0x06007F59 RID: 32601 RVA: 0x00169608 File Offset: 0x00167A08
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inviteList.Length);
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.inviteList[i]);
			}
		}

		// Token: 0x06007F5A RID: 32602 RVA: 0x00169650 File Offset: 0x00167A50
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inviteList = new ulong[(int)num];
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.inviteList[i]);
			}
		}

		// Token: 0x06007F5B RID: 32603 RVA: 0x001696A4 File Offset: 0x00167AA4
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.inviteList.Length);
		}

		// Token: 0x04003CC9 RID: 15561
		public const uint MsgID = 1100031U;

		// Token: 0x04003CCA RID: 15562
		public uint Sequence;

		// Token: 0x04003CCB RID: 15563
		public ulong[] inviteList = new ulong[0];
	}
}
