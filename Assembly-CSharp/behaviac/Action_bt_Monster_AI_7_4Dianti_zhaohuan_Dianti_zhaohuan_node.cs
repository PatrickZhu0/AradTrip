using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F2E RID: 12078
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node3 : Action
	{
		// Token: 0x0601472F RID: 83759 RVA: 0x00626FD0 File Offset: 0x006253D0
		public Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node3()
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
			item.skillID = 20306;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014730 RID: 83760 RVA: 0x00627060 File Offset: 0x00625460
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E09F RID: 57503
		private List<Input> method_p0;

		// Token: 0x0400E0A0 RID: 57504
		private bool method_p1;
	}
}
