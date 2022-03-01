using System;
using DG.Tweening;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020010CD RID: 4301
public class FinalTestPlayerInfo : MonoBehaviour
{
	// Token: 0x0600A2A5 RID: 41637 RVA: 0x0021321C File Offset: 0x0021161C
	private void Start()
	{
		base.Invoke("PlayTween", 5f);
	}

	// Token: 0x0600A2A6 RID: 41638 RVA: 0x0021322E File Offset: 0x0021162E
	private void Update()
	{
	}

	// Token: 0x0600A2A7 RID: 41639 RVA: 0x00213230 File Offset: 0x00211630
	public void SetPlayerInfo(FinalPlayerInfo info)
	{
		this.info = info;
		this.lv.text = string.Empty + info.level.ToString();
		this.icon.sprite = info.icon;
		this.icon.material = info.material;
		this.name.text = info.name;
		this.hpSlider.value = (float)info.hp / (float)info.maxHp;
		this.hp.text = (int)((float)info.hp / (float)info.maxHp * 100f) + "%";
		this.mpSlider.value = (float)info.mp / (float)info.maxMp;
		this.mp.text = (int)((float)info.mp / (float)info.maxMp * 100f) + "%";
	}

	// Token: 0x0600A2A8 RID: 41640 RVA: 0x00213334 File Offset: 0x00211734
	public void PlayTween()
	{
		if (this.info != null)
		{
			float num = (float)(this.info.hp + this.info.addHp) / (float)this.info.maxHp;
			ShortcutExtensions46.DOValue(this.hpSlider, num, 1f, false);
			float num2 = (float)(this.info.mp + this.info.addMp) / (float)this.info.maxMp;
			ShortcutExtensions46.DOValue(this.mpSlider, num2, 1f, false);
			int number = (int)((float)this.info.hp / (float)this.info.maxHp * 100f);
			int num3 = (int)((float)(this.info.hp + this.info.addHp) / (float)this.info.maxHp * 100f);
			Tween tween = DOTween.To(() => number, delegate(int x)
			{
				number = x;
			}, num3, 1f);
			TweenSettingsExtensions.OnUpdate<Tween>(tween, delegate()
			{
				this.UpdateHpTween(number);
			});
			int _number = (int)((float)this.info.mp / (float)this.info.maxMp * 100f);
			int num4 = (int)((float)(this.info.mp + this.info.addMp) / (float)this.info.maxMp * 100f);
			Tween tween2 = DOTween.To(() => _number, delegate(int x)
			{
				_number = x;
			}, num4, 1f);
			TweenSettingsExtensions.OnUpdate<Tween>(tween2, delegate()
			{
				this.UpdateMpTween(_number);
			});
		}
	}

	// Token: 0x0600A2A9 RID: 41641 RVA: 0x002134E5 File Offset: 0x002118E5
	private void UpdateHpTween(int num)
	{
		num = Mathf.Clamp(num, 0, 100);
		this.hp.text = num + "%";
	}

	// Token: 0x0600A2AA RID: 41642 RVA: 0x0021350D File Offset: 0x0021190D
	private void UpdateMpTween(int num)
	{
		num = Mathf.Clamp(num, 0, 100);
		this.mp.text = num + "%";
	}

	// Token: 0x04005AB7 RID: 23223
	public Text lv;

	// Token: 0x04005AB8 RID: 23224
	public Image icon;

	// Token: 0x04005AB9 RID: 23225
	public Text name;

	// Token: 0x04005ABA RID: 23226
	public Slider hpSlider;

	// Token: 0x04005ABB RID: 23227
	public Text hp;

	// Token: 0x04005ABC RID: 23228
	public Slider mpSlider;

	// Token: 0x04005ABD RID: 23229
	public Text mp;

	// Token: 0x04005ABE RID: 23230
	private FinalPlayerInfo info;
}
