using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003665 RID: 13925
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node25 : Action
	{
		// Token: 0x060154EC RID: 87276 RVA: 0x0066CBB8 File Offset: 0x0066AFB8
		public Action_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node25()
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
			item.skillID = 5424;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060154ED RID: 87277 RVA: 0x0066CC48 File Offset: 0x0066B048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEA3 RID: 61091
		private List<Input> method_p0;

		// Token: 0x0400EEA4 RID: 61092
		private bool method_p1;
	}
}
