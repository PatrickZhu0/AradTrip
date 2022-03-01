using System;

namespace Protocol
{
	// Token: 0x020009A4 RID: 2468
	[Protocol]
	public class SceneBeadConvertReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F13 RID: 28435 RVA: 0x0014122E File Offset: 0x0013F62E
		public uint GetMsgID()
		{
			return 501090U;
		}

		// Token: 0x06006F14 RID: 28436 RVA: 0x00141235 File Offset: 0x0013F635
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F15 RID: 28437 RVA: 0x0014123D File Offset: 0x0013F63D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F16 RID: 28438 RVA: 0x00141246 File Offset: 0x0013F646
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.beadGuid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.materialGuid);
		}

		// Token: 0x06006F17 RID: 28439 RVA: 0x00141264 File Offset: 0x0013F664
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.beadGuid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.materialGuid);
		}

		// Token: 0x06006F18 RID: 28440 RVA: 0x00141282 File Offset: 0x0013F682
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.beadGuid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.materialGuid);
		}

		// Token: 0x06006F19 RID: 28441 RVA: 0x001412A0 File Offset: 0x0013F6A0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.beadGuid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.materialGuid);
		}

		// Token: 0x06006F1A RID: 28442 RVA: 0x001412C0 File Offset: 0x0013F6C0
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04003266 RID: 12902
		public const uint MsgID = 501090U;

		// Token: 0x04003267 RID: 12903
		public uint Sequence;

		// Token: 0x04003268 RID: 12904
		public ulong beadGuid;

		// Token: 0x04003269 RID: 12905
		public ulong materialGuid;
	}
}
