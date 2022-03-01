using System;
using System.Collections.Generic;

// Token: 0x020041C8 RID: 16840
public class BeStates
{
	// Token: 0x06017391 RID: 95121 RVA: 0x0072366C File Offset: 0x00721A6C
	public BeStates(int stateid, int tag = 0, BeStates.Del enterfunc = null, BeStates.Del timeoutfunc = null, BeStates.Del2 tickfunc = null, BeStates.Del2 leavefunc = null)
	{
		this.iStateID = stateid;
		this.kTags = new SeFlag(tag);
		this.kExTags = new SeFlag(0);
		this.pkGraph = null;
		this.uiTimeOut = -1;
		this.OnEnter = enterfunc;
		this.OnLeave = leavefunc;
		this.OnTimeOut = timeoutfunc;
		this.OnTick = tickfunc;
		this.priority = 1;
		this.canCover = true;
	}

	// Token: 0x04010B82 RID: 68482
	public int iStateID;

	// Token: 0x04010B83 RID: 68483
	public int uiTimeOut;

	// Token: 0x04010B84 RID: 68484
	public SeFlag kTags;

	// Token: 0x04010B85 RID: 68485
	public SeFlag kExTags;

	// Token: 0x04010B86 RID: 68486
	public BeStatesGraph pkGraph;

	// Token: 0x04010B87 RID: 68487
	public BeStates.Del OnEnter;

	// Token: 0x04010B88 RID: 68488
	public BeStates.Del2 OnLeave;

	// Token: 0x04010B89 RID: 68489
	public BeStates.Del OnTimeOut;

	// Token: 0x04010B8A RID: 68490
	public BeStates.Del2 OnTick;

	// Token: 0x04010B8B RID: 68491
	public List<BeTimeLineHandler> OnTimeLineHandler = new List<BeTimeLineHandler>();

	// Token: 0x04010B8C RID: 68492
	public List<BeEventsHandler> OnEventHandler = new List<BeEventsHandler>();

	// Token: 0x04010B8D RID: 68493
	public int priority;

	// Token: 0x04010B8E RID: 68494
	public bool canCover;

	// Token: 0x04010B8F RID: 68495
	public bool isForceSwitch;

	// Token: 0x020041C9 RID: 16841
	// (Invoke) Token: 0x06017393 RID: 95123
	public delegate void Del(BeStates state);

	// Token: 0x020041CA RID: 16842
	// (Invoke) Token: 0x06017397 RID: 95127
	public delegate void Del2(BeStates state, int t);
}
