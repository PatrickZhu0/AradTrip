using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200357D RID: 13693
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node7 : Action
	{
		// Token: 0x0601532D RID: 86829 RVA: 0x00663924 File Offset: 0x00661D24
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node7()
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
			item.skillID = 5462;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601532E RID: 86830 RVA: 0x006639B4 File Offset: 0x00661DB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECF0 RID: 60656
		private List<Input> method_p0;

		// Token: 0x0400ECF1 RID: 60657
		private bool method_p1;
	}
}
