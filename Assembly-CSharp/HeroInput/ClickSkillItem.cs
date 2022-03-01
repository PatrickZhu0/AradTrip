using System;

namespace HeroInput
{
	// Token: 0x02000169 RID: 361
	public class ClickSkillItem : ClickSkillBaseItem
	{
		// Token: 0x06000A86 RID: 2694 RVA: 0x000366A0 File Offset: 0x00034AA0
		protected int _getCurrentTime()
		{
			if (base.index >= this.mClickList.Count)
			{
				Logger.LogErrorFormat("out of range with {0}", new object[]
				{
					base.index
				});
				return -1;
			}
			return this.mClickList[base.index].time;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x000366F9 File Offset: 0x00034AF9
		protected void _updateLeftTime(int deltaTime)
		{
			this.mCurrentTime -= deltaTime;
			if (this.mCurrentTime <= 0)
			{
				this._abortSkill();
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0003671B File Offset: 0x00034B1B
		protected override void _nextSkill()
		{
			base._nextSkill();
			this.mCurrentTime = this._getCurrentTime();
			if (!this._canUseSkill())
			{
				this._abortSkill();
			}
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00036740 File Offset: 0x00034B40
		protected override bool _canUseSkill()
		{
			if (!base._canUseSkill())
			{
				return false;
			}
			int skillID = base._getCurrentSkillID();
			BeSkill skill = base.inputManager.controllActor.GetSkill(skillID);
			if (this.mIsBeginClickChain && skill.isCooldown)
			{
				int num = this._getCurrentTime();
				int cdleftTime = skill.CDLeftTime;
				return cdleftTime < num;
			}
			return true;
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0003679D File Offset: 0x00034B9D
		public override void Update(int deltaTime)
		{
			base.Update(deltaTime);
			if (!this.mIsBeginClickChain)
			{
				return;
			}
			this._updateLeftTime(deltaTime);
		}

		// Token: 0x040007AB RID: 1963
		protected int mCurrentTime;
	}
}
