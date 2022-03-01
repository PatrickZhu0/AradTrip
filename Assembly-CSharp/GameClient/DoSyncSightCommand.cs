using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004526 RID: 17702
	public class DoSyncSightCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A28 RID: 100904 RVA: 0x007B0D7A File Offset: 0x007AF17A
		public FrameCommandID GetID()
		{
			return FrameCommandID.SyncSight;
		}

		// Token: 0x06018A29 RID: 100905 RVA: 0x007B0D7E File Offset: 0x007AF17E
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A2A RID: 100906 RVA: 0x007B0D88 File Offset: 0x007AF188
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat != null)
			{
				actorBySeat.TriggerEventNew(BeEventType.onSyncSightCommand, new EventParam
				{
					m_Int = this.skillID,
					m_Int2 = this.x,
					m_Int3 = this.z
				});
				BeSkill skill = actorBySeat.GetSkill(this.skillID);
				if (skill != null)
				{
					try
					{
						Skill1310 skill2 = skill as Skill1310;
						if (skill2 != null)
						{
							skill2.DoSyncSight(this.x, this.z);
						}
					}
					catch (Exception ex)
					{
						Logger.LogErrorFormat("DoSyncSightCommand skill id:{0} X:{1} Z:{2} error:{3}", new object[]
						{
							this.skillID,
							this.x,
							this.z,
							ex.ToString()
						});
					}
				}
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A2B RID: 100907 RVA: 0x007B0EA8 File Offset: 0x007AF2A8
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 22U,
				data2 = (uint)this.skillID,
				data3 = (uint)(this.x + 100000 * this.z)
			};
		}

		// Token: 0x06018A2C RID: 100908 RVA: 0x007B0EEC File Offset: 0x007AF2EC
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.skillID = (int)data.data2;
			this.x = (int)(data.data3 % 100000U);
			this.z = (int)((data.data3 - (uint)this.x) / 100000U);
		}

		// Token: 0x06018A2D RID: 100909 RVA: 0x007B0F40 File Offset: 0x007AF340
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} DoSyncSightCommand skillid:{2} x:{3} z:{4}", new object[]
			{
				this.frame,
				this.seat,
				this.skillID,
				this.x,
				this.z
			});
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A2E RID: 100910 RVA: 0x007B0FC4 File Offset: 0x007AF3C4
		public void Reset()
		{
			base.BaseReset();
			this.skillID = 0;
			this.x = 0;
			this.z = 0;
		}

		// Token: 0x04011C23 RID: 72739
		public int skillID;

		// Token: 0x04011C24 RID: 72740
		public int x;

		// Token: 0x04011C25 RID: 72741
		public int z;
	}
}
