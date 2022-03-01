using System;

namespace Protocol
{
	// Token: 0x02000B16 RID: 2838
	[Protocol]
	public class SceneItemAdd : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079D5 RID: 31189 RVA: 0x0015E5C1 File Offset: 0x0015C9C1
		public uint GetMsgID()
		{
			return 500626U;
		}

		// Token: 0x060079D6 RID: 31190 RVA: 0x0015E5C8 File Offset: 0x0015C9C8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079D7 RID: 31191 RVA: 0x0015E5D0 File Offset: 0x0015C9D0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079D8 RID: 31192 RVA: 0x0015E5DC File Offset: 0x0015C9DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060079D9 RID: 31193 RVA: 0x0015E630 File Offset: 0x0015CA30
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new SceneItemInfo[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new SceneItemInfo();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060079DA RID: 31194 RVA: 0x0015E698 File Offset: 0x0015CA98
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060079DB RID: 31195 RVA: 0x0015E6EC File Offset: 0x0015CAEC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new SceneItemInfo[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new SceneItemInfo();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060079DC RID: 31196 RVA: 0x0015E754 File Offset: 0x0015CB54
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.data.Length; i++)
			{
				num += this.data[i].getLen();
			}
			return num;
		}

		// Token: 0x04003974 RID: 14708
		public const uint MsgID = 500626U;

		// Token: 0x04003975 RID: 14709
		public uint Sequence;

		// Token: 0x04003976 RID: 14710
		public uint battleID;

		// Token: 0x04003977 RID: 14711
		public SceneItemInfo[] data = new SceneItemInfo[0];
	}
}
