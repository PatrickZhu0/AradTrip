using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x02004442 RID: 17474
public class Skill3713 : Skill1512
{
	// Token: 0x06018437 RID: 99383 RVA: 0x0078E5D0 File Offset: 0x0078C9D0
	public Skill3713(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018438 RID: 99384 RVA: 0x0078E62C File Offset: 0x0078CA2C
	public override void OnInit()
	{
		base.OnInit();
		this.pveDizzBuffInfoIdList.Clear();
		this.pvpDizzBuffInfoIdList.Clear();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("3713") == InputManager.SlideSetting.SLIDE);
		this.entityIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.entityIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true);
		for (int i = 0; i < this.skillData.ValueB.Count; i++)
		{
			this.pveDizzBuffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true));
		}
		for (int j = 0; j < this.skillData.ValueC.Count; j++)
		{
			this.pvpDizzBuffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueC[j], base.level, true));
		}
		this.dizzRadiueArr[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true), GlobalLogic.VALUE_1000);
		this.dizzRadiueArr[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueD[1], base.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018439 RID: 99385 RVA: 0x0078E7BC File Offset: 0x0078CBBC
	public override void OnStart()
	{
		base.OnStart();
		this.RemoveHandleList();
		this.curEntityId = ((!BattleMain.IsModePvP(base.battleType)) ? this.entityIdArr[0] : this.entityIdArr[1]);
		this.curDizzRadius = ((!BattleMain.IsModePvP(base.battleType)) ? this.dizzRadiueArr[0] : this.dizzRadiueArr[1]);
		this.AddListenerEntity();
	}

	// Token: 0x0601843A RID: 99386 RVA: 0x0078E844 File Offset: 0x0078CC44
	private void RemoveHandleList()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
	}

	// Token: 0x0601843B RID: 99387 RVA: 0x0078E89C File Offset: 0x0078CC9C
	private void AddListenerEntity()
	{
		if (base.owner == null)
		{
			return;
		}
		BeEventHandle item = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile entity = args[0] as BeProjectile;
			if (entity != null && entity.m_iResID == this.curEntityId)
			{
				BeEventHandle item2 = entity.RegisterEvent(BeEventType.onDead, delegate(object[] args1)
				{
					List<BeActor> list = ListPool<BeActor>.Get();
					if (this.owner != null && this.owner.CurrentBeScene != null)
					{
						this.owner.CurrentBeScene.FindTargetsByEntity(list, entity, this.curDizzRadius, false, null);
						for (int i = 0; i < list.Count; i++)
						{
							bool face = entity.GetFace();
							int num = entity.GetPosition().x - list[i].GetPosition().x;
							if (face != list[i].GetFace() && ((num > 0 && face) || (!face && num < 0)))
							{
								List<int> list2 = (!BattleMain.IsModePvP(this.battleType)) ? this.pveDizzBuffInfoIdList : this.pvpDizzBuffInfoIdList;
								for (int j = 0; j < list2.Count; j++)
								{
									BuffInfoData info = new BuffInfoData(list2[j], this.level, 0);
									list[i].buffController.TryAddBuff(info, null, false, default(VRate), this.owner);
								}
							}
						}
					}
					ListPool<BeActor>.Release(list);
				});
				this.handleList.Add(item2);
			}
		});
		this.handleList.Add(item);
	}

	// Token: 0x04011824 RID: 71716
	private int[] entityIdArr = new int[2];

	// Token: 0x04011825 RID: 71717
	private List<int> pveDizzBuffInfoIdList = new List<int>();

	// Token: 0x04011826 RID: 71718
	private List<int> pvpDizzBuffInfoIdList = new List<int>();

	// Token: 0x04011827 RID: 71719
	private VInt[] dizzRadiueArr = new VInt[2];

	// Token: 0x04011828 RID: 71720
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x04011829 RID: 71721
	private VInt curDizzRadius = 0;

	// Token: 0x0401182A RID: 71722
	private int curEntityId;
}
