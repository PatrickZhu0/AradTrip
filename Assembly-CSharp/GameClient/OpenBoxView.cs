using System;
using System.Collections;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A8E RID: 6798
	public class OpenBoxView : MonoBehaviour
	{
		// Token: 0x06010AF3 RID: 68339 RVA: 0x004BAD01 File Offset: 0x004B9101
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06010AF4 RID: 68340 RVA: 0x004BAD09 File Offset: 0x004B9109
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06010AF5 RID: 68341 RVA: 0x004BAD18 File Offset: 0x004B9118
		private void BindEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
				this.okButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClicked));
			}
			if (this.commonTimeRefreshControl != null)
			{
				this.commonTimeRefreshControl.SetInvokeAction(new Action(this.OnUpdateOkButton));
			}
		}

		// Token: 0x06010AF6 RID: 68342 RVA: 0x004BAD8A File Offset: 0x004B918A
		private void UnBindEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
			}
			if (this.commonTimeRefreshControl != null)
			{
				this.commonTimeRefreshControl.ResetInvokeAction();
			}
		}

		// Token: 0x06010AF7 RID: 68343 RVA: 0x004BADC9 File Offset: 0x004B91C9
		private void ClearData()
		{
			if (this._boxEffectGo != null)
			{
				Object.Destroy(this._boxEffectGo);
			}
			this._boxDataModel = null;
		}

		// Token: 0x06010AF8 RID: 68344 RVA: 0x004BADF0 File Offset: 0x004B91F0
		public void InitView(BoxDataModel boxDataModel)
		{
			this._boxDataModel = boxDataModel;
			if (this._boxDataModel == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._boxDataModel.BoxModelPath))
			{
				return;
			}
			if (this._boxDataModel.CommonNewItemDataModelList == null || this._boxDataModel.CommonNewItemDataModelList.Count <= 0)
			{
				return;
			}
			if (this._boxDataModel.AwardItemData == null)
			{
				return;
			}
			base.StartCoroutine(this.OpenBoxEffect());
		}

		// Token: 0x06010AF9 RID: 68345 RVA: 0x004BAE6C File Offset: 0x004B926C
		private IEnumerator OpenBoxEffect()
		{
			yield return Yielders.EndOfFrame;
			this._boxEffectGo = (Singleton<AssetLoader>.GetInstance().LoadRes(this._boxDataModel.BoxModelPath, true, 0U).obj as GameObject);
			if (this._boxEffectGo != null)
			{
				this._boxEffectGo.transform.SetParent(this.boxEffectRoot.transform, false);
				this._boxEffectGo.SetActive(true);
			}
			DOTweenAnimation animRandom = Utility.GetComponetInChild<DOTweenAnimation>(this._boxEffectGo, "p_Pot02/Bone007/Dummy001");
			Image imageRandomBg = Utility.GetComponetInChild<Image>(this._boxEffectGo, "p_Pot02/Bone007/Dummy001/BG");
			if (imageRandomBg != null)
			{
				imageRandomBg.gameObject.SetActive(false);
			}
			Image imageRandomIcon = Utility.GetComponetInChild<Image>(this._boxEffectGo, "p_Pot02/Bone007/Dummy001/Icon");
			if (imageRandomIcon != null)
			{
				imageRandomIcon.gameObject.SetActive(false);
			}
			animRandom.onStepComplete.RemoveAllListeners();
			animRandom.onStepComplete.AddListener(new UnityAction(this.OnAnimatorStepComplete));
			animRandom.onComplete.RemoveAllListeners();
			animRandom.onComplete.AddListener(new UnityAction(this.OnAnimatorComplete));
			yield return Yielders.GetWaitForSeconds(0.1f);
			MonoSingleton<AudioManager>.instance.PlaySound(21);
			TweenExtensions.Restart(animRandom.tween, true);
			float maxTime = 2.2f;
			this.boxOpenProgress.value = 0f;
			float startTime = Time.time;
			float elapsed = 0f;
			while (elapsed < maxTime)
			{
				elapsed = Time.time - startTime;
				this.boxOpenProgress.value = elapsed / maxTime;
				yield return Yielders.EndOfFrame;
			}
			this.boxOpenProgress.value = 1f;
			this.boxOpenProgress.gameObject.SetActive(false);
			this.boxRandomItemName.gameObject.SetActive(false);
			animRandom.gameObject.SetActive(false);
			this.boxRoot.CustomActive(false);
			yield return Yielders.EndOfFrame;
			yield return this.PlayCardEffect();
			this.UpdateOkButton(true);
			yield break;
		}

		// Token: 0x06010AFA RID: 68346 RVA: 0x004BAE88 File Offset: 0x004B9288
		private IEnumerator PlayCardEffect()
		{
			this.SetAwardItemInfo();
			this.effectToggle.isOn = false;
			this.cardRoot.CustomActive(true);
			this.effectRoot.CustomActive(true);
			this.effectAnimator.enabled = true;
			while (!this.effectToggle.isOn)
			{
				yield return Yielders.EndOfFrame;
			}
			this.effectAnimator.enabled = false;
			this.comCardEffect.bFinished = false;
			if (this.cardAnimator != null)
			{
				this.cardAnimator.enabled = true;
			}
			while (!this.comCardEffect.bFinished)
			{
				yield return Yielders.GetWaitForSeconds(0.1f);
			}
			if (this.cardAnimator != null)
			{
				this.cardAnimator.enabled = false;
			}
			yield break;
		}

		// Token: 0x06010AFB RID: 68347 RVA: 0x004BAEA4 File Offset: 0x004B92A4
		private void SetAwardItemInfo()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._boxDataModel.AwardItemData.ItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Huise";
				if (this._boxDataModel.IsSpecialAward)
				{
					switch (tableItem.Color)
					{
					case ItemTable.eColor.GREEN:
						path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Lvse";
						break;
					case ItemTable.eColor.PINK:
						path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Fense";
						break;
					case ItemTable.eColor.YELLOW:
						path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Jinse";
						break;
					default:
						path = "UI/Image/Packed/p_UI_Kapai.png:UI_Kapai_Huise";
						break;
					}
				}
				ETCImageLoader.LoadSprite(ref this.backImage, path, true);
			}
			this.cardRtf.localRotation = Quaternion.identity;
			this.cardRtf.localScale = new Vector3(1f, 1f, 1f);
			for (int i = 0; i < this.cardRtf.childCount; i++)
			{
				Transform child = this.cardRtf.GetChild(i);
				child.localRotation = Quaternion.identity;
				child.localScale = new Vector3(1f, 1f, 1f);
			}
			if (this.itemRoot != null)
			{
				CommonNewItem commonNewItem = this.itemRoot.GetComponentInChildren<CommonNewItem>();
				if (commonNewItem == null)
				{
					commonNewItem = CommonUtility.CreateCommonNewItem(this.itemRoot);
				}
				commonNewItem.InitItem(this._boxDataModel.AwardItemData.ItemId, this._boxDataModel.AwardItemData.ItemCount);
			}
			if (this.ItemName != null)
			{
				this.ItemName.text = this._boxDataModel.AwardItemData.GetItemColorName();
			}
		}

		// Token: 0x06010AFC RID: 68348 RVA: 0x004BB058 File Offset: 0x004B9458
		private void OnAnimatorStepComplete()
		{
			int index = Random.Range(0, this._boxDataModel.CommonNewItemDataModelList.Count - 1);
			CommonNewItemDataModel commonNewItemDataModel = this._boxDataModel.CommonNewItemDataModelList[index];
			if (commonNewItemDataModel != null)
			{
				this.SetBoxRandomItemName(commonNewItemDataModel.GetItemColorName());
			}
		}

		// Token: 0x06010AFD RID: 68349 RVA: 0x004BB0A4 File Offset: 0x004B94A4
		private void OnAnimatorComplete()
		{
			CommonNewItemDataModel commonNewItemDataModel = this._boxDataModel.CommonNewItemDataModelList[0];
			if (commonNewItemDataModel != null)
			{
				this.SetBoxRandomItemName(commonNewItemDataModel.GetItemColorName());
			}
		}

		// Token: 0x06010AFE RID: 68350 RVA: 0x004BB0D5 File Offset: 0x004B94D5
		private void SetBoxRandomItemName(string colorName)
		{
			if (this.boxRandomItemName != null)
			{
				this.boxRandomItemName.text = colorName;
			}
		}

		// Token: 0x06010AFF RID: 68351 RVA: 0x004BB0F4 File Offset: 0x004B94F4
		private void OnCloseButtonClicked()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnBoxOpenFinished, null, null, null, null);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<OpenBoxFrame>(null, false);
		}

		// Token: 0x06010B00 RID: 68352 RVA: 0x004BB115 File Offset: 0x004B9515
		private void UpdateOkButton(bool flag)
		{
			if (this.okButton != null)
			{
				this.okButton.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06010B01 RID: 68353 RVA: 0x004BB139 File Offset: 0x004B9539
		private void OnUpdateOkButton()
		{
			this.UpdateOkButton(true);
			if (this.commonTimeRefreshControl != null)
			{
				this.commonTimeRefreshControl.ResetInvokeAction();
			}
		}

		// Token: 0x0400AA96 RID: 43670
		private BoxDataModel _boxDataModel;

		// Token: 0x0400AA97 RID: 43671
		private GameObject _boxEffectGo;

		// Token: 0x0400AA98 RID: 43672
		[Space(10f)]
		[Header("Box")]
		[Space(10f)]
		[SerializeField]
		private GameObject boxRoot;

		// Token: 0x0400AA99 RID: 43673
		[SerializeField]
		private GameObject boxEffectRoot;

		// Token: 0x0400AA9A RID: 43674
		[SerializeField]
		private Slider boxOpenProgress;

		// Token: 0x0400AA9B RID: 43675
		[SerializeField]
		private Text boxRandomItemName;

		// Token: 0x0400AA9C RID: 43676
		[Space(10f)]
		[Header("Effect")]
		[Space(10f)]
		[SerializeField]
		private Toggle effectToggle;

		// Token: 0x0400AA9D RID: 43677
		[SerializeField]
		private Animator effectAnimator;

		// Token: 0x0400AA9E RID: 43678
		[SerializeField]
		private GameObject effectRoot;

		// Token: 0x0400AA9F RID: 43679
		[Space(10f)]
		[Header("Card")]
		[Space(10f)]
		[SerializeField]
		private GameObject cardRoot;

		// Token: 0x0400AAA0 RID: 43680
		[SerializeField]
		private Animator cardAnimator;

		// Token: 0x0400AAA1 RID: 43681
		[SerializeField]
		private RectTransform cardRtf;

		// Token: 0x0400AAA2 RID: 43682
		[SerializeField]
		private ComCardEffect comCardEffect;

		// Token: 0x0400AAA3 RID: 43683
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400AAA4 RID: 43684
		[SerializeField]
		private Text ItemName;

		// Token: 0x0400AAA5 RID: 43685
		[SerializeField]
		private Image backImage;

		// Token: 0x0400AAA6 RID: 43686
		[SerializeField]
		private Image frontImage;

		// Token: 0x0400AAA7 RID: 43687
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button okButton;

		// Token: 0x0400AAA8 RID: 43688
		[Space(20f)]
		[Header("TimeRefresh")]
		[Space(10f)]
		[SerializeField]
		private CommonTimeRefreshControl commonTimeRefreshControl;
	}
}
