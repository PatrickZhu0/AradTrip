using System;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;
using XUPorterJSON;

// Token: 0x02000D74 RID: 3444
public class GeGraphicSetting : Singleton<GeGraphicSetting>
{
	// Token: 0x06008BC6 RID: 35782 RVA: 0x0019C900 File Offset: 0x0019AD00
	public override void Init()
	{
		if (!this.LoadSetting())
		{
			this.AddSetting("GraphicLevel", 0);
			this.AddSetting("PlayerDisplayNum", 20);
		}
		int num = 0;
		if (!this.GetSetting("Version", ref num))
		{
			Debug.Log("### Loading Version succeed!");
			int androidOSAPILevel = (int)OSInfo.GetAndroidOSAPILevel();
			Debug.Log("### GetAndroidOSAPILevel value is " + androidOSAPILevel.ToString());
			if ((0 < androidOSAPILevel && androidOSAPILevel < 22) || OSInfo.GetSysMemorySize() < 1200)
			{
				Debug.Log("### Android system version is not good or memory is less than 1GB!");
				this.isModified = true;
				this.SetSetting("GraphicLevel", 2);
				this.SetSetting("PlayerDisplayNum", 5);
			}
			this.AddSetting("Version", this.VERSION);
			Debug.Log("### Save setting!");
			this.SaveSetting();
		}
	}

	// Token: 0x06008BC7 RID: 35783 RVA: 0x0019C9E0 File Offset: 0x0019ADE0
	public void SetGraphicLevel(GraphicLevel level)
	{
		this.SetSetting("GraphicLevel", (int)level);
		if (level == GraphicLevel.NORMAL)
		{
			this.SetSetting("PlayerDisplayNum", 20);
		}
		else if (level == GraphicLevel.MIDDLE)
		{
			this.SetSetting("PlayerDisplayNum", 10);
		}
		else if (level == GraphicLevel.LOW)
		{
			this.SetSetting("PlayerDisplayNum", 5);
			this.DoSetLowLevel();
		}
	}

	// Token: 0x06008BC8 RID: 35784 RVA: 0x0019CA48 File Offset: 0x0019AE48
	public int GetGraphicLevel()
	{
		int result = 0;
		Singleton<GeGraphicSetting>.instance.GetSetting("GraphicLevel", ref result);
		return result;
	}

