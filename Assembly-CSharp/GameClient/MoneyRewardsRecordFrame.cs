using System;
using System.Collections.Generic;
using GamePool;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017EE RID: 6126
	internal class MoneyRewardsRecordFrame : ClientFrame
	{
		// Token: 0x0600F16D RID: 61805 RVA: 0x00410C51 File Offset: 0x0040F051
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MoneyRewards/MoneyRewardsRecordFrame";
		}

		// Token: 0x0600F16E RID: 61806 RVA: 0x00410C58 File Offset: 0x0040F058
		public static void CommandOpen(object argv)
		{
			if (DataManager<MoneyRewardsDataManager>.GetInstance().Records.Count == 0)
			{
				DataManager<MoneyRewardsDataManager>.GetInstance().RequestRecords(false, -1, 20, delegate
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsRecordFrame>(FrameLayer.Middle, argv, string.Empty);
				});
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsRecordFrame>(FrameLayer.Middle, argv, string.Empty);
			}
		}

		// Token: 0x0600F16F RID: 61807 RVA: 0x00410CBC File Offset: 0x0040F0BC
		private void _InitGeneratorSetting()
		{
			Vector2 vector;
			vector..ctor(this.generate.rectTransform.rect.size.x, 0f);
			TextGenerationSettings generationSettings = this.generate.GetGenerationSettings(vector);
			this.textGeneratorSetting.font = generationSettings.font;
			this.textGeneratorSetting.fontSize = generationSettings.fontSize;
			this.textGeneratorSetting.fontStyle = generationSettings.fontStyle;
			this.textGeneratorSetting.lineSpacing = generationSettings.lineSpacing;
			this.textGeneratorSetting.horizontalOverflow = 0;
			this.textGeneratorSetting.verticalOverflow = 1;
			this.textGeneratorSetting.alignByGeometry = false;
			this.textGeneratorSetting.resizeTextForBestFit = generationSettings.resizeTextForBestFit;
			this.textGeneratorSetting.richText = generationSettings.richText;
			this.textGeneratorSetting.scaleFactor = 1f;
			this.textGeneratorSetting.updateBounds = generationSettings.updateBounds;
			this.textGeneratorSetting.generationExtents = vector;
		}

		// Token: 0x0600F170 RID: 61808 RVA: 0x00410DC0 File Offset: 0x0040F1C0
		protected override void _OnOpenFrame()
		{
			this._InitGeneratorSetting();
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<MoneyRewardsRecordFrame>(this, false);
			});
			if (null != this.toggle)
			{
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnToggleChanged));
			}
			if (null != this.scripts)
			{
				this.scripts.Initialize();
				this.scripts.onBindItem = delegate(GameObject go)
				{
					if (null != go)
					{
						return go.GetComponent<ComMoneyRewardsRecords>();
					}
					return null;
				};
				this.scripts.onItemVisiable = delegate(ComUIListElementScript item)
				{
					int dataCount = DataManager<MoneyRewardsDataManager>.GetInstance().getDataCount(this.toggle.isOn);
					if (null != item && item.m_index >= 0 && item.m_index < dataCount)
					{
						ComMoneyRewardsRecords comMoneyRewardsRecords = item.gameObjectBindScript as ComMoneyRewardsRecords;
						if (null != comMoneyRewardsRecords)
						{
							comMoneyRewardsRecords.OnItemVisible(DataManager<MoneyRewardsDataManager>.GetInstance().getData(item.m_index, this.toggle.isOn));
							if (item.m_index == 0)
							{
								ComMoneyRewardsRecordsData comMoneyRewardsRecordsData = DataManager<MoneyRewardsDataManager>.GetInstance().Records[0];
								if (comMoneyRewardsRecordsData != null && !this.m_searched_list.Contains(comMoneyRewardsRecordsData.iIndex))
								{
									this.m_searched_list.Add(comMoneyRewardsRecordsData.iIndex);
									int num = 0;
									if (comMoneyRewardsRecordsData.iIndex > 0)
									{
										if (comMoneyRewardsRecordsData.iIndex < 20)
										{
											num = comMoneyRewardsRecordsData.iIndex;
										}
										else
										{
											num = 20;
										}
									}
									if (num > 0)
									{
										DataManager<MoneyRewardsDataManager>.GetInstance().RequestRecords(false, comMoneyRewardsRecordsData.iIndex, num, null);
									}
								}
							}
						}
					}
				};
			}
			this._UpdateRecords();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsRecordsChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsRecordsChanged));
		}

		// Token: 0x0600F171 RID: 61809 RVA: 0x00410E94 File Offset: 0x0040F294
		private void _UpdateRecords()
		{
			if (null != this.scripts)
			{
				int dataCount = DataManager<MoneyRewardsDataManager>.GetInstance().getDataCount(this.toggle.isOn);
				List<Vector2> list = ListPool<Vector2>.Get();
				for (int i = 0; i < dataCount; i++)
				{
					ComMoneyRewardsRecordsData data = DataManager<MoneyRewardsDataManager>.GetInstance().getData(i, this.toggle.isOn);
					if (data != null)
					{
						if (!data.measured)
						{
							data.saveValue = data.ToRecords();
							float preferredHeight = this.cachedTextGenerator.GetPreferredHeight(data.saveValue, this.textGeneratorSetting);
							float x = this.textGeneratorSetting.generationExtents.x;
							data.h = preferredHeight;
							data.w = x;
							data.measured = true;
						}
						list.Add(new Vector2(data.w, data.h));
					}
				}
				this.scripts.SetElementAmount(list.Count, list);
				ListPool<Vector2>.Release(list);
			}
		}

		// Token: 0x0600F172 RID: 61810 RVA: 0x00410F85 File Offset: 0x0040F385
		private void _OnToggleChanged(bool bValue)
		{
			this._UpdateRecords();
		}

		// Token: 0x0600F173 RID: 61811 RVA: 0x00410F8D File Offset: 0x0040F38D
		private void _OnMoneyRewardsRecordsChanged(UIEvent uiEvent)
		{
			this._UpdateRecords();
		}

		// Token: 0x0600F174 RID: 61812 RVA: 0x00410F98 File Offset: 0x0040F398
		protected override void _OnCloseFrame()
		{
			if (null != this.scripts)
			{
				this.scripts.onBindItem = null;
				this.scripts.onItemVisiable = null;
				this.scripts = null;
			}
			if (null != this.toggle)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnToggleChanged));
			}
			this.m_searched_list.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsRecordsChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsRecordsChanged));
		}

		// Token: 0x04009456 RID: 37974
		[UIControl("ScrollView", typeof(ComUIListScript), 0)]
		private ComUIListScript scripts;

		// Token: 0x04009457 RID: 37975
		[UIControl("TG0", typeof(Toggle), 0)]
		private Toggle toggle;

		// Token: 0x04009458 RID: 37976
		private TextGenerator cachedTextGenerator = new TextGenerator(256);

		// Token: 0x04009459 RID: 37977
		private TextGenerationSettings textGeneratorSetting = default(TextGenerationSettings);

		// Token: 0x0400945A RID: 37978
		[UIControl("ScrollView/ViewPort/Content/RecordItem/Name", typeof(Text), 0)]
		private Text generate;

		// Token: 0x0400945B RID: 37979
		private List<int> m_searched_list = new List<int>();
	}
}
