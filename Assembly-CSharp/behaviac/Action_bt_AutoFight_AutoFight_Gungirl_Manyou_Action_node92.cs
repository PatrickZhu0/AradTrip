using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024CF RID: 9423
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node92 : Action
	{
		// Token: 0x060132E8 RID: 78568 RVA: 0x005B21D4 File Offset: 0x005B05D4
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node92()
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
			item.skillID = 2528;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060132E9 RID: 78569 RVA: 0x005B2264 File Offset: 0x005B0664
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD05 RID: 52485
		private List<Input> method_p0;

		// Token: 0x0400CD06 RID: 52486
		private bool method_p1;
	}
}
