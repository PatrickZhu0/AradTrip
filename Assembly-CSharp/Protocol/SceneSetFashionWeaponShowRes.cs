using System;

namespace Protocol
{
	// Token: 0x02000957 RID: 2391
	[Protocol]
	public class SceneSetFashionWeaponShowRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C73 RID: 27763 RVA: 0x0013BED8 File Offset: 0x0013A2D8
		public uint GetMsgID()
		{
			return 501028U;
		}

		// Token: 0x06006C74 RID: 27764 RVA: 0x0013BEDF File Offset: 0x0013A2DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C75 RID: 27765 RVA: 0x0013BEE7 File Offset: 0x0013A2E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C76 RID: 27766 RVA: 0x0013BEF0 File Offset: 0x0013A2F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006C77 RID: 27767 RVA: 0x0013BF00 File Offset: 0x0013A300
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006C78 RID: 27768 RVA: 0x0013BF10 File Offset: 0x0013A310
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006C79 RID: 27769 RVA: 0x0013BF20 File Offset: 0x0013A320
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006C7A RID: 27770 RVA: 0x0013BF30 File Offset: 0x0013A330
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003112 RID: 12562
		public const uint MsgID = 501028U;

		// Token: 0x04003113 RID: 12563
		public uint Sequence;

		// Token: 0x04003114 RID: 12564
		public uint ret;
	}
}
