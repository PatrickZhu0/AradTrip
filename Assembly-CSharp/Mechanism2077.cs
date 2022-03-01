using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;

// Token: 0x02004385 RID: 17285
public class Mechanism2077 : BeMechanism
{
	// Token: 0x06017F78 RID: 98168 RVA: 0x0076CBFF File Offset: 0x0076AFFF
	public Mechanism2077(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F79 RID: 98169 RVA: 0x0076CC17 File Offset: 0x0076B017
	public override void OnInit()
	{
		base.OnInit();
		this.InitData();
	}

	// Token: 0x06017F7A RID: 98170 RVA: 0x0076CC28 File Offset: 0x0076B028
	private void InitData()
	{
		if (this.mComBuffList == null)
		{
			this.mComBuffList = ListPool<Mechanism2077.ComboBuff>.Get();
			this.mComBuffList.Clear();
		}
		if (this.data.ValueA.Count != this.data.ValueB.Count || this.data.ValueA.Count != this.data.ValueC.Count)
		{
			Logger.LogErrorFormat("2077机制配置文件错误:配置数量不统一{0}，{1}，{2}", new object[]
			{
				this.data.ValueA.Count,
				this.data.ValueB.Count,
				this.data.ValueC.Count
			});
			return;
		}
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			int buffId = BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true) : TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			this.mComBuffList.Add(new Mechanism2077.ComboBuff(valueFromUnionCell, buffId));
		}
		this.mUndoTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017F7B RID: 98171 RVA: 0x0076CDD4 File Offset: 0x0076B1D4
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || this.mComBuffList == null)
		{
			return;
		}
		if (this.mComBuffList.Count <= 0)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onBattleCombo, new BeEventHandle.Del(this.OnComboFeed));
	}

	// Token: 0x06017F7C RID: 98172 RVA: 0x0076CE30 File Offset: 0x0076B230
	private void OnComboFeed(object[] args)
	{
		if (base.owner == null || base.owner.actorData == null || base.owner.buffController == null)
		{
			return;
		}
		int curComboCount = base.owner.actorData.GetCurComboCount();
		if (curComboCount <= 0)
		{
			return;
		}
		int buffIndex = this.GetBuffIndex(curComboCount);
		this.mCurComboIndex = buffIndex;
		if (buffIndex < this.mCurMaxComboIndex)
		{
			this.mIsComboStop = true;
		}
		else if (buffIndex >= 0)
		{
			this.IncreaseBuff(buffIndex);
		}
	}

	// Token: 0x06017F7D RID: 98173 RVA: 0x0076CEB8 File Offset: 0x0076B2B8
	private void IncreaseBuff(int buffIndex)
	{
		if (this.mComBuffList == null)
		{
			return;
		}
		if (buffIndex < 0 || buffIndex >= this.mComBuffList.Count)
		{
			return;
		}
		Mechanism2077.ComboBuff comboBuff = this.mComBuffList[buffIndex];
		if (comboBuff == null)
		{
			return;
		}
		comboBuff.mTimeAcc = 0;
		if (comboBuff.mIsAdd)
		{
			return;
		}
		if (base.owner == null || base.owner.buffController == null)
		{
			return;
		}
		if (base.owner.buffController.TryAddBuff(comboBuff.mBuffId, -1, this.level) == null)
		{
			return;
		}
		if (this.mCurMaxComboIndex >= 0 && this.mCurMaxComboIndex < this.mComBuffList.Count)
		{
			base.owner.buffController.RemoveBuff(this.mComBuffList[this.mCurMaxComboIndex].mBuffId, 0, 0);
		}
		this.mIsComboStop = false;
		this.mCurMaxComboIndex = buffIndex;
		comboBuff.mIsAdd = true;
		this.UpdateBuffInfo(this.mCurMaxComboIndex, 1f);
	}

	// Token: 0x06017F7E RID: 98174 RVA: 0x0076CFC7 File Offset: 0x0076B3C7
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateUndoBuff(deltaTime);
	}

	// Token: 0x06017F7F RID: 98175 RVA: 0x0076CFD7 File Offset: 0x0076B3D7
	public override void OnUpdateGraphic(int deltaTime)
	{
		base.OnUpdateGraphic(deltaTime);
		if (Time.frameCount % 3 == 0)
		{
			this.UpdateBuffInfo(this.mCurMaxComboIndex, this.mComboProgress);
		}
	}

	// Token: 0x06017F80 RID: 98176 RVA: 0x0076D000 File Offset: 0x0076B400
	private void UpdateUndoBuff(int deltaTime)
	{
		this.mComboProgress = 1f;
		if (!this.mIsComboStop)
		{
			return;
		}
		if (this.mCurComboIndex >= this.mCurMaxComboIndex)
		{
			this.mIsComboStop = false;
			return;
		}
		if (this.mCurMaxComboIndex < 0)
		{
			return;
		}
		if (this.mCurMaxComboIndex >= this.mComBuffList.Count)
		{
			return;
		}
		Mechanism2077.ComboBuff comboBuff = this.mComBuffList[this.mCurMaxComboIndex];
		if (comboBuff == null)
		{
			return;
		}
		comboBuff.mTimeAcc += deltaTime;
		this.mComboProgress = (float)(this.mUndoTime - comboBuff.mTimeAcc) / (float)this.mUndoTime;
		if (comboBuff.mTimeAcc >= this.mUndoTime)
		{
			this.UndoBuff(comboBuff);
		}
	}

	// Token: 0x06017F81 RID: 98177 RVA: 0x0076D0BC File Offset: 0x0076B4BC
	private void UndoBuff(Mechanism2077.ComboBuff comboBuff)
	{
		if (this.mCurMaxComboIndex < 0)
		{
			return;
		}
		if (base.owner == null || base.owner.actorData == null || base.owner.buffController == null)
		{
			return;
		}
		base.owner.buffController.RemoveBuff(comboBuff.mBuffId, 0, 0);
		comboBuff.mIsAdd = false;
		this.mCurMaxComboIndex--;
		if (this.mCurMaxComboIndex >= 0 && this.mCurMaxComboIndex < this.mComBuffList.Count)
		{
			base.owner.buffController.TryAddBuff(this.mComBuffList[this.mCurMaxComboIndex].mBuffId, -1, this.level);
		}
		this.UpdateBuffInfo(this.mCurMaxComboIndex, 1f);
		if (this.mCurMaxComboIndex < 0)
		{
			this.mIsComboStop = false;
		}
	}

	// Token: 0x06017F82 RID: 98178 RVA: 0x0076D1A8 File Offset: 0x0076B5A8
	private int GetBuffIndex(int combo)
	{
		int result = -1;
		if (this.mComBuffList == null)
		{
			return result;
		}
		for (int i = 0; i < this.mComBuffList.Count; i++)
		{
			if (this.mComBuffList[i].mCombo > combo)
			{
				break;
			}
			result = i;
		}
		return result;
	}

	// Token: 0x06017F83 RID: 98179 RVA: 0x0076D204 File Offset: 0x0076B604
	public void UpdateBuffInfo(int index, float progress)
	{
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetComboBuffNum(index + 1, progress);
			}
		}
	}

	// Token: 0x06017F84 RID: 98180 RVA: 0x0076D24C File Offset: 0x0076B64C
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.mComBuffList != null)
		{
			ListPool<Mechanism2077.ComboBuff>.Release(this.mComBuffList);
			this.mComBuffList = null;
		}
	}

	// Token: 0x04011420 RID: 70688
	private List<Mechanism2077.ComboBuff> mComBuffList;

	// Token: 0x04011421 RID: 70689
	private int mUndoTime;

	// Token: 0x04011422 RID: 70690
	private bool mIsComboStop;

	// Token: 0x04011423 RID: 70691
	private int mCurMaxComboIndex = -1;

	// Token: 0x04011424 RID: 70692
	private int mCurComboIndex = -1;

	// Token: 0x04011425 RID: 70693
	private float mComboProgress;

	// Token: 0x02004386 RID: 17286
	private class ComboBuff
	{
		// Token: 0x06017F85 RID: 98181 RVA: 0x0076D271 File Offset: 0x0076B671
		public ComboBuff(int combo, int buffId)
		{
			this.mCombo = combo;
			this.mBuffId = buffId;
			this.mTimeAcc = 0;
			this.mIsAdd = false;
		}

		// Token: 0x04011426 RID: 70694
		public readonly int mCombo;

		// Token: 0x04011427 RID: 70695
		public readonly int mBuffId;

		// Token: 0x04011428 RID: 70696
		public int mTimeAcc;

		// Token: 0x04011429 RID: 70697
		public bool mIsAdd;
	}
}
