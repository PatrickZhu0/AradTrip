using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D02 RID: 11522
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node61 : Action
	{
		// Token: 0x060142F4 RID: 82676 RVA: 0x0060F704 File Offset: 0x0060DB04
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node61()
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
			item.skillID = 20746;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060142F5 RID: 82677 RVA: 0x0060F794 File Offset: 0x0060DB94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC9B RID: 56475
		private List<Input> method_p0;

		// Token: 0x0400DC9C RID: 56476
		private bool method_p1;
	}
}
