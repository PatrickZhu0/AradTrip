using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200161B RID: 5659
	public class GuildDungeonHowToPlayFrame : ClientFrame
	{
		// Token: 0x0600DE17 RID: 56855 RVA: 0x00386CF8 File Offset: 0x003850F8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonHowToPlay";
		}

		// Token: 0x0600DE18 RID: 56856 RVA: 0x00386CFF File Offset: 0x003850FF
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			if (this.userData != null)
			{
				this.UpdateContent((uint)((ulong)this.userData));
			}
		}

		// Token: 0x0600DE19 RID: 56857 RVA: 0x00386D24 File Offset: 0x00385124
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600DE1A RID: 56858 RVA: 0x00386D2C File Offset: 0x0038512C
		protected override void _bindExUI()
		{
			this.btnClose = this.mBind.GetCom<Button>("btnClose");
			this.btnClose.SafeAddOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<GuildDungeonHowToPlayFrame>(this, false);
			});
			this.playing = this.mBind.GetCom<Text>("playing");
			this.playingDesc = this.mBind.GetCom<Text>("playingDesc");
			this.weaknesses = this.mBind.GetCom<Text>("weaknesses");
			this.weaknessesDesc = this.mBind.GetCom<Text>("weaknessesDesc");
			this.recommend = this.mBind.GetCom<Text>("recommend");
			this.recommendDesc = this.mBind.GetCom<Text>("recommendDesc");
		}

		// Token: 0x0600DE1B RID: 56859 RVA: 0x00386DEA File Offset: 0x003851EA
		protected override void _unbindExUI()
		{
			this.btnClose = null;
			this.playing = null;
			this.playingDesc = null;
			this.weaknesses = null;
			this.weaknessesDesc = null;
			this.recommend = null;
			this.recommendDesc = null;
		}

		// Token: 0x0600DE1C RID: 56860 RVA: 0x00386E1D File Offset: 0x0038521D
		private void BindUIEvent()
		{
		}

		// Token: 0x0600DE1D RID: 56861 RVA: 0x00386E1F File Offset: 0x0038521F
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600DE1E RID: 56862 RVA: 0x00386E24 File Offset: 0x00385224
		private void UpdateContent(uint iGuildDungeonID)
		{
			this.playing.SafeSetText(TR.Value("guild_dungeon_playing", DataManager<GuildDataManager>.GetInstance().GetGuildDungeonName(iGuildDungeonID)));
			this.playingDesc.SafeSetText(DataManager<GuildDataManager>.GetInstance().GetGuildDungeonPlayingDesc(iGuildDungeonID));
			this.weaknesses.SafeSetText(TR.Value("guild_dungeon_weakness", DataManager<GuildDataManager>.GetInstance().GetGuildDungeonName(iGuildDungeonID)));
			this.weaknessesDesc.SafeSetText(DataManager<GuildDataManager>.GetInstance().GetGuildDungeonWeaknessDesc(iGuildDungeonID));
			this.recommend.SafeSetText(TR.Value("guild_dungeon_recommend_job"));
			this.recommendDesc.SafeSetText(DataManager<GuildDataManager>.GetInstance().GetGuildDungeonRecommendDesc(iGuildDungeonID));
		}

		// Token: 0x04008385 RID: 33669
		private Button btnClose;

		// Token: 0x04008386 RID: 33670
		private Text playing;

		// Token: 0x04008387 RID: 33671
		private Text playingDesc;

		// Token: 0x04008388 RID: 33672
		private Text weaknesses;

		// Token: 0x04008389 RID: 33673
		private Text weaknessesDesc;

		// Token: 0x0400838A RID: 33674
		private Text recommend;

		// Token: 0x0400838B RID: 33675
		private Text recommendDesc;
	}
}
