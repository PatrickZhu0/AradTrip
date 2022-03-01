using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F8F RID: 3983
public class SkillComboItem : MonoBehaviour
{
	// Token: 0x06009A15 RID: 39445 RVA: 0x001DA758 File Offset: 0x001D8B58
	public void InitItem(int groupID, int skillD, string desc, float waitInputTime, int sourceID = 0, int phase = 0, bool showArrow = true)
	{
		this.groupID = groupID;
		this.state1.CustomActive(showArrow);
		this.showArrow = showArrow;
		this.phaseBg.CustomActive(phase != 0);
		this.phase.CustomActive(phase != 0);
		this.phase.text = phase.ToString();
		this.totaltime = waitInputTime / 1000f;
		this.mask.CustomActive(false);
		this.skillID = skillD;
		SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((sourceID != 0) ? sourceID : skillD, string.Empty, string.Empty);
		TrainingSkillComboBattle trainingSkillComboBattle = BattleMain.instance.GetBattle() as TrainingSkillComboBattle;
		if (trainingSkillComboBattle.IsLastCombo(groupID))
		{
			this.arrow.CustomActive(false);
		}
		ETCImageLoader.LoadSprite(ref this.skillIcon, tableItem.Icon, true);
	}

	// Token: 0x06009A16 RID: 39446 RVA: 0x001DA83F File Offset: 0x001D8C3F
	public void StartComboCD()
	{
		if (BattleMain.battleType != BattleType.TrainingSkillCombo)
		{
			return;
		}
		this.time = 0f;
		this.startCD = true;
		this.cdImage.gameObject.CustomActive(this.startCD);
	}

	// Token: 0x06009A17 RID: 39447 RVA: 0x001DA875 File Offset: 0x001D8C75
	public void StopComboCD()
	{
		if (BattleMain.battleType != BattleType.TrainingSkillCombo)
		{
			return;
		}
		this.startCD = false;
		this.cdImage.gameObject.CustomActive(this.startCD);
		this.ShowPassSelect();
	}

	// Token: 0x06009A18 RID: 39448 RVA: 0x001DA8A8 File Offset: 0x001D8CA8
	private void Update()
	{
		if (this.startCD)
		{
			this.time += Time.deltaTime;
			this.cdImage.fillAmount = (this.totaltime - this.time) / this.totaltime;
			if (this.time > this.totaltime)
			{
				if (SkillComboItem.timeOutCallBack != null)
				{
					SkillComboItem.timeOutCallBack();
				}
				this.time = 0f;
				this.StopComboCD();
				this.ShowError();
			}
		}
	}

	// Token: 0x06009A19 RID: 39449 RVA: 0x001DA92D File Offset: 0x001D8D2D
	public void SelectCurrent()
	{
		this.mask.CustomActive(false);
	}

	// Token: 0x06009A1A RID: 39450 RVA: 0x001DA93B File Offset: 0x001D8D3B
	public void ShowEffect()
	{
		this.effect.CustomActive(true);
	}

	// Token: 0x06009A1B RID: 39451 RVA: 0x001DA949 File Offset: 0x001D8D49
	private void ShowPassSelect()
	{
		this.state1.CustomActive(false);
		this.state2.CustomActive(true);
		this.state3.CustomActive(false);
	}

	// Token: 0x06009A1C RID: 39452 RVA: 0x001DA96F File Offset: 0x001D8D6F
	private void ShowError()
	{
		this.state1.CustomActive(false);
		this.state2.CustomActive(false);
		this.state3.CustomActive(true);
	}

	// Token: 0x04004F59 RID: 20313
	public GameObject arrow;

	// Token: 0x04004F5A RID: 20314
	public GameObject unSelectState;

	// Token: 0x04004F5B RID: 20315
	public Image skillIcon;

	// Token: 0x04004F5C RID: 20316
	public Image mask;

	// Token: 0x04004F5D RID: 20317
	public Image cdImage;

	// Token: 0x04004F5E RID: 20318
	public Text phase;

	// Token: 0x04004F5F RID: 20319
	public GameObject phaseBg;

	// Token: 0x04004F60 RID: 20320
	public GameObject state1;

	// Token: 0x04004F61 RID: 20321
	public GameObject state2;

	// Token: 0x04004F62 RID: 20322
	public GameObject state3;

	// Token: 0x04004F63 RID: 20323
	public GameObject effect;

	// Token: 0x04004F64 RID: 20324
	[NonSerialized]
	public int skillID;

	// Token: 0x04004F65 RID: 20325
	[NonSerialized]
	public bool startCD;

	// Token: 0x04004F66 RID: 20326
	[NonSerialized]
	public int groupID;

	// Token: 0x04004F67 RID: 20327
	private float totaltime;

	// Token: 0x04004F68 RID: 20328
	public static Action timeOutCallBack;

	// Token: 0x04004F69 RID: 20329
	private bool showArrow = true;

	// Token: 0x04004F6A RID: 20330
	private float time;
}
