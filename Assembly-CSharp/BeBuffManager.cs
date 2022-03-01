using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;

// Token: 0x0200415A RID: 16730
public class BeBuffManager
{
	// Token: 0x06016DAE RID: 93614 RVA: 0x00706850 File Offset: 0x00704C50
	public BeBuffManager(BeActor owner)
	{
		this.actor = owner;
	}

	// Token: 0x17001F2B RID: 7979
	// (get) Token: 0x06016DAF RID: 93615 RVA: 0x007068B8 File Offset: 0x00704CB8
	public FrameRandomImp FrameRandom
	{
		get
		{
			if (this.actor.FrameRandom == null)
			{
				return BeSkill.randomForTown;
			}
			return this.actor.FrameRandom;
		}
	}

	// Token: 0x06016DB0 RID: 93616 RVA: 0x007068DB File Offset: 0x00704CDB
	public List<BeBuff> GetBuffList()
	{
		return this.buffList;
	}

	// Token: 0x06016DB1 RID: 93617 RVA: 0x007068E3 File Offset: 0x00704CE3
	public Dictionary<int, List<BuffInfoData>> GetTriggerBuffList()
	{
		return this.triggerBuffList;
	}

	// Token: 0x06016DB2 RID: 93618 RVA: 0x007068EB File Offset: 0x00704CEB
	public bool IsAbnormalBuff(BuffType buffType)
	{
		return buffType >= BuffType.FLASH && buffType <= BuffType.CURSE;
	}

	// Token: 0x06016DB3 RID: 93619 RVA: 0x00706900 File Offset: 0x00704D00
	public BeBuff TryAddBuff(int buffInfoID, BeActor source = null, bool buffEffectAni = false, BeActor releaser = null, int externLevel = 0)
	{
		BuffInfoData info = new BuffInfoData(buffInfoID, externLevel, 0);
		return this.TryAddBuff(info, source, buffEffectAni, default(VRate), releaser);
	}

	// Token: 0x06016DB4 RID: 93620 RVA: 0x0070692C File Offset: 0x00704D2C
	public BeBuff TryAddBuffInfo(int buffInfoID, BeActor releaser, int externLevel)
	{
		BuffInfoData info = new BuffInfoData(buffInfoID, externLevel, 0);
		return this.TryAddBuff(info, null, false, default(VRate), releaser);
	}

	// Token: 0x06016DB5 RID: 93621 RVA: 0x00706958 File Offset: 0x00704D58
	public BeBuff TryAddBuff(BuffInfoData info, BeActor source = null, bool buffEffectAni = false, VRate buffAddRate = default(VRate), BeActor releaser = null)
	{
		int buffID = info.buffID;
		if (this.actor != null && this.actor.IsMonster() && info.mapMonsterTypeBuff.Count > 0)
		{
			int type = this.actor.GetEntityData().type;
			if (info.mapMonsterTypeBuff.ContainsKey(type) && info.mapMonsterTypeBuff[type] > 0)
			{
				buffID = info.mapMonsterTypeBuff[type];
			}
		}
		if (this.actor != null && info.mapMonsterTypeBuff.Count > 0 && this.actor.GetEntityData().isSummonMonster && info.mapMonsterTypeBuff.ContainsKey(Global.SUMMONMONSTERTYPE) && info.mapMonsterTypeBuff[Global.SUMMONMONSTERTYPE] > 0)
		{
			buffID = info.mapMonsterTypeBuff[Global.SUMMONMONSTERTYPE];
		}
		if (source == null)
		{
			source = this.actor;
		}
		VRate vrate = info.prob;
		if (buffAddRate > 0)
		{
			vrate = buffAddRate;
		}
		int[] array = new int[]
		{
			vrate.i
		};
		this.actor.TriggerEvent(BeEventType.onChangeBuffAttackRate, new object[]
		{
			BuffAttachType.BUFFINFO,
			info.buffInfoID,
			array,
			source
		});
		vrate = new VRate(array[0]);
		int[] array2 = new int[]
		{
			0
		};
		this.actor.TriggerEvent(BeEventType.onChangeBuffLevel, new object[]
		{
			0,
			info.buffInfoID,
			array2,
			source
		});
		info.level += array2[0];
		if (info.level < 1)
		{
			info.level = 1;
		}
		info.abnormalLevel += array2[0];
		if (info.abnormalLevel < 1)
		{
			info.abnormalLevel = 1;
		}
		int[] array3 = new int[]
		{
			GlobalLogic.VALUE_1000
		};
		this.actor.TriggerEvent(BeEventType.onChangeBuffAttack, new object[]
		{
			0,
			info.buffInfoID,
			array3,
			source
		});
		info.attack *= VFactor.NewVFactor(array3[0], GlobalLogic.VALUE_1000);
		return this.TryAddBuff(buffID, info.duration, info.level, vrate.i, info.attack, buffEffectAni, info.skillIDs, info.abnormalLevel, info.buffInfoID, releaser);
	}

	// Token: 0x06016DB6 RID: 93622 RVA: 0x00706C4C File Offset: 0x0070504C
	public BeBuff TryAddBuff(int buffID, int buffDuration, int buffLevel = 1)
	{
		return this.TryAddBuff(buffID, buffDuration, buffLevel, GlobalLogic.VALUE_1000, 0, false, null, 0, 0, null);
	}

