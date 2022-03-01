using System;

// Token: 0x0200446F RID: 17519
public class Skill1804 : BeSkill
{
	// Token: 0x060185B8 RID: 99768 RVA: 0x00796DCC File Offset: 0x007951CC
	public Skill1804(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185B9 RID: 99769 RVA: 0x00796E66 File Offset: 0x00795266
	public override void OnInit()
	{
	}

	// Token: 0x060185BA RID: 99770 RVA: 0x00796E68 File Offset: 0x00795268
	public override void OnPostInit()
	{
		if (this.m_LastCastHandle != null)
		{
			this.m_LastCastHandle.Remove();
		}
		this.m_LastCastHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			int num = array[0];
			if (num == this.m_KazanSkillId || num == this.m_SayaSkillId || num == this.m_PulimengSkillId)
			{
				this.m_LastSkillId = num;
			}
		});
	}

	// Token: 0x060185BB RID: 99771 RVA: 0x00796E9F File Offset: 0x0079529F
	public override void OnStart()
	{
		this.m_SkillCastHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			int num = array[0];
			if (num == this.m_ChargePhaseOne)
			{
				base.owner.SetCurrSkillPhase(this._newPhaseArray);
			}
			if (num == this.m_ChargePhaseTwo && this.m_LastSkillId != 0)
			{
				if (this.m_LastSkillId == this.m_KazanSkillId)
				{
					array[0] = this.m_ReplaceIdKazan;
				}
				else if (this.m_LastSkillId == this.m_SayaSkillId)
				{
					array[0] = this.m_ReplaceIdSaya;
				}
				else if (this.m_LastSkillId == this.m_PulimengSkillId)
				{
					array[0] = this.m_ReplaceIdPuliemeng;
				}
			}
		});
		this._curFrameHandle = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, new BeEventHandle.Del(this._OnSkillCurFrame));
	}

	// Token: 0x060185BC RID: 99772 RVA: 0x00796EDF File Offset: 0x007952DF
	public override void OnClickAgain()
	{
		base.OnClickAgain();
		this._ResetButtonState();
		base.owner.SetCurrSkillPhase(new int[]
		{
			1804,
			180412,
			18041,
			180422,
			180423
		});
		((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
	}

	// Token: 0x060185BD RID: 99773 RVA: 0x00796F20 File Offset: 0x00795320
	private void _OnSkillCurFrame(object[] args)
	{
		string a = args[0] as string;
		if (a == this._startFlag)
		{
			this.pressMode = SkillPressMode.PRESS_MANY_TWO;
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
			base.ChangeButtonEffect();
		}
		else if (a == this._endFlag)
		{
			this._ResetButtonState();
		}
	}

	// Token: 0x060185BE RID: 99774 RVA: 0x00796F77 File Offset: 0x00795377
	public override void OnCancel()
	{
		base.OnCancel();
		this._ClearData();
	}

	// Token: 0x060185BF RID: 99775 RVA: 0x00796F85 File Offset: 0x00795385
	public override void OnFinish()
	{
		base.OnFinish();
		this._ClearData();
	}

	// Token: 0x060185C0 RID: 99776 RVA: 0x00796F94 File Offset: 0x00795394
	private void _ClearData()
	{
		if (this.m_SkillCastHandle != null)
		{
			this.m_SkillCastHandle.Remove();
			this.m_SkillCastHandle = null;
		}
		if (this._curFrameHandle != null)
		{
			this._curFrameHandle.Remove();
			this._curFrameHandle = null;
		}
		this._ResetButtonState();
	}

	// Token: 0x060185C1 RID: 99777 RVA: 0x00796FE1 File Offset: 0x007953E1
	private void _ResetButtonState()
	{
		this.pressMode = SkillPressMode.NORMAL;
		base.ResetButtonEffect();
	}

	// Token: 0x04011953 RID: 72019
	protected BeEventHandle m_SkillCastHandle;

	// Token: 0x04011954 RID: 72020
	protected BeEventHandle m_LastCastHandle;

	// Token: 0x04011955 RID: 72021
	protected int m_ChargePhaseOne = 180421;

	// Token: 0x04011956 RID: 72022
	protected int m_ChargePhaseTwo = 180422;

	// Token: 0x04011957 RID: 72023
	protected int m_KazanSkillId = 1521;

	// Token: 0x04011958 RID: 72024
	protected int m_SayaSkillId = 1806;

	// Token: 0x04011959 RID: 72025
	protected int m_PulimengSkillId = 1805;

	// Token: 0x0401195A RID: 72026
	protected int m_LastSkillId;

	// Token: 0x0401195B RID: 72027
	protected int m_ReplaceIdKazan = 180422;

	// Token: 0x0401195C RID: 72028
	protected int m_ReplaceIdSaya = 1804222;

	// Token: 0x0401195D RID: 72029
	protected int m_ReplaceIdPuliemeng = 1804221;

	// Token: 0x0401195E RID: 72030
	private BeEventHandle _curFrameHandle;

	// Token: 0x0401195F RID: 72031
	private string _startFlag = "180401";

	// Token: 0x04011960 RID: 72032
	private string _endFlag = "180402";

	// Token: 0x04011961 RID: 72033
	private int[] _newPhaseArray = new int[]
	{
		1804,
		180412,
		18041,
		180422,
		180423
	};
}
