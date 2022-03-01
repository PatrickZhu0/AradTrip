using System;
using GameClient;

// Token: 0x02004296 RID: 17046
public class Mechanism1076 : BeMechanism
{
	// Token: 0x06017953 RID: 96595 RVA: 0x00742F32 File Offset: 0x00741332
	public Mechanism1076(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017954 RID: 96596 RVA: 0x00742F60 File Offset: 0x00741360
	public override void OnInit()
	{
		base.OnInit();
		this.buffIdArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffIdArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.maxNumArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.maxNumArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
	}

	// Token: 0x06017955 RID: 96597 RVA: 0x0074301C File Offset: 0x0074141C
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this.RegisterBuffAdd));
		this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, new BeEventHandle.Del(this.RegisterBuffRemove));
		this.handleC = base.owner.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.RegisterDead));
	}

	// Token: 0x06017956 RID: 96598 RVA: 0x0074308C File Offset: 0x0074148C
	public override void OnFinish()
	{
		base.OnFinish();
		this.HideBuffInfo();
	}

	// Token: 0x06017957 RID: 96599 RVA: 0x0074309C File Offset: 0x0074149C
	protected void RegisterBuffAdd(object[] args)
	{
		BeBuff beBuff = (BeBuff)args[0];
		if (beBuff == null)
		{
			return;
		}
		int buffIndex = this.GetBuffIndex(beBuff.buffID);
		if (buffIndex == -1)
		{
			return;
		}
		int buffCountByID = base.owner.buffController.GetBuffCountByID(beBuff.buffID);
		this.SetBuffInfo(buffIndex, buffCountByID, this.maxNumArr[0]);
	}

	// Token: 0x06017958 RID: 96600 RVA: 0x007430F8 File Offset: 0x007414F8
	protected void RegisterBuffRemove(object[] args)
	{
		int num = (int)args[0];
		int buffIndex = this.GetBuffIndex(num);
		if (buffIndex == -1)
		{
			return;
		}
		int buffCountByID = base.owner.buffController.GetBuffCountByID(num);
		this.SetBuffInfo(buffIndex, buffCountByID, this.maxNumArr[0]);
	}

	// Token: 0x06017959 RID: 96601 RVA: 0x00743140 File Offset: 0x00741540
	protected int GetBuffIndex(int buffId)
	{
		for (int i = 0; i < this.buffIdArr.Length; i++)
		{
			if (buffId == this.buffIdArr[i])
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x0601795A RID: 96602 RVA: 0x00743178 File Offset: 0x00741578
	private void SetBuffInfo(int index, int curNum, int maxNum)
	{
		this.RefreshEffect(index);
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetShengQiBeiDongBuff(index, curNum, maxNum);
			}
		}
	}

	// Token: 0x0601795B RID: 96603 RVA: 0x007431C8 File Offset: 0x007415C8
	private void HideBuffInfo()
	{
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetShengQiBeiDongBuff(0, 0, 0);
			}
		}
	}

	// Token: 0x0601795C RID: 96604 RVA: 0x00743210 File Offset: 0x00741610
	private void RefreshEffect(int index)
	{
		if (index == -1)
		{
			return;
		}
		if (this.m_EffectArr[index] == null)
		{
			string effectPath = (index != 0) ? "Effects/Hero_Paladin/Eff_Paladin_Juexing/Prefab/Eff_Paladin_Juexing_ShenPanYinJi" : "Effects/Hero_Paladin/Eff_Paladin_Juexing/Prefab/Eff_Paladin_Juexing_ZhuFuYinJi";
			GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(effectPath, "[actor]Orign", 1E+12f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.BUFF, false);
			if (geEffectEx != null)
			{
				this.m_EffectArr[index] = geEffectEx;
			}
		}
		for (int i = 0; i < this.m_EffectArr.Length; i++)
		{
			if (this.m_EffectArr[i] != null)
			{
				this.m_EffectArr[i].SetVisible(i == index);
			}
		}
	}

	// Token: 0x0601795D RID: 96605 RVA: 0x007432C2 File Offset: 0x007416C2
	protected void RegisterDead(object[] args)
	{
		base.owner.buffController.RemoveBuff(this.buffIdArr[0], 0, 0);
		base.owner.buffController.RemoveBuff(this.buffIdArr[1], 0, 0);
	}

	// Token: 0x04010F21 RID: 69409
	protected int[] buffIdArr = new int[2];

	// Token: 0x04010F22 RID: 69410
	protected int[] maxNumArr = new int[2];

	// Token: 0x04010F23 RID: 69411
	protected ClientFrame frame;

	// Token: 0x04010F24 RID: 69412
	protected GeEffectEx[] m_EffectArr = new GeEffectEx[2];
}
