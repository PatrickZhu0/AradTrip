using System;

namespace Protocol
{
	// Token: 0x02000B41 RID: 2881
	[Protocol]
	public class SceneSetWeaponBarRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B10 RID: 31504 RVA: 0x00160A28 File Offset: 0x0015EE28
		public uint GetMsgID()
		{
			return 501220U;
		}

		// Token: 0x06007B11 RID: 31505 RVA: 0x00160A2F File Offset: 0x0015EE2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B12 RID: 31506 RVA: 0x00160A37 File Offset: 0x0015EE37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B13 RID: 31507 RVA: 0x00160A40 File Offset: 0x0015EE40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007B14 RID: 31508 RVA: 0x00160A50 File Offset: 0x0015EE50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007B15 RID: 31509 RVA: 0x00160A60 File Offset: 0x0015EE60
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007B16 RID: 31510 RVA: 0x00160A70 File Offset: 0x0015EE70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007B17 RID: 31511 RVA: 0x00160A80 File Offset: 0x0015EE80
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A4F RID: 14927
		public const uint MsgID = 501220U;

		// Token: 0x04003A50 RID: 14928
		public uint Sequence;

		// Token: 0x04003A51 RID: 14929
		public uint result;
	}
}
