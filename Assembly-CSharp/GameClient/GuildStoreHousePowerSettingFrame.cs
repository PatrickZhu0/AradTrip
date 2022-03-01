using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001661 RID: 5729
	internal class GuildStoreHousePowerSettingFrame : ClientFrame
	{
		// Token: 0x0600E144 RID: 57668 RVA: 0x0039B8BB File Offset: 0x00399CBB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildStoreHousePowerSettingFrame";
		}

		// Token: 0x0600E145 RID: 57669 RVA: 0x0039B8C2 File Offset: 0x00399CC2
		[UIEventHandle("BtnClose")]
		private void _OnClickCloseFrame()
		{
			this.frameMgr.CloseFrame<GuildStoreHousePowerSettingFrame>(this, false);
		}

		// Token: 0x0600E146 RID: 57670 RVA: 0x0039B8D4 File Offset: 0x00399CD4
		public static void CommandOpen(object argv = null)
		{
			if (argv == null)
			{
				argv = new GuildStoreHousePowerSettingFrameData
				{
					toggle0s = GuildDataManager.winPowerSetting,
					toggle1s = GuildDataManager.losePowerSetting
				};
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStoreHousePowerSettingFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600E147 RID: 57671 RVA: 0x0039B918 File Offset: 0x00399D18
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as GuildStoreHousePowerSettingFrameData);
			this._InitToggle0();
			this._InitToggle1();
			this._InitToggle2();
			this._InitToggle3();
			GuildDataManager instance = DataManager<GuildDataManager>.GetInstance();
			instance.onGuildPowerChanged = (GuildDataManager.OnGuildPowerChanged)Delegate.Combine(instance.onGuildPowerChanged, new GuildDataManager.OnGuildPowerChanged(this._OnGuildPowerChanged));
		}

		// Token: 0x0600E148 RID: 57672 RVA: 0x0039B974 File Offset: 0x00399D74
		private void _OnGuildPowerChanged(PowerSettingType ePowerSettingType, int iPowerValue)
		{
			if (ePowerSettingType <= PowerSettingType.PST_INVALID || ePowerSettingType >= PowerSettingType.PST_COUNT)
			{
				return;
			}
			switch (ePowerSettingType)
			{
			case PowerSettingType.PST_WIN_POWER:
				iPowerValue = DataManager<GuildDataManager>.GetInstance().translateWinPowerIndex(iPowerValue);
				if (this.data != null && this.data.toggle0s != null && iPowerValue >= 0 && iPowerValue < this.data.toggle0s.Count && iPowerValue < this.m_akToggle0s.Count)
				{
					for (int i = 0; i < this.m_akToggle0s.Count; i++)
					{
						int iIndex = i;
						this.m_akToggle0s[i].onValueChanged.RemoveAllListeners();
						this.m_akToggle0s[i].onValueChanged.AddListener(delegate(bool bValue)
						{
							this.m_goSelecte0s[iIndex].CustomActive(bValue);
						});
					}
					this.m_akToggle0s[iPowerValue].isOn = true;
					for (int j = 0; j < this.m_akToggle0s.Count; j++)
					{
						int iPowerIndex = j;
						this.m_akToggle0s[j].onValueChanged.AddListener(delegate(bool bValue)
						{
							if (bValue)
							{
								int winPowerByIndex = GuildDataManager.getWinPowerByIndex(iPowerIndex);
								DataManager<GuildDataManager>.GetInstance().SendChangeGuildSettingPower(PowerSettingType.PST_WIN_POWER, winPowerByIndex);
							}
						});
					}
				}
				break;
			case PowerSettingType.PST_LOSE_POWER:
				iPowerValue = DataManager<GuildDataManager>.GetInstance().translateLosePowerIndex(iPowerValue);
				if (this.data != null && this.data.toggle1s != null && iPowerValue >= 0 && iPowerValue < this.data.toggle1s.Count && iPowerValue < this.m_akToggle1s.Count)
				{
					for (int k = 0; k < this.m_akToggle1s.Count; k++)
					{
						int iIndex = k;
						this.m_akToggle1s[k].onValueChanged.RemoveAllListeners();
						this.m_akToggle1s[k].onValueChanged.AddListener(delegate(bool bValue)
						{
							this.m_goSelecte1s[iIndex].CustomActive(bValue);
						});
					}
					this.m_akToggle1s[iPowerValue].isOn = true;
					for (int l = 0; l < this.m_akToggle1s.Count; l++)
					{
						int iPowerIndex = l;
						this.m_akToggle1s[l].onValueChanged.AddListener(delegate(bool bValue)
						{
							if (bValue)
							{
								int losePowerByIndex = GuildDataManager.getLosePowerByIndex(iPowerIndex);
								DataManager<GuildDataManager>.GetInstance().SendChangeGuildSettingPower(PowerSettingType.PST_LOSE_POWER, losePowerByIndex);
							}
						});
					}
				}
				break;
			case PowerSettingType.PST_CONTRIBUTE_POWER:
			{
				int num = 0;
				GuildPost guildPost = (GuildPost)iPowerValue;
				if (guildPost == GuildPost.GUILD_POST_ELDER)
				{
					num = 1;
				}
				else if (guildPost == GuildPost.GUILD_POST_NORMAL)
				{
					num = 0;
				}
				if (num >= 0 && num < this.m_akToggle2s.Count)
				{
					for (int m = 0; m < this.m_akToggle2s.Count; m++)
					{
						int iIndex = m;
						this.m_akToggle2s[m].onValueChanged.RemoveAllListeners();
						this.m_akToggle2s[m].onValueChanged.AddListener(delegate(bool bValue)
						{
							this.m_goSelecte2s[iIndex].CustomActive(bValue);
						});
					}
					this.m_akToggle2s[num].isOn = true;
					for (int n = 0; n < this.m_akToggle2s.Count; n++)
					{
						GuildPost eResult = (n != 0) ? GuildPost.GUILD_POST_ELDER : GuildPost.GUILD_POST_NORMAL;
						this.m_akToggle2s[n].onValueChanged.AddListener(delegate(bool bValue)
						{
							if (bValue)
							{
								DataManager<GuildDataManager>.GetInstance().SendChangeGuildSettingPower(PowerSettingType.PST_CONTRIBUTE_POWER, (int)eResult);
							}
						});
					}
				}
				break;
			}
			case PowerSettingType.PST_DELETE_POWER:
			{
				int num2 = 0;
				GuildPost guildPost2 = (GuildPost)iPowerValue;
				if (guildPost2 == GuildPost.GUILD_POST_ASSISTANT)
				{
					num2 = 0;
				}
				else if (guildPost2 == GuildPost.GUILD_POST_ELDER)
				{
					num2 = 1;
				}
				if (num2 >= 0 && num2 < this.m_akToggle3s.Count)
				{
					for (int num3 = 0; num3 < this.m_akToggle3s.Count; num3++)
					{
						int iIndex = num3;
						this.m_akToggle3s[num3].onValueChanged.RemoveAllListeners();
						this.m_akToggle3s[num3].onValueChanged.AddListener(delegate(bool bValue)
						{
							this.m_goSelecte3s[iIndex].CustomActive(bValue);
						});
					}
					this.m_akToggle3s[num2].isOn = true;
					for (int num4 = 0; num4 < this.m_akToggle3s.Count; num4++)
					{
						GuildPost eResult = (num4 != 0) ? GuildPost.GUILD_POST_ELDER : GuildPost.GUILD_POST_ASSISTANT;
						this.m_akToggle3s[num4].onValueChanged.AddListener(delegate(bool bValue)
						{
							if (bValue)
							{
								DataManager<GuildDataManager>.GetInstance().SendChangeGuildSettingPower(PowerSettingType.PST_DELETE_POWER, (int)eResult);
							}
						});
					}
				}
				break;
			}
			}
		}

		// Token: 0x0600E149 RID: 57673 RVA: 0x0039BE54 File Offset: 0x0039A254
		private void _InitToggle0()
		{
			GameObject parent = Utility.FindChild(this.frame, "VP/TGP");
			GameObject gameObject = Utility.FindChild(this.frame, "VP/TGP/TG0");
			gameObject.CustomActive(false);
			for (int i = 0; i < this.data.toggle0s.Count; i++)
			{
				int num = this.data.toggle0s[i];
				GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
				if (!(null == gameObject2))
				{
					Utility.AttachTo(gameObject2, parent, false);
					gameObject2.CustomActive(true);
					Text text = Utility.FindComponent<Text>(gameObject2, "Desc", true);
					if (null != text)
					{
						text.text = string.Format("{0}%", num);
					}
					GameObject gameObject3 = Utility.FindChild(gameObject2, "Selected");
					gameObject3.CustomActive(false);
					Toggle component = gameObject2.GetComponent<Toggle>();
					if (null != component)
					{
						this.m_akToggle0s.Add(component);
						this.m_goSelecte0s.Add(gameObject3);
					}
				}
			}
			this._OnGuildPowerChanged(PowerSettingType.PST_WIN_POWER, DataManager<GuildDataManager>.GetInstance().winPower);
		}

		// Token: 0x0600E14A RID: 57674 RVA: 0x0039BF74 File Offset: 0x0039A374
		private void _UnInitToggle0()
		{
			for (int i = 0; i < this.m_akToggle0s.Count; i++)
			{
				this.m_akToggle0s[i].onValueChanged.RemoveAllListeners();
			}
			this.m_akToggle0s.Clear();
			this.m_goSelecte0s.Clear();
		}

		// Token: 0x0600E14B RID: 57675 RVA: 0x0039BFC9 File Offset: 0x0039A3C9
		private void _SendChangeGuildPower(PowerSettingType ePowerSettingType, int iPower)
		{
		}

		// Token: 0x0600E14C RID: 57676 RVA: 0x0039BFCC File Offset: 0x0039A3CC
		private void _InitToggle1()
		{
			GameObject parent = Utility.FindChild(this.frame, "FP/TGP");
			GameObject gameObject = Utility.FindChild(this.frame, "FP/TGP/TG0");
			gameObject.CustomActive(false);
			for (int i = 0; i < this.data.toggle0s.Count; i++)
			{
				int num = this.data.toggle0s[i];
				GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
				if (!(null == gameObject2))
				{
					Utility.AttachTo(gameObject2, parent, false);
					gameObject2.CustomActive(true);
					Text text = Utility.FindComponent<Text>(gameObject2, "Desc", true);
					if (null != text)
					{
						text.text = string.Format("{0}%", num);
					}
					GameObject gameObject3 = Utility.FindChild(gameObject2, "Selected");
					gameObject3.CustomActive(false);
					Toggle component = gameObject2.GetComponent<Toggle>();
					if (null != component)
					{
						this.m_akToggle1s.Add(component);
						this.m_goSelecte1s.Add(gameObject3);
					}
				}
			}
			this._OnGuildPowerChanged(PowerSettingType.PST_LOSE_POWER, DataManager<GuildDataManager>.GetInstance().losePower);
		}

		// Token: 0x0600E14D RID: 57677 RVA: 0x0039C0EC File Offset: 0x0039A4EC
		private void _UnInitToggle1()
		{
			for (int i = 0; i < this.m_akToggle1s.Count; i++)
			{
				this.m_akToggle1s[i].onValueChanged.RemoveAllListeners();
			}
			this.m_akToggle1s.Clear();
			this.m_goSelecte1s.Clear();
		}

		// Token: 0x0600E14E RID: 57678 RVA: 0x0039C144 File Offset: 0x0039A544
		private void _InitToggle2()
		{
			for (int i = 0; i < 2; i++)
			{
				GameObject gameObject = Utility.FindChild(this.frame, string.Format("PF/TGP0/TG{0}", i));
				gameObject.CustomActive(true);
				GameObject gameObject2 = Utility.FindChild(gameObject, "Selected");
				gameObject2.CustomActive(false);
				Toggle component = gameObject.GetComponent<Toggle>();
				if (null != component)
				{
					this.m_akToggle2s.Add(component);
					this.m_goSelecte2s.Add(gameObject2);
				}
			}
			this._OnGuildPowerChanged(PowerSettingType.PST_CONTRIBUTE_POWER, (int)DataManager<GuildDataManager>.GetInstance().contributePower);
		}

		// Token: 0x0600E14F RID: 57679 RVA: 0x0039C1D8 File Offset: 0x0039A5D8
		private void _UnInitToggle2()
		{
			for (int i = 0; i < this.m_akToggle2s.Count; i++)
			{
				this.m_akToggle2s[i].onValueChanged.RemoveAllListeners();
			}
			this.m_akToggle2s.Clear();
			this.m_goSelecte2s.Clear();
		}

		// Token: 0x0600E150 RID: 57680 RVA: 0x0039C230 File Offset: 0x0039A630
		private void _InitToggle3()
		{
			for (int i = 0; i < 2; i++)
			{
				GameObject gameObject = Utility.FindChild(this.frame, string.Format("PF/TGP1/TG{0}", i));
				gameObject.CustomActive(true);
				GameObject gameObject2 = Utility.FindChild(gameObject, "Selected");
				gameObject2.CustomActive(false);
				Toggle component = gameObject.GetComponent<Toggle>();
				if (null != component)
				{
					this.m_akToggle3s.Add(component);
					this.m_goSelecte3s.Add(gameObject2);
				}
			}
			this._OnGuildPowerChanged(PowerSettingType.PST_DELETE_POWER, (int)DataManager<GuildDataManager>.GetInstance().clearPower);
		}

		// Token: 0x0600E151 RID: 57681 RVA: 0x0039C2C4 File Offset: 0x0039A6C4
		private void _UnInitToggle3()
		{
			for (int i = 0; i < this.m_akToggle3s.Count; i++)
			{
				this.m_akToggle3s[i].onValueChanged.RemoveAllListeners();
			}
			this.m_akToggle3s.Clear();
			this.m_goSelecte3s.Clear();
		}

		// Token: 0x0600E152 RID: 57682 RVA: 0x0039C31C File Offset: 0x0039A71C
		protected override void _OnCloseFrame()
		{
			this._UnInitToggle0();
			this._UnInitToggle1();
			this._UnInitToggle2();
			this._UnInitToggle3();
			GuildDataManager instance = DataManager<GuildDataManager>.GetInstance();
			instance.onGuildPowerChanged = (GuildDataManager.OnGuildPowerChanged)Delegate.Remove(instance.onGuildPowerChanged, new GuildDataManager.OnGuildPowerChanged(this._OnGuildPowerChanged));
			this.data = null;
		}

		// Token: 0x04008611 RID: 34321
		private GuildStoreHousePowerSettingFrameData data;

		// Token: 0x04008612 RID: 34322
		private List<Toggle> m_akToggle0s = new List<Toggle>();

		// Token: 0x04008613 RID: 34323
		private List<GameObject> m_goSelecte0s = new List<GameObject>();

		// Token: 0x04008614 RID: 34324
		private List<Toggle> m_akToggle1s = new List<Toggle>();

		// Token: 0x04008615 RID: 34325
		private List<GameObject> m_goSelecte1s = new List<GameObject>();

		// Token: 0x04008616 RID: 34326
		private List<Toggle> m_akToggle2s = new List<Toggle>();

		// Token: 0x04008617 RID: 34327
		private List<GameObject> m_goSelecte2s = new List<GameObject>();

		// Token: 0x04008618 RID: 34328
		private List<Toggle> m_akToggle3s = new List<Toggle>();

		// Token: 0x04008619 RID: 34329
		private List<GameObject> m_goSelecte3s = new List<GameObject>();
	}
}
