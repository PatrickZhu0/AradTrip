using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200267C RID: 9852
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node12 : Action
	{
		// Token: 0x0601363D RID: 79421 RVA: 0x005C4F5C File Offset: 0x005C335C
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node12()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601363E RID: 79422 RVA: 0x005C4FF0 File Offset: 0x005C33F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D08F RID: 53391
		private List<Input> method_p0;

		// Token: 0x0400D090 RID: 53392
		private bool method_p1;
	}
}
