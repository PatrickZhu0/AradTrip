using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001105 RID: 4357
	public class ChijiBuffTipsFrame : ClientFrame
	{
		// Token: 0x0600A522 RID: 42274 RVA: 0x002211B5 File Offset: 0x0021F5B5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiBuffTips";
		}

		// Token: 0x0600A523 RID: 42275 RVA: 0x002211BC File Offset: 0x0021F5BC
		protected override void _OnOpenFrame()
		{
			this.ChiJiBuffID = (int)this.userData;
			this.InitInterface();
			this.SetupFramePosition(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		}

		// Token: 0x0600A524 RID: 42276 RVA: 0x00221205 File Offset: 0x0021F605
		protected override void _OnCloseFrame()
		{
			this.ChiJiBuffID = 0;
			this.isUpdate = false;
			this.chijiBuffTipsTime = 3f;
		}

		// Token: 0x0600A525 RID: 42277 RVA: 0x00221220 File Offset: 0x0021F620
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A526 RID: 42278 RVA: 0x00221223 File Offset: 0x0021F623
		protected override void _OnUpdate(float timeElapsed)
		{
			if (!this.isUpdate)
			{
				return;
			}
			this.chijiBuffTipsTime -= timeElapsed;
			if (this.chijiBuffTipsTime <= 0f)
			{
				base.Close(false);
			}
		}

		// Token: 0x0600A527 RID: 42279 RVA: 0x00221258 File Offset: 0x0021F658
		private void InitInterface()
		{
			this.isUpdate = true;
			ChijiBuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChijiBuffTable>(this.ChiJiBuffID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.mBuffName != null)
			{
				this.mBuffName.text = tableItem.Name;
			}
			if (this.mBuffDesc != null)
			{
				this.mBuffDesc.text = tableItem.Description;
			}
		}

		// Token: 0x0600A528 RID: 42280 RVA: 0x002212D4 File Offset: 0x0021F6D4
		private void SetupFramePosition(Vector2 pos)
		{
			RectTransform component = this.mContent.GetComponent<RectTransform>();
			RectTransform rectTransform = component.transform.parent as RectTransform;
			Vector2 anchoredPosition;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, pos, Singleton<ClientSystemManager>.GetInstance().UICamera, ref anchoredPosition))
			{
				return;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			Vector2 vector;
			vector..ctor(10f, 10f);
			float x = vector.x;
			float num = rectTransform.rect.size.x - vector.x - component.rect.size.x;
			float y = vector.y;
			float num2 = -(rectTransform.rect.size.y - vector.y - component.rect.size.y);
			anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, x, num);
			anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, num2, y);
			component.anchoredPosition = anchoredPosition;
		}

		// Token: 0x0600A529 RID: 42281 RVA: 0x002213F0 File Offset: 0x0021F7F0
		protected override void _bindExUI()
		{
			this.mBuffName = this.mBind.GetCom<Text>("BuffName");
			this.mBuffDesc = this.mBind.GetCom<Text>("BuffDesc");
			this.mContent = this.mBind.GetGameObject("Content");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x0600A52A RID: 42282 RVA: 0x00221484 File Offset: 0x0021F884
		protected override void _unbindExUI()
		{
			this.mBuffName = null;
			this.mBuffDesc = null;
			this.mContent = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x0600A52B RID: 42283 RVA: 0x002214DA File Offset: 0x0021F8DA
		private void _onCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x04005C2B RID: 23595
		private int ChiJiBuffID;

		// Token: 0x04005C2C RID: 23596
		private bool isUpdate;

		// Token: 0x04005C2D RID: 23597
		private float chijiBuffTipsTime = 3f;

		// Token: 0x04005C2E RID: 23598
		private Text mBuffName;

		// Token: 0x04005C2F RID: 23599
		private Text mBuffDesc;

		// Token: 0x04005C30 RID: 23600
		private GameObject mContent;

		// Token: 0x04005C31 RID: 23601
		private Button mClose;
	}
}
