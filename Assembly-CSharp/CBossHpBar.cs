using System;
using DG.Tweening;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E5F RID: 3679
[ExecuteInEditMode]
public class CBossHpBar : MonoBehaviour, IHPBar
{
	// Token: 0x170018F4 RID: 6388
	// (get) Token: 0x06009228 RID: 37416 RVA: 0x001B1DBE File Offset: 0x001B01BE
	public int LeftHP
	{
		get
		{
			return this.iLeftHP;
		}
	}

	// Token: 0x170018F5 RID: 6389
	// (get) Token: 0x06009229 RID: 37417 RVA: 0x001B1DC6 File Offset: 0x001B01C6
	public bool IsInit
	{
		get
		{
			return this.bInit;
		}
	}

	// Token: 0x170018F6 RID: 6390
	// (get) Token: 0x0600922A RID: 37418 RVA: 0x001B1DCE File Offset: 0x001B01CE
	public CBossHpBar.BloodState bloodState
	{
		get
		{
			return this.mBloodState;
		}
	}

	// Token: 0x0600922B RID: 37419 RVA: 0x001B1DD6 File Offset: 0x001B01D6
	public void Reset()
	{
		this.mBloodState = CBossHpBar.BloodState.None;
		this.bInit = false;
	}

	// Token: 0x0600922C RID: 37420 RVA: 0x001B1DE8 File Offset: 0x001B01E8
	public void Init(int sumHp, int sumMp, int singleHpValue, int resistValue = 0)
	{
		this.bInit = true;
		this.mBloodState = CBossHpBar.BloodState.Alive;
		this._removeDeadEffect();
		this.iSumHP = sumHp;
		this.iLeftHP = sumHp;
		this.mTmpHP = this.iSumHP;
		this.mAnimateHPValue = this.iSumHP;
		this.iPerBarAmount = singleHpValue;
		int num = sumHp % singleHpValue;
		if (singleHpValue < 0)
		{
			this.iPerBarAmount = this.iSumHP;
		}
		if (this.iSumHP < singleHpValue)
		{
			this.iPerBarAmount = this.iSumHP;
		}
		if (this.iSumHP < singleHpValue)
		{
		}
		this._setFgByHp(this.iSumHP);
		this._setBgByHp(this.iSumHP);
		this._updateAnimate(this.iSumHP);
	}

