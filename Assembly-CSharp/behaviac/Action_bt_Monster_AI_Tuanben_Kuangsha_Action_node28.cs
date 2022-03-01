using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003AC9 RID: 15049
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node28 : Action
	{
		// Token: 0x06015D51 RID: 89425 RVA: 0x00698864 File Offset: 0x00696C64
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node28()
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
			item.skillID = 21032;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015D52 RID: 89426 RVA: 0x006988F4 File Offset: 0x00696CF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F660 RID: 63072
		private List<Input> method_p0;

		// Token: 0x0400F661 RID: 63073
		private bool method_p1;
	}
}
