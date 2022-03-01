using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200156F RID: 5487
	public class ComVoiceTalkButtonGroup : MonoBehaviour
	{
		// Token: 0x0600D65E RID: 54878 RVA: 0x00358DF4 File Offset: 0x003571F4
		private void Awake()
		{
			if (this.hideTalkBtns == null)
			{
				this.hideTalkBtns = new List<ComVoiceTalkButton>();
			}
			if (this.talkBtns != null)
			{
				if (this.expandTalkBtns == null)
				{
					this.expandTalkBtns = new List<ComVoiceTalkButton>();
				}
				for (int i = 0; i < this.talkBtns.Count; i++)
				{
					ComVoiceTalkButton comVoiceTalkButton = this.talkBtns[i];
					comVoiceTalkButton.sortIndex = i;
					if (!(comVoiceTalkButton == null))
					{
						comVoiceTalkButton.group = this;
						if (i == 0)
						{
							this.headTalkBtn = comVoiceTalkButton;
						}
						else
						{
							this.expandTalkBtns.Add(comVoiceTalkButton);
						}
					}
				}
			}
			this._RecoverGroup();
		}

		// Token: 0x0600D65F RID: 54879 RVA: 0x00358EA4 File Offset: 0x003572A4
		private void OnDestroy()
		{
			this.headTalkBtn = null;
			if (this.expandTalkBtns != null)
			{
				this.expandTalkBtns.Clear();
				this.expandTalkBtns = null;
			}
			if (this.hideTalkBtns != null)
			{
				this.hideTalkBtns.Clear();
				this.hideTalkBtns = null;
			}
		}

		// Token: 0x0600D660 RID: 54880 RVA: 0x00358EF2 File Offset: 0x003572F2
		public List<ComVoiceTalkButton> GetAllTalkBtns()
		{
			return this.talkBtns;
		}

		// Token: 0x0600D661 RID: 54881 RVA: 0x00358EFC File Offset: 0x003572FC
		public void UpdateAllTalkBtns(List<string> talkSceneIds)
		{
			if (this.talkBtns == null || talkSceneIds == null)
			{
				return;
			}
			for (int num = 0; num != Mathf.Min(this.talkBtns.Count, talkSceneIds.Count); num++)
			{
				ComVoiceTalkButton comVoiceTalkButton = this.talkBtns[num];
				if (!(comVoiceTalkButton == null))
				{
					if (comVoiceTalkButton.bType == ComVoiceTalkButton.TalkBtnType.MicChannelOn)
					{
						comVoiceTalkButton.param1 = talkSceneIds[num];
					}
				}
			}
		}

		// Token: 0x0600D662 RID: 54882 RVA: 0x00358F7C File Offset: 0x0035737C
		private void _ExpandGroup()
		{
			if (null == this.expandRoot)
			{
				return;
			}
			this._ResetSortIndex(this.hideTalkBtns);
			if (this.hideTalkBtns != null)
			{
				for (int i = 0; i < this.hideTalkBtns.Count; i++)
				{
					ComVoiceTalkButton comVoiceTalkButton = this.hideTalkBtns[i];
					if (!(comVoiceTalkButton == null))
					{
						Utility.AttachTo(comVoiceTalkButton.gameObject, this.expandRoot, false);
						if (this.expandTalkBtns != null && !this.expandTalkBtns.Contains(comVoiceTalkButton))
						{
							this.expandTalkBtns.Add(comVoiceTalkButton);
						}
					}
				}
				this.hideTalkBtns.Clear();
			}
		}

		// Token: 0x0600D663 RID: 54883 RVA: 0x00359034 File Offset: 0x00357434
		private void _RecoverGroup()
		{
			if (null == this.hideRoot)
			{
				return;
			}
			this._ResetSortIndex(this.expandTalkBtns);
			if (this.expandTalkBtns != null)
			{
				for (int i = 0; i < this.expandTalkBtns.Count; i++)
				{
					ComVoiceTalkButton comVoiceTalkButton = this.expandTalkBtns[i];
					if (!(comVoiceTalkButton == null))
					{
						Utility.AttachTo(comVoiceTalkButton.gameObject, this.hideRoot, false);
						if (this.hideTalkBtns != null && !this.hideTalkBtns.Contains(comVoiceTalkButton))
						{
							this.hideTalkBtns.Add(comVoiceTalkButton);
						}
					}
				}
				this.expandTalkBtns.Clear();
			}
		}

		// Token: 0x0600D664 RID: 54884 RVA: 0x003590EC File Offset: 0x003574EC
		public void SetMicChannelOnTalkBtnSelected(string talkChannelId, bool bSelected)
		{
			if (this.talkBtns == null || this.talkBtns.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.talkBtns.Count; i++)
			{
				ComVoiceTalkButton comVoiceTalkButton = this.talkBtns[i];
				if (!(comVoiceTalkButton == null) && comVoiceTalkButton.bType == ComVoiceTalkButton.TalkBtnType.MicChannelOn)
				{
					string text = comVoiceTalkButton.param1 as string;
					if (!string.IsNullOrEmpty(text) && !(text != talkChannelId))
					{
						this.SetComVoiceTalkBtnSelected(comVoiceTalkButton, bSelected);
					}
				}
			}
		}

		// Token: 0x0600D665 RID: 54885 RVA: 0x0035918C File Offset: 0x0035758C
		public void SetMicOffTalkBtnSelected(bool bSelected)
		{
			if (this.talkBtns == null || this.talkBtns.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.talkBtns.Count; i++)
			{
				ComVoiceTalkButton comVoiceTalkButton = this.talkBtns[i];
				if (!(comVoiceTalkButton == null) && comVoiceTalkButton.bType == ComVoiceTalkButton.TalkBtnType.MicAllOff)
				{
					this.SetComVoiceTalkBtnSelected(comVoiceTalkButton, bSelected);
				}
			}
		}

		// Token: 0x0600D666 RID: 54886 RVA: 0x00359204 File Offset: 0x00357604
		public void SetComVoiceTalkBtnSelected(ComVoiceTalkButton comBtn, bool bSelected)
		{
			if (!bSelected)
			{
				this._ExpandGroup();
				return;
			}
			if (null == comBtn)
			{
				return;
			}
			this._TrySetTalkBtnToHead(comBtn);
			this._RecoverGroup();
		}

		// Token: 0x0600D667 RID: 54887 RVA: 0x00359230 File Offset: 0x00357630
		private void _TrySetTalkBtnToHead(ComVoiceTalkButton talkBtn)
		{
			if (null == talkBtn)
			{
				return;
			}
			if (talkBtn == this.headTalkBtn)
			{
				return;
			}
			this._ResetAllTalkBtnsToExpandRoot();
			Utility.AttachTo(talkBtn.gameObject, this.headRoot, false);
			if (this.expandTalkBtns != null)
			{
				this.expandTalkBtns.Remove(talkBtn);
			}
			if (this.hideTalkBtns != null)
			{
				this.hideTalkBtns.Remove(talkBtn);
			}
			this.headTalkBtn = talkBtn;
		}

		// Token: 0x0600D668 RID: 54888 RVA: 0x003592AC File Offset: 0x003576AC
		private void _ResetAllTalkBtnsToExpandRoot()
		{
			if (this.expandTalkBtns == null)
			{
				return;
			}
			if (!this.expandTalkBtns.Contains(this.headTalkBtn))
			{
				this.expandTalkBtns.Insert(0, this.headTalkBtn);
			}
			if (this.hideTalkBtns != null && this.hideTalkBtns.Count > 0)
			{
				for (int i = 0; i < this.hideTalkBtns.Count; i++)
				{
					ComVoiceTalkButton comVoiceTalkButton = this.hideTalkBtns[i];
					if (!(comVoiceTalkButton == null))
					{
						if (!this.expandTalkBtns.Contains(comVoiceTalkButton))
						{
							this.expandTalkBtns.Add(comVoiceTalkButton);
						}
					}
				}
			}
		}

		// Token: 0x0600D669 RID: 54889 RVA: 0x00359360 File Offset: 0x00357760
		private void _ResetSortIndex(List<ComVoiceTalkButton> unSortedBtnList)
		{
			if (unSortedBtnList == null || unSortedBtnList.Count <= 0)
			{
				return;
			}
			unSortedBtnList.Sort((ComVoiceTalkButton x, ComVoiceTalkButton y) => x.sortIndex.CompareTo(y.sortIndex));
		}

		// Token: 0x04007DDB RID: 32219
		[Header("请按顺序添加ComTalkButton")]
		[SerializeField]
		private List<ComVoiceTalkButton> talkBtns;

		// Token: 0x04007DDC RID: 32220
		[SerializeField]
		private GameObject headRoot;

		// Token: 0x04007DDD RID: 32221
		[SerializeField]
		private GameObject expandRoot;

		// Token: 0x04007DDE RID: 32222
		[SerializeField]
		private GameObject hideRoot;

		// Token: 0x04007DDF RID: 32223
		private ComVoiceTalkButton headTalkBtn;

		// Token: 0x04007DE0 RID: 32224
		private List<ComVoiceTalkButton> expandTalkBtns;

		// Token: 0x04007DE1 RID: 32225
		private List<ComVoiceTalkButton> hideTalkBtns;
	}
}
