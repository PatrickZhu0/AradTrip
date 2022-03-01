using System;

namespace Protocol
{
	// Token: 0x020007F0 RID: 2032
	[Protocol]
	public class WorldDungeonNotifyGetYellowEquip : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061DB RID: 25051 RVA: 0x0012477D File Offset: 0x00122B7D
		public uint GetMsgID()
		{
			return 606820U;
		}

		// Token: 0x060061DC RID: 25052 RVA: 0x00124784 File Offset: 0x00122B84
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061DD RID: 25053 RVA: 0x0012478C File Offset: 0x00122B8C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061DE RID: 25054 RVA: 0x00124795 File Offset: 0x00122B95
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x060061DF RID: 25055 RVA: 0x001247B3 File Offset: 0x00122BB3
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x060061E0 RID: 25056 RVA: 0x001247D1 File Offset: 0x00122BD1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x060061E1 RID: 25057 RVA: 0x001247EF File Offset: 0x00122BEF
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x060061E2 RID: 25058 RVA: 0x00124810 File Offset: 0x00122C10
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040028C2 RID: 10434
		public const uint MsgID = 606820U;

		// Token: 0x040028C3 RID: 10435
		public uint Sequence;

		// Token: 0x040028C4 RID: 10436
		public ulong roleId;

		// Token: 0x040028C5 RID: 10437
		public uint itemId;
	}
}
