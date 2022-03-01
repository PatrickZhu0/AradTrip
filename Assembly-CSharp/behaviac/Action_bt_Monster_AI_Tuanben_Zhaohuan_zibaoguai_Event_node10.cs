using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B80 RID: 15232
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node10 : Action
	{
		// Token: 0x06015EB2 RID: 89778 RVA: 0x0069F8F4 File Offset: 0x0069DCF4
		public Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node10()
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
			item.skillID = 21402;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015EB3 RID: 89779 RVA: 0x0069F984 File Offset: 0x0069DD84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F775 RID: 63349
		private List<Input> method_p0;

		// Token: 0x0400F776 RID: 63350
		private bool method_p1;
	}
}
