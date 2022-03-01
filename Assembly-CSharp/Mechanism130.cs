using System;
using UnityEngine;

// Token: 0x02004307 RID: 17159
public class Mechanism130 : BeMechanism
{
	// Token: 0x06017BD2 RID: 97234 RVA: 0x00752219 File Offset: 0x00750619
	public Mechanism130(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BD3 RID: 97235 RVA: 0x00752224 File Offset: 0x00750624
	public override void OnInit()
	{
		base.OnInit();
		this.absorbDamageRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.absorbDamageMax = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017BD4 RID: 97236 RVA: 0x007522AF File Offset: 0x007506AF
	public override void OnStart()
	{
		base.OnStart();
		this.curDamage = 0;
		this.StartEnergyUI(this.absorbDamageMax);
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeHurtValue, delegate(object[] args)
		{
			int[] hurtValueArr = (int[])args[0];
			this.ChangeHurtValue(hurtValueArr);
		});
	}

	// Token: 0x06017BD5 RID: 97237 RVA: 0x007522EC File Offset: 0x007506EC
	protected void ChangeHurtValue(int[] hurtValueArr)
	{
		VFactor f = new VFactor((long)this.absorbDamageRate, (long)GlobalLogic.VALUE_1000);
		int num = hurtValueArr[0] * f;
		if (this.curDamage + num >= this.absorbDamageMax)
		{
			num = this.absorbDamageMax - this.curDamage;
			base.owner.buffController.RemoveBuff(this.buffId, 0, 0);
		}
		hurtValueArr[0] -= num;
		this.curDamage += num;
		this.RefreshEnergrUI(this.absorbDamageMax - this.curDamage);
	}

	// Token: 0x06017BD6 RID: 97238 RVA: 0x0075237D File Offset: 0x0075077D
	public override void OnFinish()
	{
		base.OnFinish();
		this.StopEnergyUI();
	}

	// Token: 0x06017BD7 RID: 97239 RVA: 0x0075238C File Offset: 0x0075078C
	protected void StartEnergyUI(int maxValue)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorHeadEnergy", true, 0U);
		this.energyBar = gameObject.GetComponent<ComDungeonCharactorBarEnergy>();
		base.owner.m_pkGeActor.CreateBarRoot();
		GameObject hRoot = base.owner.m_pkGeActor.mBarsRoot.hRoot;
		Utility.AttachTo(gameObject, hRoot, false);
		this.energyBar.InitData((float)maxValue);
	}

	// Token: 0x06017BD8 RID: 97240 RVA: 0x007523F2 File Offset: 0x007507F2
	protected void RefreshEnergrUI(int value)
	{
		if (this.energyBar == null)
		{
			return;
		}
		this.energyBar.RefreshData((float)value);
	}

	// Token: 0x06017BD9 RID: 97241 RVA: 0x00752414 File Offset: 0x00750814
	protected void StopEnergyUI()
	{
		if (this.energyBar == null)
		{
			return;
		}
		GameObject gameObject = this.energyBar.GetGameObject();
		Object.Destroy(gameObject);
	}

	// Token: 0x04011107 RID: 69895
	protected int absorbDamageRate;

	// Token: 0x04011108 RID: 69896
	protected int absorbDamageMax;

	// Token: 0x04011109 RID: 69897
	protected int buffId;

	// Token: 0x0401110A RID: 69898
	protected int curDamage;

	// Token: 0x0401110B RID: 69899
	protected ComDungeonCharactorBarEnergy energyBar;
}
