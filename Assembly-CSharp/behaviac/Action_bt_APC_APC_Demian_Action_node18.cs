using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D09 RID: 7433
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Demian_Action_node18 : Action
	{
		// Token: 0x060123D7 RID: 74711 RVA: 0x00550F2C File Offset: 0x0054F32C
		public Action_bt_APC_APC_Demian_Action_node18()
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
			item.skillID = 8006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060123D8 RID: 74712 RVA: 0x00550FBC File Offset: 0x0054F3BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDCE RID: 48590
		private List<Input> method_p0;

		// Token: 0x0400BDCF RID: 48591
		private bool method_p1;
	}
}
