using System;

namespace Protocol
{
	// Token: 0x0200069D RID: 1693
	[Protocol]
	public class WorldInheritExpRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005798 RID: 22424 RVA: 0x0010B094 File Offset: 0x00109494
		public uint GetMsgID()
		{
			return 608608U;
		}

		// Token: 0x06005799 RID: 22425 RVA: 0x0010B09B File Offset: 0x0010949B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600579A RID: 22426 RVA: 0x0010B0A3 File Offset: 0x001094A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600579B RID: 22427 RVA: 0x0010B0AC File Offset: 0x001094AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownInheritBlessNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownInheritBlessExp);
		}

		// Token: 0x0600579C RID: 22428 RVA: 0x0010B0D8 File Offset: 0x001094D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownInheritBlessNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownInheritBlessExp);
		}

		// Token: 0x0600579D RID: 22429 RVA: 0x0010B104 File Offset: 0x00109504
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownInheritBlessNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownInheritBlessExp);
		}

		// Token: 0x0600579E RID: 22430 RVA: 0x0010B130 File Offset: 0x00109530
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownInheritBlessNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownInheritBlessExp);
		}

		// Token: 0x0600579F RID: 22431 RVA: 0x0010B15C File Offset: 0x0010955C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x040022D3 RID: 8915
		public const uint MsgID = 608608U;

		// Token: 0x040022D4 RID: 8916
		public uint Sequence;

		// Token: 0x040022D5 RID: 8917
		public uint resCode;

		// Token: 0x040022D6 RID: 8918
		public uint ownInheritBlessNum;

		// Token: 0x040022D7 RID: 8919
		public ulong ownInheritBlessExp;
	}
}
