using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004266 RID: 16998
internal class Mechanism103 : BeMechanism
{
	// Token: 0x06017857 RID: 96343 RVA: 0x0073C7FC File Offset: 0x0073ABFC
	public Mechanism103(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017858 RID: 96344 RVA: 0x0073C814 File Offset: 0x0073AC14
	public override void OnInit()
	{
		this.effectPath1 = this.data.StringValueA[0];
		this.effectPath2 = this.data.StringValueA[1];
		this.buffArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.buffArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.delay = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.distance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017859 RID: 96345 RVA: 0x0073C910 File Offset: 0x0073AD10
	public override void OnStart()
	{
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].playerActor != null && !allPlayers[i].playerActor.IsDead() && allPlayers[i].playerActor.stateController.CanBeHit())
			{
				this.player = allPlayers[i].playerActor;
				this.DoWork();
				break;
			}
		}
	}

	// Token: 0x0601785A RID: 96346 RVA: 0x0073C9AC File Offset: 0x0073ADAC
	private void DoWork()
	{
		if (this.player == null)
		{
			return;
		}
		this.AddBuffs();
		this.player.m_pkGeActor.CreateEffect(this.effectPath1, "[actor]Body", 0f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		this.player.delayCaller.DelayCall(this.delay, delegate
		{
			if (this.player != null && !this.player.IsDead() && this.player.stateController.CanBeHit())
			{
				VInt3 position = base.owner.GetPosition();
				position.x += ((!base.owner.GetFace()) ? this.distance.i : (-this.distance.i));
				if (this.player.CurrentBeScene.IsInBlockPlayer(position))
				{
					VInt3 rkPos = BeAIManager.FindStandPositionNew(position, this.player.CurrentBeScene, !base.owner.GetFace(), false, 40);
					this.player.SetPosition(rkPos, false, true, false);
				}
				else
				{
					this.player.SetPosition(position, false, true, false);
				}
				this.RemoveBuffs();
				GameObject attachNode = this.player.m_pkGeActor.GetAttachNode("[actor]Body");
				VInt3 vint = new VInt3(attachNode.transform.position);
				position.z = vint.z;
				this.player.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath2, 0f, position.vec3, 1f, 1f, false, false);
			}
		}, 0, 0, false);
	}

	// Token: 0x0601785B RID: 96347 RVA: 0x0073CA28 File Offset: 0x0073AE28
	private void AddBuffs()
	{
		if (this.player == null)
		{
			return;
		}
		for (int i = 0; i < this.buffArray.Length; i++)
		{
			BeBuff beBuff = this.player.buffController.TryAddBuff(this.buffArray[i], GlobalLogic.VALUE_100000, 1);
			if (beBuff != null)
			{
				this.buffList.Add(beBuff);
			}
		}
	}

	// Token: 0x0601785C RID: 96348 RVA: 0x0073CA8C File Offset: 0x0073AE8C
	private void RemoveBuffs()
	{
		if (this.player == null)
		{
			return;
		}
		for (int i = 0; i < this.buffList.Count; i++)
		{
			this.player.buffController.RemoveBuff(this.buffList[i]);
		}
		this.buffList.Clear();
	}

	// Token: 0x0601785D RID: 96349 RVA: 0x0073CAE8 File Offset: 0x0073AEE8
	public override void OnFinish()
	{
		this.RemoveBuffs();
	}

	// Token: 0x04010E6C RID: 69228
	private string effectPath1;

	// Token: 0x04010E6D RID: 69229
	private string effectPath2;

	// Token: 0x04010E6E RID: 69230
	private int[] buffArray;

	// Token: 0x04010E6F RID: 69231
	private int delay;

	// Token: 0x04010E70 RID: 69232
	private VInt distance;

	// Token: 0x04010E71 RID: 69233
	private BeActor player;

	// Token: 0x04010E72 RID: 69234
	private List<BeBuff> buffList = new List<BeBuff>();
}
