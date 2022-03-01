using System;

namespace Protocol
{
	// Token: 0x02000C1A RID: 3098
	[Protocol]
	public class SceneGiveMoneyManageRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008170 RID: 33136 RVA: 0x0016D828 File Offset: 0x0016BC28
		public uint GetMsgID()
		{
			return 503304U;
		}

		// Token: 0x06008171 RID: 33137 RVA: 0x0016D82F File Offset: 0x0016BC2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008172 RID: 33138 RVA: 0x0016D837 File Offset: 0x0016BC37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008173 RID: 33139 RVA: 0x0016D840 File Offset: 0x0016BC40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008174 RID: 33140 RVA: 0x0016D850 File Offset: 0x0016BC50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008175 RID: 33141 RVA: 0x0016D860 File Offset: 0x0016BC60
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008176 RID: 33142 RVA: 0x0016D870 File Offset: 0x0016BC70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008177 RID: 33143 RVA: 0x0016D880 File Offset: 0x0016BC80
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DCB RID: 15819
		public const uint MsgID = 503304U;

		// Token: 0x04003DCC RID: 15820
		public uint Sequence;

		// Token: 0x04003DCD RID: 15821
		public uint result;
	}
}
