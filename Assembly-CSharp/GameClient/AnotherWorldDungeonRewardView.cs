using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001077 RID: 4215
	public class AnotherWorldDungeonRewardView : MonoBehaviour
	{
		// Token: 0x06009F41 RID: 40769 RVA: 0x001FD2F8 File Offset: 0x001FB6F8
		private void Awake()
		{
			if (this.mAnotherWorldReward0Btn != null)
			{
				this.mAnotherWorldReward0Btn.onClick.RemoveAllListeners();
				this.mAnotherWorldReward0Btn.onClick.AddListener(new UnityAction(this.OnAnotherWorldRewardBtn0Click));
			}
			if (this.mAnotherWorldReward1Btn != null)
			{
				this.mAnotherWorldReward1Btn.onClick.RemoveAllListeners();
				this.mAnotherWorldReward1Btn.onClick.AddListener(new UnityAction(this.OnAnotherWorldRewardBtn1Click));
			}
			if (this.mAnotherWorldReward2Btn != null)
			{
				this.mAnotherWorldReward2Btn.onClick.RemoveAllListeners();
				this.mAnotherWorldReward2Btn.onClick.AddListener(new UnityAction(this.OnAnotherWorldRewardBtn2Click));
			}
			if (this.mAnotherWorldReward3Btn != null)
			{
				this.mAnotherWorldReward3Btn.onClick.RemoveAllListeners();
				this.mAnotherWorldReward3Btn.onClick.AddListener(new UnityAction(this.OnAnotherWorldRewardBtn3Click));
			}
		}

		// Token: 0x06009F42 RID: 40770 RVA: 0x001FD3FC File Offset: 0x001FB7FC
		private void OnDestroy()
		{
			if (this.mAnotherWorldReward0Btn != null)
			{
				this.mAnotherWorldReward0Btn.onClick.RemoveListener(new UnityAction(this.OnAnotherWorldRewardBtn0Click));
			}
			if (this.mAnotherWorldReward1Btn != null)
			{
				this.mAnotherWorldReward1Btn.onClick.RemoveListener(new UnityAction(this.OnAnotherWorldRewardBtn1Click));
			}
			if (this.mAnotherWorldReward2Btn != null)
			{
				this.mAnotherWorldReward2Btn.onClick.RemoveListener(new UnityAction(this.OnAnotherWorldRewardBtn2Click));
			}
			if (this.mAnotherWorldReward3Btn != null)
			{
				this.mAnotherWorldReward3Btn.onClick.RemoveListener(new UnityAction(this.OnAnotherWorldRewardBtn3Click));
			}
			this.callBack = null;
		}

		// Token: 0x06009F43 RID: 40771 RVA: 0x001FD4C4 File Offset: 0x001FB8C4
		public void InitView(OnAnotherWorldRewardClick click)
		{
			this.callBack = click;
		}

		// Token: 0x06009F44 RID: 40772 RVA: 0x001FD4CD File Offset: 0x001FB8CD
		private void OnAnotherWorldRewardBtn0Click()
		{
			this.OnAnotherWorldRewardBtnClick(0);
		}

		// Token: 0x06009F45 RID: 40773 RVA: 0x001FD4D6 File Offset: 0x001FB8D6
		private void OnAnotherWorldRewardBtn1Click()
		{
			this.OnAnotherWorldRewardBtnClick(1);
		}

		// Token: 0x06009F46 RID: 40774 RVA: 0x001FD4DF File Offset: 0x001FB8DF
		private void OnAnotherWorldRewardBtn2Click()
		{
			this.OnAnotherWorldRewardBtnClick(2);
		}

		// Token: 0x06009F47 RID: 40775 RVA: 0x001FD4E8 File Offset: 0x001FB8E8
		private void OnAnotherWorldRewardBtn3Click()
		{
			this.OnAnotherWorldRewardBtnClick(3);
		}

		// Token: 0x06009F48 RID: 40776 RVA: 0x001FD4F1 File Offset: 0x001FB8F1
		private void OnAnotherWorldRewardBtnClick(int idx)
		{
			if (this.callBack != null)
			{
				this.callBack(idx);
			}
		}

		// Token: 0x06009F49 RID: 40777 RVA: 0x001FD50C File Offset: 0x001FB90C
		public void StartAnotherWorldSelect(int idx, UnityAction callback)
		{
			for (int i = 0; i < this.mRewardCount; i++)
			{
				if (idx == i)
				{
					Image image = this.mAnotherWorldRewardImageList[i];
					if (!(image == null))
					{
						image.color = Color.clear;
						this.HiddenAllChild(image.gameObject);
						this.SetEffectAnotherWorldBtn(idx);
						GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.kAnotherWorldEffectPath, true, 0U);
						Utility.AttachTo(gameObject, image.gameObject, false);
						ComAnimatorAutoClose component = gameObject.GetComponent<ComAnimatorAutoClose>();
						if (component != null)
						{
							component.mOnFinishCallback.RemoveAllListeners();
							component.mOnFinishCallback.AddListener(callback);
						}
					}
				}
			}
		}

		// Token: 0x06009F4A RID: 40778 RVA: 0x001FD5C4 File Offset: 0x001FB9C4
		private void HiddenAllChild(GameObject root)
		{
			if (null == root)
			{
				return;
			}
			int childCount = root.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = root.transform.GetChild(i);
				if (null != child && null != child.gameObject)
				{
					child.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x06009F4B RID: 40779 RVA: 0x001FD634 File Offset: 0x001FBA34
		public void SetEffectAnotherWorldBtn(int index)
		{
			for (int i = 0; i < this.mYijieKamianqianEffect.Count; i++)
			{
				if (index == i)
				{
					if (this.mYijieKamianqianEffect[i] != null)
					{
						this.mYijieKamianqianEffect[i].CustomActive(false);
					}
					if (this.mYijieKamianhouEffect[i] != null)
					{
						this.mYijieKamianhouEffect[i].CustomActive(false);
					}
				}
			}
		}

		// Token: 0x040057B7 RID: 22455
		[SerializeField]
		private Button mAnotherWorldReward0Btn;

		// Token: 0x040057B8 RID: 22456
		[SerializeField]
		private Button mAnotherWorldReward1Btn;

		// Token: 0x040057B9 RID: 22457
		[SerializeField]
		private Button mAnotherWorldReward2Btn;

		// Token: 0x040057BA RID: 22458
		[SerializeField]
		private Button mAnotherWorldReward3Btn;

		// Token: 0x040057BB RID: 22459
		[SerializeField]
		private List<GameObject> mYijieKamianqianEffect = new List<GameObject>();

		// Token: 0x040057BC RID: 22460
		[SerializeField]
		private List<GameObject> mYijieKamianhouEffect = new List<GameObject>();

		// Token: 0x040057BD RID: 22461
		[SerializeField]
		public List<Image> mAnotherWorldRewardImageList = new List<Image>();

		// Token: 0x040057BE RID: 22462
		[SerializeField]
		private int mRewardCount = 4;

		// Token: 0x040057BF RID: 22463
		[SerializeField]
		private string kAnotherWorldEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_kapian_yijie";

		// Token: 0x040057C0 RID: 22464
		private OnAnotherWorldRewardClick callBack;
	}
}