	// Token: 0x0600922D RID: 37421 RVA: 0x001B1E95 File Offset: 0x001B0295
	private void _removeDeadEffect()
	{
		if (null != this.mDeadEffect)
		{
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.mDeadEffect);
			this.mDeadEffect = null;
		}
	}

	// Token: 0x0600922E RID: 37422 RVA: 0x001B1EBF File Offset: 0x001B02BF
	public void SetIcon(Sprite sprite, Material material)
	{
		if (null == this)
		{
			return;
		}
		if (sprite != null)
		{
			this.imgIcon.sprite = sprite;
			this.imgIcon.material = material;
		}
	}

	// Token: 0x0600922F RID: 37423 RVA: 0x001B1EF2 File Offset: 0x001B02F2
	public void SetName(string name, int level)
	{
		this._setNameData(name);
		this._setLevelData(level);
		this._updateTxtName();
	}

	// Token: 0x06009230 RID: 37424 RVA: 0x001B1F08 File Offset: 0x001B0308
	public void SetName(string name)
	{
		this._setNameData(name);
		this._updateTxtName();
	}

	// Token: 0x06009231 RID: 37425 RVA: 0x001B1F17 File Offset: 0x001B0317
	public void SetLevel(int level)
	{
		this._setLevelData(level);
		this._updateTxtName();
	}

	// Token: 0x06009232 RID: 37426 RVA: 0x001B1F26 File Offset: 0x001B0326
	private void _setLevelData(int level)
	{
		if (this.mLevelCount != level)
		{
			this.mLevelCount = level;
			this.mIsNameLevelDirty = true;
		}
	}

	// Token: 0x06009233 RID: 37427 RVA: 0x001B1F42 File Offset: 0x001B0342
	public void _setNameData(string name)
	{
		if (this.mNameString != name)
		{
			this.mNameString = name;
			this.mIsNameLevelDirty = true;
		}
	}

	// Token: 0x06009234 RID: 37428 RVA: 0x001B1F64 File Offset: 0x001B0364
	private void _updateTxtName()
	{
		if (null == this)
		{
			return;
		}
		if (!this.mIsNameLevelDirty)
		{
			return;
		}
		this.mIsNameLevelDirty = false;
		this.txtName.text = string.Format("Lv.{0} {1}", this.mLevelCount, this.mNameString);
	}

	// Token: 0x06009235 RID: 37429 RVA: 0x001B1FB7 File Offset: 0x001B03B7
	public eHpBarType GetBarType()
	{
		return this.type;
	}

	// Token: 0x06009236 RID: 37430 RVA: 0x001B1FC0 File Offset: 0x001B03C0
	public void Damage(int damage, bool withAnimate)
	{
		this._updateTmpHP(damage);
		if (this.mBloodState != CBossHpBar.BloodState.Alive)
		{
			return;
		}
		this.mFadeMax = this.iLeftHP;
		this.iLeftHP -= damage;
		this.iLeftHP = Mathf.Clamp(this.iLeftHP, 0, this.iSumHP);
		this.mFadeMin = this.iLeftHP;
		if (damage > 0)
		{
			if (withAnimate)
			{
				this._startFade(this.mFadeMin, this.mFadeMax);
			}
			else
			{
				this._setDamageWithOutAnimate();
			}
		}
		else
		{
			this._setDamageWithOutAnimate();
		}
		if (this.iLeftHP <= 0)
		{
			this.iLeftHP = 0;
			this.mBloodState = CBossHpBar.BloodState.Dead;
		}
		if (damage > 0 && withAnimate)
		{
			this._shakeBloodBar();
		}
	}

	// Token: 0x06009237 RID: 37431 RVA: 0x001B2081 File Offset: 0x001B0481
	private void _setDamageWithOutAnimate()
	{
		this.mTmpHP = this.iLeftHP;
		this.mAnimateHPValue = this.iLeftHP;
		this._updateAnimate(this.iLeftHP);
		this._setFgByHp(this.iLeftHP);
	}

	// Token: 0x06009238 RID: 37432 RVA: 0x001B20B4 File Offset: 0x001B04B4
	private void _startFade(int minHP, int maxHP)
	{
		int num = maxHP - minHP;
		float minValue;
		float maxValue;
		if (num >= this._getCurrentBarAmount())
		{
			minValue = 0f;
			maxValue = 1f;
		}
		else
		{
			minValue = this._getFgRateByHP(minHP);
			maxValue = this._getFgRateByHP(maxHP);
		}
		this.mAnimateHPValue = maxHP;
		this._setFgByHp(minHP);
		if (null != this.whiteBar)
		{
			this.whiteBar.SetValue(minValue, maxValue, this.fWhiteFadeOutTime, delegate
			{
				this._fadeCB(minHP);
			});
		}
	}

	// Token: 0x06009239 RID: 37433 RVA: 0x001B215F File Offset: 0x001B055F
	private void _fadeCB(int minHP)
	{
		if (this.mAnimateHPValue > minHP)
		{
			this._setBgByHp(minHP);
			this.mAnimateHPValue = minHP;
		}
	}

	// Token: 0x0600923A RID: 37434 RVA: 0x001B217C File Offset: 0x001B057C
	public void Update()
	{
		if (this.mBloodState == CBossHpBar.BloodState.None)
		{
			return;
		}
		if (this.mTmpHP > this.mAnimateHPValue)
		{
			this.mTmpHP -= this._getRealAnimateSpeed();
			if (this.mTmpHP < this.mAnimateHPValue)
			{
				this.mTmpHP = this.mAnimateHPValue;
			}
			this._updateAnimate(this.mTmpHP);
		}
		if (this.mBloodState == CBossHpBar.BloodState.Remove)
		{
			this.mBloodState = CBossHpBar.BloodState.WaitDeadFlag;
			this.mEffectCounterTime = this.mEffectTime;
			if (!BeClientSwitch.FunctionIsOpen(ClientSwitchType.NotAttachDeadUIEffect))
			{
				this.mDeadEffect = Singleton<CGameObjectPool>.instance.GetGameObject("Effects/Scene_effects/EffectUI/EffUI_guaiwusiwang", enResourceType.UIPrefab, 0U);
				Utility.AttachTo(this.mDeadEffect, this.imgIcon.gameObject, false);
			}
		}
		if (this.mBloodState == CBossHpBar.BloodState.WaitDeadFlag)
		{
			if (this._isCurrentHiddent())
			{
				this.mBloodState = CBossHpBar.BloodState.Destroy;
				this._removeDeadEffect();
			}
			else
			{
				this.mEffectCounterTime -= Time.deltaTime;
				if (this.mEffectCounterTime < 0f)
				{
					if (this.mTmpHP <= 0)
					{
						this.mBloodState = CBossHpBar.BloodState.Destroy;
						this._removeDeadEffect();
					}
					else
					{
						this.mBloodState = CBossHpBar.BloodState.Remove;
					}
				}
			}
		}
		if (this.mBloodState == CBossHpBar.BloodState.Destroy)
		{
			if (null != this && null != base.gameObject)
			{
				this.SetActive(false);
			}
			this.mBloodState = CBossHpBar.BloodState.None;
		}
	}

	// Token: 0x0600923B RID: 37435 RVA: 0x001B22E4 File Offset: 0x001B06E4
	private void _updateAnimate(int midHpValue)
	{
		int num = this._getCurrentBarAmount();
		int num2 = this._getAnimateHPStandCount(midHpValue);
		if (num2 > 0)
		{
			if (num2 == 1)
			{
				if (null != this.mSliderBloodMidAnimateBg)
				{
					this.mSliderBloodMidAnimateBg.value = this._getBgRateByHP(midHpValue);
					this.mSliderBloodMidAnimateBg.image.sprite = this._getBgSprite(midHpValue);
				}
			}
			else if (null != this.mSliderBloodMidAnimateBg)
			{
				this.mSliderBloodMidAnimateBg.value = this._getBgRateByHP(midHpValue);
				this.mSliderBloodMidAnimateBg.image.sprite = this._getBgSprite(midHpValue);
			}
		}
		else if (null != this.mSliderBloodMidAnimateBg)
		{
			this.mSliderBloodMidAnimateBg.value = 0f;
		}
		this._updateTop2Indx(num2);
		if (null != this.mSliderBloodMidAnimate)
		{
			this.mSliderBloodMidAnimate.value = this._getFgRateByHP(midHpValue);
			this.mSliderBloodMidAnimate.image.sprite = this._getFgSprite(midHpValue);
		}
		this._updateLeftBarCountByHp(midHpValue);
		this._setBgByHp(midHpValue);
	}

	// Token: 0x0600923C RID: 37436 RVA: 0x001B23FC File Offset: 0x001B07FC
	private void _updateTop2Indx(int i)
	{
		if (i == 0)
		{
			if (null != this.mSliderBloodFg)
			{
				this.mSliderBloodFg.gameObject.SetActive(true);
				this.mSliderBloodFg.transform.SetAsLastSibling();
			}
		}
		else if (i == 1)
		{
			if (null != this.mSliderBloodFg)
			{
				this.mSliderBloodFg.gameObject.SetActive(true);
				this.mSliderBloodFg.transform.SetAsLastSibling();
			}
			if (null != this.mSliderBloodMidAnimate)
			{
				this.mSliderBloodMidAnimate.transform.SetAsLastSibling();
			}
		}
		else if (null != this.mSliderBloodFg)
		{
			this.mSliderBloodFg.gameObject.SetActive(false);
			this.mSliderBloodFg.transform.SetAsFirstSibling();
		}
	}

	// Token: 0x0600923D RID: 37437 RVA: 0x001B24D8 File Offset: 0x001B08D8
	private int _getAnimateHPStandCount(int hp)
	{
		int num = this._getLeftHPInCurrentBar(hp);
		int num2 = hp - this.mAnimateHPValue;
		int num3 = this._getCurrentBarAmount();
		if (num2 <= num)
		{
			return 0;
		}
		int num4 = num2 - num;
		if (num4 % num3 == 0)
		{
			return num4 / num3;
		}
		return num4 / num3 + 1;
	}

	// Token: 0x0600923E RID: 37438 RVA: 0x001B251C File Offset: 0x001B091C
	private void _updateTmpHP(int damage)
	{
		int num = this._getCurrentBarAmount();
		int num2 = this.mTmpHP - this.mAnimateHPValue;
		if (num2 > num * 2)
		{
			if (this.mAnimateHPValue % num == 0 && this.mAnimateHPValue != 0)
			{
				this.mTmpHP = this.mAnimateHPValue + num;
			}
			else
			{
				this.mTmpHP = this.mAnimateHPValue / num * num;
			}
			this._updateAnimate(this.mTmpHP);
		}
	}

	// Token: 0x0600923F RID: 37439 RVA: 0x001B2590 File Offset: 0x001B0990
	private int _getRealAnimateSpeed()
	{
		int num = this._getCurrentBarAmount();
		int num2 = this.mTmpHP - this.mAnimateHPValue;
		float num3 = 1f * (float)num / this.fOneAmountBloodAnimateTime;
		float num4 = (float)num2 / num3;
		if (num2 / num >= 2 || this.mAnimateHPValue == 0)
		{
			this.mRealAnimateSpeed = (int)((float)this.iSumHP / this.fFullBloodAnimateTime * Time.deltaTime + 1f);
		}
		else if (num4 < this.fFullBloodAnimateTime * 2f)
		{
			this.mRealAnimateSpeed = (int)(num3 * Time.deltaTime + 1f);
		}
		else
		{
			this.mRealAnimateSpeed = (int)(num3 * Time.deltaTime + 1f);
		}
		return this.mRealAnimateSpeed;
	}

	// Token: 0x06009240 RID: 37440 RVA: 0x001B2646 File Offset: 0x001B0A46
	public void SetActive(bool active)
	{
		if (null != this && null != this.root)
		{
			this.root.alpha = ((!active) ? 0f : 1f);
		}
	}

	// Token: 0x06009241 RID: 37441 RVA: 0x001B2685 File Offset: 0x001B0A85
	public void Unload()
	{
		this.Damage(this.iLeftHP, true);
		if (this._isCurrentHiddent())
		{
			this.mBloodState = CBossHpBar.BloodState.Destroy;
			this._removeDeadEffect();
		}
		else
		{
			this.mBloodState = CBossHpBar.BloodState.Remove;
		}
	}

	// Token: 0x06009242 RID: 37442 RVA: 0x001B26B8 File Offset: 0x001B0AB8
	private bool _isCurrentHiddent()
	{
		return null != this && null != this.root && Mathf.Approximately(this.root.alpha, 0f);
	}

	// Token: 0x06009243 RID: 37443 RVA: 0x001B26EF File Offset: 0x001B0AEF
	public void SetHidden(bool hidden)
	{
		this.mHidden = hidden;
	}

	// Token: 0x06009244 RID: 37444 RVA: 0x001B26F8 File Offset: 0x001B0AF8
	public string GetName()
	{
		return this.txtName.text;
	}

	// Token: 0x06009245 RID: 37445 RVA: 0x001B2705 File Offset: 0x001B0B05
	public bool GetHidden()
	{
		return this.mHidden;
	}

	// Token: 0x06009246 RID: 37446 RVA: 0x001B270D File Offset: 0x001B0B0D
	private int _getCurrentBarAmount()
	{
		return this.iPerBarAmount;
	}

	// Token: 0x06009247 RID: 37447 RVA: 0x001B2715 File Offset: 0x001B0B15
	private int _getLeftCurrentBarIndex(int leftHP)
	{
		if (leftHP <= 0)
		{
			return 0;
		}
		return leftHP / this._getCurrentBarAmount();
	}

	// Token: 0x06009248 RID: 37448 RVA: 0x001B2728 File Offset: 0x001B0B28
	private int _getLeftHPInCurrentBar(int leftHP)
	{
		int num = this._getCurrentBarAmount();
		int num2 = leftHP % num;
		if (num2 != 0)
		{
			return num2;
		}
		if (leftHP == 0)
		{
			return 0;
		}
		return num;
	}

	// Token: 0x06009249 RID: 37449 RVA: 0x001B2751 File Offset: 0x001B0B51
	private int _getBgIndex(int leftValue)
	{
		if (leftValue <= this._getCurrentBarAmount())
		{
			return -1;
		}
		leftValue -= leftValue % this._getCurrentBarAmount();
		return this._getSpriteIdxByHP(leftValue);
	}

	// Token: 0x0600924A RID: 37450 RVA: 0x001B2774 File Offset: 0x001B0B74
	private int _getFgIndex(int leftValue)
	{
		return this._getSpriteIdxByHP(leftValue);
	}

	// Token: 0x0600924B RID: 37451 RVA: 0x001B2780 File Offset: 0x001B0B80
	private int _getSpriteIdxByHP(int leftHP)
	{
		int num = this._getLeftCurrentBarIndex(leftHP);
		int num2 = this._getCurrentBarAmount();
		int num3 = this._getLeftHPInCurrentBar(leftHP);
		if (num2 == num3)
		{
			num--;
		}
		if (num < 0)
		{
			num = 0;
		}
		return num % this.SpriteList.Length;
	}

	// Token: 0x0600924C RID: 37452 RVA: 0x001B27C4 File Offset: 0x001B0BC4
	private Sprite _getFgSprite(int leftValue)
	{
		int num = this._getFgIndex(leftValue);
		return this.SpriteList[num];
	}

	// Token: 0x0600924D RID: 37453 RVA: 0x001B27E4 File Offset: 0x001B0BE4
	private Sprite _getBgSprite(int leftValue)
	{
		int num = this._getBgIndex(leftValue);
		if (num < 0)
		{
			return null;
		}
		return this.SpriteList[num];
	}

	// Token: 0x0600924E RID: 37454 RVA: 0x001B280A File Offset: 0x001B0C0A
	private void _shakeBloodBar()
	{
		if (this.shakeTween != null)
		{
			this.shakeTween.DORestart(false);
		}
	}

	// Token: 0x0600924F RID: 37455 RVA: 0x001B2829 File Offset: 0x001B0C29
	private void _attachEffect()
	{
	}

	// Token: 0x06009250 RID: 37456 RVA: 0x001B282C File Offset: 0x001B0C2C
	private void _updateLeftBarCount(int idx)
	{
		if (this.txtLeftBar != null)
		{
			if (idx <= 0)
			{
				this.txtLeftBar.text = string.Empty;
			}
			else
			{
				this.txtLeftBar.text = string.Format("x{0}", idx);
			}
		}
	}

	// Token: 0x06009251 RID: 37457 RVA: 0x001B2884 File Offset: 0x001B0C84
	private void _updateLeftBarCountByHp(int leftHP)
	{
		int idx = this._getLeftCurrentBarIndex(leftHP);
		this._updateLeftBarCount(idx);
	}

	// Token: 0x06009252 RID: 37458 RVA: 0x001B28A0 File Offset: 0x001B0CA0
	private void _setFgByHp(int leftHP)
	{
		Sprite sprite = this._getFgSprite(leftHP);
		if (null != this.imgBloodFg)
		{
			this.imgBloodFg.sprite = sprite;
		}
		if (null != this.mSliderBloodFg)
		{
			this.mSliderBloodFg.value = this._getFgRateByHP(leftHP);
		}
	}

	// Token: 0x06009253 RID: 37459 RVA: 0x001B28F8 File Offset: 0x001B0CF8
	private void _setBgByHp(int leftHP)
	{
		Sprite sprite = this._getBgSprite(leftHP);
		if (null != sprite)
		{
			if (null != this.imgBloodBg)
			{
				this.imgBloodBg.sprite = sprite;
			}
			if (null != this.mSliderBloodBg)
			{
				this.mSliderBloodBg.value = this._getBgRateByHP(leftHP);
			}
		}
		else if (null != this.mSliderBloodBg)
		{
			this.mSliderBloodBg.value = 0f;
		}
	}

	// Token: 0x06009254 RID: 37460 RVA: 0x001B2980 File Offset: 0x001B0D80
	private float _getBgRateByHP(int leftHP)
	{
		int num = this._getCurrentBarAmount();
		if (leftHP < num)
		{
			return Mathf.Clamp01((float)leftHP * 1f / (float)num);
		}
		return 1f;
	}

	// Token: 0x06009255 RID: 37461 RVA: 0x001B29B1 File Offset: 0x001B0DB1
	private float _getFgRateByHP(int leftHP)
	{
		return 1f * (float)this._getLeftHPInCurrentBar(leftHP) / (float)this._getCurrentBarAmount();
	}

	// Token: 0x06009256 RID: 37462 RVA: 0x001B29C9 File Offset: 0x001B0DC9
	private void _setFgRate(float rate)
	{
		if (null != this.mSliderBloodFg)
		{
			this.mSliderBloodFg.value = rate;
		}
	}

	// Token: 0x06009257 RID: 37463 RVA: 0x001B29E8 File Offset: 0x001B0DE8
	private void _setBgRate(float rate)
	{
		if (null != this.mSliderBloodBg)
		{
			this.mSliderBloodBg.value = rate;
		}
	}

	// Token: 0x06009258 RID: 37464 RVA: 0x001B2A07 File Offset: 0x001B0E07
	public void SetMPRate(float percent)
	{
	}

	// Token: 0x06009259 RID: 37465 RVA: 0x001B2A09 File Offset: 0x001B0E09
	public void SetHP(int curHP, int maxHP)
	{
	}

	// Token: 0x0600925A RID: 37466 RVA: 0x001B2A0B File Offset: 0x001B0E0B
	public void SetMP(int curMP, int maxMP)
	{
	}

	// Token: 0x0600925B RID: 37467 RVA: 0x001B2A0D File Offset: 0x001B0E0D
	public void InitResistMagic(int resistValue, BeActor player)
	{
	}

	// Token: 0x0600925C RID: 37468 RVA: 0x001B2A0F File Offset: 0x001B0E0F
	public void SetBuffName(string text)
	{
		if (this.buffName != null)
		{
			this.buffName.text = text;
		}
	}

	// Token: 0x0400492E RID: 18734
	public eHpBarType type;

	// Token: 0x0400492F RID: 18735
	public CBossHpFadeWhite whiteBar;

	// Token: 0x04004930 RID: 18736
	public CanvasGroup root;

	// Token: 0x04004931 RID: 18737
	public Slider mSliderBg;

	// Token: 0x04004932 RID: 18738
	public Slider mSliderBloodFg;

	// Token: 0x04004933 RID: 18739
	public Slider mSliderBloodMidAnimate;

	// Token: 0x04004934 RID: 18740
	public Slider mSliderBloodMidAnimateBg;

	// Token: 0x04004935 RID: 18741
	public Slider mSliderBloodBg;

	// Token: 0x04004936 RID: 18742
	public Image imgBloodFg;

	// Token: 0x04004937 RID: 18743
	public Image imgBloodBg;

	// Token: 0x04004938 RID: 18744
	public Image imgBloodMid;

	// Token: 0x04004939 RID: 18745
	public Image imgBloodMidAnimate;

	// Token: 0x0400493A RID: 18746
	public Image imgIcon;

	// Token: 0x0400493B RID: 18747
	public Text txtName;

	// Token: 0x0400493C RID: 18748
	public Text txtLeftBar;

	// Token: 0x0400493D RID: 18749
	public Text buffName;

	// Token: 0x0400493E RID: 18750
	public RectTransform rectHUD;

	// Token: 0x0400493F RID: 18751
	public Image imgFgBoss;

	// Token: 0x04004940 RID: 18752
	public Image imgFgMonster;

	// Token: 0x04004941 RID: 18753
	public RectTransform rectBar;

	// Token: 0x04004942 RID: 18754
	public DOTweenAnimation shakeTween;

	// Token: 0x04004943 RID: 18755
	public float fBloodAnimateSpeed = 0.001f;

	// Token: 0x04004944 RID: 18756
	public float fWhiteFadeOutTime = 1.5f;

	// Token: 0x04004945 RID: 18757
	public float fFullBloodAnimateTime = 3f;

	// Token: 0x04004946 RID: 18758
	public float fOneAmountBloodAnimateTime = 3f;

	// Token: 0x04004947 RID: 18759
	private int iRealBloodAnimateSpeed;

	// Token: 0x04004948 RID: 18760
	public float bloodDeltaTime = 0.5f;

	// Token: 0x04004949 RID: 18761
	public bool bShowAnimate = true;

	// Token: 0x0400494A RID: 18762
	public bool bIsBoss;

	// Token: 0x0400494B RID: 18763
	private float fWidth = 10f;

	// Token: 0x0400494C RID: 18764
	public int iSumHP = 1;

	// Token: 0x0400494D RID: 18765
	private int iPerBarAmount;

	// Token: 0x0400494E RID: 18766
	private int iLeftHP;

	// Token: 0x0400494F RID: 18767
	public float fDeltaIconSize = 88f;

	// Token: 0x04004950 RID: 18768
	private bool bInit;

	// Token: 0x04004951 RID: 18769
	private CBossHpBar.BloodState mBloodState;

	// Token: 0x04004952 RID: 18770
	private CBossHpBar.BloodState mLastBloodState;

	// Token: 0x04004953 RID: 18771
	private int mTmpHP;

	// Token: 0x04004954 RID: 18772
	public Sprite[] SpriteList;

	// Token: 0x04004955 RID: 18773
	private int mLevelCount = -1;

	// Token: 0x04004956 RID: 18774
	private string mNameString = string.Empty;

	// Token: 0x04004957 RID: 18775
	private bool mIsNameLevelDirty;

	// Token: 0x04004958 RID: 18776
	private int mAnimateHPValue;

	// Token: 0x04004959 RID: 18777
	private int mFadeMin;

	// Token: 0x0400495A RID: 18778
	private int mFadeMax;

	// Token: 0x0400495B RID: 18779
	private GameObject mDeadEffect;

	// Token: 0x0400495C RID: 18780
	public float mEffectTime = 1.167f;

	// Token: 0x0400495D RID: 18781
	private float mEffectCounterTime;

	// Token: 0x0400495E RID: 18782
	private int mRealAnimateSpeed;

	// Token: 0x0400495F RID: 18783
	private bool mHidden = true;

	// Token: 0x02000E60 RID: 3680
	public enum BloodType
	{
		// Token: 0x04004961 RID: 18785
		MonsterBlood,
		// Token: 0x04004962 RID: 18786
		BossBlood
	}

	// Token: 0x02000E61 RID: 3681
	public enum BloodState
	{
		// Token: 0x04004964 RID: 18788
		None,
		// Token: 0x04004965 RID: 18789
		Alive,
		// Token: 0x04004966 RID: 18790
		Dead,
		// Token: 0x04004967 RID: 18791
		Remove,
		// Token: 0x04004968 RID: 18792
		WaitDeadFlag,
		// Token: 0x04004969 RID: 18793
		Destroy
	}
}
