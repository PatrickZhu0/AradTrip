using System;
using System.Text;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200451E RID: 17694
	public class UseItemFrameCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189E8 RID: 100840 RVA: 0x007AFB3D File Offset: 0x007ADF3D
		public FrameCommandID GetID()
		{
			return FrameCommandID.UseItem;
		}

		// Token: 0x060189E9 RID: 100841 RVA: 0x007AFB40 File Offset: 0x007ADF40
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189EA RID: 100842 RVA: 0x007AFB48 File Offset: 0x007ADF48
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 8U,
				data2 = this.itemID,
				data3 = this.itemNum,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189EB RID: 100843 RVA: 0x007AFB89 File Offset: 0x007ADF89
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.itemID = data.data2;
			this.itemNum = data.data3;
		}

		// Token: 0x060189EC RID: 100844 RVA: 0x007AFBB4 File Offset: 0x007ADFB4
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} item type :{2}, item num {3}", new object[]
			{
				this.frame,
				this.seat,
				this.itemID,
				this.itemNum
			});
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189ED RID: 100845 RVA: 0x007AFC2C File Offset: 0x007AE02C
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat == null || actorBySeat.IsDead())
			{
				return;
			}
			if (actorBySeat != null && actorBySeat.IsProcessRecord())
			{
				base.Record(actorBySeat, this.GetString());
			}
			if (actorBySeat.buffController != null)
			{
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>((int)this.itemID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.OnUseBuffId > 0)
				{
					BuffTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<BuffTable>(tableItem.OnUseBuffId, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						int num = GlobalLogic.VALUE_1000;
						if (tableItem2.ValueA.Count > 0)
						{
							num = TableManager.GetValueFromUnionCell(tableItem2.ValueA[0], 0, true);
						}
						if (num == 0)
						{
							num = GlobalLogic.VALUE_1000;
						}
						BeBuff beBuff = actorBySeat.buffController.TryAddBuff(tableItem2.ID, num, 1);
						if (beBuff != null)
						{
							beBuff.passive = true;
						}
						if (actorBySeat.m_pkGeActor != null && Utility.IsStringValid(tableItem2.BirthEffectLocate))
						{
							DAssetObject effectRes;
							effectRes.m_AssetObj = null;
							effectRes.m_AssetPath = tableItem2.BirthEffect;
							EffectsFrames effectsFrames = new EffectsFrames();
							effectsFrames.localPosition = new Vector3(0f, 0f, 0f);
							effectsFrames.timetype = EffectTimeType.BUFF;
							if (Utility.IsStringValid(tableItem2.BirthEffectLocate))
							{
								effectsFrames.attachname = tableItem2.BirthEffectLocate;
							}
							actorBySeat.m_pkGeActor.CreateEffect(effectRes, effectsFrames, 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, false);
						}
					}
				}
			}
		}

		// Token: 0x060189EE RID: 100846 RVA: 0x007AFDD7 File Offset: 0x007AE1D7
		public void Reset()
		{
			base.BaseReset();
			this.itemID = 0U;
			this.itemNum = 0U;
		}

		// Token: 0x04011C10 RID: 72720
		public uint itemID;

		// Token: 0x04011C11 RID: 72721
		public uint itemNum;
	}
}
