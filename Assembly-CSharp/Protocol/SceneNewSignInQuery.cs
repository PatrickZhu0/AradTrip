using System;

namespace Protocol
{
	// Token: 0x0200067A RID: 1658
	[Protocol]
	public class SceneNewSignInQuery : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005675 RID: 22133 RVA: 0x00109144 File Offset: 0x00107544
		public uint GetMsgID()
		{
			return 501163U;
		}

		// Token: 0x06005676 RID: 22134 RVA: 0x0010914B File Offset: 0x0010754B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005677 RID: 22135 RVA: 0x00109153 File Offset: 0x00107553
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005678 RID: 22136 RVA: 0x0010915C File Offset: 0x0010755C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005679 RID: 22137 RVA: 0x0010915E File Offset: 0x0010755E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600567A RID: 22138 RVA: 0x00109160 File Offset: 0x00107560
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600567B RID: 22139 RVA: 0x00109162 File Offset: 0x00107562
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600567C RID: 22140 RVA: 0x00109164 File Offset: 0x00107564
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002257 RID: 8791
		public const uint MsgID = 501163U;

		// Token: 0x04002258 RID: 8792
		public uint Sequence;
	}
}
