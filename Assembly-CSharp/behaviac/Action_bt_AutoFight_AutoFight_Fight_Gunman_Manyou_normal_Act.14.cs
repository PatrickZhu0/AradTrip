using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002195 RID: 8597
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node35 : Action
	{
		// Token: 0x06012CBA RID: 76986 RVA: 0x00586F90 File Offset: 0x00585390
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node35()
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
			item.skillID = 1009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012CBB RID: 76987 RVA: 0x00587020 File Offset: 0x00585420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6AD RID: 50861
		private List<Input> method_p0;

		// Token: 0x0400C6AE RID: 50862
		private bool method_p1;
	}
}
