using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001373 RID: 4979
	public class ActiveItemObject : CachedObject
	{
		// Token: 0x0600C122 RID: 49442 RVA: 0x002DE1FC File Offset: 0x002DC5FC
		public static void Clear()
		{
			if (ActiveItemObject.ms_kStringBuilder != null)
			{
				StringBuilderCache.Release(ActiveItemObject.ms_kStringBuilder);
				ActiveItemObject.ms_kStringBuilder = null;
			}
		}

		// Token: 0x17001BB0 RID: 7088
		// (get) Token: 0x0600C123 RID: 49443 RVA: 0x002DE218 File Offset: 0x002DC618
		public ActiveManager.ActivityData ActiveItem
		{
			get
			{
				return this.activeItem;
			}
		}

		// Token: 0x0600C124 RID: 49444 RVA: 0x002DE220 File Offset: 0x002DC620
		private void _InitVarBinder()
		{
		}

		// Token: 0x0600C125 RID: 49445 RVA: 0x002DE224 File Offset: 0x002DC624
		private void _InitKeyValuePair()
		{
			this.m_akKeyValuePairObjects.Clear();
			this.m_akSliders.Clear();
			if (!string.IsNullOrEmpty(this.activeItem.activeItem.UpdateDesc))
			{
				string[] array = this.activeItem.activeItem.UpdateDesc.Split(new char[]
				{
					'\r',
					'\n'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						Match match = KeyValuePairObject.kvRegex.Match(array[i]);
						if (!string.IsNullOrEmpty(match.Groups[0].Value))
						{
							Match match2 = KeyValuePairObject.kvContent.Match(match.Groups[2].Value);
							if (!string.IsNullOrEmpty(match2.Groups[0].Value))
							{
								Text text = Utility.FindComponent<Text>(this.goLocal, match.Groups[1].Value, true);
								if (!(text == null))
								{
									KeyValuePairObject keyValuePairObject = new KeyValuePairObject();
									keyValuePairObject.text = text;
									keyValuePairObject.key = match2.Groups[1].Value;
									keyValuePairObject.v = match2.Groups[2].Value;
									keyValuePairObject.eKVMode = (KeyValuePairObject.KVMode)int.Parse(match2.Groups[3].Value);
									keyValuePairObject.kPreContent = match.Groups[2].Value.Substring(0, match2.Index);
									keyValuePairObject.kAftContent = match.Groups[2].Value.Substring(match2.Index + match2.Length, match.Groups[2].Value.Length - (match2.Index + match2.Length));
									if (!string.IsNullOrEmpty(match2.Groups[4].Value) && !string.IsNullOrEmpty(match2.Groups[5].Value))
									{
										keyValuePairObject.enableColor = match2.Groups[4].Value;
										keyValuePairObject.disableColor = match2.Groups[5].Value;
										keyValuePairObject.bHasColor = true;
									}
									this.m_akKeyValuePairObjects.Add(keyValuePairObject);
								}
							}
						}
						else
						{
							match = SliderObject.kvRegex.Match(array[i]);
							if (!string.IsNullOrEmpty(match.Groups[0].Value))
							{
								Slider slider = Utility.FindComponent<Slider>(this.goLocal, match.Groups[1].Value, true);
								if (!(slider == null))
								{
									SliderObject sliderObject = new SliderObject();
									sliderObject.slider = slider;
									sliderObject.key = match.Groups[2].Value;
									sliderObject.v = match.Groups[3].Value;
									sliderObject.eKVMode = (KeyValuePairObject.KVMode)int.Parse(match.Groups[4].Value);
									this.m_akSliders.Add(sliderObject);
								}
							}
							else
							{
								match = FullLevelObject.kvRegex.Match(array[i]);
								if (match.Success)
								{
									GameObject gameObject = Utility.FindChild(this.goLocal, match.Groups[1].Value);
									if (null != gameObject)
									{
										FullLevelObject fullLevelObject = new FullLevelObject();
										fullLevelObject.gameObject = gameObject;
										this.m_akFullObjects.Add(fullLevelObject);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C126 RID: 49446 RVA: 0x002DE5C4 File Offset: 0x002DC9C4
		private void _UpdateKeyValuePair()
		{
			for (int i = 0; i < this.m_akKeyValuePairObjects.Count; i++)
			{
				KeyValuePairObject keyValuePairObject = this.m_akKeyValuePairObjects[i];
				if (keyValuePairObject != null)
				{
					KeyValuePairObject.KVMode eKVMode = keyValuePairObject.eKVMode;
					if (eKVMode != KeyValuePairObject.KVMode.KVM_KV)
					{
						if (eKVMode != KeyValuePairObject.KVMode.KVM_KK)
						{
							if (eKVMode == KeyValuePairObject.KVMode.KVM_REPLACE)
							{
								int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, keyValuePairObject.key, 0);
								if (keyValuePairObject.bHasColor)
								{
									keyValuePairObject.text.text = string.Format("{0}<color={1}>{2}</color>{3}", new object[]
									{
										keyValuePairObject.kPreContent,
										keyValuePairObject.enableColor,
										activeItemValue,
										keyValuePairObject.kAftContent
									});
								}
								else
								{
									keyValuePairObject.text.text = keyValuePairObject.kPreContent + activeItemValue + keyValuePairObject.kAftContent;
								}
							}
						}
						else
						{
							int activeItemValue2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, keyValuePairObject.key, 0);
							int activeItemValue3 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, keyValuePairObject.v, 0);
							if (keyValuePairObject.bHasColor)
							{
								keyValuePairObject.text.text = string.Format("{1}<color={0}>{2}/{3}</color>{4}", new object[]
								{
									(activeItemValue2 < activeItemValue3) ? keyValuePairObject.disableColor : keyValuePairObject.enableColor,
									keyValuePairObject.kPreContent,
									activeItemValue2,
									activeItemValue3,
									keyValuePairObject.kAftContent
								});
							}
							else
							{
								keyValuePairObject.text.text = string.Concat(new object[]
								{
									keyValuePairObject.kPreContent,
									activeItemValue2,
									"/",
									activeItemValue3,
									keyValuePairObject.kAftContent
								});
							}
						}
					}
					else
					{
						int activeItemValue4 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, keyValuePairObject.key, 0);
						int num = 0;
						if (int.TryParse(keyValuePairObject.v, out num))
						{
							if (keyValuePairObject.bHasColor)
							{
								keyValuePairObject.text.text = string.Format("{1}<color={0}>{2}/{3}</color>{4}", new object[]
								{
									(activeItemValue4 < num) ? keyValuePairObject.disableColor : keyValuePairObject.enableColor,
									keyValuePairObject.kPreContent,
									activeItemValue4,
									num,
									keyValuePairObject.kAftContent
								});
							}
							else
							{
								keyValuePairObject.text.text = string.Concat(new object[]
								{
									keyValuePairObject.kPreContent,
									activeItemValue4,
									"/",
									num,
									keyValuePairObject.kAftContent
								});
							}
						}
					}
				}
			}
			for (int j = 0; j < this.m_akSliders.Count; j++)
			{
				SliderObject sliderObject = this.m_akSliders[j];
				if (sliderObject != null)
				{
					KeyValuePairObject.KVMode eKVMode2 = sliderObject.eKVMode;
					if (eKVMode2 != KeyValuePairObject.KVMode.KVM_KV)
					{
						if (eKVMode2 != KeyValuePairObject.KVMode.KVM_KK)
						{
							if (eKVMode2 == KeyValuePairObject.KVMode.KVM_REPLACE)
							{
								Logger.LogErrorFormat("MODE ERROR !!", new object[0]);
							}
						}
						else
						{
							int activeItemValue5 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, sliderObject.key, 0);
							int num2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, sliderObject.v, 0);
							if (num2 <= 0)
							{
								num2 = 1;
							}
							sliderObject.slider.value = Mathf.Clamp01((float)activeItemValue5 * 1f / (float)num2);
						}
					}
					else
					{
						int activeItemValue6 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, sliderObject.key, 0);
						int num3 = 0;
						if (int.TryParse(sliderObject.v, out num3))
						{
						}
						if (num3 <= 0)
						{
							num3 = 1;
						}
						sliderObject.slider.value = Mathf.Clamp01((float)activeItemValue6 * 1f / (float)num3);
					}
				}
			}
			for (int k = 0; k < this.m_akFullObjects.Count; k++)
			{
				this.m_akFullObjects[k].Update();
			}
		}

		// Token: 0x0600C127 RID: 49447 RVA: 0x002DEA30 File Offset: 0x002DCE30
		public override void OnCreate(object[] param)
		{
			this.goParent = (param[0] as GameObject);
			this.goPrefab = (param[1] as GameObject);
			this.activeItem = (param[2] as ActiveManager.ActivityData);
			this.activeData = (param[3] as ActiveManager.ActiveData);
			this.localKey = (param[4] as string);
			this.THIS = (param[5] as ActiveChargeFrame);
			if (this.goLocal == null && this.goPrefab == null)
			{
				return;
			}
			if (this.goLocal == null)
			{
				this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
				Utility.AttachTo(this.goLocal, this.goParent, false);
				this._BindKeyValuePair();
				this._CreateAwards();
				this._InitVarBinder();
				this._InitKeyValuePair();
				this.comLevelFull = this.goLocal.GetComponent<LevelFullControl>();
			}
			this.goLocal.name = this.activeItem.activeItem.ID.ToString();
			this.Enable();
			this._Initialize();
			this._UpdateItem();
		}

		// Token: 0x0600C128 RID: 49448 RVA: 0x002DEB4C File Offset: 0x002DCF4C
		public static int Cmp(ActiveManager.ActivityData left, ActiveManager.ActivityData right)
		{
			if (left.activeItem.SortPriority != right.activeItem.SortPriority)
			{
				return left.activeItem.SortPriority - right.activeItem.SortPriority;
			}
			if (left.status != right.status)
			{
				return ActiveItemObject.ms_sort_order[(int)left.status] - ActiveItemObject.ms_sort_order[(int)right.status];
			}
			if (left.activeItem.SortPriority2 != right.activeItem.SortPriority2)
			{
				return left.activeItem.SortPriority2 - right.activeItem.SortPriority2;
			}
			return left.activeItem.ID - right.activeItem.ID;
		}

		// Token: 0x0600C129 RID: 49449 RVA: 0x002DEC04 File Offset: 0x002DD004
		public static int Cmp(ActiveItemObject left, ActiveItemObject right)
		{
			if (left.ActiveItem.activeItem.SortPriority != right.activeItem.activeItem.SortPriority)
			{
				return left.activeItem.activeItem.SortPriority - right.activeItem.activeItem.SortPriority;
			}
			if (left.ActiveItem.status != right.ActiveItem.status)
			{
				return ActiveItemObject.ms_sort_order[(int)left.ActiveItem.status] - ActiveItemObject.ms_sort_order[(int)right.ActiveItem.status];
			}
			if (left.ActiveItem.activeItem.SortPriority2 != right.activeItem.activeItem.SortPriority2)
			{
				return left.activeItem.activeItem.SortPriority2 - right.activeItem.activeItem.SortPriority2;
			}
			return left.ActiveItem.activeItem.ID - right.activeItem.activeItem.ID;
		}

		// Token: 0x0600C12A RID: 49450 RVA: 0x002DECFF File Offset: 0x002DD0FF
		public override void SetAsLastSibling()
		{
			if (this.goLocal != null)
			{
				this.goLocal.transform.SetAsLastSibling();
			}
		}

		// Token: 0x0600C12B RID: 49451 RVA: 0x002DED24 File Offset: 0x002DD124
		private void _CreateAwards()
		{
			try
			{
				this.goAwardParent = null;
				if (!string.IsNullOrEmpty(this.activeData.mainItem.awardparent))
				{
					string[] array = this.activeData.mainItem.awardparent.Split(new char[]
					{
						'\r',
						'\n'
					});
					for (int i = 0; i < array.Length; i++)
					{
						Match match = ActiveItemObject.s_award.Match(array[i]);
						if (!string.IsNullOrEmpty(match.Groups[0].Value) && match.Groups[1].Value == this.localKey)
						{
							this.goAwardParent = Utility.FindChild(this.goLocal, match.Groups[3].Value);
							break;
						}
					}
				}
				if (this.goAwardParent != null)
				{
					bool flag = false;
					if (!string.IsNullOrEmpty(this.activeItem.activeItem.DanymicAwards))
					{
						flag = true;
						Match match2 = ActiveItemObject.s_dynamic_award.Match(this.activeItem.activeItem.DanymicAwards);
						if (match2 != null && !string.IsNullOrEmpty(match2.Groups[0].Value))
						{
							int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, match2.Groups[3].Value, 0);
							for (int j = 0; j < activeItemValue; j++)
							{
								int activeItemValue2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, match2.Groups[2].Value + (j + 1).ToString(), 0);
								ItemData itemData = ItemDataManager.CreateItemDataFromTable(activeItemValue2, 100, 0);
								if (itemData != null)
								{
									int activeItemValue3 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.activeItem.activeItem.ID, match2.Groups[1].Value + (j + 1).ToString(), 0);
									if (activeItemValue3 > 0)
									{
										itemData.Count = activeItemValue3;
										ComItem comItem = this.THIS.CreateComItem(this.goAwardParent);
										if (comItem != null)
										{
											comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
											{
												DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
											});
										}
									}
								}
							}
						}
						else
						{
							Logger.LogErrorFormat("MATCH ERROR WITH DanymicAwards ActiveID is {0}", new object[]
							{
								this.activeItem.activeItem.ID
							});
						}
					}
					if (!flag && !string.IsNullOrEmpty(this.activeItem.activeItem.Awards))
					{
						string[] array2 = this.activeItem.activeItem.Awards.Split(new char[]
						{
							','
						});
						for (int k = 0; k < array2.Length; k++)
						{
							if (!string.IsNullOrEmpty(array2[k]))
							{
								string[] array3 = array2[k].Split(new char[]
								{
									'_'
								});
								if (array3.Length == 2)
								{
									int tableId = int.Parse(array3[0]);
									int count = int.Parse(array3[1]);
									ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
									if (itemData2 != null)
									{
										itemData2.Count = count;
										ComItem comItem2 = this.THIS.CreateComItem(this.goAwardParent);
										comItem2.Setup(itemData2, new ComItem.OnItemClicked(this.OnItemClicked));
									}
								}
								else if (array3.Length == 4)
								{
									int tableId2 = int.Parse(array3[0]);
									int count2 = int.Parse(array3[1]);
									int equipType = int.Parse(array3[2]);
									int strengthenLevel = int.Parse(array3[3]);
									ItemData itemData3 = ItemDataManager.CreateItemDataFromTable(tableId2, 100, 0);
									if (itemData3 != null)
									{
										itemData3.Count = count2;
										itemData3.EquipType = (EEquipType)equipType;
										itemData3.StrengthenLevel = strengthenLevel;
										ComItem comItem3 = this.THIS.CreateComItem(this.goAwardParent);
										comItem3.Setup(itemData3, new ComItem.OnItemClicked(this.OnItemClicked));
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600C12C RID: 49452 RVA: 0x002DF18C File Offset: 0x002DD58C
		private void _BindKeyValuePair()
		{
			try
			{
				this.m_akKey2ValueGroup.Clear();
				string[] array = this.activeItem.activeItem.Desc.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						IEnumerator enumerator = ActiveItemObject.s_regex_content.Matches(array[i]).GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								Match match = (Match)obj;
								ValueObject valueObject = new ValueObject();
								valueObject.kOrgValue = match.Groups[2].Value;
								valueObject.kKey = match.Groups[1].Value;
								if (!this.m_akKey2ValueGroup.ContainsKey(valueObject.kKey))
								{
									this.m_akKey2ValueGroup.Add(valueObject.kKey, valueObject);
								}
							}
						}
						finally
						{
							IDisposable disposable;
							if ((disposable = (enumerator as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600C12D RID: 49453 RVA: 0x002DF2E4 File Offset: 0x002DD6E4
		private string _ParseText(string content)
		{
			if (ActiveItemObject.ms_kStringBuilder == null)
			{
				ActiveItemObject.ms_kStringBuilder = StringBuilderCache.Acquire(256);
			}
			MyExtensionMethods.Clear(ActiveItemObject.ms_kStringBuilder);
			int num = 0;
			for (int i = 0; i < ActiveItemObject.ms_missionkey_regex.Length; i++)
			{
				IEnumerator enumerator = ActiveItemObject.ms_missionkey_regex[i].Matches(content).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Match curMatch = (Match)enumerator.Current;
						ActiveItemObject.ms_kStringBuilder.Append(content.Substring(num, curMatch.Index - num));
						ActiveItemObject.ActiveKeyType activeKeyType = (ActiveItemObject.ActiveKeyType)i;
						if (activeKeyType != ActiveItemObject.ActiveKeyType.AKT_KEY)
						{
							if (activeKeyType != ActiveItemObject.ActiveKeyType.AKT_KEY_KEY)
							{
								if (activeKeyType == ActiveItemObject.ActiveKeyType.AKT_KEY_VALUE)
								{
									TaskPair taskPair = this.activeItem.akActivityValues.Find((TaskPair x) => x.key == curMatch.Groups[1].Value);
									string arg = (taskPair == null) ? "0" : taskPair.value;
									ActiveItemObject.ms_kStringBuilder.AppendFormat("{0}/{1}", arg, curMatch.Groups[2].Value);
								}
							}
							else
							{
								TaskPair taskPair2 = this.activeItem.akActivityValues.Find((TaskPair x) => x.key == curMatch.Groups[1].Value);
								string arg2 = (taskPair2 == null) ? "0" : taskPair2.value;
								taskPair2 = this.activeItem.akActivityValues.Find((TaskPair x) => x.key == curMatch.Groups[2].Value);
								string arg3 = (taskPair2 == null) ? "0" : taskPair2.value;
								ActiveItemObject.ms_kStringBuilder.AppendFormat("{0}/{1}", arg2, arg3);
							}
						}
						else
						{
							TaskPair taskPair3 = this.activeItem.akActivityValues.Find((TaskPair x) => x.key == curMatch.Groups[1].Value);
							if (taskPair3 != null)
							{
								ActiveItemObject.ms_kStringBuilder.Append(taskPair3.value);
							}
							else
							{
								ActiveItemObject.ms_kStringBuilder.Append("0");
							}
						}
						num = curMatch.Index + curMatch.Length;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			ActiveItemObject.ms_kStringBuilder.Append(content.Substring(num, content.Length - num));
			return ActiveItemObject.ms_kStringBuilder.ToString();
		}

		// Token: 0x0600C12E RID: 49454 RVA: 0x002DF558 File Offset: 0x002DD958
		private void _StatusFilter()
		{
			if (this.m_kControlData == null)
			{
				if (this.activeData == null || this.activeData.values == null)
				{
					return;
				}
				if (!this.activeData.values.TryGetValue(this.localKey, out this.m_kControlData))
				{
					return;
				}
			}
			if (this.m_kControlData != null)
			{
				bool isLevelFull = DataManager<PlayerBaseData>.GetInstance().IsLevelFull;
				for (int i = 0; i < this.m_kControlData.Count; i++)
				{
					ActiveManager.ControlData controlData = this.m_kControlData[i];
					if (controlData != null && controlData.Type != ActiveManager.ControlData.ControlDataType.CDT_INVALID)
					{
						switch (controlData.Type)
						{
						case ActiveManager.ControlData.ControlDataType.CDT_IMAGE:
						{
							Image image = Utility.FindComponent<Image>(this.goLocal, controlData.Name, true);
							if (image != null)
							{
								bool flag = controlData.NeedShow((int)this.activeItem.status);
								if ((this.activeData.iActiveID == 8100 || this.activeData.iActiveID == 8200) && this.activeItem.status == 0)
								{
									flag = false;
								}
								if (flag && isLevelFull && this.activeItem.activeItem.IsWorkWithFullLevel == 0 && this.activeItem.status >= 0 && this.activeItem.status <= 2)
								{
									flag = false;
								}
								image.gameObject.CustomActive(flag);
								ActiveManager.ControlData.StatusValue statusValue = controlData.GetStatusValue((int)this.activeItem.status);
								if (statusValue != null)
								{
									ETCImageLoader.LoadSprite(ref image, statusValue.value, true);
								}
							}
							break;
						}
						case ActiveManager.ControlData.ControlDataType.CDT_BUTTON:
						{
							Button button = Utility.FindComponent<Button>(this.goLocal, controlData.Name, true);
							if (button != null)
							{
								bool flag2 = controlData.NeedShow((int)this.activeItem.status);
								if (flag2 && isLevelFull && this.activeItem.activeItem.IsWorkWithFullLevel == 0 && this.activeItem.status >= 0 && this.activeItem.status <= 2)
								{
									flag2 = false;
								}
								button.gameObject.CustomActive(flag2);
								button.onClick.RemoveAllListeners();
								if (flag2)
								{
									OnClickActive comActive = button.gameObject.GetComponent<OnClickActive>();
									button.onClick.AddListener(delegate()
									{
										if (!DataManager<ActiveManager>.GetInstance()._CheckCanJumpGo(this.activeItem.activeItem.LinkLimit, true))
										{
											return;
										}
										if (comActive.m_eOnClickCloseType == OnClickActive.OnClickCloseType.OCCT_PRE)
										{
											ClientFrameBinder componentInParent = comActive.GetComponentInParent<ClientFrameBinder>();
											if (null != componentInParent)
											{
												componentInParent.CloseFrame(true);
											}
										}
										DataManager<ActiveManager>.GetInstance().OnClickActivity(this.activeData, comActive, this.activeItem);
										if (comActive.m_eOnClickCloseType == OnClickActive.OnClickCloseType.OCCT_AFT)
										{
											ClientFrameBinder componentInParent2 = comActive.GetComponentInParent<ClientFrameBinder>();
											if (null != componentInParent2)
											{
												componentInParent2.CloseFrame(true);
											}
										}
									});
								}
							}
							break;
						}
						case ActiveManager.ControlData.ControlDataType.CDT_TEXT:
						{
							Text text = Utility.FindComponent<Text>(this.goLocal, controlData.Name, true);
							if (text != null)
							{
								bool flag3 = controlData.NeedShow((int)this.activeItem.status);
								if (flag3 && isLevelFull && this.activeItem.activeItem.IsWorkWithFullLevel == 0 && this.activeItem.status >= 0 && this.activeItem.status <= 2)
								{
									flag3 = false;
								}
								text.gameObject.CustomActive(flag3);
								ActiveManager.ControlData.StatusValue statusValue2 = controlData.GetStatusValue((int)this.activeItem.status);
								if (statusValue2 != null)
								{
									text.text = statusValue2.value;
								}
							}
							break;
						}
						case ActiveManager.ControlData.ControlDataType.CDT_GAMEOBJECT:
						{
							GameObject gameObject = Utility.FindChild(this.goLocal, controlData.Name);
							bool flag4 = controlData.NeedShow((int)this.activeItem.status);
							if (flag4 && isLevelFull && this.activeItem.activeItem.IsWorkWithFullLevel == 0 && this.activeItem.status >= 0 && this.activeItem.status <= 2)
							{
								flag4 = false;
							}
							gameObject.CustomActive(flag4);
							break;
						}
						}
					}
				}
			}
		}

		// Token: 0x0600C12F RID: 49455 RVA: 0x002DF924 File Offset: 0x002DDD24
		private void _UpdateText()
		{
			if (this.activeItem != null && !string.IsNullOrEmpty(this.activeData.mainItem.Desc))
			{
				IEnumerator enumerator = ActiveItemObject.s_regex.Matches(this.activeData.mainItem.Desc).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Match match = (Match)obj;
						string value = match.Groups[1].Value;
						if (value == this.localKey)
						{
							int num = int.Parse(match.Groups[2].Value);
							string value2 = match.Groups[3].Value;
							string value3 = match.Groups[4].Value;
							Text text = Utility.FindComponent<Text>(this.goLocal, value3, true);
							if (text != null && this.m_akKey2ValueGroup.ContainsKey(value2))
							{
								ValueObject valueObject = this.m_akKey2ValueGroup[value2];
								if (valueObject != null)
								{
									text.text = this._ParseText(valueObject.kOrgValue);
								}
							}
						}
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}

		// Token: 0x0600C130 RID: 49456 RVA: 0x002DFA78 File Offset: 0x002DDE78
		private void _Initialize()
		{
			if (!string.IsNullOrEmpty(this.activeItem.activeItem.InitDesc))
			{
				string[] array = this.activeItem.activeItem.InitDesc.Split(new char[]
				{
					'\r',
					'\n'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						for (int j = 0; j < ActiveItemObject.ms_initkeys.Length; j++)
						{
							Match match = ActiveItemObject.ms_initkeys[j].Match(array[i]);
							if (match != null && !string.IsNullOrEmpty(match.Groups[0].Value))
							{
								ActiveItemObject.InitializeKeyType initializeKeyType = (ActiveItemObject.InitializeKeyType)j;
								if (initializeKeyType != ActiveItemObject.InitializeKeyType.IKT_SHOW)
								{
									if (initializeKeyType == ActiveItemObject.InitializeKeyType.IKT_VALUE)
									{
										string value = match.Groups[3].Value;
										if (value != null)
										{
											if (!(value == "Text"))
											{
												if (!(value == "Image"))
												{
													if (value == "UINumber")
													{
														UINumber uinumber = Utility.FindComponent<UINumber>(this.goLocal, match.Groups[2].Value, true);
														int num = -1;
														if (null != uinumber && int.TryParse(match.Groups[4].Value, out num))
														{
															uinumber.gameObject.CustomActive(true);
															uinumber.Value = num;
														}
														else
														{
															if (null == uinumber)
															{
																Logger.LogErrorFormat("can not find component with path = {0}", new object[]
																{
																	match.Groups[2].Value
																});
															}
															if (num == -1)
															{
																Logger.LogErrorFormat("int.TraParse error value = {0} can not be converned to int type!", new object[]
																{
																	match.Groups[4].Value
																});
															}
														}
													}
												}
												else
												{
													Image image = Utility.FindComponent<Image>(this.goLocal, match.Groups[2].Value, true);
													if (null != image)
													{
														image.CustomActive(true);
														image.enabled = true;
														ETCImageLoader.LoadSprite(ref image, match.Groups[4].Value, true);
													}
												}
											}
											else
											{
												Text text = Utility.FindComponent<Text>(this.goLocal, match.Groups[2].Value, true);
												if (null != text)
												{
													text.CustomActive(true);
													text.enabled = true;
													text.text = match.Groups[4].Value;
												}
											}
										}
									}
								}
								else
								{
									GameObject gameObject = Utility.FindChild(this.goLocal, match.Groups[2].Value);
									if (gameObject != null)
									{
										gameObject.CustomActive(true);
									}
								}
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C131 RID: 49457 RVA: 0x002DFD5C File Offset: 0x002DE15C
		private void OnItemClicked(GameObject gameObject, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600C132 RID: 49458 RVA: 0x002DFD6E File Offset: 0x002DE16E
		public override void OnRecycle()
		{
			this.Disable();
		}

		// Token: 0x0600C133 RID: 49459 RVA: 0x002DFD76 File Offset: 0x002DE176
		public override void Enable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(true);
			}
		}

		// Token: 0x0600C134 RID: 49460 RVA: 0x002DFD95 File Offset: 0x002DE195
		public override void Disable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x0600C135 RID: 49461 RVA: 0x002DFDB4 File Offset: 0x002DE1B4
		public override void OnDecycle(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x0600C136 RID: 49462 RVA: 0x002DFDBD File Offset: 0x002DE1BD
		public override void OnRefresh(object[] param)
		{
			this._UpdateItem();
		}

		// Token: 0x0600C137 RID: 49463 RVA: 0x002DFDC5 File Offset: 0x002DE1C5
		public override bool NeedFilter(object[] param)
		{
			return false;
		}

		// Token: 0x0600C138 RID: 49464 RVA: 0x002DFDC8 File Offset: 0x002DE1C8
		private void _UpdateItem()
		{
			try
			{
				this._UpdateText();
				this._StatusFilter();
				this._UpdateVarBinder();
				this._UpdateKeyValuePair();
				if (null != this.comLevelFull)
				{
					this.comLevelFull.BindActiveID = this.activeItem.activeItem.ID;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600C139 RID: 49465 RVA: 0x002DFE40 File Offset: 0x002DE240
		private void _UpdateVarBinder()
		{
		}

		// Token: 0x04006D33 RID: 27955
		private static Regex[] ms_missionkey_regex = new Regex[]
		{
			new Regex("<key>key=(\\w+)</key>"),
			new Regex("<key>key=(\\w+)/value=(\\d+)</key>"),
			new Regex("<key>key=(\\w+)/key=(\\w+)</key>")
		};

		// Token: 0x04006D34 RID: 27956
		private static Regex s_regex_content = new Regex("<keyname=(\\w+) valuegroup=(.+)>", RegexOptions.Singleline);

		// Token: 0x04006D35 RID: 27957
		private static Regex s_regex = new Regex("<prefabkey=(\\w+) type=(\\d+) key=(\\w+) value=([A-Za-z0-9_/]+)>", RegexOptions.Singleline);

		// Token: 0x04006D36 RID: 27958
		private static Regex s_award = new Regex("<prefabkey=(\\w+) key=(\\d+) value=(.+)>", RegexOptions.Singleline);

		// Token: 0x04006D37 RID: 27959
		private static Regex s_dynamic_award = new Regex("<KeyNum=(\\w+) KeyId=(\\w+) KeySize=(\\w+)>", RegexOptions.Singleline);

		// Token: 0x04006D38 RID: 27960
		private static Regex[] ms_initkeys = new Regex[]
		{
			new Regex("<prefabkey=(\\w+) localpath=([A-Za-z0-9/]+)>"),
			new Regex("<prefabkey=(\\w+) localpath=([A-Za-z0-9/]+) type=(\\w+) value=(.+)>")
		};

		// Token: 0x04006D39 RID: 27961
		private static Regex s_init_key0 = new Regex("<localpath=(\\w+)>", RegexOptions.Singleline);

		// Token: 0x04006D3A RID: 27962
		public static StringBuilder ms_kStringBuilder;

		// Token: 0x04006D3B RID: 27963
		protected GameObject goLocal;

		// Token: 0x04006D3C RID: 27964
		protected GameObject goParent;

		// Token: 0x04006D3D RID: 27965
		protected GameObject goPrefab;

		// Token: 0x04006D3E RID: 27966
		protected GameObject goAwardParent;

		// Token: 0x04006D3F RID: 27967
		protected string localKey;

		// Token: 0x04006D40 RID: 27968
		protected LevelFullControl comLevelFull;

		// Token: 0x04006D41 RID: 27969
		private ActiveManager.ActivityData activeItem;

		// Token: 0x04006D42 RID: 27970
		private ActiveManager.ActiveData activeData;

		// Token: 0x04006D43 RID: 27971
		private Dictionary<string, ValueObject> m_akKey2ValueGroup = new Dictionary<string, ValueObject>();

		// Token: 0x04006D44 RID: 27972
		private ActiveChargeFrame THIS;

		// Token: 0x04006D45 RID: 27973
		private List<KeyValuePairObject> m_akKeyValuePairObjects = new List<KeyValuePairObject>();

		// Token: 0x04006D46 RID: 27974
		private List<SliderObject> m_akSliders = new List<SliderObject>();

		// Token: 0x04006D47 RID: 27975
		private List<FullLevelObject> m_akFullObjects = new List<FullLevelObject>();

		// Token: 0x04006D48 RID: 27976
		public static int[] ms_sort_order = new int[]
		{
			2,
			1,
			0,
			3,
			4,
			5
		};

		// Token: 0x04006D49 RID: 27977
		private List<ActiveManager.ControlData> m_kControlData;

		// Token: 0x02001374 RID: 4980
		private enum ActiveKeyType
		{
			// Token: 0x04006D4C RID: 27980
			AKT_KEY,
			// Token: 0x04006D4D RID: 27981
			AKT_KEY_VALUE,
			// Token: 0x04006D4E RID: 27982
			AKT_KEY_KEY,
			// Token: 0x04006D4F RID: 27983
			AKT_COUNT
		}

		// Token: 0x02001375 RID: 4981
		private enum InitializeKeyType
		{
			// Token: 0x04006D51 RID: 27985
			IKT_SHOW,
			// Token: 0x04006D52 RID: 27986
			IKT_VALUE,
			// Token: 0x04006D53 RID: 27987
			IKT_COUNT
		}
	}
}
