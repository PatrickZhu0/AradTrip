using System;

namespace Protocol
{
	// Token: 0x02000935 RID: 2357
	[Protocol]
	public class SCOpenMagBoxRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B44 RID: 27460 RVA: 0x00139E98 File Offset: 0x00138298
		public uint GetMsgID()
		{
			return 500970U;
		}

		// Token: 0x06006B45 RID: 27461 RVA: 0x00139E9F File Offset: 0x0013829F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B46 RID: 27462 RVA: 0x00139EA7 File Offset: 0x001382A7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B47 RID: 27463 RVA: 0x00139EB0 File Offset: 0x001382B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewards.Length);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B48 RID: 27464 RVA: 0x00139F04 File Offset: 0x00138304
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewards = new OpenJarResult[(int)num];
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i] = new OpenJarResult();
				this.rewards[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B49 RID: 27465 RVA: 0x00139F6C File Offset: 0x0013836C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewards.Length);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B4A RID: 27466 RVA: 0x00139FC0 File Offset: 0x001383C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewards = new OpenJarResult[(int)num];
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i] = new OpenJarResult();
				this.rewards[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B4B RID: 27467 RVA: 0x0013A028 File Offset: 0x00138428
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.rewards.Length; i++)
			{
				num += this.rewards[i].getLen();
			}
			return num;
		}

		// Token: 0x0400309F RID: 12447
		public const uint MsgID = 500970U;

		// Token: 0x040030A0 RID: 12448
		public uint Sequence;

		// Token: 0x040030A1 RID: 12449
		public uint retCode;

		// Token: 0x040030A2 RID: 12450
		public OpenJarResult[] rewards = new OpenJarResult[0];
	}
}
