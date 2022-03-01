using System;

namespace Protocol
{
	// Token: 0x02000990 RID: 2448
	[Protocol]
	public class SceneEquipEnhanceChg : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E62 RID: 28258 RVA: 0x0013FA9C File Offset: 0x0013DE9C
		public uint GetMsgID()
		{
			return 501066U;
		}

		// Token: 0x06006E63 RID: 28259 RVA: 0x0013FAA3 File Offset: 0x0013DEA3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E64 RID: 28260 RVA: 0x0013FAAB File Offset: 0x0013DEAB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E65 RID: 28261 RVA: 0x0013FAB4 File Offset: 0x0013DEB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stuffID);
		}

		// Token: 0x06006E66 RID: 28262 RVA: 0x0013FAE0 File Offset: 0x0013DEE0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stuffID);
		}

		// Token: 0x06006E67 RID: 28263 RVA: 0x0013FB0C File Offset: 0x0013DF0C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stuffID);
		}

		// Token: 0x06006E68 RID: 28264 RVA: 0x0013FB38 File Offset: 0x0013DF38
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stuffID);
		}

		// Token: 0x06006E69 RID: 28265 RVA: 0x0013FB64 File Offset: 0x0013DF64
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + 4;
		}

		// Token: 0x04003201 RID: 12801
		public const uint MsgID = 501066U;

		// Token: 0x04003202 RID: 12802
		public uint Sequence;

		// Token: 0x04003203 RID: 12803
		public ulong euqipUid;

		// Token: 0x04003204 RID: 12804
		public byte enhanceType;

		// Token: 0x04003205 RID: 12805
		public uint stuffID;
	}
}
