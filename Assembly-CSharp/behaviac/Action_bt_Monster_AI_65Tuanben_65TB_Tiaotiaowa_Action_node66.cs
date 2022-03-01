using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D06 RID: 11526
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node66 : Action
	{
		// Token: 0x060142FC RID: 82684 RVA: 0x0060F884 File Offset: 0x0060DC84
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node66()
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
			item.skillID = 20748;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142FD RID: 82685 RVA: 0x0060F914 File Offset: 0x0060DD14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCA2 RID: 56482
		private List<Input> method_p0;

		// Token: 0x0400DCA3 RID: 56483
		private bool method_p1;
	}
}
