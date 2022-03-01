using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014A4 RID: 5284
	public class OpenAwakeFrame : ClientFrame
	{
		// Token: 0x0600CCE2 RID: 52450 RVA: 0x003254DA File Offset: 0x003238DA
		protected sealed override void _OnOpenFrame()
		{
		}

		// Token: 0x0600CCE3 RID: 52451 RVA: 0x003254DC File Offset: 0x003238DC
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0600CCE4 RID: 52452 RVA: 0x003254DE File Offset: 0x003238DE
		public sealed override string GetPrefabPath()
		{
			return "UI/Prefabs/OpenAwakeFrame";
		}

		// Token: 0x0600CCE5 RID: 52453 RVA: 0x003254E5 File Offset: 0x003238E5
		[UIEventHandle("btOK")]
		private void OnClickOK()
		{
			this.frameMgr.CloseFrame<OpenAwakeFrame>(this, false);
		}

		// Token: 0x0600CCE6 RID: 52454 RVA: 0x003254F4 File Offset: 0x003238F4
		public void SetNotifyDataByTable(CommonTipsDesc NotifyData, string content)
		{
			if (NotifyData != null)
			{
				this.SetContent(content);
				this.SetDes(NotifyData.TitleText);
			}
		}

		// Token: 0x0600CCE7 RID: 52455 RVA: 0x0032550F File Offset: 0x0032390F
		public void AddListener(UnityAction OnOKCallBack)
		{
			if (OnOKCallBack != null)
			{
				this.ButtonOK.onClick.RemoveListener(OnOKCallBack);
				this.ButtonOK.onClick.AddListener(OnOKCallBack);
			}
		}

		// Token: 0x0600CCE8 RID: 52456 RVA: 0x00325539 File Offset: 0x00323939
		public void SetContent(string str)
		{
			this.content.gameObject.SetActive(false);
			this.content.text = str;
		}

		// Token: 0x0600CCE9 RID: 52457 RVA: 0x00325558 File Offset: 0x00323958
		public void SetDes(string str)
		{
			this.description.text = str;
		}

		// Token: 0x0600CCEA RID: 52458 RVA: 0x00325568 File Offset: 0x00323968
		public void SetIcon(string path)
		{
			if (path == string.Empty || path == "-")
			{
				this.icon.gameObject.SetActive(false);
			}
			Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(path, typeof(Sprite), true, 0U).obj as Sprite;
			if (sprite == null)
			{
				this.icon.gameObject.SetActive(false);
			}
			ETCImageLoader.LoadSprite(ref this.icon, path, true);
		}

		// Token: 0x04007752 RID: 30546
		[UIControl("content", null, 0)]
		protected new Text content;

		// Token: 0x04007753 RID: 30547
		[UIControl("icon", null, 0)]
		protected Image icon;

		// Token: 0x04007754 RID: 30548
		[UIControl("description", null, 0)]
		protected Text description;

		// Token: 0x04007755 RID: 30549
		[UIControl("btOK", null, 0)]
		protected Button ButtonOK;
	}
}
