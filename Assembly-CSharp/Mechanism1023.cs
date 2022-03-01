using System;
using System.Collections.Generic;

// Token: 0x0200425F RID: 16991
public class Mechanism1023 : BeMechanism
{
	// Token: 0x06017829 RID: 96297 RVA: 0x0073BA9C File Offset: 0x00739E9C
	public Mechanism1023(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601782A RID: 96298 RVA: 0x0073BAB1 File Offset: 0x00739EB1
	public override void OnInit()
	{
		base.OnInit();
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x0601782B RID: 96299 RVA: 0x0073BAE4 File Offset: 0x00739EE4
	public override void OnStart()
	{
		base.OnStart();
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindMainActor(list);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor actor = list[i];
			BeEventHandle item = actor.RegisterEvent(BeEventType.OnUseCrystal, delegate(object[] args)
			{
				bool face = actor.GetFace();
				float x = (!face) ? -1f : 1f;
				this.owner.SetFace(face, false, false);
				this.owner.SetPosition(actor.GetPosition() + new VInt3(x, 0f, 0f), true, true, false);
				if (this.owner.CanUseSkill(this.skillID))
				{
					this.owner.UseSkill(this.skillID, false);
				}
			});
			this.handleList.Add(item);
		}
	}

	// Token: 0x0601782C RID: 96300 RVA: 0x0073BB68 File Offset: 0x00739F68
	private void RemoveHandleList()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x0601782D RID: 96301 RVA: 0x0073BBCB File Offset: 0x00739FCB
	public override void OnDead()
	{
		base.OnDead();
		this.RemoveHandleList();
	}

	// Token: 0x0601782E RID: 96302 RVA: 0x0073BBD9 File Offset: 0x00739FD9
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandleList();
	}

	// Token: 0x04010E55 RID: 69205
	private int skillID;

	// Token: 0x04010E56 RID: 69206
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
