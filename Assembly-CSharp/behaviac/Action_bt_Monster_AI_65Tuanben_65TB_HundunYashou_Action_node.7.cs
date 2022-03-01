using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B96 RID: 11158
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node18 : Action
	{
		// Token: 0x06014038 RID: 81976 RVA: 0x006024C0 File Offset: 0x006008C0
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node18()
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
			item.skillID = 20759;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014039 RID: 81977 RVA: 0x00602550 File Offset: 0x00600950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA2D RID: 55853
		private List<Input> method_p0;

		// Token: 0x0400DA2E RID: 55854
		private bool method_p1;
	}
}
