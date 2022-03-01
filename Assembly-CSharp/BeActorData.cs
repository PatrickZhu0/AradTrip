using System;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02004148 RID: 16712
public class BeActorData
{
	// Token: 0x06016CD5 RID: 93397 RVA: 0x00700DE4 File Offset: 0x006FF1E4
	public BeActorData(BeActor a)
	{
		this.actor = a;
		this.comboIntervel = this.comboDefaultIntervel;
	}

	// Token: 0x06016CD6 RID: 93398 RVA: 0x00700E37 File Offset: 0x006FF237
	public void InitData(BeActor actor)
	{
		if (actor == null)
		{
			return;
		}
		this.m_RecordComboIntervel = this.comboDefaultIntervel;
		this.m_RecordOwner = actor;
		this.m_RecordComboHandle = actor.RegisterEvent(BeEventType.onHitOther, new BeEventHandle.Del(this.RegisterHitOtherEvent));
	}

	// Token: 0x06016CD7 RID: 93399 RVA: 0x00700E70 File Offset: 0x006FF270
	protected void RegisterHitOtherEvent(object[] args)
	{
		if (args.Length > 2 && args[1] != null)
		{
			int id = (int)args[1];
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(id, string.Empty, string.Empty);
			if (tableItem != null && (tableItem.IsFriendDamage > 0 || tableItem.HasDamage != 1))
			{
				return;
			}
		}
		this.m_TopOwner = (this.m_RecordOwner.GetTopOwner(this.m_RecordOwner) as BeActor);
		if (this.m_TopOwner == null)
		{
			this.RecordComboData();
		}
		else
		{
			this.m_TopOwner.actorData.RecordComboData();
		}
	}

	// Token: 0x06016CD8 RID: 93400 RVA: 0x00700F10 File Offset: 0x006FF310
	public void UpdateRecordCombo(int iDeltaTime)
	{
		if (!this.m_RecordOwner.isMainActor)
		{
			return;
		}
		if (!this.m_IsComboRecord)
		{
			return;
		}
		if (this.m_RecordComboTimeAcc > 0)
		{
			this.m_RecordComboTimeAcc -= iDeltaTime;
		}
		else if (this.m_TopOwner == null)
		{
			this.StopRecordCombo();
		}
		else
		{
			this.m_TopOwner.actorData.StopRecordCombo();
		}
	}

	// Token: 0x06016CD9 RID: 93401 RVA: 0x00700F80 File Offset: 0x006FF380
	protected void UpdateTopOwnerCombo(int iDeltaTime)
	{
		if (!this.m_RecordOwner.isSpecialMonster)
		{
			return;
		}
		if (this.m_TopOwner == null)
		{
			return;
		}
		if (!this.m_TopOwner.actorData.m_IsComboRecord)
		{
			return;
		}
		if (this.m_TopOwner.actorData.m_RecordComboTimeAcc > 0)
		{
			this.m_TopOwner.actorData.m_RecordComboTimeAcc -= iDeltaTime;
		}
		else
		{
			this.m_TopOwner.actorData.StopRecordCombo();
		}
	}

	// Token: 0x06016CDA RID: 93402 RVA: 0x00701003 File Offset: 0x006FF403
	public void UpdateLogic(int iDeltaTime)
	{
		this.UpdateRecordCombo(iDeltaTime);
		if (this.isSpecialMonster)
		{
			this.UpdateTopOwnerCombo(iDeltaTime);
		}
	}

	// Token: 0x06016CDB RID: 93403 RVA: 0x00701020 File Offset: 0x006FF420
	protected void RecordComboData()
	{
		if (!this.m_RecordOwner.isMainActor)
		{
			return;
		}
		this.m_RecordComboTimeAcc = this.m_RecordComboIntervel;
		this.m_CurComboCount++;
		this.m_IsComboRecord = true;
		if (this.m_RecordOwner != null)
		{
			this.m_RecordOwner.TriggerEvent(BeEventType.onBattleCombo, null);
		}
	}

