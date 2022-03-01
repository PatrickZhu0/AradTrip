using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001639 RID: 5689
	internal class GuildMyMainFrame : ClientFrame
	{
		// Token: 0x0600DF9C RID: 57244 RVA: 0x0039168C File Offset: 0x0038FA8C
		public static void OpenLinkFrame(string a_strParam)
		{
			try
			{
				string[] array = a_strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length > 0)
				{
					if (!GuildMyMainFrame.ms_bFuncsInited)
					{
						GuildMyMainFrame.ms_arrOperateFuncs[0] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[1] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenMemberFrame, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[2] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenBuildingFrame, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[7] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenShopFrame, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[9] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenStorageFrame, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[8] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenManorFrame, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[10] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenCrossManorFrame, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[11] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenRedPacketFrame, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[12] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnOpenGuildEmblemLevelPage, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[13] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnOpenGuildBenefitsPage, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_arrOperateFuncs[14] = delegate(object[] a_arrParams)
						{
							if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnOpenGuildActivityPage, null, null, null, null);
							}
							else
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						};
						GuildMyMainFrame.ms_bFuncsInited = true;
					}
					int num = int.Parse(array[0]);
					if (num >= 0 && num < GuildMyMainFrame.ms_arrOperateFuncs.Length)
					{
						GuildMyMainFrame.OperateFunc operateFunc = GuildMyMainFrame.ms_arrOperateFuncs[num];
						if (operateFunc != null)
						{
							operateFunc(array);
						}
						else
						{
							Logger.LogErrorFormat("跳转到公会，参数错误， 类型：{0}", new object[]
							{
								num
							});
						}
					}
					else
					{
						Logger.LogErrorFormat("跳转到公会，参数错误， 类型：{0}", new object[]
						{
							num
						});
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("PackageFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x0600DF9D RID: 57245 RVA: 0x00391900 File Offset: 0x0038FD00
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildMyMain";
		}

		// Token: 0x0600DF9E RID: 57246 RVA: 0x00391907 File Offset: 0x0038FD07
		protected sealed override void _OnOpenFrame()
		{
			this._InitTabs();
			this._RegisterUIEvent();
			this._UpdateCrossGuildBattleTab();
			this.openShopFrameTime = 0f;
		}

		// Token: 0x0600DF9F RID: 57247 RVA: 0x00391926 File Offset: 0x0038FD26
		protected sealed override void _OnCloseFrame()
		{
			this.m_bToggleBlockSignal = false;
			this._UnRegisterUIEvent();
			this._CloseAll();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildMainFrameClose, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildMain);
			this.openShopFrameTime = 0f;
		}

		// Token: 0x0600DFA0 RID: 57248 RVA: 0x00391968 File Offset: 0x0038FD68
		protected override void _bindExUI()
		{
			this.Emblem = this.mBind.GetCom<Toggle>("Emblem");
			this.Emblem.SafeAddOnValueChangedListener(delegate(bool bValue)
			{
				if (bValue)
				{
					this.frameMgr.OpenFrame<GuildEmblemUpFrame>(this.m_objContentRoot, null, string.Empty);
					this.EmblemRedPoint.CustomActive(false);
				}
				else
				{
					this.frameMgr.CloseFrame<GuildEmblemUpFrame>(null, false);
				}
			});
			this.EmblemRedPoint = this.mBind.GetCom<Image>("EmblemRedPoint");
			this.Benefits = this.mBind.GetCom<Toggle>("Benefits");
			this.Benefits.SafeSetOnValueChangedListener(delegate(bool bValue)
			{
				if (bValue)
				{
					this.frameMgr.OpenFrame<GuildBenefitsFrame>(this.m_objContentRoot, null, string.Empty);
				}
				else
				{
					this.frameMgr.CloseFrame<GuildBenefitsFrame>(null, false);
				}
			});
			this.Activity = this.mBind.GetCom<Toggle>("Activity");
			this.Activity.SafeSetOnValueChangedListener(delegate(bool bValue)
			{
				if (bValue)
				{
					this.frameMgr.OpenFrame<GuildActivityFrame>(this.m_objContentRoot, null, string.Empty);
				}
				else
				{
					this.frameMgr.CloseFrame<GuildActivityFrame>(null, false);
				}
			});
			this.activityRedPoint = this.mBind.GetGameObject("activityRedPoint");
		}

		// Token: 0x0600DFA1 RID: 57249 RVA: 0x00391A28 File Offset: 0x0038FE28
		protected override void _unbindExUI()
		{
			this.Emblem = null;
			this.EmblemRedPoint = null;
			this.Benefits = null;
			this.Activity = null;
			this.activityRedPoint = null;
		}

		// Token: 0x0600DFA2 RID: 57250 RVA: 0x00391A50 File Offset: 0x0038FE50
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildCloseMainFrame, new ClientEventSystem.UIEventHandler(this._OnCloseMainFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenMemberFrame, new ClientEventSystem.UIEventHandler(this._OnOpenMemberFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenBuildingFrame, new ClientEventSystem.UIEventHandler(this._OnOpenBuildingFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenShopFrame, new ClientEventSystem.UIEventHandler(this._OnOpenShopFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenManorFrame, new ClientEventSystem.UIEventHandler(this._OnOpenManorFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnOpenGuildHouseMain, new ClientEventSystem.UIEventHandler(this._OnOpenGuildHouseMain));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenStorageFrame, new ClientEventSystem.UIEventHandler(this._OnGuildOpenStorageFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenCrossManorFrame, new ClientEventSystem.UIEventHandler(this._OnOpenCrossManorFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildEmblemLevelUp, new ClientEventSystem.UIEventHandler(this._OnGuildEmblemLevelUp));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnOpenGuildEmblemLevelPage, new ClientEventSystem.UIEventHandler(this._OnOpenGuildEmblemLevelPage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenShopRefreshConsumeItem, new ClientEventSystem.UIEventHandler(this._OnGuildOpenShopRefreshConsumeItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnOpenGuildBenefitsPage, new ClientEventSystem.UIEventHandler(this._OnOpenGuildBenefitsPage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnOpenGuildActivityPage, new ClientEventSystem.UIEventHandler(this._OnOpenGuildActivityPage));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_GUILD_CROSS_BATTLE, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnCrossBattleStateSwitch));
		}

		// Token: 0x0600DFA3 RID: 57251 RVA: 0x00391C20 File Offset: 0x00390020
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildCloseMainFrame, new ClientEventSystem.UIEventHandler(this._OnCloseMainFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenMemberFrame, new ClientEventSystem.UIEventHandler(this._OnOpenMemberFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenBuildingFrame, new ClientEventSystem.UIEventHandler(this._OnOpenBuildingFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenShopFrame, new ClientEventSystem.UIEventHandler(this._OnOpenShopFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenManorFrame, new ClientEventSystem.UIEventHandler(this._OnOpenManorFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnOpenGuildHouseMain, new ClientEventSystem.UIEventHandler(this._OnOpenGuildHouseMain));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenStorageFrame, new ClientEventSystem.UIEventHandler(this._OnGuildOpenStorageFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenCrossManorFrame, new ClientEventSystem.UIEventHandler(this._OnOpenCrossManorFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildEmblemLevelUp, new ClientEventSystem.UIEventHandler(this._OnGuildEmblemLevelUp));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnOpenGuildEmblemLevelPage, new ClientEventSystem.UIEventHandler(this._OnOpenGuildEmblemLevelPage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenShopRefreshConsumeItem, new ClientEventSystem.UIEventHandler(this._OnGuildOpenShopRefreshConsumeItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnOpenGuildBenefitsPage, new ClientEventSystem.UIEventHandler(this._OnOpenGuildBenefitsPage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnOpenGuildActivityPage, new ClientEventSystem.UIEventHandler(this._OnOpenGuildActivityPage));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_GUILD_CROSS_BATTLE, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnCrossBattleStateSwitch));
		}

		// Token: 0x0600DFA4 RID: 57252 RVA: 0x00391DD8 File Offset: 0x003901D8
		private void _InitTabs()
		{
			this.m_toggleBase.onValueChanged.RemoveAllListeners();
			this.m_toggleBase.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				if (!this.m_bToggleBlockSignal)
				{
					if (a_bChecked)
					{
						this.m_baseFrame = this.frameMgr.OpenFrame<GuildMyBaseFrame>(this.m_objContentRoot, null, string.Empty);
					}
					else
					{
						this._CloseBasePage();
					}
				}
			});
			this.m_toggleMember.onValueChanged.RemoveAllListeners();
			this.m_toggleMember.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				if (!this.m_bToggleBlockSignal)
				{
					if (a_bChecked)
					{
						this.m_memberFrame = this.frameMgr.OpenFrame<GuildMyMemberFrame>(this.m_objContentRoot, null, string.Empty);
					}
					else
					{
						this._CloseMemberPage();
					}
				}
			});
			this.m_toggleBuilding.onValueChanged.RemoveAllListeners();
			this.m_toggleBuilding.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				if (!this.m_bToggleBlockSignal)
				{
					if (a_bChecked)
					{
						if (this.m_buildingFrame != null)
						{
							this.frameMgr.CloseFrame<IClientFrame>(this.m_buildingFrame, false);
						}
						this.m_buildingFrame = this.frameMgr.OpenFrame<GuildBuildingFrame>(this.m_objContentRoot, this.m_buildingParam, string.Empty);
						this.m_objBuildingRedPoint.CustomActive(false);
					}
					else
					{
						this._CloseBuildingPage();
					}
				}
			});
			this.m_toggleManor.onValueChanged.RemoveAllListeners();
			this.m_toggleManor.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				if (!this.m_bToggleBlockSignal)
				{
					if (a_bChecked)
					{
						this.frameMgr.OpenFrame<GuildManorFrame>(FrameLayer.Middle, null, string.Empty);
						DataManager<NewMessageNoticeManager>.GetInstance().RemoveNewMessageNoticeByTag("GuildBattle");
					}
					else
					{
						this._CloseManorPage();
					}
				}
			});
			this.m_toggleShop.onValueChanged.RemoveAllListeners();
			this.m_toggleShop.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				if (!this.m_bToggleBlockSignal)
				{
					if (a_bChecked)
					{
						if (this.openShopFrameTime > 0f && Time.realtimeSinceStartup - this.openShopFrameTime <= 1f)
						{
							return;
						}
						this.openShopFrameTime = Time.realtimeSinceStartup;
						if (this.m_shopFrame != null)
						{
							this.frameMgr.CloseFrame<IClientFrame>(this.m_shopFrame, false);
						}
						this.m_shopFrame = this.frameMgr.OpenFrame<GuildShopFrame>(this.m_objContentRoot, null, string.Empty);
					}
					else
					{
						this._CloseShopPage();
					}
				}
			});
			this.m_toggleStorage.onValueChanged.RemoveAllListeners();
			this.m_toggleStorage.onValueChanged.AddListener(new UnityAction<bool>(this._OnStorageToggleChanged));
			this.m_toggleCrossManor.onValueChanged.RemoveAllListeners();
			this.m_toggleCrossManor.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				if (!this.m_bToggleBlockSignal)
				{
					if (a_bChecked)
					{
						this.frameMgr.OpenFrame<GuildCrossManorFrame>(FrameLayer.Middle, null, string.Empty);
					}
					else
					{
						this._CloseCrossManorPage();
					}
				}
			});
			this.m_bToggleBlockSignal = true;
			this.m_toggleBase.isOn = false;
			this.m_toggleMember.isOn = true;
			this.m_toggleBuilding.isOn = true;
			this.m_toggleManor.isOn = true;
			this.m_toggleStorage.isOn = true;
			this.m_toggleShop.isOn = true;
			this.m_toggleCrossManor.isOn = true;
			this.m_bToggleBlockSignal = false;
			this.m_toggleBase.isOn = true;
			this._UpdateRedPoint();
		}

		// Token: 0x0600DFA5 RID: 57253 RVA: 0x00391F8D File Offset: 0x0039038D
		private void _OnStorageToggleChanged(bool a_bChecked)
		{
			if (!this.m_bToggleBlockSignal)
			{
				if (a_bChecked)
				{
					GuildStoreFrame.ansyOpen(null);
				}
				else
				{
					this._CloseStoragePage();
				}
			}
		}

		// Token: 0x0600DFA6 RID: 57254 RVA: 0x00391FB1 File Offset: 0x003903B1
		private void _OpenBasePage()
		{
			if (!this.m_toggleBase.isOn)
			{
				this.m_toggleBase.isOn = true;
			}
		}

		// Token: 0x0600DFA7 RID: 57255 RVA: 0x00391FCF File Offset: 0x003903CF
		private void _OpenMemberPage()
		{
			if (!this.m_toggleMember.isOn)
			{
				this.m_toggleMember.isOn = true;
			}
		}

		// Token: 0x0600DFA8 RID: 57256 RVA: 0x00391FED File Offset: 0x003903ED
		private void _OpenBuildingPage(object a_param)
		{
			this.m_buildingParam = a_param;
			if (!this.m_toggleBuilding.isOn)
			{
				this.m_toggleBuilding.isOn = true;
			}
			else
			{
				this.m_toggleBuilding.onValueChanged.Invoke(true);
			}
		}

		// Token: 0x0600DFA9 RID: 57257 RVA: 0x00392028 File Offset: 0x00390428
		private void _OpenShopPage()
		{
			if (!this.m_toggleShop.isOn)
			{
				this.m_toggleShop.isOn = true;
			}
		}

		// Token: 0x0600DFAA RID: 57258 RVA: 0x00392046 File Offset: 0x00390446
		private void _OpenManorPage()
		{
			if (!this.Activity.isOn)
			{
				this.Activity.isOn = true;
			}
		}

		// Token: 0x0600DFAB RID: 57259 RVA: 0x00392064 File Offset: 0x00390464
		private void _OpenCrossManorPage()
		{
			if (!this.Activity.isOn)
			{
				this.Activity.isOn = true;
			}
		}

		// Token: 0x0600DFAC RID: 57260 RVA: 0x00392082 File Offset: 0x00390482
		private void _OpenGuildEmblemLevelPage()
		{
			if (this.Emblem != null && !this.Emblem.isOn)
			{
				this.Emblem.isOn = true;
			}
		}

		// Token: 0x0600DFAD RID: 57261 RVA: 0x003920B1 File Offset: 0x003904B1
		private void _OpenGuildBenefitsPage()
		{
			if (this.Benefits != null && !this.Benefits.isOn)
			{
				this.Benefits.isOn = true;
			}
		}

		// Token: 0x0600DFAE RID: 57262 RVA: 0x003920E0 File Offset: 0x003904E0
		private void _OpenGuildActivityPage()
		{
			if (this.Activity != null && !this.Activity.isOn)
			{
				this.Activity.isOn = true;
			}
		}

		// Token: 0x0600DFAF RID: 57263 RVA: 0x0039210F File Offset: 0x0039050F
		private void _OpenGuildRedPacketPage()
		{
			if (!this.m_toggleRedPacket.isOn)
			{
				this.m_toggleRedPacket.isOn = true;
			}
		}

		// Token: 0x0600DFB0 RID: 57264 RVA: 0x0039212D File Offset: 0x0039052D
		private void _CloseBasePage()
		{
			if (this.m_baseFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_baseFrame, false);
				this.m_baseFrame = null;
			}
		}

		// Token: 0x0600DFB1 RID: 57265 RVA: 0x00392153 File Offset: 0x00390553
		private void _CloseMemberPage()
		{
			if (this.m_memberFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_memberFrame, false);
				this.m_memberFrame = null;
			}
		}

		// Token: 0x0600DFB2 RID: 57266 RVA: 0x00392179 File Offset: 0x00390579
		private void _CloseBuildingPage()
		{
			if (this.m_buildingFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_buildingFrame, false);
				this.m_buildingFrame = null;
				this.m_buildingParam = null;
			}
		}

		// Token: 0x0600DFB3 RID: 57267 RVA: 0x003921A6 File Offset: 0x003905A6
		private void _CloseManorPage()
		{
			if (this.m_manorFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_manorFrame, false);
				this.m_manorFrame = null;
			}
		}

		// Token: 0x0600DFB4 RID: 57268 RVA: 0x003921CC File Offset: 0x003905CC
		private void _CloseShopPage()
		{
			if (this.m_shopFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_shopFrame, false);
				this.m_shopFrame = null;
				if (this.m_comConsumeItemGroup != null)
				{
					this.m_comConsumeItemGroup.ResetOriginalItemIdsWithShow(true, ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue);
				}
			}
		}

		// Token: 0x0600DFB5 RID: 57269 RVA: 0x0039221C File Offset: 0x0039061C
		private void _CloseStoragePage()
		{
			if (this.m_storageFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_storageFrame, false);
				this.m_storageFrame = null;
			}
		}

		// Token: 0x0600DFB6 RID: 57270 RVA: 0x00392242 File Offset: 0x00390642
		private void _CloseCrossManorPage()
		{
			if (this.m_crossManorFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_crossManorFrame, false);
				this.m_crossManorFrame = null;
			}
		}

		// Token: 0x0600DFB7 RID: 57271 RVA: 0x00392268 File Offset: 0x00390668
		private void _CloseAll()
		{
			this._CloseBasePage();
			this._CloseMemberPage();
			this._CloseBuildingPage();
			this._CloseManorPage();
			this._CloseShopPage();
			this._CloseStoragePage();
			this._CloseCrossManorPage();
			this.frameMgr.CloseFrame<GuildEmblemUpFrame>(null, false);
			this.frameMgr.CloseFrame<GuildBenefitsFrame>(null, false);
			this.frameMgr.CloseFrame<GuildActivityFrame>(null, false);
			this.frameMgr.CloseFrame<GuildCrossManorFrame>(null, false);
			this.frameMgr.CloseFrame<GuildManorFrame>(null, false);
			this.frameMgr.CloseFrame<GuildMyMainFrame>(this, false);
		}

		// Token: 0x0600DFB8 RID: 57272 RVA: 0x003922ED File Offset: 0x003906ED
		private void _OnCloseMainFrame(UIEvent a_event)
		{
			this._CloseAll();
		}

		// Token: 0x0600DFB9 RID: 57273 RVA: 0x003922F5 File Offset: 0x003906F5
		private void _OnOpenMemberFrame(UIEvent a_event)
		{
			this._OpenMemberPage();
		}

		// Token: 0x0600DFBA RID: 57274 RVA: 0x003922FD File Offset: 0x003906FD
		private void _OnOpenBuildingFrame(UIEvent a_event)
		{
			this._OpenBuildingPage(a_event.Param1);
		}

		// Token: 0x0600DFBB RID: 57275 RVA: 0x0039230B File Offset: 0x0039070B
		private void _OnOpenShopFrame(UIEvent a_event)
		{
			this._OpenShopPage();
		}

		// Token: 0x0600DFBC RID: 57276 RVA: 0x00392313 File Offset: 0x00390713
		private void _OnOpenManorFrame(UIEvent a_event)
		{
			this._OpenManorPage();
		}

		// Token: 0x0600DFBD RID: 57277 RVA: 0x0039231B File Offset: 0x0039071B
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildMyMainFrame>(this, false);
		}

		// Token: 0x0600DFBE RID: 57278 RVA: 0x0039232C File Offset: 0x0039072C
		private void _UpdateRedPoint()
		{
			this.m_objBaseRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildBase));
			this.m_objBuildingRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildBuilding));
			this.m_objMemberRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildMember));
			this.m_objManorRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildManor));
			this.m_objShopRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildShop));
			this.m_objCrossManorRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildCrossManor));
			this.activityRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildManor) || DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildCrossManor) || DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildTerrDayReward));
		}

		// Token: 0x0600DFBF RID: 57279 RVA: 0x003923FE File Offset: 0x003907FE
		private void _OnRedPointChanged(UIEvent a_event)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0600DFC0 RID: 57280 RVA: 0x00392406 File Offset: 0x00390806
		private void _OnGuildOpenStorageFrame(UIEvent a_event)
		{
			if (!this.m_toggleStorage.isOn)
			{
				this.m_toggleStorage.isOn = true;
			}
		}

		// Token: 0x0600DFC1 RID: 57281 RVA: 0x00392424 File Offset: 0x00390824
		private void _OnOpenGuildHouseMain(UIEvent a_event)
		{
			if (this.m_storageFrame != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_storageFrame, false);
				this.m_storageFrame = null;
			}
			this.m_storageFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStoreFrame>(this.m_objContentRoot, a_event.Param1, string.Empty);
		}

		// Token: 0x0600DFC2 RID: 57282 RVA: 0x00392476 File Offset: 0x00390876
		private void _OnOpenCrossManorFrame(UIEvent a_event)
		{
			this._OpenCrossManorPage();
		}

		// Token: 0x0600DFC3 RID: 57283 RVA: 0x0039247E File Offset: 0x0039087E
		private void _OnGuildEmblemLevelUp(UIEvent a_event)
		{
		}

		// Token: 0x0600DFC4 RID: 57284 RVA: 0x00392480 File Offset: 0x00390880
		private void _OnOpenGuildEmblemLevelPage(UIEvent a_event)
		{
			this._OpenGuildEmblemLevelPage();
		}

		// Token: 0x0600DFC5 RID: 57285 RVA: 0x00392488 File Offset: 0x00390888
		private void _OnOpenGuildBenefitsPage(UIEvent a_event)
		{
			this._OpenGuildBenefitsPage();
		}

		// Token: 0x0600DFC6 RID: 57286 RVA: 0x00392490 File Offset: 0x00390890
		private void _OnOpenGuildActivityPage(UIEvent a_event)
		{
			this._OpenGuildActivityPage();
		}

		// Token: 0x0600DFC7 RID: 57287 RVA: 0x00392498 File Offset: 0x00390898
		private void _OnCrossBattleStateSwitch(ServerSceneFuncSwitch fSwitch)
		{
			if (fSwitch.sType != ServiceType.SERVICE_GUILD_CROSS_BATTLE)
			{
				return;
			}
			this._UpdateCrossGuildBattleTab();
		}

		// Token: 0x0600DFC8 RID: 57288 RVA: 0x003924B0 File Offset: 0x003908B0
		private void _OnGuildOpenShopRefreshConsumeItem(UIEvent a_event)
		{
			if (a_event == null)
			{
				return;
			}
			List<int> list = a_event.Param1 as List<int>;
			if (list == null || list.Count <= 0)
			{
				return;
			}
			if (this.m_comConsumeItemGroup == null)
			{
				return;
			}
			this.m_comConsumeItemGroup.ResetSelectedItemIds(list.ToArray(), false, true, ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue);
		}

		// Token: 0x0600DFC9 RID: 57289 RVA: 0x0039250A File Offset: 0x0039090A
		[UIEventHandle("RedEnvelope")]
		private void _OnRedPacketClicked()
		{
		}

		// Token: 0x0600DFCA RID: 57290 RVA: 0x0039250C File Offset: 0x0039090C
		[UIEventHandle("BG/Title/Close")]
		private void _OnCloseCliecked()
		{
			this._CloseAll();
		}

		// Token: 0x0600DFCB RID: 57291 RVA: 0x00392514 File Offset: 0x00390914
		private void _UpdateCrossGuildBattleTab()
		{
		}

		// Token: 0x040084CF RID: 33999
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/Base", typeof(Toggle), 0)]
		private Toggle m_toggleBase;

		// Token: 0x040084D0 RID: 34000
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/Member", typeof(Toggle), 0)]
		private Toggle m_toggleMember;

		// Token: 0x040084D1 RID: 34001
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/Building", typeof(Toggle), 0)]
		private Toggle m_toggleBuilding;

		// Token: 0x040084D2 RID: 34002
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/Manor", typeof(Toggle), 0)]
		private Toggle m_toggleManor;

		// Token: 0x040084D3 RID: 34003
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/Storage", typeof(Toggle), 0)]
		private Toggle m_toggleStorage;

		// Token: 0x040084D4 RID: 34004
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/Shop", null, 0)]
		private Toggle m_toggleShop;

		// Token: 0x040084D5 RID: 34005
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/CrossManor", typeof(Toggle), 0)]
		private Toggle m_toggleCrossManor;

		// Token: 0x040084D6 RID: 34006
		[UIControl("TabGroup/ScrollRect/Viewport/Tabs/RedPacket", typeof(Toggle), 0)]
		private Toggle m_toggleRedPacket;

		// Token: 0x040084D7 RID: 34007
		[UIObject("TabGroup/ScrollRect/Viewport/Tabs/Base/RedPoint")]
		private GameObject m_objBaseRedPoint;

		// Token: 0x040084D8 RID: 34008
		[UIObject("TabGroup/ScrollRect/Viewport/Tabs/Member/RedPoint")]
		private GameObject m_objMemberRedPoint;

		// Token: 0x040084D9 RID: 34009
		[UIObject("TabGroup/ScrollRect/Viewport/Tabs/Building/RedPoint")]
		private GameObject m_objBuildingRedPoint;

		// Token: 0x040084DA RID: 34010
		[UIObject("TabGroup/ScrollRect/Viewport/Tabs/Manor/RedPoint")]
		private GameObject m_objManorRedPoint;

		// Token: 0x040084DB RID: 34011
		[UIObject("TabGroup/ScrollRect/Viewport/Tabs/Shop/RedPoint")]
		private GameObject m_objShopRedPoint;

		// Token: 0x040084DC RID: 34012
		[UIObject("TabGroup/ScrollRect/Viewport/Tabs/CrossManor/RedPoint")]
		private GameObject m_objCrossManorRedPoint;

		// Token: 0x040084DD RID: 34013
		[UIObject("TabGroup/ScrollRect/Viewport/Tabs/RedPacket/RedPoint")]
		private GameObject m_objRedPacketRedPoint;

		// Token: 0x040084DE RID: 34014
		[UIObject("TabGroup/Page")]
		private GameObject m_objContentRoot;

		// Token: 0x040084DF RID: 34015
		[UIControl("BG/Title/Moneys", typeof(ComConsumeItemGroup), 0)]
		private ComConsumeItemGroup m_comConsumeItemGroup;

		// Token: 0x040084E0 RID: 34016
		private bool m_bToggleBlockSignal;

		// Token: 0x040084E1 RID: 34017
		private IClientFrame m_baseFrame;

		// Token: 0x040084E2 RID: 34018
		private IClientFrame m_memberFrame;

		// Token: 0x040084E3 RID: 34019
		private IClientFrame m_buildingFrame;

		// Token: 0x040084E4 RID: 34020
		private IClientFrame m_manorFrame;

		// Token: 0x040084E5 RID: 34021
		private IClientFrame m_storageFrame;

		// Token: 0x040084E6 RID: 34022
		private IClientFrame m_shopFrame;

		// Token: 0x040084E7 RID: 34023
		private IClientFrame m_crossManorFrame;

		// Token: 0x040084E8 RID: 34024
		private IClientFrame m_guildRedPackFrame;

		// Token: 0x040084E9 RID: 34025
		private object m_buildingParam;

		// Token: 0x040084EA RID: 34026
		private Toggle Emblem;

		// Token: 0x040084EB RID: 34027
		private Image EmblemRedPoint;

		// Token: 0x040084EC RID: 34028
		private Toggle Benefits;

		// Token: 0x040084ED RID: 34029
		private Toggle Activity;

		// Token: 0x040084EE RID: 34030
		private GameObject activityRedPoint;

		// Token: 0x040084EF RID: 34031
		private static bool ms_bFuncsInited = false;

		// Token: 0x040084F0 RID: 34032
		private static GuildMyMainFrame.OperateFunc[] ms_arrOperateFuncs = new GuildMyMainFrame.OperateFunc[15];

		// Token: 0x040084F1 RID: 34033
		private float openShopFrameTime;

		// Token: 0x040084F2 RID: 34034
		private const float openShopFrameCD = 1f;

		// Token: 0x0200163A RID: 5690
		public enum EOperateType
		{
			// Token: 0x040084FF RID: 34047
			Invalid = -1,
			// Token: 0x04008500 RID: 34048
			OpenBaseInfo,
			// Token: 0x04008501 RID: 34049
			OpenMembers,
			// Token: 0x04008502 RID: 34050
			OpenBuilding,
			// Token: 0x04008503 RID: 34051
			OpenBuildingTable,
			// Token: 0x04008504 RID: 34052
			OpenBuildingWelfare,
			// Token: 0x04008505 RID: 34053
			OpenBuildingStatue,
			// Token: 0x04008506 RID: 34054
			OpenBuildingSkill,
			// Token: 0x04008507 RID: 34055
			OpenBuildingShop,
			// Token: 0x04008508 RID: 34056
			OpenManor,
			// Token: 0x04008509 RID: 34057
			OpenGuildStore,
			// Token: 0x0400850A RID: 34058
			OpenGuildCrossManor,
			// Token: 0x0400850B RID: 34059
			OpenGuildRedPacket,
			// Token: 0x0400850C RID: 34060
			OpenGuildEmblemLevel,
			// Token: 0x0400850D RID: 34061
			OpenGuildBenefits,
			// Token: 0x0400850E RID: 34062
			OpenGuildActivity,
			// Token: 0x0400850F RID: 34063
			Count
		}

		// Token: 0x0200163B RID: 5691
		// (Invoke) Token: 0x0600DFE2 RID: 57314
		private delegate void OperateFunc(params object[] a_arrParams);
	}
}
