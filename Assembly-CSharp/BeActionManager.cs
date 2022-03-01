using System;
using System.Collections.Generic;

// Token: 0x02004215 RID: 16917
public class BeActionManager
{
	// Token: 0x060176B3 RID: 95923 RVA: 0x007320D4 File Offset: 0x007304D4
	public void Init()
	{
	}

	// Token: 0x060176B4 RID: 95924 RVA: 0x007320D6 File Offset: 0x007304D6
	public void Deinit()
	{
		this.actionList.Clear();
	}

	// Token: 0x060176B5 RID: 95925 RVA: 0x007320E3 File Offset: 0x007304E3
	public void RunAction(BeAction action)
	{
		action.manager = this;
		action.Start();
		this.actionList.Add(action);
	}

	// Token: 0x060176B6 RID: 95926 RVA: 0x007320FE File Offset: 0x007304FE
	private bool CheckCanRemove(BeAction item)
	{
		return !item.IsRunning();
	}

	// Token: 0x060176B7 RID: 95927 RVA: 0x00732110 File Offset: 0x00730510
	public void Update(int deltaTime)
	{
		bool flag = false;
		for (int i = 0; i < this.actionList.Count; i++)
		{
			BeAction beAction = this.actionList[i];
			if (this.CheckCanRemove(beAction))
			{
				flag = true;
			}
			if (!beAction.IsPause())
			{
				beAction.Update(deltaTime);
			}
		}
		if (flag)
		{
			this._RemoveAction();
		}
	}

	// Token: 0x060176B8 RID: 95928 RVA: 0x00732174 File Offset: 0x00730574
	private void _RemoveAction()
	{
		this.actionList.RemoveAll(new Predicate<BeAction>(this.CheckCanRemove));
	}

	// Token: 0x060176B9 RID: 95929 RVA: 0x00732190 File Offset: 0x00730590
	public void Pause()
	{
		for (int i = 0; i < this.actionList.Count; i++)
		{
			BeAction beAction = this.actionList[i];
			if (beAction.IsRunning())
			{
				beAction.Pause();
			}
		}
	}

	// Token: 0x060176BA RID: 95930 RVA: 0x007321D8 File Offset: 0x007305D8
	public void Resume()
	{
		for (int i = 0; i < this.actionList.Count; i++)
		{
			BeAction beAction = this.actionList[i];
			if (beAction.IsRunning() && beAction.IsPause())
			{
				beAction.Resume();
			}
		}
	}

	// Token: 0x060176BB RID: 95931 RVA: 0x0073222C File Offset: 0x0073062C
	public void StopAll()
	{
		for (int i = 0; i < this.actionList.Count; i++)
		{
			BeAction beAction = this.actionList[i];
			if (beAction.IsRunning())
			{
				beAction.Stop();
			}
		}
	}

	// Token: 0x060176BC RID: 95932 RVA: 0x00732274 File Offset: 0x00730674
	public BeAction GetRunningAction()
	{
		for (int i = 0; i < this.actionList.Count; i++)
		{
			BeAction beAction = this.actionList[i];
			if (beAction.IsRunning())
			{
				return beAction;
			}
		}
		return null;
	}

	// Token: 0x060176BD RID: 95933 RVA: 0x007322B8 File Offset: 0x007306B8
	public List<BeAction> GetActionList()
	{
		return this.actionList;
	}

	// Token: 0x04010D10 RID: 68880
	private List<BeAction> actionList = new List<BeAction>();
}
