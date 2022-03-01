using System;

namespace GameClient
{
	// Token: 0x02001CF2 RID: 7410
	public class HorseGamblingMapShooterModel : IHorseGamblingMapShooterModel
	{
		// Token: 0x06012359 RID: 74585 RVA: 0x0054E189 File Offset: 0x0054C589
		public HorseGamblingMapShooterModel(int id, string name, bool isShowOdds, EHorseGamblingBattleResult battleState)
		{
			this.Id = id;
			this.IsShowOdds = isShowOdds;
			this.BattleState = battleState;
			this.Name = name;
		}

		// Token: 0x17001EDD RID: 7901
		// (get) Token: 0x0601235A RID: 74586 RVA: 0x0054E1AE File Offset: 0x0054C5AE
		// (set) Token: 0x0601235B RID: 74587 RVA: 0x0054E1B6 File Offset: 0x0054C5B6
		public int Id { get; private set; }

		// Token: 0x17001EDE RID: 7902
		// (get) Token: 0x0601235C RID: 74588 RVA: 0x0054E1BF File Offset: 0x0054C5BF
		// (set) Token: 0x0601235D RID: 74589 RVA: 0x0054E1C7 File Offset: 0x0054C5C7
		public string Name { get; private set; }

		// Token: 0x17001EDF RID: 7903
		// (get) Token: 0x0601235E RID: 74590 RVA: 0x0054E1D0 File Offset: 0x0054C5D0
		// (set) Token: 0x0601235F RID: 74591 RVA: 0x0054E1D8 File Offset: 0x0054C5D8
		public bool IsShowOdds { get; private set; }

		// Token: 0x17001EE0 RID: 7904
		// (get) Token: 0x06012360 RID: 74592 RVA: 0x0054E1E1 File Offset: 0x0054C5E1
		// (set) Token: 0x06012361 RID: 74593 RVA: 0x0054E1E9 File Offset: 0x0054C5E9
		public EHorseGamblingBattleResult BattleState { get; private set; }
	}
}
