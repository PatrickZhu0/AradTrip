using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001614 RID: 5652
	public class GuildDungeonBossKillRankListFrame : ClientFrame
	{
		// Token: 0x0600DD8C RID: 56716 RVA: 0x00382B5B File Offset: 0x00380F5B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonBossKillRankList";
		}

		// Token: 0x0600DD8D RID: 56717 RVA: 0x00382B62 File Offset: 0x00380F62
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this._UpdateRankList();
		}

		// Token: 0x0600DD8E RID: 56718 RVA: 0x00382B70 File Offset: 0x00380F70
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600DD8F RID: 56719 RVA: 0x00382B78 File Offset: 0x00380F78
		protected override void _bindExUI()
		{
			this.itemTemplate = this.mBind.GetGameObject("itemTemplate");
			this.itemListParent = this.mBind.GetGameObject("itemListParent");
			this.zeroTips = this.mBind.GetGameObject("zeroTips");
			this.hide = this.mBind.GetCom<Button>("hide");
			this.hide.SafeAddOnClickListener(delegate
			{
				if (this.hideAnimation != null)
				{
					this.hideAnimation.isActive = true;
					if (this.hideAnimation.tween == null)
					{
						this.hideAnimation.CreateTween();
					}
					this.hideAnimation.DORestart(false);
				}
			});
			this.show = this.mBind.GetCom<Button>("show");
			this.show.SafeAddOnClickListener(delegate
			{
				if (this.showAnimation != null)
				{
					this.showAnimation.isActive = true;
					if (this.showAnimation.tween == null)
					{
						this.showAnimation.CreateTween();
					}
					this.showAnimation.DORestart(false);
				}
			});
			this.root = this.mBind.GetGameObject("root");
			if (this.root != null)
			{
				DOTweenAnimation[] components = this.root.GetComponents<DOTweenAnimation>();
				if (components != null)
				{
					for (int i = 0; i < components.Length; i++)
					{
						if (components[i].id == "hide")
						{
							this.hideAnimation = components[i];
						}
						else if (components[i].id == "show")
						{
							this.showAnimation = components[i];
						}
					}
				}
			}
			this.rootAnimation = this.mBind.GetCom<DOTweenAnimation>("rootAnimation");
			this.help = this.mBind.GetCom<Button>("help");
			this.help.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonAuctionAwardShowFrame>(FrameLayer.Middle, null, string.Empty);
			});
		}

		// Token: 0x0600DD90 RID: 56720 RVA: 0x00382D07 File Offset: 0x00381107
		protected override void _unbindExUI()
		{
			this.itemTemplate = null;
			this.itemListParent = null;
			this.zeroTips = null;
			this.hide = null;
			this.show = null;
			this.root = null;
			this.rootAnimation = null;
			this.help = null;
		}

		// Token: 0x0600DD91 RID: 56721 RVA: 0x00382D41 File Offset: 0x00381141
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
		}

		// Token: 0x0600DD92 RID: 56722 RVA: 0x00382D5E File Offset: 0x0038115E
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
		}

		// Token: 0x0600DD93 RID: 56723 RVA: 0x00382D7C File Offset: 0x0038117C
		private void _UpdateRankList()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData == null)
			{
				return;
			}
			if (this.itemListParent != null && this.itemTemplate != null)
			{
				for (int i = 0; i < this.itemListParent.transform.childCount; i++)
				{
					GameObject gameObject = this.itemListParent.transform.GetChild(i).gameObject;
					Object.Destroy(gameObject);
				}
				int num = 0;
				int num2 = 0;
				while (num2 < guildDungeonActivityData.guildDungeonClearGateInfos.Count && num2 < 5)
				{
					GuildDataManager.GuildDungeonClearGateInfo guildDungeonClearGateInfo = guildDungeonActivityData.guildDungeonClearGateInfos[num2];
					if (guildDungeonClearGateInfo != null)
					{
						GameObject gameObject2 = Object.Instantiate<GameObject>(this.itemTemplate.gameObject);
						Utility.AttachTo(gameObject2, this.itemListParent, false);
						gameObject2.CustomActive(true);
						ComCommonBind component = gameObject2.GetComponent<ComCommonBind>();
						if (component != null)
						{
							StaticUtility.SafeSetText(component, "guild", guildDungeonClearGateInfo.guildName);
							StaticUtility.SafeSetText(component, "timeUse", Function.GetLastsTimeStr(guildDungeonClearGateInfo.spendTime));
							if (num <= 2)
							{
								StaticUtility.SafeSetVisible<Image>(component, "rankImage", true);
								StaticUtility.SafeSetVisible<Text>(component, "rank", false);
								StaticUtility.SafeSetImage(component, "rankImage", string.Format("UI/Image/Packed/p_UI_Gonghuifuben.png:UI_Gonghuifuben_Paiming_0{0}", num + 1));
							}
							else
							{
								StaticUtility.SafeSetVisible<Image>(component, "rankImage", false);
								StaticUtility.SafeSetVisible<Text>(component, "rank", true);
								StaticUtility.SafeSetText(component, "rank", (num2 + 1).ToString());
							}
							StaticUtility.SafeSetVisible<Image>(component, "bg", num % 2 != 0);
							StaticUtility.SafeSetVisible<Image>(component, "bg2", num % 2 == 0);
							num++;
						}
					}
					num2++;
				}
				for (int j = Math.Min(5, guildDungeonActivityData.guildDungeonClearGateInfos.Count); j < 5; j++)
				{
					GameObject gameObject3 = Object.Instantiate<GameObject>(this.itemTemplate.gameObject);
					Utility.AttachTo(gameObject3, this.itemListParent, false);
					gameObject3.CustomActive(true);
					ComCommonBind component2 = gameObject3.GetComponent<ComCommonBind>();
					if (component2 != null)
					{
						StaticUtility.SafeSetText(component2, "guild", "暂无");
						StaticUtility.SafeSetText(component2, "timeUse", "暂无");
						if (num <= 2)
						{
							StaticUtility.SafeSetVisible<Image>(component2, "rankImage", true);
							StaticUtility.SafeSetVisible<Text>(component2, "rank", false);
							StaticUtility.SafeSetImage(component2, "rankImage", string.Format("UI/Image/Packed/p_UI_Gonghuifuben.png:UI_Gonghuifuben_Paiming_0{0}", num + 1));
						}
						else
						{
							StaticUtility.SafeSetVisible<Image>(component2, "rankImage", false);
							StaticUtility.SafeSetVisible<Text>(component2, "rank", true);
							StaticUtility.SafeSetText(component2, "rank", (j + 1).ToString());
						}
						StaticUtility.SafeSetVisible<Image>(component2, "bg", num % 2 != 0);
						StaticUtility.SafeSetVisible<Image>(component2, "bg2", num % 2 == 0);
						num++;
					}
				}
			}
		}

		// Token: 0x0600DD94 RID: 56724 RVA: 0x00383081 File Offset: 0x00381481
		private void _OnUpdateActivityData(UIEvent uiEvent)
		{
			this._UpdateRankList();
		}

		// Token: 0x0400831C RID: 33564
		private DOTweenAnimation hideAnimation;

		// Token: 0x0400831D RID: 33565
		private DOTweenAnimation showAnimation;

		// Token: 0x0400831E RID: 33566
		private const int maxRankItemNum = 5;

		// Token: 0x0400831F RID: 33567
		private const string rankImagePath = "UI/Image/Packed/p_UI_Gonghuifuben.png:UI_Gonghuifuben_Paiming_0{0}";

		// Token: 0x04008320 RID: 33568
		private GameObject itemTemplate;

		// Token: 0x04008321 RID: 33569
		private GameObject itemListParent;

		// Token: 0x04008322 RID: 33570
		private GameObject zeroTips;

		// Token: 0x04008323 RID: 33571
		private Button hide;

		// Token: 0x04008324 RID: 33572
		private Button show;

		// Token: 0x04008325 RID: 33573
		private new GameObject root;

		// Token: 0x04008326 RID: 33574
		private DOTweenAnimation rootAnimation;

		// Token: 0x04008327 RID: 33575
		private Button help;
	}
}
