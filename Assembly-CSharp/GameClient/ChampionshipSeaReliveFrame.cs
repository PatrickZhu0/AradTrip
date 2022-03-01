using System;

namespace GameClient
{
	// Token: 0x0200150F RID: 5391
	public class ChampionshipSeaReliveFrame : ClientFrame
	{
		// Token: 0x0600D166 RID: 53606 RVA: 0x0033AA76 File Offset: 0x00338E76
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Main/Relive/ChampionshipSeaReliveFrame";
		}

		// Token: 0x0600D167 RID: 53607 RVA: 0x0033AA7D File Offset: 0x00338E7D
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChampionshipSeaReliveView != null)
			{
				this.mChampionshipSeaReliveView.InitView();
			}
		}

		// Token: 0x0600D168 RID: 53608 RVA: 0x0033AAA1 File Offset: 0x00338EA1
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600D169 RID: 53609 RVA: 0x0033AAA3 File Offset: 0x00338EA3
		protected override void _bindExUI()
		{
			this.mChampionshipSeaReliveView = this.mBind.GetCom<ChampionshipSeaReliveView>("ChampionshipSeaReliveView");
		}

		// Token: 0x0600D16A RID: 53610 RVA: 0x0033AABB File Offset: 0x00338EBB
		protected override void _unbindExUI()
		{
			this.mChampionshipSeaReliveView = null;
		}

		// Token: 0x04007A93 RID: 31379
		private ChampionshipSeaReliveView mChampionshipSeaReliveView;
	}
}
