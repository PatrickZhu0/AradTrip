using System;
using System.Collections.Generic;
using DG.Tweening;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x020044A1 RID: 17569
public class Skill2312 : BeSkill
{
	// Token: 0x06018702 RID: 100098 RVA: 0x0079F584 File Offset: 0x0079D984
	public Skill2312(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018703 RID: 100099 RVA: 0x0079F610 File Offset: 0x0079DA10
	public override void OnInit()
	{
		base.OnInit();
		this.mTargetBulletId = (BattleMain.IsModePvP(base.owner.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true));
		if (BattleMain.IsModePvP(base.battleType))
		{
			for (int i = 0; i < this.skillData.ValueG.Count; i++)
			{
				this.mBulletScale.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueG[i], base.level, true));
			}
		}
		else
		{
			for (int j = 0; j < this.skillData.ValueB.Count; j++)
			{
				this.mBulletScale.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueB[j], base.level, true));
			}
		}
		for (int k = 0; k < this.skillData.ValueC.Count; k++)
		{
			this.mTargetHurtID.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueC[k], base.level, true));
		}
		this.mHurtRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true), GlobalLogic.VALUE_1000);
		int num = 0;
		while (num < this.skillData.ValueE.Count && num < this.m_NormalHurtIdArr.Length)
		{
			this.m_NormalHurtIdArr[num] = TableManager.GetValueFromUnionCell(this.skillData.ValueE[num], base.level, true);
			num++;
		}
		int num2 = 0;
		while (num2 < this.skillData.ValueF.Count && num2 < this.m_BigHurtIdArr.Length)
		{
			this.m_BigHurtIdArr[num2] = TableManager.GetValueFromUnionCell(this.skillData.ValueF[num2], base.level, true);
			num2++;
		}
	}

	// Token: 0x06018704 RID: 100100 RVA: 0x0079F84A File Offset: 0x0079DC4A
	public override void OnPostInit()
	{
		if (base.owner == null)
		{
			return;
		}
		base.OnPostInit();
		this.GetChaserMgr();
	}

	// Token: 0x06018705 RID: 100101 RVA: 0x0079F864 File Offset: 0x0079DC64
	private void UpdateEquipData()
	{
		if (base.owner == null)
		{
			return;
		}
		this.m_SkillAttackAddRate = VRate.zero;
		List<BeMechanism> mechanismList = base.owner.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		for (int i = 0; i < mechanismList.Count; i++)
		{
			if (mechanismList[i].isRunning)
			{
				Mechanism2091 mechanism = mechanismList[i] as Mechanism2091;
				if (mechanism != null)
				{
					this.m_SkillAttackAddRate += mechanism.SkillAttackAddRate;
				}
			}
		}
	}

	// Token: 0x06018706 RID: 100102 RVA: 0x0079F8F7 File Offset: 0x0079DCF7
	private void AddSkillAttackRate(int count)
	{
		this.attackAddRate += this.m_SkillAttackAddRate.i * count;
		this.m_Skilling = true;
	}

	// Token: 0x06018707 RID: 100103 RVA: 0x0079F923 File Offset: 0x0079DD23
	private void ClearSkillAttackRate(int count)
	{
		this.attackAddRate -= this.m_SkillAttackAddRate.i * count;
		this.m_Skilling = false;
	}

	// Token: 0x06018708 RID: 100104 RVA: 0x0079F950 File Offset: 0x0079DD50
	public override bool CanUseSkill()
	{
		bool flag = base.CanUseSkill();
		this.GetChaserMgr();
		return this.mChaserMgr != null && this.mChaserMgr.GetChaserCount() > 0 && flag;
	}

	// Token: 0x06018709 RID: 100105 RVA: 0x0079F98C File Offset: 0x0079DD8C
	protected void RegisterHandle()
	{
		if (base.owner == null)
		{
			return;
		}
		this.mGenBulletHandle = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, new BeEventHandle.Del(this.OnAfterGenBullet));
		this.mDamageHandle = base.owner.RegisterEventNew(BeEventType.onReplaceHurtTableDamageData, new BeEvent.BeEventHandleNew.Function(this.ReplaceHurtTableDamageData));
	}

	// Token: 0x0601870A RID: 100106 RVA: 0x0079F9E4 File Offset: 0x0079DDE4
	public override void OnStart()
	{
		base.OnStart();
		this.GetChaserMgr();
		if (this.mChaserMgr == null)
		{
			return;
		}
		this.ClearSkillAttackRate(this.mChaserCount);
		this.GetChaserList();
		this.CompoundChaser();
		this.UpdateEquipData();
		this.AddSkillAttackRate(this.mChaserCount);
		this.GetChaserLevel();
		this.AddBuff();
		this.RemoveHandle();
		this.RegisterHandle();
	}

	// Token: 0x0601870B RID: 100107 RVA: 0x0079FA4C File Offset: 0x0079DE4C
	private void GetChaserLevel()
	{
		if (base.owner != null)
		{
			int skillLevel = base.owner.GetSkillLevel(2302);
			if (skillLevel == 0)
			{
				this.m_ChaserLevel = 1;
			}
			else
			{
				this.m_ChaserLevel = skillLevel;
			}
		}
	}

	// Token: 0x0601870C RID: 100108 RVA: 0x0079FA90 File Offset: 0x0079DE90
	private void OnAfterGenBullet(object[] args)
	{
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile == null)
		{
			return;
		}
		if (beProjectile.m_iResID == this.mTargetBulletId)
		{
			int num = this.mChaserList.Count - 1;
			if (num < this.mBulletScale.Count)
			{
				beProjectile.SetScale(this.mBulletScale[num]);
			}
			else
			{
				Logger.LogErrorFormat("炫纹强压 大小修正错误：{0}缩放系数没配", new object[]
				{
					num
				});
			}
		}
	}

	// Token: 0x0601870D RID: 100109 RVA: 0x0079FB14 File Offset: 0x0079DF14
	protected void ReplaceHurtTableDamageData(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (this.mTargetHurtID.Contains(@int))
		{
			int[] chaserMixHurtIdArr = this.GetChaserMixHurtIdArr();
			if (chaserMixHurtIdArr == null)
			{
				return;
			}
			int num = 0;
			VPercent a = VPercent.zero;
			bool flag = BattleMain.IsModePvP(base.battleType);
			for (int i = 0; i < chaserMixHurtIdArr.Length; i++)
			{
				EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(chaserMixHurtIdArr[i], string.Empty, string.Empty);
				num += TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageFixedValue : tableItem.DamageFixedValuePVP, this.m_ChaserLevel, true);
				a += TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageRate : tableItem.DamageRatePVP, this.m_ChaserLevel, true);
			}
			param.m_Int2 = num * this.mHurtRate;
			param.m_Percent = new VPercent((a.precent * this.mHurtRate).single);
		}
	}

	// Token: 0x0601870E RID: 100110 RVA: 0x0079FC24 File Offset: 0x0079E024
	protected int[] GetChaserMixHurtIdArr()
	{
		if (this.mChaserList == null)
		{
			Logger.LogErrorFormat("炫纹强压数据为空，请检查,当前技能ID{0}", new object[]
			{
				base.owner.m_iCurSkillID
			});
			return null;
		}
		List<int> list = ListPool<int>.Get();
		for (int i = 0; i < this.mChaserList.Count; i++)
		{
			Mechanism2072.ChaserData chaserData = this.mChaserList[i];
			int type = (int)chaserData.type;
			int sizeType = (int)chaserData.sizeType;
			base.owner.TriggerEventNew(BeEventType.onChaserUse, new EventParam
			{
				m_Int = (int)chaserData.sizeType,
				m_Int2 = (int)chaserData.type
			});
			list.Add((sizeType != 0) ? this.m_BigHurtIdArr[type] : this.m_NormalHurtIdArr[type]);
		}
		int[] result = list.ToArray();
		ListPool<int>.Release(list);
		return result;
	}

	// Token: 0x0601870F RID: 100111 RVA: 0x0079FD03 File Offset: 0x0079E103
	public override void OnFinish()
	{
		this.mChaserList.Clear();
		base.OnFinish();
	}

	// Token: 0x06018710 RID: 100112 RVA: 0x0079FD16 File Offset: 0x0079E116
	public override void OnCancel()
	{
		base.OnCancel();
		this.mChaserList.Clear();
	}

	// Token: 0x06018711 RID: 100113 RVA: 0x0079FD2C File Offset: 0x0079E12C
	private void GetChaserList()
	{
		if (this.mChaserMgr == null)
		{
			return;
		}
		this.mChaserList.Clear();
		this.mChaserCount = this.mChaserMgr.GetChaserCount();
		this.mChaserMgr.LaunchChaser(this.mChaserCount, this.mChaserList);
		this.mChaserMgr.ReduceChaserCount(this.mChaserCount);
	}

	// Token: 0x06018712 RID: 100114 RVA: 0x0079FD8C File Offset: 0x0079E18C
	private void AddBuff()
	{
		int[] array2;
		if (BattleMain.IsModePvP(base.battleType))
		{
			int[] array = new int[]
			{
				230201,
				230211,
				230241,
				230231,
				230221
			};
			array2 = array;
		}
		else
		{
			int[] array3 = new int[]
			{
				230200,
				230210,
				230240,
				230230,
				230220
			};
			array2 = array3;
		}
		for (int i = 0; i < this.mChaserList.Count; i++)
		{
			int type = (int)this.mChaserList[i].type;
			if (type < array2.Length)
			{
				base.owner.buffController.TryAddBuffInfo(array2[type], base.owner, this.m_ChaserLevel);
			}
		}
	}

	// Token: 0x06018713 RID: 100115 RVA: 0x0079FE30 File Offset: 0x0079E230
	private void CompoundChaser()
	{
		if (base.owner == null)
		{
			return;
		}
		if (this.mChaserList == null)
		{
			return;
		}
		float num = 1f;
		if (this.skillSpeed > 0)
		{
			num = 1000f / (float)this.skillSpeed;
		}
		float num2 = 0.5f * num;
		float num3 = 0.5f * num;
		Vector3 vector = this.mCenterPos;
		vector.x = ((!base.owner.GetFace()) ? this.mCenterPos.x : (this.mCenterPos.x * -1f));
		if (this.mChaserCount == 1)
		{
			if (this.mChaserList.Count == 1)
			{
				Mechanism2072.ChaserData data = this.mChaserList[0];
				Sequence sequence = DOTween.Sequence();
				if (data != null && data.effect != null)
				{
					if (data.effect.GetRootNode() != null)
					{
						TweenSettingsExtensions.Append(sequence, TweenSettingsExtensions.SetEase<Tweener>(ShortcutExtensions.DOLocalMove(data.effect.GetRootNode().transform, vector, num3 + num2, false), 14));
					}
					if (base.owner != null && base.owner.m_pkGeActor != null)
					{
						TweenSettingsExtensions.OnComplete<Sequence>(sequence, delegate()
						{
							if (data.effect != null && this.owner != null && this.owner.m_pkGeActor != null)
							{
								this.owner.m_pkGeActor.DestroyEffect(data.effect);
							}
						});
					}
					TweenExtensions.Play<Sequence>(sequence);
				}
			}
		}
		else
		{
			float num4 = 360f / (float)this.mChaserList.Count;
			Sequence sequence2 = DOTween.Sequence();
			for (int i = 0; i < this.mChaserList.Count; i++)
			{
				float num5 = num4 * (float)i;
				float num6 = (float)this.mRotateRadius * Mathf.Cos(num5 * 3.14f / 180f);
				float num7 = (float)this.mRotateRadius * Mathf.Sin(num5 * 3.14f / 180f);
				Vector3 vector2;
				vector2..ctor(num6, num7, 0f);
				Mechanism2072.ChaserData data = this.mChaserList[i];
				Sequence sequence3 = DOTween.Sequence();
				if (data != null && data.effect != null)
				{
					if (data.effect.GetRootNode() != null)
					{
						TweenSettingsExtensions.Append(sequence3, TweenSettingsExtensions.SetEase<Tweener>(ShortcutExtensions.DOLocalMove(data.effect.GetRootNode().transform, vector + vector2, num2, false), 6));
						TweenSettingsExtensions.Append(sequence3, TweenSettingsExtensions.SetEase<Tweener>(ShortcutExtensions.DOLocalMove(data.effect.GetRootNode().transform, vector, num3, false), 14));
					}
					if (base.owner != null && base.owner.m_pkGeActor != null)
					{
						TweenSettingsExtensions.OnComplete<Sequence>(sequence3, delegate()
						{
							if (data.effect != null && this.owner != null && this.owner.m_pkGeActor != null)
							{
								this.owner.m_pkGeActor.DestroyEffect(data.effect);
							}
						});
					}
				}
				TweenSettingsExtensions.Join(sequence2, sequence3);
			}
			TweenExtensions.Play<Sequence>(sequence2);
		}
	}

	// Token: 0x06018714 RID: 100116 RVA: 0x007A0154 File Offset: 0x0079E554
	private void GetChaserMgr()
	{
		if (base.owner == null)
		{
			return;
		}
		if (this.mChaserMgr != null)
		{
			return;
		}
		BeMechanism mechanism = base.owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			return;
		}
		Mechanism2072 mechanism2 = mechanism as Mechanism2072;
		this.mChaserMgr = mechanism2;
	}

	// Token: 0x06018715 RID: 100117 RVA: 0x007A019F File Offset: 0x0079E59F
	private void RemoveHandle()
	{
		if (this.mGenBulletHandle != null)
		{
			this.mGenBulletHandle.Remove();
			this.mGenBulletHandle = null;
		}
		if (this.mDamageHandle != null)
		{
			this.mDamageHandle.Remove();
			this.mDamageHandle = null;
		}
	}

	// Token: 0x04011A17 RID: 72215
	private readonly Vector3 mCenterPos = new Vector3(-0.5f, 2.5f, 0f);

	// Token: 0x04011A18 RID: 72216
	private readonly int mRotateRadius = 1;

	// Token: 0x04011A19 RID: 72217
	private List<Mechanism2072.ChaserData> mChaserList = new List<Mechanism2072.ChaserData>();

	// Token: 0x04011A1A RID: 72218
	private int mChaserCount;

	// Token: 0x04011A1B RID: 72219
	private Mechanism2072 mChaserMgr;

	// Token: 0x04011A1C RID: 72220
	private BeEventHandle mGenBulletHandle;

	// Token: 0x04011A1D RID: 72221
	private BeEvent.BeEventHandleNew mDamageHandle;

	// Token: 0x04011A1E RID: 72222
	private int mTargetBulletId;

	// Token: 0x04011A1F RID: 72223
	private List<int> mBulletScale = new List<int>();

	// Token: 0x04011A20 RID: 72224
	private HashSet<int> mTargetHurtID = new HashSet<int>();

	// Token: 0x04011A21 RID: 72225
	private VFactor mHurtRate = VFactor.one;

	// Token: 0x04011A22 RID: 72226
	protected int[] m_NormalHurtIdArr = new int[5];

	// Token: 0x04011A23 RID: 72227
	protected int[] m_BigHurtIdArr = new int[5];

	// Token: 0x04011A24 RID: 72228
	private VRate m_SkillAttackAddRate = VRate.zero;

	// Token: 0x04011A25 RID: 72229
	private bool m_Skilling;

	// Token: 0x04011A26 RID: 72230
	private int m_ChaserLevel = 1;
}