	// Token: 0x06008BC9 RID: 35785 RVA: 0x0019CA6C File Offset: 0x0019AE6C
	public void DoSetLowLevel()
	{
		if (BattleMain.instance == null)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				int displayNum = 0;
				this.GetSetting("PlayerDisplayNum", ref displayNum);
				clientSystemTown.OnGraphicSettingChange(displayNum);
			}
		}
		else if (BattleMain.instance != null && !BattleMain.IsModePvP(BattleMain.battleType))
		{
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (!allPlayers[i].playerActor.isLocalActor)
				{
					BeActor playerActor = allPlayers[i].playerActor;
					playerActor.m_pkGeActor.GetEffectManager().useCube = true;
					List<BeActor> list = ListPool<BeActor>.Get();
					playerActor.CurrentBeScene.GetSummonBySummoner(list, playerActor, false, false);
					for (int j = 0; j < list.Count; j++)
					{
						list[j].m_pkGeActor.SetUseCube(true);
						list[j].m_pkGeActor.SetActorForLowLevel();
					}
					ListPool<BeActor>.Release(list);
				}
			}
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.comShowHit.RefreshGraphicSetting();
			}
		}
	}

	// Token: 0x06008BCA RID: 35786 RVA: 0x0019CBB4 File Offset: 0x0019AFB4
	public bool IsHighLevel()
	{
		int num = 0;
		Singleton<GeGraphicSetting>.instance.GetSetting("GraphicLevel", ref num);
		return num == 0;
	}

	// Token: 0x06008BCB RID: 35787 RVA: 0x0019CBDC File Offset: 0x0019AFDC
	public bool IsMiddleLevel()
	{
		int num = 0;
		Singleton<GeGraphicSetting>.instance.GetSetting("GraphicLevel", ref num);
		return num == 1;
	}

	// Token: 0x06008BCC RID: 35788 RVA: 0x0019CC04 File Offset: 0x0019B004
	public bool IsLowLevel()
	{
		int num = 0;
		Singleton<GeGraphicSetting>.instance.GetSetting("GraphicLevel", ref num);
		return num == 2;
	}

	// Token: 0x06008BCD RID: 35789 RVA: 0x0019CC2C File Offset: 0x0019B02C
	public bool AddSetting(string key, int value)
	{
		string value2 = value.ToString();
		return this._AddSetting(key, value2);
	}

	// Token: 0x06008BCE RID: 35790 RVA: 0x0019CC50 File Offset: 0x0019B050
	public bool AddSetting(string key, float value)
	{
		string value2 = value.ToString();
		return this._AddSetting(key, value2);
	}

	// Token: 0x06008BCF RID: 35791 RVA: 0x0019CC74 File Offset: 0x0019B074
	public bool AddSetting(string key, bool value)
	{
		string value2 = value.ToString();
		return this._AddSetting(key, value2);
	}

	// Token: 0x06008BD0 RID: 35792 RVA: 0x0019CC98 File Offset: 0x0019B098
	public bool SetSetting(string key, int value)
	{
		string value2 = value.ToString();
		return this._SetSetting(key, value2);
	}

	// Token: 0x06008BD1 RID: 35793 RVA: 0x0019CCBC File Offset: 0x0019B0BC
	public bool SetSetting(string key, float value)
	{
		string value2 = value.ToString();
		return this._SetSetting(key, value2);
	}

	// Token: 0x06008BD2 RID: 35794 RVA: 0x0019CCE0 File Offset: 0x0019B0E0
	public bool SetSetting(string key, bool value)
	{
		string value2 = value.ToString();
		return this._SetSetting(key, value2);
	}

	// Token: 0x06008BD3 RID: 35795 RVA: 0x0019CD04 File Offset: 0x0019B104
	public bool GetSetting(string key, ref int value)
	{
		string s = null;
		return this._GetSetting(key, ref s) && int.TryParse(s, out value);
	}

	// Token: 0x06008BD4 RID: 35796 RVA: 0x0019CD30 File Offset: 0x0019B130
	public bool GetSetting(string key, ref float value)
	{
		string s = null;
		return this._GetSetting(key, ref s) && float.TryParse(s, out value);
	}

	// Token: 0x06008BD5 RID: 35797 RVA: 0x0019CD5C File Offset: 0x0019B15C
	public bool GetSetting(string key, ref bool value)
	{
		string value2 = null;
		if (this._GetSetting(key, ref value2) && bool.TryParse(value2, out value))
		{
			Debug.Log("### Load graphic setting " + key);
			return true;
		}
		return false;
	}

	// Token: 0x06008BD6 RID: 35798 RVA: 0x0019CD98 File Offset: 0x0019B198
	public bool LoadSetting()
	{
		bool result;
		try
		{
			string json = null;
			if (FileArchiveAccessor.LoadFileInPersistentFileArchive(this.GE_SETTING_RES, out json))
			{
				Hashtable hashtable = MiniJSON.jsonDecode(json) as Hashtable;
				IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string dataKey = enumerator.Key as string;
					string dataValue = enumerator.Value as string;
					GeGraphicSetting.GeSettingDesc geSettingDesc = new GeGraphicSetting.GeSettingDesc();
					geSettingDesc.m_DataKey = dataKey;
					geSettingDesc.m_DataValue = dataValue;
					this.m_GeSettingDescList.Add(geSettingDesc);
				}
				Debug.Log("### Load graphic setting succeed!");
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("LoadSetting error {0}!", new object[]
			{
				ex.ToString()
			});
			result = false;
		}
		return result;
	}

	// Token: 0x06008BD7 RID: 35799 RVA: 0x0019CE6C File Offset: 0x0019B26C
	public void SaveSetting()
	{
		Hashtable hashtable = new Hashtable();
		int i = 0;
		int count = this.m_GeSettingDescList.Count;
		while (i < count)
		{
			GeGraphicSetting.GeSettingDesc geSettingDesc = this.m_GeSettingDescList[i];
			if (geSettingDesc != null)
			{
				hashtable.Add(geSettingDesc.m_DataKey, geSettingDesc.m_DataValue);
			}
			i++;
		}
		string data = MiniJSON.jsonEncode(hashtable);
		if (!FileArchiveAccessor.SaveFileInPersistentFileArchive(this.GE_SETTING_RES, data))
		{
		}
	}

	// Token: 0x06008BD8 RID: 35800 RVA: 0x0019CEE4 File Offset: 0x0019B2E4
	public bool _GetSetting(string key, ref string value)
	{
		GeGraphicSetting.GeSettingDesc geSettingDesc = this._GetSettingDesc(key, false);
		if (geSettingDesc != null)
		{
			value = geSettingDesc.m_DataValue;
			return true;
		}
		return false;
	}

	// Token: 0x06008BD9 RID: 35801 RVA: 0x0019CF0C File Offset: 0x0019B30C
	protected bool _AddSetting(string key, string value)
	{
		GeGraphicSetting.GeSettingDesc geSettingDesc = this._GetSettingDesc(key, true);
		if (geSettingDesc != null)
		{
			return false;
		}
		GeGraphicSetting.GeSettingDesc geSettingDesc2 = new GeGraphicSetting.GeSettingDesc();
		geSettingDesc2.m_DataKey = key.ToLower();
		geSettingDesc2.m_DataValue = value;
		this.m_GeSettingDescList.Add(geSettingDesc2);
		return true;
	}

	// Token: 0x06008BDA RID: 35802 RVA: 0x0019CF50 File Offset: 0x0019B350
	protected bool _SetSetting(string key, string value)
	{
		GeGraphicSetting.GeSettingDesc geSettingDesc = this._GetSettingDesc(key, false);
		if (geSettingDesc != null)
		{
			geSettingDesc.m_DataValue = value;
			return true;
		}
		return false;
	}

	// Token: 0x06008BDB RID: 35803 RVA: 0x0019CF78 File Offset: 0x0019B378
	protected GeGraphicSetting.GeSettingDesc _GetSettingDesc(string key, bool mute = false)
	{
		int i = 0;
		int count = this.m_GeSettingDescList.Count;
		while (i < count)
		{
			GeGraphicSetting.GeSettingDesc geSettingDesc = this.m_GeSettingDescList[i];
			if (geSettingDesc != null)
			{
				if (key.Equals(geSettingDesc.m_DataKey, StringComparison.OrdinalIgnoreCase))
				{
					return geSettingDesc;
				}
			}
			i++;
		}
		if (!mute)
		{
		}
		return null;
	}

	// Token: 0x06008BDC RID: 35804 RVA: 0x0019CFD8 File Offset: 0x0019B3D8
	public void CheckTownFPS()
	{
		if (!this.needPromoted && MonoSingleton<ComponentFPS>.instance.GetLastAverageFPS() <= MonoSingleton<ComponentFPS>.instance.lowFrameTown && !this.IsLowLevel() && Singleton<ClientSystemManager>.GetInstance().IsMainPrefabTop())
		{
			this.needPromoted = true;
		}
	}

	// Token: 0x06008BDD RID: 35805 RVA: 0x0019D02C File Offset: 0x0019B42C
	public void CheckBattleFPS()
	{
		if (!this.needPromoted && BattleMain.instance != null && MonoSingleton<ComponentFPS>.instance.GetLastAverageFPS() <= MonoSingleton<ComponentFPS>.instance.lowFrameTown && !this.IsLowLevel() && BattleMain.instance.GetDungeonManager() != null && BattleMain.instance.GetDungeonManager().GetBeScene() != null && BattleMain.instance.GetDungeonManager().GetBeScene().state == BeSceneState.onFight)
		{
			this.needPromoted = true;
		}
	}

	// Token: 0x06008BDE RID: 35806 RVA: 0x0019D0B8 File Offset: 0x0019B4B8
	public void CheckComponent(GameObject go)
	{
		if (go == null)
		{
			return;
		}
		ComGraphicControl[] componentsInChildren = go.GetComponentsInChildren<ComGraphicControl>();
		if (componentsInChildren != null)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].controlEnum == ComGraphicControl.GraphicControlEnum.High)
				{
					componentsInChildren[i].gameObject.CustomActive(false);
				}
				else if (componentsInChildren[i].controlEnum == ComGraphicControl.GraphicControlEnum.Mid && (Singleton<GeGraphicSetting>.instance.IsLowLevel() || Singleton<GeGraphicSetting>.instance.IsMiddleLevel()))
				{
					componentsInChildren[i].gameObject.CustomActive(false);
				}
				else if ((componentsInChildren[i].controlEnum == ComGraphicControl.GraphicControlEnum.Low || componentsInChildren[i].controlEnum == ComGraphicControl.GraphicControlEnum.VeryLow) && Singleton<GeGraphicSetting>.instance.IsLowLevel())
				{
					componentsInChildren[i].gameObject.CustomActive(false);
				}
				else
				{
					componentsInChildren[i].gameObject.CustomActive(true);
				}
			}
		}
	}

	// Token: 0x04004512 RID: 17682
	public bool needPromoted;

	// Token: 0x04004513 RID: 17683
	public bool isModified;

	// Token: 0x04004514 RID: 17684
	protected readonly int VERSION = 2;

	// Token: 0x04004515 RID: 17685
	protected readonly string GE_SETTING_RES = "GraphicSetting.json";

	// Token: 0x04004516 RID: 17686
	private List<GeGraphicSetting.GeSettingDesc> m_GeSettingDescList = new List<GeGraphicSetting.GeSettingDesc>();

	// Token: 0x02000D75 RID: 3445
	protected class GeSettingDesc
	{
		// Token: 0x04004517 RID: 17687
		public string m_DataKey;

		// Token: 0x04004518 RID: 17688
		public string m_DataValue;
	}
}
