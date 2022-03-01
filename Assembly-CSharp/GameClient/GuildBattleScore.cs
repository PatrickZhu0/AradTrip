using System;

namespace GameClient
{
	// Token: 0x02000657 RID: 1623
	public class GuildBattleScore : BaseSortListEntry
	{
		// Token: 0x060055CB RID: 21963 RVA: 0x00106E24 File Offset: 0x00105224
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos, ref array[i]);
			}
			this.serverName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.score);
			return true;
		}

		// Token: 0x040021D4 RID: 8660
		public string serverName;

		// Token: 0x040021D5 RID: 8661
		public uint score;
	}
}
