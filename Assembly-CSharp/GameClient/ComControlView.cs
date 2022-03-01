using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EA8 RID: 3752
	public class ComControlView : MonoBehaviour
	{
		// Token: 0x06009424 RID: 37924 RVA: 0x001BC14A File Offset: 0x001BA54A
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06009425 RID: 37925 RVA: 0x001BC152 File Offset: 0x001BA552
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06009426 RID: 37926 RVA: 0x001BC160 File Offset: 0x001BA560
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x06009427 RID: 37927 RVA: 0x001BC19F File Offset: 0x001BA59F
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009428 RID: 37928 RVA: 0x001BC1C4 File Offset: 0x001BA5C4
		private void ClearData()
		{
			if (this._comTwoLevelToggleDataList != null)
			{
				for (int i = 0; i < this._comTwoLevelToggleDataList.Count; i++)
				{
					if (this._comTwoLevelToggleDataList[i].SecondLevelToggleDataList != null)
					{
						this._comTwoLevelToggleDataList[i].SecondLevelToggleDataList.Clear();
					}
				}
				this._comTwoLevelToggleDataList.Clear();
			}
			if (this._comTwoLevelToggleDataListWithExample != null)
			{
				for (int j = 0; j < this._comTwoLevelToggleDataListWithExample.Count; j++)
				{
					if (this._comTwoLevelToggleDataListWithExample[j].SecondLevelToggleDataList != null)
					{
						this._comTwoLevelToggleDataListWithExample[j].SecondLevelToggleDataList.Clear();
					}
				}
				this._comTwoLevelToggleDataListWithExample.Clear();
			}
			if (this._comToggleDataList != null)
			{
				this._comToggleDataList.Clear();
			}
			this._comToggleData = null;
		}

		// Token: 0x06009429 RID: 37929 RVA: 0x001BC2AA File Offset: 0x001BA6AA
		public void InitView()
		{
			this.InitTestTwoLevelToggleWithExample();
		}

		// Token: 0x0600942A RID: 37930 RVA: 0x001BC2B4 File Offset: 0x001BA6B4
		private void InitTestComToggle()
		{
			for (int i = 0; i < 10; i++)
			{
				TestLevelData testLevelData = new TestLevelData
				{
					Id = i + 1,
					Name = "CT_" + (i + 1),
					IsSelected = false,
					LevelName = "LV_" + (i + 1)
				};
				testLevelData.IsSelected = (i == 2);
				this._comToggleDataList.Add(testLevelData);
			}
			if (this.comToggleControl != null && this._comToggleDataList != null && this._comToggleDataList.Count > 0)
			{
				this.comToggleControl.InitComToggleControl(this._comToggleDataList, new OnComToggleClick(this.OnTestToggleClick));
			}
		}

		// Token: 0x0600942B RID: 37931 RVA: 0x001BC388 File Offset: 0x001BA788
		private void OnTestToggleClick(ComControlData comToggleData)
		{
			if (comToggleData == null)
			{
				return;
			}
			if (this._comToggleData != null && this._comToggleData.Id == comToggleData.Id)
			{
				return;
			}
			this._comToggleData = comToggleData;
			TestLevelData testLevelData = this._comToggleData as TestLevelData;
			if (testLevelData != null)
			{
				Logger.LogErrorFormat("OnComToggleClick and id is {0}, name is {1}, levelName is {2}", new object[]
				{
					testLevelData.Id,
					testLevelData.Name,
					testLevelData.LevelName
				});
			}
		}

		// Token: 0x0600942C RID: 37932 RVA: 0x001BC408 File Offset: 0x001BA808
		private void InitTestDropDown()
		{
			for (int i = 0; i < 10; i++)
			{
				TestDropDownData item = new TestDropDownData
				{
					Id = i + 1,
					Name = "DD_" + (i + 1),
					DropDownName = "NN_" + (i + 2)
				};
				this._dropDownDataList.Add(item);
			}
			ComControlData comControlData = this._dropDownDataList[8];
			if (this.comDropDownControl != null)
			{
				this.comDropDownControl.InitComDropDownControl(comControlData, this._dropDownDataList, new OnComDropDownItemButtonClick(this.OnDropDownItemClicked), null);
			}
		}

		// Token: 0x0600942D RID: 37933 RVA: 0x001BC4B4 File Offset: 0x001BA8B4
		private void OnDropDownItemClicked(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			if (this._dropDownData != null && this._dropDownData.Id == comControlData.Id)
			{
				return;
			}
			this._dropDownData = comControlData;
			TestDropDownData testDropDownData = this._dropDownData as TestDropDownData;
			if (testDropDownData != null)
			{
				Logger.LogErrorFormat("The selected DropDownData id is {0}, name is {1}, dropDownName is {2}", new object[]
				{
					testDropDownData.Id,
					testDropDownData.Name,
					testDropDownData.DropDownName
				});
			}
		}

		// Token: 0x0600942E RID: 37934 RVA: 0x001BC534 File Offset: 0x001BA934
		private void InitTestTwoLevelToggle()
		{
			for (int i = 0; i < 5; i++)
			{
				ComTwoLevelToggleData comTwoLevelToggleData = new ComTwoLevelToggleData();
				ComControlData comControlData = new ComControlData
				{
					Id = i + 1,
					Name = "FL_" + (i + 1),
					IsSelected = false
				};
				comControlData.IsSelected = (i == 1);
				comTwoLevelToggleData.FirstLevelToggleData = comControlData;
				List<ComControlData> list = new List<ComControlData>();
				int num = i;
				for (int j = 0; j < num; j++)
				{
					ComControlData comControlData2 = new ComControlData
					{
						Id = j + 1,
						Name = "SL_" + (j + 1),
						IsSelected = false
					};
					comControlData2.IsSelected = (j == 0);
					list.Add(comControlData2);
				}
				comTwoLevelToggleData.SecondLevelToggleDataList = list;
				this._comTwoLevelToggleDataList.Add(comTwoLevelToggleData);
			}
			if (this.comTwoLevelToggleControl != null)
			{
				this.comTwoLevelToggleControl.InitTwoLevelToggleControl(this._comTwoLevelToggleDataList, new OnComToggleClick(this.OnFirstLevelToggleClick), new OnComToggleClick(this.OnSecondLevelToggleClick));
			}
		}

		// Token: 0x0600942F RID: 37935 RVA: 0x001BC664 File Offset: 0x001BAA64
		private void OnFirstLevelToggleClick(ComControlData comToggleData)
		{
			if (comToggleData != null)
			{
				Logger.LogErrorFormat("firstLevel ToggleClick and id is {0}, name is {1}", new object[]
				{
					comToggleData.Id,
					comToggleData.Name
				});
			}
		}

		// Token: 0x06009430 RID: 37936 RVA: 0x001BC693 File Offset: 0x001BAA93
		private void OnSecondLevelToggleClick(ComControlData comToggleData)
		{
			if (comToggleData != null)
			{
				Logger.LogErrorFormat("secondLevel ToggleClick and id is {0}, name is {1}", new object[]
				{
					comToggleData.Id,
					comToggleData.Name
				});
			}
		}

		// Token: 0x06009431 RID: 37937 RVA: 0x001BC6C4 File Offset: 0x001BAAC4
		private void InitTestTwoLevelToggleWithExample()
		{
			for (int i = 0; i < 5; i++)
			{
				ComTwoLevelToggleData comTwoLevelToggleData = new ComTwoLevelToggleData();
				ComFirstLevelToggleDataWithExample comFirstLevelToggleDataWithExample = new ComFirstLevelToggleDataWithExample
				{
					Id = i + 1,
					Name = "FL_" + (i * 10 + 1),
					IsSelected = false,
					FirstLevelExampleName = "一" + (i * 10 + 1),
					FirstLevelIndex = 1000 + (i * 10 + 1)
				};
				comFirstLevelToggleDataWithExample.IsSelected = (i == 1);
				comTwoLevelToggleData.FirstLevelToggleData = comFirstLevelToggleDataWithExample;
				List<ComControlData> list = new List<ComControlData>();
				int num = i;
				for (int j = 0; j < num; j++)
				{
					ComSecondLevelToggleDataWithExample comSecondLevelToggleDataWithExample = new ComSecondLevelToggleDataWithExample
					{
						Id = j + 1,
						Name = "SL_" + (j * 10 + 1),
						IsSelected = false,
						SecondLevelExampleName = "二" + (j * 10 + 1),
						SecondLevelIndex = 200 + (j * 10 + 1)
					};
					comSecondLevelToggleDataWithExample.IsSelected = (j == 0);
					list.Add(comSecondLevelToggleDataWithExample);
				}
				comTwoLevelToggleData.SecondLevelToggleDataList = list;
				this._comTwoLevelToggleDataListWithExample.Add(comTwoLevelToggleData);
			}
			if (this.comTwoLevelToggleControlWithExample != null)
			{
				this.comTwoLevelToggleControlWithExample.InitTwoLevelToggleControl(this._comTwoLevelToggleDataListWithExample, new OnComToggleClick(this.OnFirstLevelToggleClickWithExample), new OnComToggleClick(this.OnSecondLevelToggleClickWithExample));
			}
		}

		// Token: 0x06009432 RID: 37938 RVA: 0x001BC860 File Offset: 0x001BAC60
		private void OnFirstLevelToggleClickWithExample(ComControlData comToggleData)
		{
			if (comToggleData != null)
			{
				Logger.LogErrorFormat("firstLevel ToggleClick and id is {0}, name is {1}", new object[]
				{
					comToggleData.Id,
					comToggleData.Name
				});
				ComFirstLevelToggleDataWithExample comFirstLevelToggleDataWithExample = comToggleData as ComFirstLevelToggleDataWithExample;
				if (comFirstLevelToggleDataWithExample != null)
				{
					Logger.LogErrorFormat("firstLevel ToggleClick and dataWithExample name is {0}, index is {1}", new object[]
					{
						comFirstLevelToggleDataWithExample.FirstLevelExampleName,
						comFirstLevelToggleDataWithExample.FirstLevelIndex
					});
				}
			}
		}

		// Token: 0x06009433 RID: 37939 RVA: 0x001BC8D0 File Offset: 0x001BACD0
		private void OnSecondLevelToggleClickWithExample(ComControlData comToggleData)
		{
			if (comToggleData != null)
			{
				Logger.LogErrorFormat("secondLevel ToggleClick and id is {0}, name is {1}", new object[]
				{
					comToggleData.Id,
					comToggleData.Name
				});
				ComSecondLevelToggleDataWithExample comSecondLevelToggleDataWithExample = comToggleData as ComSecondLevelToggleDataWithExample;
				if (comSecondLevelToggleDataWithExample != null)
				{
					Logger.LogErrorFormat("secondLevel ToggleClick and dataWithExample name is {0} index is {1}", new object[]
					{
						comSecondLevelToggleDataWithExample.SecondLevelExampleName,
						comSecondLevelToggleDataWithExample.SecondLevelIndex
					});
				}
			}
		}

		// Token: 0x06009434 RID: 37940 RVA: 0x001BC93E File Offset: 0x001BAD3E
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ComControlFrame>(null, false);
		}

		// Token: 0x04004AFE RID: 19198
		[SerializeField]
		private Button closeButton;

		// Token: 0x04004AFF RID: 19199
		private ComControlData _comToggleData;

		// Token: 0x04004B00 RID: 19200
		private List<ComControlData> _comToggleDataList = new List<ComControlData>();

		// Token: 0x04004B01 RID: 19201
		private ComControlData _dropDownData;

		// Token: 0x04004B02 RID: 19202
		private List<ComControlData> _dropDownDataList = new List<ComControlData>();

		// Token: 0x04004B03 RID: 19203
		private List<ComTwoLevelToggleData> _comTwoLevelToggleDataList = new List<ComTwoLevelToggleData>();

		// Token: 0x04004B04 RID: 19204
		private List<ComTwoLevelToggleData> _comTwoLevelToggleDataListWithExample = new List<ComTwoLevelToggleData>();

		// Token: 0x04004B05 RID: 19205
		[Space(10f)]
		[Header("ComToggleControl")]
		[Space(5f)]
		[SerializeField]
		private ComToggleControl comToggleControl;

		// Token: 0x04004B06 RID: 19206
		[Space(10f)]
		[Header("ComTwoLevelToggleControl")]
		[Space(5f)]
		[SerializeField]
		private ComTwoLevelToggleControl comTwoLevelToggleControl;

		// Token: 0x04004B07 RID: 19207
		[Space(10f)]
		[Header("ComTwoLevelToggleControlWithExample")]
		[Space(5f)]
		[SerializeField]
		private ComTwoLevelToggleControl comTwoLevelToggleControlWithExample;

		// Token: 0x04004B08 RID: 19208
		[Space(10f)]
		[Header("ComDropDownControl")]
		[Space(5f)]
		[SerializeField]
		private ComDropDownControl comDropDownControl;
	}
}
