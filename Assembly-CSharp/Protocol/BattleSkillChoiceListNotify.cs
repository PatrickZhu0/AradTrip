using System;

namespace Protocol
{
	// Token: 0x0200071E RID: 1822
	[Protocol]
	public class BattleSkillChoiceListNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B7E RID: 23422 RVA: 0x00115350 File Offset: 0x00113750
		public uint GetMsgID()
		{
			return 508939U;
		}

		// Token: 0x06005B7F RID: 23423 RVA: 0x00115357 File Offset: 0x00113757
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B80 RID: 23424 RVA: 0x0011535F File Offset: 0x0011375F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B81 RID: 23425 RVA: 0x00115368 File Offset: 0x00113768
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillList.Length);
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B82 RID: 23426 RVA: 0x001153B0 File Offset: 0x001137B0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillList = new ChiJiSkill[(int)num];
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i] = new ChiJiSkill();
				this.skillList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B83 RID: 23427 RVA: 0x0011540C File Offset: 0x0011380C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillList.Length);
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B84 RID: 23428 RVA: 0x00115454 File Offset: 0x00113854
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillList = new ChiJiSkill[(int)num];
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i] = new ChiJiSkill();
				this.skillList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B85 RID: 23429 RVA: 0x001154B0 File Offset: 0x001138B0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.skillList.Length; i++)
			{
				num += this.skillList[i].getLen();
			}
			return num;
		}

		// Token: 0x0400254D RID: 9549
		public const uint MsgID = 508939U;

		// Token: 0x0400254E RID: 9550
		public uint Sequence;

		// Token: 0x0400254F RID: 9551
		public ChiJiSkill[] skillList = new ChiJiSkill[0];
	}
}
