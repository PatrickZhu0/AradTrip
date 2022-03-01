using System;

namespace Protocol
{
	// Token: 0x02000955 RID: 2389
	[Protocol]
	public class SceneItemLockRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C61 RID: 27745 RVA: 0x0013BDB4 File Offset: 0x0013A1B4
		public uint GetMsgID()
		{
			return 501026U;
		}

		// Token: 0x06006C62 RID: 27746 RVA: 0x0013BDBB File Offset: 0x0013A1BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C63 RID: 27747 RVA: 0x0013BDC3 File Offset: 0x0013A1C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C64 RID: 27748 RVA: 0x0013BDCC File Offset: 0x0013A1CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006C65 RID: 27749 RVA: 0x0013BDEA File Offset: 0x0013A1EA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006C66 RID: 27750 RVA: 0x0013BE08 File Offset: 0x0013A208
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
		}

		// Token: 0x06006C67 RID: 27751 RVA: 0x0013BE26 File Offset: 0x0013A226
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
		}

		// Token: 0x06006C68 RID: 27752 RVA: 0x0013BE44 File Offset: 0x0013A244
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400310B RID: 12555
		public const uint MsgID = 501026U;

		// Token: 0x0400310C RID: 12556
		public uint Sequence;

		// Token: 0x0400310D RID: 12557
		public ulong itemUid;

		// Token: 0x0400310E RID: 12558
		public uint ret;
	}
}
