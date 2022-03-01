using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CFA RID: 11514
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node51 : Action
	{
		// Token: 0x060142E4 RID: 82660 RVA: 0x0060F404 File Offset: 0x0060D804
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node51()
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
			item.skillID = 20744;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142E5 RID: 82661 RVA: 0x0060F494 File Offset: 0x0060D894
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC8D RID: 56461
		private List<Input> method_p0;

		// Token: 0x0400DC8E RID: 56462
		private bool method_p1;
	}
}
