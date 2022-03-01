using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004431 RID: 17457
public class Skill1015 : BeSkill
{
	// Token: 0x060183D3 RID: 99283 RVA: 0x0078BF90 File Offset: 0x0078A390
	public Skill1015(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183D4 RID: 99284 RVA: 0x0078BFC8 File Offset: 0x0078A3C8
	public override void OnInit()
	{
		this.newBullets.Clear();
		if (this.skillData != null)
		{
			this.mBulletsPve = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
			this.mBulletsPvp = ((this.skillData.ValueA.Count <= 1) ? TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true));
			for (int i = 0; i < this.skillData.ValueC.Count; i += 2)
			{
				Skill1015.NewBullet item;
				item.weaponType = TableManager.GetValueFromUnionCell(this.skillData.ValueC[i], base.level, true);
				item.bulletID = TableManager.GetValueFromUnionCell(this.skillData.ValueC[i + 1], base.level, true);
				this.newBullets.Add(item);
			}
			for (int j = 0; j < this.skillData.ValueD.Count; j++)
			{
				this.effectTableID[j] = TableManager.GetValueFromUnionCell(this.skillData.ValueD[j], base.level, true);
			}
			this.mRemoveBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
		}
	}

	// Token: 0x060183D5 RID: 99285 RVA: 0x0078C149 File Offset: 0x0078A549
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.UpdateBulletInfo();
	}

	// Token: 0x060183D6 RID: 99286 RVA: 0x0078C158 File Offset: 0x0078A558
	private void SetBulletNum()
	{
		this.bulletsCount = 0;
		this.bullets = ((!BattleMain.IsModePvP(base.battleType)) ? this.mBulletsPve : this.mBulletsPvp);
		SpecialBulletType specialBulletType = SpecialBulletType.SILVER;
		int skillID = this.skillID;
		if (skillID != 1302)
		{
			if (skillID != 1303)
			{
				if (skillID == 1308)
				{
					specialBulletType = SpecialBulletType.FIRE;
				}
			}
			else
			{
				specialBulletType = SpecialBulletType.ICE;
			}
		}
		else
		{
			specialBulletType = SpecialBulletType.STRESILVER;
		}
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism126 mechanism = base.owner.MechanismList[i] as Mechanism126;
			if (mechanism != null && specialBulletType == (SpecialBulletType)mechanism.bulletType)
			{
				this.bullets += mechanism.bulletNum;
			}
		}
	}

	// Token: 0x060183D7 RID: 99287 RVA: 0x0078C23C File Offset: 0x0078A63C
	public override void OnStart()
	{
		this.SetBulletNum();
		this.RemoveHandle();
		this.curFrameHandle = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (a == this.addBuffFlag)
			{
				this.UpdateBulletInfo();
			}
		});
		this.removeBuffHandle = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.mRemoveBuffId)
			{
				this.bulletsCount = this.bullets;
				this.DoClear();
			}
		});
		this.handler = base.owner.RegisterEvent(BeEventType.onBeforeGenBullet, delegate(object[] args)
		{
			if (base.owner.IsCastingSkill() && this.IsSkillTakeEffect(base.owner.m_iCurSkillID))
			{
				int[] array = (int[])args[0];
				array[1] = ((!BattleMain.IsModePvP(base.battleType)) ? this.effectTableID[0] : this.effectTableID[1]);
				int weaponType = base.owner.GetWeaponType();
				for (int i = 0; i < this.newBullets.Count; i++)
				{
					if (weaponType == this.newBullets[i].weaponType)
					{
						array[0] = this.newBullets[i].bulletID;
					}
				}
				this.ConsumBulletCount();
			}
		});
	}

	// Token: 0x060183D8 RID: 99288 RVA: 0x0078C2B2 File Offset: 0x0078A6B2
	public override void OnCancel()
	{
		base.OnCancel();
		if (this.bulletsCount < this.bullets)
		{
			this.bulletsCount = this.bullets;
			this.DoClear();
		}
	}

	// Token: 0x060183D9 RID: 99289 RVA: 0x0078C2E7 File Offset: 0x0078A6E7
	private void DoClear()
	{
		this.RemoveHandle();
		this.UpdateBulletInfo();
	}

	// Token: 0x060183DA RID: 99290 RVA: 0x0078C2F8 File Offset: 0x0078A6F8
	private bool IsSkillTakeEffect(int skillID)
	{
		if (this.skillData != null)
		{
			for (int i = 0; i < this.skillData.ValueB.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
				if (valueFromUnionCell == skillID)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060183DB RID: 99291 RVA: 0x0078C35C File Offset: 0x0078A75C
	private void UpdateBulletInfo()
	{
		if (this.bullets - this.bulletsCount <= 0)
		{
			this.RemoveBuff();
		}
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				SpecialBulletType type = SpecialBulletType.SILVER;
				int skillID = this.skillID;
				if (skillID != 1302)
				{
					if (skillID != 1303)
					{
						if (skillID == 1308)
						{
							type = SpecialBulletType.FIRE;
						}
					}
					else
					{
						type = SpecialBulletType.ICE;
					}
				}
				else
				{
					type = SpecialBulletType.STRESILVER;
				}
				clientSystemBattle.SetSilverBulletNum(this.skillID, this.bullets - this.bulletsCount, type);
			}
		}
	}

	// Token: 0x060183DC RID: 99292 RVA: 0x0078C41C File Offset: 0x0078A81C
	protected void RemoveHandle()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
		if (this.removeBuffHandle != null)
		{
			this.removeBuffHandle.Remove();
			this.removeBuffHandle = null;
		}
		if (this.curFrameHandle != null)
		{
			this.curFrameHandle.Remove();
			this.curFrameHandle = null;
		}
	}

	// Token: 0x060183DD RID: 99293 RVA: 0x0078C480 File Offset: 0x0078A880
	protected void RemoveBuff()
	{
		if (this.mRemoveBuffId != 0)
		{
			base.owner.buffController.RemoveBuff(this.mRemoveBuffId, 0, 0);
		}
	}

	// Token: 0x060183DE RID: 99294 RVA: 0x0078C4A8 File Offset: 0x0078A8A8
	public int GetLeftBulletNum()
	{
		int num = this.bullets - this.bulletsCount;
		if (num > 0)
		{
			return num;
		}
		return 0;
	}

	// Token: 0x060183DF RID: 99295 RVA: 0x0078C4D2 File Offset: 0x0078A8D2
	public void ConsumBulletCount()
	{
		this.bulletsCount++;
		this.UpdateBulletInfo();
		if (this.bulletsCount >= this.bullets)
		{
			this.DoClear();
		}
	}

	// Token: 0x040117E7 RID: 71655
	private CrypticInt32 bulletsCount = 0;

	// Token: 0x040117E8 RID: 71656
	private int[] effectTableID = new int[2];

	// Token: 0x040117E9 RID: 71657
	private int bullets;

	// Token: 0x040117EA RID: 71658
	private int mBulletsPve;

	// Token: 0x040117EB RID: 71659
	private int mBulletsPvp;

	// Token: 0x040117EC RID: 71660
	protected string addBuffFlag = "101501";

	// Token: 0x040117ED RID: 71661
	private int mRemoveBuffId;

	// Token: 0x040117EE RID: 71662
	private BeEventHandle handler;

	// Token: 0x040117EF RID: 71663
	private List<Skill1015.NewBullet> newBullets = new List<Skill1015.NewBullet>();

	// Token: 0x040117F0 RID: 71664
	private BeEventHandle removeBuffHandle;

	// Token: 0x040117F1 RID: 71665
	private BeEventHandle curFrameHandle;

	// Token: 0x02004432 RID: 17458
	public struct NewBullet
	{
		// Token: 0x040117F2 RID: 71666
		public int weaponType;

		// Token: 0x040117F3 RID: 71667
		public int bulletID;
	}
}
