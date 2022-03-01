using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042EA RID: 17130
public class Mechanism1182 : BeMechanism
{
	// Token: 0x06017B40 RID: 97088 RVA: 0x0074E2BC File Offset: 0x0074C6BC
	public Mechanism1182(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B41 RID: 97089 RVA: 0x0074E2D4 File Offset: 0x0074C6D4
	public override void OnInit()
	{
		base.OnInit();
		this._skillStartInfoList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism1182.SkillStartInfo item = default(Mechanism1182.SkillStartInfo);
			item.SkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.StartPhase = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			this._skillStartInfoList.Add(item);
		}
	}

	// Token: 0x06017B42 RID: 97090 RVA: 0x0074E379 File Offset: 0x0074C779
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x06017B43 RID: 97091 RVA: 0x0074E387 File Offset: 0x0074C787
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEventNew(BeEventType.onSkillStart, new BeEvent.BeEventHandleNew.Function(this._OnSkillStar));
	}

	// Token: 0x06017B44 RID: 97092 RVA: 0x0074E3AC File Offset: 0x0074C7AC
	private void _OnSkillStar(BeEvent.BeEventParam param)
	{
		for (int i = 0; i < this._skillStartInfoList.Count; i++)
		{
			Mechanism1182.SkillStartInfo skillStartInfo = this._skillStartInfoList[i];
			if (skillStartInfo.SkillId == param.m_Int)
			{
				BeSkill beSkill = param.m_Obj as BeSkill;
				if (beSkill != null)
				{
					beSkill.SetSkillStartPhase(skillStartInfo.StartPhase);
				}
			}
		}
	}

	// Token: 0x04011081 RID: 69761
	private List<Mechanism1182.SkillStartInfo> _skillStartInfoList = new List<Mechanism1182.SkillStartInfo>();

	// Token: 0x020042EB RID: 17131
	private struct SkillStartInfo
	{
		// Token: 0x04011082 RID: 69762
		public int SkillId;

		// Token: 0x04011083 RID: 69763
		public int StartPhase;
	}
}
