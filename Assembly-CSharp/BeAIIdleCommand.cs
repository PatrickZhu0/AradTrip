using System;

// Token: 0x02004114 RID: 16660
[LoggerModel("AI")]
public class BeAIIdleCommand : BeAICommand
{
	// Token: 0x06016AE7 RID: 92903 RVA: 0x006DFF90 File Offset: 0x006DE390
	public BeAIIdleCommand(BeEntity e) : base(e, "AIIdleCommand")
	{
		this.cmdType = AI_COMMAND.IDLE;
	}

	// Token: 0x06016AE8 RID: 92904 RVA: 0x006DFFA5 File Offset: 0x006DE3A5
	public void Init(int dur)
	{
		this.duraction = dur;
	}

	// Token: 0x06016AE9 RID: 92905 RVA: 0x006DFFAE File Offset: 0x006DE3AE
	public override void OnExecute()
	{
		if (this.entity != null)
		{
			this.entity.Reset();
		}
		else
		{
			Logger.LogErrorFormat("entity is null!", new object[0]);
		}
	}

	// Token: 0x06016AEA RID: 92906 RVA: 0x006DFFDB File Offset: 0x006DE3DB
	public override void OnFinish()
	{
		if (this.entity != null && this.entity.aiManager != null && this.entity.aiManager != null)
		{
			this.entity.aiManager.ResetDestinationSelect();
		}
	}
}
