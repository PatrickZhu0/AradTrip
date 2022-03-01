using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E7B RID: 11899
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node156 : Action
	{
		// Token: 0x060145D3 RID: 83411 RVA: 0x0061C640 File Offset: 0x0061AA40
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node156()
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
			item.skillID = 21623;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060145D4 RID: 83412 RVA: 0x0061C6D0 File Offset: 0x0061AAD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF5D RID: 57181
		private List<Input> method_p0;

		// Token: 0x0400DF5E RID: 57182
		private bool method_p1;
	}
}
