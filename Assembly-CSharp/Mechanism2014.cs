using System;
using System.Collections.Generic;

// Token: 0x02004344 RID: 17220
public class Mechanism2014 : BeMechanism
{
	// Token: 0x06017D61 RID: 97633 RVA: 0x0075D999 File Offset: 0x0075BD99
	public Mechanism2014(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D62 RID: 97634 RVA: 0x0075D9CF File Offset: 0x0075BDCF
	public override void OnPostInit()
	{
		base.OnPostInit();
	}

	// Token: 0x06017D63 RID: 97635 RVA: 0x0075D9D8 File Offset: 0x0075BDD8
	public override void OnStart()
	{
		base.OnStart();
		List<BeActor> mainActorList = this.GetMainActorList();
		for (int i = 0; i < mainActorList.Count; i++)
		{
			BeEventHandle item = mainActorList[i].RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
			{
				BeBuff beBuff = args[0] as BeBuff;
				if (beBuff.buffID == this.buffID && (base.owner.sgGetCurrentState() != 14 || (base.owner.sgGetCurrentState() == 14 && base.owner.GetCurSkillID() != this.skillID)))
				{
					int count = this.GetMainActorList().Count;
					if (count == 1)
					{
						base.owner.UseSkill(this.castSkillID, false);
					}
					else if (this.AllHaveFreezeBuff())
					{
						base.owner.UseSkill(this.castSkillID, false);
					}
				}
			});
			this.handleList.Add(item);
		}
	}

	// Token: 0x06017D64 RID: 97636 RVA: 0x0075DA30 File Offset: 0x0075BE30
	private bool AllHaveFreezeBuff()
	{
		List<BeActor> mainActorList = this.GetMainActorList();
		bool result = true;
		for (int i = 0; i < mainActorList.Count; i++)
		{
			if (mainActorList[i].buffController.HasBuffByID(this.buffID) == null)
			{
				result = false;
			}
		}
		return result;
	}

	// Token: 0x06017D65 RID: 97637 RVA: 0x0075DA7C File Offset: 0x0075BE7C
	private List<BeActor> GetMainActorList()
	{
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindMainActor(list);
		return list;
	}

	// Token: 0x06017D66 RID: 97638 RVA: 0x0075DAA2 File Offset: 0x0075BEA2
	public override void OnDead()
	{
		this.RemoveHandleList();
		base.OnDead();
	}

	// Token: 0x06017D67 RID: 97639 RVA: 0x0075DAB0 File Offset: 0x0075BEB0
	public override void OnFinish()
	{
		this.RemoveHandleList();
		base.OnFinish();
	}

	// Token: 0x06017D68 RID: 97640 RVA: 0x0075DAC0 File Offset: 0x0075BEC0
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
		this.handleList.Clear();
	}

	// Token: 0x0401127B RID: 70267
	private int buffID = 521803;

	// Token: 0x0401127C RID: 70268
	private int skillID = 20211;

	// Token: 0x0401127D RID: 70269
	private int castSkillID = 20213;

	// Token: 0x0401127E RID: 70270
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
