using System;

namespace Protocol
{
	// Token: 0x020007C0 RID: 1984
	[Protocol]
	public class SceneDungeonEnterNextAreaReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006031 RID: 24625 RVA: 0x00121014 File Offset: 0x0011F414
		public uint GetMsgID()
		{
			return 506807U;
		}

		// Token: 0x06006032 RID: 24626 RVA: 0x0012101B File Offset: 0x0011F41B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006033 RID: 24627 RVA: 0x00121023 File Offset: 0x0011F423
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006034 RID: 24628 RVA: 0x0012102C File Offset: 0x0011F42C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
			this.staticVal.encode(buffer, ref pos_);
		}

		// Token: 0x06006035 RID: 24629 RVA: 0x00121057 File Offset: 0x0011F457
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
			this.staticVal.decode(buffer, ref pos_);
		}

		// Token: 0x06006036 RID: 24630 RVA: 0x00121082 File Offset: 0x0011F482
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
			this.staticVal.encode(buffer, ref pos_);
		}

		// Token: 0x06006037 RID: 24631 RVA: 0x001210AD File Offset: 0x0011F4AD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
			this.staticVal.decode(buffer, ref pos_);
		}

		// Token: 0x06006038 RID: 24632 RVA: 0x001210D8 File Offset: 0x0011F4D8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + this.staticVal.getLen();
		}

		// Token: 0x040027F9 RID: 10233
		public const uint MsgID = 506807U;

		// Token: 0x040027FA RID: 10234
		public uint Sequence;

		// Token: 0x040027FB RID: 10235
		public uint areaId;

		// Token: 0x040027FC RID: 10236
		public uint lastFrame;

		// Token: 0x040027FD RID: 10237
		public DungeonStaticValue staticVal = new DungeonStaticValue();
	}
}
