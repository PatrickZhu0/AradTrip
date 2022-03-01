using System;

// Token: 0x02004113 RID: 16659
[LoggerModel("AI")]
public class BeAINoneCommand : BeAICommand
{
	// Token: 0x06016AE4 RID: 92900 RVA: 0x006DFF0C File Offset: 0x006DE30C
	public BeAINoneCommand(BeEntity e) : base(e, "AINoneCommand")
	{
		this.cmdType = AI_COMMAND.NONE;
	}

	// Token: 0x06016AE5 RID: 92901 RVA: 0x006DFF21 File Offset: 0x006DE321
	public void Init()
	{
	}

	// Token: 0x06016AE6 RID: 92902 RVA: 0x006DFF24 File Offset: 0x006DE324
	public override void OnExecute()
	{
		if (this.entity != null)
		{
			this.entity.ResetMoveCmd();
			this.entity.dontSetFace = false;
			BeActor beActor = this.entity as BeActor;
			if (beActor != null)
			{
				beActor.ChangeRunMode(false);
			}
			else
			{
				Logger.LogError("entity is not BeActor!");
			}
		}
		else
		{
			Logger.LogErrorFormat("entity is null!", new object[0]);
		}
	}
}
