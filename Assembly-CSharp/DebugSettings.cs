using System;
using System.Collections;
using System.Collections.Generic;
using XUPorterJSON;

// Token: 0x0200011B RID: 283
public class DebugSettings : Singleton<DebugSettings>
{
	// Token: 0x17000070 RID: 112
	// (get) Token: 0x0600064B RID: 1611 RVA: 0x00025E20 File Offset: 0x00024220
	public bool DisableAnimation
	{
		get
		{
			return this._disableAnimation;
		}
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x0600064C RID: 1612 RVA: 0x00025E28 File Offset: 0x00024228
	public bool DummyEffect
	{
		get
		{
			return this._DummyEffect;
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x0600064D RID: 1613 RVA: 0x00025E30 File Offset: 0x00024230
	public bool DisableBugly
	{
		get
		{
			return this._disableBugly;
		}
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x0600064E RID: 1614 RVA: 0x00025E38 File Offset: 0x00024238
	public bool DisableAudio
	{
		get
		{
			return this._disableAudio;
		}
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x0600064F RID: 1615 RVA: 0x00025E40 File Offset: 0x00024240
	public bool DisableGameObjPool
	{
		get
		{
			return this._disableGameObjPool;
		}
	}

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x06000650 RID: 1616 RVA: 0x00025E48 File Offset: 0x00024248
	public bool DisableAnimMaterial
	{
		get
		{
			return this._disableAnimMaterial;
		}
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x06000651 RID: 1617 RVA: 0x00025E50 File Offset: 0x00024250
	public bool DisableAI
	{
		get
		{
			return this._disableAI;
		}
	}

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x06000652 RID: 1618 RVA: 0x00025E58 File Offset: 0x00024258
	public bool DisableHitText
	{
		get
		{
			return this._disableHitText;
		}
	}

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x06000653 RID: 1619 RVA: 0x00025E60 File Offset: 0x00024260
	public bool DisableChatDisplay
	{
		get
		{
			return this._disableChatDispaly;
		}
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000654 RID: 1620 RVA: 0x00025E68 File Offset: 0x00024268
	public bool DisableModuleLoad
	{
		get
		{
			return this._disableModuleLoad;
		}
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000655 RID: 1621 RVA: 0x00025E70 File Offset: 0x00024270
	public bool DisableSnap
	{
		get
		{
			return this._disableSnap;
		}
	}

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000656 RID: 1622 RVA: 0x00025E78 File Offset: 0x00024278
	public bool DisablePreload
	{
		get
		{
			return this._disablePreload;
		}
	}

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x06000657 RID: 1623 RVA: 0x00025E80 File Offset: 0x00024280
	public bool EnableActionFrameCache
	{
		get
		{
			return this._enableActionFrameCache;
		}
	}

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000658 RID: 1624 RVA: 0x00025E88 File Offset: 0x00024288
	public bool EnableDSkillDataCache
	{
		get
		{
			return this._enableDSkillDataCache;
		}
	}

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000659 RID: 1625 RVA: 0x00025E90 File Offset: 0x00024290
	public bool EnableTestFashionEquip
	{
		get
		{
			return this._enableTestFashionEquip;
		}
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x00025E98 File Offset: 0x00024298
	public override void Init()
	{
		base.Init();
		this._LoadSetting();
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x00025EA6 File Offset: 0x000242A6
	public override void UnInit()
	{
		base.UnInit();
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x00025EB0 File Offset: 0x000242B0
	public bool IsDebugEnable(string setting)
	{
		bool flag = false;
		return this.m_DebugSettings.TryGetValue(setting, out flag) && flag;
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x00025ED8 File Offset: 0x000242D8
	public void SetDebugEnable(string setting, bool enable)
	{
		if (this.m_DebugSettings.ContainsKey(setting))
		{
			this.m_DebugSettings[setting] = enable;
		}
		else
		{
			this.m_DebugSettings.Add(setting, enable);
		}
		this._SaveSetting();
		switch (setting)
		{
		case "DisableAnimation":
			this._disableAnimation = enable;
			return;
		case "DummyEffect":
			this._DummyEffect = enable;
			return;
		case "DisableBugly":
			this._disableBugly = enable;
			return;
		case "DisableAudio":
			this._disableAudio = enable;
			return;
		case "DisableGameObjPool":
			this._disableGameObjPool = enable;
			return;
		case "DisableAnimMaterial":
			this._disableAnimMaterial = enable;
			return;
		case "DisableAI":
			this._disableAI = enable;
			return;
		case "DisableHitText":
			this._disableHitText = enable;
			return;
		case "DisableChatDisplay":
			this._disableChatDispaly = enable;
			return;
		case "DisableModuleLoad":
			this._disableModuleLoad = enable;
			return;
		case "DisableSnap":
			this._disableSnap = enable;
			return;
		case "DisablePreload":
			this._disablePreload = enable;
			return;
		case "EnableActionFrameCache":
			this._enableActionFrameCache = enable;
			return;
		case "EnableDSkillDataCache":
			this._enableDSkillDataCache = enable;
			return;
		case "EnableTestFashionEquip":
			this._enableTestFashionEquip = enable;
			return;
		}
		Logger.LogErrorFormat("debugSetting找不到{0}", new object[]
		{
			setting
		});
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x0002611D File Offset: 0x0002451D
	public void AddDebugSetting(string setting, bool defEnabled)
	{
		if (!this.m_DebugSettings.ContainsKey(setting))
		{
			this.m_DebugSettings.Add(setting, defEnabled);
		}
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x00026140 File Offset: 0x00024540
	protected void _LoadSetting()
	{
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x00026150 File Offset: 0x00024550
	protected void _SaveSetting()
	{
		Hashtable json = new Hashtable(this.m_DebugSettings);
		string data = MiniJSON.jsonEncode(json);
		FileArchiveAccessor.SaveFileInPersistentFileArchive("DebugSettings.json", data);
	}

	// Token: 0x0400051B RID: 1307
	private Dictionary<string, bool> m_DebugSettings = new Dictionary<string, bool>();

	// Token: 0x0400051C RID: 1308
	private bool _disableAnimation;

	// Token: 0x0400051D RID: 1309
	private bool _DummyEffect;

	// Token: 0x0400051E RID: 1310
	private bool _disableBugly;

	// Token: 0x0400051F RID: 1311
	private bool _disableAudio;

	// Token: 0x04000520 RID: 1312
	private bool _disableGameObjPool;

	// Token: 0x04000521 RID: 1313
	private bool _disableAnimMaterial;

	// Token: 0x04000522 RID: 1314
	private bool _disableAI;

	// Token: 0x04000523 RID: 1315
	private bool _disableHitText;

	// Token: 0x04000524 RID: 1316
	private bool _disableChatDispaly;

	// Token: 0x04000525 RID: 1317
	private bool _disableModuleLoad;

	// Token: 0x04000526 RID: 1318
	private bool _disableSnap;

	// Token: 0x04000527 RID: 1319
	private bool _disablePreload;

	// Token: 0x04000528 RID: 1320
	private bool _enableActionFrameCache;

	// Token: 0x04000529 RID: 1321
	private bool _enableDSkillDataCache;

	// Token: 0x0400052A RID: 1322
	private bool _enableTestFashionEquip;
}
