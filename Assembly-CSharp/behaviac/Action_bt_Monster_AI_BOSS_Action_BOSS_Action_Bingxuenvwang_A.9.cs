using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F9B RID: 12187
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node47 : Action
	{
		// Token: 0x06014804 RID: 83972 RVA: 0x0062AEC0 File Offset: 0x006292C0
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 5547;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014805 RID: 83973 RVA: 0x0062AF50 File Offset: 0x00629350
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E166 RID: 57702
		private List<Input> method_p0;

		// Token: 0x0400E167 RID: 57703
		private bool method_p1;
	}
}
