using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B61 RID: 7009
	public class InscriptionSynthesisResultFrame : ClientFrame
	{
		// Token: 0x060112D0 RID: 70352 RVA: 0x004EFC3B File Offset: 0x004EE03B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/InscriptionFrame/InscriptionSynthesisResultFrame";
		}

		// Token: 0x060112D1 RID: 70353 RVA: 0x004EFC44 File Offset: 0x004EE044
		protected sealed override void _OnOpenFrame()
		{
			CommonGetItemData commonGetItemData = this.userData as CommonGetItemData;
			if (commonGetItemData == null)
			{
				Logger.LogError("open CommonGetItemFrame, userdata is invalid");
				return;
			}
			for (int i = 0; i < commonGetItemData.itemDatas.Count; i++)
			{
				ResultItemData resultItemData = commonGetItemData.itemDatas[i];
				GameObject gameObject = Object.Instantiate<GameObject>(this.mPrefabs);
				if (gameObject != null)
				{
					gameObject.CustomActive(true);
					Utility.AttachTo(gameObject, this.mItemParent, false);
					ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
					if (component != null)
					{
						GameObject gameObject2 = component.GetGameObject("itemParent");
						Text com = component.GetCom<Text>("itemname");
						base.CreateComItem(gameObject2).Setup(resultItemData.itemData, commonGetItemData.itemClickCallback);
						if (com != null)
						{
							com.text = resultItemData.desc;
						}
					}
				}
			}
			MonoSingleton<AudioManager>.instance.PlaySound(12);
		}

		// Token: 0x060112D2 RID: 70354 RVA: 0x004EFD34 File Offset: 0x004EE134
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x060112D3 RID: 70355 RVA: 0x004EFD38 File Offset: 0x004EE138
		protected sealed override void _bindExUI()
		{
			this.mItemParent = this.mBind.GetGameObject("ItemParent");
			this.mOK = this.mBind.GetCom<Button>("OK");
			if (null != this.mOK)
			{
				this.mOK.onClick.AddListener(new UnityAction(this._onOKButtonClick));
			}
			this.mPrefabs = this.mBind.GetGameObject("Prefabs");
		}

		// Token: 0x060112D4 RID: 70356 RVA: 0x004EFDB4 File Offset: 0x004EE1B4
		protected sealed override void _unbindExUI()
		{
			this.mItemParent = null;
			if (null != this.mOK)
			{
				this.mOK.onClick.RemoveListener(new UnityAction(this._onOKButtonClick));
			}
			this.mOK = null;
			this.mPrefabs = null;
		}

		// Token: 0x060112D5 RID: 70357 RVA: 0x004EFE03 File Offset: 0x004EE203
		private void _onOKButtonClick()
		{
			this.frameMgr.CloseFrame<InscriptionSynthesisResultFrame>(this, false);
		}

		// Token: 0x0400B154 RID: 45396
		private GameObject mItemParent;

		// Token: 0x0400B155 RID: 45397
		private Button mOK;

		// Token: 0x0400B156 RID: 45398
		private GameObject mPrefabs;
	}
}
