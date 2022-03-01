using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200315F RID: 12639
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node1 : Action
	{
		// Token: 0x06014B5B RID: 84827 RVA: 0x0063CAD4 File Offset: 0x0063AED4
		public Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node1()
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
			item.skillID = 20435;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B5C RID: 84828 RVA: 0x0063CB64 File Offset: 0x0063AF64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4D2 RID: 58578
		private List<Input> method_p0;

		// Token: 0x0400E4D3 RID: 58579
		private bool method_p1;
	}
}
