using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002019 RID: 8217
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node10 : Action
	{
		// Token: 0x060129CD RID: 76237 RVA: 0x00575360 File Offset: 0x00573760
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node10()
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
			item.skillID = 2517;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060129CE RID: 76238 RVA: 0x005753F0 File Offset: 0x005737F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3C0 RID: 50112
		private List<Input> method_p0;

		// Token: 0x0400C3C1 RID: 50113
		private bool method_p1;
	}
}
