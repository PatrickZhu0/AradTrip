using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CF4 RID: 7412
	public class HorseGamblingMapZoneModel : IHorseGamblingMapZoneModel
	{
		// Token: 0x06012381 RID: 74625 RVA: 0x0054E3F8 File Offset: 0x0054C7F8
		public HorseGamblingMapZoneModel(MapInfo msg)
		{
			this.Id = (int)msg.id;
			BetHorseMap tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseMap>(this.Id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			FlatBufferArray<string> terrainPaths = tableItem.TerrainPaths;
			if ((ulong)msg.terrain <= (ulong)((long)terrainPaths.Count))
			{
				this.TerrainPath = terrainPaths[(int)(msg.terrain - 1U)];
			}
			this.Phase = tableItem.MapPhase;
			if (msg.shooter != null)
			{
				this.Shooters = new Dictionary<int, HorseGamblingMapShooterModel>(msg.shooter.Length);
				for (int i = 0; i < msg.shooter.Length; i++)
				{
					EHorseGamblingBattleResult battleState = EHorseGamblingBattleResult.NotBattle;
					if (msg.winShooterId != 0U)
					{
						battleState = ((msg.winShooterId != msg.shooter[i]) ? EHorseGamblingBattleResult.Lose : EHorseGamblingBattleResult.Win);
					}
					HorseGamblingShooterModel shooterModel = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterModel((int)msg.shooter[i]);
					if (shooterModel != null)
					{
						this.Shooters.Add((int)msg.shooter[i], new HorseGamblingMapShooterModel((int)msg.shooter[i], shooterModel.Name, tableItem.MapPhase == 1, battleState));
					}
				}
			}
			else
			{
				this.Shooters = new Dictionary<int, HorseGamblingMapShooterModel>();
			}
		}

		// Token: 0x17001EEF RID: 7919
		// (get) Token: 0x06012382 RID: 74626 RVA: 0x0054E52E File Offset: 0x0054C92E
		// (set) Token: 0x06012383 RID: 74627 RVA: 0x0054E536 File Offset: 0x0054C936
		public int Id { get; private set; }

		// Token: 0x17001EF0 RID: 7920
		// (get) Token: 0x06012384 RID: 74628 RVA: 0x0054E53F File Offset: 0x0054C93F
		// (set) Token: 0x06012385 RID: 74629 RVA: 0x0054E547 File Offset: 0x0054C947
		public string TerrainPath { get; private set; }

		// Token: 0x17001EF1 RID: 7921
		// (get) Token: 0x06012386 RID: 74630 RVA: 0x0054E550 File Offset: 0x0054C950
		// (set) Token: 0x06012387 RID: 74631 RVA: 0x0054E558 File Offset: 0x0054C958
		public Dictionary<int, HorseGamblingMapShooterModel> Shooters { get; private set; }

		// Token: 0x17001EF2 RID: 7922
		// (get) Token: 0x06012388 RID: 74632 RVA: 0x0054E561 File Offset: 0x0054C961
		// (set) Token: 0x06012389 RID: 74633 RVA: 0x0054E569 File Offset: 0x0054C969
		public int Phase { get; private set; }

		// Token: 0x0601238A RID: 74634 RVA: 0x0054E574 File Offset: 0x0054C974
		public void Update(MapInfo msg)
		{
			if (msg.shooter != null)
			{
				for (int i = 0; i < msg.shooter.Length; i++)
				{
					EHorseGamblingBattleResult battleState = EHorseGamblingBattleResult.NotBattle;
					if (msg.winShooterId != 0U)
					{
						battleState = ((msg.winShooterId != msg.shooter[i]) ? EHorseGamblingBattleResult.Lose : EHorseGamblingBattleResult.Win);
					}
					HorseGamblingShooterModel shooterModel = DataManager<HorseGamblingDataManager>.GetInstance().GetShooterModel((int)msg.shooter[i]);
					if (shooterModel != null)
					{
						this.Shooters[(int)msg.shooter[i]] = new HorseGamblingMapShooterModel((int)msg.shooter[i], shooterModel.Name, this.Phase == 1, battleState);
					}
				}
			}
		}
	}
}
