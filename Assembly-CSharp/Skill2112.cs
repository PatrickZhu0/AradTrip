using System;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x0200448A RID: 17546
public class Skill2112 : BeSkill
{
	// Token: 0x06018639 RID: 99897 RVA: 0x007997BF File Offset: 0x00797BBF
	public Skill2112(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601863A RID: 99898 RVA: 0x007997E0 File Offset: 0x00797BE0
	public override void OnInit()
	{
		int count = this.skillData.ValueA.Count;
		this.ids = new int[this.skillData.ValueA.Count];
		for (int i = 0; i < count; i++)
		{
			this.ids[i] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
		}
		this.distancex = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true), 1000);
		this.distancey = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true), 1000);
		this.effectIDFriend = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.effectIDSummon = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
		this.effectPath = "Effects/Hero_Mage/Caoren/Prefab/Eff_Jiekebaodan_yan";
		this.isCreatePoppet = true;
	}

	// Token: 0x0601863B RID: 99899 RVA: 0x00799904 File Offset: 0x00797D04
	public override void OnPostInit()
	{
		if (this.m_BtnRestoreHandle != null)
		{
			this.m_BtnRestoreHandle.Remove();
		}
		if (base.owner != null)
		{
			this.m_BtnRestoreHandle = base.owner.RegisterEvent(BeEventType.onMechanism2050RestoreBtn, new BeEventHandle.Del(this.OnBtnRestore));
		}
	}

	// Token: 0x0601863C RID: 99900 RVA: 0x00799954 File Offset: 0x00797D54
	public override void OnStart()
	{
		base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath, 0f, base.owner.GetPosition().vec3, 1f, 1f, false, false);
		VInt3 position = base.owner.GetPosition();
		position.z = Mathf.Max(position.z, VInt.Float2VIntValue(1.5f));
		if (this.isCreatePoppet)
		{
			this.CreatePoppet(position);
		}
		if (base.owner.IsInMoveDirection())
		{
			BeAIManager.MoveDir dir = InputManager.MoveDir2ToMoveDir(InputManager.GetDir8((int)(base.owner.MoveDirectionDegree() * 15)));
			this.ChangePositionWithManual(dir);
		}
		else
		{
			BeAIManager.MoveDir d = (BeAIManager.MoveDir)base.FrameRandom.InRange(0, 8);
			this.ChangePosition(d);
		}
	}

	// Token: 0x0601863D RID: 99901 RVA: 0x00799A28 File Offset: 0x00797E28
	private void ChangePositionWithManual(BeAIManager.MoveDir dir)
	{
		VInt3 position = base.owner.GetPosition();
		position.x += BeAIManager.DIR_VALUE2[(int)dir, 0] * this.distancex.i;
		position.y += BeAIManager.DIR_VALUE2[(int)dir, 1] * this.distancey.i;
		position.z = 0;
		DGrid grid = this.TestDestination(base.owner.GetPosition(), position, dir, Mathf.Max(this.distancex.i / BeAIWalkCommand.grid.x, this.distancey.i / BeAIWalkCommand.grid.y));
		VInt3 rkPos = base.owner.CurrentBeScene.CalPositionByGrid(grid);
		base.owner.SetPosition(rkPos, false, true, false);
		base.owner.ClearMoveSpeed(7);
	}

	// Token: 0x0601863E RID: 99902 RVA: 0x00799B10 File Offset: 0x00797F10
	private void ChangePosition(BeAIManager.MoveDir d)
	{
		VInt3 position = base.owner.GetPosition();
		position.x += BeAIManager.DIR_VALUE2[(int)d, 0] * this.distancex.i;
		position.y += BeAIManager.DIR_VALUE2[(int)d, 1] * this.distancey.i;
		position.z = 0;
		base.owner.GetPosition().z = 0;
		BeActor beActor = base.owner.CurrentBeScene.FindTarget(base.owner, VInt.one.i * 20);
		if (beActor == null)
		{
			beActor = base.owner;
		}
		VInt3 destination = this.GetDestination(base.owner.GetPosition(), this.distancex, this.distancey, beActor);
		base.owner.SetPosition(destination, false, true, false);
		base.owner.ClearMoveSpeed(7);
	}

	// Token: 0x0601863F RID: 99903 RVA: 0x00799C08 File Offset: 0x00798008
	private VInt3 GetDestination(VInt3 start, VInt dx, VInt dy, BeEntity target)
	{
		VInt3 position = target.GetPosition();
		position.z = 0;
		start.z = 0;
		VInt3 result = VInt3.zero;
		int num = -1;
		for (int i = 0; i < 8; i++)
		{
			VInt3 dest = start;
			dest.x += BeAIManager.DIR_VALUE2[i, 0] * dx.i;
			dest.y += BeAIManager.DIR_VALUE2[i, 0] * dy.i;
			dest.z = 0;
			DGrid grid = this.TestDestination(start, dest, (BeAIManager.MoveDir)i, Mathf.Max(this.distancex.i / BeAIWalkCommand.grid.x, this.distancey.i / BeAIWalkCommand.grid.y));
			VInt3 vint = base.owner.CurrentBeScene.CalPositionByGrid(grid);
			int magnitude = (position - vint).magnitude;
			if (magnitude > num)
			{
				num = magnitude;
				result = vint;
			}
		}
		return result;
	}

	// Token: 0x06018640 RID: 99904 RVA: 0x00799D14 File Offset: 0x00798114
	private void CreatePoppet(VInt3 pos)
	{
		BeObject obj = base.owner.CurrentBeScene.AddLogicObject(this.ids[base.FrameRandom.InRange(0, 3)], base.owner.m_iCamp);
		obj.SetPosition(pos, false, true, false);
		BeEventHandle handler = null;
		handler = obj.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			obj.ForceDoDead();
			BeActor beActor = args[0] as BeActor;
			if (beActor != null)
			{
				if (beActor.GetEntityData().isSummonMonster)
				{
					this.AddBuff(beActor, this.effectIDSummon);
				}
				else
				{
					this.AddBuff(beActor, this.effectIDFriend);
				}
			}
			handler.Remove();
		});
	}

	// Token: 0x06018641 RID: 99905 RVA: 0x00799D98 File Offset: 0x00798198
	private new void AddBuff(BeActor target, int effectID)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(effectID, string.Empty, string.Empty);
		if (tableItem != null && tableItem.BuffID > 0)
		{
			int level = base.level;
			int valueFromUnionCell;
			if (BattleMain.IsChijiNeedReplaceHurtId(effectID, base.battleType))
			{
				ChijiEffectMapTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(effectID, string.Empty, string.Empty);
				valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem2.AttachBuffTime, level, true);
			}
			else
			{
				valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem.AttachBuffTime, level, true);
			}
			target.buffController.TryAddBuff(tableItem.BuffID, valueFromUnionCell, level);
		}
	}

	// Token: 0x06018642 RID: 99906 RVA: 0x00799E32 File Offset: 0x00798232
	public override bool CanUseSkill()
	{
		return base.CanUseSkill() && this.CheckSpellCondition((ActionState)base.owner.sgGetCurrentState()) && !this.HaveBuff();
	}

	// Token: 0x06018643 RID: 99907 RVA: 0x00799E64 File Offset: 0x00798264
	public override bool CheckSpellCondition(ActionState state)
	{
		bool flag = base.owner.stateController.HasBuffState(BeBuffStateType.FROZEN) || base.owner.stateController.HasBuffState(BeBuffStateType.STUN) || base.owner.stateController.HasBuffState(BeBuffStateType.STONE) || base.owner.stateController.HasBuffState(BeBuffStateType.SLEEP) || base.owner.stateController.HasBuffState(BeBuffStateType.STRAIN);
		return base.owner.sgGetCurrentState() != 15 && base.owner.sgGetCurrentState() != 14 && base.owner.sgGetCurrentState() != 18 && base.owner.sgGetCurrentState() != 6 && base.owner.sgGetCurrentState() != 19 && !flag && base.owner.IsInPassiveState() && !base.owner.stateController.WillBeGrab();
	}

	// Token: 0x06018644 RID: 99908 RVA: 0x00799F80 File Offset: 0x00798380
	private bool HaveBuff()
	{
		BeBuff beBuff = base.owner.buffController.GetBuffList().Find((BeBuff x) => x.buffID == 370500 || x.buffID == 370501);
		return beBuff != null;
	}

	// Token: 0x06018645 RID: 99909 RVA: 0x00799FC8 File Offset: 0x007983C8
	private DGrid TestDestination(VInt3 start, VInt3 dest, BeAIManager.MoveDir dir, int maxStep)
	{
		DGrid dgrid = base.owner.CurrentBeScene.CalGridByPosition(start);
		DGrid dgrid2 = base.owner.CurrentBeScene.CalGridByPosition(dest);
		byte[] mBlockInfo = base.owner.CurrentBeScene.mBlockInfo;
		int logicX = base.owner.CurrentBeScene.sceneData.GetLogicX();
		int logicZ = base.owner.CurrentBeScene.sceneData.GetLogicZ();
		dgrid2.x = Mathf.Clamp(dgrid2.x, 0, logicX - 1);
		dgrid2.y = Mathf.Clamp(dgrid2.y, 0, logicZ - 1);
		DGrid result = dgrid;
		int num = 1;
		for (;;)
		{
			int num2 = dgrid.x + BeAIManager.DIR_VALUE2[(int)dir, 0] * num;
			int num3 = dgrid.y + BeAIManager.DIR_VALUE2[(int)dir, 1] * num;
			num++;
			if (num2 < 0 || num2 >= logicX || num3 < 0 || num3 >= logicZ || mBlockInfo[num3 * logicX + num2] != 0 || num > maxStep)
			{
				break;
			}
			DGrid dgrid3 = new DGrid(num2, num3);
			VInt3 position = base.owner.CurrentBeScene.CalPositionByGrid(dgrid3);
			if (!base.owner.CurrentBeScene.IsInBlockPlayer(position))
			{
				result = dgrid3;
				if (num2 == dgrid2.x && num3 == dgrid2.y)
				{
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06018646 RID: 99910 RVA: 0x0079A148 File Offset: 0x00798548
	public override void OnFinish()
	{
		base.OnFinish();
		this.ClearProtectData();
	}

	// Token: 0x06018647 RID: 99911 RVA: 0x0079A158 File Offset: 0x00798558
	protected void ClearProtectData()
	{
		if (base.owner.CurrentBeBattle == null)
		{
			return;
		}
		if (base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.Skill2112Protect))
		{
			return;
		}
		if (!base.owner.HasTag(4) && !base.owner.HasTag(1))
		{
			return;
		}
		base.owner.protectManager.ClearGroundProtect();
		base.owner.protectManager.DelayClearFallProtect();
	}

	// Token: 0x06018648 RID: 99912 RVA: 0x0079A1D8 File Offset: 0x007985D8
	private void OnBtnRestore(object[] args)
	{
		bool flag = base.owner.CanUseSkill(this.skillID);
		if (base.button != null && base.button.gameObject.activeInHierarchy != flag)
		{
			base.button.gameObject.CustomActive(flag);
		}
	}

	// Token: 0x0401199A RID: 72090
	protected string effectPath;

	// Token: 0x0401199B RID: 72091
	protected VInt distancex = VInt.zero;

	// Token: 0x0401199C RID: 72092
	protected VInt distancey = VInt.zero;

	// Token: 0x0401199D RID: 72093
	protected bool isCreatePoppet;

	// Token: 0x0401199E RID: 72094
	private int effectIDFriend;

	// Token: 0x0401199F RID: 72095
	private int effectIDSummon;

	// Token: 0x040119A0 RID: 72096
	private int[] ids;

	// Token: 0x040119A1 RID: 72097
	private BeEventHandle m_BtnRestoreHandle;
}
