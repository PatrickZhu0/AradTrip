using System;
using GameClient;

// Token: 0x0200442C RID: 17452
public class Skill1007 : BeSkill
{
	// Token: 0x060183BE RID: 99262 RVA: 0x0078BC94 File Offset: 0x0078A094
	public Skill1007(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183BF RID: 99263 RVA: 0x0078BCA8 File Offset: 0x0078A0A8
	public override void OnInit()
	{
		this.originSkillPhaseID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.replaceSkillPhaseID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.originSkillPhaseID2 = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.replaceSkillPhaseID2 = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
	}

	// Token: 0x060183C0 RID: 99264 RVA: 0x0078BD44 File Offset: 0x0078A144
	public override void OnPostInit()
	{
		base.OnPostInit();
		if (!base.owner.isLocalActor)
		{
			return;
		}
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("1007") == InputManager.SlideSetting.SLIDE);
		if (!this.canSlide)
		{
			this.joystickMode = SkillJoystickMode.NONE;
		}
	}

	// Token: 0x060183C1 RID: 99265 RVA: 0x0078BD92 File Offset: 0x0078A192
	public override void OnStart()
	{
		this.ClearHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onActionLoop, delegate(object[] args)
		{
			if (!base.owner.IsCastingSkill())
			{
				return;
			}
			this.ChooseRightSkill(this.currentDir);
		});
	}

	// Token: 0x060183C2 RID: 99266 RVA: 0x0078BDB9 File Offset: 0x0078A1B9
	public override void OnUpdateJoystick(int degree)
	{
		this.currentDir = InputManager.GetDir(degree);
	}

	// Token: 0x060183C3 RID: 99267 RVA: 0x0078BDC7 File Offset: 0x0078A1C7
	public override void OnEnterPhase(int phase)
	{
		this.RemoveHandle2();
		if (phase == 2 || phase == 3)
		{
			this.handle2 = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
			{
				int[] array = (int[])args[0];
				int num = array[0];
				if (this.currentDir == InputManager.PressDir.TOP)
				{
					if (num == this.originSkillPhaseID)
					{
						array[0] = this.replaceSkillPhaseID;
					}
					else if (num == this.originSkillPhaseID2)
					{
						array[0] = this.replaceSkillPhaseID2;
					}
				}
				this.RemoveHandle2();
			});
		}
	}

	// Token: 0x060183C4 RID: 99268 RVA: 0x0078BDFC File Offset: 0x0078A1FC
	public override void OnFinish()
	{
		this.CleanUP();
	}

	// Token: 0x060183C5 RID: 99269 RVA: 0x0078BE04 File Offset: 0x0078A204
	public override void OnCancel()
	{
		this.CleanUP();
	}

	// Token: 0x060183C6 RID: 99270 RVA: 0x0078BE0C File Offset: 0x0078A20C
	protected void RemoveHandle2()
	{
		if (this.handle2 != null)
		{
			this.handle2.Remove();
			this.handle2 = null;
		}
	}

	// Token: 0x060183C7 RID: 99271 RVA: 0x0078BE2C File Offset: 0x0078A22C
	protected void ChooseRightSkill(InputManager.PressDir dir)
	{
		int targetPhaseSkillIndex = this.originSkillPhaseID;
		if (dir == InputManager.PressDir.TOP)
		{
			targetPhaseSkillIndex = this.replaceSkillPhaseID;
		}
		if (base.owner.m_cpkCurEntityActionInfo != null && base.owner.m_cpkCurEntityActionInfo.skillID != targetPhaseSkillIndex)
		{
			base.owner.delayCaller.DelayCall(10, delegate
			{
				this.owner.PlaySkillAction(targetPhaseSkillIndex);
			}, 0, 0, false);
		}
	}

	// Token: 0x060183C8 RID: 99272 RVA: 0x0078BEB1 File Offset: 0x0078A2B1
	protected void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x060183C9 RID: 99273 RVA: 0x0078BED0 File Offset: 0x0078A2D0
	protected void ClearHandle()
	{
		this.RemoveHandle();
		this.RemoveHandle2();
	}

	// Token: 0x060183CA RID: 99274 RVA: 0x0078BEDE File Offset: 0x0078A2DE
	protected void CleanUP()
	{
		this.ClearHandle();
		this.currentDir = InputManager.PressDir.NONE;
	}

	// Token: 0x040117DB RID: 71643
	protected BeEventHandle handle;

	// Token: 0x040117DC RID: 71644
	protected BeEventHandle handle2;

	// Token: 0x040117DD RID: 71645
	protected int originSkillPhaseID;

	// Token: 0x040117DE RID: 71646
	protected int replaceSkillPhaseID;

	// Token: 0x040117DF RID: 71647
	protected int originSkillPhaseID2;

	// Token: 0x040117E0 RID: 71648
	protected int replaceSkillPhaseID2;

	// Token: 0x040117E1 RID: 71649
	protected InputManager.PressDir currentDir = InputManager.PressDir.RIGHT;
}
