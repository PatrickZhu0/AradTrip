using System;

namespace Protocol
{
	// Token: 0x020008E0 RID: 2272
	[Protocol]
	public class ScenePushStorage : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006850 RID: 26704 RVA: 0x0013535C File Offset: 0x0013375C
		public uint GetMsgID()
		{
			return 500909U;
		}

		// Token: 0x06006851 RID: 26705 RVA: 0x00135363 File Offset: 0x00133763
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006852 RID: 26706 RVA: 0x0013536B File Offset: 0x0013376B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006853 RID: 26707 RVA: 0x00135374 File Offset: 0x00133774
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.storageType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006854 RID: 26708 RVA: 0x001353A0 File Offset: 0x001337A0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.storageType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006855 RID: 26709 RVA: 0x001353CC File Offset: 0x001337CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.storageType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006856 RID: 26710 RVA: 0x001353F8 File Offset: 0x001337F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.storageType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006857 RID: 26711 RVA: 0x00135424 File Offset: 0x00133824
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			return num + 2;
		}

		// Token: 0x04002F57 RID: 12119
		public const uint MsgID = 500909U;

		// Token: 0x04002F58 RID: 12120
		public uint Sequence;

		// Token: 0x04002F59 RID: 12121
		public byte storageType;

		// Token: 0x04002F5A RID: 12122
		public ulong uid;

		// Token: 0x04002F5B RID: 12123
		public ushort num;
	}
}
