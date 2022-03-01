using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Network;
using Parser;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013F1 RID: 5105
	internal class ActorShowGroup : ClientFrame
	{
		// Token: 0x0600C5DA RID: 50650 RVA: 0x002FAFFC File Offset: 0x002F93FC
		protected override void _bindExUI()
		{
			this.mName = this.mBind.GetCom<Text>("playerName");
			this.mLevel = this.mBind.GetCom<Text>("level");
			this.mJob = this.mBind.GetCom<Text>("job");
			this.mGuildName = this.mBind.GetCom<Text>("guildName");
			this.mGuildJob = this.mBind.GetCom<Text>("guildJob");
			this.mPkLevel = this.mBind.GetCom<Text>("pkLevel");
			this.mPkPoint = this.mBind.GetCom<Text>("pkPoint");
			this.mPkCount = this.mBind.GetCom<Text>("pkCount");
			this.mPkWinRate = this.mBind.GetCom<Text>("pkWinRate");
			this.mNickName = this.mBind.GetCom<Text>("nickName");
			this.mVipGo = this.mBind.GetGameObject("VipGo");
			this.mVip = this.mBind.GetCom<UINumber>("vipNum");
			this.mSpecial = this.mBind.GetCom<Text>("special");
			this.mBtnAddFriend = this.mBind.GetGameObject("btnAddFriend");
			this.mBtnChat = this.mBind.GetGameObject("btnChat");
			this.mObjInfoRoot = this.mBind.GetGameObject("objInfoRoot");
			this.mBtnCheckInfo = this.mBind.GetCom<Button>("btnCheckInfo");
			this.mBtnCheckInfo.onClick.AddListener(new UnityAction(this._onBtnCheckInfoButtonClick));
			this.mBtnHideInfo = this.mBind.GetCom<Button>("btnHideInfo");
			this.mBtnHideInfo.onClick.AddListener(new UnityAction(this._onBtnHideInfoButtonClick));
			this.mPkLevelBg = this.mBind.GetCom<Image>("pkLevelBg");
			this.mPkLevelNum = this.mBind.GetCom<Image>("pkLevelNum");
			this.mPetRoot = this.mBind.GetGameObject("petRoot");
			this.mAdventureTeamName = this.mBind.GetCom<Text>("adventureTeamName");
			this.mAdventureTeamScore = this.mBind.GetCom<Text>("adventureTeamScore");
			this.mAdventureTeamRank = this.mBind.GetCom<Text>("adventureTeamRank");
			this.mObjInfoRoot.CustomActive(false);
			this.mBtnCheckInfo.gameObject.CustomActive(true);
			this.mBtnHideInfo.gameObject.CustomActive(false);
			this.fashionItemParent = this.mBind.GetGameObject("fashionItemParent");
			this.emblemName = this.mBind.GetCom<Image>("playerEmblemName");
		}

		// Token: 0x0600C5DB RID: 50651 RVA: 0x002FB2AC File Offset: 0x002F96AC
		protected override void _unbindExUI()
		{
			this.mName = null;
			this.mLevel = null;
			this.mJob = null;
			this.mGuildName = null;
			this.mGuildJob = null;
			this.mPkLevel = null;
			this.mPkPoint = null;
			this.mPkCount = null;
			this.mPkWinRate = null;
			this.mNickName = null;
			this.mVipGo = null;
			this.mVip = null;
			this.mSpecial = null;
			this.mBtnAddFriend = null;
			this.mBtnChat = null;
			this.mBtnCheckInfo.onClick.RemoveListener(new UnityAction(this._onBtnCheckInfoButtonClick));
			this.mBtnCheckInfo = null;
			this.mBtnHideInfo.onClick.RemoveListener(new UnityAction(this._onBtnHideInfoButtonClick));
			this.mBtnHideInfo = null;
			this.mPkLevelBg = null;
			this.mPkLevelNum = null;
			this.mAdventureTeamName = null;
			this.mAdventureTeamScore = null;
			this.mAdventureTeamRank = null;
			this.fashionItemParent = null;
			this.emblemName = null;
		}

		// Token: 0x0600C5DC RID: 50652 RVA: 0x002FB399 File Offset: 0x002F9799
		private void _onBtnCheckInfoButtonClick()
		{
			this.ShowInfo(true);
			this.mBtnHideInfo.gameObject.CustomActive(true);
			this.mBtnCheckInfo.gameObject.CustomActive(false);
		}

		// Token: 0x0600C5DD RID: 50653 RVA: 0x002FB3C4 File Offset: 0x002F97C4
		private void _onBtnHideInfoButtonClick()
		{
			this.ShowInfo(false);
			this.mBtnHideInfo.gameObject.CustomActive(false);
			this.mBtnCheckInfo.gameObject.CustomActive(true);
		}

		// Token: 0x0600C5DE RID: 50654 RVA: 0x002FB3EF File Offset: 0x002F97EF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CheckInfo/ActorShowGroup";
		}

		// Token: 0x0600C5DF RID: 50655 RVA: 0x002FB3F6 File Offset: 0x002F97F6
		private void ShowInfo(bool show = true)
		{
			if (this.mObjInfoRoot.activeSelf == show)
			{
				return;
			}
			this.mObjInfoRoot.CustomActive(show);
			this.SetInfo(this.mObjInfoRoot);
		}

		// Token: 0x0600C5E0 RID: 50656 RVA: 0x002FB424 File Offset: 0x002F9824
		private float GetValue(DisplayAttribute attribute, string childName)
		{
			FieldInfo field = attribute.GetType().GetField(childName);
			float result = 0f;
			if (field != null)
			{
				result = (float)field.GetValue(attribute);
			}
			return result;
		}

		// Token: 0x0600C5E1 RID: 50657 RVA: 0x002FB458 File Offset: 0x002F9858
		private void _onReceiveOtherPlayerInfo(WorldQueryPlayerDetailsRet res)
		{
			DisplayAttribute playerActorAttributeByRaceInfo = BeUtility.GetPlayerActorAttributeByRaceInfo(res.info);
			this.SetAttributeInfo(playerActorAttributeByRaceInfo, BeUtility.GetMainPlayerActorAttribute(false, false), this.mObjInfoRoot);
			this.infoGeted = true;
		}

		// Token: 0x0600C5E2 RID: 50658 RVA: 0x002FB48C File Offset: 0x002F988C
		private IEnumerator _requestOtherPlayerInfo()
		{
			MessageEvents msg = new MessageEvents();
			WorldQueryPlayerDetailsReq req = new WorldQueryPlayerDetailsReq();
			WorldQueryPlayerDetailsRet res = new WorldQueryPlayerDetailsRet();
			req.roleId = this.m_kData.m_guid;
			req.zoneId = this.m_kData.m_zoneId;
			req.queryType = this.m_kData.m_queryPlayerType;
			req.name = string.Empty;
			yield return MessageUtility.WaitWithResend<WorldQueryPlayerDetailsReq, WorldQueryPlayerDetailsRet>(ServerType.GATE_SERVER, msg, req, res, true, 10f, null);
			if (msg.IsAllMessageReceived())
			{
				this._onReceiveOtherPlayerInfo(res);
			}
			yield break;
		}

		// Token: 0x0600C5E3 RID: 50659 RVA: 0x002FB4A8 File Offset: 0x002F98A8
		private void SetAttributeInfo(DisplayAttribute otherAttr, DisplayAttribute myattr, GameObject root)
		{
			if (otherAttr != null && myattr != null && root != null)
			{
				ComCommonBind component = root.GetComponent<ComCommonBind>();
				if (component != null)
				{
					GameObject gameObject = component.GetGameObject("objOtherLeft");
					GameObject gameObject2 = component.GetGameObject("objOtherRight");
					GameObject gameObject3 = component.GetGameObject("objMyLeft");
					GameObject gameObject4 = component.GetGameObject("objMyRight");
					otherAttr.attachValue.Clear();
					myattr.attachValue.Clear();
					for (int i = 0; i < 51; i++)
					{
						AttributeType attributeType = (AttributeType)i;
						if (attributeType != AttributeType.abnormalResist)
						{
							string name = Enum.GetName(typeof(AttributeType), (AttributeType)i);
							float value = this.GetValue(otherAttr, name);
							float value2 = this.GetValue(myattr, name);
							if (value > value2)
							{
								myattr.attachValue.Add(name, -1);
							}
							else if (value < value2)
							{
								myattr.attachValue.Add(name, 1);
							}
						}
					}
					Utility.SetPersonalInfo(otherAttr, gameObject, gameObject2);
					Utility.SetPersonalInfo(myattr, gameObject3, gameObject4);
				}
			}
		}

		// Token: 0x0600C5E4 RID: 50660 RVA: 0x002FB5C2 File Offset: 0x002F99C2
		private void SetInfo(GameObject root)
		{
			if (!this.infoGeted)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._requestOtherPlayerInfo());
			}
		}

		// Token: 0x0600C5E5 RID: 50661 RVA: 0x002FB5E0 File Offset: 0x002F99E0
		private void _InitActorModel()
		{
			Text text = this.mName;
			string kName = this.m_kData.m_kName;
			this.mNickName.text = kName;
			text.text = kName;
			this._SetText(this.mName, this.m_kData.m_kName);
			RelationData relationData = null;
			DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(this.m_kData.m_guid, ref relationData);
			if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
			{
				this.mName.text = relationData.remark;
				this._SetText(this.mName, relationData.remark);
			}
			this.mLevel.text = this.m_kData.m_iLevel.ToString();
			if (this.m_kData.HasGuild())
			{
				this.mGuildName.text = this.m_kData.guildName;
				this.mGuildJob.text = Utility.GetGuildPositionName(this.m_kData.guildJob);
			}
			else
			{
				this.mGuildName.text = "-";
				this.mGuildJob.text = "-";
			}
			this.mPkLevel.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)this.m_kData.pkValue, true);
			this.mPkPoint.text = this.m_kData.matchScore.ToString();
			this.mPkCount.text = this.m_kData.m_pkInfo.totalNum.ToString();
			if (this.m_kData.m_pkInfo.totalNum > 0U)
			{
				this.mPkWinRate.text = string.Format("{0:P1}", this.m_kData.m_pkInfo.totalWinNum / this.m_kData.m_pkInfo.totalNum);
			}
			else
			{
				this.mPkWinRate.text = "0";
			}
			if (this.m_kData.HasVip())
			{
				this.mVipGo.CustomActive(true);
				this.mVip.Value = this.m_kData.vip;
			}
			else
			{
				this.mVipGo.CustomActive(false);
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.m_kData.m_iJob, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mJob.text = tableItem.Name;
			}
			if (tableItem == null)
			{
				Logger.LogError("职业ID找不到 " + this.m_kData.m_iJob + "\n");
			}
			else if (Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty) == null)
			{
				Logger.LogError("模型资源表 找不到 " + tableItem.Mode + "\n");
			}
			else
			{
				Utility.CreateActor(this.m_AvatarRenderer, tableItem.ID, 0, 530, 764, false);
				this._ShowFashion();
				this.m_AvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
				this.m_AvatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
			}
			if (this.otherMeText)
			{
				this.otherMeText.text = this.mName.text;
			}
			if (this.otherLvText)
			{
				this.otherLvText.text = "Lv." + this.mLevel.text;
			}
			if (this.otherJobText)
			{
				this.otherJobText.text = this.mJob.text;
			}
			if (this.selfLvText)
			{
				this.selfLvText.text = "Lv." + DataManager<PlayerBaseData>.GetInstance().Level.ToString();
			}
			if (this.selfMeText)
			{
				this.selfMeText.text = "我";
			}
			if (this.selfJobText)
			{
				JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
				this.selfJobText.text = tableItem2.Name;
			}
			if (this.selfEquipScoreText != null)
			{
				this.selfEquipScoreText.text = DataManager<PlayerBaseData>.GetInstance().TotalEquipScore.ToString();
			}
			if (this.otherEquipScoreText != null)
			{
				this.otherEquipScoreText.text = this.m_kData.totalEquipScore.ToString();
			}
			if (this.mPkLevelBg)
			{
				ETCImageLoader.LoadSprite(ref this.mPkLevelBg, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon((int)this.m_kData.pkValue), true);
			}
			if (this.mPkLevelNum)
			{
				ETCImageLoader.LoadSprite(ref this.mPkLevelNum, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon((int)this.m_kData.pkValue), true);
				string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)this.m_kData.pkValue, true);
				if (string.Compare(rankName, "最强王者") != 0)
				{
					this.mPkLevelNum.rectTransform.localScale = Vector3.one / 2f;
				}
			}
			if (this.m_kData.HasAdventureTeam())
			{
				if (this.mAdventureTeamName)
				{
					this.mAdventureTeamName.text = AdventureTeamDataManager.ChangeColorByGrade(this.m_kData.adventureTeamName, this.m_kData.adventureTeamGrade);
				}
				if (this.mAdventureTeamScore)
				{
					bool flag = string.IsNullOrEmpty(this.m_kData.adventureTeamGrade);
					this.mAdventureTeamScore.CustomActive(!flag);
					if (!flag)
					{
						string text2 = AdventureTeamDataManager.ChangeColorByGrade(this.m_kData.adventureTeamGrade, this.m_kData.adventureTeamGrade);
						this.mAdventureTeamScore.text = text2;
					}
				}
				if (this.mAdventureTeamRank)
				{
					bool flag2 = this.m_kData.adventureTeamRank == 0U;
					this.mAdventureTeamRank.CustomActive(!flag2);
					if (!flag2)
					{
						string arg = this.m_kData.adventureTeamRank.ToString();
						this.mAdventureTeamRank.text = string.Format(TR.Value("adventure_team_actor_show_rank"), arg);
					}
				}
			}
			else
			{
				if (this.mAdventureTeamName)
				{
					this.mAdventureTeamName.text = "-";
				}
				if (this.mAdventureTeamScore)
				{
					this.mAdventureTeamScore.text = string.Empty;
				}
				if (this.mAdventureTeamRank)
				{
					this.mAdventureTeamRank.text = string.Empty;
				}
			}
		}

		// Token: 0x0600C5E6 RID: 50662 RVA: 0x002FBCD8 File Offset: 0x002FA0D8
		private void _SetText(Text text, string content)
		{
			if (text == null || content == null)
			{
				return;
			}
			text.font.RequestCharactersInTexture(content, text.fontSize, text.fontStyle);
			float num = 1f;
			for (int i = 0; i < content.Length; i++)
			{
				CharacterInfo characterInfo;
				text.font.GetCharacterInfo(content[i], ref characterInfo, text.fontSize);
				num += (float)characterInfo.advance;
			}
			text.rectTransform.sizeDelta = new Vector2(num, text.rectTransform.sizeDelta.y);
			text.text = content;
		}

		// Token: 0x0600C5E7 RID: 50663 RVA: 0x002FBD80 File Offset: 0x002FA180
		private void _ShowFashion()
		{
			if (this.m_kData.avatar != null)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(this.m_AvatarRenderer, this.m_kData.avatar.equipItemIds, this.m_kData.m_iJob, (int)this.m_kData.avatar.weaponStrengthen, null, false, this.m_kData.avatar.isShoWeapon, false);
			}
		}

		// Token: 0x0600C5E8 RID: 50664 RVA: 0x002FBDEB File Offset: 0x002FA1EB
		private void _InitEquipments()
		{
			if (!this.m_bEquipInited)
			{
				this.m_akCachedEquiptItemObjects.Clear();
				this._InitEquiptSlots();
				this._InitEquipts();
				this.m_bEquipInited = true;
			}
		}

		// Token: 0x0600C5E9 RID: 50665 RVA: 0x002FBE18 File Offset: 0x002FA218
		private void _InitEquiptSlots()
		{
			this.m_goLeft = Utility.FindChild(this.frame, "ActorShowEquip/Equips/Left");
			this.m_goRight = Utility.FindChild(this.frame, "ActorShowEquip/Equips/Right");
			this.m_goMiddle = Utility.FindChild(this.frame, "ActorShowEquip/Equips/Middle");
			List<ComItem> list = new List<ComItem>();
			int num = 98;
			int num2 = 10;
			for (int i = 0; i < num; i++)
			{
				if (i < num2)
				{
					ComItem item = base.CreateComItem((i >= num2 / 2) ? this.m_goRight : this.m_goLeft);
					list.Add(item);
				}
				else
				{
					list.Add(null);
				}
			}
			for (int j = num; j < 101; j++)
			{
				ComItem item2 = base.CreateComItem(this.m_goMiddle);
				list.Add(item2);
			}
			for (int k = 1; k < 102; k++)
			{
				MapIndex enumAttribute = Utility.GetEnumAttribute<EEquipWearSlotType, MapIndex>((EEquipWearSlotType)k);
				if (enumAttribute != null && enumAttribute.Index >= 0 && enumAttribute.Index < list.Count)
				{
					ComItem comItem = list[enumAttribute.Index];
					if (!(comItem == null))
					{
						GameObject gameObject = comItem.transform.parent.gameObject;
						GameObject gameObject2 = comItem.transform.gameObject;
						EEquipWearSlotType eequipWearSlotType = (EEquipWearSlotType)k;
						CachedObjectDicManager<EEquipWearSlotType, ActorShowGroup.EquipItemObject> akCachedEquiptItemObjects = this.m_akCachedEquiptItemObjects;
						EEquipWearSlotType key = (EEquipWearSlotType)k;
						object[] array = new object[5];
						array[0] = gameObject;
						array[1] = gameObject2;
						array[2] = eequipWearSlotType;
						array[3] = this;
						akCachedEquiptItemObjects.Create(key, array);
					}
				}
			}
		}

		// Token: 0x0600C5EA RID: 50666 RVA: 0x002FBFA8 File Offset: 0x002FA3A8
		private void _InitEquipts()
		{
			if (this.m_kData.m_akEquipts != null)
			{
				for (int i = 0; i < this.m_kData.m_akEquipts.Count; i++)
				{
					ItemData itemData = this.m_kData.m_akEquipts[i];
					if (itemData != null && this.m_akCachedEquiptItemObjects.HasObject(itemData.EquipWearSlotType))
					{
						this.m_akCachedEquiptItemObjects.RefreshObject(itemData.EquipWearSlotType, new object[]
						{
							itemData
						});
					}
				}
			}
		}

		// Token: 0x0600C5EB RID: 50667 RVA: 0x002FC030 File Offset: 0x002FA430
		private void ShowPetsInfo()
		{
			if (this.IsInitPetShow)
			{
				return;
			}
			this.IsInitPetShow = true;
			for (int i = 0; i < this.m_kData.pets.Length; i++)
			{
				ActorShowEquipData.PetData petData = this.m_kData.pets[i];
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.strPetItem, false, 0U);
				if (gameObject != null)
				{
					Utility.AttachTo(gameObject, this.mPetRoot, false);
				}
				if (petData.dataID > 0)
				{
					PetInfo petInfo = new PetInfo();
					petInfo.dataId = (uint)petData.dataID;
					petInfo.level = (ushort)petData.level;
					petInfo.hunger = (ushort)petData.hunger;
					petInfo.skillIndex = (byte)petData.skillIndex;
					petInfo.petScore = (uint)petData.petScore;
					DataManager<PetDataManager>.GetInstance().SetPetItemData(gameObject, petInfo, this.m_kData.m_iJob, PetTipsType.None, false);
				}
			}
		}

		// Token: 0x0600C5EC RID: 50668 RVA: 0x002FC121 File Offset: 0x002FA521
		private void _InitAllFashions()
		{
			if (!this.m_bFashionInited)
			{
				this.m_akCachedEquiptFashionObjects.Clear();
				this._InitFashionSlots();
				this._InitFashions();
				this.m_bFashionInited = true;
			}
		}

		// Token: 0x0600C5ED RID: 50669 RVA: 0x002FC14C File Offset: 0x002FA54C
		private void _InitFashionSlots()
		{
			this.m_goFashionLeft = Utility.FindChild(this.frame, "ActorShowFashion/Fashions/Left");
			this.m_goFashionRight = Utility.FindChild(this.frame, "ActorShowFashion/Fashions/Right");
			List<ComItem> list = new List<ComItem>();
			if (this.fashionItemParent != null)
			{
				for (int i = 1; i < 9; i++)
				{
					ComItem item = base.CreateComItem(this.fashionItemParent);
					list.Add(item);
				}
			}
			for (int j = 1; j < 9; j++)
			{
				MapIndex enumAttribute = Utility.GetEnumAttribute<EFashionWearNewSlotType, MapIndex>((EFashionWearNewSlotType)j);
				if (enumAttribute.Index >= 0 && enumAttribute.Index < list.Count)
				{
					ComItem comItem = list[enumAttribute.Index];
					GameObject gameObject = comItem.transform.parent.gameObject;
					GameObject gameObject2 = comItem.transform.gameObject;
					EFashionWearNewSlotType fashionWearNewSlotType = (EFashionWearNewSlotType)j;
					EFashionWearSlotType fashionWearSlotTypeByItemFashionWearNewSlotType = DataManager<PackageDataManager>.GetInstance().GetFashionWearSlotTypeByItemFashionWearNewSlotType(fashionWearNewSlotType);
					CachedObjectDicManager<EFashionWearSlotType, ActorShowGroup.FashionItemObject> akCachedEquiptFashionObjects = this.m_akCachedEquiptFashionObjects;
					EFashionWearSlotType key = fashionWearSlotTypeByItemFashionWearNewSlotType;
					object[] array = new object[5];
					array[0] = gameObject;
					array[1] = gameObject2;
					array[2] = fashionWearSlotTypeByItemFashionWearNewSlotType;
					array[3] = this;
					akCachedEquiptFashionObjects.Create(key, array);
				}
			}
		}

		// Token: 0x0600C5EE RID: 50670 RVA: 0x002FC26C File Offset: 0x002FA66C
		private void _InitFashions()
		{
			if (this.m_kData.m_akFashions != null)
			{
				for (int i = 0; i < this.m_kData.m_akFashions.Count; i++)
				{
					ItemData itemData = this.m_kData.m_akFashions[i];
					if (itemData != null && this.m_akCachedEquiptFashionObjects.HasObject(itemData.FashionWearSlotType))
					{
						this.m_akCachedEquiptFashionObjects.RefreshObject(itemData.FashionWearSlotType, new object[]
						{
							itemData
						});
					}
				}
			}
		}

		// Token: 0x0600C5EF RID: 50671 RVA: 0x002FC2F4 File Offset: 0x002FA6F4
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as ActorShowEquipData);
			if (this.m_kData != null)
			{
				ActorShowGroup.m_queryPlayerType = this.m_kData.m_queryPlayerType;
				ActorShowGroup.m_zoneId = this.m_kData.m_zoneId;
			}
			else
			{
				ActorShowGroup.m_queryPlayerType = 0U;
				ActorShowGroup.m_zoneId = 0U;
			}
			this.m_bEquipInited = false;
			this.m_bFashionInited = false;
			this.m_goActorModel = Utility.FindChild(this.frame, "ActorShowModel");
			this.m_goModel = Utility.FindChild(this.m_goActorModel, "Model");
			this.m_goActorShowEquip = Utility.FindChild(this.frame, "ActorShowEquip");
			this.m_goActorShowFashion = Utility.FindChild(this.frame, "ActorShowFashion");
			this.m_bMarked = false;
			this.m_eTabType = ActorShowGroup.TabType.TT_COUNT;
			this._InitTabs();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRefreshFriendList, new ClientEventSystem.UIEventHandler(this._OnRereshFriend));
		}

		// Token: 0x0600C5F0 RID: 50672 RVA: 0x002FC3E4 File Offset: 0x002FA7E4
		protected override void _OnCloseFrame()
		{
			this.IsInitPetShow = false;
			this.m_akCachedEquiptFashionObjects.Clear();
			this.m_akCachedEquiptItemObjects.Clear();
			this.m_akTabObjects.Clear();
			this.m_akTabObjects.DestroyAllObjects();
			this.infoGeted = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRefreshFriendList, new ClientEventSystem.UIEventHandler(this._OnRereshFriend));
			ActorShowGroup.m_queryPlayerType = 0U;
			ActorShowGroup.m_zoneId = 0U;
		}

		// Token: 0x0600C5F1 RID: 50673 RVA: 0x002FC452 File Offset: 0x002FA852
		private void _OnRereshFriend(UIEvent uiEvent)
		{
			this.OnSetFilter(this.m_eTabType);
		}

		// Token: 0x0600C5F2 RID: 50674 RVA: 0x002FC460 File Offset: 0x002FA860
		private void _InitTabs()
		{
			this.m_akTabObjects.Clear();
			this.OnSetFilter(ActorShowGroup.TabType.TT_ACTOR);
		}

		// Token: 0x0600C5F3 RID: 50675 RVA: 0x002FC474 File Offset: 0x002FA874
		[UIEventHandle("close")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<ActorShowGroup>(this, false);
		}

		// Token: 0x0600C5F4 RID: 50676 RVA: 0x002FC483 File Offset: 0x002FA883
		[UIEventHandle("buttonRoot/BtnAddFriend")]
		private void OnAddFriend()
		{
			DataManager<RelationDataManager>.GetInstance().AddFriendByID(this.m_kData.m_guid);
			this.m_bMarked = true;
		}

		// Token: 0x0600C5F5 RID: 50677 RVA: 0x002FC4A4 File Offset: 0x002FA8A4
		[UIEventHandle("buttonRoot/BtnChat")]
		private void OnChat()
		{
			if (this.m_kData.m_guid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("can_not_talk_to_yourself"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (ChatUtility.IsForbidPrivateChat())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("chat_private_forbid_in_scene"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_friend_chat_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChatFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChatFrame>(null, false);
			}
			if (this.bIsMyFriend)
			{
				RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.m_kData.m_guid);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RelationFrameNew>(null))
				{
					DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(relationByRoleID, false);
					RelationFrameData relationFrameData = new RelationFrameData();
					relationFrameData.eCurrentRelationData = relationByRoleID;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPStartTalk, relationFrameData, null, null, null);
				}
				else
				{
					DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(relationByRoleID);
				}
				this.OnClickClose();
			}
			else
			{
				RelationData relationData = new RelationData();
				relationData.level = (ushort)this.m_kData.m_iLevel;
				relationData.uid = this.m_kData.m_guid;
				relationData.name = this.m_kData.m_kName;
				relationData.occu = (byte)this.m_kData.m_iJob;
				relationData.vipLv = (byte)this.m_kData.vip;
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RelationFrameNew>(null))
				{
					DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(relationData, false);
					RelationFrameData relationFrameData2 = new RelationFrameData();
					relationFrameData2.eCurrentRelationData = relationData;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPStartTalk, relationFrameData2, null, null, null);
				}
				else
				{
					DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(relationData);
				}
				this.OnClickClose();
			}
		}

		// Token: 0x0600C5F6 RID: 50678 RVA: 0x002FC690 File Offset: 0x002FAA90
		[UIEventHandle("buttonRoot/BtnReport")]
		private void OnReport()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(82, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_report_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_kData.m_guid != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				InformantInfo informantInfo = new InformantInfo();
				informantInfo.roleId = this.m_kData.m_guid.ToString();
				informantInfo.roleName = this.m_kData.m_kName;
				informantInfo.roleLevel = this.m_kData.m_iLevel.ToString();
				informantInfo.vipLevel = this.m_kData.vip.ToString();
				informantInfo.jobId = this.m_kData.m_iJob.ToString();
				informantInfo.jobName = DataManager<BaseWebViewManager>.GetInstance().GetJobNameByJobId(this.m_kData.m_iJob);
				DataManager<BaseWebViewManager>.GetInstance().TryOpenReportFrame(informantInfo);
			}
			else
			{
				SystemNotifyManager.SystemNotify(9937, string.Empty);
			}
			base.Close(false);
		}

		// Token: 0x0600C5F7 RID: 50679 RVA: 0x002FC7D0 File Offset: 0x002FABD0
		public void ShowButton(bool isFriend)
		{
			UIGray uigray = this.mBtnAddFriend.SafeAddComponent(true);
			if (uigray != null)
			{
				uigray.SetEnable(false);
			}
			Button component = this.mBtnAddFriend.GetComponent<Button>();
			if (component != null)
			{
				component.interactable = true;
			}
			if (isFriend)
			{
				this.mBtnAddFriend.CustomActive(false);
				this.mBtnChat.CustomActive(true);
			}
			else
			{
				this.mBtnAddFriend.CustomActive(true);
				this.mBtnChat.CustomActive(true);
				if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
				{
					if (uigray != null)
					{
						uigray.SetEnable(true);
					}
					if (component != null)
					{
						component.interactable = false;
					}
				}
			}
		}

		// Token: 0x0600C5F8 RID: 50680 RVA: 0x002FC890 File Offset: 0x002FAC90
		private void OnSetFilter(ActorShowGroup.TabType eTabType)
		{
			ActorShowGroup.TabType eTabType2 = this.m_eTabType;
			this.m_eTabType = eTabType;
			if (this.m_eTabType == ActorShowGroup.TabType.TT_ACTOR)
			{
				if (eTabType2 == ActorShowGroup.TabType.TT_COUNT)
				{
					this._InitActorModel();
				}
				this.m_goModel.CustomActive(true);
				this.m_goActorModel.CustomActive(true);
				this.m_goActorShowEquip.CustomActive(true);
				this.m_goActorShowFashion.CustomActive(true);
				this._InitEquipments();
				this.bIsMyFriend = false;
				RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.m_kData.m_guid);
				if (relationByRoleID != null && relationByRoleID.type == 1)
				{
					this.bIsMyFriend = true;
				}
				this.ShowButton(this.bIsMyFriend);
				this._InitAllFashions();
				this.ShowPetsInfo();
				this.btnReport.CustomActive(DataManager<BaseWebViewManager>.GetInstance().IsReportFuncOpen());
			}
			else if (this.m_eTabType == ActorShowGroup.TabType.TT_FASHION)
			{
			}
		}

		// Token: 0x04007129 RID: 28969
		public ActorShowEquipData m_kData;

		// Token: 0x0400712A RID: 28970
		public static uint m_queryPlayerType;

		// Token: 0x0400712B RID: 28971
		public static uint m_zoneId;

		// Token: 0x0400712C RID: 28972
		private bool IsInitPetShow;

		// Token: 0x0400712D RID: 28973
		private Text mName;

		// Token: 0x0400712E RID: 28974
		private Text mLevel;

		// Token: 0x0400712F RID: 28975
		private Text mJob;

		// Token: 0x04007130 RID: 28976
		private Text mGuildName;

		// Token: 0x04007131 RID: 28977
		private Text mGuildJob;

		// Token: 0x04007132 RID: 28978
		private Text mPkLevel;

		// Token: 0x04007133 RID: 28979
		private Text mPkPoint;

		// Token: 0x04007134 RID: 28980
		private Text mPkCount;

		// Token: 0x04007135 RID: 28981
		private Text mPkWinRate;

		// Token: 0x04007136 RID: 28982
		private Text mNickName;

		// Token: 0x04007137 RID: 28983
		private UINumber mVip;

		// Token: 0x04007138 RID: 28984
		private GameObject mVipGo;

		// Token: 0x04007139 RID: 28985
		private Text mSpecial;

		// Token: 0x0400713A RID: 28986
		private GameObject mBtnAddFriend;

		// Token: 0x0400713B RID: 28987
		private GameObject mBtnChat;

		// Token: 0x0400713C RID: 28988
		private GameObject mObjInfoRoot;

		// Token: 0x0400713D RID: 28989
		private Button mBtnHideInfo;

		// Token: 0x0400713E RID: 28990
		private Button mBtnCheckInfo;

		// Token: 0x0400713F RID: 28991
		private Image mPkLevelBg;

		// Token: 0x04007140 RID: 28992
		private Image mPkLevelNum;

		// Token: 0x04007141 RID: 28993
		private GameObject mPetRoot;

		// Token: 0x04007142 RID: 28994
		private Text mAdventureTeamName;

		// Token: 0x04007143 RID: 28995
		private Text mAdventureTeamScore;

		// Token: 0x04007144 RID: 28996
		private Text mAdventureTeamRank;

		// Token: 0x04007145 RID: 28997
		private GameObject fashionItemParent;

		// Token: 0x04007146 RID: 28998
		private Image emblemName;

		// Token: 0x04007147 RID: 28999
		[UIControl("ActorShowModel/Model/ModelRenderTexture", typeof(GeAvatarRendererEx), 0)]
		private GeAvatarRendererEx m_AvatarRenderer;

		// Token: 0x04007148 RID: 29000
		private bool infoGeted;

		// Token: 0x04007149 RID: 29001
		private bool m_bEquipInited;

		// Token: 0x0400714A RID: 29002
		private GameObject m_goLeft;

		// Token: 0x0400714B RID: 29003
		private GameObject m_goRight;

		// Token: 0x0400714C RID: 29004
		private GameObject m_goMiddle;

		// Token: 0x0400714D RID: 29005
		private CachedObjectDicManager<EEquipWearSlotType, ActorShowGroup.EquipItemObject> m_akCachedEquiptItemObjects = new CachedObjectDicManager<EEquipWearSlotType, ActorShowGroup.EquipItemObject>();

		// Token: 0x0400714E RID: 29006
		private string strPetItem = "UIFlatten/Prefabs/Pet/PetItem";

		// Token: 0x0400714F RID: 29007
		private GameObject m_goFashionLeft;

		// Token: 0x04007150 RID: 29008
		private GameObject m_goFashionRight;

		// Token: 0x04007151 RID: 29009
		private bool m_bFashionInited;

		// Token: 0x04007152 RID: 29010
		private CachedObjectDicManager<EFashionWearSlotType, ActorShowGroup.FashionItemObject> m_akCachedEquiptFashionObjects = new CachedObjectDicManager<EFashionWearSlotType, ActorShowGroup.FashionItemObject>();

		// Token: 0x04007153 RID: 29011
		private GameObject m_goActorModel;

		// Token: 0x04007154 RID: 29012
		private GameObject m_goNameInfo;

		// Token: 0x04007155 RID: 29013
		private GameObject m_goJobInfo;

		// Token: 0x04007156 RID: 29014
		private GameObject m_goModel;

		// Token: 0x04007157 RID: 29015
		private GameObject m_goActorShowEquip;

		// Token: 0x04007158 RID: 29016
		private GameObject m_goActorShowFashion;

		// Token: 0x04007159 RID: 29017
		private GameObject m_goActorShowFollowPet;

		// Token: 0x0400715A RID: 29018
		private Text m_kHasPetHint;

		// Token: 0x0400715B RID: 29019
		private GameObject m_goPkInfo;

		// Token: 0x0400715C RID: 29020
		private bool m_bMarked;

		// Token: 0x0400715D RID: 29021
		private bool bIsMyFriend;

		// Token: 0x0400715E RID: 29022
		private GameObject m_goTabParent;

		// Token: 0x0400715F RID: 29023
		private GameObject m_goTabPrefab;

		// Token: 0x04007160 RID: 29024
		private Toggle[] m_akToggle = new Toggle[2];

		// Token: 0x04007161 RID: 29025
		private ActorShowGroup.TabType m_eTabType;

		// Token: 0x04007162 RID: 29026
		private CachedObjectDicManager<ActorShowGroup.TabType, ActorShowGroup.TabObject> m_akTabObjects = new CachedObjectDicManager<ActorShowGroup.TabType, ActorShowGroup.TabObject>();

		// Token: 0x04007163 RID: 29027
		[UIControl("infoRoot/leftTitle/NameLayout/LV", typeof(Text), 0)]
		private Text selfLvText;

		// Token: 0x04007164 RID: 29028
		[UIControl("infoRoot/leftTitle/NameLayout/me", typeof(Text), 0)]
		private Text selfMeText;

		// Token: 0x04007165 RID: 29029
		[UIControl("infoRoot/leftTitle/NameLayout/jobName", typeof(Text), 0)]
		private Text selfJobText;

		// Token: 0x04007166 RID: 29030
		[UIControl("infoRoot/PersonalInformationMe/Left/equipScore/Value", null, 0)]
		private Text selfEquipScoreText;

		// Token: 0x04007167 RID: 29031
		[UIControl("infoRoot/RightTitle/NameLayout/LV", typeof(Text), 0)]
		private Text otherLvText;

		// Token: 0x04007168 RID: 29032
		[UIControl("infoRoot/RightTitle/NameLayout/me", typeof(Text), 0)]
		private Text otherMeText;

		// Token: 0x04007169 RID: 29033
		[UIControl("infoRoot/RightTitle/NameLayout/jobName", typeof(Text), 0)]
		private Text otherJobText;

		// Token: 0x0400716A RID: 29034
		[UIControl("infoRoot/PersonalInformationOther/Left/equipScore/Value", null, 0)]
		private Text otherEquipScoreText;

		// Token: 0x0400716B RID: 29035
		[UIControl("infoRoot/PersonalInformationMeTop/Left/guildName/Value", typeof(Text), 0)]
		private Text me_GuildName;

		// Token: 0x0400716C RID: 29036
		[UIControl("infoRoot/PersonalInformationMeTop/Left/pkLevel/Value", typeof(Text), 0)]
		private Text me_pkLevelName;

		// Token: 0x0400716D RID: 29037
		[UIControl("infoRoot/PersonalInformationMeTop/Left/pkLevel/Image", typeof(Image), 0)]
		private Image me_pkLevelImg;

		// Token: 0x0400716E RID: 29038
		[UIControl("infoRoot/PersonalInformationMeTop/Right/pkNum/Value", typeof(Text), 0)]
		private Text me_pkNums;

		// Token: 0x0400716F RID: 29039
		[UIControl("infoRoot/PersonalInformationMeTop/Right/pkWinNum/Value", typeof(Text), 0)]
		private Text me_pkWinNums;

		// Token: 0x04007170 RID: 29040
		[UIControl("infoRoot/PersonalInformationMeTop/Left/guildName/Value", typeof(Text), 0)]
		private Text other_GuildName;

		// Token: 0x04007171 RID: 29041
		[UIControl("infoRoot/PersonalInformationMeTop/Left/pkLevel/Value", typeof(Text), 0)]
		private Text other_pkLevelName;

		// Token: 0x04007172 RID: 29042
		[UIControl("infoRoot/PersonalInformationMeTop/Left/pkLevel/Image", typeof(Image), 0)]
		private Image other_pkLevelImg;

		// Token: 0x04007173 RID: 29043
		[UIControl("infoRoot/PersonalInformationMeTop/Right/pkNum/Value", typeof(Text), 0)]
		private Text other_pkNums;

		// Token: 0x04007174 RID: 29044
		[UIControl("infoRoot/PersonalInformationMeTop/Right/pkWinNum/Value", typeof(Text), 0)]
		private Text other_pkWinNums;

		// Token: 0x04007175 RID: 29045
		[UIControl("buttonRoot/BtnReport", null, 0)]
		private Button btnReport;

		// Token: 0x020013F2 RID: 5106
		public class EquipItemObject : CachedObject
		{
			// Token: 0x0600C5FB RID: 50683 RVA: 0x002FC978 File Offset: 0x002FAD78
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goLocal = (param[1] as GameObject);
				this.eEEquipWearSlotType = (EEquipWearSlotType)param[2];
				this.THIS = (param[3] as ActorShowGroup);
				this.itemData = (param[4] as ItemData);
				this.comItem = this.goLocal.GetComponent<ComItem>();
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600C5FC RID: 50684 RVA: 0x002FCA05 File Offset: 0x002FAE05
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600C5FD RID: 50685 RVA: 0x002FCA0D File Offset: 0x002FAE0D
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C5FE RID: 50686 RVA: 0x002FCA2C File Offset: 0x002FAE2C
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C5FF RID: 50687 RVA: 0x002FCA4B File Offset: 0x002FAE4B
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C600 RID: 50688 RVA: 0x002FCA54 File Offset: 0x002FAE54
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(new object[]
				{
					this.goParent,
					this.goLocal,
					this.eEEquipWearSlotType,
					this.THIS,
					param[0]
				});
			}

			// Token: 0x0600C601 RID: 50689 RVA: 0x002FCA91 File Offset: 0x002FAE91
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600C602 RID: 50690 RVA: 0x002FCA94 File Offset: 0x002FAE94
			private void _UpdateItem()
			{
				string text = Utility.GetEnumDescription<EEquipWearSlotType>(this.eEEquipWearSlotType);
				text = TR.Value(text);
				this.comItem.SetupSlot(ComItem.ESlotType.Opened, text, null, string.Empty);
				if (this.eEEquipWearSlotType == EEquipWearSlotType.Equipassist3)
				{
					this.comItem.SetupSlot(ComItem.ESlotType.Locked, string.Empty, null, string.Empty);
				}
			}

			// Token: 0x0600C603 RID: 50691 RVA: 0x002FCAEB File Offset: 0x002FAEEB
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					DataManager<LinkManager>.GetInstance().AttachDatas = this.THIS.m_kData;
					ItemParser.OnItemLink(item.GUID, item.TableID, ActorShowGroup.m_queryPlayerType, ActorShowGroup.m_zoneId);
				}
			}

			// Token: 0x04007176 RID: 29046
			protected GameObject goLocal;

			// Token: 0x04007177 RID: 29047
			protected GameObject goParent;

			// Token: 0x04007178 RID: 29048
			protected EEquipWearSlotType eEEquipWearSlotType;

			// Token: 0x04007179 RID: 29049
			protected ActorShowGroup THIS;

			// Token: 0x0400717A RID: 29050
			private ComItem comItem;

			// Token: 0x0400717B RID: 29051
			private ItemData itemData;
		}

		// Token: 0x020013F3 RID: 5107
		public class FashionItemObject : CachedObject
		{
			// Token: 0x0600C605 RID: 50693 RVA: 0x002FCB2C File Offset: 0x002FAF2C
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goLocal = (param[1] as GameObject);
				this.eEFashionWearSlotType = (EFashionWearSlotType)param[2];
				this.THIS = (param[3] as ActorShowGroup);
				this.itemData = (param[4] as ItemData);
				this.comItem = this.goLocal.GetComponent<ComItem>();
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600C606 RID: 50694 RVA: 0x002FCBB9 File Offset: 0x002FAFB9
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600C607 RID: 50695 RVA: 0x002FCBC1 File Offset: 0x002FAFC1
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C608 RID: 50696 RVA: 0x002FCBE0 File Offset: 0x002FAFE0
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C609 RID: 50697 RVA: 0x002FCBFF File Offset: 0x002FAFFF
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C60A RID: 50698 RVA: 0x002FCC08 File Offset: 0x002FB008
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(new object[]
				{
					this.goParent,
					this.goLocal,
					this.eEFashionWearSlotType,
					this.THIS,
					param[0]
				});
			}

			// Token: 0x0600C60B RID: 50699 RVA: 0x002FCC45 File Offset: 0x002FB045
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600C60C RID: 50700 RVA: 0x002FCC48 File Offset: 0x002FB048
			private void _UpdateItem()
			{
				string text = Utility.GetEnumDescription<EFashionWearSlotType>(this.eEFashionWearSlotType);
				text = TR.Value(text);
				this.comItem.SetupSlot(ComItem.ESlotType.Opened, text, null, string.Empty);
			}

			// Token: 0x0600C60D RID: 50701 RVA: 0x002FCC7B File Offset: 0x002FB07B
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					DataManager<LinkManager>.GetInstance().AttachDatas = this.THIS.m_kData;
					ItemParser.OnItemLink(item.GUID, item.TableID, ActorShowGroup.m_queryPlayerType, ActorShowGroup.m_zoneId);
				}
			}

			// Token: 0x0400717C RID: 29052
			protected GameObject goLocal;

			// Token: 0x0400717D RID: 29053
			protected GameObject goParent;

			// Token: 0x0400717E RID: 29054
			protected EFashionWearSlotType eEFashionWearSlotType;

			// Token: 0x0400717F RID: 29055
			protected ActorShowGroup THIS;

			// Token: 0x04007180 RID: 29056
			private ComItem comItem;

			// Token: 0x04007181 RID: 29057
			private ItemData itemData;
		}

		// Token: 0x020013F4 RID: 5108
		private enum TabType
		{
			// Token: 0x04007183 RID: 29059
			[Description("角色")]
			TT_ACTOR,
			// Token: 0x04007184 RID: 29060
			[Description("时装")]
			TT_FASHION,
			// Token: 0x04007185 RID: 29061
			TT_COUNT
		}

		// Token: 0x020013F5 RID: 5109
		public class TabObject : CachedObject
		{
			// Token: 0x0600C60F RID: 50703 RVA: 0x002FCCBC File Offset: 0x002FB0BC
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.eTabType = (ActorShowGroup.TabType)param[2];
				this.THIS = (param[3] as ActorShowGroup);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.Label = Utility.FindComponent<Text>(this.goLocal, "Label", true);
					this.CheckLabel = Utility.FindComponent<Text>(this.goLocal, "Checkmark/Label", true);
					this.toggle = this.goLocal.GetComponent<Toggle>();
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this.OnValueChanged();
						}
					});
				}
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600C610 RID: 50704 RVA: 0x002FCDAC File Offset: 0x002FB1AC
			private void OnValueChanged()
			{
				this.THIS.OnSetFilter(this.eTabType);
			}

			// Token: 0x0600C611 RID: 50705 RVA: 0x002FCDBF File Offset: 0x002FB1BF
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600C612 RID: 50706 RVA: 0x002FCDC7 File Offset: 0x002FB1C7
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C613 RID: 50707 RVA: 0x002FCDE6 File Offset: 0x002FB1E6
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C614 RID: 50708 RVA: 0x002FCE05 File Offset: 0x002FB205
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C615 RID: 50709 RVA: 0x002FCE0E File Offset: 0x002FB20E
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C616 RID: 50710 RVA: 0x002FCE17 File Offset: 0x002FB217
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600C617 RID: 50711 RVA: 0x002FCE1C File Offset: 0x002FB21C
			private void _UpdateItem()
			{
				string enumDescription = Utility.GetEnumDescription<ActorShowGroup.TabType>(this.eTabType);
				this.Label.text = enumDescription;
				this.CheckLabel.text = enumDescription;
			}

			// Token: 0x04007186 RID: 29062
			protected GameObject goLocal;

			// Token: 0x04007187 RID: 29063
			protected GameObject goParent;

			// Token: 0x04007188 RID: 29064
			protected GameObject goPrefab;

			// Token: 0x04007189 RID: 29065
			private ActorShowGroup THIS;

			// Token: 0x0400718A RID: 29066
			private Text Label;

			// Token: 0x0400718B RID: 29067
			private Text CheckLabel;

			// Token: 0x0400718C RID: 29068
			public Toggle toggle;

			// Token: 0x0400718D RID: 29069
			private ActorShowGroup.TabType eTabType;
		}
	}
}
