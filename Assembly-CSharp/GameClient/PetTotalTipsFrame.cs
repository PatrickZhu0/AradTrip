using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Protocol;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001982 RID: 6530
	internal class PetTotalTipsFrame : ClientFrame
	{
		// Token: 0x0600FDFF RID: 65023 RVA: 0x0046304A File Offset: 0x0046144A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pet/PetTotalTipsFrame";
		}

		// Token: 0x0600FE00 RID: 65024 RVA: 0x00463051 File Offset: 0x00461451
		protected override void _OnOpenFrame()
		{
			this._RefreshData();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetItemsInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdatePetList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetSlotChanged, new ClientEventSystem.UIEventHandler(this._OnPetSlotChanged));
		}

		// Token: 0x0600FE01 RID: 65025 RVA: 0x0046308F File Offset: 0x0046148F
		private void _OnUpdatePetList(UIEvent uiEvent)
		{
			this._RefreshData();
		}

		// Token: 0x0600FE02 RID: 65026 RVA: 0x00463097 File Offset: 0x00461497
		private void _OnPetSlotChanged(UIEvent uiEvent)
		{
			this._RefreshData();
		}

		// Token: 0x0600FE03 RID: 65027 RVA: 0x004630A0 File Offset: 0x004614A0
		private void _RefreshData()
		{
			if (null != this.headDesc)
			{
				this.headDesc.text = TR.Value("pet_tips_head", DataManager<PetDataManager>.GetInstance().GetOnUsePetList().Count);
			}
			if (null != this.hintText)
			{
				int num = 0;
				List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
				if (onUsePetList != null)
				{
					num = onUsePetList.Count;
				}
				this.hintText.CustomActive(num <= 0);
			}
			List<ComPetTipsUnitData> tips = new List<ComPetTipsUnitData>();
			this._GetPetTipsData(ref tips);
			if (null != this.comPetTips)
			{
				this.comPetTips.setTips(tips);
			}
		}

		// Token: 0x0600FE04 RID: 65028 RVA: 0x0046314F File Offset: 0x0046154F
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetItemsInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdatePetList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetSlotChanged, new ClientEventSystem.UIEventHandler(this._OnPetSlotChanged));
		}

		// Token: 0x0600FE05 RID: 65029 RVA: 0x00463188 File Offset: 0x00461588
		private void _AddPetAttributesData(ref List<ComPetTipsUnitData> datas)
		{
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			if (onUsePetList != null && datas != null)
			{
				Dictionary<string, PetTotalTipsFrame.TipsUnitData> dictionary = new Dictionary<string, PetTotalTipsFrame.TipsUnitData>();
				for (int i = 0; i < onUsePetList.Count; i++)
				{
					PetInfo petInfo = onUsePetList[i];
					if (petInfo != null)
					{
						PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)petInfo.dataId, string.Empty, string.Empty);
						if (tableItem != null)
						{
							List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(tableItem.InnateSkill, (byte)petInfo.level, FightTypeLabel.PVE);
							if (skillDesList != null)
							{
								for (int j = 0; j < skillDesList.Count; j++)
								{
									if (!string.IsNullOrEmpty(skillDesList[j]))
									{
										Match match = this.m_regex.Match(skillDesList[j]);
										if (match.Success)
										{
											float num = 0f;
											if (float.TryParse(match.Groups[2].Value, out num))
											{
												string value = match.Groups[1].Value;
												if (dictionary.ContainsKey(value))
												{
													dictionary[value].value += num;
												}
												else
												{
													dictionary[value] = new PetTotalTipsFrame.TipsUnitData
													{
														append = match.Groups[3].Value,
														value = 0f
													};
													dictionary[value].value = num;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				Dictionary<string, PetTotalTipsFrame.TipsUnitData>.Enumerator enumerator = dictionary.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ComPetTipsUnitData comPetTipsUnitData = new ComPetTipsUnitData();
					comPetTipsUnitData.eComPetTipsUnitType = ComPetTipsUnitType.CPTUT_CONTENT;
					ComPetTipsUnitData comPetTipsUnitData2 = comPetTipsUnitData;
					string key = "pet_tips_attr";
					KeyValuePair<string, PetTotalTipsFrame.TipsUnitData> keyValuePair = enumerator.Current;
					object key2 = keyValuePair.Key;
					KeyValuePair<string, PetTotalTipsFrame.TipsUnitData> keyValuePair2 = enumerator.Current;
					object arg = keyValuePair2.Value.value;
					KeyValuePair<string, PetTotalTipsFrame.TipsUnitData> keyValuePair3 = enumerator.Current;
					comPetTipsUnitData2.content = TR.Value(key, key2, arg, keyValuePair3.Value.append);
					ComPetTipsUnitData item = comPetTipsUnitData;
					datas.Add(item);
				}
			}
		}

		// Token: 0x0600FE06 RID: 65030 RVA: 0x004633B4 File Offset: 0x004617B4
		private void _AddSeperateLine(ref List<ComPetTipsUnitData> datas)
		{
			datas.Add(new ComPetTipsUnitData
			{
				eComPetTipsUnitType = ComPetTipsUnitType.CPTUT_SPERATE_LINE,
				content = string.Empty
			});
		}

		// Token: 0x0600FE07 RID: 65031 RVA: 0x004633E4 File Offset: 0x004617E4
		private void _AddPetSkillsData(ref List<ComPetTipsUnitData> datas)
		{
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			if (onUsePetList != null && datas != null)
			{
				for (int i = 0; i < onUsePetList.Count; i++)
				{
					PetInfo petInfo = onUsePetList[i];
					if (petInfo != null)
					{
						int petSkillIDByJob = PetDataManager.GetPetSkillIDByJob((int)petInfo.dataId, DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)petInfo.skillIndex);
						if (DataManager<SkillDataManager>.GetInstance().GetSkillDesList(petSkillIDByJob, (byte)petInfo.level, FightTypeLabel.PVE) != null)
						{
							SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(petSkillIDByJob, string.Empty, string.Empty);
							if (tableItem != null)
							{
								PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)petInfo.dataId, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									if (datas.Count > 0)
									{
										this._AddSeperateLine(ref datas);
									}
									datas.Add(new ComPetTipsUnitData
									{
										eComPetTipsUnitType = ComPetTipsUnitType.CPTUT_TITLE,
										content = TR.Value("pet_tips_skill_head", DataManager<PetDataManager>.GetInstance().GetColorName(tableItem2.Name, tableItem2.Quality), tableItem.Name)
									});
									string[] array = DataManager<PetDataManager>.GetInstance().GetPetCurSkillTips(tableItem2, DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)petInfo.skillIndex, (int)petInfo.level, false).Split(new char[]
									{
										'\r',
										'\n'
									});
									for (int j = 0; j < array.Length; j++)
									{
										if (!string.IsNullOrEmpty(array[j]))
										{
											datas.Add(new ComPetTipsUnitData
											{
												eComPetTipsUnitType = ComPetTipsUnitType.CPTUT_CONTENT,
												content = string.Format(TR.Value("pet_tips_skill_attr"), array[j])
											});
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600FE08 RID: 65032 RVA: 0x004635AC File Offset: 0x004619AC
		private void _GetPetTipsData(ref List<ComPetTipsUnitData> datas)
		{
			datas.Clear();
			if (DataManager<PetDataManager>.GetInstance().GetOnUsePetList().Count > 0)
			{
				datas.Add(new ComPetTipsUnitData
				{
					eComPetTipsUnitType = ComPetTipsUnitType.CPTUT_TITLE,
					content = TR.Value("pet_tips_attr_head")
				});
				this._AddPetAttributesData(ref datas);
				this._AddPetSkillsData(ref datas);
			}
		}

		// Token: 0x04009FF7 RID: 40951
		[UIControl("", typeof(ComPetTipsUnit), 0)]
		private ComPetTipsUnit comPetTips;

		// Token: 0x04009FF8 RID: 40952
		private Regex m_regex = new Regex("([^\\d]*)(\\d+\\.?\\d*)(%?)$");

		// Token: 0x04009FF9 RID: 40953
		[UIControl("mark/Text", typeof(Text), 0)]
		private Text headDesc;

		// Token: 0x04009FFA RID: 40954
		[UIControl("ScrollView/ViewPort/HintText", typeof(Text), 0)]
		private Text hintText;

		// Token: 0x02001983 RID: 6531
		private class TipsUnitData
		{
			// Token: 0x04009FFB RID: 40955
			public float value;

			// Token: 0x04009FFC RID: 40956
			public string append;
		}
	}
}
