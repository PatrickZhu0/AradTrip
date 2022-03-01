using System;

namespace Protocol
{
	// Token: 0x020007D8 RID: 2008
	[Protocol]
	public class SceneTowerWipeoutQueryResultRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006103 RID: 24835 RVA: 0x00123550 File Offset: 0x00121950
		public uint GetMsgID()
		{
			return 507212U;
		}

		// Token: 0x06006104 RID: 24836 RVA: 0x00123557 File Offset: 0x00121957
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006105 RID: 24837 RVA: 0x0012355F File Offset: 0x0012195F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006106 RID: 24838 RVA: 0x00123568 File Offset: 0x00121968
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006107 RID: 24839 RVA: 0x001235BC File Offset: 0x001219BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new SceneDungeonDropItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006108 RID: 24840 RVA: 0x00123624 File Offset: 0x00121A24
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006109 RID: 24841 RVA: 0x00123678 File Offset: 0x00121A78
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new SceneDungeonDropItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600610A RID: 24842 RVA: 0x001236E0 File Offset: 0x00121AE0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x04002874 RID: 10356
		public const uint MsgID = 507212U;

		// Token: 0x04002875 RID: 10357
		public uint Sequence;

		// Token: 0x04002876 RID: 10358
		public uint result;

		// Token: 0x04002877 RID: 10359
		public SceneDungeonDropItem[] items = new SceneDungeonDropItem[0];
	}
}
