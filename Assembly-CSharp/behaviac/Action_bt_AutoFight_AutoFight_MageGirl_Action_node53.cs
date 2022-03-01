using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002693 RID: 9875
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node53 : Action
	{
		// Token: 0x0601366A RID: 79466 RVA: 0x005C6C1C File Offset: 0x005C501C
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node53()
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
			item.skillID = 2006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601366B RID: 79467 RVA: 0x005C6CAC File Offset: 0x005C50AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0BD RID: 53437
		private List<Input> method_p0;

		// Token: 0x0400D0BE RID: 53438
		private bool method_p1;
	}
}
