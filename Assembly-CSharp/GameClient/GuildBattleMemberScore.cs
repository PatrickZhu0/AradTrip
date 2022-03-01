using System;

namespace GameClient
{
	// Token: 0x02000659 RID: 1625
	public class GuildBattleMemberScore : GuildBattleScore
	{
		// Token: 0x060055CF RID: 21967 RVA: 0x00106F1C File Offset: 0x0010531C
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
			this.guildName = StringHelper.BytesToString(array);
			return true;
		}

		// Token: 0x040021D9 RID: 8665
		public string guildName;
	}
}
