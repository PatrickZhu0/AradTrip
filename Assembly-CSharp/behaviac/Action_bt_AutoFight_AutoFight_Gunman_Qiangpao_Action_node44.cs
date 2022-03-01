using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002678 RID: 9848
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node44 : Action
	{
		// Token: 0x06013635 RID: 79413 RVA: 0x005C4DA8 File Offset: 0x005C31A8
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node44()
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
			item.skillID = 1013;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013636 RID: 79414 RVA: 0x005C4E38 File Offset: 0x005C3238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D087 RID: 53383
		private List<Input> method_p0;

		// Token: 0x0400D088 RID: 53384
		private bool method_p1;
	}
}
