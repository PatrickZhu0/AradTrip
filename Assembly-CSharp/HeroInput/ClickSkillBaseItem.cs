using System;
using System.Collections.Generic;
using ProtoTable;

namespace HeroInput
{
	// Token: 0x02000167 RID: 359
	public class ClickSkillBaseItem
	{
		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00036313 File Offset: 0x00034713
		// (set) Token: 0x06000A68 RID: 2664 RVA: 0x0003630A File Offset: 0x0003470A
		public InputManager inputManager { protected get; set; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x00036324 File Offset: 0x00034724
		// (set) Token: 0x06000A6A RID: 2666 RVA: 0x0003631B File Offset: 0x0003471B
		public ETCButton button
		{
			protected get
			{
				if (this.mButton == null)
				{
					Logger.LogError("Button is nil");
				}
				return this.mButton;
			}
			set
			{
				this.mButton = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x00036347 File Offset: 0x00034747
		// (set) Token: 0x06000A6D RID: 2669 RVA: 0x0003634F File Offset: 0x0003474F
		public int index { get; protected set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x00036361 File Offset: 0x00034761
		// (set) Token: 0x06000A6E RID: 2670 RVA: 0x00036358 File Offset: 0x00034758
		public int pid { protected get; set; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x00036372 File Offset: 0x00034772
		// (set) Token: 0x06000A70 RID: 2672 RVA: 0x00036369 File Offset: 0x00034769
		public bool isDead { get; set; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000A73 RID: 2675 RVA: 0x00036383 File Offset: 0x00034783
		// (set) Token: 0x06000A72 RID: 2674 RVA: 0x0003637A File Offset: 0x0003477A
		public ClickSkillBaseItem.AbortHandle abortHandle { protected get; set; }

		// Token: 0x06000A74 RID: 2676 RVA: 0x0003638C File Offset: 0x0003478C
		public void SetClickList(InputSkillComboData[] list)
		{
			this.mClickList = new List<InputSkillComboData>(list);
			this.mClickSkillIDList.Clear();
			for (int i = 0; i < this.mClickList.Count; i++)
			{
				InputSkillComboData inputSkillComboData = this.mClickList[i];
				int skillIDBySlot = this.inputManager.GetSkillIDBySlot(this.pid, inputSkillComboData.slot);
				this.mClickSkillIDList.Add(skillIDBySlot);
			}
			this._refreshButtonIcon();
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00036404 File Offset: 0x00034804
		protected int _getCurrentSkillID()
		{
			if (this.index >= this.mClickSkillIDList.Count)
			{
				Logger.LogErrorFormat("out of range with index {0}", new object[]
				{
					this.index
				});
				return -1;
			}
			return this.mClickSkillIDList[this.index];
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00036458 File Offset: 0x00034858
		protected void _refreshButtonIcon()
		{
			if (this.button == null)
			{
				Logger.LogErrorFormat("nil button", new object[0]);
				return;
			}
			int num = this._getCurrentSkillID();
			if (Singleton<TableManager>.instance.GetTableItem<SkillTable>(num, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("can't find skil item with id : {0}", new object[]
				{
					num
				});
				return;
			}
			this.button.SetFgImage("skillItem.Icon", true);
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000364D5 File Offset: 0x000348D5
		protected bool _realNextSkill()
		{
			this.index++;
			return this.index < this.mClickList.Count;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x000364FE File Offset: 0x000348FE
		protected void _resetSkill()
		{
			this.index = 0;
			this._refreshButtonIcon();
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00036510 File Offset: 0x00034910
		protected int _useSkill()
		{
			int num = this._getCurrentSkillID();
			this.inputManager.CreateSkillFrameCommand(num, 0);
			return num;
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00036534 File Offset: 0x00034934
		protected void _updateCurrentLeftTime(int deltaTime)
		{
			int skillID = this._getCurrentSkillID();
			BeSkill skill = this.inputManager.controllActor.GetSkill(skillID);
			if (skill != null && skill.isCooldown)
			{
				this.button.UpdateFakeCoolDown(skill.CDTimeAcc, skill.GetCurrentCD(), skill.isBuffSkill);
			}
			else
			{
				this.button.StopFakeCoolDown(false);
			}
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00036599 File Offset: 0x00034999
		protected virtual void _nextSkill()
		{
			if (!this._realNextSkill())
			{
				this._abortSkill();
				return;
			}
			this._refreshButtonIcon();
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x000365B3 File Offset: 0x000349B3
		protected virtual void _abortSkill()
		{
			this._resetSkill();
			if (this.abortHandle != null)
			{
				this.abortHandle();
			}
			this.mIsBeginClickChain = false;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000365D8 File Offset: 0x000349D8
		protected virtual bool _canUseSkill()
		{
			int skillID = this._getCurrentSkillID();
			BeSkill skill = this.inputManager.controllActor.GetSkill(skillID);
			return skill != null && skill.CanUseSkill();
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x00036614 File Offset: 0x00034A14
		public virtual int UseSkill()
		{
			int result = -1;
			if (this._canUseSkill() && !this.inputManager.controllActor.IsCastingSkill())
			{
				result = this._useSkill();
				this.mIsBeginClickChain = true;
				this._nextSkill();
			}
			return result;
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00036658 File Offset: 0x00034A58
		public virtual void SkipSkill(int skillID)
		{
			int num = this._getCurrentSkillID();
			if (skillID == num)
			{
				this.mIsBeginClickChain = true;
				this._nextSkill();
			}
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00036680 File Offset: 0x00034A80
		public virtual void Update(int deltaTime)
		{
			if (this.isDead)
			{
				return;
			}
			this._updateCurrentLeftTime(deltaTime);
		}

		// Token: 0x040007A3 RID: 1955
		protected ETCButton mButton;

		// Token: 0x040007A8 RID: 1960
		protected bool mIsBeginClickChain;

		// Token: 0x040007A9 RID: 1961
		protected List<InputSkillComboData> mClickList = new List<InputSkillComboData>();

		// Token: 0x040007AA RID: 1962
		protected List<int> mClickSkillIDList = new List<int>();

		// Token: 0x02000168 RID: 360
		// (Invoke) Token: 0x06000A82 RID: 2690
		public delegate void AbortHandle();
	}
}
