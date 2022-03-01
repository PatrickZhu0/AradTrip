using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002049 RID: 8265
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node20 : Action
	{
		// Token: 0x06012A2C RID: 76332 RVA: 0x00577564 File Offset: 0x00575964
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node20()
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
			item.skillID = 2508;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012A2D RID: 76333 RVA: 0x005775F4 File Offset: 0x005759F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C41F RID: 50207
		private List<Input> method_p0;

		// Token: 0x0400C420 RID: 50208
		private bool method_p1;
	}
}
