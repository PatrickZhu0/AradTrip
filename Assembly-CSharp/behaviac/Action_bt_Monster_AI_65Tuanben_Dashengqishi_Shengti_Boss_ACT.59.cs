using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E81 RID: 11905
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node169 : Action
	{
		// Token: 0x060145DF RID: 83423 RVA: 0x0061C918 File Offset: 0x0061AD18
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node169()
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
			item.skillID = 21625;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145E0 RID: 83424 RVA: 0x0061C9A8 File Offset: 0x0061ADA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF6B RID: 57195
		private List<Input> method_p0;

		// Token: 0x0400DF6C RID: 57196
		private bool method_p1;
	}
}
