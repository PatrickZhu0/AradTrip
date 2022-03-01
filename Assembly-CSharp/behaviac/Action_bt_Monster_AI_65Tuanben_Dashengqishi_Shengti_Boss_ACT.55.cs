using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E75 RID: 11893
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node277 : Action
	{
		// Token: 0x060145C7 RID: 83399 RVA: 0x0061C364 File Offset: 0x0061A764
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node277()
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
			item.skillID = 21640;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145C8 RID: 83400 RVA: 0x0061C3F4 File Offset: 0x0061A7F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF4F RID: 57167
		private List<Input> method_p0;

		// Token: 0x0400DF50 RID: 57168
		private bool method_p1;
	}
}
