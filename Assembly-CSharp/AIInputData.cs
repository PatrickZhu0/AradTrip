using System;
using System.Collections.Generic;
using behaviac;

// Token: 0x0200410F RID: 16655
public class AIInputData
{
	// Token: 0x06016AC9 RID: 92873 RVA: 0x006DFAC2 File Offset: 0x006DDEC2
	public AIInputData()
	{
	}

	// Token: 0x06016ACA RID: 92874 RVA: 0x006DFAD5 File Offset: 0x006DDED5
	public AIInputData(int sid, int d = 0, int pt = 0, int c = 0)
	{
		this.AddInput(sid, d, pt, c, false);
	}

	// Token: 0x06016ACB RID: 92875 RVA: 0x006DFAF4 File Offset: 0x006DDEF4
	public void AddInput(int sid, int d = 0, int pt = 0, int c = 0, bool randomChangeDirection = false)
	{
		behaviac.Input item = default(behaviac.Input);
		item.delay = d;
		item.skillID = sid;
		item.pressTime = pt;
		item.specialChoice = c;
		item.randomChangeDirection = randomChangeDirection;
		this.inputs.Add(item);
	}

	// Token: 0x06016ACC RID: 92876 RVA: 0x006DFB3F File Offset: 0x006DDF3F
	public void AddInput(behaviac.Input input)
	{
		this.inputs.Add(input);
	}

	// Token: 0x040102B1 RID: 66225
	public bool useAgent;

	// Token: 0x040102B2 RID: 66226
	public List<behaviac.Input> inputs = new List<behaviac.Input>();

	// Token: 0x040102B3 RID: 66227
	public behaviac.Input lastInputData;

	// Token: 0x040102B4 RID: 66228
	public bool needKeepDistance;

	// Token: 0x02004110 RID: 16656
	public struct Input
	{
		// Token: 0x06016ACD RID: 92877 RVA: 0x006DFB4D File Offset: 0x006DDF4D
		public Input(int sid, int d, int pt, int c)
		{
			this.delay = d;
			this.skillID = sid;
			this.pressTime = pt;
			this.specialChoice = c;
		}

		// Token: 0x040102B5 RID: 66229
		public int delay;

		// Token: 0x040102B6 RID: 66230
		public int skillID;

		// Token: 0x040102B7 RID: 66231
		public int pressTime;

		// Token: 0x040102B8 RID: 66232
		public int specialChoice;
	}
}
