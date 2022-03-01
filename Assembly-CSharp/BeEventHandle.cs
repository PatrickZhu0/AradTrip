using System;

// Token: 0x02004183 RID: 16771
public class BeEventHandle : IBeEventHandle
{
	// Token: 0x06017040 RID: 94272 RVA: 0x007100FF File Offset: 0x0070E4FF
	public BeEventHandle(int eventName, BeEventHandle.Del fn, BeEventProcessor processor)
	{
		this.eventName = eventName;
		this.fn = fn;
		this.processor = processor;
		this.stackLevel = 0;
	}

	// Token: 0x06017041 RID: 94273 RVA: 0x00710124 File Offset: 0x0070E524
	public void DoFunc(object[] args)
	{
		this.stackLevel++;
		if (this.stackLevel > Global.TriggerSingleEventStackLevelLimit && this.stackLevel <= Global.MaxStackLevelLogLimit)
		{
			Logger.LogErrorFormat("call event id {0} recurse out of stack level {1}", new object[]
			{
				this.eventName,
				this.stackLevel
			});
		}
		if (this.fn != null)
		{
			this.fn(args);
		}
		this.stackLevel--;
	}

	// Token: 0x06017042 RID: 94274 RVA: 0x007101B0 File Offset: 0x0070E5B0
	public void Remove()
	{
		if (this.processor != null)
		{
			this.canRemove = true;
		}
	}

	// Token: 0x0401093D RID: 67901
	public int eventName;

	// Token: 0x0401093E RID: 67902
	public BeEventHandle.Del fn;

	// Token: 0x0401093F RID: 67903
	public BeEventProcessor processor;

	// Token: 0x04010940 RID: 67904
	public bool canRemove;

	// Token: 0x04010941 RID: 67905
	private int stackLevel;

	// Token: 0x02004184 RID: 16772
	// (Invoke) Token: 0x06017044 RID: 94276
	public delegate void Del(object[] args);
}
