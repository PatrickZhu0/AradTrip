using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E90 RID: 3728
public class ComCharactorHeadHPBar : MonoBehaviour, IHPBar
{
	// Token: 0x06009399 RID: 37785 RVA: 0x001B9A50 File Offset: 0x001B7E50
	public void Damage(int value, bool withAnimate = false)
	{
		this.SetActive(true);
		this.mHpValue -= value;
		this.mHpValue = Mathf.Clamp(this.mHpValue, 0, this.mMaxHpValue);
		float rate = (float)this.mHpValue * 1f / (float)this.mMaxHpValue;
		this._setHpRate(rate);
		this._delayHidden();
	}

	// Token: 0x0600939A RID: 37786 RVA: 0x001B9AAD File Offset: 0x001B7EAD
	private void _delayHidden()
	{
		if (this.mType == eHpBarType.Monster)
		{
			this.mState = ComCharactorHeadHPBar.eState.Show;
			this.mTime = this.mTimeHidden;
		}
	}

	// Token: 0x0600939B RID: 37787 RVA: 0x001B9ACE File Offset: 0x001B7ECE
	private void Update()
	{
		if (this.mState == ComCharactorHeadHPBar.eState.Show)
		{
			this.mTime -= Time.deltaTime;
			if (this.mTime < 0f)
			{
				this.mState = ComCharactorHeadHPBar.eState.Hidden;
				this.SetActive(false);
			}
		}
	}

	// Token: 0x0600939C RID: 37788 RVA: 0x001B9B0C File Offset: 0x001B7F0C
	private void _setHpRate(float rate)
	{
		rate = Mathf.Clamp01(rate);
		if (this.mType == eHpBarType.Player)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ShowDeadTips(rate <= this.mRateLimit);
			}
		}
		if (this.mHp)
		{
			this.mHp.value = rate;
		}
	}

	// Token: 0x0600939D RID: 37789 RVA: 0x001B9B71 File Offset: 0x001B7F71
	public eHpBarType GetBarType()
	{
		return this.mType;
	}

	// Token: 0x0600939E RID: 37790 RVA: 0x001B9B79 File Offset: 0x001B7F79
	public bool GetHidden()
	{
		return base.gameObject.activeSelf;
	}

	// Token: 0x0600939F RID: 37791 RVA: 0x001B9B86 File Offset: 0x001B7F86
	public void Init(int hp, int mp, int maxHp = -1, int resistValue = 0)
	{
		this.mHpValue = hp;
		this.mMaxHpValue = hp;
		this._setHpRate(1f);
	}

	// Token: 0x060093A0 RID: 37792 RVA: 0x001B9BA1 File Offset: 0x001B7FA1
	public void SetActive(bool active)
	{
		if (null == this)
		{
			return;
		}
		base.gameObject.CustomActive(active);
	}

	// Token: 0x060093A1 RID: 37793 RVA: 0x001B9BBC File Offset: 0x001B7FBC
	public void SetHidden(bool hidden)
	{
		this.SetActive(hidden);
	}

	// Token: 0x060093A2 RID: 37794 RVA: 0x001B9BC5 File Offset: 0x001B7FC5
	public void SetMPRate(float percent)
	{
	}

	// Token: 0x060093A3 RID: 37795 RVA: 0x001B9BC7 File Offset: 0x001B7FC7
	public void SetName(string name, int level)
	{
	}

	// Token: 0x060093A4 RID: 37796 RVA: 0x001B9BC9 File Offset: 0x001B7FC9
	public void SetName(string name)
	{
	}

	// Token: 0x060093A5 RID: 37797 RVA: 0x001B9BCB File Offset: 0x001B7FCB
	public void SetLevel(int level)
	{
	}

	// Token: 0x060093A6 RID: 37798 RVA: 0x001B9BCD File Offset: 0x001B7FCD
	public void Unload()
	{
	}

	// Token: 0x060093A7 RID: 37799 RVA: 0x001B9BD0 File Offset: 0x001B7FD0
	public void SetHP(int curHP, int maxHP)
	{
		this.mHpValue = curHP;
		this.mMaxHpValue = maxHP;
		float rate = (float)this.mHpValue * 1f / (float)this.mMaxHpValue;
		this._setHpRate(rate);
	}

	// Token: 0x060093A8 RID: 37800 RVA: 0x001B9C08 File Offset: 0x001B8008
	public void SetMP(int curMP, int maxMP)
	{
	}

	// Token: 0x060093A9 RID: 37801 RVA: 0x001B9C0A File Offset: 0x001B800A
	public void SetIcon(Sprite headIcon, Material material)
	{
	}

	// Token: 0x060093AA RID: 37802 RVA: 0x001B9C0C File Offset: 0x001B800C
	public void InitResistMagic(int resistValue, BeActor player)
	{
	}

	// Token: 0x060093AB RID: 37803 RVA: 0x001B9C0E File Offset: 0x001B800E
	public void SetBuffName(string text)
	{
	}

	// Token: 0x04004A9F RID: 19103
	public Slider mHp;

	// Token: 0x04004AA0 RID: 19104
	public eHpBarType mType;

	// Token: 0x04004AA1 RID: 19105
	public float mRateLimit = 0.2f;

	// Token: 0x04004AA2 RID: 19106
	private int mMaxHpValue;

	// Token: 0x04004AA3 RID: 19107
	private int mHpValue;

	// Token: 0x04004AA4 RID: 19108
	private ComCharactorHeadHPBar.eState mState;

	// Token: 0x04004AA5 RID: 19109
	public float mTimeHidden = 2f;

	// Token: 0x04004AA6 RID: 19110
	private float mTime;

	// Token: 0x02000E91 RID: 3729
	private enum eState
	{
		// Token: 0x04004AA8 RID: 19112
		None,
		// Token: 0x04004AA9 RID: 19113
		Show,
		// Token: 0x04004AAA RID: 19114
		Hidden
	}
}
