using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001592 RID: 5522
	internal class NewMessageNoticeFrame : ClientFrame
	{
		// Token: 0x0600D81B RID: 55323 RVA: 0x0036016C File Offset: 0x0035E56C
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600D81C RID: 55324 RVA: 0x00360170 File Offset: 0x0035E570
		protected override void _OnUpdate(float timeElapsed)
		{
			NewMessageNoticeManager instance = DataManager<NewMessageNoticeManager>.GetInstance();
			if (this.mDataVersion != instance.DataVersion)
			{
				instance.MarkAllRead();
				this.mDataVersion = instance.DataVersion;
				this.mListScript.SetElementAmount(instance.mNewMessageNoticeCount);
			}
		}

		// Token: 0x0600D81D RID: 55325 RVA: 0x003601B7 File Offset: 0x0035E5B7
		[UIEventHandle("Title/Button")]
		protected void OnClose()
		{
			base.Close(false);
		}

		// Token: 0x0600D81E RID: 55326 RVA: 0x003601C0 File Offset: 0x0035E5C0
		protected override void _OnOpenFrame()
		{
			this.mComBind = this.frame.GetComponent<ComCommonBind>();
			this.mListScript = this.mComBind.GetCom<ComUIListScript>("ListControl");
			Button com = this.mComBind.GetCom<Button>("Clear");
			if (com)
			{
				com.onClick.AddListener(delegate()
				{
					DataManager<NewMessageNoticeManager>.GetInstance().ClearNewMessageNotice();
				});
			}
			this.mListScript.onBindItem = delegate(GameObject obj)
			{
				NewMessageNoticeScript newMessageNoticeScript = new NewMessageNoticeScript();
				ComUIListElementScript elem = obj.GetComponent<ComUIListElementScript>();
				ComCommonBind component = obj.GetComponent<ComCommonBind>();
				newMessageNoticeScript.title = component.GetCom<Text>("Title");
				newMessageNoticeScript.message = component.GetCom<Text>("Message");
				Button com2 = component.GetCom<Button>("Forward");
				com2.onClick.AddListener(delegate()
				{
					this.OnForward(elem);
				});
				newMessageNoticeScript.forwardText = component.GetCom<Text>("ForwardText");
				return newMessageNoticeScript;
			};
			this.mListScript.onItemVisiable = delegate(ComUIListElementScript elem)
			{
				NewMessageNoticeManager instance = DataManager<NewMessageNoticeManager>.GetInstance();
				NewMessageNoticeData newMessageNoticeByIndex = instance.GetNewMessageNoticeByIndex(elem.m_index);
				if (newMessageNoticeByIndex != null)
				{
					NewMessageNoticeScript newMessageNoticeScript = elem.gameObjectBindScript as NewMessageNoticeScript;
					newMessageNoticeScript.title.text = newMessageNoticeByIndex.mTitle;
					newMessageNoticeScript.message.text = newMessageNoticeByIndex.mMessage;
				}
			};
			this.mListScript.Initialize();
		}

		// Token: 0x0600D81F RID: 55327 RVA: 0x00360284 File Offset: 0x0035E684
		protected void OnForward(ComUIListElementScript item)
		{
			NewMessageNoticeManager instance = DataManager<NewMessageNoticeManager>.GetInstance();
			NewMessageNoticeData newMessageNoticeByIndex = instance.GetNewMessageNoticeByIndex(item.m_index);
			if (newMessageNoticeByIndex != null && newMessageNoticeByIndex.mForwardAction != null)
			{
				newMessageNoticeByIndex.mForwardAction(newMessageNoticeByIndex);
			}
			base.Close(false);
		}

		// Token: 0x0600D820 RID: 55328 RVA: 0x003602C8 File Offset: 0x0035E6C8
		protected override void _OnCloseFrame()
		{
			this.mDataVersion = ulong.MaxValue;
		}

		// Token: 0x0600D821 RID: 55329 RVA: 0x003602D2 File Offset: 0x0035E6D2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/NewMessageNotice";
		}

		// Token: 0x04007EDC RID: 32476
		private ComCommonBind mComBind;

		// Token: 0x04007EDD RID: 32477
		private ComUIListScript mListScript;

		// Token: 0x04007EDE RID: 32478
		private ulong mDataVersion = ulong.MaxValue;
	}
}
