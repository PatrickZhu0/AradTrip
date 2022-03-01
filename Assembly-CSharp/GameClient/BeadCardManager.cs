using System;
using System.Collections.Generic;
using System.Text;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02004552 RID: 17746
	public class BeadCardManager : DataManager<BeadCardManager>
	{
		// Token: 0x06018B71 RID: 101233 RVA: 0x007B8F14 File Offset: 0x007B7314
		public sealed override void Clear()
		{
			this.UnRegisterNetHandler();
			this.mRemovJewelsTableDic.Clear();
			this.mBeadRandomBuffDic.Clear();
			this.mReplaceJewelsTableDic.Clear();
			this.TreasureConvertTip = false;
		}

		// Token: 0x06018B72 RID: 101234 RVA: 0x007B8F44 File Offset: 0x007B7344
		public sealed override void Initialize()
		{
			this.RegisterNetHandler();
			this.InitRemovJewelsTable();
			this.InitBeadRandomBuff();
			this.InitReplaceJewelsTable();
		}

		// Token: 0x06018B73 RID: 101235 RVA: 0x007B8F60 File Offset: 0x007B7360
		public List<BeadPickItemModel> GetBeadExpendItemModel(int cololLevel, int beadLevel, int beadType)
		{
			if (this.mRemovJewelsTableDic.ContainsKey(cololLevel) && this.mRemovJewelsTableDic[cololLevel].ContainsKey(beadLevel) && this.mRemovJewelsTableDic[cololLevel][beadLevel].ContainsKey(beadType))
			{
				return this.mRemovJewelsTableDic[cololLevel][beadLevel][beadType];
			}
			return null;
		}

		// Token: 0x06018B74 RID: 101236 RVA: 0x007B8FCC File Offset: 0x007B73CC
		private void InitRemovJewelsTable()
		{
			this.mRemovJewelsTableDic.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<RemovejewelsTable>())
			{
				RemovejewelsTable removejewelsTable = keyValuePair.Value as RemovejewelsTable;
				if (removejewelsTable != null)
				{
					if (!this.mRemovJewelsTableDic.ContainsKey(removejewelsTable.Colour))
					{
						this.mRemovJewelsTableDic.Add(removejewelsTable.Colour, new Dictionary<int, Dictionary<int, List<BeadPickItemModel>>>());
					}
					if (!this.mRemovJewelsTableDic[removejewelsTable.Colour].ContainsKey(removejewelsTable.Grades))
					{
						this.mRemovJewelsTableDic[removejewelsTable.Colour].Add(removejewelsTable.Grades, new Dictionary<int, List<BeadPickItemModel>>());
					}
					if (!this.mRemovJewelsTableDic[removejewelsTable.Colour][removejewelsTable.Grades].ContainsKey(removejewelsTable.BeadType))
					{
						this.mRemovJewelsTableDic[removejewelsTable.Colour][removejewelsTable.Grades].Add(removejewelsTable.BeadType, new List<BeadPickItemModel>());
					}
					BeadPickItemModel item = new BeadPickItemModel(removejewelsTable.Material1, removejewelsTable.Num1, removejewelsTable.Success1, removejewelsTable.PickNum);
					this.mRemovJewelsTableDic[removejewelsTable.Colour][removejewelsTable.Grades][removejewelsTable.BeadType].Add(item);
				}
			}
		}

		// Token: 0x06018B75 RID: 101237 RVA: 0x007B9138 File Offset: 0x007B7538
		private void InitBeadRandomBuff()
		{
			this.mBeadRandomBuffDic.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<BeadRandomBuff>())
			{
				BeadRandomBuff beadRandomBuff = keyValuePair.Value as BeadRandomBuff;
				if (beadRandomBuff != null)
				{
					if (!this.mBeadRandomBuffDic.ContainsKey(beadRandomBuff.BuffinfoID))
					{
						this.mBeadRandomBuffDic.Add(beadRandomBuff.BuffinfoID, beadRandomBuff);
					}
				}
			}
		}

		// Token: 0x06018B76 RID: 101238 RVA: 0x007B91BC File Offset: 0x007B75BC
		private void InitReplaceJewelsTable()
		{
			this.mReplaceJewelsTableDic.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<ReplacejewelsTable>())
			{
				ReplacejewelsTable replacejewelsTable = keyValuePair.Value as ReplacejewelsTable;
				if (replacejewelsTable != null)
				{
					if (!this.mReplaceJewelsTableDic.ContainsKey(replacejewelsTable.Colour))
					{
						this.mReplaceJewelsTableDic.Add(replacejewelsTable.Colour, new Dictionary<int, Dictionary<int, ReplacejewelsTable>>());
					}
					if (!this.mReplaceJewelsTableDic[replacejewelsTable.Colour].ContainsKey(replacejewelsTable.Grades))
					{
						this.mReplaceJewelsTableDic[replacejewelsTable.Colour].Add(replacejewelsTable.Grades, new Dictionary<int, ReplacejewelsTable>());
					}
					if (!this.mReplaceJewelsTableDic[replacejewelsTable.Colour][replacejewelsTable.Grades].ContainsKey(replacejewelsTable.BeadType))
					{
						this.mReplaceJewelsTableDic[replacejewelsTable.Colour][replacejewelsTable.Grades].Add(replacejewelsTable.BeadType, replacejewelsTable);
					}
				}
			}
		}

		// Token: 0x06018B77 RID: 101239 RVA: 0x007B92D8 File Offset: 0x007B76D8
		public ReplacejewelsTable GetBeadReplaceJewelsTableData(int cololLevel, int beadLevel, int beadType)
		{
			if (this.mReplaceJewelsTableDic.ContainsKey(cololLevel) && this.mReplaceJewelsTableDic[cololLevel].ContainsKey(beadLevel) && this.mReplaceJewelsTableDic[cololLevel][beadLevel].ContainsKey(beadType))
			{
				return this.mReplaceJewelsTableDic[cololLevel][beadLevel][beadType];
			}
			return null;
		}

		// Token: 0x06018B78 RID: 101240 RVA: 0x007B9344 File Offset: 0x007B7744
		public BeadRandomBuff GetBeadRandomBuffData(int buffInfoID)
		{
			BeadRandomBuff result = null;
			if (this.mBeadRandomBuffDic.ContainsKey(buffInfoID))
			{
				result = this.mBeadRandomBuffDic[buffInfoID];
			}
			return result;
		}

		// Token: 0x06018B79 RID: 101241 RVA: 0x007B9374 File Offset: 0x007B7774
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(500972U, new Action<MsgDATA>(this.OnRecvSceneAddPreciousBeadRet));
			NetProcess.AddMsgHandler(501034U, new Action<MsgDATA>(this.OnSceneMountPreciousBeadRet));
			NetProcess.AddMsgHandler(501036U, new Action<MsgDATA>(this.OnSceneExtirpePreciousBeadRet));
			NetProcess.AddMsgHandler(501040U, new Action<MsgDATA>(this.OnSceneUpgradePreciousbeadRes));
			NetProcess.AddMsgHandler(501043U, new Action<MsgDATA>(this.OnSceneReplacePreciousBeadRet));
			NetProcess.AddMsgHandler(501091U, new Action<MsgDATA>(this.OnSceneBeadConvertRes));
		}

		// Token: 0x06018B7A RID: 101242 RVA: 0x007B9408 File Offset: 0x007B7808
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(500972U, new Action<MsgDATA>(this.OnRecvSceneAddPreciousBeadRet));
			NetProcess.RemoveMsgHandler(501034U, new Action<MsgDATA>(this.OnSceneMountPreciousBeadRet));
			NetProcess.RemoveMsgHandler(501036U, new Action<MsgDATA>(this.OnSceneExtirpePreciousBeadRet));
			NetProcess.RemoveMsgHandler(501040U, new Action<MsgDATA>(this.OnSceneUpgradePreciousbeadRes));
			NetProcess.RemoveMsgHandler(501043U, new Action<MsgDATA>(this.OnSceneReplacePreciousBeadRet));
			NetProcess.RemoveMsgHandler(501091U, new Action<MsgDATA>(this.OnSceneBeadConvertRes));
		}

		// Token: 0x06018B7B RID: 101243 RVA: 0x007B949C File Offset: 0x007B789C
		public string GetCondition(int iBeadCard)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_condition_color"));
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(iBeadCard, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.Parts.Count; i++)
				{
					string enumDescription = Utility.GetEnumDescription<EEquipWearSlotType>((EEquipWearSlotType)tableItem.Parts[i]);
					stringBuilder.Append(TR.Value(enumDescription));
					if (i != tableItem.Parts.Count - 1)
					{
						stringBuilder.Append("、");
					}
				}
			}
			stringBuilder.Append("</color>");
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018B7C RID: 101244 RVA: 0x007B955C File Offset: 0x007B795C
		public string GetAttributesDesc(int iID, bool isSubstitutionBox = false)
		{
			string text = string.Empty;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(iID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return text;
			}
			if (tableItem.BuffInfoIDPve.Count <= 0 && tableItem.BuffInfoIDPvp.Count <= 0)
			{
				text = DataManager<EnchantmentsCardManager>.GetInstance().MagicCardAndBeadCardGetAttributesDesc(tableItem.PropType, tableItem.PropValue, tableItem.BuffInfoIDPve, tableItem.SkillAttributes, text, tableItem.ProminentAtt == 1, isSubstitutionBox);
			}
			else
			{
				bool flag = false;
				int num = 0;
				if (num < tableItem.BuffInfoIDPve.Count)
				{
					flag = (tableItem.BuffInfoIDPve[num] == tableItem.BuffInfoIDPvp[num]);
				}
				if (flag)
				{
					text = DataManager<EnchantmentsCardManager>.GetInstance().MagicCardAndBeadCardGetAttributesDesc(tableItem.PropType, tableItem.PropValue, tableItem.BuffInfoIDPve, tableItem.SkillAttributes, text, tableItem.ProminentAtt == 1, isSubstitutionBox);
				}
				else
				{
					text = string.Format("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem.Instruction);
				}
			}
			return text;
		}

		// Token: 0x06018B7D RID: 101245 RVA: 0x007B9680 File Offset: 0x007B7A80
		public string GetBeadRandomAttributesDesc(int iBuffId)
		{
			string result = string.Empty;
			BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(iBuffId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.Description.Count > 0)
			{
				result = string.Format("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem.Description[0]);
			}
			return result;
		}

		// Token: 0x06018B7E RID: 101246 RVA: 0x007B96E4 File Offset: 0x007B7AE4
		public string GetBeadPickRemainNumber(int TableID, int BeadPickNumber)
		{
			string result = string.Empty;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				List<BeadPickItemModel> beadExpendItemModel = DataManager<BeadCardManager>.GetInstance().GetBeadExpendItemModel(tableItem.Color, tableItem.Level, tableItem.BeadType);
				if (beadExpendItemModel != null)
				{
					for (int i = 0; i < beadExpendItemModel.Count; i++)
					{
						BeadPickItemModel beadPickItemModel = beadExpendItemModel[i];
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(beadPickItemModel.mExpendItemID);
						if (commonItemTableDataByID != null)
						{
							if (commonItemTableDataByID.SubType == 89)
							{
								if (beadPickItemModel.mBeadPickTotleNumber > 0)
								{
									result = TR.Value("BeadPickRemainNumber", beadPickItemModel.mBeadPickTotleNumber - BeadPickNumber);
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06018B7F RID: 101247 RVA: 0x007B97B4 File Offset: 0x007B7BB4
		public string GetBeadReplaceRemainNumber(int TableID, int BeadReplaceNumber)
		{
			string result = string.Empty;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ReplacejewelsTable beadReplaceJewelsTableData = this.GetBeadReplaceJewelsTableData(tableItem.Color, tableItem.Level, tableItem.BeadType);
				if (beadReplaceJewelsTableData != null)
				{
					if (beadReplaceJewelsTableData.ReplaceNum == -1)
					{
						result = TR.Value("ReplaceNumberDesc", "不限");
					}
					else if (beadReplaceJewelsTableData.ReplaceNum > 0)
					{
						int num = beadReplaceJewelsTableData.ReplaceNum - BeadReplaceNumber;
						result = TR.Value("ReplaceNumberDesc", num);
					}
				}
			}
			return result;
		}

		// Token: 0x06018B80 RID: 101248 RVA: 0x007B984C File Offset: 0x007B7C4C
		public bool FindProminentAttID(IList<int> iBuffIDs, ref int buffId)
		{
			bool flag = false;
			for (int i = 0; i < iBuffIDs.Count; i++)
			{
				BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(iBuffIDs[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.SkillID.Count > 0)
					{
						for (int j = 0; j < tableItem.SkillID.Count; j++)
						{
							SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(tableItem.SkillID[j], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (tableItem2.JobID.Length > 0)
								{
									if (tableItem2.JobID.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
									{
										flag = true;
										buffId = iBuffIDs[i];
										break;
									}
								}
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x06018B81 RID: 101249 RVA: 0x007B9948 File Offset: 0x007B7D48
		public void SendAddSarah(ulong cardid, ulong itemid)
		{
			SceneAddPreciousBeadReq sceneAddPreciousBeadReq = new SceneAddPreciousBeadReq();
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(cardid);
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemid);
			if (item != null && item2 != null)
			{
				sceneAddPreciousBeadReq.preciousBeadUid = item.GUID;
				sceneAddPreciousBeadReq.itemUid = item2.GUID;
				NetManager.Instance().SendCommand<SceneAddPreciousBeadReq>(ServerType.GATE_SERVER, sceneAddPreciousBeadReq);
			}
		}

		// Token: 0x06018B82 RID: 101250 RVA: 0x007B99A4 File Offset: 0x007B7DA4
		private void OnRecvSceneAddPreciousBeadRet(MsgDATA msgData)
		{
			SceneAddPreciousBeadRet sceneAddPreciousBeadRet = new SceneAddPreciousBeadRet();
			sceneAddPreciousBeadRet.decode(msgData.bytes);
			if (sceneAddPreciousBeadRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneAddPreciousBeadRet.code, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAddSarahSuccess, null, null, null, null);
				SarahResultFrame.SarahResultFrameData sarahResultFrameData = new SarahResultFrame.SarahResultFrameData();
				sarahResultFrameData.bMerge = false;
				sarahResultFrameData.iCardTableID = (int)sceneAddPreciousBeadRet.preciousBeadId;
				sarahResultFrameData.itemData = DataManager<ItemDataManager>.GetInstance().GetItem(sceneAddPreciousBeadRet.itemUid);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SarahResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<SarahResultFrame>(null, false);
				}
				ClientFrame.OpenTargetFrame<SarahResultFrame>(FrameLayer.Middle, sarahResultFrameData);
			}
		}

		// Token: 0x06018B83 RID: 101251 RVA: 0x007B9A4C File Offset: 0x007B7E4C
		public void SedndSceneMountPreciousBeadReq(ulong beadid, ulong itemid, byte holeIndex)
		{
			SceneMountPreciousBeadReq sceneMountPreciousBeadReq = new SceneMountPreciousBeadReq();
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(beadid);
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemid);
			if (item != null && item2 != null)
			{
				sceneMountPreciousBeadReq.preciousBeadUid = item.GUID;
				sceneMountPreciousBeadReq.itemUid = item2.GUID;
				sceneMountPreciousBeadReq.holeIndex = holeIndex;
				NetManager.Instance().SendCommand<SceneMountPreciousBeadReq>(ServerType.GATE_SERVER, sceneMountPreciousBeadReq);
			}
		}

		// Token: 0x06018B84 RID: 101252 RVA: 0x007B9AB0 File Offset: 0x007B7EB0
		private void OnSceneMountPreciousBeadRet(MsgDATA msgData)
		{
			SceneMountPreciousBeadRet sceneMountPreciousBeadRet = new SceneMountPreciousBeadRet();
			sceneMountPreciousBeadRet.decode(msgData.bytes);
			if (sceneMountPreciousBeadRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneMountPreciousBeadRet.code, string.Empty);
			}
			else
			{
				SarahResultFrame.SarahResultFrameData sarahResultFrameData = new SarahResultFrame.SarahResultFrameData();
				sarahResultFrameData.bMerge = false;
				sarahResultFrameData.iCardTableID = (int)sceneMountPreciousBeadRet.preciousBeadId;
				sarahResultFrameData.itemData = DataManager<ItemDataManager>.GetInstance().GetItem(sceneMountPreciousBeadRet.itemUid);
				sarahResultFrameData.iHoleIndex = (int)sceneMountPreciousBeadRet.holeIndex;
				sarahResultFrameData.iTitleType = 1;
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SarahResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<SarahResultFrame>(null, false);
				}
				ClientFrame.OpenTargetFrame<SarahResultFrame>(FrameLayer.Middle, sarahResultFrameData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAddSarahSuccess, null, null, null, null);
		}

		// Token: 0x06018B85 RID: 101253 RVA: 0x007B9B68 File Offset: 0x007B7F68
		public void SendSceneExtirpePreciousBeadReq(byte holeIndex, ulong itemUid, uint pestleId)
		{
			SceneExtirpePreciousBeadReq sceneExtirpePreciousBeadReq = new SceneExtirpePreciousBeadReq();
			sceneExtirpePreciousBeadReq.holeIndex = holeIndex;
			sceneExtirpePreciousBeadReq.itemUid = itemUid;
			sceneExtirpePreciousBeadReq.pestleId = pestleId;
			NetManager.Instance().SendCommand<SceneExtirpePreciousBeadReq>(ServerType.GATE_SERVER, sceneExtirpePreciousBeadReq);
		}

		// Token: 0x06018B86 RID: 101254 RVA: 0x007B9BA0 File Offset: 0x007B7FA0
		private void OnSceneExtirpePreciousBeadRet(MsgDATA msgData)
		{
			SceneExtirpePreciousBeadRet sceneExtirpePreciousBeadRet = new SceneExtirpePreciousBeadRet();
			sceneExtirpePreciousBeadRet.decode(msgData.bytes);
			if (sceneExtirpePreciousBeadRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneExtirpePreciousBeadRet.code, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("BeadPickSuccess"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BeadPickFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<BeadPickFrame>(null, false);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BeadPickSuccess, null, null, null, null);
		}

		// Token: 0x06018B87 RID: 101255 RVA: 0x007B9C20 File Offset: 0x007B8020
		public void SendSceneUpgradePreciousbeadReq(BeadItemModel model, int mExpendBeadID)
		{
			SceneUpgradePreciousbeadReq sceneUpgradePreciousbeadReq = new SceneUpgradePreciousbeadReq();
			if (model.mountedType == 1)
			{
				sceneUpgradePreciousbeadReq.mountedType = (byte)model.mountedType;
				sceneUpgradePreciousbeadReq.equipGuid = model.equipItemData.GUID;
				sceneUpgradePreciousbeadReq.eqPrecHoleIndex = (byte)model.eqPrecHoleIndex;
				sceneUpgradePreciousbeadReq.precId = (uint)model.beadItemData.TableID;
			}
			else
			{
				sceneUpgradePreciousbeadReq.mountedType = (byte)model.mountedType;
				sceneUpgradePreciousbeadReq.precGuid = model.beadItemData.GUID;
			}
			sceneUpgradePreciousbeadReq.consumePrecId = (uint)mExpendBeadID;
			NetManager.Instance().SendCommand<SceneUpgradePreciousbeadReq>(ServerType.GATE_SERVER, sceneUpgradePreciousbeadReq);
		}

		// Token: 0x06018B88 RID: 101256 RVA: 0x007B9CB4 File Offset: 0x007B80B4
		private void OnSceneUpgradePreciousbeadRes(MsgDATA msgData)
		{
			SceneUpgradePreciousbeadRes sceneUpgradePreciousbeadRes = new SceneUpgradePreciousbeadRes();
			sceneUpgradePreciousbeadRes.decode(msgData.bytes);
			if (sceneUpgradePreciousbeadRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneUpgradePreciousbeadRes.retCode, string.Empty);
			}
			else
			{
				BeadUpgradeResultData beadUpgradeResultData = new BeadUpgradeResultData((int)sceneUpgradePreciousbeadRes.mountedType, sceneUpgradePreciousbeadRes.equipGuid, (int)sceneUpgradePreciousbeadRes.precId, (int)sceneUpgradePreciousbeadRes.addBuffId, sceneUpgradePreciousbeadRes.newPrebeadUid);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BeadUpgradeResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<BeadUpgradeResultFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<BeadUpgradeResultFrame>(FrameLayer.Middle, beadUpgradeResultData, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnBeadUpgradeSuccess, beadUpgradeResultData, null, null, null);
			}
		}

		// Token: 0x06018B89 RID: 101257 RVA: 0x007B9D58 File Offset: 0x007B8158
		public void OnSendSceneReplacePreciousBeadReq(byte holeIndex, ulong itemUid, ulong beadId)
		{
			SceneReplacePreciousBeadReq sceneReplacePreciousBeadReq = new SceneReplacePreciousBeadReq();
			sceneReplacePreciousBeadReq.holeIndex = holeIndex;
			sceneReplacePreciousBeadReq.itemUid = itemUid;
			sceneReplacePreciousBeadReq.preciousBeadUid = beadId;
			NetManager.Instance().SendCommand<SceneReplacePreciousBeadReq>(ServerType.GATE_SERVER, sceneReplacePreciousBeadReq);
		}

		// Token: 0x06018B8A RID: 101258 RVA: 0x007B9D90 File Offset: 0x007B8190
		public void OnSceneReplacePreciousBeadRet(MsgDATA msgData)
		{
			SceneReplacePreciousBeadRet sceneReplacePreciousBeadRet = new SceneReplacePreciousBeadRet();
			sceneReplacePreciousBeadRet.decode(msgData.bytes);
			if (sceneReplacePreciousBeadRet.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneReplacePreciousBeadRet.retCode, string.Empty);
			}
			else
			{
				SarahResultFrame.SarahResultFrameData sarahResultFrameData = new SarahResultFrame.SarahResultFrameData();
				sarahResultFrameData.bMerge = false;
				sarahResultFrameData.iCardTableID = (int)sceneReplacePreciousBeadRet.preciousBeadId;
				sarahResultFrameData.itemData = DataManager<ItemDataManager>.GetInstance().GetItem(sceneReplacePreciousBeadRet.itemUid);
				sarahResultFrameData.iHoleIndex = (int)sceneReplacePreciousBeadRet.holeIndex;
				sarahResultFrameData.iTitleType = 2;
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SarahResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<SarahResultFrame>(null, false);
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BeadPerfectReplacementFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<BeadPerfectReplacementFrame>(null, false);
				}
				ClientFrame.OpenTargetFrame<SarahResultFrame>(FrameLayer.Middle, sarahResultFrameData);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAddSarahSuccess, null, null, null, null);
			}
		}

		// Token: 0x06018B8B RID: 101259 RVA: 0x007B9E64 File Offset: 0x007B8264
		public void OnSceneBeadConvertReq(ulong treasureGuid, ulong materialGuid)
		{
			SceneBeadConvertReq sceneBeadConvertReq = new SceneBeadConvertReq();
			sceneBeadConvertReq.beadGuid = treasureGuid;
			sceneBeadConvertReq.materialGuid = materialGuid;
			NetManager.Instance().SendCommand<SceneBeadConvertReq>(ServerType.GATE_SERVER, sceneBeadConvertReq);
		}

		// Token: 0x06018B8C RID: 101260 RVA: 0x007B9E94 File Offset: 0x007B8294
		private void OnSceneBeadConvertRes(MsgDATA msg)
		{
			SceneBeadConvertRes sceneBeadConvertRes = new SceneBeadConvertRes();
			sceneBeadConvertRes.decode(msg.bytes);
			if (sceneBeadConvertRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneBeadConvertRes.retCode, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureConversionSuccessed, null, null, null, null);
			}
		}

		// Token: 0x06018B8D RID: 101261 RVA: 0x007B9EE8 File Offset: 0x007B82E8
		public bool CheckTreasureConvertActivityOpon()
		{
			ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().GetActivityInfo(TR.Value("TreasureConvert_activity_name"));
			return activityInfo != null && activityInfo.level <= DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x04011D09 RID: 72969
		private Dictionary<int, Dictionary<int, Dictionary<int, List<BeadPickItemModel>>>> mRemovJewelsTableDic = new Dictionary<int, Dictionary<int, Dictionary<int, List<BeadPickItemModel>>>>();

		// Token: 0x04011D0A RID: 72970
		private Dictionary<int, BeadRandomBuff> mBeadRandomBuffDic = new Dictionary<int, BeadRandomBuff>();

		// Token: 0x04011D0B RID: 72971
		private Dictionary<int, Dictionary<int, Dictionary<int, ReplacejewelsTable>>> mReplaceJewelsTableDic = new Dictionary<int, Dictionary<int, Dictionary<int, ReplacejewelsTable>>>();

		// Token: 0x04011D0C RID: 72972
		public bool TreasureConvertTip;
	}
}
