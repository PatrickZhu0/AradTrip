using System;

namespace Protocol
{
	// Token: 0x02000C0A RID: 3082
	public class TCGridObjData : IProtocolStream
	{
		// Token: 0x060080F2 RID: 33010 RVA: 0x0016C364 File Offset: 0x0016A764
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridObjId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridStatus);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gridPro.Length);
			for (int i = 0; i < this.gridPro.Length; i++)
			{
				this.gridPro[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060080F3 RID: 33011 RVA: 0x0016C3E4 File Offset: 0x0016A7E4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridObjId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridStatus);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gridPro = new TCGridProperty[(int)num];
			for (int i = 0; i < this.gridPro.Length; i++)
			{
				this.gridPro[i] = new TCGridProperty();
				this.gridPro[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060080F4 RID: 33012 RVA: 0x0016C478 File Offset: 0x0016A878
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridObjId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gridStatus);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gridPro.Length);
			for (int i = 0; i < this.gridPro.Length; i++)
			{
				this.gridPro[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060080F5 RID: 33013 RVA: 0x0016C4F8 File Offset: 0x0016A8F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridObjId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gridStatus);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gridPro = new TCGridProperty[(int)num];
			for (int i = 0; i < this.gridPro.Length; i++)
			{
				this.gridPro[i] = new TCGridProperty();
				this.gridPro[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060080F6 RID: 33014 RVA: 0x0016C58C File Offset: 0x0016A98C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.gridPro.Length; i++)
			{
				num += this.gridPro[i].getLen();
			}
			return num;
		}

		// Token: 0x04003D85 RID: 15749
		public uint gridObjId;

		// Token: 0x04003D86 RID: 15750
		public uint gridId;

		// Token: 0x04003D87 RID: 15751
		public uint gridType;

		// Token: 0x04003D88 RID: 15752
		public uint gridStatus;

		// Token: 0x04003D89 RID: 15753
		public TCGridProperty[] gridPro = new TCGridProperty[0];
	}
}
