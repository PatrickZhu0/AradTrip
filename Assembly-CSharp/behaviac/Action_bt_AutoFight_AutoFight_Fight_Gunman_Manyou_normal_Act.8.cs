using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002189 RID: 8585
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node20 : Action
	{
		// Token: 0x06012CA2 RID: 76962 RVA: 0x00586A0C File Offset: 0x00584E0C
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node20()
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
			item.skillID = 1007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012CA3 RID: 76963 RVA: 0x00586A9C File Offset: 0x00584E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C695 RID: 50837
		private List<Input> method_p0;

		// Token: 0x0400C696 RID: 50838
		private bool method_p1;
	}
}
