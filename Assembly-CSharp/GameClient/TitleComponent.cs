using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004627 RID: 17959
	public class TitleComponent : MonoBehaviour
	{
		// Token: 0x060193D2 RID: 103378 RVA: 0x007FD3F8 File Offset: 0x007FB7F8
		public static TitleComponent Create(GameObject goParent)
		{
			if (goParent == null)
			{
				return null;
			}
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/TownUI/HeadTitle", enResourceType.UIPrefab, 2U);
			if (gameObject == null)
			{
				return null;
			}
			Utility.AttachTo(gameObject, goParent, false);
			return gameObject.GetComponent<TitleComponent>();
		}

		// Token: 0x060193D3 RID: 103379 RVA: 0x007FD444 File Offset: 0x007FB844
		public void OnRecycle()
		{
			if (this.layoutInsArray != null)
			{
				for (int i = 0; i < this.layoutInsArray.Length; i++)
				{
					if (this.layoutInsArray[i] != null && this.layoutInsArray[i].gameObject != null)
					{
						TitleConvert com = this.layoutInsArray[i].GetCom<TitleConvert>("TitleConvert");
						if (com != null)
						{
							com.OnRecycle();
						}
						Singleton<CGameObjectPool>.instance.RecycleGameObject(this.layoutInsArray[i].gameObject);
					}
				}
				this.layoutInsArray = null;
			}
			this.curLayoutCanvas = null;
			this.curLayoutIns = null;
			this.sName_TLT_LV_NAME = string.Empty;
			this.sName_TLT_LV_NAME_TITLE_VIP = string.Empty;
			this.sName_TLT_GANG = string.Empty;
			this.sName_TLT_NAME = string.Empty;
			this.sName_TLT_PKLV_NAME = string.Empty;
			this.sName_TLT_TLT_LV_NAME_TITLE = string.Empty;
			this.sName_TLT_ADVENT = string.Empty;
			this.sAdventureName_TLT_ADVENT = string.Empty;
			this.iTitleID_TLT_TLT_LV_NAME_TITLE = -1;
			this.iTitleID_TLT_LV_NAME_TITLE_VIP = -1;
			this.iLv_TLT_LV_NAME_TITLE_VIP = -1;
			this.iLv_TLT_LV_NAME = -1;
			this.iLv_TLT_TLT_LV_NAME_TITLE = -1;
			this.gangDuty_TLT_GANG = 100;
			this.iPkRank_TLT_PKLV_NAME = -1;
			base.gameObject.transform.SetParent(null);
			this.Level = 0;
			this.TitleID = 0;
			this.PKRank = 0;
			this.VipLevel = 0;
			this.GangDuty = 0;
			base.CancelInvoke("_UpdateTurn");
			base.gameObject.CustomActive(false);
			Singleton<CGameObjectPool>.instance.RecycleGameObject(base.gameObject);
		}

		// Token: 0x060193D4 RID: 103380 RVA: 0x007FD5D8 File Offset: 0x007FB9D8
		private void OnDestroy()
		{
			if (this.layoutInsArray != null)
			{
				for (int i = 0; i < this.layoutInsArray.Length; i++)
				{
					if (this.layoutInsArray[i] != null && this.layoutInsArray[i].gameObject)
					{
						TitleConvert com = this.layoutInsArray[i].GetCom<TitleConvert>("TitleConvert");
						if (com != null)
						{
							com.OnRecycle();
						}
						Singleton<CGameObjectPool>.instance.RecycleGameObject(this.layoutInsArray[i].gameObject);
					}
				}
				this.layoutInsArray = null;
			}
			base.CancelInvoke("_UpdateTurn");
		}

		// Token: 0x170020BA RID: 8378
		// (get) Token: 0x060193D5 RID: 103381 RVA: 0x007FD681 File Offset: 0x007FBA81
		// (set) Token: 0x060193D6 RID: 103382 RVA: 0x007FD68E File Offset: 0x007FBA8E
		public int Level
		{
			get
			{
				return this.kData.iLv;
			}
			set
			{
				this.kData.iLv = value;
			}
		}

		// Token: 0x170020BB RID: 8379
		// (get) Token: 0x060193D7 RID: 103383 RVA: 0x007FD69C File Offset: 0x007FBA9C
		// (set) Token: 0x060193D8 RID: 103384 RVA: 0x007FD6A9 File Offset: 0x007FBAA9
		public int TitleID
		{
			get
			{
				return this.kData.iTitleID;
			}
			set
			{
				this.kData.iTitleID = value;
				this._MarkDirty();
			}
		}

		// Token: 0x170020BC RID: 8380
		// (get) Token: 0x060193D9 RID: 103385 RVA: 0x007FD6BD File Offset: 0x007FBABD
		// (set) Token: 0x060193DA RID: 103386 RVA: 0x007FD6CA File Offset: 0x007FBACA
		public int PKRank
		{
			get
			{
				return this.kData.pkRank;
			}
			set
			{
				this.kData.pkRank = value;
			}
		}

		// Token: 0x170020BD RID: 8381
		// (get) Token: 0x060193DB RID: 103387 RVA: 0x007FD6D8 File Offset: 0x007FBAD8
		// (set) Token: 0x060193DC RID: 103388 RVA: 0x007FD6E5 File Offset: 0x007FBAE5
		public int VipLevel
		{
			get
			{
				return this.kData.iVipLevel;
			}
			set
			{
				this.kData.iVipLevel = value;
				this._MarkDirty();
			}
		}

		// Token: 0x170020BE RID: 8382
		// (get) Token: 0x060193DD RID: 103389 RVA: 0x007FD6F9 File Offset: 0x007FBAF9
		// (set) Token: 0x060193DE RID: 103390 RVA: 0x007FD706 File Offset: 0x007FBB06
		public string Name
		{
			get
			{
				return this.kData.name;
			}
			set
			{
				this.kData.name = value;
				this._MarkDirty();
			}
		}

		// Token: 0x170020BF RID: 8383
		// (get) Token: 0x060193DF RID: 103391 RVA: 0x007FD71A File Offset: 0x007FBB1A
		// (set) Token: 0x060193E0 RID: 103392 RVA: 0x007FD727 File Offset: 0x007FBB27
		public string GangIcon
		{
			get
			{
				return this.kData.gangIcon;
			}
			set
			{
				this.kData.gangIcon = value;
			}
		}

		// Token: 0x170020C0 RID: 8384
		// (get) Token: 0x060193E1 RID: 103393 RVA: 0x007FD735 File Offset: 0x007FBB35
		// (set) Token: 0x060193E2 RID: 103394 RVA: 0x007FD744 File Offset: 0x007FBB44
		public string GangName
		{
			get
			{
				return this.kData.gangName;
			}
			set
			{
				this.kData.gangName = value;
				EGuildDuty clientDuty = DataManager<GuildDataManager>.GetInstance().GetClientDuty(this.kData.gangDuty);
				this.HasGang = (clientDuty != EGuildDuty.Invalid);
			}
		}

		// Token: 0x170020C1 RID: 8385
		// (get) Token: 0x060193E3 RID: 103395 RVA: 0x007FD780 File Offset: 0x007FBB80
		// (set) Token: 0x060193E4 RID: 103396 RVA: 0x007FD790 File Offset: 0x007FBB90
		public byte GangDuty
		{
			get
			{
				return this.kData.gangDuty;
			}
			set
			{
				this.kData.gangDuty = value;
				EGuildDuty clientDuty = DataManager<GuildDataManager>.GetInstance().GetClientDuty(value);
				this.HasGang = (clientDuty != EGuildDuty.Invalid);
			}
		}

		// Token: 0x170020C2 RID: 8386
		// (get) Token: 0x060193E5 RID: 103397 RVA: 0x007FD7C2 File Offset: 0x007FBBC2
		// (set) Token: 0x060193E6 RID: 103398 RVA: 0x007FD7CF File Offset: 0x007FBBCF
		private bool HasGang
		{
			get
			{
				return this.kData.bHasGang;
			}
			set
			{
				this.kData.bHasGang = value;
				this._MarkDirty();
			}
		}

		// Token: 0x170020C3 RID: 8387
		// (get) Token: 0x060193E7 RID: 103399 RVA: 0x007FD7E3 File Offset: 0x007FBBE3
		// (set) Token: 0x060193E8 RID: 103400 RVA: 0x007FD7F0 File Offset: 0x007FBBF0
		public string AdventTeamName
		{
			get
			{
				return this.kData.adventTeamName;
			}
			set
			{
				this.kData.adventTeamName = value;
				this.HasAdventureTeam = !string.IsNullOrEmpty(this.kData.adventTeamName);
			}
		}

		// Token: 0x170020C4 RID: 8388
		// (get) Token: 0x060193E9 RID: 103401 RVA: 0x007FD817 File Offset: 0x007FBC17
		// (set) Token: 0x060193EA RID: 103402 RVA: 0x007FD824 File Offset: 0x007FBC24
		public PlayerWearedTitleInfo PlayerWearedTitleInfo
		{
			get
			{
				return this.kData.playerWearedTitleInfo;
			}
			set
			{
				this.kData.playerWearedTitleInfo = value;
				this.HasTitleName = DataManager<TitleDataManager>.GetInstance().IsHaveTitle();
			}
		}

		// Token: 0x170020C5 RID: 8389
		// (get) Token: 0x060193EB RID: 103403 RVA: 0x007FD842 File Offset: 0x007FBC42
		// (set) Token: 0x060193EC RID: 103404 RVA: 0x007FD84F File Offset: 0x007FBC4F
		public int GuildEmblemLv
		{
			get
			{
				return this.kData.guildEmblemLv;
			}
			set
			{
				this.kData.guildEmblemLv = value;
				this._MarkDirty();
			}
		}

		// Token: 0x170020C6 RID: 8390
		// (get) Token: 0x060193ED RID: 103405 RVA: 0x007FD863 File Offset: 0x007FBC63
		// (set) Token: 0x060193EE RID: 103406 RVA: 0x007FD870 File Offset: 0x007FBC70
		private bool HasAdventureTeam
		{
			get
			{
				return this.kData.bHasAdventureTeam;
			}
			set
			{
				this.kData.bHasAdventureTeam = value;
				this._MarkDirty();
			}
		}

		// Token: 0x170020C7 RID: 8391
		// (get) Token: 0x060193EF RID: 103407 RVA: 0x007FD884 File Offset: 0x007FBC84
		// (set) Token: 0x060193F0 RID: 103408 RVA: 0x007FD891 File Offset: 0x007FBC91
		private bool HasTitleName
		{
			get
			{
				return this.kData.bTitleName;
			}
			set
			{
				this.kData.bTitleName = value;
				this._MarkDirty();
			}
		}

		// Token: 0x060193F1 RID: 103409 RVA: 0x007FD8A8 File Offset: 0x007FBCA8
		private float SwitchStatus(int iStatus)
		{
			float result = 2f;
			if (this.layoutInsArray == null)
			{
				this.layoutInsArray = new ComCommonBind[8];
			}
			TitleComponent.TitleLayoutType titleLayoutType = (TitleComponent.TitleLayoutType)iStatus;
			if (this.curLayoutCanvas != null)
			{
				this.curLayoutCanvas.enabled = false;
				this.curLayoutCanvas = null;
			}
			if (this.curLayoutIns != null)
			{
				this.curLayoutIns.SetLayer("OUTUI");
				this.curLayoutIns = null;
			}
			ComCommonBind comCommonBind = this.layoutInsArray[iStatus];
			if (comCommonBind == null)
			{
				string prefabFullPath = "UIFlatten/Prefabs/TownUI/TitleLayout_" + titleLayoutType.ToString();
				GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(prefabFullPath, enResourceType.UIPrefab, 2U);
				if (gameObject == null)
				{
					return result;
				}
				Utility.AttachTo(gameObject, base.gameObject, false);
				comCommonBind = gameObject.GetComponent<ComCommonBind>();
				this.layoutInsArray[iStatus] = comCommonBind;
			}
			this.curLayoutIns = comCommonBind.gameObject;
			if (this.curLayoutIns != null)
			{
				this.curLayoutIns.SetLayer("SCENEUI");
			}
			this.curLayoutCanvas = comCommonBind.GetCom<Canvas>("Canvas");
			if (this.curLayoutCanvas != null)
			{
				this.curLayoutCanvas.enabled = true;
			}
			switch (titleLayoutType)
			{
			case TitleComponent.TitleLayoutType.TLT_NAME:
				this._UpdateLayout_TLT_NAME(comCommonBind);
				break;
			case TitleComponent.TitleLayoutType.TLT_PKLV_NAME:
				this._UpdateLayout_TLT_PKLV_NAME(comCommonBind);
				break;
			case TitleComponent.TitleLayoutType.TLT_LV_NAME_TITLE:
				result = this._UpdateLayout_TLT_LV_NAME_TITLE(comCommonBind);
				break;
			case TitleComponent.TitleLayoutType.TLT_GANG:
				this._UpdateLayout_TLT_GANG(comCommonBind);
				break;
			case TitleComponent.TitleLayoutType.TLT_LV_NAME:
				this._UpdateLayout_TLT_LV_NAME(comCommonBind);
				break;
			case TitleComponent.TitleLayoutType.TLT_LV_NAME_TITLE_VIP:
				result = this._UpdateLayout_TLT_LV_NAME_TITLE_VIP(comCommonBind);
				break;
			case TitleComponent.TitleLayoutType.TLT_ADVENT_LV_NAME_TITLE:
				this._UpdateLayout_TLT_ADVENT(comCommonBind);
				break;
			case TitleComponent.TitleLayoutType.TLT_ALL:
				this._UpdateLayout_TLT_ALL(comCommonBind);
				break;
			}
			return result;
		}

		// Token: 0x060193F2 RID: 103410 RVA: 0x007FDA74 File Offset: 0x007FBE74
		private void _SetText(Text text, string content)
		{
			if (text == null)
			{
				return;
			}
			text.font.RequestCharactersInTexture(content, text.fontSize, 0);
			float num = 1f;
			for (int i = 0; i < content.Length; i++)
			{
				CharacterInfo characterInfo;
				text.font.GetCharacterInfo(content[i], ref characterInfo, text.fontSize);
				num += (float)characterInfo.advance;
			}
			text.rectTransform.sizeDelta = new Vector2(num, 20f);
			text.text = content;
		}

		// Token: 0x060193F3 RID: 103411 RVA: 0x007FDB04 File Offset: 0x007FBF04
		private void _UpdateLayout_TLT_NAME(ComCommonBind ccb)
		{
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.sName_TLT_NAME != this.kData.name)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
				this.sName_TLT_NAME = this.kData.name;
			}
		}

		// Token: 0x060193F4 RID: 103412 RVA: 0x007FDB78 File Offset: 0x007FBF78
		private void _UpdateLayout_TLT_PKLV_NAME(ComCommonBind ccb)
		{
			bool flag = false;
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.sName_TLT_PKLV_NAME != this.kData.name)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
				this.sName_TLT_PKLV_NAME = this.kData.name;
				flag = true;
			}
			RectTransform com2 = ccb.GetCom<RectTransform>("PkGroup");
			if (com2 != null && com2.gameObject.activeInHierarchy != this.bShowPKLv)
			{
				com2.gameObject.SetActive(this.bShowPKLv);
			}
			Image com3 = ccb.GetCom<Image>("SeasonMainLevel");
			Image com4 = ccb.GetCom<Image>("SeasonSubLevel");
			if (com3 != null && com4 != null && this.iPkRank_TLT_PKLV_NAME != this.kData.pkRank && DataManager<SeasonDataManager>.GetInstance().IsLevelValid(this.kData.pkRank))
			{
				com3.gameObject.SetActive(true);
				ETCImageLoader.LoadSprite(ref com3, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon(this.kData.pkRank), true);
				ETCImageLoader.LoadSprite(ref com4, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon(this.kData.pkRank), true);
				com4.SetNativeSize();
				this.iPkRank_TLT_PKLV_NAME = this.kData.pkRank;
				flag = true;
			}
			if (flag)
			{
				com2.localPosition = (com3.preferredWidth * 0.5f + com.preferredWidth * 0.5f) * Vector3.left;
			}
		}

		// Token: 0x060193F5 RID: 103413 RVA: 0x007FDD20 File Offset: 0x007FC120
		private float _UpdateLayout_TLT_LV_NAME_TITLE(ComCommonBind ccb)
		{
			bool flag = false;
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.sName_TLT_TLT_LV_NAME_TITLE != this.kData.name)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
				this.sName_TLT_TLT_LV_NAME_TITLE = this.kData.name;
				flag = true;
			}
			Text com2 = ccb.GetCom<Text>("Lv");
			if (com2 != null && this.iLv_TLT_TLT_LV_NAME_TITLE != this.kData.iLv)
			{
				this._SetText(com2, string.Format("Lv.{0}", this.kData.iLv));
				com2.color = this.textColor;
				this.iTitleID_TLT_TLT_LV_NAME_TITLE = this.kData.iLv;
				flag = true;
			}
			TitleConvert com3 = ccb.GetCom<TitleConvert>("TitleConvert");
			if (com3 != null && this.iTitleID_TLT_TLT_LV_NAME_TITLE != this.kData.iTitleID)
			{
				com3.TitleID = this.kData.iTitleID;
				com3.Active(true);
				this.iTitleID_TLT_TLT_LV_NAME_TITLE = this.kData.iTitleID;
			}
			if (flag)
			{
				com2.rectTransform.localPosition = (com.preferredWidth * 0.5f + 5f) * Vector3.left;
				com.rectTransform.localPosition = (com2.preferredWidth * 0.5f + 5f) * Vector3.right;
			}
			return com3.GetAnimationTime(5f);
		}

		// Token: 0x060193F6 RID: 103414 RVA: 0x007FDEB8 File Offset: 0x007FC2B8
		private void _UpdateLayout_TLT_GANG(ComCommonBind ccb)
		{
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.sName_TLT_GANG != this.kData.name)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
				this.sName_TLT_GANG = this.kData.name;
			}
			Text com2 = ccb.GetCom<Text>("GangName");
			if (com2 != null && this.gangDuty_TLT_GANG != this.kData.gangDuty)
			{
				EGuildDuty clientDuty = DataManager<GuildDataManager>.GetInstance().GetClientDuty(this.kData.gangDuty);
				if (clientDuty == EGuildDuty.Invalid)
				{
					this._SetText(com2, string.Empty);
				}
				else
				{
					this._SetText(com2, this.kData.gangName + " " + TR.Value(clientDuty.GetDescription(true)));
				}
				this.gangDuty_TLT_GANG = this.kData.gangDuty;
			}
		}

		// Token: 0x060193F7 RID: 103415 RVA: 0x007FDFC0 File Offset: 0x007FC3C0
		private void _UpdateLayout_TLT_ADVENT(ComCommonBind ccb)
		{
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.sName_TLT_ADVENT != this.kData.name)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
				this.sName_TLT_ADVENT = this.kData.name;
			}
			Text com2 = ccb.GetCom<Text>("AdventTeamName");
			if (com2 != null && this.sAdventureName_TLT_ADVENT != this.kData.adventTeamName)
			{
				if (string.IsNullOrEmpty(this.kData.adventTeamName))
				{
					this._SetText(com2, string.Empty);
				}
				else
				{
					string content = string.Format(TR.Value("adventure_team_role_head_name"), this.kData.adventTeamName);
					this._SetText(com2, content);
				}
				this.sAdventureName_TLT_ADVENT = this.kData.adventTeamName;
			}
		}

		// Token: 0x060193F8 RID: 103416 RVA: 0x007FE0BC File Offset: 0x007FC4BC
		private void _UpdateLayout_TLT_ALL(ComCommonBind ccb)
		{
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.kData.name != null)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
			}
			TitleConvert com2 = ccb.GetCom<TitleConvert>("TitleConvert");
			if (com2 != null && this.iTitleID_TLT_LV_NAME_TITLE_VIP != this.kData.iTitleID)
			{
				com2.TitleID = this.kData.iTitleID;
				com2.Active(true);
			}
			GameObject gameObject = ccb.GetGameObject("GroupRoot");
			Text com3 = ccb.GetCom<Text>("GroupTitle");
			Image com4 = ccb.GetCom<Image>("HonorImage");
			Text com5 = ccb.GetCom<Text>("Title");
			Image com6 = ccb.GetCom<Image>("Title_Img");
			GameObject gameObject2 = ccb.GetGameObject("Title_Img_Parent");
			if (com5 != null)
			{
				com5.CustomActive(false);
			}
			if (gameObject != null)
			{
				gameObject.CustomActive(false);
			}
			if (gameObject2 != null)
			{
				gameObject2.CustomActive(false);
			}
			if (this.kData.playerWearedTitleInfo != null)
			{
				if (this.kData.playerWearedTitleInfo.style == 1)
				{
					string name = this.kData.playerWearedTitleInfo.name;
					if (com5 != null && name != null && name != string.Empty)
					{
						com5.CustomActive(true);
						this._SetText(com5, name);
					}
				}
				else if (this.kData.playerWearedTitleInfo.style == 2)
				{
					if (com6 != null)
					{
						gameObject2.CustomActive(true);
						NewTitleTable tableItem = Singleton<TableManager>.instance.GetTableItem<NewTitleTable>((int)this.kData.playerWearedTitleInfo.titleId, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ETCImageLoader.LoadSprite(ref com6, tableItem.path, true);
							com6.SetNativeSize();
						}
					}
				}
				else if (this.kData.playerWearedTitleInfo.style == 3)
				{
					string name2 = this.kData.playerWearedTitleInfo.name;
					if (com3 != null && name2 != null && name2 != string.Empty)
					{
						if (gameObject != null)
						{
							gameObject.CustomActive(true);
						}
						this._SetText(com3, name2);
						NewTitleTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<NewTitleTable>((int)this.kData.playerWearedTitleInfo.titleId, string.Empty, string.Empty);
						if (tableItem2 != null && com4 != null)
						{
							string path = tableItem2.path;
							if (path == string.Empty)
							{
								return;
							}
							ETCImageLoader.LoadSprite(ref com4, path, true);
							com4.SetNativeSize();
							RectTransform component = com4.GetComponent<RectTransform>();
							if (component != null)
							{
								component.sizeDelta = new Vector2(component.sizeDelta.x / 2f, component.sizeDelta.y / 2f);
							}
							com4.CustomActive(true);
						}
					}
				}
			}
		}

		// Token: 0x060193F9 RID: 103417 RVA: 0x007FE3EC File Offset: 0x007FC7EC
		private void _UpdateLayout_TLT_LV_NAME(ComCommonBind ccb)
		{
			bool flag = false;
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.sName_TLT_LV_NAME != this.kData.name)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
				this.sName_TLT_LV_NAME = this.kData.name;
				flag = true;
			}
			Text com2 = ccb.GetCom<Text>("Lv");
			if (com2 != null && this.iLv_TLT_LV_NAME != this.kData.iLv)
			{
				this._SetText(com2, string.Format("Lv.{0}", this.kData.iLv));
				com2.color = this.textColor;
				this.iLv_TLT_LV_NAME = this.kData.iLv;
				flag = true;
			}
			if (flag)
			{
				com2.rectTransform.localPosition = (com.preferredWidth * 0.5f + 5f) * Vector3.left;
				com.rectTransform.localPosition = (com2.preferredWidth * 0.5f + 5f) * Vector3.right;
			}
		}

		// Token: 0x060193FA RID: 103418 RVA: 0x007FE524 File Offset: 0x007FC924
		private float _UpdateLayout_TLT_LV_NAME_TITLE_VIP(ComCommonBind ccb)
		{
			bool flag = false;
			Text com = ccb.GetCom<Text>("Name");
			if (com != null && this.sName_TLT_LV_NAME_TITLE_VIP != this.kData.name)
			{
				this._SetText(com, this.kData.name);
				com.color = this.textColor;
				this.sName_TLT_LV_NAME_TITLE_VIP = this.kData.name;
				flag = true;
			}
			Text com2 = ccb.GetCom<Text>("Lv");
			if (com2 != null && this.iLv_TLT_LV_NAME_TITLE_VIP != this.kData.iLv)
			{
				this._SetText(com2, string.Format("Lv.{0}", this.kData.iLv));
				com2.color = this.textColor;
				this.iLv_TLT_LV_NAME_TITLE_VIP = this.kData.iLv;
				flag = true;
			}
			TitleConvert com3 = ccb.GetCom<TitleConvert>("TitleConvert");
			if (com3 != null && this.iTitleID_TLT_LV_NAME_TITLE_VIP != this.kData.iTitleID)
			{
				com3.TitleID = this.kData.iTitleID;
				com3.Active(true);
			}
			if (flag)
			{
				com2.rectTransform.localPosition = (com.preferredWidth * 0.5f + 5f) * Vector3.left;
				com.rectTransform.localPosition = (com2.preferredWidth * 0.5f + 5f) * Vector3.right;
			}
			return com3.GetAnimationTime(5f);
		}

		// Token: 0x060193FB RID: 103419 RVA: 0x007FE6AC File Offset: 0x007FCAAC
		public void SetTitleData(int iTitleID, int a_nPKRank, int iVipLevel, byte guildDuty, string gangName, int iLv, string name, string adventteamname, PlayerWearedTitleInfo playerWearedTitleInfo, int guildEmblemLv, Color nameColor)
		{
			this.PKRank = a_nPKRank;
			this.GangDuty = guildDuty;
			this.GangName = gangName;
			this.Level = iLv;
			this.Name = name;
			this.TitleID = iTitleID;
			this.VipLevel = iVipLevel;
			this.AdventTeamName = adventteamname;
			this.PlayerWearedTitleInfo = playerWearedTitleInfo;
			this.GuildEmblemLv = guildEmblemLv;
			this.SetPKEnable(true);
			this.textColor = nameColor;
		}

		// Token: 0x060193FC RID: 103420 RVA: 0x007FE718 File Offset: 0x007FCB18
		public void SetPKEnable(bool flag)
		{
			bool flag2 = this.Level >= Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel) && flag;
			this.bShowPKLv = flag2;
		}

		// Token: 0x060193FD RID: 103421 RVA: 0x007FE742 File Offset: 0x007FCB42
		private void _MarkDirty()
		{
			this.m_eShowType = this._GetTargetTittlePlayType();
			this._SetAllTitle();
		}

		// Token: 0x060193FE RID: 103422 RVA: 0x007FE758 File Offset: 0x007FCB58
		private void _UpdateTurn()
		{
			if (this.m_eShowType >= TitleComponent.TitleShowType.TST_NOGANG_NOTITTLE && this.m_eShowType < TitleComponent.TitleShowType.TST_COUNT && this.m_iIndex >= 0 && this.m_iIndex < TitleComponent.ms_akTurnList[(int)this.m_eShowType].Length)
			{
				int iStatus = (int)(TitleComponent.ms_akTurnList[(int)this.m_eShowType][this.m_iIndex] - 1);
				float num = this.SwitchStatus(iStatus);
				this.m_iIndex = (this.m_iIndex + 1) % TitleComponent.ms_akTurnList[(int)this.m_eShowType].Length;
				base.Invoke("_UpdateTurn", num);
			}
		}

		// Token: 0x060193FF RID: 103423 RVA: 0x007FE7EA File Offset: 0x007FCBEA
		private void _SetAllTitle()
		{
			this.SwitchStatus(7);
		}

		// Token: 0x06019400 RID: 103424 RVA: 0x007FE7F4 File Offset: 0x007FCBF4
		private TitleComponent.TitleShowType _GetTargetTittlePlayType()
		{
			bool flag = this.kData.iTitleID != 0;
			bool bHasGang = this.kData.bHasGang;
			bool flag2 = this.kData.iVipLevel > 0;
			bool flag3 = !string.IsNullOrEmpty(this.kData.adventTeamName);
			int num = 0;
			int num2 = 0;
			num |= ((!flag) ? 0 : 1) << num2;
			num2++;
			num |= ((!bHasGang) ? 0 : 1) << num2;
			num2++;
			num |= ((!flag2) ? 0 : 1) << num2;
			num2++;
			num |= ((!flag3) ? 0 : 1) << num2;
			num2++;
			return (TitleComponent.TitleShowType)num;
		}

		// Token: 0x06019401 RID: 103425 RVA: 0x007FE8C2 File Offset: 0x007FCCC2
		private void Start()
		{
			this.m_iIndex = 0;
			this._MarkDirty();
		}

		// Token: 0x06019402 RID: 103426 RVA: 0x007FE8D4 File Offset: 0x007FCCD4
		public static void OnChangedLv(int iPlayerID, int iLevel)
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerLvChanged((uint)iPlayerID, iLevel);
				}
				return;
			}
		}

		// Token: 0x06019403 RID: 103427 RVA: 0x007FE920 File Offset: 0x007FCD20
		public static void OnChangeGuildName(int iPlayerID, string name)
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerGuildNameChanged((uint)iPlayerID, name);
				}
			}
		}

		// Token: 0x06019404 RID: 103428 RVA: 0x007FE96C File Offset: 0x007FCD6C
		public static void OnChangeAdventTeamName(int iPlayerID, string name)
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerAdventTeamNameChanged((uint)iPlayerID, name);
				}
			}
		}

		// Token: 0x06019405 RID: 103429 RVA: 0x007FE9B8 File Offset: 0x007FCDB8
		public static void OnChangeTitleName(int iPlayerID, PlayerWearedTitleInfo playerWearedTitleInfo)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				if (clientSystemGameBattle != null)
				{
					clientSystemGameBattle.OnNotifyTownPlayerTitleNameChanged((uint)iPlayerID, playerWearedTitleInfo);
				}
				return;
			}
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerTitleNameChanged((uint)iPlayerID, playerWearedTitleInfo);
				}
			}
		}

		// Token: 0x06019406 RID: 103430 RVA: 0x007FEA28 File Offset: 0x007FCE28
		public static void OnChangeName(int iPlayerID, string name)
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerNameChanged((uint)iPlayerID, name);
				}
			}
		}

		// Token: 0x06019407 RID: 103431 RVA: 0x007FEA74 File Offset: 0x007FCE74
		public static void OnChangeGuileLv(int iPlayerID, uint guildEmblemLv)
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerGuildLvChanged((uint)iPlayerID, guildEmblemLv);
				}
			}
		}

		// Token: 0x06019408 RID: 103432 RVA: 0x007FEAC0 File Offset: 0x007FCEC0
		public static void OnChangeGuildDuty(int iPlayerID, byte duty)
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerGuildDutyChanged((uint)iPlayerID, duty);
				}
			}
		}

		// Token: 0x06019409 RID: 103433 RVA: 0x007FEB0C File Offset: 0x007FCF0C
		public static void OnChangedTittle(int iPlayerID, int iTittle)
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				}
				if (clientSystemTown != null)
				{
					clientSystemTown.OnNotifyTownPlayerTittleChanged((uint)iPlayerID, iTittle);
				}
			}
		}

		// Token: 0x0401219B RID: 74139
		private ComCommonBind[] layoutInsArray = new ComCommonBind[8];

		// Token: 0x0401219C RID: 74140
		private GameObject curLayoutIns;

		// Token: 0x0401219D RID: 74141
		private Canvas curLayoutCanvas;

		// Token: 0x0401219E RID: 74142
		private Color textColor;

		// Token: 0x0401219F RID: 74143
		private bool bShowPKLv;

		// Token: 0x040121A0 RID: 74144
		private TitleData kData = new TitleData();

		// Token: 0x040121A1 RID: 74145
		private int m_iPreStatus;

		// Token: 0x040121A2 RID: 74146
		private TitleComponent.TitleShowType m_eShowType;

		// Token: 0x040121A3 RID: 74147
		private int m_iIndex;

		// Token: 0x040121A4 RID: 74148
		private static byte[][] ms_akTurnList = new byte[][]
		{
			new byte[]
			{
				1,
				2,
				5
			},
			new byte[]
			{
				1,
				2,
				3
			},
			new byte[]
			{
				2,
				4,
				5
			},
			new byte[]
			{
				2,
				3,
				4
			},
			new byte[]
			{
				1,
				2,
				3
			},
			new byte[]
			{
				1,
				2,
				6
			},
			new byte[]
			{
				2,
				3,
				4
			},
			new byte[]
			{
				2,
				6,
				4
			},
			new byte[]
			{
				1,
				2,
				5,
				7
			},
			new byte[]
			{
				1,
				2,
				3,
				7
			},
			new byte[]
			{
				2,
				4,
				5,
				7
			},
			new byte[]
			{
				2,
				3,
				4,
				7
			},
			new byte[]
			{
				1,
				2,
				3,
				7
			},
			new byte[]
			{
				1,
				2,
				6,
				7
			},
			new byte[]
			{
				2,
				3,
				4,
				7
			},
			new byte[]
			{
				2,
				6,
				4,
				7
			}
		};

		// Token: 0x040121A5 RID: 74149
		private string sName_TLT_NAME = string.Empty;

		// Token: 0x040121A6 RID: 74150
		private string sName_TLT_PKLV_NAME = string.Empty;

		// Token: 0x040121A7 RID: 74151
		private int iPkRank_TLT_PKLV_NAME = -1;

		// Token: 0x040121A8 RID: 74152
		private string sName_TLT_TLT_LV_NAME_TITLE = string.Empty;

		// Token: 0x040121A9 RID: 74153
		private int iLv_TLT_TLT_LV_NAME_TITLE = -1;

		// Token: 0x040121AA RID: 74154
		private int iTitleID_TLT_TLT_LV_NAME_TITLE = -1;

		// Token: 0x040121AB RID: 74155
		private string sName_TLT_GANG = string.Empty;

		// Token: 0x040121AC RID: 74156
		private byte gangDuty_TLT_GANG = 100;

		// Token: 0x040121AD RID: 74157
		private string sName_TLT_ADVENT = string.Empty;

		// Token: 0x040121AE RID: 74158
		private string sAdventureName_TLT_ADVENT = string.Empty;

		// Token: 0x040121AF RID: 74159
		private string sName_TLT_LV_NAME = string.Empty;

		// Token: 0x040121B0 RID: 74160
		private int iLv_TLT_LV_NAME = -1;

		// Token: 0x040121B1 RID: 74161
		private string sName_TLT_LV_NAME_TITLE_VIP = string.Empty;

		// Token: 0x040121B2 RID: 74162
		private int iLv_TLT_LV_NAME_TITLE_VIP = -1;

		// Token: 0x040121B3 RID: 74163
		private int iTitleID_TLT_LV_NAME_TITLE_VIP = -1;

		// Token: 0x02004628 RID: 17960
		private enum TitleShowType
		{
			// Token: 0x040121B5 RID: 74165
			TST_NOGANG_NOTITTLE,
			// Token: 0x040121B6 RID: 74166
			TST_NOGANG_TITTLE,
			// Token: 0x040121B7 RID: 74167
			TST_GANG_NOTITTLE,
			// Token: 0x040121B8 RID: 74168
			TST_GANG_TITTLE,
			// Token: 0x040121B9 RID: 74169
			TST_VIP_NOGANG_NOTITTLE,
			// Token: 0x040121BA RID: 74170
			TST_VIP_NOGANG_TITTLE,
			// Token: 0x040121BB RID: 74171
			TST_VIP_GANG_NOTITTLE,
			// Token: 0x040121BC RID: 74172
			TST_VIP_GANG_TITTLE,
			// Token: 0x040121BD RID: 74173
			TST_ADVENTTEAM_NOVIP_NOGANG_NOTITLE,
			// Token: 0x040121BE RID: 74174
			TST_ADVENTTEAM_NOVIP_NOGANG_TITLE,
			// Token: 0x040121BF RID: 74175
			TST_ADVENTTEAM_NOVIP_GANG_NOTITLE,
			// Token: 0x040121C0 RID: 74176
			TST_ADVENTTEAM_NOVIP_GANG_TITLE,
			// Token: 0x040121C1 RID: 74177
			TST_ADVENTTEAM_VIP_NOGANG_NOTITLE,
			// Token: 0x040121C2 RID: 74178
			TST_ADVENTTEAM_VIP_NOGANG_TITLE,
			// Token: 0x040121C3 RID: 74179
			TST_ADVENTTEAM_VIP_GANG_NOTITLE,
			// Token: 0x040121C4 RID: 74180
			TST_ADVENTTEAM_VIP_GANG_TITLE,
			// Token: 0x040121C5 RID: 74181
			TST_COUNT,
			// Token: 0x040121C6 RID: 74182
			TST_TITTLE_STATUS = 5
		}

		// Token: 0x02004629 RID: 17961
		private enum TitleLayoutType
		{
			// Token: 0x040121C8 RID: 74184
			TLT_NAME,
			// Token: 0x040121C9 RID: 74185
			TLT_PKLV_NAME,
			// Token: 0x040121CA RID: 74186
			TLT_LV_NAME_TITLE,
			// Token: 0x040121CB RID: 74187
			TLT_GANG,
			// Token: 0x040121CC RID: 74188
			TLT_LV_NAME,
			// Token: 0x040121CD RID: 74189
			TLT_LV_NAME_TITLE_VIP,
			// Token: 0x040121CE RID: 74190
			TLT_ADVENT_LV_NAME_TITLE,
			// Token: 0x040121CF RID: 74191
			TLT_ALL,
			// Token: 0x040121D0 RID: 74192
			TLT_COUNT
		}
	}
}
