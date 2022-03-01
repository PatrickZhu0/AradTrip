using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004528 RID: 17704
	public class ChangeWeaponCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A38 RID: 100920 RVA: 0x007B1140 File Offset: 0x007AF540
		public FrameCommandID GetID()
		{
			return FrameCommandID.ChangeWeapon;
		}

		// Token: 0x06018A39 RID: 100921 RVA: 0x007B1144 File Offset: 0x007AF544
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A3A RID: 100922 RVA: 0x007B114C File Offset: 0x007AF54C
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat != null && !actorBySeat.IsDead())
			{
				if (this.equipIndex > 0)
				{
					actorBySeat.ChangeEquip(this.equipIndex - 1);
				}
				else
				{
					actorBySeat.ChangeWeapon(this.weaponIndex, 0);
				}
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A3B RID: 100923 RVA: 0x007B11D0 File Offset: 0x007AF5D0
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 21U,
				data2 = (uint)this.weaponIndex,
				data3 = (uint)this.equipIndex,
				sendTime = this.sendTime
			};
		}

		// Token: 0x06018A3C RID: 100924 RVA: 0x007B1212 File Offset: 0x007AF612
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.weaponIndex = (int)data.data2;
			this.equipIndex = (int)data.data3;
		}

		// Token: 0x06018A3D RID: 100925 RVA: 0x007B123C File Offset: 0x007AF63C
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} weapon index:{2} equipIndex:{3}", new object[]
			{
				this.frame,
				this.seat,
				this.weaponIndex,
				this.equipIndex
			});
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A3E RID: 100926 RVA: 0x007B12B2 File Offset: 0x007AF6B2
		public void Reset()
		{
			base.BaseReset();
			this.weaponIndex = 0;
			this.equipIndex = 0;
		}

		// Token: 0x04011C27 RID: 72743
		public int weaponIndex;

		// Token: 0x04011C28 RID: 72744
		public int equipIndex;
	}
}
