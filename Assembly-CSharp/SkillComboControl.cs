using System;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x020045C5 RID: 17861
public class SkillComboControl : Singleton<SkillComboControl>
{
	// Token: 0x06019126 RID: 102694 RVA: 0x007E8F48 File Offset: 0x007E7348
	public void Init(BeDungeon data, int roomID)
	{
		this.battleEnd = false;
		this.hasPassed = false;
		this.hasFinished = false;
		this.monitorSkillID = 0;
		this.dungeonData = data;
		this.roomID = roomID;
		if (this.dungeonData == null)
		{
			return;
		}
		this.curActor = BattleMain.instance.GetLocalPlayer(0UL).playerActor;
		if (this.curActor == null)
		{
			return;
		}
		this.systemBattle = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle);
		if (this.systemBattle == null)
		{
			return;
		}
		this.battleFrame = (Singleton<ClientSystemManager>.instance.GetFrame(typeof(InstituteBattleFrame)) as InstituteBattleFrame);
		if (this.battleFrame == null)
		{
			return;
		}
		this.battle = (BattleMain.instance.GetBattle() as TrainingSkillComboBattle);
		if (this.battle == null || this.battle.teachData == null)
		{
			return;
		}
		this.institueData = Singleton<TableManager>.instance.GetDataByDungeonID(this.curActor.professionID, roomID);
		if (this.institueData == null)
		{
			return;
		}
		this.skillList = this.battle.teachData.datas.ToList<ComboData>();
		if (this.skillList.Count == 0)
		{
			return;
		}
		this.AddBuff();
		if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<SkillComboFrame>(null))
		{
			this.frame = (Singleton<ClientSystemManager>.instance.OpenFrame<SkillComboFrame>(FrameLayer.Middle, null, string.Empty) as SkillComboFrame);
		}
		this.battle.playerHitCallBack = new Action<int, int>(this.PlayerHitOther);
		this.hasPassed = (DataManager<MissionManager>.GetInstance().GetState(this.institueData) == 1);
		if (this.institueData.Type == 2)
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.CastDunFu());
		}
		else if (this.institueData.DifficultyType == 1)
		{
			this.frame.InitSkillComboUI(this.curActor.professionID, roomID, true);
			this.battleFrame.SetControlContainer(false);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.InstitueTeach());
		}
		else
		{
			this.battleFrame.SetControlContainer(true);
			if (this.hasPassed)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.StartCastSkill());
			}
			else
			{
				InputManager.instance.SetEnable(false);
				Singleton<ClientSystemManager>.instance.OpenFrame<ComboSkipFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}
	}

	// Token: 0x06019127 RID: 102695 RVA: 0x007E91A4 File Offset: 0x007E75A4
	private void AddBuff()
	{
		if (this.institueData == null)
		{
			return;
		}
		if (this.curActor == null)
		{
			return;
		}
		for (int i = 0; i < this.institueData.BuffID.Count; i++)
		{
			this.curActor.buffController.TryAddBuff(this.institueData.BuffID[i], null, false, null, 0);
		}
	}

	// Token: 0x06019128 RID: 102696 RVA: 0x007E9210 File Offset: 0x007E7610
	private void PlayerHitOther(int skillID, int id)
	{
		if (this.hasFailed)
		{
			this.ShowTip();
			return;
		}
		BeSkill skill = this.curActor.GetSkill(skillID);
		if (skill == null)
		{
			return;
		}
		if (this.monitorSkillID == 0)
		{
			return;
		}
		if (skill.comboSkillSourceID != 0)
		{
			this.ExecuteSkill(id);
		}
		else
		{
			this.ExecuteSkill(skillID);
		}
	}

	// Token: 0x06019129 RID: 102697 RVA: 0x007E9270 File Offset: 0x007E7670
	private void ExecuteSkill(int skillID)
	{
		if (skillID == this.monitorSkillID)
		{
			if (this.currentItem == null)
			{
				return;
			}
			this.currentItem.StopComboCD();
			this.index++;
			if (this.index >= this.frame.GetComboItemList().Count)
			{
				if (this.hasFinished)
				{
					return;
				}
				this.hasFinished = true;
				if (this.battleFrame != null)
				{
					this.battleFrame.SetBtnEnable(false);
				}
				SystemNotifyManager.SysDungeonSkillTip("挑战完成", 3f, false);
				Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(2000, delegate
				{
					this.battle.EndInstitueTrain();
				}, 0, 0, false);
				return;
			}
			else
			{
				this.currentItem = this.frame.GetShowItem(this.index);
				this.currentItem.StartComboCD();
				this.SetMonitorSkillID(this.currentItem.skillID);
			}
		}
	}

	// Token: 0x0601912A RID: 102698 RVA: 0x007E9364 File Offset: 0x007E7764
	public void StartHellGuide(BeDungeon dungeon)
	{
		int id = dungeon.GetDungeonDataManager().CurrentAreaID();
		this.dungeonData = dungeon;
		MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.StartGuide(id));
	}

	// Token: 0x0601912B RID: 102699 RVA: 0x007E9398 File Offset: 0x007E7798
	private IEnumerator StartGuide(int id)
	{
		if (id == 23101)
		{
			return new ProcessUnit().Append(this._WaitForSeconds(0.2f)).Append(this._waitForDialog(50002)).Append(this._ShowDungeonDesFrame(id)).Sequence();
		}
		if (id == 23131)
		{
			return new ProcessUnit().Append(this._WaitForSeconds(0.2f)).Append(this._ShowDungeonDesFrame(id)).Sequence();
		}
		return new ProcessUnit().Sequence();
	}

	// Token: 0x0601912C RID: 102700 RVA: 0x007E9424 File Offset: 0x007E7824
	private IEnumerator _WaitForSeconds(float time)
	{
		yield return Yielders.GetWaitForSeconds(time);
		yield break;
	}

	// Token: 0x0601912D RID: 102701 RVA: 0x007E9440 File Offset: 0x007E7840
	private IEnumerator _ShowDungeonDesFrame(int roomID)
	{
		Singleton<ClientSystemManager>.instance.OpenFrame<DungeonInfoFrame>(FrameLayer.Middle, roomID, string.Empty);
		yield break;
	}

	// Token: 0x0601912E RID: 102702 RVA: 0x007E945C File Offset: 0x007E785C
	public void RestartPracticeFight()
	{
		if (this.institueData != null && this.institueData.Type == 2)
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.PracticeDunFu());
		}
		else
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.ReturnPractice());
		}
	}

	// Token: 0x0601912F RID: 102703 RVA: 0x007E94AC File Offset: 0x007E78AC
	private IEnumerator ReturnPractice()
	{
		return new ProcessUnit().Append(this.RecreateEntity()).Append(this.StartPractice()).Sequence();
	}

	// Token: 0x06019130 RID: 102704 RVA: 0x007E94D0 File Offset: 0x007E78D0
	public void RestartTeachFight()
	{
		if (this.institueData != null && this.institueData.Type == 2)
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.RestartTeachDunFu());
		}
		else
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.Restart());
		}
	}

	// Token: 0x06019131 RID: 102705 RVA: 0x007E9520 File Offset: 0x007E7920
	private IEnumerator Restart()
	{
		if (InputManager.instance != null)
		{
			InputManager.instance.SetEnable(false);
		}
		if (this.dungeonData != null)
		{
			this.dungeonData.ResumeFight(true, string.Empty, false);
		}
		this.DestroyEffect();
		return new ProcessUnit().Append(this.RecreateEntity()).Append(this._WaitForSeconds(0.3f)).Append(this.RestartTeach()).Sequence();
	}

	// Token: 0x06019132 RID: 102706 RVA: 0x007E9598 File Offset: 0x007E7998
	private IEnumerator RestartTeach()
	{
		if (this.institueData.DifficultyType == 1)
		{
			return new ProcessUnit().Append(this.InitUI(true)).Append(this.FreazeMonsters(-1, true, false)).Append(this.StartToTeachFight()).Append(this.ReturnPractice()).Sequence();
		}
		this.SetBattleFrame(1);
		return new ProcessUnit().Append(this.InitData()).Append(this.InitUI(false)).Append(this.LoadTeachEffect(false)).Append(this.StartSkill(0)).Sequence();
	}

	// Token: 0x06019133 RID: 102707 RVA: 0x007E9634 File Offset: 0x007E7A34
	private IEnumerator InitUI(bool showArrow)
	{
		if (this.curActor != null)
		{
			this.frame.InitSkillComboUI(this.curActor.professionID, this.roomID, showArrow);
		}
		yield break;
	}

	// Token: 0x06019134 RID: 102708 RVA: 0x007E9658 File Offset: 0x007E7A58
	private IEnumerator InitData()
	{
		this.hasFailed = false;
		InputManager.instance.SetVisible(false);
		this.battle.UseSkillCallBack = null;
		if (this.battleFrame != null)
		{
			this.battleFrame.SetControlContainer(true);
		}
		yield break;
	}

	// Token: 0x06019135 RID: 102709 RVA: 0x007E9673 File Offset: 0x007E7A73
	public void SetEndBattle()
	{
		this.battleEnd = true;
	}

	// Token: 0x06019136 RID: 102710 RVA: 0x007E967C File Offset: 0x007E7A7C
	private void CreateHPBar()
	{
		if (this.curActor == null || this.curActor.m_pkGeActor == null)
		{
			return;
		}
		this.curActor.m_pkGeActor.CreateHPBarCharactor((int)ClientApplication.playerinfo.seat);
	}

	// Token: 0x06019137 RID: 102711 RVA: 0x007E96B4 File Offset: 0x007E7AB4
	private void DestroyHPBar()
	{
		if (this.curActor == null || this.curActor.m_pkGeActor == null)
		{
			return;
		}
		this.curActor.m_pkGeActor.DestroySelfHPBar();
	}

	// Token: 0x06019138 RID: 102712 RVA: 0x007E96E4 File Offset: 0x007E7AE4
	public IEnumerator StartCastSkill()
	{
		if (this.hasPassed)
		{
			this.frame.InitSkillComboUI(this.curActor.professionID, this.roomID, true);
			return new ProcessUnit().Append(this.StartPractice()).Sequence();
		}
		this.frame.InitSkillComboUI(this.curActor.professionID, this.roomID, false);
		this.SetBattleFrame(1);
		InputManager.instance.SetVisible(false);
		return new ProcessUnit().Append(this.LoadTeachEffect(false)).Append(this.StartSkill(0)).Sequence();
	}

	// Token: 0x06019139 RID: 102713 RVA: 0x007E9780 File Offset: 0x007E7B80
	private IEnumerator StartSkill(int index)
	{
		if (this.battleEnd)
		{
			yield break;
		}
		if (index >= this.skillList.Count)
		{
			yield return this.ReturnPractice();
			yield break;
		}
		float skillTime = 0f;
		float moveTime = 0f;
		float idleTime = 0f;
		int moveDir = 0;
		int skillID = 0;
		ComboData item = this.battle.GetComboData(index);
		if (item != null)
		{
			skillTime = (float)item.skillTime / 1000f;
			moveTime = (float)item.moveTime / 1000f;
			idleTime = (float)item.idleTime / 1000f;
			moveDir = item.moveDir;
		}
		skillID = this.skillList[index].skillID;
		if (moveTime > 0f)
		{
			this.FireMoveCommand((short)moveDir, moveTime);
			yield return new WaitForSeconds(moveTime);
			InputManager.instance.FireStopCommand();
			yield return new WaitForSeconds(idleTime);
		}
		if (this.curActor == null)
		{
			yield break;
		}
		BeSkill skill = this.curActor.GetSkill(skillID);
		if (skill.comboSkillSourceID != 0)
		{
			skillID = skill.comboSkillSourceID;
		}
		this.curActor.SetFace(item.faceRight != 1, true, true);
		this.frame.ShowComboItemEffect(item.skillGroupID);
		InputManager.instance.CreateSkillFrameCommand(skillID, 0);
		InputManager.instance.CreateSkillFrameCommand(skillID, 1);
		float preTime = Time.realtimeSinceStartup;
		yield return new WaitForSeconds(skillTime);
		index++;
		yield return this.StartSkill(index);
		yield break;
	}

	// Token: 0x0601913A RID: 102714 RVA: 0x007E97A4 File Offset: 0x007E7BA4
	private void FireMoveCommand(short nDegree, float moveTime)
	{
		if (this.delayUnit.IsValid())
		{
			this.delayUnit.SetRemove(true);
		}
		int time = 0;
		bool runing = true;
		this.delayUnit = Singleton<ClientSystemManager>.instance.delayCaller.RepeatCall(30, delegate
		{
			if (!runing)
			{
				return;
			}
			time += 30;
			if ((float)time > moveTime * 1000f - 30f)
			{
				if (this.delayUnit.IsValid())
				{
					this.delayUnit.SetRemove(true);
				}
				runing = false;
				return;
			}
			MoveFrameCommand cmd = new MoveFrameCommand
			{
				degree = nDegree,
				run = true
			};
			FrameSync.instance.FireFrameCommand(cmd, false);
			FrameSync.instance.bInRunMode = true;
			FrameSync.instance.nDegree = (int)nDegree;
		}, 999, true);
	}

	// Token: 0x0601913B RID: 102715 RVA: 0x007E9820 File Offset: 0x007E7C20
	private IEnumerator InstitueTeach()
	{
		if (this.hasPassed)
		{
			return new ProcessUnit().Append(this.StartPractice()).Sequence();
		}
		return new ProcessUnit().Append(this.FreazeMonsters(-1, true, false)).Append(this.StartToTeachFight()).Append(this.ReturnPractice()).Sequence();
	}

	// Token: 0x0601913C RID: 102716 RVA: 0x007E987C File Offset: 0x007E7C7C
	private IEnumerator StartToTeachFight()
	{
		this.hasFailed = false;
		this.SetBattleFrame(1);
		SkillComboItem.timeOutCallBack = delegate()
		{
			if (this.institueData.DifficultyType == 2)
			{
				this.ShowTip();
			}
			if (this.institueData.DifficultyType == 1)
			{
				this.RestartTeachFight();
			}
		};
		InputManager.instance.SetVisible(false, true);
		InputManager.instance.SetEnable(false);
		return new ProcessUnit().Append(this.LoadTeachEffect(true)).Append(this._Guide2()).Sequence();
	}

	// Token: 0x0601913D RID: 102717 RVA: 0x007E98E0 File Offset: 0x007E7CE0
	private void SetBattleFrame(int type)
	{
		if (this.battleFrame == null)
		{
			return;
		}
		if (type == 1)
		{
			this.SetMonitorSkillID(0);
			this.DestroyHPBar();
			this.battleFrame.SetEffectState(false);
			this.battleFrame.SetTitle(0);
			this.battleFrame.SetBtnState(false);
		}
		else
		{
			this.battleFrame.ResetTimeScale();
			this.battleFrame.SetControlContainer(false);
			this.battleFrame.SetEffectState(false);
			this.battleFrame.SetTitle(1);
			this.battleFrame.SetBtnState(true);
		}
	}

	// Token: 0x0601913E RID: 102718 RVA: 0x007E9971 File Offset: 0x007E7D71
	private void DestroyEffect()
	{
		this.DestroyEffectObj();
		this.DestroyTip();
	}

	// Token: 0x0601913F RID: 102719 RVA: 0x007E9980 File Offset: 0x007E7D80
	private IEnumerator RecreateEntity()
	{
		if (this.battle != null && BattleMain.instance != null && BattleMain.instance.GetLocalPlayer(0UL) != null)
		{
			this.battle.RecreatePlayer();
			this.curActor = BattleMain.instance.GetLocalPlayer(0UL).playerActor;
			this.AddBuff();
			BeUtility.ResetCamera();
		}
		yield break;
	}

	// Token: 0x06019140 RID: 102720 RVA: 0x007E999C File Offset: 0x007E7D9C
	private IEnumerator StartPractice()
	{
		this.ResetPracticeUI();
		this.dungeonData.ResumeFight(true, string.Empty, false);
		SkillComboItem.timeOutCallBack = delegate()
		{
			this.ShowTip();
		};
		yield return this.LoadPracticeEffect();
		this.WaitInputSkill();
		yield break;
	}

	// Token: 0x06019141 RID: 102721 RVA: 0x007E99B8 File Offset: 0x007E7DB8
	private void ResetPracticeUI()
	{
		this.hasFailed = false;
		this.CreateHPBar();
		this.DestroyEffect();
		if (this.frame != null && this.curActor != null)
		{
			this.frame.InitSkillComboUI(this.curActor.professionID, this.roomID, true);
		}
		this.SetBattleFrame(2);
		if (InputManager.instance != null)
		{
			InputManager.instance.SetEnable(false);
		}
	}

	// Token: 0x06019142 RID: 102722 RVA: 0x007E9A27 File Offset: 0x007E7E27
	private void WaitInputSkill()
	{
		this.flag = false;
		this.index = 0;
		this.battle.UseSkillCallBack = delegate(int id)
		{
			if (this.index >= this.skillList.Count)
			{
				return;
			}
			if (this.index == 0)
			{
				if (this.flag)
				{
					return;
				}
				this.flag = true;
				this.currentItem = this.frame.GetShowItem(0);
				if (this.currentItem != null)
				{
					this.currentItem.StartComboCD();
					this.SetMonitorSkillID(this.currentItem.skillID);
				}
			}
			if (this.curActor == null)
			{
				return;
			}
			BeSkill skill = this.curActor.GetSkill(id);
			if (skill != null && skill.isBuffSkill)
			{
				this.ExecuteSkill(id);
			}
		};
	}

	// Token: 0x06019143 RID: 102723 RVA: 0x007E9A4E File Offset: 0x007E7E4E
	private void SetMonitorSkillID(int skillID)
	{
		this.monitorSkillID = skillID;
	}

	// Token: 0x06019144 RID: 102724 RVA: 0x007E9A58 File Offset: 0x007E7E58
	public void ShowTip()
	{
		if (this.battleFrame != null)
		{
			this.battleFrame.SetEffectState(true);
		}
		this.hasFailed = true;
		SkillComboItem.timeOutCallBack = null;
		if (this.tip != null)
		{
			return;
		}
		this.tip = SystemNotifyManager.SysDungeonSkillTip("挑战失败，请点击重置", 3f, false);
	}

	// Token: 0x06019145 RID: 102725 RVA: 0x007E9AB4 File Offset: 0x007E7EB4
	private IEnumerator _waitForDialog(int id)
	{
		if (id <= 0)
		{
			yield break;
		}
		this.dungeonData.PauseFight(true, string.Empty, false);
		bool isFinish = false;
		TaskDialogFrame.OnDialogOver task = new TaskDialogFrame.OnDialogOver();
		task.AddListener(delegate
		{
			isFinish = true;
		});
		DataManager<MissionManager>.GetInstance().CreateDialogFrame(id, 0, task);
		while (!isFinish)
		{
			yield return Yielders.EndOfFrame;
		}
		this.dungeonData.ResumeFight(true, string.Empty, false);
		yield break;
	}

	// Token: 0x06019146 RID: 102726 RVA: 0x007E9AD6 File Offset: 0x007E7ED6
	private IEnumerator _Guide2()
	{
		return new ProcessUnit().Append(this.StartSkillCombo(0)).Append(this.DestroyEffectobj()).Append(this.UnFreazeMonsters(-1, true)).Sequence();
	}

	// Token: 0x06019147 RID: 102727 RVA: 0x007E9B08 File Offset: 0x007E7F08
	private IEnumerator StartSkillCombo(int index)
	{
		InputManager.needJoystickOnTouch = false;
		if (index >= this.skillList.Count)
		{
			yield break;
		}
		InputManager.instance.SetEnable(true);
		this.SetAllSkillBtnState(false);
		this.dungeonData.PauseFight(true, string.Empty, false);
		SkillComboItem comboItem = this.frame.GetShowItem(index);
		int skillID = 0;
		if (comboItem != null)
		{
			skillID = comboItem.skillID;
			if (index != 0)
			{
				comboItem.StartComboCD();
			}
			comboItem.SelectCurrent();
		}
		bool bInput = false;
		ETCButton btn = this.GetSkillBtn(skillID);
		if (btn != null)
		{
			this.effectObj = this.LoadUIEffect(btn.gameObject, "UIFlatten/Prefabs/NewbieGuide/ButtonTipsNoButton_newbiebattle", true);
			this.effectObj.transform.localPosition = Vector3.zero;
			btn.activated = true;
		}
		this.battle.UseSkillCallBack = delegate(int id)
		{
			if (index == 0)
			{
				comboItem.StartComboCD();
			}
			if (bInput)
			{
				return;
			}
			if (id == skillID || (id == 2147483646 && skillID == 9990))
			{
				this.SetAllSkillBtnState(false);
				InputManager.instance.CreateSkillFrameCommand(skillID, 1);
				index++;
				this.DestroyTip();
				this.DestroyEffectObj();
				bInput = true;
				this.dungeonData.ResumeFight(true, string.Empty, false);
				if (comboItem != null)
				{
					comboItem.StopComboCD();
				}
			}
		};
		while (!bInput)
		{
			yield return Yielders.EndOfFrame;
		}
		float waitTime = 0f;
		waitTime = (float)this.skillList[index - 1].skillTime / 1000f;
		if (index >= this.skillList.Count)
		{
			this.SetAllSkillBtnState(true);
		}
		yield return Yielders.GetWaitForSeconds(waitTime);
		yield return this.StartSkillCombo(index);
		yield break;
	}

	// Token: 0x06019148 RID: 102728 RVA: 0x007E9B2C File Offset: 0x007E7F2C
	private IEnumerator DestroyEffectobj()
	{
		this.DestroyEffectObj();
		yield break;
	}

	// Token: 0x06019149 RID: 102729 RVA: 0x007E9B48 File Offset: 0x007E7F48
	private IEnumerator FreazeMonsters(int id = -1, bool isMonster = true, bool modifyMonsterData = true)
	{
		List<BeEntity> fullEntities = this.dungeonData.GetBeScene().GetFullEntities();
		for (int i = 0; i < fullEntities.Count; i++)
		{
			BeActor beActor = fullEntities[i] as BeActor;
			bool flag = false;
			if (isMonster)
			{
				if (beActor != null && beActor.IsMonster() && (id == -1 || id == beActor.GetEntityData().monsterID))
				{
					flag = true;
				}
			}
			else if (beActor != null && beActor.GetCamp() == 0 && (id == -1 || id == beActor.GetEntityData().monsterID))
			{
				BeEntity playerActor = this.dungeonData.GetDungeonPlayerDataManager().GetMainPlayer().playerActor;
				if (beActor != playerActor)
				{
					flag = true;
				}
			}
			if (flag)
			{
				beActor.buffController.TryAddBuff(68, -1, 1);
				beActor.hasAI = false;
				beActor.Reset();
				if (modifyMonsterData)
				{
					beActor.GetEntityData().battleData.dodge = 0;
				}
			}
		}
		yield break;
	}

	// Token: 0x0601914A RID: 102730 RVA: 0x007E9B78 File Offset: 0x007E7F78
	private IEnumerator UnFreazeMonsters(int id = -1, bool isMonster = true)
	{
		if (this.dungeonData != null && this.dungeonData.GetBeScene() != null)
		{
			List<BeEntity> fullEntities = this.dungeonData.GetBeScene().GetFullEntities();
			for (int i = 0; i < fullEntities.Count; i++)
			{
				BeActor beActor = fullEntities[i] as BeActor;
				bool flag = false;
				if (isMonster)
				{
					if (beActor != null && beActor.IsMonster() && (id == -1 || id == beActor.GetEntityData().monsterID))
					{
						flag = true;
					}
				}
				else if (beActor != null && beActor.GetCamp() == 0 && (id == -1 || id == beActor.GetEntityData().monsterID))
				{
					BeEntity playerActor = this.dungeonData.GetDungeonPlayerDataManager().GetMainPlayer().playerActor;
					if (beActor != playerActor)
					{
						flag = true;
					}
				}
				if (flag)
				{
					beActor.buffController.RemoveBuff(68, 0, 0);
					beActor.hasAI = true;
					beActor.Reset();
					beActor.StartAI(null, true);
				}
			}
		}
		yield break;
	}

	// Token: 0x0601914B RID: 102731 RVA: 0x007E9BA4 File Offset: 0x007E7FA4
	private IEnumerator CastDunFu()
	{
		if (this.hasPassed)
		{
			if (this.battleFrame != null)
			{
				this.battleFrame.SetControlContainer(false);
			}
			this.frame.InitSkillComboUI(this.curActor.professionID, this.roomID, true);
			return new ProcessUnit().Append(this.StartDunFuPractice()).Append(this.ResetUI()).Append(this.CastSkill()).Sequence();
		}
		if (this.battleFrame != null)
		{
			this.battleFrame.SetControlContainer(true);
		}
		this.frame.InitSkillComboUI(this.curActor.professionID, this.roomID, false);
		this.SetBattleFrame(1);
		InputManager.instance.SetVisible(false);
		return new ProcessUnit().Append(this.LoadTeachEffect(true)).Append(this.TeachCastSkill()).Append(this.SetAttackButtonState()).Append(this._WaitForSeconds(1f)).Append(this.PracticeDunFu()).Sequence();
	}

	// Token: 0x0601914C RID: 102732 RVA: 0x007E9CAC File Offset: 0x007E80AC
	private IEnumerator SetAttackButtonState()
	{
		if (this.curActor != null)
		{
			this.curActor.SetAttackButtonState(ButtonState.PRESS, true);
		}
		yield return Yielders.GetWaitForSeconds(2f);
		if (this.curActor != null)
		{
			this.curActor.SetAttackButtonState(ButtonState.RELEASE, true);
		}
		yield break;
	}

	// Token: 0x0601914D RID: 102733 RVA: 0x007E9CC7 File Offset: 0x007E80C7
	private IEnumerator PracticeDunFu()
	{
		return new ProcessUnit().Append(this.RecreateEntity()).Append(this.StartDunFuPractice()).Append(this.ResetUI()).Append(this.CastSkill()).Sequence();
	}

	// Token: 0x0601914E RID: 102734 RVA: 0x007E9D00 File Offset: 0x007E8100
	private IEnumerator RestartTeachDunFu()
	{
		if (this.battleFrame != null)
		{
			this.battleFrame.SetControlContainer(true);
		}
		this.DestroyEffect();
		this.frame.InitSkillComboUI(this.curActor.professionID, this.roomID, false);
		this.SetBattleFrame(1);
		return new ProcessUnit().Append(this.RecreateEntity()).Append(this.HideInputmanager()).Append(this.LoadTeachEffect(true)).Append(this.TeachCastSkill()).Append(this.SetAttackButtonState()).Append(this._WaitForSeconds(2f)).Append(this.PracticeDunFu()).Sequence();
	}

	// Token: 0x0601914F RID: 102735 RVA: 0x007E9DAC File Offset: 0x007E81AC
	private IEnumerator HideInputmanager()
	{
		InputManager.instance.SetVisible(false);
		yield break;
	}

	// Token: 0x06019150 RID: 102736 RVA: 0x007E9DC0 File Offset: 0x007E81C0
	private IEnumerator ResetUI()
	{
		this.ResetPracticeUI();
		this.dungeonData.ResumeFight(true, string.Empty, false);
		yield return this.LoadPracticeEffect();
		yield break;
	}

	// Token: 0x06019151 RID: 102737 RVA: 0x007E9DDC File Offset: 0x007E81DC
	private IEnumerator StartDunFuPractice()
	{
		if (this.battleFrame != null)
		{
			this.battleFrame.SetControlContainer(false);
		}
		if (InputManager.instance != null)
		{
			InputManager.instance.SetEnable(true);
			if (InputManager.instance.joystick != null)
			{
				InputManager.instance.joystick.visible = false;
			}
		}
		if (this.curActor != null)
		{
			this.curActor.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
			{
				ActionState actionState = (ActionState)args[0];
				if (actionState == ActionState.AS_GETUP)
				{
					if (this.curActor != null && this.curActor.GetCurrentBtnState() == ButtonState.PRESS)
					{
						if (this.frame != null)
						{
							SkillComboItem showItem = this.frame.GetShowItem(0);
							if (showItem != null)
							{
								showItem.StopComboCD();
							}
						}
						SkillComboItem.timeOutCallBack = null;
						SystemNotifyManager.SysDungeonSkillTip("挑战完成", 3f, false);
						Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(2000, delegate
						{
							if (this.battle != null)
							{
								this.battle.EndInstitueTrain();
							}
						}, 0, 0, false);
						if (this.battleFrame != null)
						{
							this.battleFrame.SetBtnEnable(false);
						}
					}
					else
					{
						this.ShowTip();
					}
				}
			});
		}
		yield break;
	}

	// Token: 0x06019152 RID: 102738 RVA: 0x007E9DF8 File Offset: 0x007E81F8
	private IEnumerator CastSkill()
	{
		BeActor actor = this.GetTargetPlayer();
		if (actor != null)
		{
			actor.UseSkill(5900, false);
		}
		SkillComboItem.timeOutCallBack = delegate()
		{
			this.ShowTip();
		};
		SkillComboItem item = this.frame.GetShowItem(0);
		if (item != null)
		{
			item.StartComboCD();
		}
		yield return new WaitForSeconds(2f);
		InputManager.instance.SetEnable(true);
		yield break;
	}

	// Token: 0x06019153 RID: 102739 RVA: 0x007E9E14 File Offset: 0x007E8214
	private IEnumerator TeachCastSkill()
	{
		BeActor actor = this.GetTargetPlayer();
		if (actor != null)
		{
			actor.UseSkill(5900, false);
		}
		yield return new WaitForSeconds(2f);
		yield break;
	}

	// Token: 0x06019154 RID: 102740 RVA: 0x007E9E30 File Offset: 0x007E8230
	private BeActor GetTargetPlayer()
	{
		if (this.curActor == null)
		{
			return null;
		}
		List<BeEntity> entities = this.curActor.CurrentBeScene.GetEntities();
		for (int i = 0; i < entities.Count; i++)
		{
			BeActor beActor = entities[i] as BeActor;
			if (beActor != null && !beActor.isLocalActor)
			{
				return beActor;
			}
		}
		return null;
	}

	// Token: 0x06019155 RID: 102741 RVA: 0x007E9E94 File Offset: 0x007E8294
	private ETCButton GetSkillBtn(int skillID)
	{
		ETCButton etcbutton = InputManager.instance.GetETCButton(skillID);
		if (etcbutton != null)
		{
			return etcbutton;
		}
		if (skillID == 9990)
		{
			return InputManager.instance.GetSpecialETCButton(SpecialSkillID.JUMP_BACK);
		}
		Logger.LogErrorFormat("该职业没有技能ID{0}", new object[]
		{
			skillID
		});
		return null;
	}

	// Token: 0x06019156 RID: 102742 RVA: 0x007E9EF0 File Offset: 0x007E82F0
	private IEnumerator LoadTeachEffect(bool enable = true)
	{
		if (this.battleFrame != null)
		{
			this.battleFrame.SetBtnEnable(false);
		}
		this.effect1 = this.LoadUIEffect(Singleton<ClientSystemManager>.instance.GetLayer(FrameLayer.Top), this.effectPath1, true);
		yield return new WaitForSeconds(1.5f);
		if (this.effect1 != null)
		{
			Object.Destroy(this.effect1);
			this.effect1 = null;
		}
		if (this.battleFrame != null)
		{
			this.battleFrame.SetBtnEnable(true);
		}
		this.AddBuffForEnemy();
		yield return new WaitForSeconds(1f);
		yield break;
	}

	// Token: 0x06019157 RID: 102743 RVA: 0x007E9F0C File Offset: 0x007E830C
	private IEnumerator LoadPracticeEffect()
	{
		if (this.battleFrame != null)
		{
			this.battleFrame.SetBtnEnable(false);
			this.effect2 = this.LoadUIEffect(this.battleFrame.GetFrame(), this.effectPath2, true);
		}
		yield return new WaitForSeconds(1.5f);
		if (this.effect2 != null)
		{
			Object.Destroy(this.effect2);
			this.effect2 = null;
		}
		yield return this.LoadStartEffect();
		yield return new WaitForSeconds(1f);
		this.AddBuffForEnemy();
		if (this.effect3 != null)
		{
			Object.Destroy(this.effect3);
			this.effect3 = null;
		}
		if (this.battleFrame != null)
		{
			this.battleFrame.SetBtnEnable(true);
		}
		InputManager.instance.SetEnable(true);
		yield break;
	}

	// Token: 0x06019158 RID: 102744 RVA: 0x007E9F28 File Offset: 0x007E8328
	private void AddBuffForEnemy()
	{
		BeActor targetPlayer = this.GetTargetPlayer();
		if (targetPlayer != null && this.institueData != null && this.institueData.EnemyBuffID.Count > 0)
		{
			int num = this.institueData.EnemyBuffID[0];
			if (targetPlayer.buffController.HasBuffByID(num) != null)
			{
				targetPlayer.buffController.RemoveBuff(num, 0, 0);
			}
			targetPlayer.buffController.TryAddBuff(num, -1, 1);
		}
		if (this.institueData != null && !string.IsNullOrEmpty(this.institueData.Tip))
		{
			SystemNotifyManager.SysDungeonSkillTip(this.institueData.Tip, 10f, false);
		}
	}

	// Token: 0x06019159 RID: 102745 RVA: 0x007E9FDC File Offset: 0x007E83DC
	private IEnumerator LoadStartEffect()
	{
		if (this.effect3 != null)
		{
			Object.Destroy(this.effect3);
			this.effect3 = null;
		}
		if (this.battleFrame != null)
		{
			this.effect3 = this.LoadUIEffect(this.battleFrame.GetFrame(), this.effectPath3, true);
		}
		yield break;
	}

	// Token: 0x0601915A RID: 102746 RVA: 0x007E9FF8 File Offset: 0x007E83F8
	public GameObject LoadUIEffect(GameObject parent, string path, bool bKeep = true)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		if (bKeep)
		{
			Utility.AttachTo(gameObject, parent, false);
		}
		else
		{
			Utility.AttachTo(gameObject, parent.transform.parent.gameObject, false);
			RectTransform component = parent.GetComponent<RectTransform>();
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			component2.position = component.position;
		}
		gameObject.transform.SetAsLastSibling();
		return gameObject;
	}

	// Token: 0x0601915B RID: 102747 RVA: 0x007EA063 File Offset: 0x007E8463
	private void SetAllSkillBtnState(bool flag)
	{
		InputManager.instance.joystick.activated = flag;
		InputManager.instance.EnableSkillButton(flag);
		this.GetSkillBtn(9990).activated = flag;
	}

	// Token: 0x0601915C RID: 102748 RVA: 0x007EA091 File Offset: 0x007E8491
	private void DestroyEffectObj()
	{
		if (this.effectObj != null)
		{
			Object.Destroy(this.effectObj);
			this.effectObj = null;
		}
	}

	// Token: 0x0601915D RID: 102749 RVA: 0x007EA0B6 File Offset: 0x007E84B6
	private void DestroyTip()
	{
		if (this.tip != null)
		{
			Object.Destroy(this.tip);
			this.tip = null;
		}
	}

	// Token: 0x04011FC4 RID: 73668
	private string effectPath1 = "Effects/UI/Prefab/EffUI_lianzhaoxitong/Prefab/EffUI_lianzhaoxitong_zhenqiancaoyan";

	// Token: 0x04011FC5 RID: 73669
	private string effectPath2 = "Effects/UI/Prefab/EffUI_lianzhaoxitong/Prefab/EffUI_lianzhaoxitong_zhenjiantiaozhan";

	// Token: 0x04011FC6 RID: 73670
	private string effectPath3 = "Effects/UI/Prefab/EffUI_lianzhaoxitong/Prefab/EffUI_lianzhaoxitong_kaishi";

	// Token: 0x04011FC7 RID: 73671
	private int roomID;

	// Token: 0x04011FC8 RID: 73672
	public int monitorSkillID;

	// Token: 0x04011FC9 RID: 73673
	private GameObject effectObj;

	// Token: 0x04011FCA RID: 73674
	private GameObject tip;

	// Token: 0x04011FCB RID: 73675
	private BeDungeon dungeonData;

	// Token: 0x04011FCC RID: 73676
	private List<ComboData> skillList;

	// Token: 0x04011FCD RID: 73677
	private BeActor curActor;

	// Token: 0x04011FCE RID: 73678
	private SkillComboFrame frame;

	// Token: 0x04011FCF RID: 73679
	private ClientSystemBattle systemBattle;

	// Token: 0x04011FD0 RID: 73680
	private TrainingSkillComboBattle battle;

	// Token: 0x04011FD1 RID: 73681
	private InstituteTable institueData;

	// Token: 0x04011FD2 RID: 73682
	private InstituteBattleFrame battleFrame;

	// Token: 0x04011FD3 RID: 73683
	public bool hasPassed;

	// Token: 0x04011FD4 RID: 73684
	private bool hasFinished;

	// Token: 0x04011FD5 RID: 73685
	private bool battleEnd;

	// Token: 0x04011FD6 RID: 73686
	private DelayCallUnitHandle delayUnit;

	// Token: 0x04011FD7 RID: 73687
	private bool hasFailed;

	// Token: 0x04011FD8 RID: 73688
	private int index;

	// Token: 0x04011FD9 RID: 73689
	private bool flag;

	// Token: 0x04011FDA RID: 73690
	private SkillComboItem currentItem;

	// Token: 0x04011FDB RID: 73691
	private GameObject effect1;

	// Token: 0x04011FDC RID: 73692
	private GameObject effect2;

	// Token: 0x04011FDD RID: 73693
	private GameObject effect3;
}
