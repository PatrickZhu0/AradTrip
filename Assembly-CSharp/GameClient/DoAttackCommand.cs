using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004525 RID: 17701
	public class DoAttackCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A20 RID: 100896 RVA: 0x007B0B18 File Offset: 0x007AEF18
		public FrameCommandID GetID()
		{
			return FrameCommandID.DoAttack;
		}

		// Token: 0x06018A21 RID: 100897 RVA: 0x007B0B1C File Offset: 0x007AEF1C
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A22 RID: 100898 RVA: 0x007B0B24 File Offset: 0x007AEF24
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
				actorBySeat.TriggerEvent(BeEventType.onSyncDungeonOperation, new object[]
				{
					this.skillID,
					this.bulletCount,
					this.pid
				});
				BeSkill skill = actorBySeat.GetSkill(this.skillID);
				if (skill != null)
				{
					try
					{
						Skill1310 skill2 = skill as Skill1310;
						if (skill2 != null)
						{
							skill2.DoRealAttack(this.bulletCount, this.pid);
						}
					}
					catch (Exception ex)
					{
						Logger.LogErrorFormat("DoAttackCommand skill id:{0} bulletCnt:{1} pid:{2} error:{3}", new object[]
						{
							this.skillID,
							this.bulletCount,
							this.pid,
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

		// Token: 0x06018A23 RID: 100899 RVA: 0x007B0C40 File Offset: 0x007AF040
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 18U,
				data2 = (uint)this.skillID,
				data3 = (uint)(this.pid + 10000 * this.bulletCount)
			};
		}

		// Token: 0x06018A24 RID: 100900 RVA: 0x007B0C84 File Offset: 0x007AF084
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.skillID = (int)data.data2;
			this.pid = (int)(data.data3 % 10000U);
			this.bulletCount = (int)((data.data3 - (uint)this.pid) / 10000U);
		}

		// Token: 0x06018A25 RID: 100901 RVA: 0x007B0CD8 File Offset: 0x007AF0D8
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} doattack skillid:{2} pid:{3} bullet:{4}", new object[]
			{
				this.frame,
				this.seat,
				this.skillID,
				this.pid,
				this.bulletCount
			});
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A26 RID: 100902 RVA: 0x007B0D5C File Offset: 0x007AF15C
		public void Reset()
		{
			base.BaseReset();
			this.skillID = 0;
			this.pid = 0;
		}

		// Token: 0x04011C20 RID: 72736
		public int skillID;

		// Token: 0x04011C21 RID: 72737
		public int bulletCount;

		// Token: 0x04011C22 RID: 72738
		public int pid;
	}
}
