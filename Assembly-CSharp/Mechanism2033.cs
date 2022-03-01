using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x02004357 RID: 17239
public class Mechanism2033 : BeMechanism
{
	// Token: 0x06017DE8 RID: 97768 RVA: 0x0076132C File Offset: 0x0075F72C
	public Mechanism2033(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x06017DE9 RID: 97769 RVA: 0x0076139C File Offset: 0x0075F79C
	public override void OnInit()
	{
		base.OnInit();
		this.scenePath = this.data.StringValueA[0];
		this.mechanismBuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.sceneTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.transformTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017DEA RID: 97770 RVA: 0x00761440 File Offset: 0x0075F840
	public override void OnStart()
	{
		base.OnStart();
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
		if (list.Count > 0)
		{
			BeActor boss = list[0];
			this.handleA = boss.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				this.OnBossDead();
			});
			this.handleB = boss.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
			{
				if (this.state != Mechanism2033.State.NONE)
				{
					return;
				}
				if (boss.sgGetCurrentState() == 0 || boss.sgGetCurrentState() == 3)
				{
					VFactor b = new VFactor(200L, (long)GlobalLogic.VALUE_1000);
					if (boss.GetEntityData().GetHPRate() < b)
					{
						this.SetBossPosition(boss);
						boss.UseSkill(this.skillID, false);
						this.owner.buffController.TryAddBuff(this.mechanismBuffID, -1, 1);
						this.state = Mechanism2033.State.START;
						this.owner.delayCaller.DelayCall(this.transformTime, delegate
						{
							if (boss.IsDead())
							{
								return;
							}
							this.LoadEvilScene();
							this.state = Mechanism2033.State.TRANSFORM;
						}, 0, 0, false);
					}
				}
			});
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017DEB RID: 97771 RVA: 0x007614DC File Offset: 0x0075F8DC
	private void SetBossPosition(BeActor actor)
	{
		actor.SetPosition(this.scenePos, true, true, false);
	}

	// Token: 0x06017DEC RID: 97772 RVA: 0x007614F0 File Offset: 0x0075F8F0
	private void OnBossDead()
	{
		switch (this.state)
		{
		case Mechanism2033.State.START:
			base.owner.buffController.RemoveBuff(this.mechanismBuffID, 0, 0);
			break;
		case Mechanism2033.State.TRANSFORM:
			this.reverse = true;
			base.owner.delayCaller.DelayCall(1000, delegate
			{
				base.owner.buffController.RemoveBuff(this.mechanismBuffID, 0, 0);
				this.DestroyMagicScene();
			}, 0, 0, false);
			break;
		}
	}

	// Token: 0x06017DED RID: 97773 RVA: 0x0076157C File Offset: 0x0075F97C
	private void LoadEvilScene()
	{
		this.scenePrefab = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.scenePath, true, 0U);
		if (this.scenePrefab != null)
		{
			Utility.AttachTo(this.scenePrefab, base.owner.CurrentBeScene.currentGeScene.GetSceneRoot(), false);
			this.renders = this.scenePrefab.GetComponentsInChildren<MeshRenderer>();
			base.owner.CurrentBeScene.currentGeScene.AddToColorDescList(this.scenePrefab);
		}
	}

	// Token: 0x06017DEE RID: 97774 RVA: 0x00761600 File Offset: 0x0075FA00
	public override void OnUpdateGraphic(int deltaTime)
	{
		base.OnUpdateGraphic(deltaTime);
		if (this.renders == null || this.scenePrefab == null)
		{
			return;
		}
		if (this.reverse)
		{
			this.reversTime += deltaTime;
			if (this.reversTime <= 2000)
			{
				this.TransformScenePrefab(true);
			}
		}
		else if (this.timer < this.sceneTime)
		{
			this.timer += deltaTime;
			this.TransformScenePrefab(false);
			this.reversValue = this.mainValue;
		}
	}

	// Token: 0x06017DEF RID: 97775 RVA: 0x00761698 File Offset: 0x0075FA98
	private void TransformScenePrefab(bool revers = false)
	{
		if (this.renders != null)
		{
			for (int i = 0; i < this.renders.Length; i++)
			{
				MeshRenderer meshRenderer = this.renders[i];
				if (revers)
				{
					this.mainValue = this.reversValue + (1.3f - this.reversValue) * ((float)this.reversTime / 2000f);
				}
				else
				{
					this.mainValue = 1.3f - 1.3f * ((float)this.timer / (float)this.sceneTime);
				}
				this.mainValue = Mathf.Clamp(this.mainValue, 0f, 1.3f);
				meshRenderer.sharedMaterial.SetFloat("_MainValue", this.mainValue);
			}
		}
	}

	// Token: 0x06017DF0 RID: 97776 RVA: 0x00761756 File Offset: 0x0075FB56
	private void DestroyMagicScene()
	{
		if (this.scenePrefab != null)
		{
			base.owner.CurrentBeScene.currentGeScene.ClearColorDesc(this.scenePrefab);
			Object.Destroy(this.scenePrefab);
			this.scenePrefab = null;
		}
	}

	// Token: 0x06017DF1 RID: 97777 RVA: 0x00761796 File Offset: 0x0075FB96
	public override void OnFinish()
	{
		base.OnFinish();
		this.DestroyMagicScene();
	}

	// Token: 0x040112D0 RID: 70352
	private int monsterID = 30780031;

	// Token: 0x040112D1 RID: 70353
	private string scenePath = string.Empty;

	// Token: 0x040112D2 RID: 70354
	private int transformTime = 1000;

	// Token: 0x040112D3 RID: 70355
	private int sceneTime = 15000;

	// Token: 0x040112D4 RID: 70356
	private GameObject scenePrefab;

	// Token: 0x040112D5 RID: 70357
	private MeshRenderer[] renders;

	// Token: 0x040112D6 RID: 70358
	private Mechanism2033.State state = Mechanism2033.State.NONE;

	// Token: 0x040112D7 RID: 70359
	private int mechanismBuffID;

	// Token: 0x040112D8 RID: 70360
	private bool reverse;

	// Token: 0x040112D9 RID: 70361
	private VInt3 scenePos = new VInt3(2.65f, 11.2f, 0f);

	// Token: 0x040112DA RID: 70362
	private int skillID = 6273;

	// Token: 0x040112DB RID: 70363
	private int timer;

	// Token: 0x040112DC RID: 70364
	private int reversTime;

	// Token: 0x040112DD RID: 70365
	private float reversValue;

	// Token: 0x040112DE RID: 70366
	private float mainValue;

	// Token: 0x02004358 RID: 17240
	private enum State
	{
		// Token: 0x040112E0 RID: 70368
		START,
		// Token: 0x040112E1 RID: 70369
		TRANSFORM,
		// Token: 0x040112E2 RID: 70370
		END,
		// Token: 0x040112E3 RID: 70371
		NONE
	}
}
