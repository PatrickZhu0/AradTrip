using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001402 RID: 5122
	public class AdventureTeamInformationFrame : ClientFrame
	{
		// Token: 0x0600C665 RID: 50789 RVA: 0x002FE128 File Offset: 0x002FC528
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length == 1)
				{
					int tabType = int.Parse(array[0]);
					AdventureTeamInformationFrame.OpenTabFrame((AdventureTeamMainTabType)tabType);
				}
				else
				{
					AdventureTeamInformationFrame.OpenTabFrame(AdventureTeamMainTabType.BaseInformation);
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[AdventureTeamInformationFrame] - OpenLinkFrame failed : " + ex.ToString(), new object[0]);
			}
		}

		// Token: 0x0600C666 RID: 50790 RVA: 0x002FE1A0 File Offset: 0x002FC5A0
		public static void OpenTabFrame(AdventureTeamMainTabType tabType)
		{
			if (!DataManager<AdventureTeamDataManager>.GetInstance().BFuncOpened)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("adventure_team_unlock"), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				return;
			}
			AdventureTeamMainFrameData userData = new AdventureTeamMainFrameData
			{
				type = tabType
			};
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamInformationFrame>(null))
			{
				AdventureTeamInformationFrame adventureTeamInformationFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(AdventureTeamInformationFrame)) as AdventureTeamInformationFrame;
				if (adventureTeamInformationFrame != null)
				{
					adventureTeamInformationFrame._TrySelectTab(tabType);
				}
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventureTeamInformationFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600C667 RID: 50791 RVA: 0x002FE226 File Offset: 0x002FC626
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventureTeam/AdventureTeamInformationFrame";
		}

		// Token: 0x0600C668 RID: 50792 RVA: 0x002FE230 File Offset: 0x002FC630
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.userData != null)
			{
				this.frameData = (AdventureTeamMainFrameData)this.userData;
			}
			if (this.frameData == null)
			{
				this.frameData = new AdventureTeamMainFrameData
				{
					type = AdventureTeamMainTabType.BaseInformation
				};
			}
			if (this.mAdventureTeamInformationView != null)
			{
				this.mAdventureTeamInformationView.InitView(this.frameData.type);
			}
		}

		// Token: 0x0600C669 RID: 50793 RVA: 0x002FE2A5 File Offset: 0x002FC6A5
		protected override void _OnCloseFrame()
		{
			this.frameData = null;
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x0600C66A RID: 50794 RVA: 0x002FE2BD File Offset: 0x002FC6BD
		private void _TrySelectTab(AdventureTeamMainTabType tabType)
		{
			if (this.mAdventureTeamInformationView != null)
			{
				this.mAdventureTeamInformationView.SelectViewByTab(tabType);
			}
		}

		// Token: 0x0600C66B RID: 50795 RVA: 0x002FE2DC File Offset: 0x002FC6DC
		protected override void _bindExUI()
		{
			this.mAdventureTeamInformationView = this.mBind.GetCom<AdventureTeamInformationView>("AdventureTeamInformationView");
		}

		// Token: 0x0600C66C RID: 50796 RVA: 0x002FE2F4 File Offset: 0x002FC6F4
		protected override void _unbindExUI()
		{
			this.mAdventureTeamInformationView = null;
		}

		// Token: 0x040071CD RID: 29133
		private AdventureTeamMainFrameData frameData;

		// Token: 0x040071CE RID: 29134
		private AdventureTeamInformationView mAdventureTeamInformationView;
	}
}
