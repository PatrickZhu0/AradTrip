using System;
using ProtoTable;
using UnityEngine;

// Token: 0x02004355 RID: 17237
public class Mechanism2031 : BeMechanism
{
	// Token: 0x06017DBF RID: 97727 RVA: 0x0075FF0B File Offset: 0x0075E30B
	public Mechanism2031(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017DC0 RID: 97728 RVA: 0x0075FF44 File Offset: 0x0075E344
	public override void OnInit()
	{
		base.OnInit();
		this.timeGap = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._shadowLiftTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.shadowInterval = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.skillIDs = new int[this.data.ValueE.Count];
		for (int i = 0; i < this.skillIDs.Length; i++)
		{
			this.skillIDs[i] = TableManager.GetValueFromUnionCell(this.data.ValueE[i], this.level, true);
		}
		this._addSpeedBuffId = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
	}

	// Token: 0x06017DC1 RID: 97729 RVA: 0x00760080 File Offset: 0x0075E480
	public override void OnStart()
	{
		base.OnStart();
		this.InitBuffId();
		this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
		{
			this.AddBuff((int)args[0]);
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (this.buffId == num)
			{
				this.RemoveBuff();
			}
		});
	}

	// Token: 0x06017DC2 RID: 97730 RVA: 0x007600D8 File Offset: 0x0075E4D8
	private void InitBuffId()
	{
		BuffInfoTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffInfoTable>(this.buffInfoID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		this.buffId = tableItem.BuffID;
	}

	// Token: 0x06017DC3 RID: 97731 RVA: 0x00760114 File Offset: 0x0075E514
	private void AddBuff(int skillId)
	{
		if (!this.flag)
		{
			return;
		}
		if (Array.IndexOf<int>(this.skillIDs, skillId) == -1)
		{
			return;
		}
		base.owner.buffController.TryAddBuffInfo(this.buffInfoID, base.owner, this.level);
	}

	// Token: 0x06017DC4 RID: 97732 RVA: 0x00760168 File Offset: 0x0075E568
	private void RemoveBuff()
	{
		this.ClearSnapEffect();
		this.AddEffect();
		this.timer = 0;
		this.flag = false;
	}

	// Token: 0x06017DC5 RID: 97733 RVA: 0x00760184 File Offset: 0x0075E584
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner.sgGetCurrentState() == 3 || base.owner.sgGetCurrentState() == 2)
		{
			this.timer += deltaTime;
			if (this.timer >= this.timeGap)
			{
				this.flag = true;
				this.timer = 0;
			}
		}
		if (this.flag)
		{
			this.shadowTime += deltaTime;
			if (this.shadowTime >= this.shadowInterval)
			{
				this._AddSpeedBuff();
				this.CreateSnapEffect();
				this.shadowTime = 0;
			}
		}
	}

	// Token: 0x06017DC6 RID: 97734 RVA: 0x00760224 File Offset: 0x0075E624
	private void _AddSpeedBuff()
	{
		if (this._addSpeedBuffId > 0)
		{
			base.owner.buffController.TryAddBuff(this._addSpeedBuffId, this._shadowLiftTime, this.level);
		}
	}

	// Token: 0x06017DC7 RID: 97735 RVA: 0x0076025C File Offset: 0x0075E65C
	private void CreateSnapEffect()
	{
		VInt3 position = base.owner.GetPosition();
		position.z = base.owner.GetPosition().z + 10000;
		this.AddEffectPos(position.vec3);
		base.owner.m_pkGeActor.CreateSnapshot(Color.white, (float)this._shadowLiftTime / 1000f, "Shader/Materials/Snapshot_Sanda_Beidongjuexing.mat");
	}

	// Token: 0x06017DC8 RID: 97736 RVA: 0x007602CE File Offset: 0x0075E6CE
	private void ClearSnapEffect()
	{
		base.owner.m_pkGeActor.DestroySnapEffect();
	}

	// Token: 0x06017DC9 RID: 97737 RVA: 0x007602E0 File Offset: 0x0075E6E0
	private void AddEffectPos(Vec3 pos)
	{
		if (this.posIndex >= this.effectPosArr.Length)
		{
			this.posIndex = 0;
		}
		this.effectPosArr[this.posIndex] = pos;
		this.posIndex++;
	}

	// Token: 0x06017DCA RID: 97738 RVA: 0x0076032C File Offset: 0x0075E72C
	private void AddEffect()
	{
		for (int i = 0; i < this.effectPosArr.Length; i++)
		{
			if (this.effectPosArr[i] != Vec3.zero)
			{
				base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath, 0f, this.effectPosArr[i], 1f, 1f, false, false);
				this.effectPosArr[i] = Vec3.zero;
			}
		}
		this.posIndex = 0;
	}

	// Token: 0x040112B4 RID: 70324
	private int buffInfoID;

	// Token: 0x040112B5 RID: 70325
	private int timeGap = 800;

	// Token: 0x040112B6 RID: 70326
	private int _shadowLiftTime;

	// Token: 0x040112B7 RID: 70327
	private bool flag;

	// Token: 0x040112B8 RID: 70328
	private int shadowInterval = 200;

	// Token: 0x040112B9 RID: 70329
	private int[] skillIDs;

	// Token: 0x040112BA RID: 70330
	private int buffId;

	// Token: 0x040112BB RID: 70331
	private int _addSpeedBuffId;

	// Token: 0x040112BC RID: 70332
	private string effectPath = "Effects/Hero_Sanda/Eff_Sanda_juexing/Prefab/Eff_Sanda_juexing_beidong_xiaosan";

	// Token: 0x040112BD RID: 70333
	private int posIndex;

	// Token: 0x040112BE RID: 70334
	private Vec3[] effectPosArr = new Vec3[4];

	// Token: 0x040112BF RID: 70335
	private int tmpBuffInfoID;

	// Token: 0x040112C0 RID: 70336
	private int timer;

	// Token: 0x040112C1 RID: 70337
	private int shadowTime;
}
