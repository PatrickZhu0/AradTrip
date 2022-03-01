using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200203D RID: 8253
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node5 : Action
	{
		// Token: 0x06012A14 RID: 76308 RVA: 0x00576FE0 File Offset: 0x005753E0
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node5()
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
			item.skillID = 2518;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012A15 RID: 76309 RVA: 0x00577070 File Offset: 0x00575470
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C407 RID: 50183
		private List<Input> method_p0;

		// Token: 0x0400C408 RID: 50184
		private bool method_p1;
	}
}
