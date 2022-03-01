using System;
using System.Collections.Generic;
using DG.Tweening;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x0200449F RID: 17567
public class Skill2310 : BeSkill
{
	// Token: 0x060186E9 RID: 100073 RVA: 0x0079E5F0 File Offset: 0x0079C9F0
	public Skill2310(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x17002013 RID: 8211
	// (get) Token: 0x060186EA RID: 100074 RVA: 0x0079E6A2 File Offset: 0x0079CAA2
	public string[] EffectPathArr
	{
		get
		{
			return this.m_EffectPathArr;
		}
	}

	// Token: 0x060186EB RID: 100075 RVA: 0x0079E6AC File Offset: 0x0079CAAC
	public override void OnInit()
	{
		base.OnInit();
		this.m_EntityIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.m_EntityIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true);
		this.m_EntityIdArr[2] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[2], base.level, true);
		this.m_EntityIdArr[3] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[3], base.level, true);
		this.m_BaseHurtIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.m_BaseHurtIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true);
		this.m_BaseHurtIdArr[2] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[2], base.level, true);
		this.m_BaseHurtIdArr[3] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[3], base.level, true);
		int num = 0;
		while (num < this.skillData.ValueC.Count && num < this.m_NormalHurtIdArr.Length)
		{
			this.m_NormalHurtIdArr[num] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[num], base.level, true);
			num++;
		}
		int num2 = 0;
		while (num2 < this.skillData.ValueD.Count && num2 < this.m_BigHurtIdArr.Length)
		{
			this.m_BigHurtIdArr[num2] = TableManager.GetValueFromUnionCell(this.skillData.ValueD[num2], base.level, true);
			num2++;
		}
		this.m_TargetAddMechanismIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
		this.m_TargetAddMechanismIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueE[1], base.level, true);
		this.m_CheckHurtIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true);
		this.m_CheckHurtIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueF[1], base.level, true);
		this.m_CheckHurtIdArr[2] = TableManager.GetValueFromUnionCell(this.skillData.ValueF[2], base.level, true);
		this.m_CheckHurtIdArr[3] = TableManager.GetValueFromUnionCell(this.skillData.ValueF[3], base.level, true);
		int n = (!BattleMain.IsModePvP(base.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueG[1], base.level, true);
		this.m_AddDamagePercent = VFactor.NewVFactor(n, GlobalLogic.VALUE_1000);
	}

	// Token: 0x060186EC RID: 100076 RVA: 0x0079E9CE File Offset: 0x0079CDCE
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.InitEffectData();
		this.GetChaserMgr();
	}

	// Token: 0x060186ED RID: 100077 RVA: 0x0079E9E4 File Offset: 0x0079CDE4
	public override bool CanUseSkill()
	{
		bool flag = base.CanUseSkill();
		this.GetChaserMgr();
		return this.mChaserMgr != null && this.mChaserMgr.GetChaserCount() >= this.ChaserCount && flag;
	}

	// Token: 0x060186EE RID: 100078 RVA: 0x0079EA28 File Offset: 0x0079CE28
	protected void InitEffectData()
	{
		this.m_EffectPathArr[0] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_rh_01_wu";
		this.m_EffectPathArr[1] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_rh_01_guang";
		this.m_EffectPathArr[2] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_rh_01_fire";
		this.m_EffectPathArr[3] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_rh_01_ice";
		this.m_EffectPathArr[4] = "Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_rh_01_an";
	}

	// Token: 0x060186EF RID: 100079 RVA: 0x0079EA78 File Offset: 0x0079CE78
	protected void RegisterHandle()
	{
		if (base.owner == null)
		{
			return;
		}
		this.m_HandleList.Add(base.owner.RegisterEvent(BeEventType.onChangeMagicElement, new BeEventHandle.Del(this.RegsiterChangeMagicElement)));
		this.m_HandleNewList.Add(base.owner.RegisterEventNew(BeEventType.onChangeMagicElementList, new BeEvent.BeEventHandleNew.Function(this.RegisterChangeMagicElementList)));
		this.m_HandleList.Add(base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, new BeEventHandle.Del(this.HitOther)));
		this.m_HandleNewList.Add(base.owner.RegisterEventNew(BeEventType.onReplaceHurtTableDamageData, new BeEvent.BeEventHandleNew.Function(this.ReplaceHurtTableDamageData)));
	}

	// Token: 0x060186F0 RID: 100080 RVA: 0x0079EB27 File Offset: 0x0079CF27
	public override void OnStart()
	{
		this.GetChaserLevel();
		base.OnStart();
		this.StartChaserMix();
		this.AddBuff();
		this.RemoveHandle();
		this.RegisterHandle();
	}

	// Token: 0x060186F1 RID: 100081 RVA: 0x0079EB50 File Offset: 0x0079CF50
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

	// Token: 0x060186F2 RID: 100082 RVA: 0x0079EB94 File Offset: 0x0079CF94
	private void StartChaserMix()
	{
		this.GetChaserMgr();
		if (this.mChaserMgr == null)
		{
			return;
		}
		if (this.m_ChaserList != null)
		{
			ListPool<Mechanism2072.ChaserData>.Release(this.m_ChaserList);
			this.m_ChaserList = null;
		}
		this.m_ChaserList = ListPool<Mechanism2072.ChaserData>.Get();
		this.m_ChaserList.Clear();
		this.mChaserMgr.LaunchChaser(this.ChaserCount, this.m_ChaserList);
		if (this.m_ChaserList != null)
		{
			this.mChaserMgr.ReduceChaserCount(this.m_ChaserList.Count);
		}
		this.CompoundChaser();
	}

	// Token: 0x060186F3 RID: 100083 RVA: 0x0079EC24 File Offset: 0x0079D024
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
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			int type = (int)this.m_ChaserList[i].type;
			if (type < array2.Length)
			{
				base.owner.buffController.TryAddBuffInfo(array2[type], base.owner, this.m_ChaserLevel);
			}
		}
	}

	// Token: 0x060186F4 RID: 100084 RVA: 0x0079ECC8 File Offset: 0x0079D0C8
	protected void RegsiterChangeMagicElement(object[] args)
	{
		int[] array = (int[])args[0];
		int value = array[1];
		int num = Array.IndexOf<int>(this.m_BaseHurtIdArr, value);
		if (num < 0)
		{
			return;
		}
		List<MagicElementType> list = ListPool<MagicElementType>.Get();
		this.GetMagicElementList(list);
		MagicElementType magicElementType = MagicElementType.NONE;
		int num2 = -1;
		for (int i = 1; i < 5; i++)
		{
			int num3 = base.owner.attribute.battleData.magicELements[i];
			int num4 = base.owner.attribute.battleData.magicElementsAttack[i];
			if (num3 > 0 || (list.Contains((MagicElementType)i) && num4 > num2))
			{
				num2 = num4;
				magicElementType = (MagicElementType)i;
			}
		}
		array[0] = (int)magicElementType;
		ListPool<MagicElementType>.Release(list);
	}

	// Token: 0x060186F5 RID: 100085 RVA: 0x0079ED94 File Offset: 0x0079D194
	protected void RegisterChangeMagicElementList(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		int num = Array.IndexOf<int>(this.m_BaseHurtIdArr, @int);
		if (num < 0)
		{
			return;
		}
		List<int> list = (List<int>)param.m_Obj;
		List<MagicElementType> list2 = ListPool<MagicElementType>.Get();
		this.GetMagicElementList(list2);
		for (int i = 0; i < list2.Count; i++)
		{
			if (!list.Contains((int)list2[i]))
			{
				list.Add((int)list2[i]);
			}
		}
		ListPool<MagicElementType>.Release(list2);
	}

	// Token: 0x060186F6 RID: 100086 RVA: 0x0079EE18 File Offset: 0x0079D218
	protected void HitOther(object[] args)
	{
		int num = (int)args[2];
		int num2 = Array.IndexOf<int>(this.m_CheckHurtIdArr, num);
		if (num2 < 0)
		{
			return;
		}
		BeActor beActor = args[1] as BeActor;
		if (beActor == null)
		{
			return;
		}
		VInt3 pos = (VInt3)args[6];
		this.CreateEntity(num2, pos);
		if (num2 > 1)
		{
			this.AddChargeMechanism(num, beActor);
		}
	}

	// Token: 0x060186F7 RID: 100087 RVA: 0x0079EE74 File Offset: 0x0079D274
	protected void CreateEntity(int hurtIdIndex, VInt3 pos)
	{
		if (base.owner == null)
		{
			return;
		}
		int entityID = this.m_EntityIdArr[hurtIdIndex];
		base.owner.AddEntity(entityID, pos, base.level, 0);
	}

	// Token: 0x060186F8 RID: 100088 RVA: 0x0079EEAC File Offset: 0x0079D2AC
	protected void AddChargeMechanism(int hurtId, BeActor target)
	{
		this.AddEffectToTarget(this.m_ChaserList, target);
		int[] chaserMixHurtIdArr = this.GetChaserMixHurtIdArr();
		int mid = (!BattleMain.IsModePvP(base.battleType)) ? this.m_TargetAddMechanismIdArr[0] : this.m_TargetAddMechanismIdArr[1];
		Mechanism2088 mechanism = target.AddMechanism(mid, base.level, MechanismSourceType.NONE, null, 0) as Mechanism2088;
		if (mechanism != null)
		{
			mechanism.InitData(chaserMixHurtIdArr, base.owner);
		}
	}

	// Token: 0x060186F9 RID: 100089 RVA: 0x0079EF1C File Offset: 0x0079D31C
	protected void ReplaceHurtTableDamageData(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		int num = Array.IndexOf<int>(this.m_BaseHurtIdArr, @int);
		if (num < 0 || num > 1)
		{
			return;
		}
		int[] chaserMixHurtIdArr = this.GetChaserMixHurtIdArr();
		if (chaserMixHurtIdArr == null)
		{
			return;
		}
		int num2 = 0;
		VPercent a = VPercent.zero;
		bool flag = BattleMain.IsModePvP(base.battleType);
		for (int i = 0; i < chaserMixHurtIdArr.Length; i++)
		{
			EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(chaserMixHurtIdArr[i], string.Empty, string.Empty);
			num2 += TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageFixedValue : tableItem.DamageFixedValuePVP, this.m_ChaserLevel, true);
			a += TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageRate : tableItem.DamageRatePVP, this.m_ChaserLevel, true);
		}
		param.m_Int2 = num2 * this.m_AddDamagePercent;
		param.m_Percent = new VPercent((a.precent * this.m_AddDamagePercent).single);
	}

	// Token: 0x060186FA RID: 100090 RVA: 0x0079F038 File Offset: 0x0079D438
	protected int[] GetChaserMixHurtIdArr()
	{
		int[] array = new int[2];
		if (this.m_ChaserList == null)
		{
			Logger.LogErrorFormat("炫纹融合数据为空，请检查", new object[0]);
			return null;
		}
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			Mechanism2072.ChaserData chaserData = this.m_ChaserList[i];
			int type = (int)chaserData.type;
			int sizeType = (int)chaserData.sizeType;
			array[i] = ((sizeType != 0) ? this.m_BigHurtIdArr[type] : this.m_NormalHurtIdArr[type]);
			base.owner.TriggerEventNew(BeEventType.onChaserUse, new EventParam
			{
				m_Int = (int)chaserData.sizeType,
				m_Int2 = (int)chaserData.type
			});
		}
		return array;
	}

	// Token: 0x060186FB RID: 100091 RVA: 0x0079F0F4 File Offset: 0x0079D4F4
	protected void GetMagicElementList(List<MagicElementType> list)
	{
		list.Clear();
		if (this.m_ChaserList == null)
		{
			Logger.LogErrorFormat("炫纹融合数据为空，请检查", new object[0]);
			return;
		}
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			Mechanism2072.ChaserData chaserData = this.m_ChaserList[i];
			int type = (int)chaserData.type;
			list.Add((MagicElementType)type);
		}
	}

	// Token: 0x060186FC RID: 100092 RVA: 0x0079F15C File Offset: 0x0079D55C
	private void CompoundChaser()
	{
		if (this.m_ChaserList == null)
		{
			return;
		}
		float num = 1f;
		if (this.skillSpeed > 0)
		{
			num = 1000f / (float)this.skillSpeed;
		}
		float num2 = 0.5f * num;
		Sequence sequence = DOTween.Sequence();
		if (sequence == null)
		{
			return;
		}
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			Mechanism2072.ChaserData data = this.m_ChaserList[i];
			if (data != null && data.effect != null && data.effect.GetRootNode() != null && base.owner != null && base.owner.m_pkGeActor != null)
			{
				TweenSettingsExtensions.Join(sequence, TweenSettingsExtensions.OnComplete<Tweener>(ShortcutExtensions.DOLocalMove(data.effect.GetRootNode().transform, this.mEndPosOffset, num2, false), delegate()
				{
					if (data.effect != null && this.owner != null && this.owner.m_pkGeActor != null)
					{
						this.owner.m_pkGeActor.DestroyEffect(data.effect);
					}
				}));
			}
		}
		TweenExtensions.Play<Sequence>(sequence);
	}

	// Token: 0x060186FD RID: 100093 RVA: 0x0079F28C File Offset: 0x0079D68C
	public void AddEffectToTarget(List<Mechanism2072.ChaserData> list, BeActor actor)
	{
		if (actor == null)
		{
			return;
		}
		if (actor.m_pkGeActor == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			int type = (int)list[i].type;
			string effectPath = this.m_EffectPathArr[type];
			string locator = "[actor]Orign";
			float num = actor.m_pkGeActor.GetOverHeadPosition().y;
			if (num <= 0f && actor.GetEntityData() != null)
			{
				num = actor.GetEntityData().overHeadHeight;
				if (num == 0f)
				{
					num = 3f;
				}
			}
			GeEffectEx effect = actor.m_pkGeActor.CreateEffect(effectPath, locator, 3400f, Vec3.zero, 1f, 1f, true, actor.GetFace(), EffectTimeType.SYNC_ANIMATION, false);
			if (effect != null)
			{
				if (i > 0)
				{
					effect.SetLocalRotation(Quaternion.Euler(new Vector3(0f, 0f, 180f)));
				}
				Vector3 localPosition;
				localPosition..ctor(0f, num / 2f, 0f);
				effect.SetLocalPosition(localPosition);
				actor.delayCaller.DelayCall(3400, delegate
				{
					if (effect != null)
					{
						effect.Remove();
					}
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x060186FE RID: 100094 RVA: 0x0079F3E0 File Offset: 0x0079D7E0
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

	// Token: 0x060186FF RID: 100095 RVA: 0x0079F42C File Offset: 0x0079D82C
	protected void RemoveHandle()
	{
		for (int i = 0; i < this.m_HandleNewList.Count; i++)
		{
			if (this.m_HandleNewList[i] != null)
			{
				this.m_HandleNewList[i].Remove();
				this.m_HandleNewList[i] = null;
			}
		}
		for (int j = 0; j < this.m_HandleList.Count; j++)
		{
			if (this.m_HandleList[j] != null)
			{
				this.m_HandleList[j].Remove();
				this.m_HandleList[j] = null;
			}
		}
	}

	// Token: 0x04011A07 RID: 72199
	protected int[] m_EntityIdArr = new int[4];

	// Token: 0x04011A08 RID: 72200
	protected int[] m_CheckHurtIdArr = new int[4];

	// Token: 0x04011A09 RID: 72201
	protected int[] m_BaseHurtIdArr = new int[4];

	// Token: 0x04011A0A RID: 72202
	protected int[] m_NormalHurtIdArr = new int[5];

	// Token: 0x04011A0B RID: 72203
	protected int[] m_BigHurtIdArr = new int[5];

	// Token: 0x04011A0C RID: 72204
	protected int[] m_TargetAddMechanismIdArr = new int[2];

	// Token: 0x04011A0D RID: 72205
	private readonly Vector3 mEndPosOffset = new Vector3(0f, 2f, 0f);

	// Token: 0x04011A0E RID: 72206
	private Mechanism2072 mChaserMgr;

	// Token: 0x04011A0F RID: 72207
	private readonly int ChaserCount = 2;

	// Token: 0x04011A10 RID: 72208
	private List<Mechanism2072.ChaserData> m_ChaserList;

	// Token: 0x04011A11 RID: 72209
	protected List<BeEventHandle> m_HandleList = new List<BeEventHandle>();

	// Token: 0x04011A12 RID: 72210
	protected List<BeEvent.BeEventHandleNew> m_HandleNewList = new List<BeEvent.BeEventHandleNew>();

	// Token: 0x04011A13 RID: 72211
	protected BeEvent.BeEventHandleNew m_EntityRemoveHandle;

	// Token: 0x04011A14 RID: 72212
	protected VFactor m_AddDamagePercent = VFactor.zero;

	// Token: 0x04011A15 RID: 72213
	private int m_ChaserLevel = 1;

	// Token: 0x04011A16 RID: 72214
	protected string[] m_EffectPathArr = new string[5];
}
