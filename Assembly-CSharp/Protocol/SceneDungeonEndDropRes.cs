using System;

namespace Protocol
{
	// Token: 0x020007D2 RID: 2002
	[Protocol]
	public class SceneDungeonEndDropRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060CD RID: 24781 RVA: 0x00122FEC File Offset: 0x001213EC
		public uint GetMsgID()
		{
			return 506824U;
		}

		// Token: 0x060060CE RID: 24782 RVA: 0x00122FF3 File Offset: 0x001213F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060CF RID: 24783 RVA: 0x00122FFB File Offset: 0x001213FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060D0 RID: 24784 RVA: 0x00123004 File Offset: 0x00121404
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.multi);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060060D1 RID: 24785 RVA: 0x00123058 File Offset: 0x00121458
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.multi);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new SceneDungeonDropItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060060D2 RID: 24786 RVA: 0x001230C0 File Offset: 0x001214C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.multi);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060060D3 RID: 24787 RVA: 0x00123114 File Offset: 0x00121514
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.multi);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new SceneDungeonDropItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060060D4 RID: 24788 RVA: 0x0012317C File Offset: 0x0012157C
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x04002861 RID: 10337
		public const uint MsgID = 506824U;

		// Token: 0x04002862 RID: 10338
		public uint Sequence;

		// Token: 0x04002863 RID: 10339
		public byte multi;

		// Token: 0x04002864 RID: 10340
		public SceneDungeonDropItem[] items = new SceneDungeonDropItem[0];
	}
}
