using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002585 RID: 9605
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node39 : Action
	{
		// Token: 0x06013452 RID: 78930 RVA: 0x005BA6AC File Offset: 0x005B8AAC
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 200;
			item.randomChangeDirection = false;
			item.skillID = 1102;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013453 RID: 78931 RVA: 0x005BA740 File Offset: 0x005B8B40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE7B RID: 52859
		private List<Input> method_p0;

		// Token: 0x0400CE7C RID: 52860
		private bool method_p1;
	}
}
