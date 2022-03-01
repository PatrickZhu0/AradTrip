using System;

namespace Protocol
{
	// Token: 0x020006F5 RID: 1781
	[Protocol]
	public class SceneBattleChangeSkillsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A19 RID: 23065 RVA: 0x00112560 File Offset: 0x00110960
		public uint GetMsgID()
		{
			return 508903U;
		}

		// Token: 0x06005A1A RID: 23066 RVA: 0x00112567 File Offset: 0x00110967
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A1B RID: 23067 RVA: 0x0011256F File Offset: 0x0011096F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A1C RID: 23068 RVA: 0x00112578 File Offset: 0x00110978
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.configType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005A1D RID: 23069 RVA: 0x001125CC File Offset: 0x001109CC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.configType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skills = new ChangeSkill[(int)num];
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i] = new ChangeSkill();
				this.skills[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005A1E RID: 23070 RVA: 0x00112634 File Offset: 0x00110A34
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.configType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005A1F RID: 23071 RVA: 0x00112688 File Offset: 0x00110A88
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.configType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skills = new ChangeSkill[(int)num];
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i] = new ChangeSkill();
				this.skills[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005A20 RID: 23072 RVA: 0x001126F0 File Offset: 0x00110AF0
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.skills.Length; i++)
			{
				num += this.skills[i].getLen();
			}
			return num;
		}

		// Token: 0x0400248B RID: 9355
		public const uint MsgID = 508903U;

		// Token: 0x0400248C RID: 9356
		public uint Sequence;

		// Token: 0x0400248D RID: 9357
		public byte configType;

		// Token: 0x0400248E RID: 9358
		public ChangeSkill[] skills = new ChangeSkill[0];
	}
}
