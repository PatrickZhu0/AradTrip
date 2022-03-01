using System;
using GameClient;
using ProtoTable;

// Token: 0x020042DB RID: 17115
public class Mechanism1166 : BeMechanism
{
	// Token: 0x06017AEE RID: 97006 RVA: 0x0074C791 File Offset: 0x0074AB91
	public Mechanism1166(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017AEF RID: 97007 RVA: 0x0074C79B File Offset: 0x0074AB9B
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this.onHurtEntity));
		}
	}

	// Token: 0x06017AF0 RID: 97008 RVA: 0x0074C7CC File Offset: 0x0074ABCC
	private void onHurtEntity(BeEvent.BeEventParam param)
	{
		EffectTable effectTable = param.m_Obj3 as EffectTable;
		BeEntity beEntity = param.m_Obj2 as BeEntity;
		BeEntity beEntity2 = param.m_Obj as BeEntity;
		if (beEntity2 == null || beEntity == null || beEntity.GetPID() != base.owner.GetPID())
		{
			return;
		}
		if (beEntity2.GetCamp() != base.owner.GetCamp())
		{
			param.m_Int = 0;
			param.m_Obj3 = null;
		}
	}
}
