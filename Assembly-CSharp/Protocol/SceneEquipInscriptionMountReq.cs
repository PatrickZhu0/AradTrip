using System;

namespace Protocol
{
	// Token: 0x02000997 RID: 2455
	[Protocol]
	public class SceneEquipInscriptionMountReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EA1 RID: 28321 RVA: 0x0013FF30 File Offset: 0x0013E330
		public uint GetMsgID()
		{
			return 501077U;
		}

		// Token: 0x06006EA2 RID: 28322 RVA: 0x0013FF37 File Offset: 0x0013E337
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EA3 RID: 28323 RVA: 0x0013FF3F File Offset: 0x0013E33F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EA4 RID: 28324 RVA: 0x0013FF48 File Offset: 0x0013E348
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.inscriptionGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x06006EA5 RID: 28325 RVA: 0x0013FF82 File Offset: 0x0013E382
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inscriptionGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x06006EA6 RID: 28326 RVA: 0x0013FFBC File Offset: 0x0013E3BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.inscriptionGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x06006EA7 RID: 28327 RVA: 0x0013FFF6 File Offset: 0x0013E3F6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inscriptionGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x06006EA8 RID: 28328 RVA: 0x00140030 File Offset: 0x0013E430
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400321C RID: 12828
		public const uint MsgID = 501077U;

		// Token: 0x0400321D RID: 12829
		public uint Sequence;

		// Token: 0x0400321E RID: 12830
		public ulong guid;

		// Token: 0x0400321F RID: 12831
		public uint index;

		// Token: 0x04003220 RID: 12832
		public ulong inscriptionGuid;

		// Token: 0x04003221 RID: 12833
		public uint inscriptionId;
	}
}
