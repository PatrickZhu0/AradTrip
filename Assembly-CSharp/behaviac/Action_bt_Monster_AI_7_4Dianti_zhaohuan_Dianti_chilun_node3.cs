using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F28 RID: 12072
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3 : Action
	{
		// Token: 0x06014724 RID: 83748 RVA: 0x00626B90 File Offset: 0x00624F90
		public Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3()
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
			item.skillID = 20308;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014725 RID: 83749 RVA: 0x00626C20 File Offset: 0x00625020
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E098 RID: 57496
		private List<Input> method_p0;

		// Token: 0x0400E099 RID: 57497
		private bool method_p1;
	}
}
