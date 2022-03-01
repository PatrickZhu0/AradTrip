using System;
using System.Collections.Generic;

namespace Battle
{
	// Token: 0x02001089 RID: 4233
	public class BattleInfo
	{
		// Token: 0x06009FA8 RID: 40872 RVA: 0x001FFAB4 File Offset: 0x001FDEB4
		public void KillMonster(int id)
		{
			if (id < 0)
			{
				return;
			}
			int num = this.killedMonsters.BinarySearch(id);
			if (num < 0)
			{
				this.killedMonsters.Insert(~num, id);
			}
		}

		// Token: 0x04005854 RID: 22612
		public int dungeonId = -1;

		// Token: 0x04005855 RID: 22613
		public uint key3;

		// Token: 0x04005856 RID: 22614
		public int startAreaId = -1;

		// Token: 0x04005857 RID: 22615
		public uint randomSeed = 305419896U;

		// Token: 0x04005858 RID: 22616
		public int areaId = -1;

		// Token: 0x04005859 RID: 22617
		public uint key4;

		// Token: 0x0400585A RID: 22618
		public int bestRecordTime = -1;

		// Token: 0x0400585B RID: 22619
		public int maxComboCount = -1;

		// Token: 0x0400585C RID: 22620
		public List<DungeonArea> areas = new List<DungeonArea>();

		// Token: 0x0400585D RID: 22621
		public List<DungeonAddMonsterDropItem> addMonsterDropItem = new List<DungeonAddMonsterDropItem>();

		// Token: 0x0400585E RID: 22622
		public uint key2;

		// Token: 0x0400585F RID: 22623
		public DungeonHellInfo dungeonHealInfo = new DungeonHellInfo();

		// Token: 0x04005860 RID: 22624
		public List<DungeonDropItem> dropItems = new List<DungeonDropItem>();

		// Token: 0x04005861 RID: 22625
		public List<DungeonDropItem> bossDropItems = new List<DungeonDropItem>();

		// Token: 0x04005862 RID: 22626
		public uint key1;

		// Token: 0x04005863 RID: 22627
		public List<uint> dropOverMonster = new List<uint>();

		// Token: 0x04005864 RID: 22628
		public byte endRaceDropMulti;

		// Token: 0x04005865 RID: 22629
		public List<DungeonDropItem> dropCacheItemIds = new List<DungeonDropItem>();

		// Token: 0x04005866 RID: 22630
		public List<int> dropItemIds = new List<int>();

		// Token: 0x04005867 RID: 22631
		public List<int> pickedItems = new List<int>();

		// Token: 0x04005868 RID: 22632
		public List<int> killedMonsters = new List<int>();
	}
}
