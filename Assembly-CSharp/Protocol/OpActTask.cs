using System;

namespace Protocol
{
	// Token: 0x02000A33 RID: 2611
	public class OpActTask : IProtocolStream
	{
		// Token: 0x06007333 RID: 29491 RVA: 0x0014E9A8 File Offset: 0x0014CDA8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.parms.Length);
			for (int i = 0; i < this.parms.Length; i++)
			{
				this.parms[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007334 RID: 29492 RVA: 0x0014EA18 File Offset: 0x0014CE18
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.parms = new OpActTaskParam[(int)num];
			for (int i = 0; i < this.parms.Length; i++)
			{
				this.parms[i] = new OpActTaskParam();
				this.parms[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007335 RID: 29493 RVA: 0x0014EA9C File Offset: 0x0014CE9C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.parms.Length);
			for (int i = 0; i < this.parms.Length; i++)
			{
				this.parms[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007336 RID: 29494 RVA: 0x0014EB0C File Offset: 0x0014CF0C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.parms = new OpActTaskParam[(int)num];
			for (int i = 0; i < this.parms.Length; i++)
			{
				this.parms[i] = new OpActTaskParam();
				this.parms[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007337 RID: 29495 RVA: 0x0014EB90 File Offset: 0x0014CF90
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			num += 2;
			for (int i = 0; i < this.parms.Length; i++)
			{
				num += this.parms[i].getLen();
			}
			return num;
		}

		// Token: 0x0400357C RID: 13692
		public uint dataId;

		// Token: 0x0400357D RID: 13693
		public uint curNum;

		// Token: 0x0400357E RID: 13694
		public byte state;

		// Token: 0x0400357F RID: 13695
		public OpActTaskParam[] parms = new OpActTaskParam[0];
	}
}
