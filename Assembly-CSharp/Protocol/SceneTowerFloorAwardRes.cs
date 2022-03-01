using System;

namespace Protocol
{
	// Token: 0x020007DE RID: 2014
	[Protocol]
	public class SceneTowerFloorAwardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006139 RID: 24889 RVA: 0x00123904 File Offset: 0x00121D04
		public uint GetMsgID()
		{
			return 507210U;
		}

		// Token: 0x0600613A RID: 24890 RVA: 0x0012390B File Offset: 0x00121D0B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600613B RID: 24891 RVA: 0x00123913 File Offset: 0x00121D13
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600613C RID: 24892 RVA: 0x0012391C File Offset: 0x00121D1C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600613D RID: 24893 RVA: 0x00123970 File Offset: 0x00121D70
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

		// Token: 0x0600613E RID: 24894 RVA: 0x001239D8 File Offset: 0x00121DD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600613F RID: 24895 RVA: 0x00123A2C File Offset: 0x00121E2C
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

		// Token: 0x06006140 RID: 24896 RVA: 0x00123A94 File Offset: 0x00121E94
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

		// Token: 0x04002885 RID: 10373
		public const uint MsgID = 507210U;

		// Token: 0x04002886 RID: 10374
		public uint Sequence;

		// Token: 0x04002887 RID: 10375
		public uint result;

		// Token: 0x04002888 RID: 10376
		public SceneDungeonDropItem[] items = new SceneDungeonDropItem[0];
	}
}
