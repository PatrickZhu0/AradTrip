using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002CE0 RID: 11488
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node8 : Action
	{
		// Token: 0x060142B0 RID: 82608 RVA: 0x0060EA84 File Offset: 0x0060CE84
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node8()
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

		// Token: 0x060142B1 RID: 82609 RVA: 0x0060EB14 File Offset: 0x0060CF14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC60 RID: 56416
		private List<Input> method_p0;

		// Token: 0x0400DC61 RID: 56417
		private bool method_p1;
	}
}
