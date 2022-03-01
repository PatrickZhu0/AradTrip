using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020043CF RID: 17359
public class Mechanism22 : BeMechanism
{
	// Token: 0x0601814F RID: 98639 RVA: 0x0077AD40 File Offset: 0x00779140
	public Mechanism22(int mid, int lv) : base(mid, lv)
	{
		this.canRemove = false;
	}

	// Token: 0x06018150 RID: 98640 RVA: 0x0077AD73 File Offset: 0x00779173
	public List<Rune> getRuneList()
	{
		return this.runes;
	}

	// Token: 0x06018151 RID: 98641 RVA: 0x0077AD7C File Offset: 0x0077917C
	public override void OnInit()
	{
		this.maxRuneNum = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.runeLiftTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06018152 RID: 98642 RVA: 0x0077AE08 File Offset: 0x00779208
	public override void OnStart()
	{
		Rune.InitQueue();
		BeSkill skill = base.owner.GetSkill(this.targetSkillID);
		if (skill != null)
		{
			this.level = skill.level;
		}
		this.RemoveHandle();
		if (base.owner != null)
		{
			this.handle1 = base.owner.RegisterEvent(BeEventType.onAddRune, delegate(object[] args)
			{
				this.AddRune();
			});
			this.handle2 = base.owner.RegisterEvent(BeEventType.onClearRune, delegate(object[] args)
			{
				this.RemoveRune(true);
			});
		}
	}

	// Token: 0x06018153 RID: 98643 RVA: 0x0077AE92 File Offset: 0x00779292
	private void RemoveHandle()
	{
		if (this.handle1 != null)
		{
			this.handle1.Remove();
			this.handle1 = null;
		}
		if (this.handle2 != null)
		{
			this.handle2.Remove();
			this.handle2 = null;
		}
	}

	// Token: 0x06018154 RID: 98644 RVA: 0x0077AED0 File Offset: 0x007792D0
	public override void OnUpdate(int deltaTime)
	{
		for (int i = 0; i < this.runes.Count; i++)
		{
			Rune rune = this.runes[i];
			if (rune.IsDead())
			{
				rune.OnRemove();
				this.runes.RemoveAt(i);
				this.OnRemoveRune();
				i--;
			}
			else
			{
				rune.Update(deltaTime);
			}
		}
	}

	// Token: 0x06018155 RID: 98645 RVA: 0x0077AF3C File Offset: 0x0077933C
	public override void OnUpdateGraphic(int deltaTime)
	{
		for (int i = 0; i < this.runes.Count; i++)
		{
			Rune rune = this.runes[i];
			if (!rune.IsDead())
			{
				rune.UpdateGraphic(deltaTime);
			}
		}
	}

	// Token: 0x06018156 RID: 98646 RVA: 0x0077AF84 File Offset: 0x00779384
	public int GetRuneCount()
	{
		return this.runes.Count;
	}

	// Token: 0x06018157 RID: 98647 RVA: 0x0077AF94 File Offset: 0x00779394
	public void AddRune()
	{
		if (this.runes.Count < this.maxRuneNum)
		{
			this.runes.Add(new Rune(this.runeLiftTime, base.owner, this));
			this.OnAddRune();
		}
		if (this.runes.Count == 1)
		{
			this.audioHandle = MonoSingleton<AudioManager>.instance.PlaySound(3025);
		}
	}

	// Token: 0x06018158 RID: 98648 RVA: 0x0077B008 File Offset: 0x00779408
	public void RemoveRune(bool all = false)
	{
		bool @bool = base.owner.TriggerEventNew(BeEventType.OnConsumeRune, new EventParam
		{
			m_Bool = false
		}).m_Bool;
		if (@bool)
		{
			return;
		}
		for (int i = 0; i < this.runes.Count; i++)
		{
			Rune rune = this.runes[i];
			if (!rune.IsDead())
			{
				rune.SetDead(true);
			}
		}
	}

	// Token: 0x06018159 RID: 98649 RVA: 0x0077B084 File Offset: 0x00779484
	public void RepositionRunes(bool force = false)
	{
		if (this.runes.Count >= 1)
		{
			float num = -1f;
			int num2 = 0;
			for (int i = 0; i < this.runes.Count; i++)
			{
				if (this.runes[i].state == Rune.State.STAND)
				{
					num2++;
					if (num <= -1f)
					{
						num = this.runes[i].angle;
					}
				}
			}
			int j = 0;
			int num3 = 0;
			while (j < this.runes.Count)
			{
				if (this.runes[j].state == Rune.State.STAND)
				{
					this.runes[j].SetRotationAngle((num + (float)(num3 * (360 / num2))) % 360f, force);
					num3++;
					if (this.runes[j].effectRune != null)
					{
						this.runes[j].effectRune.Play(true);
					}
				}
				j++;
			}
		}
	}

	// Token: 0x0601815A RID: 98650 RVA: 0x0077B18C File Offset: 0x0077958C
	protected void OnAddRune()
	{
		base.owner.buffController.TryAddBuff(this.buffID, int.MaxValue, this.level);
	}

	// Token: 0x0601815B RID: 98651 RVA: 0x0077B1B8 File Offset: 0x007795B8
	protected void OnRemoveRune()
	{
		base.owner.buffController.RemoveBuff(this.buffID, 1, 0);
		if (this.runes.Count <= 0)
		{
			Rune.InitQueue();
		}
		if (this.runes.Count < 1 && this.audioHandle != 0U)
		{
			MonoSingleton<AudioManager>.instance.Stop(this.audioHandle);
		}
	}

	// Token: 0x0601815C RID: 98652 RVA: 0x0077B21F File Offset: 0x0077961F
	public override void OnFinish()
	{
		this.RemoveRune(true);
	}

	// Token: 0x0601815D RID: 98653 RVA: 0x0077B228 File Offset: 0x00779628
	public override void OnDead()
	{
		this.RemoveRune(true);
	}

	// Token: 0x040115AF RID: 71087
	private CrypticInt32 maxRuneNum = 0;

	// Token: 0x040115B0 RID: 71088
	private int buffID;

	// Token: 0x040115B1 RID: 71089
	private int runeLiftTime;

	// Token: 0x040115B2 RID: 71090
	private int targetSkillID = 1710;

	// Token: 0x040115B3 RID: 71091
	private List<Rune> runes = new List<Rune>();

	// Token: 0x040115B4 RID: 71092
	private BeEventHandle handle1;

	// Token: 0x040115B5 RID: 71093
	private BeEventHandle handle2;

	// Token: 0x040115B6 RID: 71094
	private uint audioHandle;
}
