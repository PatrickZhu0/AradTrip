using System;

namespace Protocol
{
	// Token: 0x020009DA RID: 2522
	[Protocol]
	public class GateNotifySysSwitch : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070CF RID: 28879 RVA: 0x00145E88 File Offset: 0x00144288
		public uint GetMsgID()
		{
			return 300324U;
		}

		// Token: 0x060070D0 RID: 28880 RVA: 0x00145E8F File Offset: 0x0014428F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070D1 RID: 28881 RVA: 0x00145E97 File Offset: 0x00144297
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070D2 RID: 28882 RVA: 0x00145EA0 File Offset: 0x001442A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.cfg.Length);
			for (int i = 0; i < this.cfg.Length; i++)
			{
				this.cfg[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060070D3 RID: 28883 RVA: 0x00145EE8 File Offset: 0x001442E8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.cfg = new SysSwitchCfg[(int)num];
			for (int i = 0; i < this.cfg.Length; i++)
			{
				this.cfg[i] = new SysSwitchCfg();
				this.cfg[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060070D4 RID: 28884 RVA: 0x00145F44 File Offset: 0x00144344
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.cfg.Length);
			for (int i = 0; i < this.cfg.Length; i++)
			{
				this.cfg[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060070D5 RID: 28885 RVA: 0x00145F8C File Offset: 0x0014438C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.cfg = new SysSwitchCfg[(int)num];
			for (int i = 0; i < this.cfg.Length; i++)
			{
				this.cfg[i] = new SysSwitchCfg();
				this.cfg[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060070D6 RID: 28886 RVA: 0x00145FE8 File Offset: 0x001443E8
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.cfg.Length; i++)
			{
				num += this.cfg[i].getLen();
			}
			return num;
		}

		// Token: 0x0400335F RID: 13151
		public const uint MsgID = 300324U;

		// Token: 0x04003360 RID: 13152
		public uint Sequence;

		// Token: 0x04003361 RID: 13153
		public SysSwitchCfg[] cfg = new SysSwitchCfg[0];
	}
}
