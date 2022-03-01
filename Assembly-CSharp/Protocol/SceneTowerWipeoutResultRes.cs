using System;

namespace Protocol
{
	// Token: 0x020007D6 RID: 2006
	[Protocol]
	public class SceneTowerWipeoutResultRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060F1 RID: 24817 RVA: 0x001232B8 File Offset: 0x001216B8
		public uint GetMsgID()
		{
			return 507204U;
		}

		// Token: 0x060060F2 RID: 24818 RVA: 0x001232BF File Offset: 0x001216BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060F3 RID: 24819 RVA: 0x001232C7 File Offset: 0x001216C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060F4 RID: 24820 RVA: 0x001232D0 File Offset: 0x001216D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060060F5 RID: 24821 RVA: 0x00123324 File Offset: 0x00121724
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

		// Token: 0x060060F6 RID: 24822 RVA: 0x0012338C File Offset: 0x0012178C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060060F7 RID: 24823 RVA: 0x001233E0 File Offset: 0x001217E0
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

		// Token: 0x060060F8 RID: 24824 RVA: 0x00123448 File Offset: 0x00121848
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

		// Token: 0x0400286C RID: 10348
		public const uint MsgID = 507204U;

		// Token: 0x0400286D RID: 10349
		public uint Sequence;

		// Token: 0x0400286E RID: 10350
		public uint result;

		// Token: 0x0400286F RID: 10351
		public SceneDungeonDropItem[] items = new SceneDungeonDropItem[0];
	}
}
