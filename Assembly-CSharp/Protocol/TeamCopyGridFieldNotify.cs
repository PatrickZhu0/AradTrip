using System;

namespace Protocol
{
	// Token: 0x02000C0B RID: 3083
	[Protocol]
	public class TeamCopyGridFieldNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080F8 RID: 33016 RVA: 0x0016C5ED File Offset: 0x0016A9ED
		public uint GetMsgID()
		{
			return 1100078U;
		}

		// Token: 0x060080F9 RID: 33017 RVA: 0x0016C5F4 File Offset: 0x0016A9F4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080FA RID: 33018 RVA: 0x0016C5FC File Offset: 0x0016A9FC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080FB RID: 33019 RVA: 0x0016C608 File Offset: 0x0016AA08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.fieldVec.Length);
			for (int i = 0; i < this.fieldVec.Length; i++)
			{
				this.fieldVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060080FC RID: 33020 RVA: 0x0016C650 File Offset: 0x0016AA50
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.fieldVec = new TCGridObjData[(int)num];
			for (int i = 0; i < this.fieldVec.Length; i++)
			{
				this.fieldVec[i] = new TCGridObjData();
				this.fieldVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060080FD RID: 33021 RVA: 0x0016C6AC File Offset: 0x0016AAAC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.fieldVec.Length);
			for (int i = 0; i < this.fieldVec.Length; i++)
			{
				this.fieldVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060080FE RID: 33022 RVA: 0x0016C6F4 File Offset: 0x0016AAF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.fieldVec = new TCGridObjData[(int)num];
			for (int i = 0; i < this.fieldVec.Length; i++)
			{
				this.fieldVec[i] = new TCGridObjData();
				this.fieldVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060080FF RID: 33023 RVA: 0x0016C750 File Offset: 0x0016AB50
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.fieldVec.Length; i++)
			{
				num += this.fieldVec[i].getLen();
			}
			return num;
		}

		// Token: 0x04003D8A RID: 15754
		public const uint MsgID = 1100078U;

		// Token: 0x04003D8B RID: 15755
		public uint Sequence;

		// Token: 0x04003D8C RID: 15756
		public TCGridObjData[] fieldVec = new TCGridObjData[0];
	}
}
