using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001988 RID: 6536
	public class InstituteFrame : ClientFrame
	{
		// Token: 0x0600FE0F RID: 65039 RVA: 0x00463659 File Offset: 0x00461A59
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/InstituteFrame";
		}

		// Token: 0x0600FE10 RID: 65040 RVA: 0x00463660 File Offset: 0x00461A60
		protected override void _bindExUI()
		{
			base._bindExUI();
			this.prefabObject = this.mBind.GetGameObject("prefabObject");
			this.prefabContainer = this.mBind.GetGameObject("prefabContainer");
			this.comboSkillContainer = this.mBind.GetGameObject("comboContainer");
			this.awardContainer = this.mBind.GetGameObject("awardContainer");
			this.skillComboItem = this.mBind.GetGameObject("skillComboItem");
			this.primaryBtn = this.mBind.GetCom<Button>("primaryBtn");
			this.advanceBtn = this.mBind.GetCom<Button>("advanceBtn");
			this.select = this.mBind.GetGameObject("select");
			this.challengeBtn = this.mBind.GetCom<Button>("challengeBtn");
			this.previewBtn = this.mBind.GetCom<Button>("previewBtn");
			this.levelLimit = this.mBind.GetCom<Button>("levelLimit");
			this.lockState = this.mBind.GetCom<Button>("lockState");
			this.tip = this.mBind.GetGameObject("tip");
			this.skillName = this.mBind.GetCom<Text>("skillName");
			this.skillLevel = this.mBind.GetCom<Text>("skillLevel");
			this.des = this.mBind.GetCom<Text>("des");
			this.primaryBtn.onClick.AddListener(delegate()
			{
				this.InitTabPrefab(1);
			});
			this.advanceBtn.onClick.AddListener(delegate()
			{
				this.InitTabPrefab(2);
			});
			this.mSkillChangeTipTxt = this.mBind.GetCom<Text>("SkillChangedTip");
			this.mSkillChangeGo = this.mBind.GetGameObject("SkillChange");
			this.mTrainPVEBtn = this.mBind.GetCom<Button>("PVETrain");
			this.mFreedomTrainBtn = this.mBind.GetCom<Button>("btFreeTrain");
			this.mTrainPVEBtn.SafeAddOnClickListener(new UnityAction(this.OnPVETrainBtnClcik));
			this.mFreedomTrainBtn.SafeAddOnClickListener(new UnityAction(this.OnFreedomTrainBtnClick));
		}

		// Token: 0x0600FE11 RID: 65041 RVA: 0x00463894 File Offset: 0x00461C94
		protected override void _unbindExUI()
		{
			base._unbindExUI();
			this.prefabObject = null;
			this.prefabContainer = null;
			this.comboSkillContainer = null;
			this.awardContainer = null;
			this.skillComboItem = null;
			this.select = null;
			this.challengeBtn = null;
			this.previewBtn = null;
			this.levelLimit = null;
			this.lockState = null;
			this.tip = null;
			this.skillName = null;
			this.skillLevel = null;
			this.des = null;
			this.primaryBtn.onClick.RemoveListener(delegate()
			{
				this.InitTabPrefab(1);
			});
			this.primaryBtn = null;
			this.advanceBtn.onClick.RemoveListener(delegate()
			{
				this.InitTabPrefab(2);
			});
			this.advanceBtn = null;
			this.mSkillChangeTipTxt = null;
			this.mSkillChangeGo = null;
			this.mTrainPVEBtn.SafeRemoveOnClickListener(new UnityAction(this.OnPVETrainBtnClcik));
			this.mFreedomTrainBtn.SafeRemoveOnClickListener(new UnityAction(this.OnFreedomTrainBtnClick));
			this.mTrainPVEBtn = null;
			this.mFreedomTrainBtn = null;
		}

		// Token: 0x0600FE12 RID: 65042 RVA: 0x0046399C File Offset: 0x00461D9C
		protected override void _OnOpenFrame()
		{
			InstituteTable instituteTable = this.SelectLast();
			if (instituteTable == null)
			{
				this.InitTabPrefab(1);
			}
			else
			{
				this.InitTabPrefab(instituteTable.DifficultyType);
				this.ShowInstituteInfo(instituteTable);
			}
			InstituteFrame.IsEnterFromYanWUYuan = false;
		}

		// Token: 0x0600FE13 RID: 65043 RVA: 0x004639DB File Offset: 0x00461DDB
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x0600FE14 RID: 65044 RVA: 0x004639E4 File Offset: 0x00461DE4
		private InstituteTable SelectLast()
		{
			List<InstituteTable> jobAndTypeInstitue = Singleton<TableManager>.instance.GetJobAndTypeInstitue(DataManager<PlayerBaseData>.GetInstance().JobTableID, InstituteFrame.type);
			for (int i = 0; i < jobAndTypeInstitue.Count; i++)
			{
				if (DataManager<MissionManager>.GetInstance().GetState(jobAndTypeInstitue[i]) == 0)
				{
					return jobAndTypeInstitue[i];
				}
			}
			if (InstituteFrame.type == 2)
			{
				jobAndTypeInstitue = Singleton<TableManager>.instance.GetJobAndTypeInstitue(DataManager<PlayerBaseData>.GetInstance().JobTableID, 1);
				for (int j = 0; j < jobAndTypeInstitue.Count; j++)
				{
					if (DataManager<MissionManager>.GetInstance().GetState(jobAndTypeInstitue[j]) == 0)
					{
						return jobAndTypeInstitue[j];
					}
				}
			}
			else
			{
				jobAndTypeInstitue = Singleton<TableManager>.instance.GetJobAndTypeInstitue(DataManager<PlayerBaseData>.GetInstance().JobTableID, 2);
				for (int k = 0; k < jobAndTypeInstitue.Count; k++)
				{
					if (DataManager<MissionManager>.GetInstance().GetState(jobAndTypeInstitue[k]) == 0)
					{
						return jobAndTypeInstitue[k];
					}
				}
			}
			return null;
		}

		// Token: 0x0600FE15 RID: 65045 RVA: 0x00463AF8 File Offset: 0x00461EF8
		private void SetBtnState(int type)
		{
			if (type == 1)
			{
				this.primaryBtn.image.color = Color.white;
				this.primaryBtn.GetComponentInChildren<Text>().color = Color.white;
				this.advanceBtn.image.color = new Color(0.6901961f, 0.6901961f, 0.6901961f);
				this.advanceBtn.GetComponentInChildren<Text>().color = new Color(0.62352943f, 0.63529414f, 0.72156864f);
			}
			else
			{
				this.advanceBtn.image.color = Color.white;
				this.advanceBtn.GetComponentInChildren<Text>().color = Color.white;
				this.primaryBtn.image.color = new Color(0.6901961f, 0.6901961f, 0.6901961f);
				this.primaryBtn.GetComponentInChildren<Text>().color = new Color(0.62352943f, 0.63529414f, 0.72156864f);
			}
		}

		// Token: 0x0600FE16 RID: 65046 RVA: 0x00463BF8 File Offset: 0x00461FF8
		private void InitTabPrefab(int type)
		{
			this.SetBtnState(type);
			InstituteFrame.type = type;
			Utility.AttachTo(this.select, this.mSkillChangeGo, false);
			this.DestroyObjList();
			List<InstituteTable> jobAndTypeInstitue = Singleton<TableManager>.instance.GetJobAndTypeInstitue(DataManager<PlayerBaseData>.GetInstance().JobTableID, type);
			if (jobAndTypeInstitue != null && jobAndTypeInstitue.Count != 0)
			{
				this.mSkillChangeGo.CustomActive(true);
				this.mSkillChangeTipTxt.CustomActive(false);
				for (int i = 0; i < jobAndTypeInstitue.Count; i++)
				{
					InstituteTable data = jobAndTypeInstitue[i];
					GameObject gameObject = Object.Instantiate<GameObject>(this.prefabObject);
					if (!this.btnList.ContainsKey(data.ID))
					{
						this.btnList.Add(data.ID, gameObject);
					}
					else
					{
						this.btnList[data.ID] = gameObject;
					}
					gameObject.CustomActive(true);
					Utility.AttachTo(gameObject, this.prefabContainer, false);
					GameObject gameObject2 = Utility.FindChild("complete", gameObject);
					GameObject gameObject3 = Utility.FindChild("lock", gameObject);
					Button component = gameObject.GetComponent<Button>();
					Text component2 = Utility.FindChild("name", gameObject).GetComponent<Text>();
					component2.text = data.Title;
					int state = DataManager<MissionManager>.GetInstance().GetState(data);
					gameObject2.SetActive(state == 1);
					gameObject3.SetActive(state == 2 || state == 3);
					component.onClick.RemoveAllListeners();
					component.onClick.AddListener(delegate()
					{
						this.ShowInstituteInfo(data);
					});
				}
				this.ShowInstituteInfo(jobAndTypeInstitue[0]);
			}
			else
			{
				this.mSkillChangeGo.CustomActive(false);
				this.mSkillChangeTipTxt.CustomActive(true);
				this.des.SafeSetText(TR.Value("yawuyan_noskills"));
			}
		}

		// Token: 0x0600FE17 RID: 65047 RVA: 0x00463DE8 File Offset: 0x004621E8
		private void SetParent(GameObject child, GameObject parent)
		{
			child.transform.SetParent(parent.transform);
			child.transform.localPosition = Vector2.zero;
			child.transform.localScale = Vector3.one;
			child.transform.SetAsLastSibling();
		}

		// Token: 0x0600FE18 RID: 65048 RVA: 0x00463E38 File Offset: 0x00462238
		private void DestroyObjList()
		{
			foreach (KeyValuePair<int, GameObject> keyValuePair in this.btnList)
			{
				Object.Destroy(keyValuePair.Value);
			}
			this.btnList.Clear();
		}

		// Token: 0x0600FE19 RID: 65049 RVA: 0x00463EA4 File Offset: 0x004622A4
		private void ShowInstituteInfo(InstituteTable data)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(data.DungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.des.text = tableItem.Description;
			}
			this.SetParent(this.select, this.btnList[data.ID]);
			this.curData = data;
			InstituteFrame.id = this.curData.ID;
			this.ResetBtnState(data);
			this.ShowAwardList(data);
			this.ShowComboList(data);
		}

		// Token: 0x0600FE1A RID: 65050 RVA: 0x00463F2C File Offset: 0x0046232C
		private void ResetBtnState(InstituteTable data)
		{
			int state = DataManager<MissionManager>.GetInstance().GetState(data);
			this.challengeBtn.gameObject.CustomActive(state == 0);
			this.previewBtn.gameObject.CustomActive(state == 1);
			this.lockState.CustomActive(state == 2);
			this.levelLimit.CustomActive(state == 3);
			if (state == 3)
			{
				this.levelLimit.GetComponentInChildren<Text>().text = string.Format("需求等级:{0}", data.LevelLimit);
			}
		}

		// Token: 0x0600FE1B RID: 65051 RVA: 0x00463FB8 File Offset: 0x004623B8
		private void ShowAwardList(InstituteTable data)
		{
			List<ItemData> list = new List<ItemData>();
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(data.MissionID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string[] array = tableItem.Award.Split(new char[]
				{
					','
				});
				ComItemList.Items[] array2 = new ComItemList.Items[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					string[] array3 = array[i].Split(new char[]
					{
						'_'
					});
					if (array3.Length == 2)
					{
						array2[i] = new ComItemList.Items();
						array2[i].id = int.Parse(array3[0]);
						array2[i].count = uint.Parse(array3[1]);
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(array2[i].id);
						commonItemTableDataByID.Count = (int)array2[i].count;
						list.Add(commonItemTableDataByID);
					}
				}
				this.awardContainer.GetComponent<ComItemList>().SetItems(array2);
				ComItem[] componentsInChildren = this.awardContainer.GetComponentsInChildren<ComItem>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].Setup(list[j], new ComItem.OnItemClicked(this._OnItemClicked));
					if (DataManager<MissionManager>.GetInstance().GetState(data) == 1)
					{
						componentsInChildren[j].ItemData.IsSelected = true;
						componentsInChildren[j].SetShowSelectState(true);
					}
				}
			}
		}

		// Token: 0x0600FE1C RID: 65052 RVA: 0x0046411F File Offset: 0x0046251F
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0600FE1D RID: 65053 RVA: 0x00464138 File Offset: 0x00462538
		private void ShowComboList(InstituteTable arg)
		{
			this.DestroyComboSkillList();
			ComboTeachData comboData = Singleton<TableManager>.instance.GetComboData(arg.DungeonID);
			if (comboData == null)
			{
				return;
			}
			ComboData[] datas = comboData.datas;
			for (int i = 0; i < datas.Length; i++)
			{
				ComboData comboData2 = datas[i];
				if (comboData2.showUI != 0)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.skillComboItem);
					gameObject.CustomActive(true);
					Utility.AttachTo(gameObject, this.comboSkillContainer, false);
					Image component = Utility.FindChild("skillIcon", gameObject).GetComponent<Image>();
					int num = comboData2.skillID;
					if (comboData2.sourceID != 0)
					{
						num = comboData2.sourceID;
					}
					ComLongPress component2 = gameObject.GetComponent<ComLongPress>();
					if (component2 != null)
					{
						int[] args = new int[]
						{
							num,
							comboData2.skillLevel
						};
						component2.SetArgs(args);
						component2.pointDownCallBack = new Action<Transform, object>(this.PointDownCallBack);
						component2.pointUpCallBack = new Action<object>(this.PointUpCallBack);
					}
					SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
					ETCImageLoader.LoadSprite(ref component, tableItem.Icon, true);
					GameObject gameObject2 = Utility.FindChild("guideArrow", gameObject);
					gameObject2.CustomActive(i < datas.Length - 1);
					this.comboSkillList.Add(gameObject);
				}
			}
		}

		// Token: 0x0600FE1E RID: 65054 RVA: 0x00464298 File Offset: 0x00462698
		private void PointDownCallBack(Transform trans, object args)
		{
			int[] array = args as int[];
			this.tip.CustomActive(true);
			this.tip.transform.position = trans.position + new Vector3(-8f, 55f, 0f);
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(array[0], string.Empty, string.Empty);
			this.skillName.text = tableItem.Name;
			this.skillLevel.text = string.Format("Lv.{0}", array[1]);
		}

		// Token: 0x0600FE1F RID: 65055 RVA: 0x0046432D File Offset: 0x0046272D
		private void PointUpCallBack(object args)
		{
			this.tip.CustomActive(false);
		}

		// Token: 0x0600FE20 RID: 65056 RVA: 0x0046433C File Offset: 0x0046273C
		public static IEnumerator _commonStart(int dungeonID, byte restart = 0)
		{
			if (!InstituteFrame.mIsSendMessage)
			{
				SceneDungeonStartReq req = new SceneDungeonStartReq
				{
					dungeonId = (uint)dungeonID,
					isRestart = restart
				};
				MessageEvents msg = new MessageEvents();
				SceneDungeonStartRes res = new SceneDungeonStartRes();
				InstituteFrame.mIsSendMessage = true;
				yield return MessageUtility.Wait<SceneDungeonStartReq, SceneDungeonStartRes>(ServerType.GATE_SERVER, msg, req, res, true, 5f);
				InstituteFrame.mIsSendMessage = false;
			}
			yield break;
		}

		// Token: 0x0600FE21 RID: 65057 RVA: 0x00464360 File Offset: 0x00462760
		private void DestroyComboSkillList()
		{
			for (int i = 0; i < this.comboSkillList.Count; i++)
			{
				Object.Destroy(this.comboSkillList[i]);
			}
			this.comboSkillList.Clear();
		}

		// Token: 0x0600FE22 RID: 65058 RVA: 0x004643A5 File Offset: 0x004627A5
		[UIEventHandle("BG/Title/close")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<InstituteFrame>(this, false);
		}

		// Token: 0x0600FE23 RID: 65059 RVA: 0x004643B4 File Offset: 0x004627B4
		[UIEventHandle("SkillChange/buttonPart/challengeBtn")]
		private void ChallengeInstitute()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(InstituteFrame._commonStart(this.curData.DungeonID, 0));
		}

		// Token: 0x0600FE24 RID: 65060 RVA: 0x004643D2 File Offset: 0x004627D2
		[UIEventHandle("SkillChange/buttonPart/previewBtn")]
		private void ChallengeAgain()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(InstituteFrame._commonStart(this.curData.DungeonID, 0));
		}

		// Token: 0x0600FE25 RID: 65061 RVA: 0x004643F0 File Offset: 0x004627F0
		private void OnFreedomTrainBtnClick()
		{
			BattleMain.OpenBattle(BattleType.Training, eDungeonMode.LocalFrame, 0, "1000");
			Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
		}

		// Token: 0x0600FE26 RID: 65062 RVA: 0x0046440D File Offset: 0x0046280D
		private void OnPVETrainBtnClcik()
		{
			InstituteFrame.IsEnterFromYanWUYuan = true;
			BattleMain.OpenBattle(BattleType.TrainingPVE, eDungeonMode.LocalFrame, 0, "1000");
			Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
		}

		// Token: 0x0400A02B RID: 41003
		private GameObject prefabObject;

		// Token: 0x0400A02C RID: 41004
		private GameObject prefabContainer;

		// Token: 0x0400A02D RID: 41005
		private GameObject comboSkillContainer;

		// Token: 0x0400A02E RID: 41006
		private GameObject awardContainer;

		// Token: 0x0400A02F RID: 41007
		private GameObject skillComboItem;

		// Token: 0x0400A030 RID: 41008
		private GameObject tip;

		// Token: 0x0400A031 RID: 41009
		private Text skillName;

		// Token: 0x0400A032 RID: 41010
		private Text skillLevel;

		// Token: 0x0400A033 RID: 41011
		private InstituteTable curData;

		// Token: 0x0400A034 RID: 41012
		private Dictionary<int, GameObject> btnList = new Dictionary<int, GameObject>();

		// Token: 0x0400A035 RID: 41013
		private List<GameObject> comboSkillList = new List<GameObject>();

		// Token: 0x0400A036 RID: 41014
		private Button challengeBtn;

		// Token: 0x0400A037 RID: 41015
		private Button previewBtn;

		// Token: 0x0400A038 RID: 41016
		private Button lockState;

		// Token: 0x0400A039 RID: 41017
		private Button levelLimit;

		// Token: 0x0400A03A RID: 41018
		private Button primaryBtn;

		// Token: 0x0400A03B RID: 41019
		private Button advanceBtn;

		// Token: 0x0400A03C RID: 41020
		private GameObject select;

		// Token: 0x0400A03D RID: 41021
		private Text des;

		// Token: 0x0400A03E RID: 41022
		public static int type;

		// Token: 0x0400A03F RID: 41023
		public static int id;

		// Token: 0x0400A040 RID: 41024
		private Text mSkillChangeTipTxt;

		// Token: 0x0400A041 RID: 41025
		private GameObject mSkillChangeGo;

		// Token: 0x0400A042 RID: 41026
		private Button mTrainPVEBtn;

		// Token: 0x0400A043 RID: 41027
		private Button mFreedomTrainBtn;

		// Token: 0x0400A044 RID: 41028
		public static bool IsEnterFromYanWUYuan;

		// Token: 0x0400A045 RID: 41029
		private static bool mIsSendMessage;
	}
}
