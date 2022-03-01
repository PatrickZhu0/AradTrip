using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003178 RID: 12664
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node28 : Action
	{
		// Token: 0x06014B87 RID: 84871 RVA: 0x0063D498 File Offset: 0x0063B898
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node28()
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
			item.skillID = 21543;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B88 RID: 84872 RVA: 0x0063D528 File Offset: 0x0063B928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4F4 RID: 58612
		private List<Input> method_p0;

		// Token: 0x0400E4F5 RID: 58613
		private bool method_p1;
	}
}
