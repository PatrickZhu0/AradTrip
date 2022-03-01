using System;

namespace Protocol
{
	// Token: 0x02000C1F RID: 3103
	[Protocol]
	public class SceneWarpStoneChargeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008197 RID: 33175 RVA: 0x0016DAFC File Offset: 0x0016BEFC
		public uint GetMsgID()
		{
			return 506903U;
		}

		// Token: 0x06008198 RID: 33176 RVA: 0x0016DB03 File Offset: 0x0016BF03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008199 RID: 33177 RVA: 0x0016DB0B File Offset: 0x0016BF0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600819A RID: 33178 RVA: 0x0016DB14 File Offset: 0x0016BF14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.info.Length);
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600819B RID: 33179 RVA: 0x0016DB68 File Offset: 0x0016BF68
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.info = new ChargeInfo[(int)num];
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i] = new ChargeInfo();
				this.info[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600819C RID: 33180 RVA: 0x0016DBD0 File Offset: 0x0016BFD0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.info.Length);
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600819D RID: 33181 RVA: 0x0016DC24 File Offset: 0x0016C024
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.info = new ChargeInfo[(int)num];
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i] = new ChargeInfo();
				this.info[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600819E RID: 33182 RVA: 0x0016DC8C File Offset: 0x0016C08C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.info.Length; i++)
			{
				num += this.info[i].getLen();
			}
			return num;
		}

		// Token: 0x04003DD9 RID: 15833
		public const uint MsgID = 506903U;

		// Token: 0x04003DDA RID: 15834
		public uint Sequence;

		// Token: 0x04003DDB RID: 15835
		public uint id;

		// Token: 0x04003DDC RID: 15836
		public ChargeInfo[] info = new ChargeInfo[0];
	}
}
