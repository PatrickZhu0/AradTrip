using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F91 RID: 12177
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node37 : Action
	{
		// Token: 0x060147F0 RID: 83952 RVA: 0x0062AAC8 File Offset: 0x00628EC8
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node37()
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
			item.skillID = 5531;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060147F1 RID: 83953 RVA: 0x0062AB58 File Offset: 0x00628F58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E154 RID: 57684
		private List<Input> method_p0;

		// Token: 0x0400E155 RID: 57685
		private bool method_p1;
	}
}
