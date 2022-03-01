using System;

namespace Protocol
{
	// Token: 0x020007C2 RID: 1986
	[Protocol]
	public class SceneDungeonRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006043 RID: 24643 RVA: 0x001211D1 File Offset: 0x0011F5D1
		public uint GetMsgID()
		{
			return 506809U;
		}

		// Token: 0x06006044 RID: 24644 RVA: 0x001211D8 File Offset: 0x0011F5D8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006045 RID: 24645 RVA: 0x001211E0 File Offset: 0x0011F5E0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006046 RID: 24646 RVA: 0x001211EC File Offset: 0x0011F5EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItemIds.Length);
			for (int i = 0; i < this.dropItemIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.dropItemIds[i]);
			}
			for (int j = 0; j < this.md5.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[j]);
			}
		}

		// Token: 0x06006047 RID: 24647 RVA: 0x0012126C File Offset: 0x0011F66C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dropItemIds = new uint[(int)num];
			for (int i = 0; i < this.dropItemIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.dropItemIds[i]);
			}
			for (int j = 0; j < this.md5.Length; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[j]);
			}
		}

		// Token: 0x06006048 RID: 24648 RVA: 0x001212FC File Offset: 0x0011F6FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItemIds.Length);
			for (int i = 0; i < this.dropItemIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.dropItemIds[i]);
			}
			for (int j = 0; j < this.md5.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[j]);
			}
		}

		// Token: 0x06006049 RID: 24649 RVA: 0x0012137C File Offset: 0x0011F77C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dropItemIds = new uint[(int)num];
			for (int i = 0; i < this.dropItemIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.dropItemIds[i]);
			}
			for (int j = 0; j < this.md5.Length; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[j]);
			}
		}

		// Token: 0x0600604A RID: 24650 RVA: 0x0012140C File Offset: 0x0011F80C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2 + 4 * this.dropItemIds.Length;
			return num + this.md5.Length;
		}

		// Token: 0x04002802 RID: 10242
		public const uint MsgID = 506809U;

		// Token: 0x04002803 RID: 10243
		public uint Sequence;

		// Token: 0x04002804 RID: 10244
		public uint lastFrame;

		// Token: 0x04002805 RID: 10245
		public uint[] dropItemIds = new uint[0];

		// Token: 0x04002806 RID: 10246
		public byte[] md5 = new byte[16];
	}
}
