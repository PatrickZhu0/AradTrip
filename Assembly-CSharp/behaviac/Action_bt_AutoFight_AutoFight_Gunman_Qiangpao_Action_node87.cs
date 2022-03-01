using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002674 RID: 9844
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node87 : Action
	{
		// Token: 0x0601362D RID: 79405 RVA: 0x005C4BF0 File Offset: 0x005C2FF0
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node87()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 500;
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

		// Token: 0x0601362E RID: 79406 RVA: 0x005C4C84 File Offset: 0x005C3084
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D07F RID: 53375
		private List<Input> method_p0;

		// Token: 0x0400D080 RID: 53376
		private bool method_p1;
	}
}
