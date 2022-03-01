using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004523 RID: 17699
	public class DoublePressConfigCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A10 RID: 100880 RVA: 0x007B0542 File Offset: 0x007AE942
		public FrameCommandID GetID()
		{
			return FrameCommandID.DoublePressConfig;
		}

		// Token: 0x06018A11 RID: 100881 RVA: 0x007B0546 File Offset: 0x007AE946
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A12 RID: 100882 RVA: 0x007B0550 File Offset: 0x007AE950
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat != null && !actorBySeat.IsDead())
			{
				if (actorBySeat.IsProcessRecord())
				{
					base.Record(actorBySeat, this.GetString());
				}
				BeActor[] array = new BeActor[]
				{
					actorBySeat
				};
				actorBySeat.TriggerEvent(BeEventType.RaidBattleChangeMonster, new object[]
				{
					array
				});
				BeActor beActor = array[0];
				if (beActor != null)
				{
					beActor.recieveConfigCmd = true;
					beActor.hasDoublePress = this.hasDoublePress;
					beActor.hasRunAttackConfig = this.hasRunAttackConfig;
					beActor.attackReplaceLigui = this.attackReplaceLigui;
					beActor.canUseCrystalSkill = this.canUseCrystalSkill;
					beActor.paladinAttackCharge = this.paladinAttackCharge;
					beActor.backHitConfig = this.backHitConfig;
					beActor.autoHitConfig = this.autoHitConfig;
					beActor.chaserSwitch = this.chaserSwitch;
					beActor.XuanWuManualAttack = this.xuanWuManualAttack;
					beActor.floatShotSwitch = this.floatShotSwitch;
					beActor.headShotSwitch = this.headShotSwitch;
					beActor.TriggerEvent(BeEventType.ConfigCommand, null);
				}
			}
		}

		// Token: 0x06018A13 RID: 100883 RVA: 0x007B0654 File Offset: 0x007AEA54
		public _inputData GetInputData()
		{
			_inputData inputData = new _inputData();
			inputData.data1 = 11U;
			inputData.data2 |= ((!this.hasDoublePress) ? 0U : 1U) << 1;
			inputData.data2 |= ((!this.attackReplaceLigui) ? 0U : 1U) << 2;
			inputData.data2 |= ((!this.canUseCrystalSkill) ? 0U : 1U) << 3;
			inputData.data2 |= ((!this.paladinAttackCharge) ? 0U : 1U) << 4;
			inputData.data2 |= ((!this.backHitConfig) ? 0U : 1U) << 5;
			inputData.data2 |= ((!this.autoHitConfig) ? 0U : 1U) << 6;
			inputData.data2 |= ((!this.xuanWuManualAttack) ? 0U : 1U) << 7;
			inputData.data2 |= ((!this.floatShotSwitch) ? 0U : 1U) << 8;
			inputData.data2 |= ((!this.headShotSwitch) ? 0U : 1U) << 9;
			inputData.data3 |= ((!this.hasRunAttackConfig) ? 0U : 1U);
			inputData.data3 |= (uint)((uint)this.chaserSwitch << 1);
			inputData.sendTime = this.sendTime;
			return inputData;
		}

		// Token: 0x06018A14 RID: 100884 RVA: 0x007B07DC File Offset: 0x007AEBDC
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.hasDoublePress = ((data.data2 & 2U) != 0U);
			this.attackReplaceLigui = ((data.data2 & 4U) != 0U);
			this.canUseCrystalSkill = ((data.data2 & 8U) != 0U);
			this.paladinAttackCharge = ((data.data2 & 16U) != 0U);
			this.backHitConfig = ((data.data2 & 32U) != 0U);
			this.autoHitConfig = ((data.data2 & 64U) != 0U);
			this.xuanWuManualAttack = ((data.data2 & 128U) != 0U);
			this.floatShotSwitch = ((data.data2 & 256U) != 0U);
			this.headShotSwitch = ((data.data2 & 512U) != 0U);
			this.hasRunAttackConfig = ((data.data3 & 1U) != 0U);
			this.chaserSwitch = (byte)((data.data3 & 62U) >> 1);
		}

		// Token: 0x06018A15 RID: 100885 RVA: 0x007B091C File Offset: 0x007AED1C
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} hasDoublePress:{2} hasRunAttackConfig:{3} autoUseCrystalSkill: {4}", new object[]
			{
				this.frame,
				this.seat,
				this.hasDoublePress,
				this.hasRunAttackConfig,
				this.canUseCrystalSkill
			});
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A16 RID: 100886 RVA: 0x007B09A0 File Offset: 0x007AEDA0
		public void Reset()
		{
			base.BaseReset();
			this.hasDoublePress = false;
			this.hasRunAttackConfig = false;
			this.attackReplaceLigui = false;
			this.xuanWuManualAttack = false;
		}

		// Token: 0x04011C14 RID: 72724
		public bool hasDoublePress;

		// Token: 0x04011C15 RID: 72725
		public bool hasRunAttackConfig;

		// Token: 0x04011C16 RID: 72726
		public bool attackReplaceLigui;

		// Token: 0x04011C17 RID: 72727
		public bool canUseCrystalSkill;

		// Token: 0x04011C18 RID: 72728
		public bool paladinAttackCharge;

		// Token: 0x04011C19 RID: 72729
		public bool backHitConfig;

		// Token: 0x04011C1A RID: 72730
		public bool autoHitConfig;

		// Token: 0x04011C1B RID: 72731
		public byte chaserSwitch;

		// Token: 0x04011C1C RID: 72732
		public bool xuanWuManualAttack;

		// Token: 0x04011C1D RID: 72733
		public bool floatShotSwitch;

		// Token: 0x04011C1E RID: 72734
		public bool headShotSwitch;
	}
}
