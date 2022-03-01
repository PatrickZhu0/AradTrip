using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020042F5 RID: 17141
public class Mechanism1191 : BeMechanism
{
	// Token: 0x06017B7F RID: 97151 RVA: 0x0074FA34 File Offset: 0x0074DE34
	public Mechanism1191(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B80 RID: 97152 RVA: 0x0074FA54 File Offset: 0x0074DE54
	public override void OnInit()
	{
		base.OnInit();
		this._triggerType = (Mechanism1191.TriggerType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Length; i++)
		{
			this._selfAddBuffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Length; j++)
		{
			this._targetAddBuffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
	}

	// Token: 0x06017B81 RID: 97153 RVA: 0x0074FB2B File Offset: 0x0074DF2B
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x06017B82 RID: 97154 RVA: 0x0074FB39 File Offset: 0x0074DF39
	private void _RegisterEvent()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this._OnHurtEntity));
	}

	// Token: 0x06017B83 RID: 97155 RVA: 0x0074FB70 File Offset: 0x0074DF70
	private void _OnHurtEntity(BeEvent.BeEventParam param)
	{
		BeEntity beEntity = param.m_Obj as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		if (!base.owner.IsSameTopOwner(beEntity))
		{
			return;
		}
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beActor == null)
		{
			return;
		}
		EffectTable hurtData = param.m_Obj3 as EffectTable;
		this._FilterCheckCondition(beActor, hurtData);
	}

	// Token: 0x06017B84 RID: 97156 RVA: 0x0074FBCC File Offset: 0x0074DFCC
	private void _FilterCheckCondition(BeActor target, EffectTable hurtData)
	{
		Mechanism1191.TriggerType triggerType = this._triggerType;
		if (triggerType != Mechanism1191.TriggerType.None)
		{
			if (triggerType == Mechanism1191.TriggerType.BreakAction)
			{
				if (!base.owner.CheckCanBreakAction(target, hurtData))
				{
					return;
				}
			}
		}
		this.AddBuff(base.owner, this._selfAddBuffInfoIdList);
		this.AddBuff(target, this._targetAddBuffInfoIdList);
	}

	// Token: 0x06017B85 RID: 97157 RVA: 0x0074FC30 File Offset: 0x0074E030
	private void AddBuff(BeActor actor, List<int> buffInfoIdList)
	{
		for (int i = 0; i < buffInfoIdList.Count; i++)
		{
			BuffInfoData buffInfoData = new BuffInfoData(buffInfoIdList[i], this.level, 0);
			if (buffInfoData.condition <= BuffCondition.NONE)
			{
				actor.buffController.TryAddBuff(buffInfoData, base.owner, false, default(VRate), null);
			}
			else
			{
				actor.buffController.AddTriggerBuff(buffInfoData);
			}
		}
	}

	// Token: 0x040110AB RID: 69803
	private List<int> _selfAddBuffInfoIdList = new List<int>();

	// Token: 0x040110AC RID: 69804
	private List<int> _targetAddBuffInfoIdList = new List<int>();

	// Token: 0x040110AD RID: 69805
	private Mechanism1191.TriggerType _triggerType;

	// Token: 0x020042F6 RID: 17142
	private enum TriggerType
	{
		// Token: 0x040110AF RID: 69807
		None,
		// Token: 0x040110B0 RID: 69808
		BreakAction
	}
}
