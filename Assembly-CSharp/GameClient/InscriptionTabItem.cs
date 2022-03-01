using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B62 RID: 7010
	public class InscriptionTabItem : MonoBehaviour
	{
		// Token: 0x060112D7 RID: 70359 RVA: 0x004EFE1A File Offset: 0x004EE21A
		private void Awake()
		{
			if (this.mTog != null)
			{
				this.mTog.onValueChanged.RemoveAllListeners();
				this.mTog.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClick));
			}
		}

		// Token: 0x060112D8 RID: 70360 RVA: 0x004EFE59 File Offset: 0x004EE259
		private void OnDestroy()
		{
			this.bIsSelected = false;
			this.mInscriptionTabModel = null;
			this.mTabContentView = null;
		}

		// Token: 0x060112D9 RID: 70361 RVA: 0x004EFE70 File Offset: 0x004EE270
		public void Init(InscriptionTabModel model, bool isSelected)
		{
			this.mInscriptionTabModel = model;
			if (this.mName != null)
			{
				this.mName.text = this.mInscriptionTabModel.Name;
			}
			if (isSelected)
			{
				this.mTog.isOn = true;
			}
		}

		// Token: 0x060112DA RID: 70362 RVA: 0x004EFEC0 File Offset: 0x004EE2C0
		private void OnTabClick(bool value)
		{
			if (this.mInscriptionTabModel == null)
			{
				return;
			}
			if (this.bIsSelected == value)
			{
				return;
			}
			this.bIsSelected = value;
			if (value)
			{
				if (this.mInscriptionTabModel.ContentRoot != null)
				{
					this.mInscriptionTabModel.ContentRoot.CustomActive(true);
				}
				if (this.mTabContentView == null)
				{
					this.LoadContentView();
				}
			}
			else if (this.mInscriptionTabModel.ContentRoot != null)
			{
				this.mInscriptionTabModel.ContentRoot.CustomActive(false);
			}
		}

		// Token: 0x060112DB RID: 70363 RVA: 0x004EFF60 File Offset: 0x004EE360
		private void LoadContentView()
		{
			UIPrefabWrapper component = this.mInscriptionTabModel.ContentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this.mInscriptionTabModel.ContentRoot.transform, false);
					this.mTabContentView = gameObject;
				}
			}
			if (this.mTabContentView != null)
			{
				IInscriptionView component2 = this.mTabContentView.GetComponent<IInscriptionView>();
				if (component2 != null)
				{
					component2.InitView();
				}
			}
		}

		// Token: 0x0400B157 RID: 45399
		[SerializeField]
		private Toggle mTog;

		// Token: 0x0400B158 RID: 45400
		[SerializeField]
		private Text mName;

		// Token: 0x0400B159 RID: 45401
		private bool bIsSelected;

		// Token: 0x0400B15A RID: 45402
		private InscriptionTabModel mInscriptionTabModel;

		// Token: 0x0400B15B RID: 45403
		private GameObject mTabContentView;
	}
}
