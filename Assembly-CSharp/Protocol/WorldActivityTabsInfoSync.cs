using System;

namespace Protocol
{
	// Token: 0x02000688 RID: 1672
	[Protocol]
	public class WorldActivityTabsInfoSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056F0 RID: 22256 RVA: 0x00109D8D File Offset: 0x0010818D
		public uint GetMsgID()
		{
			return 607407U;
		}

		// Token: 0x060056F1 RID: 22257 RVA: 0x00109D94 File Offset: 0x00108194
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056F2 RID: 22258 RVA: 0x00109D9C File Offset: 0x0010819C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056F3 RID: 22259 RVA: 0x00109DA8 File Offset: 0x001081A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tabsInfo.Length);
			for (int i = 0; i < this.tabsInfo.Length; i++)
			{
				this.tabsInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060056F4 RID: 22260 RVA: 0x00109DF0 File Offset: 0x001081F0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.tabsInfo = new ActivityTabInfo[(int)num];
			for (int i = 0; i < this.tabsInfo.Length; i++)
			{
				this.tabsInfo[i] = new ActivityTabInfo();
				this.tabsInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060056F5 RID: 22261 RVA: 0x00109E4C File Offset: 0x0010824C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tabsInfo.Length);
			for (int i = 0; i < this.tabsInfo.Length; i++)
			{
				this.tabsInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060056F6 RID: 22262 RVA: 0x00109E94 File Offset: 0x00108294
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.tabsInfo = new ActivityTabInfo[(int)num];
			for (int i = 0; i < this.tabsInfo.Length; i++)
			{
				this.tabsInfo[i] = new ActivityTabInfo();
				this.tabsInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060056F7 RID: 22263 RVA: 0x00109EF0 File Offset: 0x001082F0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.tabsInfo.Length; i++)
			{
				num += this.tabsInfo[i].getLen();
			}
			return num;
		}

		// Token: 0x04002288 RID: 8840
		public const uint MsgID = 607407U;

		// Token: 0x04002289 RID: 8841
		public uint Sequence;

		// Token: 0x0400228A RID: 8842
		public ActivityTabInfo[] tabsInfo = new ActivityTabInfo[0];
	}
}
