using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200017C RID: 380
public class InputManager
{
	// Token: 0x06000AA5 RID: 2725 RVA: 0x00036C00 File Offset: 0x00035000
	public void LoadButtonJoystick(int slotPressed, BeActor actor, int skillID, bool isUp = false, SkillJoystickMode mode = SkillJoystickMode.NONE)
	{
		if (isUp)
		{
			return;
		}
		this.button = this.mButtonMap[slotPressed];
		if (this.button == null)
		{
			return;
		}
		this.owner = actor;
		this.EnableSkillButton(false);
		this.recordVx = (this.recordVy = 0);
		this.startTime = Time.realtimeSinceStartup;
		this.skillId = skillID;
		this.InitJoystickPrefab(mode);
		this.buttonJoystick.canRemoveJoystick = true;
		this.buttonJoystick.onMove = delegate(int vx, int vy, int degree)
		{
			this.OnMove(vx, vy, degree);
		};
		this.buttonJoystick.onUpdate = delegate(int v)
		{
			this.OnUpdate(v);
		};
		this.buttonJoystick.onRelease = delegate(int degree, bool hasDrag)
		{
			this.OnRelease(degree, hasDrag);
		};
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x00036CC4 File Offset: 0x000350C4
	private void InitJoystickPrefab(SkillJoystickMode mode)
	{
		string path = this.commonPath;
		if (mode == SkillJoystickMode.SELECTSEAT)
		{
			path = this.selectSeatStickPath;
		}
		if (this.goButtonJoystick == null)
		{
			this.joystickGoDic.Clear();
			this.joystickScriptDic.Clear();
		}
		if (!this.joystickGoDic.ContainsKey(mode))
		{
			this.goButtonJoystick = (Singleton<AssetLoader>.instance.LoadRes(path, true, 0U).obj as GameObject);
			this.buttonJoystick = this.goButtonJoystick.GetComponent<HGJoyStick>();
			this.joystickGoDic.Add(mode, this.goButtonJoystick);
			this.joystickScriptDic.Add(mode, this.buttonJoystick);
			this.goButtonJoystick.SetActive(false);
			if (mode == SkillJoystickMode.SELECTSEAT)
			{
				this.InitSelectSeatJoystick();
			}
		}
		else
		{
			this.goButtonJoystick = this.joystickGoDic[mode];
			this.buttonJoystick = this.joystickScriptDic[mode];
			if (mode == SkillJoystickMode.SELECTSEAT)
			{
				this.ResetSelectData();
			}
		}
		this.goButtonJoystick.SetActive(true);
		Utility.AttachTo(this.goButtonJoystick, this.button.transform.parent.gameObject, false);
		this.goButtonJoystick.transform.position = this.button.transform.position;
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x00036E16 File Offset: 0x00035216
	public void RemoveButtonJoystick2(int skillID)
	{
		if (this.goButtonJoystick == null)
		{
			return;
		}
		if (!this.goButtonJoystick.activeSelf)
		{
			return;
		}
		this.RemoveButtonJoystick(skillID);
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x00036E44 File Offset: 0x00035244
	private void OnMove(int vx, int vy, int degree)
	{
		BeSkill skill = this.owner.GetSkill(this.skillId);
		if (this.skillId > 0 && skill != null && skill.joystickMode == SkillJoystickMode.FREE && this.skillId > 0 && skill != null && skill.innerState == BeSkill.InnerState.CHOOSE_TARGET && ((int)this.recordVx != vx || (int)this.recordVy != vy))
		{
			this.recordVx = (short)vx;
			this.recordVy = (short)vy;
			this.CreateSkillFrameCommand(this.skillId, (vx + GlobalLogic.VALUE_1000) * GlobalLogic.VALUE_10000 + vy + GlobalLogic.VALUE_1000);
		}
		if (skill != null && (int)this.recordJoystickDegree != degree && skill.joystickMode != SkillJoystickMode.SELECTSEAT)
		{
			this.recordJoystickDegree = (short)degree;
			this.CreateSkillFrameCommand(this.skillId, 100000000 + degree);
		}
		if (this.skillId > 0 && skill != null && skill.joystickMode == SkillJoystickMode.SELECTSEAT)
		{
			this.SelectSeatMove(degree);
		}
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x00036F48 File Offset: 0x00035348
	private void OnUpdate(int v)
	{
		BeSkill skill = this.owner.GetSkill(this.skillId);
		if (skill != null && this.buttonJoystick.canRemoveJoystick != skill.canRemoveJoystick)
		{
			this.buttonJoystick.canRemoveJoystick = skill.canRemoveJoystick;
		}
		if (skill != null && skill.joystickMode == SkillJoystickMode.FREE && skill.innerState == BeSkill.InnerState.LAUNCH)
		{
			this.RemoveButtonJoystick(this.skillId);
			this.ReleaseCaptureButton(this.button);
		}
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x00036FCC File Offset: 0x000353CC
	private void OnRelease(int degree, bool hasDrag)
	{
		BeSkill skill = this.owner.GetSkill(this.skillId);
		if (skill == null)
		{
			return;
		}
		float duration = Time.realtimeSinceStartup - this.startTime;
		this.DefaultRelease(skill, duration, hasDrag, degree);
		this.SpecialSkillRelease(skill, duration, hasDrag, degree);
		this.SelectSeatRelease(skill, duration, hasDrag, degree);
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x0003701D File Offset: 0x0003541D
	private void UpButtonJoystick(int skillID)
	{
		this.CreateSkillFrameCommand(skillID, 100);
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x00037028 File Offset: 0x00035428
	private void RemoveButtonJoystick(int skillID)
	{
		this.CreateSkillFrameCommand(skillID, 1);
		this.DisableSkillJoystick();
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x00037038 File Offset: 0x00035438
	public void DisableSkillJoystick()
	{
		this.lastSelectIndex = 0;
		if (this.goButtonJoystick != null)
		{
			this.goButtonJoystick.SetActive(false);
		}
		if (this.buttonJoystick == null)
		{
			return;
		}
		this.buttonJoystick.onMove = null;
		this.buttonJoystick.onRelease = null;
		this.buttonJoystick.onUpdate = null;
		this.EnableSkillButton(true);
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x000370A6 File Offset: 0x000354A6
	public void ResetSkillJoystick()
	{
		this.DisableSkillJoystick();
		this.goButtonJoystick = null;
		this.joystickGoDic.Clear();
		this.joystickScriptDic.Clear();
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x000370CC File Offset: 0x000354CC
	private void ReleaseCaptureButton(ETCButton button)
	{
		ControlButtonAnimationInside component = button.GetComponent<ControlButtonAnimationInside>();
		if (component != null)
		{
			component.skillup();
		}
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x000370F4 File Offset: 0x000354F4
	private void DefaultRelease(BeSkill skill, float duration, bool hasDrag, int degree)
	{
		if (this.skillId > 0 && skill != null)
		{
			if (skill.canRemoveJoystick)
			{
				if (this.skillId == 2208 && duration < 0.3f)
				{
					this.UpButtonJoystick(this.skillId);
				}
				else
				{
					this.RemoveButtonJoystick(this.skillId);
					skill.ReleaseJoystick();
				}
			}
			else
			{
				this.UpButtonJoystick(this.skillId);
			}
		}
		this.ReleaseCaptureButton(this.button);
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x0003717C File Offset: 0x0003557C
	private void SpecialSkillRelease(BeSkill skill, float duration, bool hasDrag, int degree)
	{
		if (skill == null)
		{
			return;
		}
		if (skill.joystickMode == SkillJoystickMode.SPECIAL)
		{
			int num = 0;
			if (duration >= 0.05f && hasDrag)
			{
				if (degree >= 45 && degree < 135)
				{
					num = 1;
				}
				else if (degree >= 135 && degree < 225)
				{
					num = 0;
				}
				else if (degree >= 225 && degree < 315)
				{
					num = 2;
				}
				else
				{
					num = 0;
				}
			}
			this.CreateSkillFrameCommand(this.skillId, num + 2);
		}
		else if (skill.joystickMode == SkillJoystickMode.FORWARDBACK)
		{
			int num2 = 0;
			if (duration >= 0.05f && hasDrag)
			{
				if (degree >= 90 && degree < 270)
				{
					num2 = 1;
				}
				else
				{
					num2 = 0;
				}
			}
			if (!this.owner.GetFace())
			{
				if (num2 == 1)
				{
					num2 = 0;
				}
				else if (num2 == 0)
				{
					num2 = 1;
				}
			}
			this.CreateSkillFrameCommand(this.skillId, num2 + 10);
		}
	}

	// Token: 0x06000AB2 RID: 2738 RVA: 0x00037290 File Offset: 0x00035690
	private void SelectSeatRelease(BeSkill skill, float duration, bool hasDrag, int degree)
	{
		if (skill != null && skill.joystickMode == SkillJoystickMode.SELECTSEAT)
		{
			int selectIndexByDegree = this.GetSelectIndexByDegree(degree);
			this.CreateSkillFrameCommand(this.skillId, this.seatList[selectIndexByDegree] + 5);
		}
	}

	// Token: 0x06000AB3 RID: 2739 RVA: 0x000372D4 File Offset: 0x000356D4
	private int GetSelectIndexByDegree(int degree)
	{
		int index = 0;
		if ((degree >= 0 && degree < 70) || (degree >= 300 && degree < 360))
		{
			index = 2;
		}
		else if (degree >= 70 && degree < 180)
		{
			index = 1;
		}
		else if (degree >= 180 && degree < 280)
		{
			index = 0;
		}
		return this.CheckJoystickSelect(index);
	}

	// Token: 0x06000AB4 RID: 2740 RVA: 0x0003734C File Offset: 0x0003574C
	private void InitSelectJoystickUI()
	{
		this.selectSeatCommonBind = this.goButtonJoystick.GetComponent<ComCommonBind>();
		this.iconImageArr[0] = this.selectSeatCommonBind.GetCom<Image>("PlayerOneIcon");
		this.iconImageArr[1] = this.selectSeatCommonBind.GetCom<Image>("PlayerTwoIcon");
		this.iconImageArr[2] = this.selectSeatCommonBind.GetCom<Image>("PlayerThreeIcon");
		this.selectTransArr[0] = this.selectSeatCommonBind.GetCom<RectTransform>("PlayerOneSelect");
		this.selectTransArr[1] = this.selectSeatCommonBind.GetCom<RectTransform>("PlayerTwoSelect");
		this.selectTransArr[2] = this.selectSeatCommonBind.GetCom<RectTransform>("PlayerThreeSelect");
		this.headArr[0] = this.selectSeatCommonBind.GetCom<RectTransform>("PlayerOneHead");
		this.headArr[1] = this.selectSeatCommonBind.GetCom<RectTransform>("PlayerTwoHead");
		this.headArr[2] = this.selectSeatCommonBind.GetCom<RectTransform>("PlayerThreeHead");
		this.grayArr[0] = this.selectSeatCommonBind.GetCom<UIGray>("IconGrayOne");
		this.grayArr[1] = this.selectSeatCommonBind.GetCom<UIGray>("IconGrayTwo");
		this.grayArr[2] = this.selectSeatCommonBind.GetCom<UIGray>("IconGrayThree");
		this.selectHightColor[0] = this.selectSeatCommonBind.GetCom<Image>("SelectHightOne1");
		this.selectHightColor[1] = this.selectSeatCommonBind.GetCom<Image>("SelectHightOne2");
		this.selectHightColor[2] = this.selectSeatCommonBind.GetCom<Image>("SelectHightTwo1");
		this.selectHightColor[3] = this.selectSeatCommonBind.GetCom<Image>("SelectHightTwo2");
		this.selectHightColor[4] = this.selectSeatCommonBind.GetCom<Image>("SelectHightThree1");
		this.selectHightColor[5] = this.selectSeatCommonBind.GetCom<Image>("SelectHightThree2");
	}

	// Token: 0x06000AB5 RID: 2741 RVA: 0x0003751C File Offset: 0x0003591C
	private void InitSelectSeatJoystick()
	{
		this.InitSelectJoystickUI();
		this.lastSelectIndex = 0;
		this.seatList.Clear();
		if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null)
		{
			return;
		}
		List<BattlePlayer> list = BattleMain.instance.GetPlayerManager().GetAllPlayers();
		if (list == null)
		{
			return;
		}
		list = this.PlayerListSort(list, this.owner);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].playerActor != null)
			{
				int playerSeat = (int)list[i].GetPlayerSeat();
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)list[i].playerInfo.occupation, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						return;
					}
					if (!this.seatList.Contains(playerSeat))
					{
						this.seatList.Add(playerSeat);
					}
					this.InitPlayerData(i, tableItem2.IconPath);
				}
			}
		}
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x0003763A File Offset: 0x00035A3A
	private int GetPlayerCount()
	{
		if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null)
		{
			return 0;
		}
		if (BattleMain.IsModePvP(BattleMain.battleType))
		{
			return 0;
		}
		return BattleMain.instance.GetPlayerManager().GetPlayerCount();
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x00037678 File Offset: 0x00035A78
	private int CheckJoystickSelect(int index)
	{
		if (this.seatList == null)
		{
			return 0;
		}
		if (index >= this.seatList.Count)
		{
			return 0;
		}
		BeActor playerBySeat = this.GetPlayerBySeat(this.seatList[index]);
		if (playerBySeat == null)
		{
			return 0;
		}
		if (playerBySeat != null && playerBySeat.IsDead())
		{
			return 0;
		}
		return index;
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x000376D4 File Offset: 0x00035AD4
	private BeActor GetPlayerBySeat(int seat)
	{
		if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null)
		{
			return null;
		}
		BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat((byte)seat);
		if (playerBySeat == null)
		{
			return null;
		}
		return playerBySeat.playerActor;
	}

	// Token: 0x06000AB9 RID: 2745 RVA: 0x0003771C File Offset: 0x00035B1C
	private void InitPlayerData(int seat, string iconPath)
	{
		if (seat > 3)
		{
			return;
		}
		if (this.iconImageArr[seat] != null)
		{
			ETCImageLoader.LoadSprite(ref this.iconImageArr[seat], iconPath, true);
		}
		this.headArr[seat].gameObject.CustomActive(true);
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x0003776C File Offset: 0x00035B6C
	private void SelectSeatMove(int degree)
	{
		int selectIndexByDegree = this.GetSelectIndexByDegree(degree);
		if (selectIndexByDegree == this.lastSelectIndex)
		{
			return;
		}
		this.ChangeSeatSelect(selectIndexByDegree);
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x00037798 File Offset: 0x00035B98
	private void ResetSelectData()
	{
		for (int i = 0; i < this.headArr.Length; i++)
		{
			this.SetSingleData(i, false);
		}
		this.SetSingleData(0, true);
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x000377CE File Offset: 0x00035BCE
	private void ChangeSeatSelect(int curIndex)
	{
		if (curIndex > 3)
		{
			return;
		}
		this.SetSingleData(this.lastSelectIndex, false);
		this.SetSingleData(curIndex, true);
		this.lastSelectIndex = curIndex;
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x000377F4 File Offset: 0x00035BF4
	private List<BattlePlayer> PlayerListSort(List<BattlePlayer> list, BeActor owner)
	{
		int num = list.FindIndex((BattlePlayer x) => x.playerActor == owner);
		List<BattlePlayer> list2 = new List<BattlePlayer>();
		list2.Add(list[num]);
		for (int i = 0; i < list.Count; i++)
		{
			if (i != num)
			{
				list2.Add(list[i]);
			}
		}
		return list2;
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x00037860 File Offset: 0x00035C60
	private void SetSingleData(int index, bool isSelect)
	{
		if (index < 0 || index > 2)
		{
			return;
		}
		if (index >= this.seatList.Count)
		{
			return;
		}
		this.headArr[index].localScale = ((!isSelect) ? Vector3.one : new Vector3(1.2f, 1.2f, 1.2f));
		this.selectTransArr[index].gameObject.CustomActive(isSelect);
		BeActor playerBySeat = this.GetPlayerBySeat(this.seatList[index]);
		this.grayArr[index].enabled = (playerBySeat != null && playerBySeat.IsDead());
		int num = 0;
		int num2 = 0;
		if (index == 0)
		{
			num = 0;
			num2 = 1;
		}
		else if (index == 1)
		{
			num = 2;
			num2 = 3;
		}
		else if (index == 2)
		{
			num = 4;
			num2 = 5;
		}
		this.selectHightColor[num].color = ((!isSelect) ? new Color(0f, 0f, 0f, 0.5f) : new Color(1f, 1f, 1f, 0.5f));
		this.selectHightColor[num2].color = ((!isSelect) ? new Color(0f, 0f, 0f, 0.5f) : new Color(1f, 1f, 1f, 0.5f));
	}

	// Token: 0x06000ABF RID: 2751 RVA: 0x000379C3 File Offset: 0x00035DC3
	public static string GetEtcSkillRoot()
	{
		return InputManager.cEctSkillRootName[(int)InputManager.sEctSkillMode];
	}

	// Token: 0x06000AC0 RID: 2752 RVA: 0x000379D0 File Offset: 0x00035DD0
	public static string GetEtcSkillResPath()
	{
		return InputManager.cEctSkillResPath[(int)InputManager.sEctSkillMode];
	}

	// Token: 0x06000AC1 RID: 2753 RVA: 0x000379E0 File Offset: 0x00035DE0
	public void ForceJoyStickUp()
	{
		if (null == this.joystick)
		{
			return;
		}
		ExecuteEvents.Execute<IPointerDownHandler>(this.joystick.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
		ExecuteEvents.Execute<IPointerUpHandler>(this.joystick.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
	}

	// Token: 0x06000AC2 RID: 2754 RVA: 0x00037A3F File Offset: 0x00035E3F
	public InputUserData GetInputData()
	{
		return this.mUserDataDict[DataManager<PlayerBaseData>.GetInstance().JobTableID];
	}

	// Token: 0x06000AC3 RID: 2755 RVA: 0x00037A56 File Offset: 0x00035E56
	public int GetJobID()
	{
		return DataManager<PlayerBaseData>.GetInstance().JobTableID;
	}

	// Token: 0x06000AC4 RID: 2756 RVA: 0x00037A64 File Offset: 0x00035E64
	private InputUserData _getLocalInputData(int pid)
	{
		if (!this.mUserDataDict.ContainsKey(pid))
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(pid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("the JobTable don't contain the item with id : " + pid);
				return null;
			}
			InputUserData inputUserData = Singleton<AssetLoader>.instance.LoadRes(tableItem.InputConfigPath, true, 0U).obj as InputUserData;
			if (inputUserData == null)
			{
				Logger.LogError("the input data is nil");
				return null;
			}
			this.mUserDataDict.Add(pid, inputUserData);
		}
		return this.mUserDataDict[pid];
	}

	// Token: 0x06000AC5 RID: 2757 RVA: 0x00037B04 File Offset: 0x00035F04
	public int GetSkillIDBySlot(int pid, int slot)
	{
		Dictionary<int, int> dictionary = this._GetSlotMap();
		if (dictionary.ContainsKey(slot))
		{
			return dictionary[slot];
		}
		return -1;
	}

	// Token: 0x06000AC6 RID: 2758 RVA: 0x00037B2D File Offset: 0x00035F2D
	private void _clearSlot()
	{
		this.mUserDataDict.Clear();
		this.mLocalSlotMap.Clear();
		this.mServerSlotMap.Clear();
		this.mButtonMap.Clear();
		this.mDictSkillID.Clear();
	}

	// Token: 0x06000AC7 RID: 2759 RVA: 0x00037B68 File Offset: 0x00035F68
	public void ReloadButtons(int pid, BeActor actor, Dictionary<int, int> slotmap, bool hideJump = false)
	{
		this.UnloadActorConfig();
		this.controllActor = actor;
		this._clearSlot();
		this._loadButtonUI();
		this._addButtons(pid, slotmap);
		this.LoadActorConfig(actor);
		this.Update(1);
		if (hideJump)
		{
			this.HiddenJump();
		}
		else
		{
			this.ShowJump();
		}
	}

	// Token: 0x06000AC8 RID: 2760 RVA: 0x00037BBC File Offset: 0x00035FBC
	public Dictionary<int, int> GetServerSlotMap()
	{
		return this.mServerSlotMap;
	}

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x00037BC4 File Offset: 0x00035FC4
	public ETCJoystick joystick
	{
		get
		{
			return this.mJoystick;
		}
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x00037BCC File Offset: 0x00035FCC
	public GameObject GetJoyStick()
	{
		return this.mObJoyStick;
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x00037BD4 File Offset: 0x00035FD4
	private void _loadJoystickUI(InputManager.JoystickMode mode = InputManager.JoystickMode.DYNAMIC)
	{
		this.joystickMode = mode;
		GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.MiddleLayer, "ETCJoystick", false);
		if (gameObject != null)
		{
			Object.Destroy(gameObject);
		}
		string path = (mode != InputManager.JoystickMode.STATIC) ? "UIFlatten/Prefabs/ETCInput/ETCJoystick" : "UIFlatten/Prefabs/ETCInput/ETCJoystickStatic";
		this.mObJoyStick = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		if (this.mObJoyStick == null)
		{
			Logger.LogError("[InputManager] Can not find [UIFlatten/Prefabs/ETCInput/ETCJoystick] Prefabs,Please Check!");
			return;
		}
		this.mObJoyStick.name = "ETCJoystick";
		Utility.AttachTo(this.mObJoyStick, Singleton<ClientSystemManager>.instance.MiddleLayer, false);
		this.mObJoyStick.transform.SetAsLastSibling();
		this.mJoystick = this.mObJoyStick.GetComponent<ETCJoystick>();
		this.mJoystick.CustomActive(true);
		if (this.mJoystick == null)
		{
			Logger.LogError("[InputManager] ETCJoystick Not Find,Please Check [UIFlatten/Prefabs/ETCInput/ETCJoystick] Prefabs!");
		}
		else
		{
			this.mJoystick.onMove.AddListener(new UnityAction<Vector2>(this._onJoystickMove));
			this.mJoystick.onTouchUp.AddListener(new UnityAction(this._onJoystickMoveEnd));
			this.mJoystick.onTouchStart.AddListener(delegate()
			{
				this.CheckDoublePress();
			});
		}
	}

	// Token: 0x06000ACC RID: 2764 RVA: 0x00037D1D File Offset: 0x0003611D
	private void CheckDoublePress()
	{
		if (this.pressOne)
		{
			if (this.doubleCheckAcc <= Global.Settings.doublePressCheckDuration)
			{
				this._onDoublePress();
				this.StartCheckDoublePress();
			}
		}
		else
		{
			this.StartCheckDoublePress();
		}
	}

	// Token: 0x06000ACD RID: 2765 RVA: 0x00037D56 File Offset: 0x00036156
	private void StartCheckDoublePress()
	{
		this.doubleCheckAcc = 0;
		this.pressOne = true;
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x00037D66 File Offset: 0x00036166
	private void EndCheckDoublePress()
	{
		this.doubleCheckAcc = int.MaxValue;
		this.pressOne = false;
		this.doublePress = false;
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x00037D84 File Offset: 0x00036184
	private void UpdateCheckDoublePress(int delta)
	{
		if (!this.pressOne)
		{
			return;
		}
		this.doubleCheckAcc += delta;
		if (this.doubleCheckAcc > Global.Settings.doublePressCheckDuration && !this.doublePress)
		{
			this.EndCheckDoublePress();
		}
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x00037DD1 File Offset: 0x000361D1
	private void _onDoublePress()
	{
		this.doublePress = true;
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x00037DDC File Offset: 0x000361DC
	private void _unloadJoystickUI()
	{
		if (this.mObJoyStick != null)
		{
			Object.Destroy(this.mObJoyStick);
			this.mObJoyStick = null;
		}
		if (null != this.joystick)
		{
			this.joystick.onMove.RemoveListener(new UnityAction<Vector2>(this._onJoystickMove));
			this.joystick.onTouchUp.RemoveListener(new UnityAction(this._onJoystickMoveEnd));
			this.mJoystick = null;
		}
		this.mUserConfig = null;
	}

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00037E63 File Offset: 0x00036263
	public List<GameObject> SkillButtons
	{
		get
		{
			return this.mObETCButtonsList;
		}
	}

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x00037E6B File Offset: 0x0003626B
	public GameObject ETCButtonContainer
	{
		get
		{
			return this.mObETCButtons;
		}
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x00037E74 File Offset: 0x00036274
	private void _loadButtonUI()
	{
		this._unloadButtonUI();
		InputManager.ButtonMode buttonMode = this.currentMode;
		if (buttonMode != InputManager.ButtonMode.NORMAL)
		{
			if (buttonMode != InputManager.ButtonMode.NORMALEIGHT)
			{
				Logger.LogErrorFormat("not deal with the button type : {0}", new object[]
				{
					this.currentMode
				});
			}
			else
			{
				this.mObETCButtons = Singleton<AssetLoader>.instance.LoadResAsGameObject(InputManager.GetEtcSkillResPath(), true, 0U);
			}
		}
		else
		{
			this.mObETCButtons = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/ETCInput/ETCButtonsModeNormal", true, 0U);
		}
		Utility.AttachTo(this.mObETCButtons, Singleton<ClientSystemManager>.instance.MiddleLayer, true);
		this.mObETCButtons.transform.SetAsFirstSibling();
		this.mObETCButtonsList.Clear();
		int childCount = this.mObETCButtons.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			string name = this.mObETCButtons.transform.GetChild(i).name;
			GameObject item = Utility.FindGameObject(this.mObETCButtons, name, true);
			this.mObETCButtonsList.Add(item);
		}
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x00037F82 File Offset: 0x00036382
	private void _unloadButtonUI()
	{
		if (this.mObETCButtons != null)
		{
			Object.Destroy(this.mObETCButtons);
			this.mObETCButtons = null;
		}
		this.mObETCButtonsList.Clear();
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x00037FB4 File Offset: 0x000363B4
	private bool _isGetServerSlot()
	{
		List<Skill> skillListBattle = DataManager<SkillDataManager>.GetInstance().GetSkillListBattle(BattleMain.IsModePvP(BattleMain.battleType));
		return skillListBattle.Count >= 0 && BattleMain.instance != null && (BattleMain.battleType == BattleType.NewbieGuide || Global.Settings.startSystem == EClientSystem.Login);
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x00038008 File Offset: 0x00036408
	private void _loadServerSlotMap()
	{
		this.mServerSlotMap.Clear();
		this.mServerSlotMap.Add(1, this.mLocalSlotMap[1]);
		this.mServerSlotMap.Add(2, -1);
		this.mServerSlotMap.Add(3, -1);
		List<SkillBarGrid> curSkillBar = DataManager<SkillDataManager>.GetInstance().GetCurSkillBar(BattleMain.IsModePvP(BattleMain.battleType), SkillSystemSourceType.None);
		for (int i = 0; i < curSkillBar.Count; i++)
		{
			SkillBarGrid skillBarGrid = curSkillBar[i];
			int num = (int)(skillBarGrid.slot + 3);
			if (!this.mServerSlotMap.ContainsKey(num))
			{
				this.mServerSlotMap.Add(num, (int)skillBarGrid.id);
			}
			else
			{
				Logger.LogErrorFormat("already contain the slot {0}", new object[]
				{
					num
				});
			}
		}
		List<int> list;
		if (SwitchFunctionUtility.IsOpen(69))
		{
			list = DataManager<SkillDataManager>.GetInstance().GetBuffSkillIDByLevelLimit(BattleMain.IsModePvP(BattleMain.battleType));
		}
		else
		{
			list = DataManager<SkillDataManager>.GetInstance().GetBuffSkillID(BattleMain.IsModePvP(BattleMain.battleType));
		}
		for (int j = 0; j < list.Count; j++)
		{
			int num2 = 17 + j;
			if (!this.mServerSlotMap.ContainsKey(num2))
			{
				this.mServerSlotMap.Add(num2, list[j]);
			}
			else
			{
				Logger.LogErrorFormat("already contain the buff slot {0}", new object[]
				{
					num2
				});
			}
		}
		int qteskillID = DataManager<SkillDataManager>.GetInstance().GetQTESkillID(BattleMain.IsModePvP(BattleMain.battleType));
		if (qteskillID > 0 && !this.mServerSlotMap.ContainsKey(16))
		{
			this.mServerSlotMap.Add(16, qteskillID);
		}
		int runAttackSkillID = DataManager<SkillDataManager>.GetInstance().GetRunAttackSkillID(BattleMain.IsModePvP(BattleMain.battleType));
		if (runAttackSkillID > 0 && !this.mServerSlotMap.ContainsKey(22))
		{
			this.mServerSlotMap.Add(22, runAttackSkillID);
		}
		if (DataManager<PlayerBaseData>.GetInstance().HasAccompany() && !this.mServerSlotMap.ContainsKey(20))
		{
			this.mServerSlotMap.Add(20, 10000);
		}
		int awakeSkillID = DataManager<PlayerBaseData>.GetInstance().GetAwakeSkillID();
		if (awakeSkillID != 0 && !this.mServerSlotMap.ContainsKey(21))
		{
			this.mServerSlotMap.Add(21, awakeSkillID);
		}
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x00038260 File Offset: 0x00036660
	private void _loadLocalSlotMap()
	{
		this.mLocalSlotMap.Clear();
		for (int i = 0; i < this.mUserConfig.slotMap.Length; i++)
		{
			InputSlotSkillMap inputSlotSkillMap = this.mUserConfig.slotMap[i];
			if (!this.mLocalSlotMap.ContainsKey(inputSlotSkillMap.slot))
			{
				this.mLocalSlotMap.Add(inputSlotSkillMap.slot, inputSlotSkillMap.skillID);
			}
			else
			{
				Logger.LogError("检查技能槽和技能的对应关系，不得有重复啊！");
			}
		}
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x000382E0 File Offset: 0x000366E0
	private void _loadButtonData(int pid = 20)
	{
		this.mPid = pid;
		this.mUserConfig = this._getLocalInputData(pid);
		this.mDictSkillID.Clear();
		this._loadLocalSlotMap();
		this._loadServerSlotMap();
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x00038310 File Offset: 0x00036710
	public static void _setButtonImageByPath(ETCButton button, string path, float scale = 1f)
	{
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path, typeof(Sprite), false, 0U);
		if (assetInst != null)
		{
			button.SetFgImage(path, false);
			button.SetFgImageScale(scale);
		}
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x0003834C File Offset: 0x0003674C
	private void _setButtonImageBySkillID(ETCButton button, int skillID, bool useUnlock = false)
	{
		SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			button.SetFgImage(tableItem.Icon, false);
			if (!this.mDictSkillID.ContainsKey(skillID))
			{
				this.mDictSkillID.Add(skillID, button);
			}
		}
		else if (useUnlock)
		{
			button.SetFgImage("UI/Image/Icon/Icon_skillIcon/Common/icon_lock.png", true);
			button.coolDownImage.enabled = false;
			button.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x000383CF File Offset: 0x000367CF
	public void HiddenJump()
	{
		if (this.mObETCButtonsList.Count > 2)
		{
			this.mObETCButtonsList[1].SetActive(false);
			this.mObETCButtonsList[2].SetActive(false);
		}
	}

	// Token: 0x06000ADD RID: 2781 RVA: 0x00038406 File Offset: 0x00036806
	public void ShowJump()
	{
		if (this.mObETCButtonsList.Count > 2)
		{
			this.mObETCButtonsList[1].SetActive(false);
			this.mObETCButtonsList[2].SetActive(true);
		}
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x00038440 File Offset: 0x00036840
	public void SetEnable(bool enable)
	{
		this.isLock = !enable;
		if (this.IsJoyStickLoaded)
		{
			this.mJoystick.activated = enable;
		}
		if (this.IsSkillButtonLoaded)
		{
			foreach (KeyValuePair<int, ETCButton> keyValuePair in this.mButtonMap)
			{
				ETCButton value = keyValuePair.Value;
				if (null != value)
				{
					value.activated = enable;
					value.SetDark(!enable, 1f);
				}
			}
		}
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x000384C8 File Offset: 0x000368C8
	private void _loadNormalButton()
	{
		int num = this.mUserConfig.normalDataLen;
		InputSlotClickNormalMap[] array = this.mUserConfig.normalData;
		if (this.currentMode == InputManager.ButtonMode.NORMALEIGHT)
		{
			num = this.mUserConfig.normalEightDataLen;
			array = this.mUserConfig.normalEightData;
		}
		this.mButtonMap.Clear();
		bool flag = false;
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.mPid, string.Empty, string.Empty);
		if (tableItem != null)
		{
			flag = (tableItem.JobType == 0);
		}
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = this.mObETCButtonsList[i];
			if (!(gameObject == null))
			{
				ETCButton component = gameObject.GetComponent<ETCButton>();
				InputSlotClickNormalMap inputSlotClickNormalMap = array[i];
				int normalClick = inputSlotClickNormalMap.normalClickSlot;
				int num2 = i + 1;
				if (i >= 3)
				{
					if (this.mServerSlotMap.ContainsKey(num2) || (Global.Settings.startSystem == EClientSystem.Battle && this.mLocalSlotMap.ContainsKey(num2)))
					{
						normalClick = num2;
					}
					else
					{
						normalClick = -1;
					}
					if (this.currentMode != InputManager.ButtonMode.NORMALEIGHT || i >= this.kMaxOffset)
					{
					}
				}
				if (component != null)
				{
					if (normalClick <= 0)
					{
						if (num2 >= 17)
						{
							gameObject.SetActive(false);
						}
						else if (num2 >= 20)
						{
							if (num2 == 20)
							{
							}
							gameObject.SetActive(false);
						}
						else
						{
							component.activated = false;
							this._setButtonImageBySkillID(component, -1, true);
						}
						goto IL_38C;
					}
					int skillID = 0;
					if (this._isGetServerSlot() && this.mServerSlotMap.ContainsKey(num2))
					{
						skillID = this.mServerSlotMap[num2];
					}
					else if (this.mLocalSlotMap.ContainsKey(normalClick))
					{
						skillID = this.mLocalSlotMap[normalClick];
					}
					this._setButtonImageBySkillID(component, skillID, false);
					if (flag)
					{
						bool flag2 = this.ChangePrejobSkillImage(skillID, component);
						if (flag2)
						{
							flag = false;
						}
					}
					component.onDown.AddListener(delegate()
					{
						this._onKeyPress(normalClick, false);
					});
					component.onUp.AddListener(delegate()
					{
						this._onKeyPress(normalClick, true);
					});
					if (this.controllActor != null)
					{
						BeSkill skill = this.controllActor.GetSkill(skillID);
						if (skill != null)
						{
							if (skill.charge && !skill.hideSpellBar)
							{
								component.AddEffect(ETCButton.eEffectType.onCharge, false);
							}
							else if (skill.isQTE || skill.isRunAttack)
							{
								component.AddEffect(ETCButton.eEffectType.onContinue, false);
								component.gameObject.CustomActive(false);
							}
							else if (skill.canSlide)
							{
								component.AddEffect(ETCButton.eEffectType.onSlide, false);
							}
							if (DataManager<SkillDataManager>.GetInstance().isSkillNew(skill.skillID))
							{
								component.AddEffect(ETCButton.eEffectType.onNew, false);
							}
							skill.button = component;
						}
					}
					if (!this.mButtonMap.ContainsKey(normalClick))
					{
						this.mButtonMap.Add(normalClick, component);
					}
					else
					{
						Logger.LogErrorFormat("mButtonMap same key {0}, name {1}", new object[]
						{
							normalClick,
							this.mButtonMap[normalClick].name
						});
					}
				}
				this.stateDic2[i] = gameObject.activeSelf;
			}
			IL_38C:;
		}
	}

	// Token: 0x06000AE0 RID: 2784 RVA: 0x00038870 File Offset: 0x00036C70
	private bool ChangePrejobSkillImage(int skillID, ETCButton button)
	{
		SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
		if (tableItem != null && tableItem.IsPreJob > 0)
		{
			Image component = button.gameObject.GetComponent<Image>();
			if (component != null)
			{
				AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes("UI/Image/Icon/Icon_skillIcon/Common/Common_skill button_yuzhanzhi.png:Common_skill button_yuzhanzhi", typeof(Sprite), false, 0U);
				if (assetInst != null && assetInst.obj != null)
				{
					button.normalSprite = (assetInst.obj as Sprite);
					Color normalColor = button.normalColor;
					button.normalColor = normalColor;
					component.SetNativeSize();
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000AE1 RID: 2785 RVA: 0x00038918 File Offset: 0x00036D18
	private void _addButtons(int pid, Dictionary<int, int> slotMap = null)
	{
		this._loadButtonData(pid);
		if (slotMap != null)
		{
			if (this._isGetServerSlot())
			{
				this.mServerSlotMap = new Dictionary<int, int>(slotMap);
			}
			else
			{
				this.mLocalSlotMap = new Dictionary<int, int>(slotMap);
			}
		}
		InputManager.ButtonMode buttonMode = this.currentMode;
		if (buttonMode != InputManager.ButtonMode.NORMAL && buttonMode != InputManager.ButtonMode.NORMALEIGHT)
		{
			Logger.LogError("current mode is not in control : " + this.currentMode.ToString());
		}
		else
		{
			this._loadNormalButton();
		}
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x000389A4 File Offset: 0x00036DA4
	private GameObject _addOneSliderButtonUI()
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes("UIFlatten/Prefabs/ETCInput/ETCButtonSliderUnit", true, 0U).obj as GameObject;
		Utility.AttachTo(gameObject, this.mObETCButtons, false);
		return gameObject;
	}

	// Token: 0x06000AE3 RID: 2787 RVA: 0x000389DC File Offset: 0x00036DDC
	public void LoadSkillButton(BeActor actor)
	{
		if (actor == null)
		{
			Logger.LogError("[InputManager] LoadSkillButton Must have a Actor!");
			return;
		}
		this._setActorControl(actor);
		this._loadButtonUI();
		this._addButtons(actor.professionID, null);
		this.mPassDoorHandle = actor.RegisterEvent(BeEventType.onPassedDoor, new BeEventHandle.Del(this._onPassedDoor));
	}

	// Token: 0x06000AE4 RID: 2788 RVA: 0x00038A30 File Offset: 0x00036E30
	private void _onPassedDoor(object[] args)
	{
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x00038A3D File Offset: 0x00036E3D
	public ETCButton GetETCButton(int skillid)
	{
		if (this.mDictSkillID.ContainsKey(skillid))
		{
			return this.mDictSkillID[skillid];
		}
		return null;
	}

	// Token: 0x06000AE6 RID: 2790 RVA: 0x00038A60 File Offset: 0x00036E60
	public ETCButton GetSpecialETCButton(SpecialSkillID sp)
	{
		int num = 0;
		if (sp != SpecialSkillID.JUMP)
		{
			if (sp != SpecialSkillID.JUMP_BACK)
			{
				if (sp == SpecialSkillID.NORMAL_ATTACK)
				{
					num = 0;
				}
			}
			else
			{
				num = 2;
			}
		}
		else
		{
			num = 1;
		}
		if (this.mObETCButtonsList.Count > num && num >= 0 && this.mObETCButtonsList[num] != null)
		{
			return this.mObETCButtonsList[num].GetComponent<ETCButton>();
		}
		return null;
	}

	// Token: 0x06000AE7 RID: 2791 RVA: 0x00038AEC File Offset: 0x00036EEC
	public void LoadJoystick(InputManager.JoystickMode mode = InputManager.JoystickMode.DYNAMIC)
	{
		this._loadJoystickUI(mode);
	}

	// Token: 0x06000AE8 RID: 2792 RVA: 0x00038AF5 File Offset: 0x00036EF5
	public void SetVisible(bool flag)
	{
		if (this.mObJoyStick != null)
		{
			this.mObJoyStick.SetActive(flag);
		}
		if (this.mObETCButtons != null)
		{
			this.mObETCButtons.SetActive(flag);
		}
	}

	// Token: 0x06000AE9 RID: 2793 RVA: 0x00038B31 File Offset: 0x00036F31
	public void SetMoveJoystickVisible(bool flag)
	{
		if (this.mObJoyStick != null)
		{
			this.mObJoyStick.CustomActive(flag);
		}
	}

	// Token: 0x06000AEA RID: 2794 RVA: 0x00038B50 File Offset: 0x00036F50
	public void SetVisible(bool stickShow, bool buttonShow)
	{
		if (this.mObJoyStick != null)
		{
			this.mObJoyStick.SetActive(stickShow);
		}
		if (this.mObETCButtons != null)
		{
			this.mObETCButtons.SetActive(buttonShow);
		}
	}

	// Token: 0x06000AEB RID: 2795 RVA: 0x00038B8C File Offset: 0x00036F8C
	public void SetJoyStickMoveCallback(UnityAction<Vector2> callback)
	{
		this.mUseKeyCallBack = 1;
		this.mMoveCallback = (UnityAction<Vector2>)Delegate.Combine(this.mMoveCallback, callback);
	}

	// Token: 0x06000AEC RID: 2796 RVA: 0x00038BAC File Offset: 0x00036FAC
	public void ReleaseJoyStickMoveCallback(UnityAction<Vector2> callback)
	{
		this.mJoyX = 0f;
		this.mJoyY = 0f;
		this.mUseKeyCallBack = 0;
		this.mMoveCallback = (UnityAction<Vector2>)Delegate.Remove(this.mMoveCallback, callback);
	}

	// Token: 0x06000AED RID: 2797 RVA: 0x00038BE2 File Offset: 0x00036FE2
	public void SetJoyStickMoveEndCallback(UnityAction callback)
	{
		this.mMoveEndCallback = (UnityAction)Delegate.Combine(this.mMoveEndCallback, callback);
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x00038BFB File Offset: 0x00036FFB
	public void ReleaseJoyStickMoveEndCallback(UnityAction callback)
	{
		this.mMoveEndCallback = (UnityAction)Delegate.Remove(this.mMoveEndCallback, callback);
	}

	// Token: 0x06000AEF RID: 2799 RVA: 0x00038C14 File Offset: 0x00037014
	private void _onJoystickMoveImp(Vector2 move, bool force = false)
	{
		this.mJoyX = move.x;
		this.mJoyY = move.y;
		if (this.mMoveCallback != null)
		{
			this.mMoveCallback.Invoke(move);
		}
		if (this.JoysticMoveCallBack != null)
		{
			this.JoysticMoveCallBack();
		}
		if (!force)
		{
			this._updateJoystick(0);
		}
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x00038C78 File Offset: 0x00037078
	private void _onJoystickMove(Vector2 move)
	{
		ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
		this._onJoystickMoveImp(move, clientSystemTown != null);
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x00038CA3 File Offset: 0x000370A3
	private void _onJoystickMoveEnd()
	{
		this.mJoyX = 0f;
		this.mJoyY = 0f;
		if (this.mMoveEndCallback != null)
		{
			this.mMoveEndCallback.Invoke();
		}
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x00038CD1 File Offset: 0x000370D1
	private void _clearJoystickState()
	{
		this.mJoyX = 0f;
		this.mJoyY = 0f;
		this.mUseKeyCallBack = 0;
		this.mMoveCallback = null;
		this.mMoveEndCallback = null;
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x00038D00 File Offset: 0x00037100
	private void _clearCmd()
	{
		StopFrameCommand cmd = new StopFrameCommand();
		FrameSync.instance.FireFrameCommand(cmd, false);
		FrameSync.instance.bInMoveMode = false;
		FrameSync.instance.ResetMove();
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x00038D34 File Offset: 0x00037134
	public void Unload()
	{
		this._clearJoystickState();
		this._clearSlot();
		this._setActorControl(null);
		this._clearCmd();
		this._unloadButtonUI();
		this._unloadJoystickUI();
		if (this.mPassDoorHandle != null)
		{
			this.mPassDoorHandle.Remove();
			this.mPassDoorHandle = null;
		}
	}

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x00038D8B File Offset: 0x0003718B
	// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x00038D83 File Offset: 0x00037183
	public static bool isForceLock
	{
		get
		{
			return InputManager.mIsForceLock;
		}
		set
		{
			InputManager.mIsForceLock = value;
		}
	}

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x00038D9B File Offset: 0x0003719B
	// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x00038D92 File Offset: 0x00037192
	public bool isLock
	{
		get
		{
			return this.mIsLock || !this.IsInit || InputManager.isForceLock;
		}
		set
		{
			this.mIsLock = value;
		}
	}

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x00038DBB File Offset: 0x000371BB
	public bool IsJoyStickLoaded
	{
		get
		{
			return this.mObJoyStick != null;
		}
	}

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x06000AFA RID: 2810 RVA: 0x00038DC9 File Offset: 0x000371C9
	public bool IsSkillButtonLoaded
	{
		get
		{
			return this.mObETCButtons != null;
		}
	}

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06000AFB RID: 2811 RVA: 0x00038DD7 File Offset: 0x000371D7
	public bool IsInit
	{
		get
		{
			return this.IsJoyStickLoaded || this.IsSkillButtonLoaded;
		}
	}

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x06000AFC RID: 2812 RVA: 0x00038DED File Offset: 0x000371ED
	// (set) Token: 0x06000AFD RID: 2813 RVA: 0x00038DF5 File Offset: 0x000371F5
	public BeActor controllActor
	{
		get
		{
			return this.mControllActor;
		}
		private set
		{
			this._setActorControl(value);
		}
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x00038DFE File Offset: 0x000371FE
	public void UnloadActorConfig()
	{
		if (this.controllActor != null)
		{
			this.controllActor.SetAttackButtonState(ButtonState.RELEASE, true);
			this.controllActor = null;
			if (this.mOnStateChangeHandler != null)
			{
				this.mOnStateChangeHandler.Remove();
			}
		}
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x00038E35 File Offset: 0x00037235
	public void LoadActorConfig(BeActor actor)
	{
		this.controllActor = actor;
		this.mOnStateChangeHandler = this.controllActor.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
		{
			Dictionary<int, int> dictionary = this.mLocalSlotMap;
			if (this._isGetServerSlot())
			{
				dictionary = this.mServerSlotMap;
			}
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int value = keyValuePair.Value;
				if (value > 0 && this.mButtonMap.ContainsKey(keyValuePair.Key))
				{
					BeSkill skill = this.controllActor.GetSkill(value);
					if (skill != null && !skill.isCooldown)
					{
						bool flag = this.controllActor.CanUseSkill(value);
						this.mButtonMap[keyValuePair.Key].SetDark(!flag, 0.5f);
					}
				}
			}
		});
	}

	// Token: 0x06000B00 RID: 2816 RVA: 0x00038E5D File Offset: 0x0003725D
	private Dictionary<int, int> _GetSlotMap()
	{
		if (this._isGetServerSlot())
		{
			return this.mServerSlotMap;
		}
		return this.mLocalSlotMap;
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x00038E77 File Offset: 0x00037277
	public Dictionary<int, int> GetLocalSlotMap()
	{
		return this.mLocalSlotMap;
	}

	// Token: 0x06000B02 RID: 2818 RVA: 0x00038E80 File Offset: 0x00037280
	private void OnActorStateChange(object[] args)
	{
		if (this.isLock)
		{
			return;
		}
		Dictionary<int, int> dictionary = this._GetSlotMap();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int value = keyValuePair.Value;
			Dictionary<int, int>.Enumerator enumerator;
			KeyValuePair<int, int> keyValuePair2 = enumerator.Current;
			int key = keyValuePair2.Key;
			if (value > 0 && this.mButtonMap.ContainsKey(key))
			{
				BeSkill skill = this.controllActor.GetSkill(value);
				if (skill != null && !skill.isCooldown)
				{
					bool flag = this.controllActor.CanUseSkill(value);
					if (this.mButtonMap.ContainsKey(key))
					{
						this.mButtonMap[key].SetDark(!flag, 0.5f);
					}
				}
			}
		}
	}

	// Token: 0x06000B03 RID: 2819 RVA: 0x00038F50 File Offset: 0x00037350
	private void _setActorControl(BeActor actor)
	{
		if (this.mControllActor == actor)
		{
			return;
		}
		if (this.mControllActor != null)
		{
			this.mControllActor.RemoveEvent(BeEventType.onStateChange, new BeEventHandle.Del(this.OnActorStateChange));
			this.mControllActor.SetAttackButtonState(ButtonState.RELEASE, true);
			this.mOnStateChangeHandler = null;
		}
		this.mControllActor = actor;
		if (this.mControllActor != null)
		{
			this.mOnStateChangeHandler = this.mControllActor.RegisterEvent(BeEventType.onStateChange, new BeEventHandle.Del(this.OnActorStateChange));
		}
	}

	// Token: 0x06000B04 RID: 2820 RVA: 0x00038FD4 File Offset: 0x000373D4
	private void _updateCD()
	{
		if (this.controllActor == null || !this.IsSkillButtonLoaded || this.isAttackButtonOnly)
		{
			return;
		}
		Dictionary<int, int> dictionary = this._GetSlotMap();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			if (this.mButtonMap.ContainsKey(keyValuePair.Key))
			{
				BeSkill skill = this.controllActor.GetSkill(keyValuePair.Value);
				if (skill == null)
				{
					this.mButtonMap[keyValuePair.Key].StopFakeCoolDown(false);
				}
				else if (skill.isCooldown)
				{
					this.mButtonMap[keyValuePair.Key].UpdateFakeCoolDown(skill.CDTimeAcc, skill.GetCurrentCD(), skill.isBuffSkill);
					this.mButtonMap[keyValuePair.Key].SetDark(true, 0.5f);
				}
				else if (skill.ForceShowButtonImage)
				{
					this.mButtonMap[keyValuePair.Key].StopFakeCoolDown(skill.isBuffSkill);
					this.mButtonMap[keyValuePair.Key].SetDark(false, 1f);
				}
				else
				{
					this.mButtonMap[keyValuePair.Key].StopFakeCoolDown(skill.isBuffSkill);
					if (!this.controllActor.CanUseSkill(keyValuePair.Value))
					{
						this.mButtonMap[keyValuePair.Key].SetDark(true, 0.5f);
					}
					else
					{
						this.mButtonMap[keyValuePair.Key].SetDark(false, 1f);
					}
				}
			}
		}
	}

	// Token: 0x06000B05 RID: 2821 RVA: 0x0003918F File Offset: 0x0003758F
	public void InitState()
	{
		this._updateCD();
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x00039197 File Offset: 0x00037597
	public void Update(int deltaTime)
	{
		this._updateCD();
		if (this.isLock)
		{
			return;
		}
		this._updateJoystick(deltaTime);
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x000391B2 File Offset: 0x000375B2
	public void SingleUpdate(int deltaTime)
	{
		if (this.isLock)
		{
			return;
		}
		this._updateJoystick(deltaTime);
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x000391C8 File Offset: 0x000375C8
	private void _updateJoystick(int deltaTime)
	{
		if (this.isLock)
		{
			return;
		}
		this.UpdateCheckDoublePress(deltaTime);
		float axisRaw = Input.GetAxisRaw("Horizontal");
		float axisRaw2 = Input.GetAxisRaw("Vertical");
		if (Input.GetKeyUp(275) || Input.GetKeyUp(276))
		{
			this.CheckDoublePress();
		}
		bool flag = false;
		float num = this.mJoyX;
		float num2 = this.mJoyY;
		short num3 = 0;
		if (Mathf.Abs(axisRaw) > 1E-05f || Mathf.Abs(axisRaw2) > 1E-05f)
		{
			num = axisRaw;
			num2 = axisRaw2;
			flag = true;
		}
		if (Mathf.Abs(num) > 1E-05f || Mathf.Abs(num2) > 1E-05f)
		{
			float num4 = Mathf.Sqrt(num * num + num2 * num2);
			float num5 = Mathf.Acos(num / num4);
			num3 = (short)(57.29578f * num5);
			if (num2 < --0f)
			{
				num3 = 360 - num3;
			}
			num3 /= 15;
			flag = true;
		}
		bool flag2 = false;
		if (flag)
		{
			if (this.doublePress)
			{
				if (this.controllActor != null && this.controllActor.hasDoublePress)
				{
					flag2 = true;
				}
				this.doublePress = false;
			}
			if (this.controllActor != null && !this.controllActor.hasDoublePress)
			{
				flag2 = true;
			}
			if (Singleton<SettingManager>.GetInstance().GetJoystickDir() == InputManager.JoystickDir.EIGHT_DIR && SwitchFunctionUtility.IsOpen(29))
			{
				this.MoveIn8Dir(ref num3);
			}
			MoveFrameCommand cmd = new MoveFrameCommand
			{
				degree = num3,
				run = flag2
			};
			if (flag2 != FrameSync.instance.bInRunMode || (int)num3 != FrameSync.instance.nDegree || !FrameSync.instance.bInMoveMode)
			{
				FrameSync.instance.FireFrameCommand(cmd, false);
				FrameSync.instance.bInRunMode = flag2;
				FrameSync.instance.nDegree = (int)num3;
			}
			FrameSync.instance.bInMoveMode = true;
			if (this.mUseKeyCallBack == 1)
			{
				this.m_MoveVector.x = axisRaw;
				this.m_MoveVector.y = axisRaw2;
				this._onJoystickMoveImp(this.m_MoveVector, true);
			}
		}
		else
		{
			if (FrameSync.instance.bInMoveMode)
			{
				if (this.mUseKeyCallBack == 1)
				{
					this._onJoystickMoveEnd();
				}
				FrameSync.instance.bInMoveMode = false;
			}
			this.FireStopCommand();
		}
	}

	// Token: 0x06000B09 RID: 2825 RVA: 0x00039428 File Offset: 0x00037828
	private void MoveIn8Dir(ref short degree)
	{
		float joystickDirAdjust = Singleton<SettingManager>.GetInstance().GetJoystickDirAdjust();
		float num = -17.5f;
		int offset = (int)((joystickDirAdjust - 0.5f) * num);
		BeAIManager.MoveDir2 dir8ByOffset = InputManager.GetDir8ByOffset((int)(degree * 15), offset);
		degree = (short)(dir8ByOffset * (BeAIManager.MoveDir2)45 / (BeAIManager.MoveDir2)15);
	}

	// Token: 0x06000B0A RID: 2826 RVA: 0x00039468 File Offset: 0x00037868
	public void SetButtonStateActive(int index)
	{
		this.isAttackButtonOnly = true;
		int count = this.mObETCButtonsList.Count;
		for (int i = 0; i < count; i++)
		{
			this.stateDic[i] = this.mObETCButtonsList[i].activeSelf;
			this.stateDic2[i] = this.mObETCButtonsList[i].activeSelf;
		}
		for (int j = 0; j < count; j++)
		{
			this.mObETCButtonsList[j].CustomActive(j == index);
			if (j == index)
			{
				this.mObETCButtonsList[j].GetComponent<ETCButton>().SetDark(false, 1f);
			}
		}
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x00039520 File Offset: 0x00037920
	public void ResetButtonState()
	{
		this.EtcButtonStopCoolDown();
		this.isAttackButtonOnly = false;
		int count = this.mObETCButtonsList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.stateDic.ContainsKey(i) && this.mObETCButtonsList[i] != null)
			{
				this.mObETCButtonsList[i].CustomActive(this.stateDic[i]);
			}
		}
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x000395A0 File Offset: 0x000379A0
	public void ResetButtonState2()
	{
		this.EtcButtonStopCoolDown();
		this.isAttackButtonOnly = false;
		int count = this.mObETCButtonsList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.stateDic2.ContainsKey(i) && this.mObETCButtonsList[i] != null)
			{
				this.mObETCButtonsList[i].CustomActive(this.stateDic2[i]);
			}
		}
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x00039620 File Offset: 0x00037A20
	protected void EtcButtonStopCoolDown()
	{
		Dictionary<int, int> dictionary = this._GetSlotMap();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			if (this.mButtonMap.ContainsKey(keyValuePair.Key))
			{
				BeSkill skill = this.controllActor.GetSkill(keyValuePair.Value);
				if (skill != null && !skill.isCooldown && null != skill.button)
				{
					skill.button.StopCoolDown2();
					this.mButtonMap[keyValuePair.Key].RemoveEffect(ETCButton.eEffectType.onCDFinish, false);
					this.mButtonMap[keyValuePair.Key].RemoveEffect(ETCButton.eEffectType.onCDFinishBuff, false);
				}
			}
		}
	}

	// Token: 0x06000B0E RID: 2830 RVA: 0x000396E0 File Offset: 0x00037AE0
	public void FireStopCommand()
	{
		if (this.mControllActor != null && this.mControllActor.IsInMoveDirection())
		{
			IFrameCommand cmd = FrameCommandFactory.CreateCommand(2U);
			FrameSync.instance.FireFrameCommand(cmd, false);
			FrameSync.instance.bInMoveMode = false;
		}
	}

	// Token: 0x06000B0F RID: 2831 RVA: 0x00039728 File Offset: 0x00037B28
	private void _onKeyPress(int slotPressed, bool up = false)
	{
		if (this.isLock)
		{
			return;
		}
		bool flag = false;
		if (slotPressed >= 1 && slotPressed <= 3)
		{
			flag = true;
		}
		else if (this._isGetServerSlot())
		{
			if (this.mServerSlotMap.ContainsKey(slotPressed))
			{
				flag = true;
			}
		}
		else if (this.mLocalSlotMap.ContainsKey(slotPressed))
		{
			int num = this.mLocalSlotMap[slotPressed];
			if (num > 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			BeActor beActor = this.mControllActor;
			int num2 = 0;
			if (slotPressed == 2)
			{
				num2 = int.MaxValue;
			}
			else if (slotPressed == 3)
			{
				num2 = 2147483646;
			}
			else if (slotPressed == 1)
			{
				num2 = 2147483645;
			}
			else
			{
				if (BattleMain.instance != null && BattleMain.battleType != BattleType.NewbieGuide && (BattleMain.battleType == BattleType.Single || (BattleMain.battleType == BattleType.Dungeon && Global.Settings.isLocalDungeon && Global.Settings.startSystem == EClientSystem.Battle)))
				{
					num2 = this.GetSkillIDBySlot(beActor.professionID, slotPressed);
				}
				else if (beActor.skillSlotMap != null && beActor.skillSlotMap.ContainsKey(slotPressed))
				{
					num2 = beActor.skillSlotMap[slotPressed];
				}
				else if (this.currentMode == InputManager.ButtonMode.NORMALEIGHT)
				{
					num2 = this.mServerSlotMap[slotPressed];
				}
				BeSkill skill = beActor.GetSkill(num2);
				if (skill != null)
				{
					if (!skill.isCooldown)
					{
						if (skill.joystickMode == SkillJoystickMode.FREE)
						{
							this.LoadButtonJoystick(slotPressed, beActor, num2, up, SkillJoystickMode.NONE);
						}
						else if (skill.joystickMode == SkillJoystickMode.SPECIAL || skill.joystickMode == SkillJoystickMode.FORWARDBACK)
						{
							this.LoadButtonJoystick(slotPressed, beActor, num2, up, SkillJoystickMode.NONE);
							num2 = -1;
						}
						else if (skill.joystickMode == SkillJoystickMode.SELECTSEAT && this.GetPlayerCount() > 1)
						{
							this.LoadButtonJoystick(slotPressed, beActor, num2, up, SkillJoystickMode.SELECTSEAT);
							num2 = -1;
						}
						else if (skill.joystickMode == SkillJoystickMode.DIRECTION)
						{
							this.LoadButtonJoystick(slotPressed, beActor, num2, up, SkillJoystickMode.NONE);
						}
					}
					else if (skill.joystickMode == SkillJoystickMode.DIRECTION)
					{
						this.LoadButtonJoystick(slotPressed, beActor, num2, up, SkillJoystickMode.NONE);
					}
				}
			}
			if (num2 > 0)
			{
				this.SaveETCBtnClick(num2, (!up) ? 0 : 1);
				this.CreateSkillFrameCommand(num2, (!up) ? 0 : 1);
			}
		}
	}

	// Token: 0x06000B10 RID: 2832 RVA: 0x0003997E File Offset: 0x00037D7E
	private void SaveETCBtnClick(int skillId, int up)
	{
	}

	// Token: 0x06000B11 RID: 2833 RVA: 0x00039980 File Offset: 0x00037D80
	public void CreateSkillFrameCommand(int skillID, int value = 0)
	{
		if (InputManager.needJoystickOnTouch)
		{
			if (!this.joystick.isOnDrag)
			{
				SystemNotifyManager.SysDungeonSkillTip("要先按指向拖住方向键，再释放技能", 100f, false);
				return;
			}
			if (!InputManager.isProperDir)
			{
				SystemNotifyManager.SysDungeonSkillTip("方向不对", 100f, false);
				return;
			}
		}
		SkillFrameCommand cmd = new SkillFrameCommand
		{
			frame = 0U,
			skillSolt = (uint)skillID,
			skillSlotUp = (uint)value
		};
		FrameSync.instance.FireFrameCommand(cmd, false);
		if (InputManager.onSkillCommandCallBack != null)
		{
			InputManager.onSkillCommandCallBack(skillID, value);
		}
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x00039A14 File Offset: 0x00037E14
	public static void CreateStopSkillFrameCommand(int skillID)
	{
		StopSkillCommand cmd = new StopSkillCommand
		{
			frame = 0U,
			skillID = skillID
		};
		FrameSync.instance.FireFrameCommand(cmd, false);
	}

	// Token: 0x06000B13 RID: 2835 RVA: 0x00039A44 File Offset: 0x00037E44
	public static void CreateSkillDoattackFrameCommand(int skillID, int bulletNum, int pid)
	{
		DoAttackCommand cmd = new DoAttackCommand
		{
			skillID = skillID,
			bulletCount = bulletNum,
			pid = pid
		};
		FrameSync.instance.FireFrameCommand(cmd, false);
	}

	// Token: 0x06000B14 RID: 2836 RVA: 0x00039A7C File Offset: 0x00037E7C
	public static void CreateSkillSynSightFrameCommand(int skillID, int x, int z)
	{
		DoSyncSightCommand cmd = new DoSyncSightCommand
		{
			skillID = skillID,
			x = x,
			z = z
		};
		FrameSync.instance.FireFrameCommand(cmd, false);
	}

	// Token: 0x06000B15 RID: 2837 RVA: 0x00039AB4 File Offset: 0x00037EB4
	public static void CreateBossPhaseChange(int phaseIndex)
	{
		BossPhaseChange cmd = new BossPhaseChange
		{
			phase = phaseIndex
		};
		FrameSync.instance.FireFrameCommand(cmd, true);
	}

	// Token: 0x06000B16 RID: 2838 RVA: 0x00039ADC File Offset: 0x00037EDC
	public void EnableSkillButton(bool flag)
	{
		Dictionary<int, int> dictionary = this._GetSlotMap();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			if (this.mButtonMap.ContainsKey(keyValuePair.Key))
			{
				if (keyValuePair.Key != 3 || flag)
				{
					BeSkill skill = this.controllActor.GetSkill(keyValuePair.Value);
					if (skill != null)
					{
						if (!skill.skillState.IsRunning() || flag)
						{
							this.mButtonMap[keyValuePair.Key].activated = flag;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000B17 RID: 2839 RVA: 0x00039B8C File Offset: 0x00037F8C
	public static InputManager.PressDir GetDir(int degree)
	{
		InputManager.PressDir result = InputManager.PressDir.NONE;
		if (degree > 0)
		{
			if (degree >= 45 && degree < 135)
			{
				result = InputManager.PressDir.TOP;
			}
			else if (degree >= 135 && degree < 225)
			{
				result = InputManager.PressDir.LEFT;
			}
			else if (degree >= 225 && degree < 315)
			{
				result = InputManager.PressDir.DOWN;
			}
			else
			{
				result = InputManager.PressDir.RIGHT;
			}
		}
		return result;
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x00039BFC File Offset: 0x00037FFC
	public static InputManager.PressDir GetForwardBack(int degree)
	{
		InputManager.PressDir result = InputManager.PressDir.NONE;
		if (degree >= 0)
		{
			if (degree >= 90 && degree < 270)
			{
				result = InputManager.PressDir.RIGHT;
			}
			else
			{
				result = InputManager.PressDir.LEFT;
			}
		}
		return result;
	}

	// Token: 0x06000B19 RID: 2841 RVA: 0x00039C34 File Offset: 0x00038034
	public static BeAIManager.MoveDir2 GetDir8ByOffset(int degree, int offset)
	{
		if ((float)degree > 337.5f - (float)offset || (float)degree <= 22.5f + (float)offset)
		{
			return BeAIManager.MoveDir2.RIGHT;
		}
		if ((float)degree > 22.5f + (float)offset && (float)degree <= 67.5f - (float)offset)
		{
			return BeAIManager.MoveDir2.RIGHT_TOP;
		}
		if ((float)degree > 67.5f - (float)offset && (float)degree <= 112.5f + (float)offset)
		{
			return BeAIManager.MoveDir2.TOP;
		}
		if ((float)degree > 112.5f + (float)offset && (float)degree <= 157.5f - (float)offset)
		{
			return BeAIManager.MoveDir2.LEFT_TOP;
		}
		if ((float)degree > 157.5f - (float)offset && (float)degree <= 202.5f + (float)offset)
		{
			return BeAIManager.MoveDir2.LEFT;
		}
		if ((float)degree > 202.5f + (float)offset && (float)degree <= 247.5f - (float)offset)
		{
			return BeAIManager.MoveDir2.LEFT_DOWN;
		}
		if ((float)degree > 247.5f - (float)offset && (float)degree <= 292.5f + (float)offset)
		{
			return BeAIManager.MoveDir2.DOWN;
		}
		if ((float)degree > 292.5f + (float)offset && (float)degree <= 337.5f - (float)offset)
		{
			return BeAIManager.MoveDir2.RIGHT_DOWN;
		}
		return BeAIManager.MoveDir2.COUNT;
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x00039D44 File Offset: 0x00038144
	public static BeAIManager.MoveDir2 GetDir8(int degree)
	{
		if (degree > 337 || (float)degree <= 22.5f)
		{
			return BeAIManager.MoveDir2.RIGHT;
		}
		if ((float)degree > 22.5f && (float)degree <= 67.5f)
		{
			return BeAIManager.MoveDir2.RIGHT_TOP;
		}
		if ((float)degree > 67.5f && (float)degree <= 112.5f)
		{
			return BeAIManager.MoveDir2.TOP;
		}
		if ((float)degree > 112.5f && (float)degree <= 157.5f)
		{
			return BeAIManager.MoveDir2.LEFT_TOP;
		}
		if ((float)degree > 157.5f && (float)degree <= 202.5f)
		{
			return BeAIManager.MoveDir2.LEFT;
		}
		if ((float)degree > 202.5f && (float)degree <= 247.5f)
		{
			return BeAIManager.MoveDir2.LEFT_DOWN;
		}
		if ((float)degree > 247.5f && (float)degree <= 292.5f)
		{
			return BeAIManager.MoveDir2.DOWN;
		}
		if ((float)degree > 292.5f && (float)degree <= 337.5f)
		{
			return BeAIManager.MoveDir2.RIGHT_DOWN;
		}
		return BeAIManager.MoveDir2.COUNT;
	}

	// Token: 0x06000B1B RID: 2843 RVA: 0x00039E24 File Offset: 0x00038224
	public static BeAIManager.MoveDir MoveDir2ToMoveDir(BeAIManager.MoveDir2 dir)
	{
		BeAIManager.MoveDir result = BeAIManager.MoveDir.TOP;
		if (dir == BeAIManager.MoveDir2.TOP)
		{
			result = BeAIManager.MoveDir.TOP;
		}
		if (dir == BeAIManager.MoveDir2.DOWN)
		{
			result = BeAIManager.MoveDir.DOWN;
		}
		if (dir == BeAIManager.MoveDir2.LEFT)
		{
			result = BeAIManager.MoveDir.LEFT;
		}
		if (dir == BeAIManager.MoveDir2.RIGHT)
		{
			result = BeAIManager.MoveDir.RIGHT;
		}
		if (dir == BeAIManager.MoveDir2.RIGHT_TOP)
		{
			result = BeAIManager.MoveDir.RIGHT_TOP;
		}
		if (dir == BeAIManager.MoveDir2.LEFT_TOP)
		{
			result = BeAIManager.MoveDir.LEFT_TOP;
		}
		if (dir == BeAIManager.MoveDir2.LEFT_DOWN)
		{
			result = BeAIManager.MoveDir.LEFT_DOWN;
		}
		if (dir == BeAIManager.MoveDir2.RIGHT_DOWN)
		{
			result = BeAIManager.MoveDir.RIGHT_DOWN;
		}
		return result;
	}

	// Token: 0x040007DF RID: 2015
	private GameObject goButtonJoystick;

	// Token: 0x040007E0 RID: 2016
	private HGJoyStick buttonJoystick;

	// Token: 0x040007E1 RID: 2017
	private short recordVx;

	// Token: 0x040007E2 RID: 2018
	private short recordVy;

	// Token: 0x040007E3 RID: 2019
	private short recordJoystickDegree;

	// Token: 0x040007E4 RID: 2020
	private BeActor owner;

	// Token: 0x040007E5 RID: 2021
	private int skillId;

	// Token: 0x040007E6 RID: 2022
	private float startTime;

	// Token: 0x040007E7 RID: 2023
	private ETCButton button;

	// Token: 0x040007E8 RID: 2024
	private Dictionary<SkillJoystickMode, GameObject> joystickGoDic = new Dictionary<SkillJoystickMode, GameObject>();

	// Token: 0x040007E9 RID: 2025
	private Dictionary<SkillJoystickMode, HGJoyStick> joystickScriptDic = new Dictionary<SkillJoystickMode, HGJoyStick>();

	// Token: 0x040007EA RID: 2026
	private string commonPath = "UIFlatten/Prefabs/ETCInput/HGJoystick";

	// Token: 0x040007EB RID: 2027
	private string selectSeatStickPath = "UIFlatten/Prefabs/ETCInput/HGJoystickSelectSeat";

	// Token: 0x040007EC RID: 2028
	private ComCommonBind selectSeatCommonBind;

	// Token: 0x040007ED RID: 2029
	private Image[] iconImageArr = new Image[3];

	// Token: 0x040007EE RID: 2030
	private RectTransform[] selectTransArr = new RectTransform[3];

	// Token: 0x040007EF RID: 2031
	private RectTransform[] headArr = new RectTransform[3];

	// Token: 0x040007F0 RID: 2032
	private UIGray[] grayArr = new UIGray[3];

	// Token: 0x040007F1 RID: 2033
	private Image[] selectHightColor = new Image[6];

	// Token: 0x040007F2 RID: 2034
	private int lastSelectIndex;

	// Token: 0x040007F3 RID: 2035
	private List<int> seatList = new List<int>();

	// Token: 0x040007F4 RID: 2036
	private static string[] cEctSkillResPath = new string[]
	{
		"UIFlatten/Prefabs/ETCInput/ETCButtonsModeNormalEight",
		"UIFlatten/Prefabs/ETCInput/ETCButtonsModeNormalNew"
	};

	// Token: 0x040007F5 RID: 2037
	private static string[] cEctSkillRootName = new string[]
	{
		"ETCButtonsModeNormalEight(Clone)",
		"ETCButtonsModeNormalNew(Clone)"
	};

	// Token: 0x040007F6 RID: 2038
	public static InputManager.EtcSkillMode sEctSkillMode = InputManager.EtcSkillMode.NORMAL;

	// Token: 0x040007F7 RID: 2039
	public static InputManager instance;

	// Token: 0x040007F8 RID: 2040
	private int mPid;

	// Token: 0x040007F9 RID: 2041
	public int mUseKeyCallBack;

	// Token: 0x040007FA RID: 2042
	private float mJoyX;

	// Token: 0x040007FB RID: 2043
	private float mJoyY;

	// Token: 0x040007FC RID: 2044
	public InputManager.ButtonMode currentMode = Global.Settings.buttonType;

	// Token: 0x040007FD RID: 2045
	public Dictionary<int, ETCButton> mButtonMap = new Dictionary<int, ETCButton>();

	// Token: 0x040007FE RID: 2046
	private const int QTE_SLOT_INDEX = 16;

	// Token: 0x040007FF RID: 2047
	private const int BUFF_SLOT_INDEX = 17;

	// Token: 0x04000800 RID: 2048
	private const int HELP_SLOT_INDEX = 20;

	// Token: 0x04000801 RID: 2049
	private const int AWAKE_SLOT_INDEX = 21;

	// Token: 0x04000802 RID: 2050
	private const int RUN_ATTACK_INDEX = 22;

	// Token: 0x04000803 RID: 2051
	private int TOTAL_SLOT_NUM = 22;

	// Token: 0x04000804 RID: 2052
	private Dictionary<int, InputUserData> mUserDataDict = new Dictionary<int, InputUserData>();

	// Token: 0x04000805 RID: 2053
	private ETCJoystick mJoystick;

	// Token: 0x04000806 RID: 2054
	private GameObject mObJoyStick;

	// Token: 0x04000807 RID: 2055
	private bool pressOne;

	// Token: 0x04000808 RID: 2056
	private int doublePressCheckDuration = 500;

	// Token: 0x04000809 RID: 2057
	private int doubleCheckAcc = int.MaxValue;

	// Token: 0x0400080A RID: 2058
	private bool doublePress;

	// Token: 0x0400080B RID: 2059
	public InputManager.JoystickMode joystickMode;

	// Token: 0x0400080C RID: 2060
	public Queue skillOnClickQue = new Queue();

	// Token: 0x0400080D RID: 2061
	private GameObject mObETCButtons;

	// Token: 0x0400080E RID: 2062
	private List<GameObject> mObETCButtonsList = new List<GameObject>();

	// Token: 0x0400080F RID: 2063
	private Dictionary<int, int> mServerSlotMap = new Dictionary<int, int>();

	// Token: 0x04000810 RID: 2064
	private Dictionary<int, int> mLocalSlotMap = new Dictionary<int, int>();

	// Token: 0x04000811 RID: 2065
	private InputUserData mUserConfig;

	// Token: 0x04000812 RID: 2066
	private BeEventHandle mPassDoorHandle;

	// Token: 0x04000813 RID: 2067
	private const int kServerSlotStartOffset = 3;

	// Token: 0x04000814 RID: 2068
	private Dictionary<int, ETCButton> mDictSkillID = new Dictionary<int, ETCButton>();

	// Token: 0x04000815 RID: 2069
	private int kMaxOffset = 14;

	// Token: 0x04000816 RID: 2070
	private UnityAction<Vector2> mMoveCallback;

	// Token: 0x04000817 RID: 2071
	public Action JoysticMoveCallBack;

	// Token: 0x04000818 RID: 2072
	private UnityAction mMoveEndCallback;

	// Token: 0x04000819 RID: 2073
	private BeActor mControllActor;

	// Token: 0x0400081A RID: 2074
	private bool mIsLock;

	// Token: 0x0400081B RID: 2075
	private BeEventHandle mOnCastSkillHandler;

	// Token: 0x0400081C RID: 2076
	private BeEventHandle mOnStateChangeHandler;

	// Token: 0x0400081D RID: 2077
	private static bool mIsForceLock = false;

	// Token: 0x0400081E RID: 2078
	public const short DegreeDiv = 15;

	// Token: 0x0400081F RID: 2079
	private Vector2 m_MoveVector = Vector2.zero;

	// Token: 0x04000820 RID: 2080
	public bool isAttackButtonOnly;

	// Token: 0x04000821 RID: 2081
	private Dictionary<int, bool> stateDic = new Dictionary<int, bool>();

	// Token: 0x04000822 RID: 2082
	private Dictionary<int, bool> stateDic2 = new Dictionary<int, bool>();

	// Token: 0x04000823 RID: 2083
	public static InputManager.OnSkillCommand onSkillCommandCallBack = null;

	// Token: 0x04000824 RID: 2084
	public static bool needJoystickOnTouch = false;

	// Token: 0x04000825 RID: 2085
	public static bool isProperDir = false;

	// Token: 0x0200017D RID: 381
	public enum ButtonMode
	{
		// Token: 0x04000827 RID: 2087
		[Description("普通")]
		NORMAL,
		// Token: 0x04000828 RID: 2088
		[Description("普通-8")]
		NORMALEIGHT
	}

	// Token: 0x0200017E RID: 382
	public enum PressDir
	{
		// Token: 0x0400082A RID: 2090
		NONE = -1,
		// Token: 0x0400082B RID: 2091
		TOP,
		// Token: 0x0400082C RID: 2092
		DOWN,
		// Token: 0x0400082D RID: 2093
		LEFT,
		// Token: 0x0400082E RID: 2094
		RIGHT
	}

	// Token: 0x0200017F RID: 383
	public enum EtcSkillMode
	{
		// Token: 0x04000830 RID: 2096
		EIGHT,
		// Token: 0x04000831 RID: 2097
		NORMAL
	}

	// Token: 0x02000180 RID: 384
	public enum JoystickMode
	{
		// Token: 0x04000833 RID: 2099
		DYNAMIC,
		// Token: 0x04000834 RID: 2100
		STATIC
	}

	// Token: 0x02000181 RID: 385
	public enum JoystickDir
	{
		// Token: 0x04000836 RID: 2102
		MORE_DIR,
		// Token: 0x04000837 RID: 2103
		EIGHT_DIR
	}

	// Token: 0x02000182 RID: 386
	public enum RunAttackMode
	{
		// Token: 0x04000839 RID: 2105
		NORMAL,
		// Token: 0x0400083A RID: 2106
		QTE
	}

	// Token: 0x02000183 RID: 387
	public enum CameraShockMode
	{
		// Token: 0x0400083C RID: 2108
		OPEN,
		// Token: 0x0400083D RID: 2109
		CLOSE
	}

	// Token: 0x02000184 RID: 388
	public enum SlideSetting
	{
		// Token: 0x0400083F RID: 2111
		NORMAL,
		// Token: 0x04000840 RID: 2112
		SLIDE
	}

	// Token: 0x02000185 RID: 389
	public enum PaladinAttack
	{
		// Token: 0x04000842 RID: 2114
		OPEN,
		// Token: 0x04000843 RID: 2115
		CLOSE
	}

	// Token: 0x02000186 RID: 390
	public enum PaladinXuanWuManual
	{
		// Token: 0x04000845 RID: 2117
		OPEN,
		// Token: 0x04000846 RID: 2118
		CLOSE
	}

	// Token: 0x02000187 RID: 391
	// (Invoke) Token: 0x06000B23 RID: 2851
	public delegate void OnSkillCommand(int skillid, int value);

	// Token: 0x02000188 RID: 392
	public enum SkillBtnState
	{
		// Token: 0x04000848 RID: 2120
		NORMAL,
		// Token: 0x04000849 RID: 2121
		PRESS,
		// Token: 0x0400084A RID: 2122
		UP
	}
}