	// Token: 0x06016DB7 RID: 93623 RVA: 0x00706C70 File Offset: 0x00705070
	public BeBuff TryAddBuff(int buffID, int buffDuration, int buffLevel, int buffAddRate, int buffAttack = 0, bool buffEffectAni = false, List<int> skillIDs = null, int buffAbnormalLevel = 0, int buffInfoId = 0, BeActor releaser = null)
	{
		if (buffDuration == -1)
		{
			buffDuration = int.MaxValue;
		}
		BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return null;
		}
		if (tableItem.Overlay == 7)
		{
			this.RemoveBuff(buffID, 0, 0);
		}
		if (tableItem.WorkType == 0 && this.actor.stateController.HasBuffState(BeBuffStateType.INVINCIBLE))
		{
			return null;
		}
		if (buffAbnormalLevel == 0)
		{
			buffAbnormalLevel = buffLevel;
		}
		ushort num = 0;
		if (buffAddRate < VRate.one)
		{
			num = this.FrameRandom.Range1000();
			if (this.actor != null && this.actor.IsProcessRecord())
			{
				this.actor.GetRecordServer().Mark(142055314U, new int[]
				{
					this.actor.m_iID,
					buffID
				}, new string[]
				{
					this.actor.GetName()
				});
			}
		}
		if (this.IsAbnormalBuff((BuffType)tableItem.Type) && !this.actor.stateController.CanAddAbnormalBuff())
		{
			return null;
		}
		if (tableItem.WorkType == 0 && this.IsAbnormalBuff((BuffType)tableItem.Type))
		{
			if (!this.actor.stateController.CanBeHit())
			{
				return null;
			}
			if (!this.actor.stateController.CanAddAbnormalBuffAbility((BuffType)tableItem.Type))
			{
				return null;
			}
			if (this.actor != null && this.actor.GetEntityData() != null && this.actor.GetEntityData().isPet)
			{
				return null;
			}
			int[] array = new int[]
			{
				0
			};
			this.actor.TriggerEvent(BeEventType.OnChangeAbnormalBuffLevel, new object[]
			{
				array,
				tableItem.Type
			});
			buffAbnormalLevel += array[0];
			if (!this.actor.stateController.CanAddAbnormalBuffWithBornAbility((BuffType)tableItem.Type) || !this.actor.GetEntityData().CanAddAbnormalState(buffAddRate, buffAbnormalLevel, (BuffType)tableItem.Type))
			{
				return null;
			}
		}
		else if ((int)num > buffAddRate)
		{
			return null;
		}
		BeBuff beBuff = this.HasBuffByID(buffID);
		bool flag = beBuff != null;
		if (tableItem.Overlay == 4 && flag && !beBuff.CanRemove())
		{
			beBuff.Cancel();
			return null;
		}
		if (tableItem.Overlay == 3 && flag && !beBuff.CanRemove())
		{
			return null;
		}
		if (tableItem.Overlay == 2 && flag && !beBuff.CanRemove())
		{
			beBuff.RefreshDuration(buffDuration);
			beBuff.ResetEffectElapsedTime();
			return beBuff;
		}
		if (tableItem.Overlay != 1 || !flag)
		{
			if (tableItem.Overlay == 7 && flag && !beBuff.CanRemove())
			{
				beBuff.Cancel();
			}
			if (tableItem.Overlay == 8)
			{
				for (int i = 0; i < this.buffList.Count; i++)
				{
					BeBuff beBuff2 = this.buffList[i];
					if (beBuff2 != null && !beBuff2.CanRemove() && beBuff2.buffID == buffID)
					{
						beBuff2.RefreshDuration(buffDuration);
						beBuff2.ResetEffectElapsedTime();
					}
				}
			}
			int overlayLimit = tableItem.OverlayLimit;
			if (overlayLimit > 0 && tableItem.Overlay != 7)
			{
				int buffCountByID = this.GetBuffCountByID(buffID);
				if (buffCountByID >= overlayLimit)
				{
					if (tableItem.Overlay != 6)
					{
						return null;
					}
					List<BeBuff> unDeadBuff = this.GetUnDeadBuff(buffID);
					int count = unDeadBuff.Count;
					if (count > 0 && count >= overlayLimit)
					{
						if (count > 1)
						{
							for (int j = 0; j < count - 1; j++)
							{
								unDeadBuff[j].CopyRunTime(unDeadBuff[j + 1]);
							}
						}
						BeBuff beBuff3 = unDeadBuff[count - 1];
						beBuff3.RefreshDuration(buffDuration);
						beBuff3.ResetEffectElapsedTime();
						return null;
					}
				}
			}
			BeBuff beBuff4 = null;
			if (tableItem.EffectDisOverlay > 0)
			{
				beBuff4 = this.GetLastTimeAddBuff(buffID);
			}
			beBuff = this.AddBuff(buffID, buffLevel, buffDuration, buffAttack, buffEffectAni, skillIDs, buffAbnormalLevel, releaser);
			if (beBuff4 != null && beBuff != null)
			{
				beBuff4.HideEffect();
			}
			this.RefreshAbnormalData(beBuff);
			if (beBuff != null)
			{
				if (releaser != null && tableItem.IsDelete == 1)
				{
					BeEventHandle _handle = null;
					_handle = releaser.RegisterEvent(BeEventType.onDead, delegate(object[] args)
					{
						if (this.actor != null)
						{
							this.actor.buffController.RemoveBuff(buffID, 0, 0);
						}
						if (_handle != null)
						{
							_handle.Remove();
						}
					});
				}
				beBuff.buffInfoId = buffInfoId;
				if (this.actor != null && this.actor.protectManager != null)
				{
					this.actor.protectManager.AddBuff(beBuff.buffType);
				}
			}
			return beBuff;
		}
		if (tableItem.OverlayLimit > 0 && beBuff.overlayCount > tableItem.OverlayLimit)
		{
			return beBuff;
		}
		beBuff.OverlayDamage(buffAttack, buffDuration);
		return beBuff;
	}

	// Token: 0x06016DB8 RID: 93624 RVA: 0x007071E0 File Offset: 0x007055E0
	private BeBuff AddBuff(int buffID, int buffLevel, int buffDuration, int buffAttack = 0, bool buffEffectAni = false, List<int> skillIDs = null, int abnormalLevel = 0, BeActor releaser = null)
	{
		if (this.actor.sgGetCurrentState() == 15 && (buffID == 3 || buffID == 8 || buffID == 4 || buffID == 7))
		{
			return null;
		}
		BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffID, string.Empty, string.Empty);
		if (tableItem != null && this.actor.stateController.IsGraping() && this.IsAbnormalBuff((BuffType)tableItem.Type))
		{
			return null;
		}
		if (this.actor.IsDead() && this.IsAbnormalBuff((BuffType)tableItem.Type))
		{
			return null;
		}
		int[] array = new int[1];
		this.actor.TriggerEvent(BeEventType.BuffCanAdd, new object[]
		{
			array,
			buffID
		});
		if (array[0] == 1)
		{
			return null;
		}
		string typeName = "Buff" + buffID;
		BeBuff beBuff;
		if (tableItem.Type != 6 && tableItem.Overlay == 5)
		{
			beBuff = new BeAbnormalBuff(buffID, buffLevel, buffDuration, buffAttack, buffEffectAni);
		}
		else
		{
			Type type = TypeTable.GetType(typeName);
			if (type != null)
			{
				beBuff = (BeBuff)Activator.CreateInstance(type, new object[]
				{
					buffID,
					buffLevel,
					buffDuration,
					buffAttack
				});
			}
			else
			{
				beBuff = new BeBuff(buffID, buffLevel, buffDuration, buffAttack, buffEffectAni);
			}
		}
		beBuff.owner = this.actor;
		beBuff.SetBuffReleaser(releaser);
		beBuff.skillIDs = skillIDs;
		beBuff.abnormalLevel = abnormalLevel;
		this.actor.TriggerEvent(BeEventType.onBuffBeforePostInit, new object[]
		{
			beBuff
		});
		beBuff.PostInit();
		if (!beBuff.CanAdd(this.actor))
		{
			return null;
		}
		if (!this.actor.stateController.CanAddBuff())
		{
			return null;
		}
		beBuff.Start();
		this.buffList.Add(beBuff);
		this.actor.TriggerEvent(BeEventType.onAddBuff, new object[]
		{
			beBuff
		});
		if (this.actor.CurrentBeScene != null)
		{
			this.actor.CurrentBeScene.TriggerEventNew(BeEventSceneType.onAddBuff, new EventParam
			{
				m_Obj = beBuff,
				m_Obj2 = this.actor
			});
		}
		if (this.actor != null && this.actor.IsProcessRecord() && this.actor != null)
		{
			this.actor.GetRecordServer().Mark(142055315U, new int[]
			{
				this.actor.m_iID,
				beBuff.buffID,
				this.actor.GetPosition().x,
				this.actor.GetPosition().y,
				this.actor.GetPosition().z,
				this.actor.moveXSpeed.i,
				this.actor.moveYSpeed.i,
				this.actor.moveZSpeed.i,
				(!this.actor.GetFace()) ? 0 : 1,
				this.actor.attribute.GetHP(),
				this.actor.attribute.GetMP(),
				this.actor.GetAllStatTag(),
				this.actor.attribute.battleData.attack
			}, new string[]
			{
				this.actor.GetName()
			});
		}
		return beBuff;
	}

	// Token: 0x06016DB9 RID: 93625 RVA: 0x00707594 File Offset: 0x00705994
	public BeBuff AddBuffForSkill(int id, int level, int duration, List<int> skillIDs)
	{
		if (duration == -1)
		{
			duration = int.MaxValue;
		}
		return this.AddBuff(id, level, duration, 0, false, skillIDs, 0, null);
	}

	// Token: 0x06016DBA RID: 93626 RVA: 0x007075C0 File Offset: 0x007059C0
	public BeBuff HasBuffByID(int bid)
	{
		if (bid > 0)
		{
			for (int i = 0; i < this.buffList.Count; i++)
			{
				BeBuff beBuff = this.buffList[i];
				if (beBuff != null && !beBuff.CanRemove() && beBuff.buffID == bid)
				{
					return beBuff;
				}
			}
		}
		return null;
	}

	// Token: 0x06016DBB RID: 93627 RVA: 0x00707620 File Offset: 0x00705A20
	public void DispelBuff(BuffWorkType buffWorkType, int num = 2147483647)
	{
		int num2 = 0;
		while (num2 < this.buffList.Count && num2 < num)
		{
			BeBuff beBuff = this.buffList[num2];
			if (beBuff != null && !beBuff.CanRemove() && beBuff.CanDispel() && beBuff.buffWorkType == buffWorkType)
			{
				beBuff.Cancel();
			}
			num2++;
		}
	}

	// Token: 0x06016DBC RID: 93628 RVA: 0x0070768C File Offset: 0x00705A8C
	public void DisposeByID(int bid)
	{
		if (bid > 0)
		{
			for (int i = 0; i < this.buffList.Count; i++)
			{
				if (this.buffList[i] != null && !this.buffList[i].CanRemove() && this.buffList[i].buffID == bid)
				{
					this.buffList[i].Cancel();
				}
			}
		}
	}

	// Token: 0x06016DBD RID: 93629 RVA: 0x0070770C File Offset: 0x00705B0C
	public BeBuff HasBuffByType(BuffType bt)
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (!beBuff.CanRemove() && beBuff.buffType == bt)
			{
				return beBuff;
			}
		}
		return null;
	}

	// Token: 0x06016DBE RID: 93630 RVA: 0x0070775C File Offset: 0x00705B5C
	public void DisposeByType(BuffType bt)
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff.buffType == bt)
			{
				beBuff.Cancel();
			}
		}
	}

	// Token: 0x06016DBF RID: 93631 RVA: 0x007077A4 File Offset: 0x00705BA4
	private bool CheckCanRemoveBuff(BeBuff buff)
	{
		return buff.CanRemove();
	}

	// Token: 0x06016DC0 RID: 93632 RVA: 0x007077AC File Offset: 0x00705BAC
	public void UpdateBuff(int deltaTime)
	{
		bool flag = false;
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff buff = this.buffList[i];
			if (this.CheckCanRemoveBuff(buff))
			{
				flag = true;
			}
			this.buffList[i].Update(deltaTime);
		}
		if (flag)
		{
			this._RemoveBuff();
		}
		this.UpdateRangeTriggerBuff(deltaTime);
		this.UpdateBuffInfo(deltaTime);
	}

	// Token: 0x06016DC1 RID: 93633 RVA: 0x0070781E File Offset: 0x00705C1E
	private void _RemoveBuff()
	{
		this.buffList.RemoveAll(new Predicate<BeBuff>(this.CheckCanRemoveBuff));
	}

	// Token: 0x06016DC2 RID: 93634 RVA: 0x00707838 File Offset: 0x00705C38
	public void RemoveBuff(BeBuff buff)
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			if (this.buffList[i] == buff && !this.buffList[i].CanRemove())
			{
				this.buffList[i].Cancel();
			}
		}
		this.buffList.RemoveAll(new Predicate<BeBuff>(this.CheckCanRemoveBuff));
	}

	// Token: 0x06016DC3 RID: 93635 RVA: 0x007078B4 File Offset: 0x00705CB4
	public void RemoveBuff(int buffID, int num = 0, int buffInfoId = 0)
	{
		if (this.HasBuffByID(buffID) == null)
		{
			return;
		}
		int num2 = 0;
		for (int i = 0; i < this.buffList.Count; i++)
		{
			if (this.buffList[i].buffID == buffID && !this.buffList[i].CanRemove())
			{
				if (buffInfoId == 0 || this.buffList[i].buffInfoId == buffInfoId)
				{
					this.buffList[i].Cancel();
					if (num > 0)
					{
						num2++;
						if (num2 >= num)
						{
							break;
						}
					}
				}
			}
		}
		this.buffList.RemoveAll(new Predicate<BeBuff>(this.CheckCanRemoveBuff));
	}

	// Token: 0x06016DC4 RID: 93636 RVA: 0x00707980 File Offset: 0x00705D80
	public void RemoveBuffByBuffInfoID(int buffInfoID)
	{
		if (buffInfoID <= 0)
		{
			return;
		}
		BuffInfoData buffInfoData = new BuffInfoData(buffInfoID, 0, 0);
		if (buffInfoData.condition <= BuffCondition.NONE)
		{
			if (buffInfoData.condition == BuffCondition.ENTERBATTLE || buffInfoData.condition == BuffCondition.NONE)
			{
				this.RemoveBuff(buffInfoData.buffID, 1, 0);
			}
		}
		else
		{
			this.RemoveTriggerBuff(buffInfoID);
		}
	}

	// Token: 0x06016DC5 RID: 93637 RVA: 0x007079E0 File Offset: 0x00705DE0
	public void AddPhaseDelete(BeBuff buff)
	{
		this.phaseDeleteBuffList.Add(buff);
	}

	// Token: 0x06016DC6 RID: 93638 RVA: 0x007079F0 File Offset: 0x00705DF0
	public void ClearPhaseDelete()
	{
		for (int i = 0; i < this.phaseDeleteBuffList.Count; i++)
		{
			BeBuff beBuff = this.phaseDeleteBuffList[i];
			if (beBuff != null && !beBuff.CanRemove())
			{
				beBuff.Cancel();
			}
		}
		this.phaseDeleteBuffList.Clear();
	}

	// Token: 0x06016DC7 RID: 93639 RVA: 0x00707A48 File Offset: 0x00705E48
	public void AddFinishDelete(BeBuff buff)
	{
		this.finishDeleteBuffList.Add(buff);
	}

	// Token: 0x06016DC8 RID: 93640 RVA: 0x00707A58 File Offset: 0x00705E58
	public void ClearFinishDelete()
	{
		for (int i = 0; i < this.finishDeleteBuffList.Count; i++)
		{
			BeBuff beBuff = this.finishDeleteBuffList[i];
			if (beBuff != null && !beBuff.CanRemove() && beBuff.buffID == 1)
			{
				beBuff.Cancel();
			}
		}
		this.finishDeleteBuffList.Clear();
	}

	// Token: 0x06016DC9 RID: 93641 RVA: 0x00707ABC File Offset: 0x00705EBC
	public void AddFinishDeleteAll(BeBuff buff)
	{
		this.finishDeleteAllBuffList.Add(buff);
	}

	// Token: 0x06016DCA RID: 93642 RVA: 0x00707ACC File Offset: 0x00705ECC
	public void ClearFinishDeleteAll()
	{
		for (int i = 0; i < this.finishDeleteAllBuffList.Count; i++)
		{
			BeBuff beBuff = this.finishDeleteAllBuffList[i];
			if (beBuff != null && !beBuff.CanRemove())
			{
				beBuff.Cancel();
			}
		}
		this.finishDeleteAllBuffList.Clear();
	}

	// Token: 0x06016DCB RID: 93643 RVA: 0x00707B24 File Offset: 0x00705F24
	public int GetBuffCountByType(BuffType buffType)
	{
		int num = 0;
		for (int i = 0; i < this.buffList.Count; i++)
		{
			if (!this.buffList[i].CanRemove() && this.buffList[i].buffType == buffType)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06016DCC RID: 93644 RVA: 0x00707B84 File Offset: 0x00705F84
	public int GetBuffCountByID(int buffID)
	{
		int num = 0;
		for (int i = 0; i < this.buffList.Count; i++)
		{
			if (!this.buffList[i].CanRemove() && this.buffList[i].buffID == buffID)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06016DCD RID: 93645 RVA: 0x00707BE4 File Offset: 0x00705FE4
	public List<BeBuff> GetUnDeadBuff(int buffID)
	{
		this.buffListCache.Clear();
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff.buffID == buffID && !beBuff.CanRemove())
			{
				this.buffListCache.Add(this.buffList[i]);
			}
		}
		return this.buffListCache;
	}

	// Token: 0x06016DCE RID: 93646 RVA: 0x00707C5C File Offset: 0x0070605C
	public BeBuff GetLastTimeAddBuff(int buffID)
	{
		this.buffListCache.Clear();
		for (int i = this.buffList.Count - 1; i > -1; i--)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff.buffID == buffID && !beBuff.CanRemove())
			{
				return beBuff;
			}
		}
		return null;
	}

	// Token: 0x06016DCF RID: 93647 RVA: 0x00707CBC File Offset: 0x007060BC
	public BeBuff GetBuffByType(BuffType buffType)
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			if (!this.buffList[i].CanRemove() && this.buffList[i].buffType == buffType)
			{
				return this.buffList[i];
			}
		}
		return null;
	}

	// Token: 0x06016DD0 RID: 93648 RVA: 0x00707D20 File Offset: 0x00706120
	public void RemoveInPassiveBuff()
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff != null && !beBuff.CanRemove() && !beBuff.IsPassive() && beBuff.duration < 2147483647)
			{
				beBuff.Cancel();
			}
		}
	}

	// Token: 0x06016DD1 RID: 93649 RVA: 0x00707D90 File Offset: 0x00706190
	public void RemoveDebuff(bool needDuration = true)
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff != null && !beBuff.CanRemove() && !beBuff.IsPassive() && beBuff.buffWorkType == BuffWorkType.DEBUFF && (!needDuration || beBuff.duration < 2147483647))
			{
				beBuff.Cancel();
			}
		}
	}

	// Token: 0x06016DD2 RID: 93650 RVA: 0x00707E10 File Offset: 0x00706210
	public void RemoveAllBuff()
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff != null && !beBuff.CanRemove())
			{
				beBuff.Cancel();
			}
		}
	}

	// Token: 0x06016DD3 RID: 93651 RVA: 0x00707E60 File Offset: 0x00706260
	public bool AddTriggerBuff(int buffInfoID, int level = 0)
	{
		if (buffInfoID <= 0)
		{
			return false;
		}
		BuffInfoData buffInfo = new BuffInfoData(buffInfoID, level, 0);
		return this.AddTriggerBuff(buffInfo);
	}

	// Token: 0x06016DD4 RID: 93652 RVA: 0x00707E88 File Offset: 0x00706288
	public bool AddTriggerBuff(BuffInfoData buffInfo)
	{
		if (buffInfo == null)
		{
			return false;
		}
		if (buffInfo.condition <= BuffCondition.NONE)
		{
			return false;
		}
		int condition = (int)buffInfo.condition;
		if (!this.triggerBuffList.ContainsKey(condition))
		{
			List<BuffInfoData> value = new List<BuffInfoData>();
			this.triggerBuffList.Add(condition, value);
		}
		this.triggerBuffList[condition].Add(buffInfo);
		buffInfo.OnAdd(this.actor);
		return true;
	}

	// Token: 0x06016DD5 RID: 93653 RVA: 0x00707EF8 File Offset: 0x007062F8
	public void RemoveTriggerBuff(int buffInfoID)
	{
		if (buffInfoID <= 0)
		{
			return;
		}
		BuffInfoData buffInfoData = new BuffInfoData(buffInfoID, 0, 0);
		if (buffInfoData.condition <= BuffCondition.NONE)
		{
			return;
		}
		int condition = (int)buffInfoData.condition;
		if (!this.triggerBuffList.ContainsKey(condition))
		{
			return;
		}
		List<BuffInfoData> list = this.triggerBuffList[condition];
		list.RemoveAll(delegate(BuffInfoData x)
		{
			if (x.buffInfoID == buffInfoID)
			{
				x.DoRelease();
				x.OnRemove(this.actor);
				return true;
			}
			return false;
		});
	}

	// Token: 0x06016DD6 RID: 93654 RVA: 0x00707F7C File Offset: 0x0070637C
	public BuffInfoData GetTriggerBuff(BuffInfoData buffInfo)
	{
		if (buffInfo == null)
		{
			return null;
		}
		int condition = (int)buffInfo.condition;
		if (!this.triggerBuffList.ContainsKey(condition))
		{
			return null;
		}
		List<BuffInfoData> list = this.triggerBuffList[condition];
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].buffInfoID == buffInfo.buffInfoID)
			{
				return list[i];
			}
		}
		return null;
	}

	// Token: 0x06016DD7 RID: 93655 RVA: 0x00707FFC File Offset: 0x007063FC
	public void TriggerBuffs(BuffCondition condition, BeActor target = null, object var1 = null)
	{
		List<BuffInfoData> list = null;
		if (this.triggerBuffList.ContainsKey((int)condition))
		{
			list = this.triggerBuffList[(int)condition];
		}
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			BuffInfoData buffInfo = list[i];
			this.TriggerBuffInfo(buffInfo, target, var1);
		}
	}

	// Token: 0x06016DD8 RID: 93656 RVA: 0x00708058 File Offset: 0x00706458
	public void TriggerBuffInfo(BuffInfoData buffInfo, BeActor target = null, object var1 = null)
	{
		if (buffInfo == null)
		{
			return;
		}
		if (buffInfo.condition == BuffCondition.RELEASE_SEPCIFY_SKILL || buffInfo.condition == BuffCondition.RELEASE_SEPCIFY_SKILL_HIT || buffInfo.condition == BuffCondition.RELEASE_SEPCIFY_SKILL_COMPLETE)
		{
			int skillID = 0;
			if (var1 != null)
			{
				skillID = (int)var1;
			}
			if (!buffInfo.ContainSkillID(skillID))
			{
				return;
			}
			if (this.actor != null && this.actor.attribute != null && this.actor.attribute.monsterData != null && this.actor.attribute.monsterData.MonsterMode != buffInfo.monsterMode)
			{
				return;
			}
		}
		int[] array = new int[]
		{
			GlobalLogic.VALUE_1000
		};
		this.actor.TriggerEvent(BeEventType.onChangeBuffTargetRadius, new object[]
		{
			buffInfo.buffInfoID,
			array
		});
		BuffInfoData buffInfo2 = buffInfo;
		buffInfo2.buffTargetRangeRadius *= VFactor.NewVFactor(array[0], GlobalLogic.VALUE_1000);
		bool flag = true;
		if (target != null && target.attribute != null && target.attribute.monsterData != null && buffInfo.monsterMode != 0 && target.attribute.monsterData.MonsterMode != buffInfo.monsterMode)
		{
			flag = false;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		if (buffInfo.target == BuffTarget.RANGE_ENEMY)
		{
			this.actor.CurrentBeScene.FindTargets(list, this.actor, VInt.NewVInt((long)buffInfo.buffTargetRangeRadius, (long)GlobalLogic.VALUE_1000), false, null);
		}
		else if (buffInfo.target == BuffTarget.RANGE_FRIEND)
		{
			this.actor.CurrentBeScene.FindTargets(list, this.actor, VInt.NewVInt((long)buffInfo.buffTargetRangeRadius, (long)GlobalLogic.VALUE_1000), true, null);
		}
		else if (buffInfo.target == BuffTarget.RANGE_FRIEND_ADNSELF)
		{
			this.actor.CurrentBeScene.FindTargets(list, this.actor, VInt.NewVInt((long)buffInfo.buffTargetRangeRadius, (long)GlobalLogic.VALUE_1000), true, null);
		}
		else if (buffInfo.target == BuffTarget.ENEMY)
		{
			if (target != null && target.GetCamp() != this.actor.GetCamp() && flag)
			{
				list.Add(target);
			}
		}
		else if (buffInfo.target == BuffTarget.SELF || buffInfo.target == BuffTarget.SKILL)
		{
			if (buffInfo.target == BuffTarget.SKILL || flag)
			{
				list.Add(this.actor);
			}
		}
		else if (buffInfo.target == BuffTarget.RANGE_FRIENDHERO)
		{
			BeUtility.GetAllFriendPlayers(this.actor, list);
		}
		else if (buffInfo.target == BuffTarget.RANGE_ENEMYHERO)
		{
			BeUtility.GetAllEnemyPlayers(this.actor, list);
		}
		else if (buffInfo.target == BuffTarget.RANGE_FRIEND_NOTSUMMON)
		{
			BeGetRangeFriendNotSummon filter = new BeGetRangeFriendNotSummon();
			this.actor.CurrentBeScene.FindTargets(list, this.actor, VInt.NewVInt((long)buffInfo.buffTargetRangeRadius, (long)GlobalLogic.VALUE_1000), true, filter);
		}
		else if (buffInfo.target == BuffTarget.OUT_OF_RANGE_ENEMY)
		{
			BeGetConcentricCircleTarget beGetConcentricCircleTarget = new BeGetConcentricCircleTarget();
			beGetConcentricCircleTarget.m_Owner = this.actor;
			beGetConcentricCircleTarget.m_OwnerPosXY = new VInt2(this.actor.GetPosition().x, this.actor.GetPosition().y);
			beGetConcentricCircleTarget.m_MinCircleRadius = VInt.NewVInt(buffInfo.buffTargetRangeRadius, GlobalLogic.VALUE_1000);
			beGetConcentricCircleTarget.m_MaxCircleRadius = BeGetConcentricCircleTarget.LargeMaxCirleRadius;
			this.actor.CurrentBeScene.GetFilterTarget(list, beGetConcentricCircleTarget, true);
		}
		if (!buffInfo.IsCD())
		{
			if (list != null)
			{
				VRate buffAddRate = VRate.zero;
				if (buffInfo.target == BuffTarget.RANGE_ENEMY || buffInfo.target == BuffTarget.RANGE_FRIEND || buffInfo.target == BuffTarget.RANGE_FRIEND_ADNSELF || buffInfo.target == BuffTarget.RANGE_FRIENDHERO || buffInfo.target == BuffTarget.RANGE_ENEMYHERO || buffInfo.target == BuffTarget.RANGE_FRIEND_NOTSUMMON || buffInfo.target == BuffTarget.OUT_OF_RANGE_ENEMY)
				{
					if (buffInfo.prob >= GlobalLogic.VALUE_1000)
					{
						buffAddRate = VRate.one;
					}
					else
					{
						int num = (int)this.FrameRandom.Range1000();
						if (num > buffInfo.prob)
						{
							ListPool<BeActor>.Release(list);
							return;
						}
						buffAddRate = VRate.one;
					}
				}
				bool flag2 = false;
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] != null)
					{
						BeActor realTarget = list[i];
						if (buffInfo.delay > 0)
						{
							realTarget.delayCaller.DelayCall(buffInfo.delay, delegate
							{
								this.RealAddBuff(realTarget, buffInfo, buffAddRate);
							}, 0, 0, false);
						}
						else
						{
							flag2 |= this.RealAddBuff(realTarget, buffInfo, buffAddRate);
						}
					}
				}
				if (flag2)
				{
					this.addTriggerBuffParam[0] = buffInfo;
					this.actor.TriggerEvent(BeEventType.onAddTriggerBuff, this.addTriggerBuffParam);
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06016DD9 RID: 93657 RVA: 0x007086A0 File Offset: 0x00706AA0
	private bool RealAddBuff(BeActor realTarget, BuffInfoData buffInfo, VRate buffAddRate)
	{
		bool result = false;
		if (buffInfo.buffID == -1 && (int)this.FrameRandom.Range1000() <= buffInfo.prob)
		{
			realTarget.TriggerEvent(BeEventType.onPetSkill, null);
			return result;
		}
		BeBuff beBuff = realTarget.buffController.TryAddBuff(buffInfo, this.actor, false, buffAddRate, this.actor);
		if (beBuff != null)
		{
			result = true;
			if (!buffInfo.IsCD())
			{
				buffInfo.StartCD();
			}
		}
		return result;
	}

	// Token: 0x06016DDA RID: 93658 RVA: 0x0070871C File Offset: 0x00706B1C
	public void UpdateRangeTriggerBuff(int delta)
	{
		if (!this.triggerBuffList.ContainsKey(4))
		{
			return;
		}
		List<BuffInfoData> list = this.triggerBuffList[4];
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].UpdateCheckRange(delta, this.actor);
		}
	}

	// Token: 0x06016DDB RID: 93659 RVA: 0x0070877C File Offset: 0x00706B7C
	public void RemoveRangerTriggerBuff()
	{
		if (!this.triggerBuffList.ContainsKey(4))
		{
			return;
		}
		List<BuffInfoData> list = this.triggerBuffList[4];
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].DoRelease();
		}
	}

	// Token: 0x06016DDC RID: 93660 RVA: 0x007087D4 File Offset: 0x00706BD4
	public void UpdateBuffInfo(int delta)
	{
		for (int i = 1; i < 28; i++)
		{
			if (this.triggerBuffList.ContainsKey(i))
			{
				List<BuffInfoData> list = this.triggerBuffList[i];
				if (list != null)
				{
					for (int j = 0; j < list.Count; j++)
					{
						list[j].Update(delta);
					}
				}
			}
		}
	}

	// Token: 0x06016DDD RID: 93661 RVA: 0x00708848 File Offset: 0x00706C48
	public bool HaveBatiBuff()
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff != null)
			{
				if (!beBuff.CanRemove())
				{
					if (beBuff.buffType == BuffType.BATI)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06016DDE RID: 93662 RVA: 0x007088A8 File Offset: 0x00706CA8
	public bool HaveBatiNoPauseBuff()
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff != null)
			{
				if (!beBuff.CanRemove())
				{
					if (beBuff.buffType == BuffType.BATI_NO_PAUSE)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06016DDF RID: 93663 RVA: 0x0070890C File Offset: 0x00706D0C
	public void RemoveAllAbnormalBuff()
	{
		bool flag = false;
		for (int i = this.buffList.Count - 1; i >= 0; i--)
		{
			BeBuff beBuff = this.buffList[i];
			if (beBuff != null && !beBuff.CanRemove())
			{
				if (this.IsAbnormalBuff(beBuff.buffType))
				{
					beBuff.Cancel();
					flag = true;
				}
			}
		}
		if (flag)
		{
			this.buffList.RemoveAll(new Predicate<BeBuff>(this.CheckCanRemoveBuff));
		}
	}

	// Token: 0x06016DE0 RID: 93664 RVA: 0x00708994 File Offset: 0x00706D94
	public void RefreshAbnormalData(BeBuff buff)
	{
		if (buff == null || buff.buffData.Overlay != 5)
		{
			return;
		}
		if (this.GetFirstAbnormalBuff(buff.buffID) == null)
		{
			buff.abnormalBuffData.isFirst = true;
		}
	}

	// Token: 0x06016DE1 RID: 93665 RVA: 0x007089D8 File Offset: 0x00706DD8
	public BeBuff GetFirstAbnormalBuff(int buffId)
	{
		if (buffId > 0)
		{
			for (int i = 0; i < this.buffList.Count; i++)
			{
				if (this.buffList[i] != null && this.buffList[i].buffID == buffId && this.buffList[i].abnormalBuffData.isFirst)
				{
					return this.buffList[i];
				}
			}
		}
		return null;
	}

	// Token: 0x06016DE2 RID: 93666 RVA: 0x00708A5C File Offset: 0x00706E5C
	public BeBuff GetBuffButSelf(BeBuff buff, int buffId)
	{
		for (int i = 0; i < this.buffList.Count; i++)
		{
			if (this.buffList[i] != null && this.buffList[i].buffID == buffId && this.buffList[i] != buff)
			{
				return this.buffList[i];
			}
		}
		return null;
	}

	// Token: 0x06016DE3 RID: 93667 RVA: 0x00708AD0 File Offset: 0x00706ED0
	public int GetAbnormalDamage(int buffId)
	{
		int num = 0;
		for (int i = 0; i < this.buffList.Count; i++)
		{
			if (this.buffList[i] != null && this.buffList[i].buffID == buffId)
			{
				num += this.buffList[i].GetAloneAbnormalDamage();
			}
		}
		return num;
	}

	// Token: 0x06016DE4 RID: 93668 RVA: 0x00708B40 File Offset: 0x00706F40
	public void RefreshBuffStateOnReborn()
	{
		if (this.actor.CurrentBeBattle == null)
		{
			return;
		}
		if (this.actor.CurrentBeBattle.HasFlag(BattleFlagType.HandleRemoveOptimize))
		{
			return;
		}
		for (int i = 0; i < this.buffList.Count; i++)
		{
			BeBuff beBuff = this.buffList[i];
			beBuff.OnOwnerReborn();
		}
	}

	// Token: 0x04010595 RID: 66965
	protected BeActor actor;

	// Token: 0x04010596 RID: 66966
	protected List<BeBuff> buffList = new List<BeBuff>();

	// Token: 0x04010597 RID: 66967
	protected List<BeBuff> phaseDeleteBuffList = new List<BeBuff>();

	// Token: 0x04010598 RID: 66968
	protected List<BeBuff> finishDeleteBuffList = new List<BeBuff>();

	// Token: 0x04010599 RID: 66969
	protected List<BeBuff> finishDeleteAllBuffList = new List<BeBuff>();

	// Token: 0x0401059A RID: 66970
	protected Dictionary<int, List<BuffInfoData>> triggerBuffList = new Dictionary<int, List<BuffInfoData>>();

	// Token: 0x0401059B RID: 66971
	protected List<BeBuff> buffListCache = new List<BeBuff>();

	// Token: 0x0401059C RID: 66972
	private object[] addTriggerBuffParam = new object[1];
}
