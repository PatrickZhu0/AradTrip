using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020042D5 RID: 17109
public class Mechanism1161 : BeMechanism
{
	// Token: 0x06017ABF RID: 96959 RVA: 0x0074B9DC File Offset: 0x00749DDC
	public Mechanism1161(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017AC0 RID: 96960 RVA: 0x0074BA70 File Offset: 0x00749E70
	public override void OnInit()
	{
		base.OnInit();
		this._transRateArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._transRateArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this._hpTransPercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this._shixueTransPercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true), GlobalLogic.VALUE_1000);
		this._trasnMaxValueArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this._trasnMaxValueArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
		this._normalAttackConsumePercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
		this._skillConsumePercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueD[1], this.level, true), GlobalLogic.VALUE_1000);
		this._compareDataList.Clear();
		for (int i = 0; i < this.data.ValueE.Count; i++)
		{
			Mechanism1161.CompareData item = default(Mechanism1161.CompareData);
			item.min = this.data.ValueE[i].fixInitValue;
			item.max = this.data.ValueE[i].fixLevelGrow;
			item.buffId = TableManager.GetValueFromUnionCell(this.data.ValueF[i], this.level, true);
			this._compareDataList.Add(item);
		}
	}

	// Token: 0x06017AC1 RID: 96961 RVA: 0x0074BC96 File Offset: 0x0074A096
	public override void OnStart()
	{
		base.OnStart();
		this._InitMaxValue();
		this._RegisterEvent();
	}

	// Token: 0x06017AC2 RID: 96962 RVA: 0x0074BCAA File Offset: 0x0074A0AA
	public override void OnFinish()
	{
		base.OnFinish();
		this._ResetData();
		this._RemoveHandle();
	}

	// Token: 0x06017AC3 RID: 96963 RVA: 0x0074BCC0 File Offset: 0x0074A0C0
	private void _InitMaxValue()
	{
		if (base.owner.attribute != null)
		{
			this._trasnMaxValueArr[0] *= base.owner.attribute.GetLevel();
			this._trasnMaxValueArr[1] *= base.owner.attribute.GetLevel();
		}
	}

	// Token: 0x06017AC4 RID: 96964 RVA: 0x0074BD20 File Offset: 0x0074A120
	private void _RegisterEvent()
	{
		this._handleList.Add(base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this._OnBeforeHit)));
		this._handleList.Add(base.owner.RegisterEvent(BeEventType.OnBuffDamage, new BeEventHandle.Del(this._OnBuffDamage)));
		this._handleList.Add(base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this._OnCastSkill)));
		this._handleList.Add(base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, new BeEventHandle.Del(this._OnBeHitAfterFinalDamage)));
		this._handleList.Add(base.owner.RegisterEvent(BeEventType.AbnormalBuffHurt, new BeEventHandle.Del(this._OnAbnormalBuffHurt)));
	}

	// Token: 0x06017AC5 RID: 96965 RVA: 0x0074BDE8 File Offset: 0x0074A1E8
	private void _OnBeforeHit(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		int num = base.FrameRandom.InRange(0, GlobalLogic.VALUE_1000);
		if (beActor.stateController.HasBuffState(BeBuffStateType.BLEEDING) && num <= this._transRateArr[0])
		{
			int num2 = beActor.attribute.GetHP() * this._hpTransPercent;
			num2 = IntMath.Min(num2, this._trasnMaxValueArr[0]);
			this._AddValue(num2);
		}
		this._CheckCompareValueAndAddBuff();
	}

	// Token: 0x06017AC6 RID: 96966 RVA: 0x0074BE6C File Offset: 0x0074A26C
	private void _OnBuffDamage(object[] args)
	{
		int num = base.FrameRandom.InRange(0, GlobalLogic.VALUE_1000);
		if (num > this._transRateArr[1])
		{
			return;
		}
		int i = (int)args[0];
		int value = (int)args[1];
		if (Array.IndexOf<int>(this._buffIdArr, value) < 0)
		{
			return;
		}
		int value2 = IntMath.Min(i * this._shixueTransPercent, this._trasnMaxValueArr[1]);
		this._AddValue(value2);
	}

	// Token: 0x06017AC7 RID: 96967 RVA: 0x0074BEE0 File Offset: 0x0074A2E0
	private void _AddValue(int value)
	{
		this._curValue += value;
		if (!this._haveProduce && this._curValue > 0)
		{
			this._maxValue = base.owner.attribute.GetMaxHP();
			this._CreateUI();
			this._haveProduce = true;
		}
		this._curValue = IntMath.Min(this._curValue, this._maxValue);
		this._RefreshEnergrUI(this._curValue);
	}

	// Token: 0x06017AC8 RID: 96968 RVA: 0x0074BF58 File Offset: 0x0074A358
	private void _OnCastSkill(object[] args)
	{
		BeSkill beSkill = args[1] as BeSkill;
		if (beSkill == null)
		{
			return;
		}
		int value;
		if (beSkill.skillData.SkillCategory == 1)
		{
			value = this._curValue * this._normalAttackConsumePercent;
		}
		else
		{
			value = this._curValue * this._skillConsumePercent;
		}
		this._ReduceValue(value);
	}

	// Token: 0x06017AC9 RID: 96969 RVA: 0x0074BFB8 File Offset: 0x0074A3B8
	private void _OnBeHitAfterFinalDamage(object[] args)
	{
		int hurtId = (int)args[1];
		if (!BeUtility.NeedShareBySGSH(hurtId, base.owner))
		{
			return;
		}
		this._ChangeDamageValue(args[0] as int[]);
	}

	// Token: 0x06017ACA RID: 96970 RVA: 0x0074BFEE File Offset: 0x0074A3EE
	private void _OnAbnormalBuffHurt(object[] args)
	{
		this._ChangeDamageValue(args[1] as int[]);
	}

	// Token: 0x06017ACB RID: 96971 RVA: 0x0074BFFE File Offset: 0x0074A3FE
	private void _ChangeDamageValue(int[] values)
	{
		if (this._curValue >= values[0])
		{
			this._ReduceValue(values[0]);
			values[0] = 0;
		}
		else
		{
			values[0] -= this._curValue;
			this._ReduceValue(this._curValue);
		}
	}

	// Token: 0x06017ACC RID: 96972 RVA: 0x0074C040 File Offset: 0x0074A440
	private void _ReduceValue(int value)
	{
		if (!this._haveProduce)
		{
			return;
		}
		if (value < this._curValue)
		{
			this._curValue -= value;
			this._RefreshEnergrUI(this._curValue);
		}
		else
		{
			this._RefreshEnergrUI(this._curValue);
			this._ResetData();
		}
	}

	// Token: 0x06017ACD RID: 96973 RVA: 0x0074C096 File Offset: 0x0074A496
	private void _ResetData()
	{
		this._curValue = 0;
		this._haveProduce = false;
		this._DestroyUI();
	}

	// Token: 0x06017ACE RID: 96974 RVA: 0x0074C0AC File Offset: 0x0074A4AC
	private void _CheckCompareValueAndAddBuff()
	{
		int num = 0;
		for (int i = 0; i < this._compareDataList.Count; i++)
		{
			Mechanism1161.CompareData compareData = this._compareDataList[i];
			int num2 = this._maxValue * compareData.min / GlobalLogic.VALUE_1000;
			int num3 = this._maxValue * compareData.max / GlobalLogic.VALUE_1000;
			if (this._curValue > num2 && this._curValue <= num3)
			{
				num = compareData.buffId;
				break;
			}
		}
		if (num == 0)
		{
			return;
		}
		base.owner.buffController.TryAddBuff(num, 33, this.level);
	}

	// Token: 0x06017ACF RID: 96975 RVA: 0x0074C15C File Offset: 0x0074A55C
	private void _RemoveHandle()
	{
		for (int i = 0; i < this._handleList.Count; i++)
		{
			if (this._handleList[i] != null)
			{
				this._handleList[i].Remove();
				this._handleList[i] = null;
			}
		}
	}

	// Token: 0x06017AD0 RID: 96976 RVA: 0x0074C1B4 File Offset: 0x0074A5B4
	private void _CreateUI()
	{
		this._StartEnergyUI(this._maxValue);
	}

	// Token: 0x06017AD1 RID: 96977 RVA: 0x0074C1C2 File Offset: 0x0074A5C2
	private void _DestroyUI()
	{
		this.StopEnergyUI();
	}

	// Token: 0x06017AD2 RID: 96978 RVA: 0x0074C1CC File Offset: 0x0074A5CC
	protected void _StartEnergyUI(int maxValue)
	{
		GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(this._barPath, enResourceType.UIPrefab, 2U);
		if (gameObject == null)
		{
			return;
		}
		this._energyBar = gameObject.GetComponent<ComDungeonCharactorBarEnergy>();
		base.owner.m_pkGeActor.CreateBarRoot();
		GameObject hRoot = base.owner.m_pkGeActor.mBarsRoot.hRoot;
		Utility.AttachTo(gameObject, hRoot, false);
		this._energyBar.InitData((float)maxValue);
	}

	// Token: 0x06017AD3 RID: 96979 RVA: 0x0074C240 File Offset: 0x0074A640
	protected void _RefreshEnergrUI(int value)
	{
		if (this._energyBar == null)
		{
			return;
		}
		this._energyBar.RefreshData((float)value * 1f);
	}

	// Token: 0x06017AD4 RID: 96980 RVA: 0x0074C268 File Offset: 0x0074A668
	protected void StopEnergyUI()
	{
		if (this._energyBar == null)
		{
			return;
		}
		GameObject gameObject = this._energyBar.GetGameObject();
		Singleton<CGameObjectPool>.instance.RecycleGameObject(gameObject);
		this._energyBar = null;
	}

	// Token: 0x04011033 RID: 69683
	private int[] _transRateArr = new int[2];

	// Token: 0x04011034 RID: 69684
	private VFactor _hpTransPercent = VFactor.zero;

	// Token: 0x04011035 RID: 69685
	private VFactor _shixueTransPercent = VFactor.zero;

	// Token: 0x04011036 RID: 69686
	private int[] _trasnMaxValueArr = new int[2];

	// Token: 0x04011037 RID: 69687
	private VFactor _normalAttackConsumePercent = VFactor.zero;

	// Token: 0x04011038 RID: 69688
	private VFactor _skillConsumePercent = VFactor.zero;

	// Token: 0x04011039 RID: 69689
	private List<Mechanism1161.CompareData> _compareDataList = new List<Mechanism1161.CompareData>(3);

	// Token: 0x0401103A RID: 69690
	private List<BeEventHandle> _handleList = new List<BeEventHandle>();

	// Token: 0x0401103B RID: 69691
	private int _maxValue;

	// Token: 0x0401103C RID: 69692
	private readonly int[] _buffIdArr = new int[]
	{
		162201,
		162202,
		162215,
		162216
	};

	// Token: 0x0401103D RID: 69693
	private int _curValue;

	// Token: 0x0401103E RID: 69694
	private bool _haveProduce;

	// Token: 0x0401103F RID: 69695
	private string _barPath = "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorHeadEnergy";

	// Token: 0x04011040 RID: 69696
	protected ComDungeonCharactorBarEnergy _energyBar;

	// Token: 0x020042D6 RID: 17110
	private struct CompareData
	{
		// Token: 0x04011041 RID: 69697
		public int min;

		// Token: 0x04011042 RID: 69698
		public int max;

		// Token: 0x04011043 RID: 69699
		public int buffId;
	}
}
