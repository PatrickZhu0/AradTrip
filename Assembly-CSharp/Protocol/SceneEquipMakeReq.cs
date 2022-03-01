using System;

namespace Protocol
{
	// Token: 0x02000927 RID: 2343
	[Protocol]
	public class SceneEquipMakeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006ACC RID: 27340 RVA: 0x00139344 File Offset: 0x00137744
		public uint GetMsgID()
		{
			return 500954U;
		}

		// Token: 0x06006ACD RID: 27341 RVA: 0x0013934B File Offset: 0x0013774B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006ACE RID: 27342 RVA: 0x00139353 File Offset: 0x00137753
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006ACF RID: 27343 RVA: 0x0013935C File Offset: 0x0013775C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipId);
		}

		// Token: 0x06006AD0 RID: 27344 RVA: 0x0013936C File Offset: 0x0013776C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipId);
		}

		// Token: 0x06006AD1 RID: 27345 RVA: 0x0013937C File Offset: 0x0013777C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipId);
		}

		// Token: 0x06006AD2 RID: 27346 RVA: 0x0013938C File Offset: 0x0013778C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipId);
		}

		// Token: 0x06006AD3 RID: 27347 RVA: 0x0013939C File Offset: 0x0013779C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003071 RID: 12401
		public const uint MsgID = 500954U;

		// Token: 0x04003072 RID: 12402
		public uint Sequence;

		// Token: 0x04003073 RID: 12403
		public uint equipId;
	}
}
