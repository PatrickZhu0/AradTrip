using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D45 RID: 7493
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Gunman_test_Action_node10 : Action
	{
		// Token: 0x0601244B RID: 74827 RVA: 0x005543AC File Offset: 0x005527AC
		public Action_bt_APC_APC_Gunman_test_Action_node10()
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
			item.skillID = 1006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601244C RID: 74828 RVA: 0x0055443C File Offset: 0x0055283C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE3E RID: 48702
		private List<Input> method_p0;

		// Token: 0x0400BE3F RID: 48703
		private bool method_p1;
	}
}
