using System;

namespace Protocol
{
	// Token: 0x020007BB RID: 1979
	public class ZjslDungeonInfo : IProtocolStream
	{
		// Token: 0x0600600D RID: 24589 RVA: 0x0011FC70 File Offset: 0x0011E070
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2RemainHp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffVec.Length);
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600600E RID: 24590 RVA: 0x0011FCF0 File Offset: 0x0011E0F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2RemainHp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffVec = new ZjslDungeonBuff[(int)num];
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i] = new ZjslDungeonBuff();
				this.buffVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600600F RID: 24591 RVA: 0x0011FD84 File Offset: 0x0011E184
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2RemainHp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffVec.Length);
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006010 RID: 24592 RVA: 0x0011FE04 File Offset: 0x0011E204
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2RemainHp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffVec = new ZjslDungeonBuff[(int)num];
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i] = new ZjslDungeonBuff();
				this.buffVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006011 RID: 24593 RVA: 0x0011FE98 File Offset: 0x0011E298
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				num += this.buffVec[i].getLen();
			}
			return num;
		}

		// Token: 0x040027CD RID: 10189
		public uint boss1ID;

		// Token: 0x040027CE RID: 10190
		public uint boss2ID;

		// Token: 0x040027CF RID: 10191
		public uint boss1RemainHp;

		// Token: 0x040027D0 RID: 10192
		public uint boss2RemainHp;

		// Token: 0x040027D1 RID: 10193
		public ZjslDungeonBuff[] buffVec = new ZjslDungeonBuff[0];
	}
}
