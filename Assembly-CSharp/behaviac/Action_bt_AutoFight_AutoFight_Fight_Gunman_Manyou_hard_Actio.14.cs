using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200216D RID: 8557
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node35 : Action
	{
		// Token: 0x06012C6B RID: 76907 RVA: 0x00585174 File Offset: 0x00583574
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node35()
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

		// Token: 0x06012C6C RID: 76908 RVA: 0x00585204 File Offset: 0x00583604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C65E RID: 50782
		private List<Input> method_p0;

		// Token: 0x0400C65F RID: 50783
		private bool method_p1;
	}
}
