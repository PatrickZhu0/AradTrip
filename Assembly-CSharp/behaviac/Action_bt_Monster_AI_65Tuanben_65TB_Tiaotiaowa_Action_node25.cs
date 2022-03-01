using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CE8 RID: 11496
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node25 : Action
	{
		// Token: 0x060142C0 RID: 82624 RVA: 0x0060ED84 File Offset: 0x0060D184
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node25()
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

		// Token: 0x060142C1 RID: 82625 RVA: 0x0060EE14 File Offset: 0x0060D214
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC6E RID: 56430
		private List<Input> method_p0;

		// Token: 0x0400DC6F RID: 56431
		private bool method_p1;
	}
}
