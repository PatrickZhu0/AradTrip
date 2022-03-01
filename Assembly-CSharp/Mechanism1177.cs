using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020042E4 RID: 17124
public class Mechanism1177 : BeMechanism
{
	// Token: 0x06017B20 RID: 97056 RVA: 0x0074D650 File Offset: 0x0074BA50
	public Mechanism1177(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B21 RID: 97057 RVA: 0x0074D6B8 File Offset: 0x0074BAB8
	public override void OnInit()
	{
		this.mSummonHurtID.Clear();
		this.mMonsterID.Clear();
		for (int i = 0; i < this.data.ValueALength; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(valueFromUnionCell, string.Empty, string.Empty);
			if (!this.mSummonHurtID.ContainsKey(valueFromUnionCell))
			{
				this.mSummonHurtID.Add(valueFromUnionCell, tableItem);
			}
		}
		this.summonTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.checkDis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		this.forceZHeight = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
		for (int j = 0; j < this.data.ValueELength; j++)
		{
			this.mMonsterID.Add(TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true));
		}
	}

	// Token: 0x06017B22 RID: 97058 RVA: 0x0074D824 File Offset: 0x0074BC24
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleNewA = base.owner.RegisterEventNew(BeEventType.onBeforeSummon, new BeEvent.BeEventHandleNew.Function(this.OnBeforeSummonEvent));
			this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this.OnSummonEvent));
		}
		base.InitTimeAcc(this.summonTimeAcc);
	}

	// Token: 0x06017B23 RID: 97059 RVA: 0x0074D886 File Offset: 0x0074BC86
	public override void OnUpdateTimeAcc()
	{
		this.TrySummon();
	}

	// Token: 0x06017B24 RID: 97060 RVA: 0x0074D88E File Offset: 0x0074BC8E
	public override void OnFinish()
	{
		this.mSummonHurtID.Clear();
		this.mMonsterID.Clear();
	}

	// Token: 0x06017B25 RID: 97061 RVA: 0x0074D8A8 File Offset: 0x0074BCA8
	private void TrySummon()
	{
		foreach (KeyValuePair<int, EffectTable> keyValuePair in this.mSummonHurtID)
		{
			EffectTable value = keyValuePair.Value;
			if (value != null)
			{
				base.owner.TrySummon(value);
			}
		}
	}

	// Token: 0x06017B26 RID: 97062 RVA: 0x0074D8F8 File Offset: 0x0074BCF8
	private bool CheckDis(VInt3 targetPos)
	{
		foreach (KeyValuePair<int, VInt3> keyValuePair in this.entityDataDic)
		{
			VInt3 value = keyValuePair.Value;
			if ((value - targetPos).magnitude < this.checkDis)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06017B27 RID: 97063 RVA: 0x0074D95C File Offset: 0x0074BD5C
	private void OnBeforeSummonEvent(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int2;
		if (!BeUtility.IsMonsterIDEqualList(this.mMonsterID, @int))
		{
			return;
		}
		int num = 0;
		do
		{
			num++;
			VInt3 vint = VInt3.zero;
			if (base.owner.CurrentBeScene != null)
			{
				vint = base.owner.CurrentBeScene.GetRandomPos(20);
			}
			if (this.CheckDis(vint))
			{
				if (this.forceZHeight != 0)
				{
					vint.z = this.forceZHeight.i;
				}
				param.m_Vint3 = vint;
			}
		}
		while (num < this.whileCount);
	}

	// Token: 0x06017B28 RID: 97064 RVA: 0x0074D9F8 File Offset: 0x0074BDF8
	private void OnSummonEvent(object[] args)
	{
		if (args.Length == 0)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!BeUtility.IsMonsterIDEqualList(this.mMonsterID, beActor.GetEntityData().monsterID))
		{
			return;
		}
		this.entityDataDic.Add(beActor.GetPID(), beActor.GetPosition());
		beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnMonsterDead));
	}

	// Token: 0x06017B29 RID: 97065 RVA: 0x0074DA68 File Offset: 0x0074BE68
	private void OnMonsterDead(object[] args)
	{
		if (args.Length < 3)
		{
			return;
		}
		BeActor beActor = args[2] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (this.entityDataDic.ContainsKey(beActor.GetPID()))
		{
			this.entityDataDic.Remove(beActor.GetPID());
		}
	}

	// Token: 0x04011069 RID: 69737
	private int summonTimeAcc = 2000;

	// Token: 0x0401106A RID: 69738
	private VInt checkDis = 10000;

	// Token: 0x0401106B RID: 69739
	private int whileCount = 100;

	// Token: 0x0401106C RID: 69740
	private VInt forceZHeight = 0;

	// Token: 0x0401106D RID: 69741
	private Dictionary<int, EffectTable> mSummonHurtID = new Dictionary<int, EffectTable>();

	// Token: 0x0401106E RID: 69742
	private Dictionary<int, VInt3> entityDataDic = new Dictionary<int, VInt3>();

	// Token: 0x0401106F RID: 69743
	private List<int> mMonsterID = new List<int>();
}
