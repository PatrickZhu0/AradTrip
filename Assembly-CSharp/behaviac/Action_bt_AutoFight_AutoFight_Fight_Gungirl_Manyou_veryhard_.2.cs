using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002065 RID: 8293
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node5 : Action
	{
		// Token: 0x06012A63 RID: 76387 RVA: 0x00578DFC File Offset: 0x005771FC
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node5()
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

		// Token: 0x06012A64 RID: 76388 RVA: 0x00578E8C File Offset: 0x0057728C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C456 RID: 50262
		private List<Input> method_p0;

		// Token: 0x0400C457 RID: 50263
		private bool method_p1;
	}
}
