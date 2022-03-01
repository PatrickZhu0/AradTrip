using System;

namespace Protocol
{
	// Token: 0x02000B67 RID: 2919
	[Protocol]
	public class SceneBuySkillPageReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C42 RID: 31810 RVA: 0x001630C0 File Offset: 0x001614C0
		public uint GetMsgID()
		{
			return 500720U;
		}

		// Token: 0x06007C43 RID: 31811 RVA: 0x001630C7 File Offset: 0x001614C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C44 RID: 31812 RVA: 0x001630CF File Offset: 0x001614CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C45 RID: 31813 RVA: 0x001630D8 File Offset: 0x001614D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
			BaseDLL.encode_int8(buffer, ref pos_, this.page);
		}

		// Token: 0x06007C46 RID: 31814 RVA: 0x001630F6 File Offset: 0x001614F6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.page);
		}

		// Token: 0x06007C47 RID: 31815 RVA: 0x00163114 File Offset: 0x00161514
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
			BaseDLL.encode_int8(buffer, ref pos_, this.page);
		}

		// Token: 0x06007C48 RID: 31816 RVA: 0x00163132 File Offset: 0x00161532
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.page);
		}

		// Token: 0x06007C49 RID: 31817 RVA: 0x00163150 File Offset: 0x00161550
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003ADB RID: 15067
		public const uint MsgID = 500720U;

		// Token: 0x04003ADC RID: 15068
		public uint Sequence;

		// Token: 0x04003ADD RID: 15069
		public uint configType;

		// Token: 0x04003ADE RID: 15070
		public byte page;
	}
}
