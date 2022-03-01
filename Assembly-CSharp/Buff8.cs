using System;
using System.Collections.Generic;

// Token: 0x02004231 RID: 16945
public class Buff8 : BeBuff
{
	// Token: 0x06017749 RID: 96073 RVA: 0x00734F30 File Offset: 0x00733330
	public Buff8(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x0601774A RID: 96074 RVA: 0x00734F3E File Offset: 0x0073333E
	public override void OnStart()
	{
		this.RemoveHanlder();
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			if (args.Length > 6)
			{
				List<int> list = new List<int>();
				list = (List<int>)args[6];
				if (list.Contains(2))
				{
					base.Finish();
				}
			}
		});
	}

	// Token: 0x0601774B RID: 96075 RVA: 0x00734F65 File Offset: 0x00733365
	public override void OnFinish()
	{
		this.RemoveHanlder();
	}

	// Token: 0x0601774C RID: 96076 RVA: 0x00734F6D File Offset: 0x0073336D
	private void RemoveHanlder()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04010D63 RID: 68963
	private BeEventHandle handler;
}
