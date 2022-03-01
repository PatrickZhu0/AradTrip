using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F07 RID: 3847
	internal class ComMenuFrame : ClientFrame
	{
		// Token: 0x0600964D RID: 38477 RVA: 0x001C7175 File Offset: 0x001C5575
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/ComMenu";
		}

		// Token: 0x0600964E RID: 38478 RVA: 0x001C717C File Offset: 0x001C557C
		protected override void _OnOpenFrame()
		{
			this._Initialize();
		}

		// Token: 0x0600964F RID: 38479 RVA: 0x001C7184 File Offset: 0x001C5584
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06009650 RID: 38480 RVA: 0x001C7188 File Offset: 0x001C5588
		private void _Initialize()
		{
			this.m_content = Utility.FindGameObject(this.frame, "Content", true);
			this.m_close = Utility.GetComponetInChild<Button>(this.frame, "BG");
			this.m_close.onClick.AddListener(new UnityAction(this._OnCloseClicked));
			this._SetupFramePosition(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		}

		// Token: 0x06009651 RID: 38481 RVA: 0x001C7204 File Offset: 0x001C5604
		private void _SetupFramePosition(Vector2 pos)
		{
			RectTransform component = this.m_content.GetComponent<RectTransform>();
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

		// Token: 0x06009652 RID: 38482 RVA: 0x001C731E File Offset: 0x001C571E
		public void _OnCloseClicked()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnCloseMenu, null, null, null, null);
		}

		// Token: 0x04004D28 RID: 19752
		private GameObject m_content;

		// Token: 0x04004D29 RID: 19753
		private Button m_close;
	}
}
