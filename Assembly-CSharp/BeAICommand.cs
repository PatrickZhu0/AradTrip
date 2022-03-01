using System;

// Token: 0x02004112 RID: 16658
[LoggerModel("AI")]
public class BeAICommand
{
	// Token: 0x06016AD7 RID: 92887 RVA: 0x006DFDF0 File Offset: 0x006DE1F0
	public BeAICommand(BeEntity e, string debugInfo = "AICommand")
	{
		this.entity = e;
		this.aiManager = this.entity.aiManager;
		this.debugInfo = debugInfo;
	}

	// Token: 0x06016AD8 RID: 92888 RVA: 0x006DFE25 File Offset: 0x006DE225
	public virtual void Reset(BeEntity e)
	{
		this.entity = e;
		this.aiManager = this.entity.aiManager;
		this.duraction = 0;
		this.state = AI_COMMAND_STAT.READY;
		this.timeAcc = 0;
	}

	// Token: 0x06016AD9 RID: 92889 RVA: 0x006DFE54 File Offset: 0x006DE254
	public bool IsAlive()
	{
		return this.state == AI_COMMAND_STAT.RUNNING;
	}

	// Token: 0x06016ADA RID: 92890 RVA: 0x006DFE5F File Offset: 0x006DE25F
	public bool IsCanClose()
	{
		return this.bCanClose;
	}

	// Token: 0x06016ADB RID: 92891 RVA: 0x006DFE68 File Offset: 0x006DE268
	public void Tick(int deltaTime)
	{
		if (this.state != AI_COMMAND_STAT.RUNNING)
		{
			return;
		}
		this.timeAcc += deltaTime;
		this.OnTick(deltaTime);
		if (this.timeAcc >= this.duraction)
		{
			this.OnFinish();
			this.End();
		}
	}

	// Token: 0x06016ADC RID: 92892 RVA: 0x006DFEB4 File Offset: 0x006DE2B4
	public void Execute()
	{
		this.state = AI_COMMAND_STAT.RUNNING;
		this.OnExecute();
	}

	// Token: 0x06016ADD RID: 92893 RVA: 0x006DFEC3 File Offset: 0x006DE2C3
	public void End()
	{
		this.state = AI_COMMAND_STAT.STOP;
		this.OnEnd();
		this.aiManager.ClrCurrentCommand();
		this.entity.CurrentBeBattle.BeAICommandPool.PutAICommand(this);
	}

	// Token: 0x06016ADE RID: 92894 RVA: 0x006DFEF3 File Offset: 0x006DE2F3
	public virtual void OnTick(int deltaTime)
	{
	}

	// Token: 0x06016ADF RID: 92895 RVA: 0x006DFEF5 File Offset: 0x006DE2F5
	public virtual void OnExecute()
	{
	}

	// Token: 0x06016AE0 RID: 92896 RVA: 0x006DFEF7 File Offset: 0x006DE2F7
	public virtual void OnEnd()
	{
	}

	// Token: 0x06016AE1 RID: 92897 RVA: 0x006DFEF9 File Offset: 0x006DE2F9
	public virtual void OnFinish()
	{
	}

	// Token: 0x06016AE2 RID: 92898 RVA: 0x006DFEFB File Offset: 0x006DE2FB
	public virtual string DebugInfo()
	{
		return this.debugInfo;
	}

	// Token: 0x06016AE3 RID: 92899 RVA: 0x006DFF03 File Offset: 0x006DE303
	public void SetDebugInfo(string debugInfo)
	{
		this.debugInfo = debugInfo;
	}

	// Token: 0x040102BF RID: 66239
	public AI_COMMAND cmdType = AI_COMMAND.NONE;

	// Token: 0x040102C0 RID: 66240
	public int duraction;

	// Token: 0x040102C1 RID: 66241
	protected AI_COMMAND_STAT state;

	// Token: 0x040102C2 RID: 66242
	public BeEntity entity;

	// Token: 0x040102C3 RID: 66243
	public BeAIManager aiManager;

	// Token: 0x040102C4 RID: 66244
	protected int timeAcc;

	// Token: 0x040102C5 RID: 66245
	protected bool bCanClose = true;

	// Token: 0x040102C6 RID: 66246
	protected string debugInfo;
}
