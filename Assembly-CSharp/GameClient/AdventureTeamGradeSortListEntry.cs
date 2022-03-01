using System;

namespace GameClient
{
	// Token: 0x02000660 RID: 1632
	public class AdventureTeamGradeSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055DC RID: 21980 RVA: 0x00107154 File Offset: 0x00105554
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_uint16(buffer, ref pos, ref this.adventureTeamLevel);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos, ref array[i]);
			}
			this.adventureTeamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.adventureTeamScore);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.adventureTeamGrade);
			return true;
		}

		// Token: 0x040021EC RID: 8684
		public ushort adventureTeamLevel;

		// Token: 0x040021ED RID: 8685
		public string adventureTeamName;

		// Token: 0x040021EE RID: 8686
		public uint adventureTeamScore;

		// Token: 0x040021EF RID: 8687
		public uint adventureTeamGrade;
	}
}
