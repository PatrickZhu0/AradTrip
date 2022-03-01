using System;

namespace Protocol
{
	// Token: 0x02000963 RID: 2403
	[Protocol]
	public class SceneUpgradePreciousbeadRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CDF RID: 27871 RVA: 0x0013C924 File Offset: 0x0013AD24
		public uint GetMsgID()
		{
			return 501040U;
		}

		// Token: 0x06006CE0 RID: 27872 RVA: 0x0013C92B File Offset: 0x0013AD2B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CE1 RID: 27873 RVA: 0x0013C933 File Offset: 0x0013AD33
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CE2 RID: 27874 RVA: 0x0013C93C File Offset: 0x0013AD3C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mountedType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.precId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addBuffId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.newPrebeadUid);
		}

		// Token: 0x06006CE3 RID: 27875 RVA: 0x0013C9A0 File Offset: 0x0013ADA0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mountedType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.precId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addBuffId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.newPrebeadUid);
		}

		// Token: 0x06006CE4 RID: 27876 RVA: 0x0013CA04 File Offset: 0x0013AE04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mountedType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.precId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addBuffId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.newPrebeadUid);
		}

		// Token: 0x06006CE5 RID: 27877 RVA: 0x0013CA68 File Offset: 0x0013AE68
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mountedType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.precId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addBuffId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.newPrebeadUid);
		}

		// Token: 0x06006CE6 RID: 27878 RVA: 0x0013CACC File Offset: 0x0013AECC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 8;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003149 RID: 12617
		public const uint MsgID = 501040U;

		// Token: 0x0400314A RID: 12618
		public uint Sequence;

		// Token: 0x0400314B RID: 12619
		public uint retCode;

		// Token: 0x0400314C RID: 12620
		public byte mountedType;

		// Token: 0x0400314D RID: 12621
		public ulong equipGuid;

		// Token: 0x0400314E RID: 12622
		public uint precId;

		// Token: 0x0400314F RID: 12623
		public uint addBuffId;

		// Token: 0x04003150 RID: 12624
		public ulong newPrebeadUid;
	}
}
