using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E66 RID: 3686
[ExecuteInEditMode]
public class CPKHPBar : MonoBehaviour
{
	// Token: 0x0600926B RID: 37483 RVA: 0x001B2FED File Offset: 0x001B13ED
	private void Awake()
	{
		this._bindExUI();
	}

	// Token: 0x0600926C RID: 37484 RVA: 0x001B2FF5 File Offset: 0x001B13F5
	private void OnDestroy()
	{
		this._unbindExUI();
	}

	// Token: 0x0600926D RID: 37485 RVA: 0x001B3000 File Offset: 0x001B1400
	protected void _bindExUI()
	{
		this.mName = this.mBind.GetCom<Text>("name");
		this.mIcon = this.mBind.GetCom<Image>("icon");
		this.mHpValue = this.mBind.GetCom<Text>("hpValue");
		this.mHpBar = this.mBind.GetCom<Slider>("hpBar");
		this.mMpBar = this.mBind.GetCom<Slider>("mpBar");
		this.mProtectBlue = this.mBind.GetCom<Slider>("protectBlue");
		this.mProtectBlueRoot = this.mBind.GetGameObject("protectBlueRoot");
		this.mProtectYellow = this.mBind.GetCom<Slider>("protectYellow");
		this.mProtectYellowRoot = this.mBind.GetGameObject("protectYellowRoot");
		this.mProtectRed = this.mBind.GetCom<Slider>("protectRed");
		this.mProtectRedRoot = this.mBind.GetGameObject("protectRedRoot");
		this.btn = this.mIcon.GetComponent<Button>();
		if (this.btn == null)
		{
			return;
		}
		this.btn.onClick.RemoveAllListeners();
		this.btn.onClick.AddListener(delegate()
		{
			if (this.action != null)
			{
				this.action();
			}
		});
	}

	// Token: 0x0600926E RID: 37486 RVA: 0x001B3150 File Offset: 0x001B1550
	protected void _unbindExUI()
	{
		this.mName = null;
		this.mIcon = null;
		this.mHpValue = null;
		this.mHpBar = null;
		this.mMpBar = null;
		this.mProtectBlue = null;
		this.mProtectBlueRoot = null;
		this.mProtectYellow = null;
		this.mProtectYellowRoot = null;
		this.mProtectRed = null;
		this.mProtectRedRoot = null;
	}

	// Token: 0x0600926F RID: 37487 RVA: 0x001B31AA File Offset: 0x001B15AA
	public float GetHPPercent()
	{
		if (null != this.mHpBar)
		{
			return this.mHpBar.value;
		}
		return 0f;
	}

	// Token: 0x06009270 RID: 37488 RVA: 0x001B31CE File Offset: 0x001B15CE
	public float GetMPPercent()
	{
		if (null != this.mMpBar)
		{
			return this.mMpBar.value;
		}
		return 0f;
	}

	// Token: 0x06009271 RID: 37489 RVA: 0x001B31F2 File Offset: 0x001B15F2
	public void SetHPPercent(float percent)
	{
		if (null != this.mHpBar)
		{
			this.mHpBar.value = Mathf.Clamp01(percent);
		}
	}

	// Token: 0x06009272 RID: 37490 RVA: 0x001B3216 File Offset: 0x001B1616
	public void SetHPValue(int cur, int max)
	{
		if (null != this.mHpValue)
		{
			this.mHpValue.text = string.Format("{0}/{1}", cur, max);
		}
	}

	// Token: 0x06009273 RID: 37491 RVA: 0x001B324A File Offset: 0x001B164A
	public void SetMPPercent(float percent)
	{
		if (null != this.mMpBar)
		{
			this.mMpBar.value = Mathf.Clamp01(percent);
		}
	}

	// Token: 0x06009274 RID: 37492 RVA: 0x001B326E File Offset: 0x001B166E
	public void SetNameText(string name, string area)
	{
		if (null != this.mName)
		{
			this.mName.text = string.Format("{0} <color=orange><b>{1}</b></color>", name, area);
		}
	}

