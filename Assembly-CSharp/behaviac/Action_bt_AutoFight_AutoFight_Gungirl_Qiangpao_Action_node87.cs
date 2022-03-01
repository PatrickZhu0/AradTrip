using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200254F RID: 9551
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node87 : Action
	{
		// Token: 0x060133E7 RID: 78823 RVA: 0x005B74EC File Offset: 0x005B58EC
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node87()
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
			item.skillID = 2504;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133E8 RID: 78824 RVA: 0x005B757C File Offset: 0x005B597C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE0D RID: 52749
		private List<Input> method_p0;

		// Token: 0x0400CE0E RID: 52750
		private bool method_p1;
	}
}
