using System;

// Token: 0x02004291 RID: 17041
public class Mechanism1071 : BeMechanism
{
	// Token: 0x0601793C RID: 96572 RVA: 0x00742207 File Offset: 0x00740607
	public Mechanism1071(int id, int level) : base(id, level)
	{
	}

	// Token: 0x0601793D RID: 96573 RVA: 0x00742214 File Offset: 0x00740614
	public override void OnStart()
	{
		this.ClearEventHandle();
		BeActor beActor = null;
		if (base.owner != null)
		{
			BeEntity topOwner = base.owner.GetTopOwner(base.owner.GetOwner());
			if (topOwner != null)
			{
				beActor = (topOwner as BeActor);
			}
			else
			{
				beActor = (base.owner.GetOwner() as BeActor);
			}
		}
		if (base.owner != null && beActor != null && beActor.isLocalActor)
		{
			this.onChangeHitTextType = base.owner.RegisterEvent(BeEventType.onChangeHitNumberType, delegate(object[] args)
			{
				bool[] array = (bool[])args[0];
				if (base.owner.GetOwner() != null && array != null && array.Length > 0)
				{
					array[0] = true;
				}
			});
		}
	}

	// Token: 0x0601793E RID: 96574 RVA: 0x007422AE File Offset: 0x007406AE
	public override void OnFinish()
	{
		this.ClearEventHandle();
	}

	// Token: 0x0601793F RID: 96575 RVA: 0x007422B6 File Offset: 0x007406B6
	private void ClearEventHandle()
	{
		if (this.onChangeHitTextType != null)
		{
			this.onChangeHitTextType.Remove();
			this.onChangeHitTextType = null;
		}
	}

	// Token: 0x04010F16 RID: 69398
	private BeEventHandle onChangeHitTextType;
}
