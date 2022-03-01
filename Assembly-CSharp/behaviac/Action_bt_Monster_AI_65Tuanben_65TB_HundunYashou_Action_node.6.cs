using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B92 RID: 11154
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node8 : Action
	{
		// Token: 0x06014030 RID: 81968 RVA: 0x00602340 File Offset: 0x00600740
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node8()
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
			item.skillID = 20766;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014031 RID: 81969 RVA: 0x006023D0 File Offset: 0x006007D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA26 RID: 55846
		private List<Input> method_p0;

		// Token: 0x0400DA27 RID: 55847
		private bool method_p1;
	}
}
