using System;

namespace Protocol
{
	// Token: 0x020008E8 RID: 2280
	[Protocol]
	public class SceneEquipDecompose : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006898 RID: 26776 RVA: 0x00135935 File Offset: 0x00133D35
		public uint GetMsgID()
		{
			return 500918U;
		}

		// Token: 0x06006899 RID: 26777 RVA: 0x0013593C File Offset: 0x00133D3C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600689A RID: 26778 RVA: 0x00135944 File Offset: 0x00133D44
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600689B RID: 26779 RVA: 0x00135950 File Offset: 0x00133D50
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.uids.Length);
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.uids[i]);
			}
		}

		// Token: 0x0600689C RID: 26780 RVA: 0x00135998 File Offset: 0x00133D98
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.uids = new ulong[(int)num];
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.uids[i]);
			}
		}

		// Token: 0x0600689D RID: 26781 RVA: 0x001359EC File Offset: 0x00133DEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.uids.Length);
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.uids[i]);
			}
		}

		// Token: 0x0600689E RID: 26782 RVA: 0x00135A34 File Offset: 0x00133E34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.uids = new ulong[(int)num];
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.uids[i]);
			}
		}

		// Token: 0x0600689F RID: 26783 RVA: 0x00135A88 File Offset: 0x00133E88
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.uids.Length);
		}

		// Token: 0x04002F73 RID: 12147
		public const uint MsgID = 500918U;

		// Token: 0x04002F74 RID: 12148
		public uint Sequence;

		// Token: 0x04002F75 RID: 12149
		public ulong[] uids = new ulong[0];
	}
}
