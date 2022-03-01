using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BD4 RID: 7124
	public class TAPGraduationFrame : ClientFrame
	{
		// Token: 0x0601172B RID: 71467 RVA: 0x00510D6C File Offset: 0x0050F16C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPGraduationFrame";
		}

		// Token: 0x0601172C RID: 71468 RVA: 0x00510D73 File Offset: 0x0050F173
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.relationData = (RelationData)this.userData;
			}
			this._RegisterUIEvent();
			this._InitData();
			this._InitUI();
		}

		// Token: 0x0601172D RID: 71469 RVA: 0x00510DA3 File Offset: 0x0050F1A3
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0601172E RID: 71470 RVA: 0x00510DB7 File Offset: 0x0050F1B7
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPGraduationScoreChange, new ClientEventSystem.UIEventHandler(this._OnOnTAPGraduationScoreChange));
		}

		// Token: 0x0601172F RID: 71471 RVA: 0x00510DD4 File Offset: 0x0050F1D4
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPGraduationScoreChange, new ClientEventSystem.UIEventHandler(this._OnOnTAPGraduationScoreChange));
		}

		// Token: 0x06011730 RID: 71472 RVA: 0x00510DF1 File Offset: 0x0050F1F1
		private void _InitData()
		{
			this.rewardRoot.Clear();
			this.itemList.Clear();
		}

		// Token: 0x06011731 RID: 71473 RVA: 0x00510E09 File Offset: 0x0050F209
		private void _ClearData()
		{
			this.rewardRoot.Clear();
			this.itemList.Clear();
		}

		// Token: 0x06011732 RID: 71474 RVA: 0x00510E24 File Offset: 0x0050F224
		private void _InitUI()
		{
			this.rewardRoot.Add(this.mRoot1);
			this.rewardRoot.Add(this.mRoot2);
			this.rewardRoot.Add(this.mRoot3);
			this.rewardRoot.Add(this.mRoot4);
			this.rewardRoot.Add(this.mRoot5);
			TAPGiftType tapgiftType;
			if (this.relationData.tapType == TAPType.Pupil)
			{
				tapgiftType = TAPGiftType.TeacherGraduationGift;
			}
			else
			{
				tapgiftType = TAPGiftType.PupilGraduationGift;
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MasterSysGiftTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				MasterSysGiftTable masterSysGiftTable = keyValuePair.Value as MasterSysGiftTable;
				if (tapgiftType == (TAPGiftType)masterSysGiftTable.Type)
				{
					TAPGraduationItem tapgraduationItem = new TAPGraduationItem(masterSysGiftTable);
					Utility.AttachTo(tapgraduationItem.ThisGameObject, this.rewardRoot[num], false);
					this.itemList.Add(tapgraduationItem);
					num++;
				}
			}
		}

		// Token: 0x06011733 RID: 71475 RVA: 0x00510F1E File Offset: 0x0050F31E
		private void _ClearUI()
		{
		}

		// Token: 0x06011734 RID: 71476 RVA: 0x00510F20 File Offset: 0x0050F320
		private void _OnOnTAPGraduationScoreChange(UIEvent uiEvent)
		{
			int num = (int)uiEvent.Param1;
			for (int i = 0; i < this.itemList.Count - 1; i++)
			{
				this.itemList[i].SetActiveImage(false);
				if (this.itemList[i].GetScore() <= num && this.itemList[i + 1].GetScore() > num)
				{
					this.itemList[i].SetActiveImage(true);
				}
			}
			if (this.itemList[this.itemList.Count - 1].GetScore() <= num)
			{
				this.itemList[this.itemList.Count - 1].SetActiveImage(true);
			}
			else
			{
				this.itemList[this.itemList.Count - 1].SetActiveImage(false);
			}
			this.mScore.text = num.ToString();
		}

		// Token: 0x06011735 RID: 71477 RVA: 0x00511028 File Offset: 0x0050F428
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mRoot1 = this.mBind.GetGameObject("root1");
			this.mRoot2 = this.mBind.GetGameObject("root2");
			this.mRoot3 = this.mBind.GetGameObject("root3");
			this.mRoot4 = this.mBind.GetGameObject("root4");
			this.mRoot5 = this.mBind.GetGameObject("root5");
			this.mScore = this.mBind.GetCom<Text>("Score");
		}

		// Token: 0x06011736 RID: 71478 RVA: 0x005110FC File Offset: 0x0050F4FC
		protected override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mRoot1 = null;
			this.mRoot2 = null;
			this.mRoot3 = null;
			this.mRoot4 = null;
			this.mRoot5 = null;
			this.mScore = null;
		}

		// Token: 0x06011737 RID: 71479 RVA: 0x00511167 File Offset: 0x0050F567
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TAPGraduationFrame>(this, false);
		}

		// Token: 0x0400B52C RID: 46380
		private RelationData relationData;

		// Token: 0x0400B52D RID: 46381
		private List<GameObject> rewardRoot = new List<GameObject>();

		// Token: 0x0400B52E RID: 46382
		private List<TAPGraduationItem> itemList = new List<TAPGraduationItem>();

		// Token: 0x0400B52F RID: 46383
		private Button mClose;

		// Token: 0x0400B530 RID: 46384
		private GameObject mRoot1;

		// Token: 0x0400B531 RID: 46385
		private GameObject mRoot2;

		// Token: 0x0400B532 RID: 46386
		private GameObject mRoot3;

		// Token: 0x0400B533 RID: 46387
		private GameObject mRoot4;

		// Token: 0x0400B534 RID: 46388
		private GameObject mRoot5;

		// Token: 0x0400B535 RID: 46389
		private Text mScore;
	}
}
