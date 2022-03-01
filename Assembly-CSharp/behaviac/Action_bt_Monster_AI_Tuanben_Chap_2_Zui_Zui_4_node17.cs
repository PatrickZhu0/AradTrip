using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200381B RID: 14363
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node17 : Action
	{
		// Token: 0x06015825 RID: 88101 RVA: 0x0067D9F4 File Offset: 0x0067BDF4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node17()
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
			item.skillID = 21200;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015826 RID: 88102 RVA: 0x0067DA84 File Offset: 0x0067BE84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1E6 RID: 61926
		private List<Input> method_p0;

		// Token: 0x0400F1E7 RID: 61927
		private bool method_p1;
	}
}
