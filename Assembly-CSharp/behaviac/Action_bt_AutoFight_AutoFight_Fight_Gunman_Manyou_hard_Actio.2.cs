using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002155 RID: 8533
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node5 : Action
	{
		// Token: 0x06012C3B RID: 76859 RVA: 0x0058466C File Offset: 0x00582A6C
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node5()
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
			item.skillID = 1106;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012C3C RID: 76860 RVA: 0x005846FC File Offset: 0x00582AFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C62E RID: 50734
		private List<Input> method_p0;

		// Token: 0x0400C62F RID: 50735
		private bool method_p1;
	}
}
