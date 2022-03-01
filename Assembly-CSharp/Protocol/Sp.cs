using System;

namespace Protocol
{
	// Token: 0x02000B56 RID: 2902
	public class Sp : IProtocolStream
	{
		// Token: 0x06007BBB RID: 31675 RVA: 0x0016224C File Offset: 0x0016064C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.spList.Length);
			for (int i = 0; i < this.spList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.spList[i]);
			}
		}

		// Token: 0x06007BBC RID: 31676 RVA: 0x00162294 File Offset: 0x00160694
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.spList = new uint[(int)num];
			for (int i = 0; i < this.spList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.spList[i]);
			}
		}

		// Token: 0x06007BBD RID: 31677 RVA: 0x001622E8 File Offset: 0x001606E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.spList.Length);
			for (int i = 0; i < this.spList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.spList[i]);
			}
		}

		// Token: 0x06007BBE RID: 31678 RVA: 0x00162330 File Offset: 0x00160730
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.spList = new uint[(int)num];
			for (int i = 0; i < this.spList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.spList[i]);
			}
		}

		// Token: 0x06007BBF RID: 31679 RVA: 0x00162384 File Offset: 0x00160784
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.spList.Length);
		}

		// Token: 0x04003AA9 RID: 15017
		public uint[] spList = new uint[0];
	}
}
