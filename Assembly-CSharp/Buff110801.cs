using System;

// Token: 0x02004216 RID: 16918
public class Buff110801 : BeBuff
{
	// Token: 0x060176BE RID: 95934 RVA: 0x007322C0 File Offset: 0x007306C0
	public Buff110801(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176BF RID: 95935 RVA: 0x007322CE File Offset: 0x007306CE
	public override bool CanAdd(BeActor target)
	{
		return target.GetWeaponType() == this.weaponType;
	}

	// Token: 0x060176C0 RID: 95936 RVA: 0x007322DE File Offset: 0x007306DE
	public override void OnInit()
	{
		this.weaponType = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
	}

	// Token: 0x060176C1 RID: 95937 RVA: 0x00732308 File Offset: 0x00730708
	public override void OnStart()
	{
		this.RemoveHandler();
		this.handler = base.owner.RegisterEvent(BeEventType.onHitCritical, delegate(object[] args)
		{
			VInt3 vint = (VInt3)args[0];
			base.owner.CurrentBeScene.currentGeScene.CreateEffect("Effects/Hero_Manyou/Siwangzuolun/Prefab/Eff_Siwangzuolun_fire", 0f, vint.vec3, 1f, 1f, false, base.owner.GetFace());
		});
	}

	// Token: 0x060176C2 RID: 95938 RVA: 0x0073232F File Offset: 0x0073072F
	public override void OnFinish()
	{
		this.RemoveHandler();
	}

	// Token: 0x060176C3 RID: 95939 RVA: 0x00732337 File Offset: 0x00730737
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04010D11 RID: 68881
	private int weaponType;

	// Token: 0x04010D12 RID: 68882
	private BeEventHandle handler;
}
