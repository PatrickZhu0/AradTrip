using System;

namespace Protocol
{
	// Token: 0x02000720 RID: 1824
	[Protocol]
	public class BattleChoiceSkillRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B90 RID: 23440 RVA: 0x0011556C File Offset: 0x0011396C
		public uint GetMsgID()
		{
			return 508941U;
		}

		// Token: 0x06005B91 RID: 23441 RVA: 0x00115573 File Offset: 0x00113973
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B92 RID: 23442 RVA: 0x0011557B File Offset: 0x0011397B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B93 RID: 23443 RVA: 0x00115584 File Offset: 0x00113984
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillLvl);
		}

		// Token: 0x06005B94 RID: 23444 RVA: 0x001155B0 File Offset: 0x001139B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillLvl);
		}

		// Token: 0x06005B95 RID: 23445 RVA: 0x001155DC File Offset: 0x001139DC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillLvl);
		}

		// Token: 0x06005B96 RID: 23446 RVA: 0x00115608 File Offset: 0x00113A08
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillLvl);
		}

		// Token: 0x06005B97 RID: 23447 RVA: 0x00115634 File Offset: 0x00113A34
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002553 RID: 9555
		public const uint MsgID = 508941U;

		// Token: 0x04002554 RID: 9556
		public uint Sequence;

		// Token: 0x04002555 RID: 9557
		public uint retCode;

		// Token: 0x04002556 RID: 9558
		public uint skillId;

		// Token: 0x04002557 RID: 9559
		public uint skillLvl;
	}
}
