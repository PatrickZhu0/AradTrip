using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002628 RID: 9768
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node78 : Action
	{
		// Token: 0x06013596 RID: 79254 RVA: 0x005C16C8 File Offset: 0x005BFAC8
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node78()
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
			this.method_p1 = true;
		}

		// Token: 0x06013597 RID: 79255 RVA: 0x005C1758 File Offset: 0x005BFB58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFE4 RID: 53220
		private List<Input> method_p0;

		// Token: 0x0400CFE5 RID: 53221
		private bool method_p1;
	}
}
