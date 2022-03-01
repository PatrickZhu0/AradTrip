using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B84 RID: 11140
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node29 : Action
	{
		// Token: 0x06014014 RID: 81940 RVA: 0x00601E24 File Offset: 0x00600224
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node29()
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
			item.skillID = 20770;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014015 RID: 81941 RVA: 0x00601EB4 File Offset: 0x006002B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA12 RID: 55826
		private List<Input> method_p0;

		// Token: 0x0400DA13 RID: 55827
		private bool method_p1;
	}
}
