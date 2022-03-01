using System;
using System.Collections.Generic;

// Token: 0x02004353 RID: 17235
public class Mechanism2029 : BeMechanism
{
	// Token: 0x06017DB6 RID: 97718 RVA: 0x0075FB83 File Offset: 0x0075DF83
	public Mechanism2029(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DB7 RID: 97719 RVA: 0x0075FBBC File Offset: 0x0075DFBC
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.buffIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.buffTimeAddRateList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
		for (int k = 0; k < this.data.ValueC.Count; k++)
		{
			this.buffTimeAddValueList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true));
		}
	}

	// Token: 0x06017DB8 RID: 97720 RVA: 0x0075FCB9 File Offset: 0x0075E0B9
	public override void OnStart()
	{
		base.OnStart();
		this.delayCaller.DelayCall(66, delegate
		{
			this.RegisterBuffAdd();
		}, 0, 0, false);
	}

	// Token: 0x06017DB9 RID: 97721 RVA: 0x0075FCE0 File Offset: 0x0075E0E0
	private void RegisterBuffAdd()
	{
		List<BeActor> list = new List<BeActor>();
		BeUtility.GetAllFriendPlayers(base.owner, list);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				BeEventHandle item = beActor.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
				{
					BeBuff buff = (BeBuff)args[0];
					if (buff != null && base.owner != null && buff.releaser == base.owner)
					{
						int num = this.buffIdList.FindIndex((int x) => x == buff.buffID);
						if (num != -1)
						{
							if (num < this.buffTimeAddRateList.Count)
							{
								BeBuff buff3 = buff;
								buff3.duration *= VFactor.one + VFactor.NewVFactor(this.buffTimeAddRateList[num], GlobalLogic.VALUE_1000);
							}
							if (num < this.buffTimeAddValueList.Count)
							{
								BeBuff buff2 = buff;
								buff2.duration += this.buffTimeAddValueList[num];
							}
						}
					}
				});
				this.handleList.Add(item);
			}
		}
	}

	// Token: 0x06017DBA RID: 97722 RVA: 0x0075FD48 File Offset: 0x0075E148
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x040112AF RID: 70319
	private List<int> buffIdList = new List<int>();

	// Token: 0x040112B0 RID: 70320
	private List<int> buffTimeAddRateList = new List<int>();

	// Token: 0x040112B1 RID: 70321
	private List<int> buffTimeAddValueList = new List<int>();

	// Token: 0x040112B2 RID: 70322
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
