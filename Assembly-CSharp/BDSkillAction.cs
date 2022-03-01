using System;

// Token: 0x02004102 RID: 16642
public class BDSkillAction : BDEventBase
{
	// Token: 0x06016A73 RID: 92787 RVA: 0x006DDA83 File Offset: 0x006DBE83
	public BDSkillAction(BeActionType type, float dur, float scale, VInt3 pos, bool ignoreBlock = true)
	{
		this.actionType = type;
		this.duration = dur;
		this.deltaScale = scale;
		this.deltaPos = pos;
		this.ignoreBlock = ignoreBlock;
	}

	// Token: 0x06016A74 RID: 92788 RVA: 0x006DDAB0 File Offset: 0x006DBEB0
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		if (this.actionType == BeActionType.MoveBy)
		{
			VInt3 vint = this.deltaPos;
			vint.x *= pkEntity._getFaceCoff();
			pkEntity.SaveCurrentPosition();
			pkEntity.actionManager.RunAction(BeMoveBy.Create(pkEntity, IntMath.Float2Int(this.duration * (float)GlobalLogic.VALUE_1000), pkEntity.GetPosition(), vint, this.ignoreBlock, null, false));
		}
		else if (this.actionType == BeActionType.ScaleBy)
		{
			pkEntity.actionManager.RunAction(BeScaleBy.Create(pkEntity, IntMath.Float2Int(this.duration * (float)GlobalLogic.VALUE_1000), pkEntity.GetScale(), (VInt)this.deltaScale));
		}
		else if (this.actionType == BeActionType.MoveToSavedPosition)
		{
			pkEntity.actionManager.RunAction(BeMoveTo.Create(pkEntity, IntMath.Float2Int(this.duration * (float)GlobalLogic.VALUE_1000), pkEntity.GetPosition(), pkEntity.savedPosition, this.ignoreBlock, null, false));
		}
		else if (this.actionType == BeActionType.MoveTo)
		{
			VInt3 toPos = this.deltaPos;
			toPos.x *= pkEntity._getFaceCoff();
			pkEntity.actionManager.RunAction(BeMoveTo.Create(pkEntity, IntMath.Float2Int(this.duration * (float)GlobalLogic.VALUE_1000), pkEntity.GetPosition(), toPos, this.ignoreBlock, null, false));
		}
		else if (this.actionType == BeActionType.ScaleTo)
		{
			pkEntity.actionManager.RunAction(BeScaleTo.Create(pkEntity, IntMath.Float2Int(this.duration * (float)GlobalLogic.VALUE_1000), pkEntity.GetScale(), (VInt)this.deltaScale));
		}
	}

	// Token: 0x04010261 RID: 66145
	public BeActionType actionType;

	// Token: 0x04010262 RID: 66146
	public float duration;

	// Token: 0x04010263 RID: 66147
	public float deltaScale;

	// Token: 0x04010264 RID: 66148
	public VInt3 deltaPos;

	// Token: 0x04010265 RID: 66149
	public bool ignoreBlock;
}
