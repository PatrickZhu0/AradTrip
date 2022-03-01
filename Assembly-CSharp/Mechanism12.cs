using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020042FB RID: 17147
public class Mechanism12 : BeMechanism
{
	// Token: 0x06017B9F RID: 97183 RVA: 0x00750973 File Offset: 0x0074ED73
	public Mechanism12(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BA0 RID: 97184 RVA: 0x007509B0 File Offset: 0x0074EDB0
	public override void OnInit()
	{
		this.telType = (TeleportType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.telType > TeleportType.TARGET)
		{
			this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		this.offset = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		if (this.data.ValueC.Count > 1)
		{
			this.offsetY = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true), GlobalLogic.VALUE_1000);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.isGoBack = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) > 0);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.delay = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (this.data.ValueF.Count > 0)
		{
			this.isYChange = (TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true) == 0);
		}
		this.height = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true), GlobalLogic.VALUE_1000);
		this.m_UseOffsetByPos = (TableManager.GetValueFromUnionCell(this.data.ValueH[0], this.level, true) == 0);
	}

	// Token: 0x06017BA1 RID: 97185 RVA: 0x00750BC4 File Offset: 0x0074EFC4
	public override void OnStart()
	{
		Mechanism12.<OnStart>c__AnonStorey0 <OnStart>c__AnonStorey = new Mechanism12.<OnStart>c__AnonStorey0();
		<OnStart>c__AnonStorey.$this = this;
		VInt3 position = base.owner.GetPosition();
		<OnStart>c__AnonStorey.targetPos = position;
		if (this.telType == TeleportType.TARGET)
		{
			if (base.owner.aiManager.aiTarget != null)
			{
				<OnStart>c__AnonStorey.targetPos = base.owner.aiManager.aiTarget.GetPosition();
				if (this.isGoBack)
				{
					base.owner.SaveCurrentPosition();
				}
			}
		}
		else if (this.telType == TeleportType.MONSTERID)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
			if (list.Count > 0 && list[0] != null)
			{
				<OnStart>c__AnonStorey.targetPos = list[0].GetPosition();
			}
			ListPool<BeActor>.Release(list);
		}
		else if (this.telType == TeleportType.MONSTERID_TARGET)
		{
			List<BeActor> list2 = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindMonsterByID(list2, this.monsterID, true);
			if (list2.Count > 0 && list2[0] != null && list2[0].aiManager.aiTarget != null)
			{
				<OnStart>c__AnonStorey.targetPos = list2[0].aiManager.aiTarget.GetPosition();
			}
			ListPool<BeActor>.Release(list2);
		}
		else if (this.telType == TeleportType.SCENE_CENTER)
		{
			if (base.owner.aiManager.aiTarget != null)
			{
				<OnStart>c__AnonStorey.targetPos = base.owner.CurrentBeScene.GetSceneCenterPosition();
			}
		}
		else if (this.telType == TeleportType.ENTITYID)
		{
			BeEntity entityByResId = base.owner.CurrentBeScene.GetEntityByResId(this.monsterID, base.owner);
			if (entityByResId != null && !entityByResId.IsDead())
			{
				<OnStart>c__AnonStorey.targetPos = entityByResId.GetPosition();
			}
		}
		else if (this.telType == TeleportType.RANDOM_SCENE)
		{
			<OnStart>c__AnonStorey.targetPos = base.owner.CurrentBeScene.GetRandomPos(20);
			if (base.owner.CurrentBeScene.IsInBlockPlayer(<OnStart>c__AnonStorey.targetPos))
			{
				<OnStart>c__AnonStorey.targetPos = base.owner.CurrentBeScene.GetSceneCenterPosition();
			}
		}
		if (this.m_UseOffsetByPos)
		{
			if (position.x > <OnStart>c__AnonStorey.targetPos.x)
			{
				Mechanism12.<OnStart>c__AnonStorey0 <OnStart>c__AnonStorey2 = <OnStart>c__AnonStorey;
				<OnStart>c__AnonStorey2.targetPos.x = <OnStart>c__AnonStorey2.targetPos.x + this.offset.i;
				base.owner.SetFace(true, false, false);
			}
			else if (position.x < <OnStart>c__AnonStorey.targetPos.x)
			{
				Mechanism12.<OnStart>c__AnonStorey0 <OnStart>c__AnonStorey3 = <OnStart>c__AnonStorey;
				<OnStart>c__AnonStorey3.targetPos.x = <OnStart>c__AnonStorey3.targetPos.x - this.offset.i;
				base.owner.SetFace(false, false, false);
			}
		}
		else
		{
			Mechanism12.<OnStart>c__AnonStorey0 <OnStart>c__AnonStorey4 = <OnStart>c__AnonStorey;
			<OnStart>c__AnonStorey4.targetPos.x = <OnStart>c__AnonStorey4.targetPos.x + this.offset.i;
			if (this.offset.i > 0)
			{
				base.owner.SetFace(true, false, false);
			}
			else
			{
				base.owner.SetFace(false, false, false);
			}
		}
		Mechanism12.<OnStart>c__AnonStorey0 <OnStart>c__AnonStorey5 = <OnStart>c__AnonStorey;
		<OnStart>c__AnonStorey5.targetPos.y = <OnStart>c__AnonStorey5.targetPos.y + this.offsetY.i;
		if (!this.isYChange)
		{
			<OnStart>c__AnonStorey.targetPos.z = position.z;
		}
		if (this.height != 0)
		{
			<OnStart>c__AnonStorey.targetPos.z = this.height.i;
		}
		if (this.delay > 0)
		{
			base.owner.delayCaller.DelayCall(this.delay, delegate
			{
				<OnStart>c__AnonStorey.$this._moveToTargetPos(<OnStart>c__AnonStorey.targetPos);
			}, 0, 0, false);
		}
		else
		{
			this._moveToTargetPos(<OnStart>c__AnonStorey.targetPos);
		}
	}

	// Token: 0x06017BA2 RID: 97186 RVA: 0x00750F94 File Offset: 0x0074F394
	private void _moveToTargetPos(VInt3 targetPos)
	{
		if (base.owner != null && !base.owner.IsDead())
		{
			if (this.telType == TeleportType.SCENE_CENTER)
			{
				base.owner.SetPosition(targetPos, false, true, false);
			}
			else
			{
				VInt3 rkPos = BeAIManager.FindStandPositionNew(targetPos, base.owner.CurrentBeScene, base.owner.GetFace(), false, 30);
				if (!this.isYChange)
				{
					rkPos.z = targetPos.z;
				}
				base.owner.SetPosition(rkPos, false, true, false);
			}
		}
	}

	// Token: 0x06017BA3 RID: 97187 RVA: 0x00751024 File Offset: 0x0074F424
	public override void OnFinish()
	{
		if (this.isGoBack)
		{
			if (base.owner != null && !base.owner.IsDead())
			{
				base.owner.SetPosition(base.owner.savedPosition, false, true, false);
			}
			this.isGoBack = false;
		}
	}

	// Token: 0x040110CF RID: 69839
	private TeleportType telType;

	// Token: 0x040110D0 RID: 69840
	private int monsterID;

	// Token: 0x040110D1 RID: 69841
	private VInt offset = 0;

	// Token: 0x040110D2 RID: 69842
	private VInt offsetY = 0;

	// Token: 0x040110D3 RID: 69843
	private bool isGoBack;

	// Token: 0x040110D4 RID: 69844
	private int delay;

	// Token: 0x040110D5 RID: 69845
	private bool isYChange = true;

	// Token: 0x040110D6 RID: 69846
	private VInt height = VInt.zero;

	// Token: 0x040110D7 RID: 69847
	protected bool m_UseOffsetByPos = true;
}
