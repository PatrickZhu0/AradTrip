using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015DF RID: 5599
	internal class FunctionUnlockFrame : ClientFrame
	{
		// Token: 0x0600DB48 RID: 56136 RVA: 0x0037446A File Offset: 0x0037286A
		protected override void _OnOpenFrame()
		{
			this.data = (UnlockData)this.userData;
			this.InitInterface();
		}

		// Token: 0x0600DB49 RID: 56137 RVA: 0x00374483 File Offset: 0x00372883
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600DB4A RID: 56138 RVA: 0x0037448B File Offset: 0x0037288B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FunctionUnlock/FunctionUnlockFrame";
		}

		// Token: 0x0600DB4B RID: 56139 RVA: 0x00374492 File Offset: 0x00372892
		private void ClearData()
		{
			this.data.ClearData();
			this.interval = 0f;
			if (this.ResPlayEnd != null)
			{
				this.ResPlayEnd = null;
			}
		}

		// Token: 0x0600DB4C RID: 56140 RVA: 0x003744BC File Offset: 0x003728BC
		private void InitInterface()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(this.data.FuncUnlockID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.IconPath != string.Empty && tableItem.IconPath != "-")
			{
				ETCImageLoader.LoadSprite(ref this.icon, tableItem.IconPath, true);
				this.name.text = tableItem.Name;
			}
		}

		// Token: 0x0600DB4D RID: 56141 RVA: 0x0037453E File Offset: 0x0037293E
		private void DoTweenPlayEnd()
		{
			if (this.ResPlayEnd != null)
			{
				this.ResPlayEnd();
			}
		}

		// Token: 0x0600DB4E RID: 56142 RVA: 0x00374556 File Offset: 0x00372956
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600DB4F RID: 56143 RVA: 0x0037455C File Offset: 0x0037295C
		protected override void _OnUpdate(float timeElapsed)
		{
			this.interval += timeElapsed;
			if (this.interval < 1f)
			{
				return;
			}
			RectTransform rect = this.pos.GetComponent<RectTransform>();
			TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => rect.position, delegate(Vector3 r)
			{
				rect.position = r;
			}, this.data.pos, 1.8f), 12), new TweenCallback(this.DoTweenPlayEnd));
			this.interval = 0f;
		}

		// Token: 0x04008133 RID: 33075
		public FunctionUnlockFrame.PlayEnd ResPlayEnd;

		// Token: 0x04008134 RID: 33076
		private UnlockData data = default(UnlockData);

		// Token: 0x04008135 RID: 33077
		private float interval;

		// Token: 0x04008136 RID: 33078
		[UIObject("pos")]
		protected GameObject pos;

		// Token: 0x04008137 RID: 33079
		[UIControl("pos/icon", null, 0)]
		protected Image icon;

		// Token: 0x04008138 RID: 33080
		[UIControl("pos/name", null, 0)]
		protected Text name;

		// Token: 0x020015E0 RID: 5600
		// (Invoke) Token: 0x0600DB51 RID: 56145
		public delegate void PlayEnd();
	}
}
