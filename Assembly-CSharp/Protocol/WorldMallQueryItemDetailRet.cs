using System;

namespace Protocol
{
	// Token: 0x02000917 RID: 2327
	[Protocol]
	public class WorldMallQueryItemDetailRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A3C RID: 27196 RVA: 0x00138408 File Offset: 0x00136808
		public uint GetMsgID()
		{
			return 602806U;
		}

		// Token: 0x06006A3D RID: 27197 RVA: 0x0013840F File Offset: 0x0013680F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A3E RID: 27198 RVA: 0x00138417 File Offset: 0x00136817
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A3F RID: 27199 RVA: 0x00138420 File Offset: 0x00136820
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.details.Length);
			for (int i = 0; i < this.details.Length; i++)
			{
				this.details[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A40 RID: 27200 RVA: 0x00138468 File Offset: 0x00136868
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.details = new MallGiftDetail[(int)num];
			for (int i = 0; i < this.details.Length; i++)
			{
				this.details[i] = new MallGiftDetail();
				this.details[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A41 RID: 27201 RVA: 0x001384C4 File Offset: 0x001368C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.details.Length);
			for (int i = 0; i < this.details.Length; i++)
			{
				this.details[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A42 RID: 27202 RVA: 0x0013850C File Offset: 0x0013690C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.details = new MallGiftDetail[(int)num];
			for (int i = 0; i < this.details.Length; i++)
			{
				this.details[i] = new MallGiftDetail();
				this.details[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A43 RID: 27203 RVA: 0x00138568 File Offset: 0x00136968
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.details.Length; i++)
			{
				num += this.details[i].getLen();
			}
			return num;
		}

		// Token: 0x0400302C RID: 12332
		public const uint MsgID = 602806U;

		// Token: 0x0400302D RID: 12333
		public uint Sequence;

		// Token: 0x0400302E RID: 12334
		public MallGiftDetail[] details = new MallGiftDetail[0];
	}
}
