using System;

namespace Protocol
{
	// Token: 0x02000B62 RID: 2914
	[Protocol]
	public class SceneRecommendSkillsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C15 RID: 31765 RVA: 0x00162DC8 File Offset: 0x001611C8
		public uint GetMsgID()
		{
			return 500715U;
		}

		// Token: 0x06007C16 RID: 31766 RVA: 0x00162DCF File Offset: 0x001611CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C17 RID: 31767 RVA: 0x00162DD7 File Offset: 0x001611D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C18 RID: 31768 RVA: 0x00162DE0 File Offset: 0x001611E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
		}

		// Token: 0x06007C19 RID: 31769 RVA: 0x00162DF0 File Offset: 0x001611F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
		}

		// Token: 0x06007C1A RID: 31770 RVA: 0x00162E00 File Offset: 0x00161200
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
		}

		// Token: 0x06007C1B RID: 31771 RVA: 0x00162E10 File Offset: 0x00161210
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
		}

		// Token: 0x06007C1C RID: 31772 RVA: 0x00162E20 File Offset: 0x00161220
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003AC9 RID: 15049
		public const uint MsgID = 500715U;

		// Token: 0x04003ACA RID: 15050
		public uint Sequence;

		// Token: 0x04003ACB RID: 15051
		public uint configType;
	}
}
