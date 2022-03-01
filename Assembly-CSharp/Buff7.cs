using System;
using GameClient;

// Token: 0x0200422F RID: 16943
public class Buff7 : BeBuff
{
	// Token: 0x06017742 RID: 96066 RVA: 0x00734DEB File Offset: 0x007331EB
	public Buff7(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017743 RID: 96067 RVA: 0x00734DFC File Offset: 0x007331FC
	public override void OnStart()
	{
		this.RemoveHanlder();
		if (!base.owner.CurrentBeBattle.HasFlag(BattleFlagType.Buff7Finish))
		{
			base.NeedRestoreTargetAction = false;
		}
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			this.m_IsBeHitFinish = true;
			base.Finish();
		});
	}

	// Token: 0x06017744 RID: 96068 RVA: 0x00734E50 File Offset: 0x00733250
	public override void OnFinish()
	{
		this.RemoveHanlder();
		this.SwitState();
	}

	// Token: 0x06017745 RID: 96069 RVA: 0x00734E60 File Offset: 0x00733260
	protected void SwitState()
	{
		if (base.owner.sgGetCurrentState() == 11)
		{
			if (!base.owner.CurrentBeBattle.HasFlag(BattleFlagType.Buff7Finish))
			{
				if (!this.m_IsBeHitFinish)
				{
					base.owner.GetStateGraph().SwitchStates(new BeStateData(17, 0));
				}
				else
				{
					base.owner.Locomote(new BeStateData(11, 0, 0, 0, 0, GlobalLogic.VALUE_300, false), false);
				}
			}
			else
			{
				base.owner.Locomote(new BeStateData(11, 0, 0, 0, 0, GlobalLogic.VALUE_300, false), false);
			}
		}
	}

	// Token: 0x06017746 RID: 96070 RVA: 0x00734F02 File Offset: 0x00733302
	private void RemoveHanlder()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04010D61 RID: 68961
	private BeEventHandle handler;

	// Token: 0x04010D62 RID: 68962
	protected bool m_IsBeHitFinish;
}
