using System;

// Token: 0x020044C7 RID: 17607
public class Skill3504 : Skill3601
{
	// Token: 0x060187FF RID: 100351 RVA: 0x007A630F File Offset: 0x007A470F
	public Skill3504(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018800 RID: 100352 RVA: 0x007A6335 File Offset: 0x007A4735
	public override void OnInit()
	{
		base.OnInit();
		this.startSwitchId = "3504101";
		this.endSwitchId = "3504102";
	}

	// Token: 0x06018801 RID: 100353 RVA: 0x007A6353 File Offset: 0x007A4753
	public override void OnStart()
	{
		base.OnStart();
		this.handleB = base.owner.RegisterEvent(BeEventType.onEndGrab, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			if (beActor == null || beActor.IsRemoved())
			{
				return;
			}
			int hurtid = (!this.switchFlag) ? this.hurtIdArr[0] : this.hurtIdArr[1];
			base.owner.DoAttackTo(beActor, hurtid, false, false);
		});
	}

	// Token: 0x04011AD3 RID: 72403
	protected int[] hurtIdArr = new int[]
	{
		35041,
		35044
	};
}