	// Token: 0x06016CDC RID: 93404 RVA: 0x00701077 File Offset: 0x006FF477
	protected void StopRecordCombo()
	{
		this.m_IsComboRecord = false;
		this.m_CurComboCount = 0;
		if (this.m_RecordOwner != null)
		{
			this.m_RecordOwner.TriggerEvent(BeEventType.onBattleComboStop, null);
		}
	}

	// Token: 0x06016CDD RID: 93405 RVA: 0x0070109F File Offset: 0x006FF49F
	public int GetCurComboCount()
	{
		return this.m_CurComboCount;
	}

	// Token: 0x06016CDE RID: 93406 RVA: 0x007010A7 File Offset: 0x006FF4A7
	public void ResetComboIntervel()
	{
		this.m_RecordComboIntervel = this.comboDefaultIntervel;
		this.comboIntervel = this.comboDefaultIntervel;
	}

	// Token: 0x06016CDF RID: 93407 RVA: 0x007010C1 File Offset: 0x006FF4C1
	public void SetComboIntervel(int intervel)
	{
		this.m_RecordComboIntervel = intervel;
		this.comboIntervel = intervel;
	}

	// Token: 0x06016CE0 RID: 93408 RVA: 0x007010D1 File Offset: 0x006FF4D1
	protected void RemoveLogicHandle()
	{
		if (this.m_RecordComboHandle != null)
		{
			this.m_RecordComboHandle.Remove();
			this.m_RecordComboHandle = null;
		}
	}

	// Token: 0x06016CE1 RID: 93409 RVA: 0x007010F0 File Offset: 0x006FF4F0
	public void SetEnable(bool flag)
	{
		this.enable = flag;
		if (this.enable)
		{
			this.ResetData();
		}
	}

	// Token: 0x06016CE2 RID: 93410 RVA: 0x0070110A File Offset: 0x006FF50A
	public bool IsEnable()
	{
		return this.enable;
	}

	// Token: 0x06016CE3 RID: 93411 RVA: 0x00701112 File Offset: 0x006FF512
	public void Update(int iDeltaTime)
	{
		this.UpdateCombo(iDeltaTime);
		if (this.isSpecialMonster)
		{
			this.UpdateOwnerCombo(iDeltaTime);
		}
	}

	// Token: 0x06016CE4 RID: 93412 RVA: 0x00701130 File Offset: 0x006FF530
	protected void UpdateCombo(int iDeltaTime)
	{
		if (this.curState == BeActorData.ComboState.Combo)
		{
			if (this.timeAcc > 0)
			{
				this.timeAcc -= iDeltaTime;
			}
			else if (this.owner == null)
			{
				this.StopFeed();
			}
			else
			{
				this.owner.actorData.StopFeed();
			}
		}
	}

	// Token: 0x06016CE5 RID: 93413 RVA: 0x00701190 File Offset: 0x006FF590
	protected void UpdateOwnerCombo(int iDeltaTime)
	{
		if (this.owner != null && this.owner.actorData.curState == BeActorData.ComboState.Combo)
		{
			if (this.owner.actorData.timeAcc > 0)
			{
				this.owner.actorData.timeAcc -= iDeltaTime;
			}
			else
			{
				this.owner.actorData.StopFeed();
			}
		}
	}

