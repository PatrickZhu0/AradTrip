using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200451D RID: 17693
	public class SkillFrameCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189E0 RID: 100832 RVA: 0x007AF3C2 File Offset: 0x007AD7C2
		public FrameCommandID GetID()
		{
			return FrameCommandID.Skill;
		}

		// Token: 0x060189E1 RID: 100833 RVA: 0x007AF3C5 File Offset: 0x007AD7C5
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189E2 RID: 100834 RVA: 0x007AF3D0 File Offset: 0x007AD7D0
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 3U,
				data2 = this.skillSolt,
				data3 = this.skillSlotUp,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189E3 RID: 100835 RVA: 0x007AF411 File Offset: 0x007AD811
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.skillSolt = data.data2;
			this.skillSlotUp = data.data3;
		}

		// Token: 0x060189E4 RID: 100836 RVA: 0x007AF43C File Offset: 0x007AD83C
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} Skill Slot:{2}", this.frame, this.seat, this.skillSolt);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189E5 RID: 100837 RVA: 0x007AF498 File Offset: 0x007AD898
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (this.battle == null || actorBySeat == null || actorBySeat.IsDead())
			{
				return;
			}
			BeDungeon beDungeon = this.battle.dungeonManager as BeDungeon;
			if (beDungeon != null && beDungeon.IsInFade)
			{
				if (actorBySeat.IsProcessRecord())
				{
					actorBySeat.GetRecordServer().Mark(311952006U, new int[]
					{
						actorBySeat.m_iID,
						(int)this.frame,
						(int)this.seat,
						(int)this.skillSolt
					}, new string[]
					{
						actorBySeat.GetName()
					});
				}
				return;
			}
			if (!actorBySeat.stateController.HasAbility(BeAbilityType.CAN_DO_SKILL_CMD))
			{
				return;
			}
			if (actorBySeat.isMainActor)
			{
				actorBySeat.RecordPressCount();
			}
			if (actorBySeat != null && actorBySeat.IsProcessRecord())
			{
				base.Record(actorBySeat, this.GetString());
			}
			if (this.skillSolt == 2147483647U)
			{
				if (actorBySeat.CanJump())
				{
					BeStateData rkStateData = new BeStateData(5, 0);
					actorBySeat.Locomote(rkStateData, false);
				}
			}
			else if (this.skillSolt == 2147483646U)
			{
				if (this.skillSlotUp != 0U)
				{
					return;
				}
				if (actorBySeat.CanJumpBack())
				{
					actorBySeat.TriggerEventNew(BeEventType.onUseJumpBackSkill, default(EventParam));
					BeStateData rkStateData2 = new BeStateData(6, 0);
					actorBySeat.Locomote(rkStateData2, false);
				}
				else if (actorBySeat.IsCastingSkill())
				{
					BeSkill currentSkill = actorBySeat.GetCurrentSkill();
					if (currentSkill != null && !currentSkill.IsCanceled() && currentSkill.canPressJumpBackCancel)
					{
						actorBySeat.Locomote(new BeStateData(0, 0), false);
					}
				}
			}
			else if (this.skillSolt == 2147483645U)
			{
				if (this.skillSlotUp == 1U)
				{
					actorBySeat.SetAttackButtonState(ButtonState.RELEASE, false);
					if (actorBySeat.sgGetCurrentState() == 14)
					{
						BeSkill currentSkill2 = actorBySeat.GetCurrentSkill();
						if (currentSkill2 != null && currentSkill2.charge)
						{
							currentSkill2.SetButtonRelease();
							actorBySeat.GetStateGraph().FireEvents2CurrentStates(5);
						}
					}
				}
				else
				{
					actorBySeat.SetAttackButtonState(ButtonState.PRESS, true);
				}
			}
			else
			{
				int num = (int)this.skillSolt;
				actorBySeat.TriggerEventNew(BeEventType.onSkillPressButtonCombo, new EventParam
				{
					m_Int = num,
					m_Int2 = (int)this.skillSlotUp
				});
				if (num == 10000)
				{
					actorBySeat.UseHelpSkill();
					return;
				}
				if (num > 0)
				{
					if (this.skillSlotUp == 1U)
					{
						if (actorBySeat.sgGetCurrentState() == 14)
						{
							BeSkill skill = actorBySeat.GetSkill(num);
							if (skill != null)
							{
								skill.SetButtonRelease();
							}
							actorBySeat.TriggerEvent(BeEventType.OnReleaseButtonTrigger, null);
							actorBySeat.GetStateGraph().FireEvents2CurrentStates(5);
						}
					}
					else if (this.skillSlotUp >= 100000000U)
					{
						BeSkill skill2 = actorBySeat.GetSkill(num);
						if (skill2 != null)
						{
							uint degree = this.skillSlotUp - 100000000U;
							skill2.UpdateJoystick((int)degree);
						}
					}
					else if ((ulong)this.skillSlotUp >= (ulong)((long)GlobalLogic.VALUE_1000))
					{
						BeSkill skill3 = actorBySeat.GetSkill(num);
						if (skill3 != null)
						{
							string text = this.skillSlotUp.ToString();
							int num2 = int.Parse(text.Substring(text.Length - 4, 4));
							int num3 = (int)(((ulong)this.skillSlotUp - (ulong)((long)num2)) / (ulong)((long)GlobalLogic.VALUE_10000));
							num3 -= GlobalLogic.VALUE_1000;
							num2 -= GlobalLogic.VALUE_1000;
							skill3.UpdateJoystick(num3, num2);
						}
					}
					else if (this.skillSlotUp == 100U)
					{
						BeSkill skill4 = actorBySeat.GetSkill(num);
						if (skill4 != null)
						{
							skill4.ReleaseJoystick();
						}
					}
					else if (this.skillSlotUp > 1U && this.skillSlotUp < 5U)
					{
						BeSkill skill5 = actorBySeat.GetSkill(num);
						if (skill5 != null)
						{
							skill5.specialChoice = (int)(this.skillSlotUp - 2U);
						}
						actorBySeat.UseSkill(num, false);
					}
					else if (this.skillSlotUp >= 10U && this.skillSlotUp < 12U)
					{
						BeSkill skill6 = actorBySeat.GetSkill(num);
						if (skill6 != null)
						{
							skill6.specialChoice = (int)(this.skillSlotUp - 10U);
						}
						actorBySeat.UseSkill(num, false);
					}
					else if (this.skillSlotUp >= 5U && this.skillSlotUp < 8U)
					{
						BeSkill skill7 = actorBySeat.GetSkill(num);
						if (skill7 != null)
						{
							byte seatData = (byte)(this.skillSlotUp - 5U);
							BeActor actorBySeat2 = base.GetActorBySeat(seatData);
							if (actorBySeat2 != null)
							{
								skill7.joystickSelectActor = actorBySeat2;
							}
						}
						actorBySeat.UseSkill(num, false);
					}
					else
					{
						BeSkill skill8 = actorBySeat.GetSkill(num);
						if (skill8 != null && skill8.skillButtonState == BeSkill.SkillState.WAIT_FOR_NEXT_PRESS)
						{
							if (skill8.pressMode == SkillPressMode.TWO_PRESS)
							{
								skill8.PressAgain();
							}
							else if (skill8.pressMode == SkillPressMode.PRESS_MANY_TWO)
							{
								skill8.PressMany();
								return;
							}
						}
						if (skill8 != null && skill8.skillButtonState == BeSkill.SkillState.WAIT_FOR_NEXT_PRESS && (skill8.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL_OUT || skill8.pressMode == SkillPressMode.TWO_PRESS_OUT || skill8.pressMode == SkillPressMode.PRESS_MANY || skill8.pressMode == SkillPressMode.PRESS_JOYSTICK))
						{
							if (actorBySeat.IsInPassiveState())
							{
								return;
							}
							if (skill8.pressMode == SkillPressMode.PRESS_AGAIN_CANCEL_OUT)
							{
								skill8.PressAgainCancel();
							}
							else if (skill8.pressMode == SkillPressMode.TWO_PRESS_OUT)
							{
								skill8.PressAgainRelease();
							}
							else if (skill8.pressMode == SkillPressMode.PRESS_MANY)
							{
								skill8.PressMany();
							}
							else if (skill8.pressMode == SkillPressMode.PRESS_JOYSTICK)
							{
								skill8.PressJoystick();
							}
							return;
						}
						else
						{
							bool flag = false;
							if (actorBySeat.sgGetCurrentState() == 14)
							{
								BeSkill skill9 = actorBySeat.GetSkill(num);
								BeSkill currentSkill3 = actorBySeat.GetCurrentSkill();
								bool flag2 = false;
								if (currentSkill3 != null)
								{
									flag2 = actorBySeat.TriggerEventNew(BeEventType.onChangeAttackCanTriggerSkill, new EventParam
									{
										m_Int = currentSkill3.skillID,
										m_Bool = flag2
									}).m_Bool;
								}
								if (skill9 != null && skill9.buttonState == ButtonState.RELEASE && currentSkill3 != null && (currentSkill3.skillData.IsAttackCombo != 1 || flag2) && actorBySeat.TriggerComboSkills(num))
								{
									return;
								}
								if (skill9 != null && actorBySeat.GetCurSkillID() == num && skill9.buttonState == ButtonState.RELEASE)
								{
									skill9.SetButtonPressAgain();
									actorBySeat.GetStateGraph().FireEvents2CurrentStates(8);
									flag = true;
								}
							}
							if (!flag)
							{
								actorBySeat.UseSkill(num, false);
							}
						}
					}
				}
			}
		}

		// Token: 0x060189E6 RID: 100838 RVA: 0x007AFB1F File Offset: 0x007ADF1F
		public void Reset()
		{
			base.BaseReset();
			this.skillSolt = 0U;
			this.skillSlotUp = 0U;
		}

		// Token: 0x04011C0E RID: 72718
		public uint skillSolt;

		// Token: 0x04011C0F RID: 72719
		public uint skillSlotUp;
	}
}
