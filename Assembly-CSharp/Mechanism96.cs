using System;
using GameClient;

// Token: 0x02004421 RID: 17441
public class Mechanism96 : BeMechanism
{
	// Token: 0x06018397 RID: 99223 RVA: 0x0078B49F File Offset: 0x0078989F
	public Mechanism96(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018398 RID: 99224 RVA: 0x0078B4AC File Offset: 0x007898AC
	public override void OnInit()
	{
		this.SkillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.weaponType = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06018399 RID: 99225 RVA: 0x0078B534 File Offset: 0x00789934
	public override void OnStart()
	{
		this.RemoveBuff();
		this.castSkillHandle = base.owner.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.SkillID)
			{
				this.RemoveBuff();
			}
		});
		this.switchWeaponHandle = base.owner.RegisterEvent(BeEventType.OnChangeWeapon, new BeEventHandle.Del(this.OnChangeWeapon));
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onChangeEquipEnd, new BeEvent.BeEventHandleNew.Function(this.OnChangeEquip));
	}

	// Token: 0x0601839A RID: 99226 RVA: 0x0078B5A4 File Offset: 0x007899A4
	protected void OnChangeWeapon(object[] args)
	{
		this.RemoveBuff();
	}

	// Token: 0x0601839B RID: 99227 RVA: 0x0078B5AC File Offset: 0x007899AC
	protected void OnChangeEquip(BeEvent.BeEventParam param)
	{
		this.RemoveBuff();
	}

	// Token: 0x0601839C RID: 99228 RVA: 0x0078B5B4 File Offset: 0x007899B4
	private void RemoveBuff()
	{
		if (this.weaponType != base.owner.GetWeaponType())
		{
			base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
		}
	}

	// Token: 0x0601839D RID: 99229 RVA: 0x0078B5E4 File Offset: 0x007899E4
	public override void OnFinish()
	{
		if (this.castSkillHandle != null)
		{
			this.castSkillHandle.Remove();
			this.castSkillHandle = null;
		}
		if (this.switchWeaponHandle != null)
		{
			this.switchWeaponHandle.Remove();
			this.switchWeaponHandle = null;
		}
	}

	// Token: 0x040117C9 RID: 71625
	private int SkillID;

	// Token: 0x040117CA RID: 71626
	private int buffID;

	// Token: 0x040117CB RID: 71627
	private int weaponType;

	// Token: 0x040117CC RID: 71628
	private BeEventHandle castSkillHandle;

	// Token: 0x040117CD RID: 71629
	private BeEventHandle switchWeaponHandle;
}
