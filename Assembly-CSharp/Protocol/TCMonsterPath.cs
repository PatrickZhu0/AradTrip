using System;

namespace Protocol
{
	// Token: 0x02000C0C RID: 3084
	public class TCMonsterPath : IProtocolStream
	{
		// Token: 0x06008101 RID: 33025 RVA: 0x0016C7A4 File Offset: 0x0016ABA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.monsterObjId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pathVec.Length);
			for (int i = 0; i < this.pathVec.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pathVec[i]);
			}
		}

		// Token: 0x06008102 RID: 33026 RVA: 0x0016C7FC File Offset: 0x0016ABFC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterObjId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pathVec = new uint[(int)num];
			for (int i = 0; i < this.pathVec.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pathVec[i]);
			}
		}

		// Token: 0x06008103 RID: 33027 RVA: 0x0016C85C File Offset: 0x0016AC5C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.monsterObjId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pathVec.Length);
			for (int i = 0; i < this.pathVec.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pathVec[i]);
			}
		}

		// Token: 0x06008104 RID: 33028 RVA: 0x0016C8B4 File Offset: 0x0016ACB4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterObjId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pathVec = new uint[(int)num];
			for (int i = 0; i < this.pathVec.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pathVec[i]);
			}
		}

		// Token: 0x06008105 RID: 33029 RVA: 0x0016C914 File Offset: 0x0016AD14
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 4 * this.pathVec.Length);
		}

		// Token: 0x04003D8D RID: 15757
		public uint monsterObjId;

		// Token: 0x04003D8E RID: 15758
		public uint[] pathVec = new uint[0];
	}
}
