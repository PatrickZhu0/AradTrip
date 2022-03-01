using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003410 RID: 13328
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Action_node1 : Action
	{
		// Token: 0x06015071 RID: 86129 RVA: 0x00655BCC File Offset: 0x00653FCC
		public Action_bt_Monster_AI_Heisedadi_Huimie_Action_node1()
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
			item.skillID = 6218;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015072 RID: 86130 RVA: 0x00655C5C File Offset: 0x0065405C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E949 RID: 59721
		private List<Input> method_p0;

		// Token: 0x0400E94A RID: 59722
		private bool method_p1;
	}
}
