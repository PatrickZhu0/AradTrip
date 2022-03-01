using System;

namespace Protocol
{
	// Token: 0x0200098C RID: 2444
	[Protocol]
	public class SceneEquipEnhanceClear : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E3E RID: 28222 RVA: 0x0013F851 File Offset: 0x0013DC51
		public uint GetMsgID()
		{
			return 501062U;
		}

		// Token: 0x06006E3F RID: 28223 RVA: 0x0013F858 File Offset: 0x0013DC58
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E40 RID: 28224 RVA: 0x0013F860 File Offset: 0x0013DC60
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E41 RID: 28225 RVA: 0x0013F869 File Offset: 0x0013DC69
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stuffID);
		}

		// Token: 0x06006E42 RID: 28226 RVA: 0x0013F887 File Offset: 0x0013DC87
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stuffID);
		}

		// Token: 0x06006E43 RID: 28227 RVA: 0x0013F8A5 File Offset: 0x0013DCA5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stuffID);
		}

		// Token: 0x06006E44 RID: 28228 RVA: 0x0013F8C3 File Offset: 0x0013DCC3
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stuffID);
		}

		// Token: 0x06006E45 RID: 28229 RVA: 0x0013F8E4 File Offset: 0x0013DCE4
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040031F3 RID: 12787
		public const uint MsgID = 501062U;

		// Token: 0x040031F4 RID: 12788
		public uint Sequence;

		// Token: 0x040031F5 RID: 12789
		public ulong euqipUid;

		// Token: 0x040031F6 RID: 12790
		public uint stuffID;
	}
}
