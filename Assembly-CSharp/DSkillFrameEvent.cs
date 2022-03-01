using System;

// Token: 0x02004BBB RID: 19387
[Serializable]
public class DSkillFrameEvent
{
	// Token: 0x0601C76A RID: 116586 RVA: 0x0089F4D6 File Offset: 0x0089D8D6
	public virtual void copyFrameEvent(DSkillFrameEvent src)
	{
		this.name = src.name;
		this.startframe = src.startframe;
		this.length = src.length;
	}

	// Token: 0x04013A30 RID: 80432
	public string name;

	// Token: 0x04013A31 RID: 80433
	public int startframe;

	// Token: 0x04013A32 RID: 80434
	public int length = 1;
}
