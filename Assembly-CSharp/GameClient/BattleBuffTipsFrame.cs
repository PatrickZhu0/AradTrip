using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001078 RID: 4216
	public class BattleBuffTipsFrame : ClientFrame
	{
		// Token: 0x06009F4D RID: 40781 RVA: 0x001FD6D8 File Offset: 0x001FBAD8
		protected override void _bindExUI()
		{
			this.mCloseButton = this.mBind.GetCom<Button>("CloseBtn");
			if (this.mCloseButton != null)
			{
				this.mCloseButton.onClick.AddListener(new UnityAction(this._onCloseBtnClick));
			}
			this.mContent = this.mBind.GetCom<RectTransform>("Content");
			this.scrollRectHandle = this.mBind.GetCom<BuffTipsScrollRectHandle>("ScrollRectHandle");
			this.mTipsParent = this.mBind.GetGameObject("TipsParent");
			if (this.mTipsParent != null)
			{
				this.mTipsParentVertical = this.mTipsParent.GetComponent<VerticalLayoutGroup>();
			}
		}

		// Token: 0x06009F4E RID: 40782 RVA: 0x001FD78C File Offset: 0x001FBB8C
		protected override void _unbindExUI()
		{
			if (this.mCloseButton != null)
			{
				this.mCloseButton.onClick.AddListener(new UnityAction(this._onCloseBtnClick));
			}
			this.mCloseButton = null;
			this.mContent = null;
			this.scrollRectHandle = null;
			this.mTipsParent = null;
			this.mTipsParentVertical = null;
		}

		// Token: 0x06009F4F RID: 40783 RVA: 0x001FD7E9 File Offset: 0x001FBBE9
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/BattleBuffTips";
		}

		// Token: 0x06009F50 RID: 40784 RVA: 0x001FD7F0 File Offset: 0x001FBBF0
		protected sealed override void _OnLoadPrefabFinish()
		{
			if (this.mComClienFrame == null)
			{
				this.mComClienFrame = this.frame.AddComponent<ComClientFrame>();
			}
			this.mComClienFrame.SetGroupTag("system");
		}

		// Token: 0x06009F51 RID: 40785 RVA: 0x001FD820 File Offset: 0x001FBC20
		protected override void _OnOpenFrame()
		{
			object[] array = (object[])this.userData;
			if (array == null || array.Length != 2)
			{
				return;
			}
			this.buffDisplayFrame = (array[0] as DungeonBuffDisplayFrame);
			if (this.buffDisplayFrame == null)
			{
				return;
			}
			Vector3 position = (Vector3)array[1];
			this.mContent.position = position;
			this.mTipsComBindList.Clear();
		}

		// Token: 0x06009F52 RID: 40786 RVA: 0x001FD884 File Offset: 0x001FBC84
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.buffDisplayFrame.IsInited)
			{
				if (this.buffCount != this.buffDisplayFrame.GetBuffTipsCount())
				{
					this.buffCount = this.buffDisplayFrame.GetBuffTipsCount();
					this._ResetTipsRect();
					if (this.mTipsParentVertical != null)
					{
						this.mTipsParentVertical.enabled = false;
					}
				}
				this._UpdateAllTips(this.buffCount);
				if (this.mTipsParentVertical != null && !this.mTipsParentVertical.enabled)
				{
					this.mTipsParentVertical.enabled = true;
				}
				if (this.buffDisplayFrame.GetValidBuffCount() == 0)
				{
					base.Close(false);
				}
			}
			if (this.scrollRectHandle != null && this.scrollRectHandle.mPointerUpFlag)
			{
				if (this.scrollRectHandle.mPointerDownFlag && !this.scrollRectHandle.mBeginDragFlag)
				{
					this.scrollRectHandle.ResetFlag();
					base.Close(false);
				}
				else
				{
					this.scrollRectHandle.ResetFlag();
				}
			}
		}

		// Token: 0x06009F53 RID: 40787 RVA: 0x001FD9A0 File Offset: 0x001FBDA0
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			if (this.mTipsComBindList != null)
			{
				for (int i = 0; i < this.mTipsComBindList.Count; i++)
				{
					BattleBuffTipsFrame.DestroyTip(this.mTipsComBindList[i]);
				}
			}
			this.buffDisplayFrame.CloseBuffTipListUpdate();
		}

		// Token: 0x06009F54 RID: 40788 RVA: 0x001FD9F6 File Offset: 0x001FBDF6
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06009F55 RID: 40789 RVA: 0x001FD9FC File Offset: 0x001FBDFC
		private void _UpdateAllTips(int count)
		{
			if (this.mTipsComBindList == null)
			{
				return;
			}
			int num = count - this.mTipsComBindList.Count;
			if (num >= 0)
			{
				for (int i = 0; i < this.mTipsComBindList.Count; i++)
				{
					ComCommonBind bind = this.mTipsComBindList[i];
					this._SetComBindGameObjectActive(true, bind);
				}
				if (num > 0)
				{
					for (int j = 0; j < num; j++)
					{
						ComCommonBind item = BattleBuffTipsFrame.CreateTips(this.mTipsParent);
						this.mTipsComBindList.Add(item);
					}
				}
			}
			else
			{
				for (int k = 0; k < this.mTipsComBindList.Count; k++)
				{
					ComCommonBind bind2 = this.mTipsComBindList[k];
					if (k < count)
					{
						this._SetComBindGameObjectActive(true, bind2);
					}
					else
					{
						this._SetComBindGameObjectActive(false, bind2);
					}
				}
			}
			for (int l = 0; l < this.mTipsComBindList.Count; l++)
			{
				this._UpdateOneTipByIndex(l);
			}
		}

		// Token: 0x06009F56 RID: 40790 RVA: 0x001FDB09 File Offset: 0x001FBF09
		private void _SetComBindGameObjectActive(bool active, ComCommonBind bind)
		{
			if (bind != null && bind.gameObject.activeSelf != active)
			{
				bind.gameObject.SetActive(active);
			}
		}

		// Token: 0x06009F57 RID: 40791 RVA: 0x001FDB34 File Offset: 0x001FBF34
		private void _UpdateOneTipByIndex(int index)
		{
			ComCommonBind comCommonBind = this.mTipsComBindList[index];
			if (comCommonBind == null)
			{
				return;
			}
			BuffInfoTip buffTipsByIndex = this.buffDisplayFrame.GetBuffTipsByIndex(index);
			if (buffTipsByIndex == null)
			{
				return;
			}
			Image com = comCommonBind.GetCom<Image>("Icon");
			Text com2 = comCommonBind.GetCom<Text>("Name");
			Text com3 = comCommonBind.GetCom<Text>("LeftTime");
			Text com4 = comCommonBind.GetCom<Text>("Info");
			if (com != null)
			{
				ETCImageLoader.LoadSprite(ref com, buffTipsByIndex.IconPath, true);
			}
			if (com2 != null)
			{
				com2.text = buffTipsByIndex.Name;
			}
			if (com3 != null)
			{
				com3.text = buffTipsByIndex.LeftTime;
			}
			if (com4 != null)
			{
				if (!string.IsNullOrEmpty(buffTipsByIndex.Detail))
				{
					com4.text = buffTipsByIndex.Detail;
					if (!com4.enabled)
					{
						com4.enabled = true;
					}
				}
				else
				{
					com4.enabled = false;
				}
			}
		}

		// Token: 0x06009F58 RID: 40792 RVA: 0x001FDC3C File Offset: 0x001FC03C
		private void _ResetTipsRect()
		{
			if (this.mTipsComBindList != null)
			{
				for (int i = 0; i < this.mTipsComBindList.Count; i++)
				{
					ComCommonBind comCommonBind = this.mTipsComBindList[i];
					if (comCommonBind != null)
					{
						Text com = comCommonBind.GetCom<Text>("Info");
						if (com != null)
						{
							com.text = string.Empty;
						}
					}
				}
			}
		}

		// Token: 0x06009F59 RID: 40793 RVA: 0x001FDCAC File Offset: 0x001FC0AC
		private void _onCloseBtnClick()
		{
			base.Close(false);
		}

		// Token: 0x06009F5A RID: 40794 RVA: 0x001FDCB8 File Offset: 0x001FC0B8
		public static ComCommonBind CreateTips(GameObject parent)
		{
			if (parent == null)
			{
				Logger.LogError("BattleBuffTipsFrame Create function param parent is null!");
				return null;
			}
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/BattleUI/BattleBuffTip", enResourceType.UIPrefab, 2U);
			if (gameObject != null)
			{
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component != null)
				{
					Utility.AttachTo(component.gameObject, parent, false);
					return component;
				}
			}
			return null;
		}

		// Token: 0x06009F5B RID: 40795 RVA: 0x001FDD20 File Offset: 0x001FC120
		public static void DestroyTip(ComCommonBind comTip)
		{
			if (comTip != null && comTip.gameObject != null)
			{
				Text com = comTip.GetCom<Text>("Info");
				if (com != null)
				{
					com.text = string.Empty;
				}
				Singleton<CGameObjectPool>.instance.RecycleGameObject(comTip.gameObject);
			}
		}

		// Token: 0x040057C1 RID: 22465
		private Button mCloseButton;

		// Token: 0x040057C2 RID: 22466
		private RectTransform mContent;

		// Token: 0x040057C3 RID: 22467
		private BuffTipsScrollRectHandle scrollRectHandle;

		// Token: 0x040057C4 RID: 22468
		private GameObject mTipsParent;

		// Token: 0x040057C5 RID: 22469
		private VerticalLayoutGroup mTipsParentVertical;

		// Token: 0x040057C6 RID: 22470
		private DungeonBuffDisplayFrame buffDisplayFrame;

		// Token: 0x040057C7 RID: 22471
		private int buffCount = -1;

		// Token: 0x040057C8 RID: 22472
		private List<ComCommonBind> mTipsComBindList = new List<ComCommonBind>();
	}
}
