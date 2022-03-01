using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001079 RID: 4217
	public class BattleProfessionFrame : ClientFrame
	{
		// Token: 0x06009F5D RID: 40797 RVA: 0x001FDDF8 File Offset: 0x001FC1F8
		protected override void _bindExUI()
		{
			this.mBulletNum = this.mBind.GetCom<ComCommonBind>("BulletNum");
			this.mSkillUseCount = this.mBind.GetCom<ComCommonBind>("SkillUseCount");
			this.mBuffNum = this.mBind.GetGameObject("BuffNum");
			this.mShengQiShiBieDongBuff = this.mBind.GetCom<ComCommonBind>("ShengQiShiBieDongBuff");
			this.mBuffNumText = this.mBind.GetCom<Text>("BuffNumText");
			this.mNvDaQiangEnergyBar = this.mBind.GetCom<ComCommonBind>("NvDaQiangEnergyBar");
			this.mComboBuffCom = this.mBind.GetCom<ComCommonBind>("ComboBuffCom");
			this.mComboBuffNum = this.mComboBuffCom.GetGameObject("ComboBuffNum");
			this.mComboBuffNumGray = this.mComboBuffCom.GetCom<UIGray>("ComboBuffNumGray");
			this.mComboBuffNumText = this.mComboBuffCom.GetCom<Text>("ComboBuffNumText");
			this.mComboBuffProgress = this.mComboBuffCom.GetCom<Image>("ComboBuffProgress");
		}

		// Token: 0x06009F5E RID: 40798 RVA: 0x001FDEF8 File Offset: 0x001FC2F8
		protected override void _unbindExUI()
		{
			this.mBulletNum = null;
			this.mSkillUseCount = null;
			this.mBuffNum = null;
			this.mShengQiShiBieDongBuff = null;
			this.mBuffNumText = null;
			this.mNvDaQiangEnergyBar = null;
			this.mComboBuffCom = null;
			this.mComboBuffNum = null;
			this.mComboBuffNumGray = null;
			this.mComboBuffNumText = null;
			this.mComboBuffProgress = null;
		}

		// Token: 0x06009F5F RID: 40799 RVA: 0x001FDF52 File Offset: 0x001FC352
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/BattleProfessionFrame";
		}

		// Token: 0x06009F60 RID: 40800 RVA: 0x001FDF59 File Offset: 0x001FC359
		public override void Init()
		{
			base.Init();
			this.InitShengqishiBuffData();
		}

		// Token: 0x06009F61 RID: 40801 RVA: 0x001FDF67 File Offset: 0x001FC367
		public override void Clear()
		{
			base.Clear();
			this.mainQuence = null;
		}

		// Token: 0x06009F62 RID: 40802 RVA: 0x001FDF78 File Offset: 0x001FC378
		public void SetSilverBulletNum(int skillId, int num, SpecialBulletType type)
		{
			ComCommonBind comCommonBind = null;
			if (this.itemDic.ContainsKey(skillId))
			{
				comCommonBind = this.itemDic[skillId];
			}
			else
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.mBulletNum.gameObject);
				if (gameObject != null)
				{
					comCommonBind = gameObject.GetComponent<ComCommonBind>();
					string iconPathByType = this.GetIconPathByType(type);
					Image com = comCommonBind.GetCom<Image>("Icon");
					ETCImageLoader.LoadSprite(ref com, iconPathByType, true);
					Utility.AttachTo(gameObject, this.mBind.gameObject, false);
					this.itemDic.Add(skillId, comCommonBind);
				}
			}
			if (comCommonBind == null)
			{
				return;
			}
			GameObject gameObject2 = comCommonBind.gameObject;
			Text com2 = comCommonBind.GetCom<Text>("Num");
			if (gameObject2 != null)
			{
				gameObject2.CustomActive(num > 0);
			}
			if (com2 != null)
			{
				com2.text = num.ToString();
			}
		}

		// Token: 0x06009F63 RID: 40803 RVA: 0x001FE068 File Offset: 0x001FC468
		private string GetIconPathByType(SpecialBulletType type)
		{
			string result = null;
			switch (type)
			{
			case SpecialBulletType.SILVER:
			case SpecialBulletType.STRESILVER:
				result = "UI/Image/Packed/p_UI_Icon_skillIcon.png:UI_ZhandouUI_Zidantou_01";
				break;
			case SpecialBulletType.ICE:
				result = "UI/Image/Packed/p_UI_Icon_skillIcon.png:UI_ZhandouUI_Zidantou_02";
				break;
			case SpecialBulletType.FIRE:
				result = "UI/Image/Packed/p_UI_Icon_skillIcon.png:UI_ZhandouUI_Zidantou_03";
				break;
			}
			return result;
		}

		// Token: 0x06009F64 RID: 40804 RVA: 0x001FE0B4 File Offset: 0x001FC4B4
		public void SetBuffNum(int num)
		{
			if (this.mBuffNum == null)
			{
				return;
			}
			if (num <= 0)
			{
				this.mBuffNum.SetActive(false);
			}
			else
			{
				this.mBuffNum.CustomActive(true);
				this.mBuffNumText.text = num.ToString();
			}
		}

		// Token: 0x06009F65 RID: 40805 RVA: 0x001FE110 File Offset: 0x001FC510
		public void SetComboBuffNum(int num, float progress)
		{
			if (this.mComboBuffNum == null)
			{
				return;
			}
			this.mComboBuffNum.CustomActive(true);
			if (num <= 0)
			{
				this.mComboBuffNumGray.enabled = true;
				this.mComboBuffProgress.fillAmount = 0f;
			}
			else
			{
				this.mComboBuffNumGray.enabled = false;
				this.mComboBuffProgress.fillAmount = progress;
			}
			if (this.mCurComboNum != num)
			{
				this.mCurComboNum = num;
				this.mComboBuffNumText.text = num.ToString() + "层";
			}
		}

		// Token: 0x06009F66 RID: 40806 RVA: 0x001FE1B0 File Offset: 0x001FC5B0
		public void SetSkillUseCount(int skillId, int num, string iconPath)
		{
			ComCommonBind comCommonBind = null;
			if (this.itemDic.ContainsKey(skillId))
			{
				comCommonBind = this.itemDic[skillId];
			}
			else
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.mSkillUseCount.gameObject);
				if (gameObject != null)
				{
					comCommonBind = gameObject.GetComponent<ComCommonBind>();
					Image com = comCommonBind.GetCom<Image>("Icon");
					ETCImageLoader.LoadSprite(ref com, iconPath, true);
					Utility.AttachTo(gameObject, this.mBind.gameObject, false);
					this.itemDic.Add(skillId, comCommonBind);
				}
			}
			if (comCommonBind == null)
			{
				return;
			}
			GameObject gameObject2 = comCommonBind.gameObject;
			Text com2 = comCommonBind.GetCom<Text>("Num");
			if (gameObject2 != null)
			{
				gameObject2.CustomActive(num >= 0);
			}
			if (com2 != null)
			{
				com2.text = num.ToString();
			}
		}

		// Token: 0x06009F67 RID: 40807 RVA: 0x001FE298 File Offset: 0x001FC698
		private void InitShengqishiBuffData()
		{
			if (this.mShengQiShiBieDongBuff == null)
			{
				return;
			}
			if (this.zhufuRoot != null)
			{
				return;
			}
			this.zhufuRoot = this.mShengQiShiBieDongBuff.GetGameObject("ZhufuRoot");
			this.shenPanRoot = this.mShengQiShiBieDongBuff.GetGameObject("ShepanRoot");
			this.zhufuContent = this.mShengQiShiBieDongBuff.GetGameObject("ZhufuContent");
			this.shenPanContent = this.mShengQiShiBieDongBuff.GetGameObject("ShenPanContent");
			this.effectArr[0] = this.mShengQiShiBieDongBuff.GetCom<GeEffectProxy>("ShowEffect");
			this.effectArr[1] = this.mShengQiShiBieDongBuff.GetCom<GeEffectProxy>("HideEffect");
			if (this.zhufuContent != null)
			{
				for (int i = 0; i < this.zhufuContent.transform.childCount; i++)
				{
					if (i < 5)
					{
						this.zhufuBuffUI[i] = this.zhufuContent.transform.GetChild(i).GetComponent<Toggle>();
					}
				}
			}
			if (this.shenPanContent != null)
			{
				for (int j = 0; j < this.shenPanContent.transform.childCount; j++)
				{
					if (j < 5)
					{
						this.shenpanBuffUI[j] = this.shenPanContent.transform.GetChild(j).GetComponent<Toggle>();
					}
				}
			}
			this.showEffectFlag = false;
		}

		// Token: 0x06009F68 RID: 40808 RVA: 0x001FE408 File Offset: 0x001FC808
		public void SetShengQiBeiDongBuff(int index, int curNum, int maxNum)
		{
			if (this.mShengQiShiBieDongBuff == null)
			{
				return;
			}
			this.InitShengqishiBuffData();
			Toggle[] array = (index != 0) ? this.shenpanBuffUI : this.zhufuBuffUI;
			GameObject gameObject = (index != 0) ? this.shenPanRoot : this.zhufuRoot;
			for (int i = 0; i < array.Length; i++)
			{
				if (i < curNum && !array[i].isOn)
				{
					this.ShowEffect(array[i].gameObject, false);
					array[i].isOn = true;
				}
				if (i >= curNum && array[i].isOn)
				{
					this.ShowEffect(array[i].gameObject, true);
					array[i].isOn = false;
				}
			}
			gameObject.CustomActive(curNum > 0);
			this.mShengQiShiBieDongBuff.CustomActive(index != -1);
		}

		// Token: 0x06009F69 RID: 40809 RVA: 0x001FE4E8 File Offset: 0x001FC8E8
		private void ShowEffect(GameObject rootNode, bool isHide = false)
		{
			GeEffectProxy geEffectProxy = (!isHide) ? this.effectArr[0] : this.effectArr[1];
			geEffectProxy.CustomActive(false);
			if (this.showEffectFlag)
			{
				geEffectProxy.transform.position = rootNode.transform.position;
			}
			geEffectProxy.CustomActive(true);
			this.showEffectFlag = true;
		}

		// Token: 0x06009F6A RID: 40810 RVA: 0x001FE548 File Offset: 0x001FC948
		public void InitNvDaQiangEnergyBar(int n)
		{
			this.energyMaxProcess = n;
			if (null != this.mNvDaQiangEnergyBar)
			{
				this.mNvDaQiangEnergyBar.gameObject.SetActive(true);
			}
			if (null == this.pointerTransform && null != this.mNvDaQiangEnergyBar)
			{
				this.pointerTransform = this.mNvDaQiangEnergyBar.GetCom<RectTransform>("Pointer");
			}
			if (null == this.effectRoot && null != this.mNvDaQiangEnergyBar)
			{
				this.effectRoot = this.mNvDaQiangEnergyBar.GetGameObject("effectRoot");
				if (null != this.effectRoot)
				{
					this.effectRoot.SetActive(false);
				}
			}
		}

		// Token: 0x06009F6B RID: 40811 RVA: 0x001FE60C File Offset: 0x001FCA0C
		public void SetNvDaQiangEnergyBar(int times)
		{
			if (null != this.pointerTransform && times >= 0 && times < this.angle.Length)
			{
				if (this.mainQuence != null && TweenExtensions.IsPlaying(this.mainQuence))
				{
					TweenExtensions.Complete(this.mainQuence);
					this.mainQuence = null;
				}
				this.mainQuence = DOTween.Sequence();
				if (this.energyProcess > times)
				{
					for (int i = times; i < this.energyProcess; i++)
					{
						Sequence sequence = DOTween.Sequence();
						TweenSettingsExtensions.Append(sequence, ShortcutExtensions.DORotate(this.pointerTransform.transform, new Vector3(0f, 0f, (float)this.angle[i]), 0.166f, 0));
						TweenSettingsExtensions.Join(this.mainQuence, sequence);
					}
				}
				else if (this.energyProcess < times)
				{
					for (int j = this.energyProcess + 1; j <= times; j++)
					{
						Sequence sequence2 = DOTween.Sequence();
						TweenSettingsExtensions.Append(sequence2, ShortcutExtensions.DORotate(this.pointerTransform.transform, new Vector3(0f, 0f, (float)this.angle[j]), 0.5f, 0));
						TweenSettingsExtensions.Join(this.mainQuence, sequence2);
					}
				}
				ShortcutExtensions.DOScale(this.pointerTransform.transform, new Vector3(this.size[times], this.size[times], 0f), 0.5f);
				this.energyProcess = times;
				TweenExtensions.Play<Sequence>(this.mainQuence);
			}
			if (null != this.effectRoot)
			{
				if (times == this.energyMaxProcess && !this.effectRoot.activeInHierarchy)
				{
					this.effectRoot.SetActive(true);
				}
				else if (times < this.energyMaxProcess && this.effectRoot.activeInHierarchy)
				{
					this.effectRoot.SetActive(false);
				}
			}
		}

		// Token: 0x040057C9 RID: 22473
		private ComCommonBind mBulletNum;

		// Token: 0x040057CA RID: 22474
		private ComCommonBind mSkillUseCount;

		// Token: 0x040057CB RID: 22475
		private GameObject mBuffNum;

		// Token: 0x040057CC RID: 22476
		private ComCommonBind mShengQiShiBieDongBuff;

		// Token: 0x040057CD RID: 22477
		private Text mBuffNumText;

		// Token: 0x040057CE RID: 22478
		private ComCommonBind mNvDaQiangEnergyBar;

		// Token: 0x040057CF RID: 22479
		private ComCommonBind mComboBuffCom;

		// Token: 0x040057D0 RID: 22480
		private GameObject mComboBuffNum;

		// Token: 0x040057D1 RID: 22481
		private UIGray mComboBuffNumGray;

		// Token: 0x040057D2 RID: 22482
		private Text mComboBuffNumText;

		// Token: 0x040057D3 RID: 22483
		private Image mComboBuffProgress;

		// Token: 0x040057D4 RID: 22484
		private int mCurComboNum = -1;

		// Token: 0x040057D5 RID: 22485
		private Dictionary<int, ComCommonBind> itemDic = new Dictionary<int, ComCommonBind>();

		// Token: 0x040057D6 RID: 22486
		private GameObject zhufuRoot;

		// Token: 0x040057D7 RID: 22487
		private GameObject shenPanRoot;

		// Token: 0x040057D8 RID: 22488
		private GameObject zhufuContent;

		// Token: 0x040057D9 RID: 22489
		private GameObject shenPanContent;

		// Token: 0x040057DA RID: 22490
		private GeEffectProxy[] effectArr = new GeEffectProxy[2];

		// Token: 0x040057DB RID: 22491
		private Toggle[] zhufuBuffUI = new Toggle[5];

		// Token: 0x040057DC RID: 22492
		private Toggle[] shenpanBuffUI = new Toggle[5];

		// Token: 0x040057DD RID: 22493
		private bool showEffectFlag;

		// Token: 0x040057DE RID: 22494
		private RectTransform pointerTransform;

		// Token: 0x040057DF RID: 22495
		private GameObject effectRoot;

		// Token: 0x040057E0 RID: 22496
		private int energyProcess;

		// Token: 0x040057E1 RID: 22497
		private int energyMaxProcess;

		// Token: 0x040057E2 RID: 22498
		public int[] angle = new int[]
		{
			120,
			195,
			260,
			360
		};

		// Token: 0x040057E3 RID: 22499
		public float[] size = new float[]
		{
			0.55f,
			0.65f,
			0.75f,
			1f
		};

		// Token: 0x040057E4 RID: 22500
		private Sequence mainQuence;
	}
}
