using System;

namespace Protocol
{
	// Token: 0x02000901 RID: 2305
	[Protocol]
	public class SceneRandEquipQlvRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006979 RID: 27001 RVA: 0x00136C94 File Offset: 0x00135094
		public uint GetMsgID()
		{
			return 500942U;
		}

		// Token: 0x0600697A RID: 27002 RVA: 0x00136C9B File Offset: 0x0013509B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600697B RID: 27003 RVA: 0x00136CA3 File Offset: 0x001350A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600697C RID: 27004 RVA: 0x00136CAC File Offset: 0x001350AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600697D RID: 27005 RVA: 0x00136CBC File Offset: 0x001350BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600697E RID: 27006 RVA: 0x00136CCC File Offset: 0x001350CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600697F RID: 27007 RVA: 0x00136CDC File Offset: 0x001350DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006980 RID: 27008 RVA: 0x00136CEC File Offset: 0x001350EC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002FCD RID: 12237
		public const uint MsgID = 500942U;

		// Token: 0x04002FCE RID: 12238
		public uint Sequence;

		// Token: 0x04002FCF RID: 12239
		public uint code;
	}
}
