using System;

// Token: 0x020042F0 RID: 17136
public class Mechanism1187 : BeMechanism
{
	// Token: 0x06017B5E RID: 97118 RVA: 0x0074EF33 File Offset: 0x0074D333
	public Mechanism1187(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B5F RID: 97119 RVA: 0x0074EF40 File Offset: 0x0074D340
	public override void OnInit()
	{
		this.mMonsterID = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true) : TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true));
		this.mBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017B60 RID: 97120 RVA: 0x0074EFD4 File Offset: 0x0074D3D4
	public override void OnStart()
	{
		this._RegistEvent();
	}

	// Token: 0x06017B61 RID: 97121 RVA: 0x0074EFDC File Offset: 0x0074D3DC
	private void _RegistEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this.OnTargetMonsterSummon));
	}

	// Token: 0x06017B62 RID: 97122 RVA: 0x0074F000 File Offset: 0x0074D400
	private void OnTargetMonsterSummon(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null || beActor.GetEntityData() == null || !beActor.GetEntityData().MonsterIDEqual(this.mMonsterID))
		{
			return;
		}
		if (beActor.buffController != null)
		{
			BuffInfoData buffInfoData = new BuffInfoData(this.mBuffInfoID, beActor.GetEntityData().level, 0);
			if (buffInfoData.condition <= BuffCondition.NONE)
			{
				beActor.buffController.TriggerBuffInfo(buffInfoData, null, null);
			}
			else
			{
				beActor.buffController.AddTriggerBuff(buffInfoData);
			}
		}
	}

	// Token: 0x04011098 RID: 69784
	protected int mMonsterID;

	// Token: 0x04011099 RID: 69785
	protected int mBuffInfoID;
}
