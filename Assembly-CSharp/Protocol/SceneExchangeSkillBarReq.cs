using System;

namespace Protocol
{
	// Token: 0x02000B36 RID: 2870
	[Protocol]
	public class SceneExchangeSkillBarReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AAD RID: 31405 RVA: 0x00160198 File Offset: 0x0015E598
		public uint GetMsgID()
		{
			return 501201U;
		}

		// Token: 0x06007AAE RID: 31406 RVA: 0x0016019F File Offset: 0x0015E59F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007AAF RID: 31407 RVA: 0x001601A7 File Offset: 0x0015E5A7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007AB0 RID: 31408 RVA: 0x001601B0 File Offset: 0x0015E5B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.configType);
			this.skillBars.encode(buffer, ref pos_);
		}

		// Token: 0x06007AB1 RID: 31409 RVA: 0x001601CD File Offset: 0x0015E5CD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.configType);
			this.skillBars.decode(buffer, ref pos_);
		}

		// Token: 0x06007AB2 RID: 31410 RVA: 0x001601EA File Offset: 0x0015E5EA
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.configType);
			this.skillBars.encode(buffer, ref pos_);
		}

		// Token: 0x06007AB3 RID: 31411 RVA: 0x00160207 File Offset: 0x0015E607
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.configType);
			this.skillBars.decode(buffer, ref pos_);
		}

		// Token: 0x06007AB4 RID: 31412 RVA: 0x00160224 File Offset: 0x0015E624
		public int getLen()
		{
			int num = 0;
			num++;
			return num + this.skillBars.getLen();
		}

		// Token: 0x04003A2A RID: 14890
		public const uint MsgID = 501201U;

		// Token: 0x04003A2B RID: 14891
		public uint Sequence;

		// Token: 0x04003A2C RID: 14892
		public byte configType;

		// Token: 0x04003A2D RID: 14893
		public SkillBars skillBars = new SkillBars();
	}
}
