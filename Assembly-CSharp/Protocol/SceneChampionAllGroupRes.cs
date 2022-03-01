using System;

namespace Protocol
{
	// Token: 0x0200076E RID: 1902
	[Protocol]
	public class SceneChampionAllGroupRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DF7 RID: 24055 RVA: 0x00119E78 File Offset: 0x00118278
		public uint GetMsgID()
		{
			return 509833U;
		}

		// Token: 0x06005DF8 RID: 24056 RVA: 0x00119E7F File Offset: 0x0011827F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DF9 RID: 24057 RVA: 0x00119E87 File Offset: 0x00118287
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DFA RID: 24058 RVA: 0x00119E90 File Offset: 0x00118290
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.groups.Length);
			for (int i = 0; i < this.groups.Length; i++)
			{
				this.groups[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DFB RID: 24059 RVA: 0x00119ED8 File Offset: 0x001182D8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.groups = new ChampionGroup[(int)num];
			for (int i = 0; i < this.groups.Length; i++)
			{
				this.groups[i] = new ChampionGroup();
				this.groups[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DFC RID: 24060 RVA: 0x00119F34 File Offset: 0x00118334
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.groups.Length);
			for (int i = 0; i < this.groups.Length; i++)
			{
				this.groups[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DFD RID: 24061 RVA: 0x00119F7C File Offset: 0x0011837C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.groups = new ChampionGroup[(int)num];
			for (int i = 0; i < this.groups.Length; i++)
			{
				this.groups[i] = new ChampionGroup();
				this.groups[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DFE RID: 24062 RVA: 0x00119FD8 File Offset: 0x001183D8
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.groups.Length; i++)
			{
				num += this.groups[i].getLen();
			}
			return num;
		}

		// Token: 0x04002687 RID: 9863
		public const uint MsgID = 509833U;

		// Token: 0x04002688 RID: 9864
		public uint Sequence;

		// Token: 0x04002689 RID: 9865
		public ChampionGroup[] groups = new ChampionGroup[0];
	}
}
