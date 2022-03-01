using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E0C RID: 3596
	public class CommonKeyBoardView : MonoBehaviour
	{
		// Token: 0x06008FFA RID: 36858 RVA: 0x001A9C43 File Offset: 0x001A8043
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06008FFB RID: 36859 RVA: 0x001A9C4B File Offset: 0x001A804B
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06008FFC RID: 36860 RVA: 0x001A9C59 File Offset: 0x001A8059
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x06008FFD RID: 36861 RVA: 0x001A9C98 File Offset: 0x001A8098
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06008FFE RID: 36862 RVA: 0x001A9CBB File Offset: 0x001A80BB
		private void ClearData()
		{
			this._keyBoardDataModel = null;
			this._currentValue = 0UL;
			this._maxValue = 0UL;
		}

		// Token: 0x06008FFF RID: 36863 RVA: 0x001A9CD4 File Offset: 0x001A80D4
		public void InitView(CommonKeyBoardDataModel dataModel)
		{
			this._keyBoardDataModel = dataModel;
			if (this._keyBoardDataModel == null)
			{
				Logger.LogErrorFormat("KeyBoardDataModel is null", new object[0]);
				return;
			}
			this.InitViewData();
			this.InitKeyBoardPosition();
			this.InitKeyBoardNumber();
		}

		// Token: 0x06009000 RID: 36864 RVA: 0x001A9D0C File Offset: 0x001A810C
		private void InitViewData()
		{
			if (this.firstKeyNumberGo != null)
			{
				this._baseVector3 = this.firstKeyNumberGo.transform.localPosition;
			}
			this._currentValue = this._keyBoardDataModel.CurrentValue;
			this._maxValue = this._keyBoardDataModel.MaxValue;
		}

		// Token: 0x06009001 RID: 36865 RVA: 0x001A9D62 File Offset: 0x001A8162
		private void InitKeyBoardPosition()
		{
			if (this.keyBoardContent != null)
			{
				this.keyBoardContent.transform.localPosition = this._keyBoardDataModel.Position;
			}
		}

		// Token: 0x06009002 RID: 36866 RVA: 0x001A9D90 File Offset: 0x001A8190
		private void InitKeyBoardNumber()
		{
			int num = this._keyBoardNumberTypeList.Length;
			for (int i = 0; i < num; i++)
			{
				this.InitOneKeyBoardNumber(i, this._keyBoardNumberTypeList[i]);
			}
		}

		// Token: 0x06009003 RID: 36867 RVA: 0x001A9DC8 File Offset: 0x001A81C8
		private void InitOneKeyBoardNumber(int index, KeyBoardNumberType keyBoardNumType)
		{
			int num = index / 4;
			int num2 = index % 4;
			GameObject gameObject = null;
			if (keyBoardNumType == KeyBoardNumberType.Ensure)
			{
				if (this.ensureGo != null)
				{
					gameObject = Object.Instantiate<GameObject>(this.ensureGo);
				}
			}
			else if (keyBoardNumType == KeyBoardNumberType.Delete)
			{
				if (this.deleteGo != null)
				{
					gameObject = Object.Instantiate<GameObject>(this.deleteGo);
				}
			}
			else if (this.numberGo != null)
			{
				gameObject = Object.Instantiate<GameObject>(this.numberGo);
			}
			if (gameObject == null)
			{
				return;
			}
			gameObject.CustomActive(true);
			Utility.AttachTo(gameObject, this.keyBoardContent, false);
			gameObject.transform.localPosition = new Vector3(this._baseVector3.x + (float)num2 * 130f, this._baseVector3.y - (float)num * 130f, this._baseVector3.z);
			CommonKeyBoardNumberItem component = gameObject.GetComponent<CommonKeyBoardNumberItem>();
			if (component != null)
			{
				component.InitItem(keyBoardNumType, new OnCommonKeyBoardNumberClicked(this.OnNumberItemClicked));
			}
		}

		// Token: 0x06009004 RID: 36868 RVA: 0x001A9EDA File Offset: 0x001A82DA
		private void OnNumberItemClicked(KeyBoardNumberType keyBoardNumberType)
		{
			if (keyBoardNumberType == KeyBoardNumberType.Delete)
			{
				this.OnDeleteItem();
			}
			else if (keyBoardNumberType == KeyBoardNumberType.Ensure)
			{
				this.OnEnsureItem();
			}
			else
			{
				this.OnAddItem(keyBoardNumberType);
			}
		}

		// Token: 0x06009005 RID: 36869 RVA: 0x001A9F09 File Offset: 0x001A8309
		private void OnDeleteItem()
		{
			if (this._currentValue > 9UL)
			{
				this._currentValue /= 10UL;
			}
			else
			{
				this._currentValue = 0UL;
			}
			this.OnSendChangeNumberEvent();
		}

		// Token: 0x06009006 RID: 36870 RVA: 0x001A9F3C File Offset: 0x001A833C
		private void OnAddItem(KeyBoardNumberType keyBoardNumberType)
		{
			this._currentValue = this._currentValue * 10UL + (ulong)((long)keyBoardNumberType);
			if (this._currentValue >= this._maxValue)
			{
				this._currentValue = this._maxValue;
			}
			this.OnSendChangeNumberEvent();
		}

		// Token: 0x06009007 RID: 36871 RVA: 0x001A9F74 File Offset: 0x001A8374
		private void OnSendChangeNumberEvent()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnCommonKeyBoardInput, CommonKeyBoardInputType.ChangeNumber, this._currentValue, null, null);
		}

		// Token: 0x06009008 RID: 36872 RVA: 0x001A9F98 File Offset: 0x001A8398
		private void OnEnsureItem()
		{
			this.OnCloseFrame();
		}

		// Token: 0x06009009 RID: 36873 RVA: 0x001A9FA0 File Offset: 0x001A83A0
		private void OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnCommonKeyBoardInput, CommonKeyBoardInputType.Finished, this._currentValue, null, null);
			CommonUtility.OnCloseCommonKeyBoardFrame();
		}

		// Token: 0x04004785 RID: 18309
		private readonly KeyBoardNumberType[] _keyBoardNumberTypeList = new KeyBoardNumberType[]
		{
			KeyBoardNumberType.One,
			KeyBoardNumberType.Two,
			KeyBoardNumberType.Three,
			KeyBoardNumberType.Delete,
			KeyBoardNumberType.Four,
			KeyBoardNumberType.Five,
			KeyBoardNumberType.Six,
			KeyBoardNumberType.Zero,
			KeyBoardNumberType.Seven,
			KeyBoardNumberType.Eight,
			KeyBoardNumberType.Nine,
			KeyBoardNumberType.Ensure
		};

		// Token: 0x04004786 RID: 18310
		private CommonKeyBoardDataModel _keyBoardDataModel;

		// Token: 0x04004787 RID: 18311
		private const int ColNumber = 4;

		// Token: 0x04004788 RID: 18312
		private const float IntervalWidth = 130f;

		// Token: 0x04004789 RID: 18313
		private const float IntervalHeight = 130f;

		// Token: 0x0400478A RID: 18314
		private Vector3 _baseVector3 = Vector3.zero;

		// Token: 0x0400478B RID: 18315
		private ulong _currentValue;

		// Token: 0x0400478C RID: 18316
		private ulong _maxValue;

		// Token: 0x0400478D RID: 18317
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private GameObject firstKeyNumberGo;

		// Token: 0x0400478E RID: 18318
		[SerializeField]
		private GameObject numberGo;

		// Token: 0x0400478F RID: 18319
		[SerializeField]
		private GameObject deleteGo;

		// Token: 0x04004790 RID: 18320
		[SerializeField]
		private GameObject ensureGo;

		// Token: 0x04004791 RID: 18321
		[Space(10f)]
		[Header("Bg")]
		[Space(10f)]
		[SerializeField]
		private GameObject keyBoardContent;

		// Token: 0x04004792 RID: 18322
		[Space(10f)]
		[Header("Close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
