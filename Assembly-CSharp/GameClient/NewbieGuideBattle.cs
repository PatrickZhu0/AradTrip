using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020045B7 RID: 17847
	public class NewbieGuideBattle : BaseNewbieGuideBattle
	{
		// Token: 0x06018FEE RID: 102382 RVA: 0x007E007C File Offset: 0x007DE47C
		public NewbieGuideBattle(BattleType type, eDungeonMode mode, int id) : base(type, eDungeonMode.Test, id)
		{
		}

		// Token: 0x06018FEF RID: 102383 RVA: 0x007E00E4 File Offset: 0x007DE4E4
		protected sealed override float _getSkillCDReduceRate()
		{
			NewBieGuideJobData tableItem = Singleton<TableManager>.instance.GetTableItem<NewBieGuideJobData>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return (float)tableItem.CDReduceRate / 1000f;
			}
			return 0f;
		}

		// Token: 0x06018FF0 RID: 102384 RVA: 0x007E012C File Offset: 0x007DE52C
		protected sealed override int _getSkillLevel()
		{
			NewBieGuideJobData tableItem = Singleton<TableManager>.instance.GetTableItem<NewBieGuideJobData>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.SkillLevel;
			}
			return 1;
		}

		// Token: 0x06018FF1 RID: 102385 RVA: 0x007E0166 File Offset: 0x007DE566
		protected sealed override IEnumerator _startGuide()
		{
			return new ProcessUnit().Append(this._Guide1()).Append(this._Guide2()).Append(this._Guide3()).Sequence();
		}

		// Token: 0x06018FF2 RID: 102386 RVA: 0x007E0193 File Offset: 0x007DE593
		protected sealed override void _onSceneStart()
		{
			this.mDungeonManager.GetBeScene().isUseBossShow = false;
			this.mDungeonManager.GetBeScene().SetTraceDoor(false);
		}

		// Token: 0x06018FF3 RID: 102387 RVA: 0x007E01B8 File Offset: 0x007DE5B8
		public static IList<int> GetNewbieGuidePlayerSkills()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID;
			if (num == 0)
			{
				num = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			}
			NewBieGuideJobData tableItem = Singleton<TableManager>.instance.GetTableItem<NewBieGuideJobData>(num, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.SkillList;
			}
			return null;
		}

		// Token: 0x06018FF4 RID: 102388 RVA: 0x007E0208 File Offset: 0x007DE608
		public static void InitNewbieGuidePlayerInfo(ref RacePlayerInfo info)
		{
			if (DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID > 0)
			{
				info.occupation = (byte)DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID;
			}
			NewBieGuideJobData tableItem = Singleton<TableManager>.instance.GetTableItem<NewBieGuideJobData>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				info.equips = new RaceEquip[tableItem.EquipmentID.Count];
				for (int i = 0; i < tableItem.EquipmentID.Count; i++)
				{
					info.equips[i] = new RaceEquip();
					info.equips[i].id = (uint)tableItem.EquipmentID[i];
					if (i == 0)
					{
						info.equips[i].phyAtk = 1000U;
						info.equips[i].magAtk = 1000U;
						info.equips[i].strengthen = 15;
					}
				}
			}
			info.raceItems = new RaceItem[]
			{
				new RaceItem
				{
					id = 300000105U,
					num = ushort.MaxValue
				},
				new RaceItem
				{
					id = 300000106U,
					num = ushort.MaxValue
				}
			};
		}

		// Token: 0x06018FF5 RID: 102389 RVA: 0x007E0340 File Offset: 0x007DE740
		private IEnumerator _Guide2ComboTips()
		{
			return null;
		}

		// Token: 0x06018FF6 RID: 102390 RVA: 0x007E0343 File Offset: 0x007DE743
		private IEnumerator _Guide3ComboTips()
		{
			return null;
		}

		// Token: 0x06018FF7 RID: 102391 RVA: 0x007E0346 File Offset: 0x007DE746
		private int _Guide2GetMonsterComboID()
		{
			return 2150111;
		}

		// Token: 0x06018FF8 RID: 102392 RVA: 0x007E034D File Offset: 0x007DE74D
		private float _Guide2GetMonsterComboPosition()
		{
			return 2.7f;
		}

		// Token: 0x06018FF9 RID: 102393 RVA: 0x007E0354 File Offset: 0x007DE754
		private int _GuideGetMonsterHP(int room, bool isBoss)
		{
			if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 10)
			{
				if (room != 1)
				{
					if (room != 2)
					{
						if (room == 3)
						{
							if (isBoss)
							{
								return 40000;
							}
							return 40000;
						}
					}
					else
					{
						if (isBoss)
						{
							return 10000;
						}
						return 10000;
					}
				}
				else
				{
					if (isBoss)
					{
						return 10000;
					}
					return 5000;
				}
			}
			else if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 50)
			{
				if (room != 1)
				{
					if (room != 2)
					{
						if (room == 3)
						{
							if (isBoss)
							{
								return 80000;
							}
							return 40000;
						}
					}
					else
					{
						if (isBoss)
						{
							return 14000;
						}
						return 14000;
					}
				}
				else
				{
					if (isBoss)
					{
						return 5000;
					}
					return 5000;
				}
			}
			else if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 30)
			{
				if (room != 1)
				{
					if (room != 2)
					{
						if (room == 3)
						{
							if (isBoss)
							{
								return 90000;
							}
							return 50000;
						}
					}
					else
					{
						if (isBoss)
						{
							return 15000;
						}
						return 10000;
					}
				}
				else
				{
					if (isBoss)
					{
						return 5000;
					}
					return 5000;
				}
			}
			else if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 20)
			{
				if (room != 1)
				{
					if (room != 2)
					{
						if (room == 3)
						{
							if (isBoss)
							{
								return 70000;
							}
							return 40000;
						}
					}
					else
					{
						if (isBoss)
						{
							return 90000;
						}
						return 30000;
					}
				}
				else
				{
					if (isBoss)
					{
						return 5000;
					}
					return 5000;
				}
			}
			else if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 40)
			{
				if (room != 1)
				{
					if (room != 2)
					{
						if (room == 3)
						{
							if (isBoss)
							{
								return 70000;
							}
							return 40000;
						}
					}
					else
					{
						if (isBoss)
						{
							return 90000;
						}
						return 30000;
					}
				}
				else
				{
					if (isBoss)
					{
						return 5000;
					}
					return 5000;
				}
			}
			return 10000;
		}

		// Token: 0x06018FFA RID: 102394 RVA: 0x007E055F File Offset: 0x007DE95F
		private IEnumerator _Guide2InitSkill()
		{
			return base._addExSkill(new int[0], 2f, false);
		}

		// Token: 0x06018FFB RID: 102395 RVA: 0x007E0574 File Offset: 0x007DE974
		private IEnumerator _Guide2AddExSkill()
		{
			NewBieGuideJobData tableItem = Singleton<TableManager>.instance.GetTableItem<NewBieGuideJobData>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int[] array = new int[tableItem.SecondComboSkill.Count];
				for (int i = 0; i < tableItem.SecondComboSkill.Count; i++)
				{
					array[i] = tableItem.SecondComboSkill[i];
				}
				return base._addExSkill(array, 2f, false);
			}
			return base._addExSkill(new int[0], 2f, false);
		}

		// Token: 0x06018FFC RID: 102396 RVA: 0x007E0604 File Offset: 0x007DEA04
		private IEnumerator _Guide3AddExSkill(int step)
		{
			NewBieGuideJobData data = Singleton<TableManager>.instance.GetTableItem<NewBieGuideJobData>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
			int[] skilllist = new int[0];
			if (data != null)
			{
				skilllist = new int[data.ThirdComboSkill.Count];
				for (int i = 0; i < data.ThirdComboSkill.Count; i++)
				{
					skilllist[i] = data.ThirdComboSkill[i];
				}
			}
			if (step == 0)
			{
				base._initExSkill(skilllist);
				base._hideExSkill(skilllist, 3, 4);
				yield break;
			}
			if (step == 1)
			{
				yield return base._addExSkillEx(skilllist, 3, 4);
				yield break;
			}
			yield break;
		}

		// Token: 0x06018FFD RID: 102397 RVA: 0x007E0628 File Offset: 0x007DEA28
		private IEnumerator _Guide3UseFinalSkill()
		{
			if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 10)
			{
				return base._useFinalSkill(1604, 0f, ActorOccupation.SwordMan);
			}
			if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 50)
			{
				return base._useFinalSkill(2517, 0f, ActorOccupation.Gungirl);
			}
			if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 30)
			{
				new ProcessUnit().Append(base._useFinalSkill(2008, 0f, ActorOccupation.MagicMan)).Append(base._createAPC(9080031, 1, 5324)).Sequence();
			}
			else if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 20)
			{
				return base._useFinalSkill(2517, 0f, ActorOccupation.GunMan);
			}
			return base._useFinalSkill(1505, 0f, ActorOccupation.SwordMan);
		}

		// Token: 0x06018FFE RID: 102398 RVA: 0x007E0704 File Offset: 0x007DEB04
		private IEnumerator _Guide2SummonMonster()
		{
			BeActor mainPlayer = this._GuideGetMainPlayer();
			if (mainPlayer != null)
			{
				mainPlayer.ModifyMoveDirection(true, 0);
				mainPlayer.ChangeRunMode(true);
			}
			yield return Yielders.GetWaitForSeconds(0.2f);
			if (mainPlayer != null)
			{
				mainPlayer.ModifyMoveDirection(false, 0);
			}
			yield return Yielders.GetWaitForSeconds(0.5f);
			VInt3 pos = mainPlayer.GetPosition();
			BeActor monster = this.mDungeonManager.GetBeScene().SummonMonster(this._Guide2GetMonsterComboID(), new VInt3(pos.x + VInt.Float2VIntValue(this._Guide2GetMonsterComboPosition()), pos.y, pos.z), 1, null, false, 0, true, 0, false, false);
			monster.buffController.TryAddBuff(31, 2000, 1);
			monster.aiManager.Stop();
			this.mDungeonManager.GetGeScene().CreateEffect("Effects/Hero_Zhaohuanshi/Aosuo/Prefab/Eff_Zhaohuanaosuo_dimian_guo", 0f, monster.GetPosition().vec3, 1f, 1f, false, false);
			yield return Yielders.GetWaitForSeconds(2f);
			yield break;
		}

		// Token: 0x06018FFF RID: 102399 RVA: 0x007E0720 File Offset: 0x007DEB20
		protected IEnumerator _waitForPlayerMove(float t1 = 0.5f, float t2 = 0.5f)
		{
			this.FreazeMonsters(-1, true);
			BeActor mainPlayer = this._GuideGetMainPlayer();
			if (mainPlayer != null)
			{
				mainPlayer.ModifyMoveDirection(true, 0);
				mainPlayer.ChangeRunMode(true);
			}
			yield return Yielders.GetWaitForSeconds(t1);
			if (mainPlayer != null)
			{
				mainPlayer.ModifyMoveDirection(false, 0);
			}
			yield return Yielders.GetWaitForSeconds(t2);
			yield break;
		}

		// Token: 0x06019000 RID: 102400 RVA: 0x007E074C File Offset: 0x007DEB4C
		protected IEnumerator _mainPlayerTalk(string text)
		{
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor != null)
			{
				beActor.m_pkGeActor.ShowHeadDialog(text, false, false, false, false, 3.5f, false);
			}
			yield break;
		}

		// Token: 0x06019001 RID: 102401 RVA: 0x007E0770 File Offset: 0x007DEB70
		protected void _mainPlayerTalkEx(string text)
		{
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor != null)
			{
				beActor.m_pkGeActor.ShowHeadDialog(text, false, false, false, false, 3.5f, false);
			}
		}

		// Token: 0x06019002 RID: 102402 RVA: 0x007E07A0 File Offset: 0x007DEBA0
		private IEnumerator _GuideShowNextRoom(float delays)
		{
			base._DoStateNewbieGuideFunc("_GuideShowNextRoom");
			base.Log("_GuideShowNextRoom delays {0} ", new object[]
			{
				delays
			});
			InvokeMethod.Invoke(delays, delegate()
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuideNextRoom>(FrameLayer.Middle, null, string.Empty);
			});
			yield break;
		}

		// Token: 0x06019003 RID: 102403 RVA: 0x007E07C4 File Offset: 0x007DEBC4
		protected override void ChangeActorAttribute(BeActor actor)
		{
			base.ChangeActorAttribute(actor);
			if (actor.isLocalActor)
			{
				BeEntityData entityData = actor.GetEntityData();
				if (entityData != null)
				{
					NewBieGuideJobData tableItem = Singleton<TableManager>.instance.GetTableItem<NewBieGuideJobData>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						entityData.SetAttributeValue(AttributeType.attackSpeed, tableItem.AttackSpped, true);
						entityData.SetAttributeValue(AttributeType.spellSpeed, tableItem.SpellSpeed, true);
						entityData.SetAttributeValue(AttributeType.moveSpeed, tableItem.WalkSpeed, true);
					}
				}
			}
		}

		// Token: 0x06019004 RID: 102404 RVA: 0x007E0844 File Offset: 0x007DEC44
		private BeActor _GetBoss()
		{
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
			BeActor result = null;
			for (int i = 0; i < fullEntities.Count; i++)
			{
				BeActor beActor = fullEntities[i] as BeActor;
				if (beActor != null && beActor.IsMonster() && beActor.IsBoss())
				{
					result = beActor;
				}
			}
			return result;
		}

		// Token: 0x06019005 RID: 102405 RVA: 0x007E08A8 File Offset: 0x007DECA8
		private IEnumerator _GuideMonsterSpeach(int monsterid, string text, bool isMonster = true)
		{
			BeActor beActor = this._getEntityByID(monsterid, isMonster);
			if (beActor != null)
			{
				beActor.m_pkGeActor.ShowHeadDialog(text, false, false, false, false, 3.5f, false);
			}
			yield break;
		}

		// Token: 0x06019006 RID: 102406 RVA: 0x007E08D8 File Offset: 0x007DECD8
		private void _GuideMonsterSpeachEx(int monsterid, string text, bool isMonster = true)
		{
			BeActor beActor = this._getEntityByID(monsterid, isMonster);
			if (beActor != null)
			{
				beActor.m_pkGeActor.ShowHeadDialog(text, false, false, false, false, 3.5f, false);
			}
		}

		// Token: 0x06019007 RID: 102407 RVA: 0x007E090C File Offset: 0x007DED0C
		private IEnumerator _GuideMonsterUseSkill(int monsterid, int skillid, bool isMonster = true)
		{
			base.Log("_GuideMonsterUseSkill id {0} skill {1}", new object[]
			{
				monsterid,
				skillid
			});
			BeActor beActor = this._getEntityByID(monsterid, isMonster);
			if (beActor != null)
			{
				beActor.buffController.RemoveBuff(31, 0, 0);
				beActor.aiManager.StopCurrentCommand();
				beActor.UseSkill(skillid, true);
			}
			yield break;
		}

		// Token: 0x06019008 RID: 102408 RVA: 0x007E093C File Offset: 0x007DED3C
		private IEnumerator _GuideMainPlayerUseSkill(int skillid)
		{
			base.Log("_GuideMainPlayerUseSkill  skill {0}", new object[]
			{
				skillid
			});
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer != null)
			{
				mainPlayer.playerActor.UseSkill(skillid, true);
			}
			yield break;
		}

		// Token: 0x06019009 RID: 102409 RVA: 0x007E0960 File Offset: 0x007DED60
		private IEnumerator _GuideResetMainPlayerState()
		{
			if (this.mDungeonPlayers == null)
			{
				yield break;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer != null && mainPlayer.playerActor != null)
			{
				mainPlayer.playerActor.Reset();
			}
			yield break;
		}

		// Token: 0x0601900A RID: 102410 RVA: 0x007E097C File Offset: 0x007DED7C
		private IEnumerator _GuideResetMonster(int monsterid, bool isMonster = true)
		{
			BeActor beActor = this._getEntityByID(monsterid, isMonster);
			if (beActor != null)
			{
				beActor.Reset();
			}
			yield break;
		}

		// Token: 0x0601900B RID: 102411 RVA: 0x007E09A8 File Offset: 0x007DEDA8
		private IEnumerator _GuideEnableInputManager(bool bEnable)
		{
			base.Log("_GuideEnableInputManager {0}", new object[]
			{
				bEnable
			});
			if (this.mInputManager == null)
			{
				yield break;
			}
			this.mInputManager.SetEnable(bEnable);
			yield break;
		}

		// Token: 0x0601900C RID: 102412 RVA: 0x007E09CC File Offset: 0x007DEDCC
		private IEnumerator _GuideVisiableInputManager(bool bJoyShow, bool bButtonShow)
		{
			base.Log("_GuideVisiableInputManager Joy{0} Button{1}", new object[]
			{
				bJoyShow,
				bButtonShow
			});
			if (this.mInputManager == null)
			{
				yield break;
			}
			this.mInputManager.SetVisible(bJoyShow, bButtonShow);
			yield break;
		}

		// Token: 0x0601900D RID: 102413 RVA: 0x007E09F8 File Offset: 0x007DEDF8
		private IEnumerator _GuideHackPlayerHPMP(int hp, int mp)
		{
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor != null)
			{
				BattleData battleData = beActor.GetEntityData().battleData;
				battleData.maxHp = hp;
				battleData.hp = hp;
				battleData.maxMp = mp;
				battleData.mp = mp;
				beActor.m_pkGeActor.ResetHPBar();
			}
			yield break;
		}

		// Token: 0x0601900E RID: 102414 RVA: 0x007E0A24 File Offset: 0x007DEE24
		private IEnumerator _GuideHackMonsterHP(int hp, bool bSetBoss = false)
		{
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
			for (int i = 0; i < fullEntities.Count; i++)
			{
				BeActor beActor = fullEntities[i] as BeActor;
				if (beActor != null && beActor.IsMonster() && (!bSetBoss || beActor.IsBoss()))
				{
					BattleData battleData = beActor.GetEntityData().battleData;
					battleData.maxHp = hp;
					battleData.hp = hp;
					beActor.m_pkGeActor.ResetHPBar();
				}
			}
			yield break;
		}

		// Token: 0x0601900F RID: 102415 RVA: 0x007E0A50 File Offset: 0x007DEE50
		private IEnumerator _GuideHackMainPlayerDex()
		{
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor != null)
			{
				BattleData battleData = beActor.GetEntityData().battleData;
				beActor.GetEntityData().battleData.dex = 2000;
				battleData.ciriticalAttack = 0;
				battleData.ciriticalMagicAttack = 0;
			}
			yield break;
		}

		// Token: 0x06019010 RID: 102416 RVA: 0x007E0A6C File Offset: 0x007DEE6C
		private BeActor _GuideGetMainPlayer()
		{
			if (this.mDungeonManager == null)
			{
				return null;
			}
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
			BeActor result = null;
			for (int i = 0; i < fullEntities.Count; i++)
			{
				BeEntity beEntity = fullEntities[i];
				if (beEntity.GetCamp() == 0)
				{
					result = (beEntity as BeActor);
					break;
				}
			}
			return result;
		}

		// Token: 0x06019011 RID: 102417 RVA: 0x007E0AD0 File Offset: 0x007DEED0
		private IEnumerator _GuideLockPlayerMove(bool bLock)
		{
			base.Log("_GuideLockPlayerMove bLock {0} ", new object[]
			{
				bLock
			});
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor == null)
			{
				yield break;
			}
			beActor.bLockMove = bLock;
			beActor.ResetMoveCmd();
			beActor.SetAttackButtonState(ButtonState.RELEASE, true);
			yield break;
		}

		// Token: 0x06019012 RID: 102418 RVA: 0x007E0AF4 File Offset: 0x007DEEF4
		private IEnumerator _Guide2Begin()
		{
			yield return base._waitForState(BeSceneState.onReady);
			base._DoStateNewbieGuideFunc("_Guide2Begin");
			yield return this._GuideLockPlayerMove(true);
			if (this.fingerDoubleMove != null)
			{
				Object.Destroy(this.fingerDoubleMove);
			}
			this.fingerDoubleMove = null;
			if (this.mInputManager == null)
			{
				yield break;
			}
			this.mInputManager.SetVisible(false);
			this.FreazeMonsters(-1, true);
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideNextRoom>(null, false);
			yield return this._HideGuideTips(0f);
			yield break;
		}

		// Token: 0x06019013 RID: 102419 RVA: 0x007E0B10 File Offset: 0x007DEF10
		private IEnumerator _GuideUnFreaseMonsters(float delays)
		{
			InvokeMethod.Invoke(delays, delegate()
			{
				this.UnFreazeMonsters(-1, true);
			});
			yield break;
		}

		// Token: 0x06019014 RID: 102420 RVA: 0x007E0B34 File Offset: 0x007DEF34
		private IEnumerator _ShowGuideTips(string text, float showtime, bool bLeft = true)
		{
			InvokeMethod.Invoke(showtime, delegate()
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
				NewbieGuidTipsFrame newbieGuidTipsFrame = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuidTipsFrame>(FrameLayer.Top, bLeft, string.Empty) as NewbieGuidTipsFrame;
				newbieGuidTipsFrame.SetTipsText(text);
			});
			yield break;
		}

		// Token: 0x06019015 RID: 102421 RVA: 0x007E0B60 File Offset: 0x007DEF60
		private IEnumerator _ShowGuideTipsEx3(string text, float delaytime, float showtime, bool bLeft = true)
		{
			InvokeMethod.Invoke(delaytime, delegate()
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
				NewbieGuidTipsFrame newbieGuidTipsFrame = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuidTipsFrame>(FrameLayer.Top, bLeft, string.Empty) as NewbieGuidTipsFrame;
				newbieGuidTipsFrame.SetTipsText(text);
			});
			InvokeMethod.Invoke(delaytime + showtime, delegate()
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
			});
			yield break;
		}

		// Token: 0x06019016 RID: 102422 RVA: 0x007E0B94 File Offset: 0x007DEF94
		private IEnumerator _WaitForUnitEvent(int id, bool isMonster, BeEventType e)
		{
			base.Log("_WaitForUnitEvent id {0} isMonster {1} BeEventType {2}", new object[]
			{
				id,
				isMonster,
				e
			});
			BeActor current = this._getEntityByID(id, isMonster);
			if (current != null)
			{
				bool bWaited = false;
				current.RegisterEvent(e, delegate(object[] args)
				{
					bWaited = true;
				});
				while (!bWaited)
				{
					yield return Yielders.EndOfFrame;
				}
				yield break;
			}
			Logger.LogError("[_WaitForUnitEvent] 找不到 id" + id);
			yield break;
		}

		// Token: 0x06019017 RID: 102423 RVA: 0x007E0BC4 File Offset: 0x007DEFC4
		private IEnumerator _ShowGuideTipsEx(string text, float showtime, float speed, float delay, bool bLeft = true)
		{
			base.Log("_ShowGuideTipsEx text {0} ", new object[]
			{
				text
			});
			InvokeMethod.Invoke(showtime, delegate()
			{
				this._DoStateNewbieGuideFunc("_ShowGuideTipsEx" + text);
				Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
				NewbieGuidTipsFrame newbieGuidTipsFrame = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuidTipsFrame>(FrameLayer.Top, bLeft, string.Empty) as NewbieGuidTipsFrame;
				newbieGuidTipsFrame.SetTipsTextEx(text, speed, delay);
			});
			yield break;
		}

		// Token: 0x06019018 RID: 102424 RVA: 0x007E0C04 File Offset: 0x007DF004
		private IEnumerator _ShowGuideTipsEx2(string text, float showtime, bool bLeft = true)
		{
			base.Log("_ShowGuideTipsEx2 text {0} ", new object[]
			{
				text
			});
			InvokeMethod.Invoke(showtime, delegate()
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
				NewbieGuidTipsFrame newbieGuidTipsFrame = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuidTipsFrame>(FrameLayer.Top, bLeft, string.Empty) as NewbieGuidTipsFrame;
				newbieGuidTipsFrame.SetTipsTextEx(text, 0.05f, 1.5f);
			});
			yield break;
		}

		// Token: 0x06019019 RID: 102425 RVA: 0x007E0C34 File Offset: 0x007DF034
		private IEnumerator _HideGuideTips(float showtime)
		{
			base.Log("_HideGuideTips  showtime {0}", new object[]
			{
				showtime
			});
			InvokeMethod.Invoke(showtime, delegate()
			{
				base.Log("_HideGuideTips", new object[0]);
				Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
			});
			yield break;
		}

		// Token: 0x0601901A RID: 102426 RVA: 0x007E0C58 File Offset: 0x007DF058
		private IEnumerator _rightShowGuideTip(string text, float showTime, bool bLeft = true)
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
			NewbieGuidTipsFrame tips = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuidTipsFrame>(FrameLayer.Top, bLeft, string.Empty) as NewbieGuidTipsFrame;
			tips.SetTipsText(text);
			yield return Yielders.GetWaitForSeconds(showTime);
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
			yield break;
		}

		// Token: 0x0601901B RID: 102427 RVA: 0x007E0C84 File Offset: 0x007DF084
		private IEnumerator _GuildeHackMainPlayerCDandCost(int cd, int mp)
		{
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor != null)
			{
				BattleData battleData = beActor.GetEntityData().battleData;
				battleData.cdReduceRate = cd;
				battleData.mpCostReduceRate = mp;
			}
			yield break;
		}

		// Token: 0x0601901C RID: 102428 RVA: 0x007E0CB0 File Offset: 0x007DF0B0
		private BeActor _getEntityByID(int id = -1, bool isMonster = true)
		{
			if (this.mDungeonManager == null)
			{
				return null;
			}
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
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
					BeEntity playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
					if (beActor != playerActor)
					{
						flag = true;
					}
				}
				if (flag)
				{
					return beActor;
				}
			}
			return null;
		}

		// Token: 0x0601901D RID: 102429 RVA: 0x007E0D98 File Offset: 0x007DF198
		private IEnumerator GetupMonster(int id = -1, bool isMonster = true)
		{
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.buffController.TryAddBuff(31, -1, 1);
				beActor.hasAI = false;
				beActor.Reset();
				beActor.m_pkGeActor.ChangeAction("Anim_Xiadun", 1f, true, true, true);
			}
			yield break;
		}

		// Token: 0x0601901E RID: 102430 RVA: 0x007E0DC4 File Offset: 0x007DF1C4
		private IEnumerator WeakMonster(int id = -1, bool isMonster = true)
		{
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.buffController.TryAddBuff(31, -1, 1);
				beActor.hasAI = false;
				beActor.Reset();
				beActor.PlayAction(ActionType.ActionType_DEAD, 1f, false);
			}
			yield break;
		}

		// Token: 0x0601901F RID: 102431 RVA: 0x007E0DF0 File Offset: 0x007DF1F0
		private IEnumerator DeadMonster(int id, bool isMonster = true)
		{
			base.Log("dead monster id:{0}", new object[]
			{
				id
			});
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.DoDead(false);
			}
			yield break;
		}

		// Token: 0x06019020 RID: 102432 RVA: 0x007E0E1C File Offset: 0x007DF21C
		private IEnumerator SetMonsterBlock(int id, bool block = true, bool isMonster = true)
		{
			base.Log("SetMonsterBlock id {0} block {1} isMonster {2}", new object[]
			{
				id,
				block,
				isMonster
			});
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.stateController.SetAbilityEnable(BeAbilityType.BLOCK, block);
			}
			yield break;
		}

		// Token: 0x06019021 RID: 102433 RVA: 0x007E0E4C File Offset: 0x007DF24C
		private IEnumerator SetMonsterZhenWudi(int id, bool zhenwudi = true, bool isMonster = true)
		{
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.stateController.SetAbilityEnable(BeAbilityType.FALLGROUND, zhenwudi);
				beActor.stateController.SetAbilityEnable(BeAbilityType.FLOAT, zhenwudi);
				beActor.stateController.SetAbilityEnable(BeAbilityType.BEGRAB, zhenwudi);
				beActor.stateController.SetAbilityEnable(BeAbilityType.BEBREAK, zhenwudi);
			}
			yield break;
		}

		// Token: 0x06019022 RID: 102434 RVA: 0x007E0E7C File Offset: 0x007DF27C
		private IEnumerator SetMainplayerZhenwudi(bool zhenwudi)
		{
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor != null)
			{
				beActor.stateController.SetAbilityEnable(BeAbilityType.FALLGROUND, zhenwudi);
				beActor.stateController.SetAbilityEnable(BeAbilityType.FLOAT, zhenwudi);
				beActor.stateController.SetAbilityEnable(BeAbilityType.BEGRAB, zhenwudi);
				beActor.stateController.SetAbilityEnable(BeAbilityType.BEBREAK, zhenwudi);
			}
			yield break;
		}

		// Token: 0x06019023 RID: 102435 RVA: 0x007E0EA0 File Offset: 0x007DF2A0
		private IEnumerator SetMonsterBatiShow(int id, bool batiShow, bool isMonster)
		{
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				if (batiShow)
				{
					beActor.m_pkGeActor.ChangeSurface("霸体", 0f, true, true);
				}
				else
				{
					beActor.m_pkGeActor.RemoveSurface(uint.MaxValue);
				}
			}
			yield break;
		}

		// Token: 0x06019024 RID: 102436 RVA: 0x007E0ED0 File Offset: 0x007DF2D0
		private IEnumerator WaitMonsterHPLow(float percent, int id, bool isMonster)
		{
			BeActor current = this._getEntityByID(id, isMonster);
			if (current != null)
			{
				while (current != null && current.GetEntityData().GetHPRate().single > percent)
				{
					yield return Yielders.EndOfFrame;
				}
			}
			yield break;
		}

		// Token: 0x06019025 RID: 102437 RVA: 0x007E0F00 File Offset: 0x007DF300
		private IEnumerator MonsterTalk(string text, int id = -1, bool isMonster = true)
		{
			base._DoStateNewbieGuideFunc("MonsterTalk " + text);
			base.Log("MonsterTalk Text {0} id {1} isMonster {2}", new object[]
			{
				text,
				id,
				isMonster
			});
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.m_pkGeActor.ShowHeadDialog(text, false, false, false, false, 3.5f, false);
			}
			yield break;
		}

		// Token: 0x06019026 RID: 102438 RVA: 0x007E0F30 File Offset: 0x007DF330
		private IEnumerator FreazeMonsters(int id = -1, bool isMonster = true)
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			if (this.mDungeonManager.GetBeScene() != null)
			{
				List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
				if (fullEntities != null)
				{
					for (int i = 0; i < fullEntities.Count; i++)
					{
						BeActor beActor = fullEntities[i] as BeActor;
						if (beActor != null)
						{
							BeEntityData entityData = beActor.GetEntityData();
							if (entityData != null)
							{
								bool flag = false;
								if (isMonster)
								{
									if (beActor != null && beActor.IsMonster() && (id == -1 || id == entityData.monsterID))
									{
										flag = true;
									}
								}
								else if (beActor != null && beActor.GetCamp() == 0 && (id == -1 || id == entityData.monsterID) && this.mDungeonPlayers != null && this.mDungeonPlayers.GetMainPlayer() != null)
								{
									BeEntity playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
									if (beActor != playerActor)
									{
										flag = true;
									}
								}
								if (beActor != null && flag)
								{
									base.Log("FreazeMonsters {0} isMonster {1}", new object[]
									{
										id,
										isMonster
									});
									if (beActor.buffController != null)
									{
										beActor.buffController.TryAddBuff(31, -1, 1);
									}
									beActor.hasAI = false;
									beActor.Reset();
								}
							}
						}
					}
				}
				yield break;
			}
			yield break;
		}

		// Token: 0x06019027 RID: 102439 RVA: 0x007E0F5C File Offset: 0x007DF35C
		private IEnumerator AddMonstersBuff(int id, bool isMonster, int bufferid, int time = -1)
		{
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
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
					BeEntity playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
					if (beActor != playerActor)
					{
						flag = true;
					}
				}
				if (flag)
				{
					beActor.buffController.TryAddBuff(bufferid, time, 1);
				}
			}
			yield break;
		}

		// Token: 0x06019028 RID: 102440 RVA: 0x007E0F94 File Offset: 0x007DF394
		private IEnumerator RemoveMonstersBuff(int id, bool isMonster, int bufferid)
		{
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
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
					BeEntity playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
					if (beActor != playerActor)
					{
						flag = true;
					}
				}
				if (flag)
				{
					beActor.buffController.RemoveBuff(bufferid, 0, 0);
				}
			}
			yield break;
		}

		// Token: 0x06019029 RID: 102441 RVA: 0x007E0FC4 File Offset: 0x007DF3C4
		private IEnumerator SetMainPlayerFaceMonster(int mid)
		{
			BeActor beActor = this._GuideGetMainPlayer();
			BeActor beActor2 = this._getEntityByID(mid, true);
			if (beActor != null && beActor2 != null)
			{
				beActor.SetFace(beActor2.GetPosition().x < beActor.GetPosition().x, true, false);
				float f = 1.6f;
				VInt3 position = beActor.GetPosition();
				position.z = 0;
				if (beActor.GetFace())
				{
					position.x += VInt.Float2VIntValue(f);
				}
				else
				{
					position.x -= VInt.Float2VIntValue(f);
				}
				if (beActor.CurrentBeScene.IsInBlockPlayer(position))
				{
					beActor.SetFace(!beActor.GetFace(), true, false);
				}
			}
			yield break;
		}

		// Token: 0x0601902A RID: 102442 RVA: 0x007E0FE8 File Offset: 0x007DF3E8
		private IEnumerator SetKillMask(int id = -1, bool isMonster = true, bool bAdd = true)
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
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
					BeEntity playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
					if (beActor != playerActor)
					{
						flag = true;
					}
				}
				if (flag)
				{
					beActor.m_pkGeActor.AddKillMark();
				}
			}
			yield break;
		}

		// Token: 0x0601902B RID: 102443 RVA: 0x007E1014 File Offset: 0x007DF414
		private IEnumerator UnFreazeMonsters(int id = -1, bool isMonster = true)
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
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
					BeEntity playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
					if (beActor != playerActor)
					{
						flag = true;
					}
				}
				if (flag)
				{
					base.Log("UnFreazeMonsters {0} isMonster {1}", new object[]
					{
						id,
						isMonster
					});
					beActor.buffController.RemoveBuff(31, 0, 0);
					beActor.hasAI = true;
					beActor.Reset();
					beActor.StartAI(null, true);
				}
			}
			yield break;
		}

		// Token: 0x0601902C RID: 102444 RVA: 0x007E1040 File Offset: 0x007DF440
		private IEnumerator _Parallel(float delay, UnityAction ation)
		{
			InvokeMethod.Invoke(delay, ation);
			yield break;
		}

		// Token: 0x0601902D RID: 102445 RVA: 0x007E1064 File Offset: 0x007DF464
		private IEnumerator _addBuffer2MainPlayer(int bufferid)
		{
			BeActor beActor = this._GuideGetMainPlayer();
			if (beActor != null)
			{
				beActor.buffController.TryAddBuff(bufferid, -1, 1);
			}
			yield break;
		}

		// Token: 0x0601902E RID: 102446 RVA: 0x007E1088 File Offset: 0x007DF488
		private IEnumerator _Guide3Begin()
		{
			yield return base._waitForState(BeSceneState.onReady);
			this.mInputManager.SetVisible(false);
			this.boss = this._GetBoss();
			this.boss.m_pkGeActor.SetHeadInfoVisible(false);
			this.boss.m_pkGeActor.SetFootIndicatorVisible(false);
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideNextRoom>(null, false);
			yield return this._HideGuideTips(0f);
			yield break;
		}

		// Token: 0x0601902F RID: 102447 RVA: 0x007E10A4 File Offset: 0x007DF4A4
		private IEnumerator _playEffectInScene(string effectpath, float time, Vec3 pos, bool isLoop = false, bool isFaceLeft = false)
		{
			GeEffectEx moveInEffect = this.mDungeonManager.GetGeScene().CreateEffect(effectpath, time, pos, 1f, 1f, isLoop, isFaceLeft);
			yield return base._waitForTime(time, false);
			if (moveInEffect != null)
			{
				this.mDungeonManager.GetGeScene().DestroyEffect(moveInEffect);
			}
			yield break;
		}

		// Token: 0x06019030 RID: 102448 RVA: 0x007E10E4 File Offset: 0x007DF4E4
		private IEnumerator _GuideUseSkill(int index, float timeLen)
		{
			List<GameObject> skillButtons = this.mInputManager.SkillButtons;
			GameObject jumpback = base.LoadUIEffect(skillButtons[index], "UIFlatten/Prefabs/NewbieGuide/ButtonTipsNoButton_newbiebattle", true);
			InvokeMethod.Invoke(timeLen, delegate()
			{
				Object.Destroy(jumpback);
			});
			yield break;
		}

		// Token: 0x06019031 RID: 102449 RVA: 0x007E1110 File Offset: 0x007DF510
		private IEnumerator _GuideJumpback()
		{
			base._DoStateNewbieGuideFunc("_GuideJumpback Guide2 - Begin");
			if (this.mInputManager.SkillButtons == null)
			{
				yield break;
			}
			List<GameObject> list = this.mInputManager.SkillButtons;
			list[2].CustomActive(true);
			yield return this.SetMainPlayerFaceMonster(6300021);
			GameObject jumpback = base.LoadUIEffect(list[2], "UIFlatten/Prefabs/NewbieGuide/ButtonTipsNoButton_newbiebattle", true);
			yield return base._GuideShowSkill(list[2], 0.3f);
			yield return this._ShowGuideTipsEx2("快使用后跳可以快速位移，躲避敌人技能", 0.5f, true);
			bool bInput = false;
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.PauseFight(true, string.Empty, false);
			InputManager.onSkillCommandCallBack = delegate(int id, int value)
			{
				if (id == 2147483646 && this.CanResumeFightJumpBack(bInput))
				{
					bInput = true;
					if (this.mDungeonManager != null)
					{
						this.mDungeonManager.ResumeFight(true, string.Empty, false);
					}
				}
			};
			while (!bInput)
			{
				yield return Yielders.EndOfFrame;
			}
			if (null != jumpback)
			{
				Object.Destroy(jumpback);
				jumpback = null;
			}
			InputManager.onSkillCommandCallBack = null;
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
			base._DoStateNewbieGuideFunc("_GuideJumpback Guide2 - End");
			yield break;
		}

		// Token: 0x06019032 RID: 102450 RVA: 0x007E112B File Offset: 0x007DF52B
		private bool CanResumeFightJumpBack(bool input)
		{
			return !BeClientSwitch.FunctionIsOpen(ClientSwitchType.NewbieGuideJumpBack) || !input;
		}

		// Token: 0x06019033 RID: 102451 RVA: 0x007E1144 File Offset: 0x007DF544
		private IEnumerator _GuideShowJoystickAndSkillButton()
		{
			base._DoStateNewbieGuideFunc("MoveJoyStik Guide1");
			yield return Yielders.GetWaitForSeconds(0.3f);
			yield return this._ShowGuideTips("操作左下方移动按钮，移动到指定位置", 0f, true);
			yield return Yielders.GetWaitForSeconds(0.2f);
			yield return this._GuideEnableInputManager(true);
			if (this.mInputManager == null)
			{
				yield break;
			}
			List<GameObject> list = this.mInputManager.SkillButtons;
			list[0].transform.localScale = Vector3.zero;
			this.mInputManager.SetVisible(true, false);
			GameObject joystick = this.mInputManager.GetJoyStick();
			GameObject fingerMove = base.LoadUIEffect(joystick, "UIFlatten/Prefabs/NewbieGuide/FingerMove", true);
			GeEffectEx moveInEffect = this.mDungeonManager.GetGeScene().CreateEffect("Effects/Scene_effects/Xinshou/Eff_yingdao_dimian", 1000000f, new Vec3(this.moveInPostion.x, this.moveInPostion.z, this.moveInPostion.y), 1f, 1f, false, false);
			while (!FrameSync.instance.bInMoveMode)
			{
				yield return Yielders.EndOfFrame;
			}
			base._DoStateNewbieGuideFunc("MoveJoyStik Guide1 - move");
			yield return this._HideGuideTips(0f);
			yield return this._GuideWaitForPlayerMoveIn(this.moveInPostion, this.moveInRadius);
			yield return this._GuideLockPlayerMove(true);
			Object.Destroy(fingerMove);
			fingerMove = null;
			base._DoStateNewbieGuideFunc("MoveJoyStik Guide1 - moveOver");
			yield return this.SetKillMask(6330021, true, true);
			if (this.mDungeonManager != null)
			{
				this.mDungeonManager.GetGeScene().CreateEffect("Effects/Hero_Zhaohuanshi/Aosuo/Prefab/Eff_Zhaohuanaosuo_dimian_guo 1", 0f, new Vec3(this.moveInPostion.x, this.moveInPostion.z, this.moveInPostion.y), 1f, 2f, false, false);
				this.mDungeonManager.GetGeScene().DestroyEffect(moveInEffect);
			}
			yield return this._HideGuideTips(0f);
			yield return this.UnFreazeMonsters(-1, true);
			if (this.mInputManager != null)
			{
				this.mInputManager.SetVisible(true, true);
			}
			yield return this._ShowGuideTips("点击右下角攻击按钮，击败敌人！", 0f, true);
			if (list[0] != null)
			{
				this.temp = base.LoadUIEffect(list[0], "UIFlatten/Prefabs/NewbieGuide/ButtonTipsNoButton_newbiebattle", true);
				yield return base._GuideShowSkill(list[0], 0.3f);
				bool bInput = false;
				InputManager.onSkillCommandCallBack = delegate(int id, int value)
				{
					bInput = true;
				};
				yield return Yielders.GetWaitForSeconds(0.5f);
				yield return this._GuideLockPlayerMove(false);
				while (!bInput)
				{
					yield return Yielders.EndOfFrame;
				}
				Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
				base._DoStateNewbieGuideFunc("MoveJoyStik Guide1 - FightBegin");
				this.UnFreazeMonsters(-1, true);
			}
			yield break;
		}

		// Token: 0x06019034 RID: 102452 RVA: 0x007E1160 File Offset: 0x007DF560
		private IEnumerator _GuideShowDoubleMove()
		{
			GameObject joystick = this.mInputManager.GetJoyStick();
			this.fingerDoubleMove = base.LoadUIEffect(joystick, "UIFlatten/Prefabs/NewbieGuide/FingerDoubleMove", false);
			while (!FrameSync.instance.bInMoveMode)
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06019035 RID: 102453 RVA: 0x007E117C File Offset: 0x007DF57C
		private IEnumerator _GuideWaitForPlayerMoveIn(Vector3 position, float raduis)
		{
			BeActor actor = this._GuideGetMainPlayer();
			if (actor == null)
			{
				yield break;
			}
			bool bMoveIn = false;
			while (!bMoveIn)
			{
				Vector3 playerPosition = actor.m_pkGeActor.GetPosition();
				bMoveIn = ((playerPosition - position).magnitude < raduis);
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06019036 RID: 102454 RVA: 0x007E11A8 File Offset: 0x007DF5A8
		private IEnumerator _Guide1MonsterMoveForward(float dis, float time)
		{
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
			for (int i = 0; i < fullEntities.Count; i++)
			{
				BeActor beActor = fullEntities[i] as BeActor;
				if (beActor != null && beActor.IsMonster())
				{
					VInt3 position = beActor.GetPosition();
					position.x += VInt.Float2VIntValue(dis);
					beActor.buffController.RemoveBuff(31, 0, 0);
					beActor.aiManager.ExecuteCommand(new BeAISimpleWalkCommand(beActor, position, VInt.Float2VIntValue(0.1f)));
				}
			}
			yield return Yielders.GetWaitForSeconds(time);
			List<BeEntity> fullEntities2 = this.mDungeonManager.GetBeScene().GetFullEntities();
			for (int j = 0; j < fullEntities2.Count; j++)
			{
				BeActor beActor2 = fullEntities2[j] as BeActor;
				if (beActor2 != null && beActor2.IsMonster())
				{
					beActor2.Reset();
				}
			}
			yield break;
		}

		// Token: 0x06019037 RID: 102455 RVA: 0x007E11D4 File Offset: 0x007DF5D4
		private IEnumerator _entityMoveForward(BeActor current, float dis, float time)
		{
			if (current != null)
			{
				VInt3 position = current.GetPosition();
				position.x += VInt.Float2VIntValue(dis);
				current.buffController.RemoveBuff(31, 0, 0);
				current.SetController(new BeActorMoveController(position, 0.1f, true));
				current.ChangeRunMode(true);
				current.ModifyMoveDirection(false, 0);
			}
			yield return Yielders.GetWaitForSeconds(time);
			if (current != null)
			{
				current.ChangeRunMode(false);
				current.ModifyMoveDirection(false, 0);
				current.Reset();
			}
			yield break;
		}

		// Token: 0x06019038 RID: 102456 RVA: 0x007E1200 File Offset: 0x007DF600
		private IEnumerator _mainPlayerMoveForward(float dis, float time)
		{
			base.Log("_mainPlayerMoveForward dis {0} time {1}", new object[]
			{
				dis,
				time
			});
			if (this.mDungeonPlayers == null)
			{
				yield break;
			}
			BeActor current = this.mDungeonPlayers.GetMainPlayer().playerActor;
			yield return this._entityMoveForward(current, dis, time);
			yield break;
		}

		// Token: 0x06019039 RID: 102457 RVA: 0x007E122C File Offset: 0x007DF62C
		private IEnumerator _monsterMoveForward(int id, float dis, float time, bool isMonster = true)
		{
			base.Log("_monsterMoveForward id{0} dis {1} time {2} isMonster {3}", new object[]
			{
				id,
				dis,
				time,
				isMonster
			});
			BeActor current = this._getEntityByID(id, isMonster);
			yield return this._entityMoveForward(current, dis, time);
			yield break;
		}

		// Token: 0x0601903A RID: 102458 RVA: 0x007E1264 File Offset: 0x007DF664
		private IEnumerator _createSummonMonster(int id, Vec3 pos, bool isEnemy, int attack = 200, int level = 20, int hp = 5000, int mp = 5000)
		{
			base.Log("_createSummonMonster id{0} pos {1} isEnemy {2} attack {3} level{4} hp{5} mp{6}", new object[]
			{
				id,
				pos,
				isEnemy,
				attack,
				level,
				hp,
				mp
			});
			BeEntity entity = this.mDungeonManager.GetBeScene().SummonMonster(id, new VInt3(pos), (!isEnemy) ? 0 : 1, null, false, level, false, 0, false, false);
			if (entity != null)
			{
				entity.GetEntityData().battleData.attack = attack;
				entity.GetEntityData().battleData.ciriticalAttack = 0;
				entity.GetEntityData().battleData.ciriticalMagicAttack = 0;
				entity.GetEntityData().battleData.hp = hp;
				entity.GetEntityData().battleData.maxHp = hp;
				entity.GetEntityData().battleData.mp = mp;
				entity.GetEntityData().battleData.maxMp = mp;
				entity.m_pkGeActor.ResetHPBar();
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0601903B RID: 102459 RVA: 0x007E12B4 File Offset: 0x007DF6B4
		private IEnumerator _waitForMonsterCastSkill(int id, int iSkillID)
		{
			bool bCast = false;
			List<BeEntity> entityList = this.mDungeonManager.GetBeScene().GetFullEntities();
			for (int i = 0; i < entityList.Count; i++)
			{
				BeActor beActor = entityList[i] as BeActor;
				if (id == beActor.GetEntityData().monsterID)
				{
					beActor.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
					{
						if (args != null && args.Length == 1)
						{
							int num = (int)args[0];
							if (num == iSkillID)
							{
								bCast = true;
							}
						}
					});
				}
			}
			while (!bCast)
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x0601903C RID: 102460 RVA: 0x007E12E0 File Offset: 0x007DF6E0
		private IEnumerator _waitActorFirstHurt(int id, bool isMonster)
		{
			BeActor current = this._getEntityByID(id, isMonster);
			bool flag = false;
			BeEventHandle h = null;
			if (current != null)
			{
				h = current.RegisterEvent(BeEventType.onHurt, delegate(object[] args)
				{
					flag = true;
				});
			}
			while (!flag)
			{
				yield return Yielders.EndOfFrame;
			}
			if (current != null)
			{
				current.RemoveEvent(h);
				h = null;
			}
			yield break;
		}

		// Token: 0x0601903D RID: 102461 RVA: 0x007E130C File Offset: 0x007DF70C
		private IEnumerator _setMonsterFaceLeft(int id, bool isRight, bool isMonster)
		{
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.SetFace(isRight, true, true);
			}
			yield break;
		}

		// Token: 0x0601903E RID: 102462 RVA: 0x007E133C File Offset: 0x007DF73C
		private IEnumerator _GuideDoorOpen(TransportDoorType type, bool bOpen)
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.GetBeScene().SetTransportDoorEnable(type, bOpen);
			yield break;
		}

		// Token: 0x0601903F RID: 102463 RVA: 0x007E1368 File Offset: 0x007DF768
		private IEnumerator _Guide1()
		{
			return new ProcessUnit().Append(base._DoStateNewbieGuideBegin()).Append(base._DoStateNewbieGuideIter("_Guide1Begin")).Append(base._DoStateNewbieGuideIter("Comic1Begin")).Append(base._waitFrameClose(typeof(NewbieGuideComic1))).Append(base._DoStateNewbieGuideIter("Comic1End")).Append(this.FreazeMonsters(-1, true)).Append(this._GuideEnableInputManager(false)).Append(this._GuideVisiableInputManager(false, false)).Append(this._ShowComicFrame(true)).Append(new ProcessUnit().Append(new ProcessUnit().Append(this._GuideLockPlayerMove(true)).Append(this._mainPlayerMoveForward(1.4f, 0.5f)).Sequence()).Append(new ProcessUnit().Append(base._moveCameraTo(2.2f, 0.8f, 1)).Sequence()).Parallel()).Append(base._waitForDialog(14001)).Append(base._resetCamera(0.5f)).Append(base._setPlayerFrameCommand(true)).Append(base._waitForTime(1f, false)).Append(this.FreazeMonsters(-1, false)).Append(base._waitForState(BeSceneState.onFight)).Append(this._ShowComicFrame(false)).Append(this._GuideLockPlayerMove(false)).Append(this._GuideShowJoystickAndSkillButton()).Append(this._GuideEnableInputManager(true)).Append(this._Parallel(0f, delegate
			{
				if (this.temp != null)
				{
					Object.Destroy(this.temp);
				}
				this.temp = null;
			})).Append(base._waitForState(BeSceneState.onClear)).Append(this._GuideLockPlayerMove(true)).Append(this._GuideResetMainPlayerState()).Append(this._GuideVisiableInputManager(false, false)).Append(this._ShowComicFrame(true)).Append(this._ShowGuideTipsEx("快向右移动，通关传送门到下一个房间吧", 0f, -1f, 1f, false)).Append(base._waitForTime(2f, false)).Append(this._ShowComicFrame(false)).Append(this._GuideVisiableInputManager(true, true)).Append(this._GuideLockPlayerMove(false)).Append(this._GuideShowNextRoom(0f)).Append(this._GuideDoorOpen(TransportDoorType.Right, true)).Sequence();
		}

		// Token: 0x06019040 RID: 102464 RVA: 0x007E15B8 File Offset: 0x007DF9B8
		private int GuideGetMonsterCount(int id, bool isMonster)
		{
			int num = 0;
			List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
			for (int i = 0; i < fullEntities.Count; i++)
			{
				BeActor beActor = fullEntities[i] as BeActor;
				if (isMonster)
				{
					if (beActor != null && beActor.IsMonster() && (id == -1 || id == beActor.GetEntityData().monsterID))
					{
						num++;
					}
				}
				else if (beActor != null && beActor.GetCamp() == 0 && (id == -1 || id == beActor.GetEntityData().monsterID))
				{
					BeEntity playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
					if (beActor != playerActor)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06019041 RID: 102465 RVA: 0x007E168C File Offset: 0x007DFA8C
		private IEnumerator _GuideWaitMonsterNumZero(int id, bool isMonster)
		{
			while (this.GuideGetMonsterCount(id, isMonster) > 0)
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06019042 RID: 102466 RVA: 0x007E16B8 File Offset: 0x007DFAB8
		private IEnumerator _CamreShock(float time, float speed, float x, float y)
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mOriginCameraMode = this.mDungeonManager.GetGeScene().GetCamera().GetPlayerShockEffectMode();
			this.mDungeonManager.GetGeScene().GetCamera().PlayShockEffect(time, speed, x, y, 2, true);
			yield break;
		}

		// Token: 0x06019043 RID: 102467 RVA: 0x007E16F0 File Offset: 0x007DFAF0
		private IEnumerator _resetCameraShockMode()
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			if (this.mOriginCameraMode != -1)
			{
				this.mDungeonManager.GetGeScene().GetCamera().SetPlayerShockEffectMode(this.mOriginCameraMode);
			}
			yield break;
		}

		// Token: 0x06019044 RID: 102468 RVA: 0x007E170C File Offset: 0x007DFB0C
		private IEnumerator _ShowComicFrame(bool bShow)
		{
			if (bShow)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<ComicFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<ComicFrame>(null, false);
			}
			yield break;
		}

		// Token: 0x06019045 RID: 102469 RVA: 0x007E1728 File Offset: 0x007DFB28
		private IEnumerator _GuideTimeScale(float scale)
		{
			Time.timeScale = scale;
			yield break;
		}

		// Token: 0x06019046 RID: 102470 RVA: 0x007E1744 File Offset: 0x007DFB44
		private IEnumerator _GuideTips(string tips)
		{
			NewbieGuideBattleTipsFrame newbieGuideBattleTipsFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<NewbieGuideBattleTipsFrame>(FrameLayer.Top, null, string.Empty) as NewbieGuideBattleTipsFrame;
			newbieGuideBattleTipsFrame.SetTipsText(tips);
			yield break;
		}

		// Token: 0x06019047 RID: 102471 RVA: 0x007E1760 File Offset: 0x007DFB60
		private IEnumerator _GuideTipsClose()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<NewbieGuideBattleTipsFrame>(null, false);
			yield break;
		}

		// Token: 0x06019048 RID: 102472 RVA: 0x007E1774 File Offset: 0x007DFB74
		private IEnumerator _GuideJumpShow(bool bShow)
		{
			if (this.mInputManager == null)
			{
				yield break;
			}
			if (bShow)
			{
				this.mInputManager.ShowJump();
			}
			else
			{
				this.mInputManager.HiddenJump();
			}
			yield break;
		}

		// Token: 0x06019049 RID: 102473 RVA: 0x007E1798 File Offset: 0x007DFB98
		private IEnumerator SetMonsterSkillsEnable(int id, List<int> skillIDs, bool flag)
		{
			BeActor beActor = this._getEntityByID(id, true);
			if (beActor != null)
			{
				beActor.aiManager.SetSkillsEnable(skillIDs, flag);
			}
			yield break;
		}

		// Token: 0x0601904A RID: 102474 RVA: 0x007E17C8 File Offset: 0x007DFBC8
		private IEnumerator MonsterSkillTalk(string skillSpeech, int id, bool isMonster)
		{
			BeActor beActor = this._getEntityByID(id, isMonster);
			if (beActor != null)
			{
				beActor.m_pkGeActor.ShowHeadDialog(skillSpeech, false, false, false, true, 3.5f, false);
			}
			yield break;
		}

		// Token: 0x0601904B RID: 102475 RVA: 0x007E17F8 File Offset: 0x007DFBF8
		private IEnumerator _Guide2()
		{
			return new ProcessUnit().Append(this._Guide2Begin()).Append(base._waitForTime(0.2f, false)).Append(this.FreazeMonsters(-1, true)).Append(this._mainPlayerMoveForward(4.5f, 1f)).Append(this._GuideEnableInputManager(false)).Append(base._moveCameraTo(1.5f, 0.5f, 1)).Append(this._ShowComicFrame(true)).Append(base._waitForTime(0.5f, false)).Append(base._waitForDialog(14011)).Append(this._ShowComicFrame(false)).Append(base._waitForTime(0.5f, false)).Append(this._GuideMonsterUseSkill(6300021, 7255, true)).Append(base._waitForTime(1.55f, false)).Append(this._GuideLockPlayerMove(true)).Append(this._GuideEnableInputManager(true)).Append(this._GuideVisiableInputManager(true, true)).Append(this._GuideJumpback()).Append(this._GuideJumpShow(true)).Append(this._GuideEnableInputManager(false)).Append(base._waitForTime(0.5f, false)).Append(this.FreazeMonsters(-1, true)).Append(this._GuideLockPlayerMove(true)).Append(base._resetCamera(0.3f)).Append(this._rightShowGuideTip("熟练的使用后跳会让你更飘逸，再教你一些攻击技能去战斗吧！", 1f, true)).Append(this._Guide2AddExSkill()).Append(this._GuideJumpShow(true)).Append(this._GuideLockPlayerMove(false)).Append(this.UnFreazeMonsters(-1, true)).Append(this._GuideEnableInputManager(true)).Append(this._GuideResetMainPlayerState()).Append(base._waitForState(BeSceneState.onClear)).Append(this._ShowGuideTipsEx("继续跑吧，追兵好像越来越近了！", 0f, -1f, 1.5f, false)).Append(base._waitForTime(0.5f, false)).Append(this._GuideLockPlayerMove(false)).Append(this._GuideDoorOpen(TransportDoorType.Right, true)).Append(this._GuideShowNextRoom(0f)).Sequence();
		}

		// Token: 0x0601904C RID: 102476 RVA: 0x007E1A28 File Offset: 0x007DFE28
		private IEnumerator Guide3Begin()
		{
			yield return base._waitForState(BeSceneState.onReady);
			base._DoStateNewbieGuideFunc("Guide3Begin");
			if (this.fingerDoubleMove != null)
			{
				Object.Destroy(this.fingerDoubleMove);
			}
			this.fingerDoubleMove = null;
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.GetBeScene().SetTraceDoor(false);
			if (this.mInputManager != null)
			{
				this.mInputManager.SetVisible(false);
			}
			yield return this.FreazeMonsters(-1, true);
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideNextRoom>(null, false);
			yield return this._HideGuideTips(0f);
			yield break;
		}

		// Token: 0x0601904D RID: 102477 RVA: 0x007E1A44 File Offset: 0x007DFE44
		private IEnumerator _Guide3()
		{
			return new ProcessUnit().Append(this.Guide3Begin()).Append(this._mainPlayerMoveForward(2f, 1f)).Append(this._HideGuideTips(0f)).Append(this._Guide3AddExSkill(0)).Append(this._GuideJumpShow(true)).Append(this._ShowComicFrame(true)).Append(this._GuideEnableInputManager(false)).Append(this._GuideResetMainPlayerState()).Append(this._CamreShock(1.5f, 100f, 0.03f, 0.01f)).Append(base._waitForTime(1f, false)).Append(this._resetCameraShockMode()).Append(base._moveCameraTo(4.5f, 1.5f, 1)).Append(base._moveCameraTo(-2.5f, 0.7f, 1)).Append(this._mainPlayerMoveForward(2f, 1f)).Append(base._waitForDialog(14021)).Append(base._waitForTime(0.5f, false)).Append(this._ShowComicFrame(false)).Append(base._resetCamera(0.5f)).Append(this._GuideVisiableInputManager(true, true)).Append(this._HideGuideTips(0f)).Append(this._Guide3AddExSkill(1)).Append(base._waitForTime(0.2f, false)).Append(this._ShowGuideTipsEx("让敌人尝尝新技能的滋味吧！", 0f, -1f, 1.5f, false)).Append(this._GuideEnableInputManager(true)).Append(this.UnFreazeMonsters(-1, true)).Append(base._waitForTime(0.5f, false)).Append(base._waitForState(BeSceneState.onFinish)).Append(this._CamreShock(1.5f, 100f, 0.03f, 0.01f)).Append(base._waitForTime(1.5f, false)).Append(this._resetCameraShockMode()).Append(this._ShowComicFrame(true)).Append(base._waitForDialog(14031)).Append(this._mainPlayerMoveForward(7f, 1.5f)).Append(this._ShowComicFrame(false)).Append(this._Parallel(0f, delegate
			{
			})).Append(this._Parallel(0f, delegate
			{
			})).Append(base._returnToTown()).Sequence();
		}

		// Token: 0x04011F3B RID: 73531
		private BossController bossShow;

		// Token: 0x04011F3C RID: 73532
		private BeActor boss;

		// Token: 0x04011F3D RID: 73533
		private Vector3 moveInPostion = new Vector3(14.3f, 0f, 6.4f);

		// Token: 0x04011F3E RID: 73534
		private float moveInRadius = 1.5f;

		// Token: 0x04011F3F RID: 73535
		private GameObject temp;

		// Token: 0x04011F40 RID: 73536
		private GameObject fingerDoubleMove;

		// Token: 0x04011F41 RID: 73537
		private const int kAllUnitID = -1;

		// Token: 0x04011F42 RID: 73538
		private int mOriginCameraMode = -1;

		// Token: 0x04011F43 RID: 73539
		private const int guide2_longren = 6320021;

		// Token: 0x04011F44 RID: 73540
		private const int guide2_huonv = 6300021;

		// Token: 0x04011F45 RID: 73541
		private const int guide2_allmonster = -1;

		// Token: 0x04011F46 RID: 73542
		private const int guide2_majia = 6290021;

		// Token: 0x04011F47 RID: 73543
		private const int newbieSkillID = 5528;

		// Token: 0x04011F48 RID: 73544
		private List<int> newbieSkillList = new List<int>
		{
			5528
		};

		// Token: 0x04011F49 RID: 73545
		private int chongjibo_skillid = 9999;
	}
}
