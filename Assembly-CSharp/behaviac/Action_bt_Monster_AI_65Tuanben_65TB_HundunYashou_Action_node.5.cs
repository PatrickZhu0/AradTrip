using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002B8E RID: 11150
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node1 : Action
	{
		// Token: 0x06014028 RID: 81960 RVA: 0x006021C0 File Offset: 0x006005C0
		public Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node1()
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
			item.skillID = 20765;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014029 RID: 81961 RVA: 0x00602250 File Offset: 0x00600650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA1F RID: 55839
		private List<Input> method_p0;

		// Token: 0x0400DA20 RID: 55840
		private bool method_p1;
	}
}
