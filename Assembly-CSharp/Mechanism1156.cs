using System;
using GameClient;

// Token: 0x020042CC RID: 17100
public class Mechanism1156 : BeMechanism
{
	// Token: 0x06017A9A RID: 96922 RVA: 0x0074AC8B File Offset: 0x0074908B
	public Mechanism1156(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A9B RID: 96923 RVA: 0x0074AC98 File Offset: 0x00749098
	public override void OnInit()
	{
		base.OnInit();
		this._magicElementType = (MagicElementType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._compareType = (CompareType)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._compareValue = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this._buffAddIsSelf = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 0);
		this._buffId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this._criticalBuffId = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this._buffTime = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
	}

	// Token: 0x06017A9C RID: 96924 RVA: 0x0074ADCF File Offset: 0x007491CF
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x06017A9D RID: 96925 RVA: 0x0074ADE0 File Offset: 0x007491E0
	private void _RegisterEvent()
	{
		if (this._buffId > 0)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this._OnBeforeHit));
		}
		if (this._criticalBuffId > 0 && base.owner.CurrentBeScene != null)
		{
			this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this._OnHurtEntity));
		}
	}

	// Token: 0x06017A9E RID: 96926 RVA: 0x0074AE58 File Offset: 0x00749258
	private void _OnBeforeHit(object[] args)
	{
		if (this._buffId <= 0)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!this._CompareValue(beActor))
		{
			return;
		}
		int buffDuration = (this._buffTime != 0) ? this._buffTime : 33;
		if (this._buffAddIsSelf)
		{
			base.owner.buffController.TryAddBuff(this._buffId, buffDuration, 1);
		}
		else
		{
			beActor.buffController.TryAddBuff(this._buffId, buffDuration, 1);
		}
	}

	// Token: 0x06017A9F RID: 96927 RVA: 0x0074AEE8 File Offset: 0x007492E8
	private void _OnHurtEntity(BeEvent.BeEventParam param)
	{
		if (this._criticalBuffId <= 0)
		{
			return;
		}
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beActor == null)
		{
			return;
		}
		BeEntity beEntity = param.m_Obj as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		beEntity = beEntity.GetTopOwner(beEntity);
		if (beEntity == null || beEntity != base.owner)
		{
			return;
		}
		if (!this._CompareValue(beActor))
		{
			return;
		}
		if (this._buffAddIsSelf)
		{
			base.owner.buffController.TryAddBuff(this._criticalBuffId, 33, 1);
		}
		else
		{
			beActor.buffController.TryAddBuff(this._criticalBuffId, 33, 1);
		}
	}

	// Token: 0x06017AA0 RID: 96928 RVA: 0x0074AF90 File Offset: 0x00749390
	private bool _CompareValue(BeActor target)
	{
		if (base.owner.attribute == null || base.owner.attribute.battleData == null)
		{
			return false;
		}
		CrypticInt32 inData = base.owner.attribute.battleData.magicElementsAttack[(int)this._magicElementType];
		CrypticInt32 inData2 = target.attribute.battleData.magicElementsDefence[(int)this._magicElementType];
		bool result = false;
		CompareType compareType = this._compareType;
		if (compareType != CompareType.Equal)
		{
			if (compareType != CompareType.GreaterThan)
			{
				if (compareType == CompareType.LessThan)
				{
					result = (inData - inData2 < this._compareValue);
				}
			}
			else
			{
				result = (inData - inData2 > this._compareValue);
			}
		}
		else
		{
			result = (inData - inData2 == this._compareValue);
		}
		return result;
	}

	// Token: 0x0401100F RID: 69647
	private MagicElementType _magicElementType;

	// Token: 0x04011010 RID: 69648
	private CompareType _compareType;

	// Token: 0x04011011 RID: 69649
	private int _compareValue;

	// Token: 0x04011012 RID: 69650
	private bool _buffAddIsSelf;

	// Token: 0x04011013 RID: 69651
	private int _buffId;

	// Token: 0x04011014 RID: 69652
	private int _criticalBuffId;

	// Token: 0x04011015 RID: 69653
	private int _buffTime;
}