	// Token: 0x06009275 RID: 37493 RVA: 0x001B3298 File Offset: 0x001B1698
	public void SetIcon(Sprite sprite, Material material)
	{
		if (null != this.mIcon && sprite != null)
		{
			this.mIcon.sprite = sprite;
			this.mIcon.material = material;
		}
	}

	// Token: 0x06009276 RID: 37494 RVA: 0x001B32CF File Offset: 0x001B16CF
	public void HiddentAllProtectTips()
	{
		this.mProtectRedRoot.SetActive(false);
		this.mProtectBlueRoot.SetActive(false);
		this.mProtectYellowRoot.SetActive(false);
	}

	// Token: 0x06009277 RID: 37495 RVA: 0x001B32F8 File Offset: 0x001B16F8
	private bool _isValidValue(float percent)
	{
		float num = this.mHpBar.value - percent;
		return num >= 0f && num <= 1f;
	}

	// Token: 0x06009278 RID: 37496 RVA: 0x001B332C File Offset: 0x001B172C
	public void ShowProtectStand(bool show, float percent = 0f)
	{
		if (show)
		{
			if (!this._isValidValue(percent))
			{
				return;
			}
			this.mProtectYellowRoot.CustomActive(true);
			this.mProtectYellow.value = this.mHpBar.value - percent;
		}
		else
		{
			this.mProtectYellowRoot.CustomActive(false);
		}
	}

	// Token: 0x06009279 RID: 37497 RVA: 0x001B3384 File Offset: 0x001B1784
	public void ShowProtectFloat(bool show, float percent = 0f)
	{
		if (show)
		{
			if (!this._isValidValue(percent))
			{
				return;
			}
			this.mProtectBlueRoot.CustomActive(true);
			this.mProtectBlue.value = this.mHpBar.value - percent;
		}
		else
		{
			this.mProtectBlueRoot.CustomActive(false);
		}
	}

	// Token: 0x0600927A RID: 37498 RVA: 0x001B33DC File Offset: 0x001B17DC
	public void ShowProtectGround(bool show, float percent = 0f)
	{
		if (show)
		{
			if (!this._isValidValue(percent))
			{
				return;
			}
			this.mProtectRedRoot.CustomActive(true);
			this.mProtectRed.value = this.mHpBar.value - percent;
		}
		else
		{
			this.mProtectRedRoot.CustomActive(false);
		}
	}

	// Token: 0x04004981 RID: 18817
	public CPKHPBar.PKBarType type;

	// Token: 0x04004982 RID: 18818
	private CPKHPBar.PKBarType lastType;

	// Token: 0x04004983 RID: 18819
	public Action action;

	// Token: 0x04004984 RID: 18820
	public ComCommonBind mBind;

	// Token: 0x04004985 RID: 18821
	private Text mName;

	// Token: 0x04004986 RID: 18822
	private Image mIcon;

	// Token: 0x04004987 RID: 18823
	private Text mHpValue;

	// Token: 0x04004988 RID: 18824
	private Slider mHpBar;

	// Token: 0x04004989 RID: 18825
	private Slider mMpBar;

	// Token: 0x0400498A RID: 18826
	private Slider mProtectBlue;

	// Token: 0x0400498B RID: 18827
	private GameObject mProtectBlueRoot;

	// Token: 0x0400498C RID: 18828
	private Slider mProtectYellow;

	// Token: 0x0400498D RID: 18829
	private GameObject mProtectYellowRoot;

	// Token: 0x0400498E RID: 18830
	private Slider mProtectRed;

	// Token: 0x0400498F RID: 18831
	private GameObject mProtectRedRoot;

	// Token: 0x04004990 RID: 18832
	private Button btn;

	// Token: 0x02000E67 RID: 3687
	public enum PKBarType
	{
		// Token: 0x04004992 RID: 18834
		Left,
		// Token: 0x04004993 RID: 18835
		Right
	}
}
