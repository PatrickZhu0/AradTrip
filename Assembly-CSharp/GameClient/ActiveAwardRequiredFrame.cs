using System;
using System.Text.RegularExpressions;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A31 RID: 6705
	internal class ActiveAwardRequiredFrame : ClientFrame
	{
		// Token: 0x06010785 RID: 67461 RVA: 0x004A2ABC File Offset: 0x004A0EBC
		public static void Open(ActiveAwardRequiredFrameData data)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActiveAwardRequiredFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActiveAwardRequiredFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveAwardRequiredFrame>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x06010786 RID: 67462 RVA: 0x004A2AEC File Offset: 0x004A0EEC
		private void _SetHeadTitle()
		{
			if (this.data != null && !string.IsNullOrEmpty(this.data.activityData.activeItem.UpdateDesc))
			{
				string[] array = this.data.activityData.activeItem.UpdateDesc.Split(new char[]
				{
					'\r',
					'\n'
				});
				ActiveManager.ActivityData activityData = this.data.activityData;
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
								if (!(match.Groups[1].Value != "Name"))
								{
									KeyValuePairObject keyValuePairObject = new KeyValuePairObject();
									keyValuePairObject.text = this.kName;
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
									KeyValuePairObject keyValuePairObject2 = keyValuePairObject;
									if (keyValuePairObject2 != null)
									{
										KeyValuePairObject.KVMode eKVMode = keyValuePairObject2.eKVMode;
										if (eKVMode != KeyValuePairObject.KVMode.KVM_KV)
										{
											if (eKVMode != KeyValuePairObject.KVMode.KVM_KK)
											{
												if (eKVMode == KeyValuePairObject.KVMode.KVM_REPLACE)
												{
													int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(activityData.activeItem.ID, keyValuePairObject2.key, 0);
													if (keyValuePairObject2.bHasColor)
													{
														keyValuePairObject2.text.text = string.Format("{0}<color={1}>{2}</color>{3}", new object[]
														{
															keyValuePairObject2.kPreContent,
															keyValuePairObject2.enableColor,
															activeItemValue,
															keyValuePairObject2.kAftContent
														});
													}
													else
													{
														keyValuePairObject2.text.text = keyValuePairObject2.kPreContent + activeItemValue + keyValuePairObject2.kAftContent;
													}
												}
											}
											else
											{
												int activeItemValue2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(activityData.activeItem.ID, keyValuePairObject2.key, 0);
												int activeItemValue3 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(activityData.activeItem.ID, keyValuePairObject2.v, 0);
												if (keyValuePairObject2.bHasColor)
												{
													keyValuePairObject2.text.text = string.Format("<color={0}>{1}{2}/{3}{4}</color>", new object[]
													{
														(activeItemValue2 < activeItemValue3) ? keyValuePairObject2.disableColor : keyValuePairObject2.enableColor,
														keyValuePairObject2.kPreContent,
														activeItemValue2,
														activeItemValue3,
														keyValuePairObject2.kAftContent
													});
												}
												else
												{
													keyValuePairObject2.text.text = string.Concat(new object[]
													{
														keyValuePairObject2.kPreContent,
														activeItemValue2,
														"/",
														activeItemValue3,
														keyValuePairObject2.kAftContent
													});
												}
											}
										}
										else
										{
											int activeItemValue4 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(activityData.activeItem.ID, keyValuePairObject2.key, 0);
											int num = 0;
											if (int.TryParse(keyValuePairObject2.v, out num))
											{
												if (keyValuePairObject2.bHasColor)
												{
													keyValuePairObject2.text.text = string.Format("<color={0}>{1}{2}/{3}{4}</color>", new object[]
													{
														(activeItemValue4 < num) ? keyValuePairObject2.disableColor : keyValuePairObject2.enableColor,
														keyValuePairObject2.kPreContent,
														activeItemValue4,
														num,
														keyValuePairObject2.kAftContent
													});
												}
												else
												{
													keyValuePairObject2.text.text = string.Concat(new object[]
													{
														keyValuePairObject2.kPreContent,
														activeItemValue4,
														"/",
														num,
														keyValuePairObject2.kAftContent
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
			}
		}

		// Token: 0x06010787 RID: 67463 RVA: 0x004A3028 File Offset: 0x004A1428
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as ActiveAwardRequiredFrameData);
			this.m_iCurCount = 1;
			this.m_eCountLimitType = ActiveAwardRequiredFrame.CountLimitType.CLT_MIN;
			this.m_inputCount.onValueChanged.RemoveAllListeners();
			this.m_inputCount.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			this.kName = Utility.FindComponent<Text>(this.frame, "Middle/Name", true);
			this.kCostNum = Utility.FindComponent<Text>(this.frame, "Bottom/ok/item/costnum", true);
			this.kCostIcon = Utility.FindComponent<Image>(this.frame, "Bottom/ok/item/icon", true);
			this.m_kSlider = Utility.FindComponent<Slider>(this.frame, "slider", true);
			this.m_kSlider.onValueChanged.AddListener(new UnityAction<float>(this._OnSliderValueChanged));
			this.m_iMaxValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "ct", 0);
			this.m_kSlider.value = 0f;
			this.kName.text = string.Format(TR.Value("award_acquire_hint"), this.data.activityData.activeItem.Param0, this.m_iMaxValue);
			this._OnValueChanged();
		}

		// Token: 0x06010788 RID: 67464 RVA: 0x004A316E File Offset: 0x004A156E
		private int _TransFloatValue2IntForSilder(float fValue, int m_iMaxValue)
		{
			if (m_iMaxValue <= 1)
			{
				return 1;
			}
			if (fValue <= 0f)
			{
				return 1;
			}
			if (fValue >= 1f)
			{
				return m_iMaxValue;
			}
			return (int)(fValue * (float)(m_iMaxValue - 1) + 1f);
		}

		// Token: 0x06010789 RID: 67465 RVA: 0x004A31A0 File Offset: 0x004A15A0
		private void _OnSliderValueChanged(float fValue)
		{
			this.m_iMaxValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "ct", 0);
			if (this.m_iMaxValue <= 1)
			{
				this.m_iCurCount = 1;
				if (this.m_kSlider.value != 0f)
				{
					this.m_kSlider.value = 0f;
				}
				if (this.m_inputCount.text != this.m_iCurCount.ToString())
				{
					this.m_inputCount.text = this.m_iCurCount.ToString();
				}
			}
			else
			{
				if (fValue <= 0f)
				{
					this.m_iCurCount = 1;
				}
				else if (fValue >= 1f)
				{
					this.m_iCurCount = this.m_iMaxValue;
				}
				else
				{
					this.m_iCurCount = (int)((float)(this.m_iMaxValue - 1) * fValue) + 1;
				}
				if (this.m_inputCount.text != this.m_iCurCount.ToString())
				{
					this.m_inputCount.text = this.m_iCurCount.ToString();
				}
			}
		}

		// Token: 0x0601078A RID: 67466 RVA: 0x004A32DC File Offset: 0x004A16DC
		protected void OnValueChanged(string value)
		{
			int iCurCount = 0;
			if (value.Length > 0)
			{
				int.TryParse(value, out iCurCount);
			}
			this.m_iCurCount = iCurCount;
			this.m_eCountLimitType = ActiveAwardRequiredFrame.CountLimitType.CLT_NORMAL;
			this._OnValueChanged();
		}

		// Token: 0x0601078B RID: 67467 RVA: 0x004A3314 File Offset: 0x004A1714
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0601078C RID: 67468 RVA: 0x004A3316 File Offset: 0x004A1716
		protected void _OnUpdate(UIEvent uiEvent)
		{
			this._OnValueChanged();
		}

		// Token: 0x0601078D RID: 67469 RVA: 0x004A331E File Offset: 0x004A171E
		[UIEventHandle("Background/title/closeicon")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<ActiveAwardRequiredFrame>(this, false);
		}

		// Token: 0x0601078E RID: 67470 RVA: 0x004A332D File Offset: 0x004A172D
		private void OnClickCancel()
		{
			this.frameMgr.CloseFrame<ActiveAwardRequiredFrame>(this, false);
		}

		// Token: 0x0601078F RID: 67471 RVA: 0x004A333C File Offset: 0x004A173C
		[UIEventHandle("Bottom/ok")]
		private void OnClickOK()
		{
			int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "ncs", 0);
			int activeItemValue2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "pcs", 0);
			int num = (this.data.eEventType != OnClickActive.EventType.EventType_NormalAcquireAward) ? activeItemValue2 : activeItemValue;
			int num2 = (this.data.eEventType != OnClickActive.EventType.EventType_NormalAcquireAward) ? DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) : DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num2, true);
			this.m_iMaxValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "ct", 0);
			if (this.m_iCurCount > this.m_iMaxValue)
			{
				SystemNotifyManager.SysNotifyTextAnimation("次数不足,无法找回!", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (ItemDataManager.CreateItemDataFromTable(num2, 100, 0) == null)
			{
				Logger.LogErrorFormat("can not find item with id={0}", new object[]
				{
					num2
				});
				return;
			}
			int iTargetID = this.data.activityData.ID % 100000000;
			int num3 = (this.data.eEventType != OnClickActive.EventType.EventType_NormalAcquireAward) ? 1 : 0;
			int iParam = num3 << 16 | (this.m_iCurCount & 255);
			iParam |= int.MinValue;
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
			{
				nMoneyID = num2,
				nCount = num * this.m_iCurCount
			}, delegate
			{
				DataManager<ActiveManager>.GetInstance().SendSubmitActivity(iTargetID, (uint)iParam);
				this.frameMgr.CloseFrame<ActiveAwardRequiredFrame>(this, false);
			}, "common_money_cost", null);
		}

		// Token: 0x06010790 RID: 67472 RVA: 0x004A3510 File Offset: 0x004A1910
		private void OnClickCancel2()
		{
			this.frameMgr.CloseFrame<ActiveAwardRequiredFrame>(this, false);
		}

		// Token: 0x06010791 RID: 67473 RVA: 0x004A351F File Offset: 0x004A191F
		private void OnClickMin()
		{
			this.m_eCountLimitType = ActiveAwardRequiredFrame.CountLimitType.CLT_MIN;
			this.m_iCurCount = 1;
			this._OnValueChanged();
		}

		// Token: 0x06010792 RID: 67474 RVA: 0x004A3535 File Offset: 0x004A1935
		[UIEventHandle("Middle/max")]
		private void OnClickMax()
		{
			this.m_eCountLimitType = ActiveAwardRequiredFrame.CountLimitType.CLT_MAX;
			this.m_iCurCount = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "ct", 0);
			this._OnValueChanged();
		}

		// Token: 0x06010793 RID: 67475 RVA: 0x004A356A File Offset: 0x004A196A
		[UIEventHandle("Middle/add")]
		private void OnClickAdd()
		{
			this.m_iCurCount++;
			this.m_eCountLimitType = ActiveAwardRequiredFrame.CountLimitType.CLT_NORMAL;
			this._OnValueChanged();
		}

		// Token: 0x06010794 RID: 67476 RVA: 0x004A3587 File Offset: 0x004A1987
		[UIEventHandle("Middle/minus")]
		private void OnClickMinus()
		{
			this.m_iCurCount--;
			this.m_eCountLimitType = ActiveAwardRequiredFrame.CountLimitType.CLT_NORMAL;
			this._OnValueChanged();
		}

		// Token: 0x06010795 RID: 67477 RVA: 0x004A35A4 File Offset: 0x004A19A4
		private void _OnValueChanged()
		{
			this._SetHeadTitle();
			this.m_iMaxValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "ct", 0);
			if (this.m_iCurCount < 1)
			{
				this.m_iCurCount = 1;
			}
			if (this.m_iCurCount > this.m_iMaxValue)
			{
				this.m_iCurCount = this.m_iMaxValue;
			}
			if (this.m_iCurCount.ToString() != this.m_inputCount.text)
			{
				this.m_inputCount.text = this.m_iCurCount.ToString();
			}
			if (this.m_iCurCount != this._TransFloatValue2IntForSilder(this.m_kSlider.value, this.m_iMaxValue))
			{
				this.m_kSlider.value = (float)this.m_iCurCount * 1f / (float)this.m_iMaxValue;
			}
			int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "ncs", 0);
			int activeItemValue2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.data.activityData.ID, "pcs", 0);
			int num = (this.data.eEventType != OnClickActive.EventType.EventType_NormalAcquireAward) ? activeItemValue2 : activeItemValue;
			int num2 = (this.data.eEventType != OnClickActive.EventType.EventType_NormalAcquireAward) ? DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) : DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num2, true);
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(num2, 100, 0);
			if (itemData != null)
			{
				ETCImageLoader.LoadSprite(ref this.kCostIcon, itemData.Icon, true);
			}
			this.kCostNum.text = (this.m_iCurCount * num).ToString();
			this.kCostNum.color = ((ownedItemCount < this.m_iCurCount * num) ? Color.red : Color.white);
		}

		// Token: 0x06010796 RID: 67478 RVA: 0x004A379A File Offset: 0x004A1B9A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/ActiveAwardRequiredFrame";
		}

		// Token: 0x0400A774 RID: 42868
		private ActiveAwardRequiredFrameData data;

		// Token: 0x0400A775 RID: 42869
		private int m_iCurCount;

		// Token: 0x0400A776 RID: 42870
		private ActiveAwardRequiredFrame.CountLimitType m_eCountLimitType;

		// Token: 0x0400A777 RID: 42871
		[UIControl("Middle/count", typeof(InputField), 0)]
		private InputField m_inputCount;

		// Token: 0x0400A778 RID: 42872
		private Slider m_kSlider;

		// Token: 0x0400A779 RID: 42873
		private Text kName;

		// Token: 0x0400A77A RID: 42874
		private int m_iCurValue;

		// Token: 0x0400A77B RID: 42875
		private int m_iMaxValue;

		// Token: 0x0400A77C RID: 42876
		private Text kCostNum;

		// Token: 0x0400A77D RID: 42877
		private Image kCostIcon;

		// Token: 0x0400A77E RID: 42878
		[UIControl("Middle/Name", typeof(Text), 0)]
		private Text m_kName;

		// Token: 0x0400A77F RID: 42879
		[UIControl("Bottom/ok/item/costnum", typeof(Text), 0)]
		private Text m_kCount;

		// Token: 0x0400A780 RID: 42880
		[UIControl("Bottom/ok/item/icon", null, 0)]
		private Image m_kIcon;

		// Token: 0x02001A32 RID: 6706
		public enum CountLimitType
		{
			// Token: 0x0400A782 RID: 42882
			CLT_MIN,
			// Token: 0x0400A783 RID: 42883
			CLT_NORMAL,
			// Token: 0x0400A784 RID: 42884
			CLT_MAX
		}

		// Token: 0x02001A33 RID: 6707
		public enum CountConfigType
		{
			// Token: 0x0400A786 RID: 42886
			CCT_MIN = 1
		}
	}
}
