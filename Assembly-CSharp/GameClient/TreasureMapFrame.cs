using System;

namespace GameClient
{
	// Token: 0x020010E9 RID: 4329
	public class TreasureMapFrame : ClientFrame
	{
		// Token: 0x0600A429 RID: 42025 RVA: 0x0021C31F File Offset: 0x0021A71F
		protected override void _bindExUI()
		{
			this.mTreasureDungeonMap = this.mBind.GetCom<TreasureDungeonMap>("DungeonMapScript");
			this.mTreasureMapBuff = this.mBind.GetCom<TreasureMapBuff>("DungeonBuffScript");
		}

		// Token: 0x0600A42A RID: 42026 RVA: 0x0021C34D File Offset: 0x0021A74D
		protected override void _unbindExUI()
		{
			this.mTreasureDungeonMap = null;
			this.mTreasureMapBuff = null;
		}

		// Token: 0x0600A42B RID: 42027 RVA: 0x0021C35D File Offset: 0x0021A75D
		protected sealed override void _OnLoadPrefabFinish()
		{
			if (this.mComClienFrame == null)
			{
				this.mComClienFrame = this.frame.AddComponent<ComClientFrame>();
			}
			this.mComClienFrame.SetGroupTag("system");
		}

		// Token: 0x0600A42C RID: 42028 RVA: 0x0021C38B File Offset: 0x0021A78B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/TreasureMapFrame";
		}

		// Token: 0x170019A6 RID: 6566
		// (get) Token: 0x0600A42D RID: 42029 RVA: 0x0021C392 File Offset: 0x0021A792
		public TreasureDungeonMap TreasureDungeonMap
		{
			get
			{
				return this.mTreasureDungeonMap;
			}
		}

		// Token: 0x170019A7 RID: 6567
		// (get) Token: 0x0600A42E RID: 42030 RVA: 0x0021C39A File Offset: 0x0021A79A
		public TreasureMapBuff TreasureMapBuff
		{
			get
			{
				return this.mTreasureMapBuff;
			}
		}

		// Token: 0x04005BCD RID: 23501
		private TreasureDungeonMap mTreasureDungeonMap;

		// Token: 0x04005BCE RID: 23502
		private TreasureMapBuff mTreasureMapBuff;
	}
}
