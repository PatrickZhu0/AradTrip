using System;

namespace Protocol
{
	// Token: 0x02000B0D RID: 2829
	[Protocol]
	public class SceneNpcAdd : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600798D RID: 31117 RVA: 0x0015DBE1 File Offset: 0x0015BFE1
		public uint GetMsgID()
		{
			return 500622U;
		}

		// Token: 0x0600798E RID: 31118 RVA: 0x0015DBE8 File Offset: 0x0015BFE8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600798F RID: 31119 RVA: 0x0015DBF0 File Offset: 0x0015BFF0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007990 RID: 31120 RVA: 0x0015DBFC File Offset: 0x0015BFFC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007991 RID: 31121 RVA: 0x0015DC44 File Offset: 0x0015C044
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new SceneNpcInfo[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new SceneNpcInfo();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007992 RID: 31122 RVA: 0x0015DCA0 File Offset: 0x0015C0A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007993 RID: 31123 RVA: 0x0015DCE8 File Offset: 0x0015C0E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new SceneNpcInfo[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new SceneNpcInfo();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007994 RID: 31124 RVA: 0x0015DD44 File Offset: 0x0015C144
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.data.Length; i++)
			{
				num += this.data[i].getLen();
			}
			return num;
		}

		// Token: 0x0400395A RID: 14682
		public const uint MsgID = 500622U;

		// Token: 0x0400395B RID: 14683
		public uint Sequence;

		// Token: 0x0400395C RID: 14684
		public SceneNpcInfo[] data = new SceneNpcInfo[0];
	}
}
