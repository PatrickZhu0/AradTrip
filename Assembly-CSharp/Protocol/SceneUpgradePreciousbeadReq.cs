using System;

namespace Protocol
{
	// Token: 0x02000962 RID: 2402
	[Protocol]
	public class SceneUpgradePreciousbeadReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CD6 RID: 27862 RVA: 0x0013C74C File Offset: 0x0013AB4C
		public uint GetMsgID()
		{
			return 501039U;
		}

		// Token: 0x06006CD7 RID: 27863 RVA: 0x0013C753 File Offset: 0x0013AB53
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CD8 RID: 27864 RVA: 0x0013C75B File Offset: 0x0013AB5B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CD9 RID: 27865 RVA: 0x0013C764 File Offset: 0x0013AB64
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mountedType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.precGuid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipGuid);
			BaseDLL.encode_int8(buffer, ref pos_, this.eqPrecHoleIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.precId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.consumePrecId);
		}

		// Token: 0x06006CDA RID: 27866 RVA: 0x0013C7C8 File Offset: 0x0013ABC8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mountedType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.precGuid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipGuid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.eqPrecHoleIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.precId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.consumePrecId);
		}

		// Token: 0x06006CDB RID: 27867 RVA: 0x0013C82C File Offset: 0x0013AC2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mountedType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.precGuid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipGuid);
			BaseDLL.encode_int8(buffer, ref pos_, this.eqPrecHoleIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.precId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.consumePrecId);
		}

		// Token: 0x06006CDC RID: 27868 RVA: 0x0013C890 File Offset: 0x0013AC90
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mountedType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.precGuid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipGuid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.eqPrecHoleIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.precId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.consumePrecId);
		}

		// Token: 0x06006CDD RID: 27869 RVA: 0x0013C8F4 File Offset: 0x0013ACF4
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			num += 8;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003141 RID: 12609
		public const uint MsgID = 501039U;

		// Token: 0x04003142 RID: 12610
		public uint Sequence;

		// Token: 0x04003143 RID: 12611
		public byte mountedType;

		// Token: 0x04003144 RID: 12612
		public ulong precGuid;

		// Token: 0x04003145 RID: 12613
		public ulong equipGuid;

		// Token: 0x04003146 RID: 12614
		public byte eqPrecHoleIndex;

		// Token: 0x04003147 RID: 12615
		public uint precId;

		// Token: 0x04003148 RID: 12616
		public uint consumePrecId;
	}
}
