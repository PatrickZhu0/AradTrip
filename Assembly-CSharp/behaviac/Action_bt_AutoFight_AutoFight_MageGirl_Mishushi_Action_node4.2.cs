using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026E5 RID: 9957
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node40 : Action
	{
		// Token: 0x0601370D RID: 79629 RVA: 0x005C9C68 File Offset: 0x005C8068
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node40()
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

		// Token: 0x0601370E RID: 79630 RVA: 0x005C9CF8 File Offset: 0x005C80F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D163 RID: 53603
		private List<Input> method_p0;

		// Token: 0x0400D164 RID: 53604
		private bool method_p1;
	}
}
