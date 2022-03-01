using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020010CC RID: 4300
public class FailBossInfo : MonoBehaviour
{
	// Token: 0x0600A2A1 RID: 41633 RVA: 0x00213177 File Offset: 0x00211577
	private void Start()
	{
	}

	// Token: 0x0600A2A2 RID: 41634 RVA: 0x00213179 File Offset: 0x00211579
	private void Update()
	{
	}

	// Token: 0x0600A2A3 RID: 41635 RVA: 0x0021317C File Offset: 0x0021157C
	public void SetBossInfo(BossInfo info)
	{
		this.icon.sprite = info.icon;
		this.icon.material = info.material;
		this.level.text = string.Format("Lv.{0}", info.level);
		this.name.text = info.name;
		this.hpSlider.value = info.hpRate;
		this.hp.text = string.Format("{0}%", (int)(info.hpRate * 100f));
	}

	// Token: 0x04005AB2 RID: 23218
	public Image icon;

	// Token: 0x04005AB3 RID: 23219
	public Text level;

	// Token: 0x04005AB4 RID: 23220
	public Text name;

	// Token: 0x04005AB5 RID: 23221
	public Text hp;

	// Token: 0x04005AB6 RID: 23222
	public Slider hpSlider;
}
