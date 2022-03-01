using System;
using System.Collections.Generic;

// Token: 0x0200420B RID: 16907
public class BeActionSequence : BeAction
{
	// Token: 0x06017697 RID: 95895 RVA: 0x00731B04 File Offset: 0x0072FF04
	public static BeActionSequence Create(params object[] args)
	{
		BeActionSequence beActionSequence = new BeActionSequence
		{
			duration = int.MaxValue
		};
		for (int i = 0; i < args.Length; i++)
		{
			beActionSequence.actionList.Add(args[i] as BeAction);
		}
		return beActionSequence;
	}

	// Token: 0x06017698 RID: 95896 RVA: 0x00731B4C File Offset: 0x0072FF4C
	public sealed override void OnStart()
	{
		this.curIndex = -1;
		this.StartNext();
	}

	// Token: 0x06017699 RID: 95897 RVA: 0x00731B5C File Offset: 0x0072FF5C
	public sealed override void OnTick(int deltaTime)
	{
		BeAction beAction = this.actionList[this.curIndex];
		if (!beAction.IsRunning())
		{
			this.StartNext();
		}
	}

	// Token: 0x0601769A RID: 95898 RVA: 0x00731B8C File Offset: 0x0072FF8C
	protected void StartNext()
	{
		this.curIndex++;
		if (this.curIndex >= this.actionList.Count)
		{
			base.Stop();
			return;
		}
		BeAction action = this.actionList[this.curIndex];
		if (this.manager != null)
		{
			this.manager.RunAction(action);
		}
	}

	// Token: 0x04010CFC RID: 68860
	protected List<BeAction> actionList = new List<BeAction>();

	// Token: 0x04010CFD RID: 68861
	protected int curIndex;
}