	// Token: 0x06016CE6 RID: 93414 RVA: 0x00701204 File Offset: 0x006FF604
	public void RemoveHandle()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
		if (this.breakHandle != null)
		{
			this.breakHandle.Remove();
			this.breakHandle = null;
		}
		if (this.blockHandle != null)
		{
			this.blockHandle.Remove();
			this.blockHandle = null;
		}
		this.RemoveLogicHandle();
	}

	// Token: 0x06016CE7 RID: 93415 RVA: 0x00701270 File Offset: 0x006FF670
	protected void ResetData()
	{
		this.curState = BeActorData.ComboState.None;
		this.maxCombo = 0;
		this.curCombo = 0;
		this.timeAcc = 0;
		this.curBreakAction = 0;
		this.curBlock = 0;
		this.comboDamageValue = 0f;
		if (this.actor.GetEntityData() != null && this.actor.GetEntityData().isSummonMonster)
		{
			BeEntity beEntity = this.actor.GetOwner();
			this.owner = (beEntity as BeActor);
		}
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
		this.handler = this.actor.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			float damgeValue = 0f;
			if (args.Length > 2 && args[1] != null)
			{
				int id = (int)args[1];
				EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(id, string.Empty, string.Empty);
				if (tableItem != null && (tableItem.IsFriendDamage > 0 || tableItem.HasDamage != 1))
				{
					return;
				}
				BeEntity beEntity2 = (BeEntity)args[0];
				if (beEntity2 != null && beEntity2.attribute != null)
				{
					int num = (int)args[5];
					if (beEntity2.attribute.GetMaxHP() > 0)
					{
						damgeValue = (float)num / (float)beEntity2.attribute.GetMaxHP();
					}
				}
			}
			if (this.owner == null)
			{
				this.Feed(damgeValue);
			}
			else
			{
				this.owner.actorData.Feed(damgeValue);
			}
		});
		if (this.breakHandle != null)
		{
			this.breakHandle.Remove();
			this.breakHandle = null;
		}
		this.breakHandle = this.actor.RegisterEvent(BeEventType.onBreakAction, delegate(object[] args)
		{
			this.curBreakAction++;
		});
		if (this.blockHandle != null)
		{
			this.blockHandle.Remove();
			this.blockHandle = null;
		}
		this.blockHandle = this.actor.RegisterEvent(BeEventType.BlockSuccess, delegate(object[] args)
		{
			this.curBlock++;
		});
		if (this.actor.battleType == BattleType.ScufflePVP)
		{
			if (this.deadHandler != null)
			{
				this.deadHandler.Remove();
				this.deadHandler = null;
			}
			BeActor beActor = (this.owner != null) ? this.owner : this.actor;
			this.deadHandler = beActor.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				beActor.actorData.StopFeed();
			});
		}
	}

	// Token: 0x06016CE8 RID: 93416 RVA: 0x0070141C File Offset: 0x006FF81C
	public void Feed(float damgeValue)
	{
		this.curState = BeActorData.ComboState.Combo;
		this.timeAcc = this.comboIntervel;
		this.curCombo++;
		this.comboDamageValue += damgeValue;
		if (this.curCombo > this.maxCombo)
		{
			this.maxCombo = this.curCombo;
		}
		if (this.actor.isLocalActor || (this.owner != null && this.owner.isLocalActor))
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null && clientSystemBattle.Combo != null)
			{
				clientSystemBattle.Combo.Feed(this.curCombo);
			}
		}
	}

	// Token: 0x06016CE9 RID: 93417 RVA: 0x007014D8 File Offset: 0x006FF8D8
	private uint GetDamageScore(float damageFactor, int comboCount)
	{
		if (this.actor == null)
		{
			return 0U;
		}
		if (this.actor.battleType != BattleType.MutiPlayer)
		{
			return 0U;
		}
		int num = (int)(damageFactor * 100f);
		return Singleton<TableManager>.instance.GetComboScore(this.actor.professionID, Mathf.Min(num, 100), comboCount);
	}

	// Token: 0x06016CEA RID: 93418 RVA: 0x0070152C File Offset: 0x006FF92C
	public void StopFeed()
	{
		this.curState = BeActorData.ComboState.None;
		uint damageScore = this.GetDamageScore(this.comboDamageValue, this.curCombo);
		this.timeAcc = 0;
		this.curCombo = 0;
		if (this.actor.battleType == BattleType.MutiPlayer)
		{
			for (int i = 0; i < this.comboMaxDamageList.Length; i++)
			{
				if (this.comboMaxDamageList[i] <= damageScore)
				{
					for (int j = this.comboMaxDamageList.Length - 1; j > i; j--)
					{
						this.comboMaxDamageList[j] = this.comboMaxDamageList[j - 1];
					}
					this.comboMaxDamageList[i] = damageScore;
					break;
				}
			}
			this.comboDamageValue = 0f;
		}
		if (this.actor.isLocalActor || (this.owner != null && this.owner.isLocalActor))
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null && clientSystemBattle.Combo != null)
			{
				clientSystemBattle.Combo.StopFeed();
			}
		}
	}

	// Token: 0x06016CEB RID: 93419 RVA: 0x0070163C File Offset: 0x006FFA3C
	public int GetMaxCombo()
	{
		return this.maxCombo;
	}

	// Token: 0x06016CEC RID: 93420 RVA: 0x00701644 File Offset: 0x006FFA44
	public uint GetDamageScore()
	{
		uint num = 0U;
		for (int i = 0; i < this.comboMaxDamageList.Length; i++)
		{
			if (i == 0)
			{
				num += this.comboMaxDamageList[i];
			}
			if (i == 1)
			{
				num += (uint)(0.5f * this.comboMaxDamageList[i]);
			}
			if (i == 2)
			{
				num += (uint)(0.3f * this.comboMaxDamageList[i]);
			}
		}
		return (uint)Mathf.Clamp(num, 0f, 450f);
	}

	// Token: 0x06016CED RID: 93421 RVA: 0x007016C8 File Offset: 0x006FFAC8
	public uint GetExtraScore()
	{
		uint num = (uint)Mathf.Clamp(this.curBreakAction * 10, 0, 30);
		uint num2 = (uint)Mathf.Clamp(this.curBlock * 10, 0, 20);
		return num + num2;
	}

	// Token: 0x040104B3 RID: 66739
	private BeEventHandle m_RecordComboHandle;

	// Token: 0x040104B4 RID: 66740
	protected BeActor m_RecordOwner;

	// Token: 0x040104B5 RID: 66741
	protected BeActor m_TopOwner;

	// Token: 0x040104B6 RID: 66742
	protected int m_CurComboCount;

	// Token: 0x040104B7 RID: 66743
	protected bool m_IsComboRecord;

	// Token: 0x040104B8 RID: 66744
	private readonly int comboDefaultIntervel = 1250;

	// Token: 0x040104B9 RID: 66745
	protected int m_RecordComboIntervel = 1250;

	// Token: 0x040104BA RID: 66746
	protected int m_RecordComboTimeAcc;

	// Token: 0x040104BB RID: 66747
	protected BeActorData.ComboState curState;

	// Token: 0x040104BC RID: 66748
	protected BeActor actor;

	// Token: 0x040104BD RID: 66749
	protected BeActor owner;

	// Token: 0x040104BE RID: 66750
	protected BeEventHandle handler;

	// Token: 0x040104BF RID: 66751
	protected BeEventHandle deadHandler;

	// Token: 0x040104C0 RID: 66752
	protected BeEventHandle breakHandle;

	// Token: 0x040104C1 RID: 66753
	protected BeEventHandle blockHandle;

	// Token: 0x040104C2 RID: 66754
	protected bool enable;

	// Token: 0x040104C3 RID: 66755
	protected int maxCombo;

	// Token: 0x040104C4 RID: 66756
	protected int curCombo;

	// Token: 0x040104C5 RID: 66757
	protected int curBreakAction;

	// Token: 0x040104C6 RID: 66758
	protected int curBlock;

	// Token: 0x040104C7 RID: 66759
	protected int comboIntervel = 1250;

	// Token: 0x040104C8 RID: 66760
	protected int timeAcc;

	// Token: 0x040104C9 RID: 66761
	public bool isSpecialMonster;

	// Token: 0x040104CA RID: 66762
	protected float comboDamageValue;

	// Token: 0x040104CB RID: 66763
	protected uint[] comboMaxDamageList = new uint[3];

	// Token: 0x02004149 RID: 16713
	protected enum ComboState
	{
		// Token: 0x040104CD RID: 66765
		None,
		// Token: 0x040104CE RID: 66766
		Combo
	}
}
