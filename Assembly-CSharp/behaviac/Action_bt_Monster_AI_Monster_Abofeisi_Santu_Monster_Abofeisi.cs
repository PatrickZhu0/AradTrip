using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035E4 RID: 13796
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node5 : Action
	{
		// Token: 0x060153F0 RID: 87024 RVA: 0x006678C8 File Offset: 0x00665CC8
		public Action_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node5()
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
			item.skillID = 5653;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060153F1 RID: 87025 RVA: 0x00667958 File Offset: 0x00665D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDAE RID: 60846
		private List<Input> method_p0;

		// Token: 0x0400EDAF RID: 60847
		private bool method_p1;
	}
}
