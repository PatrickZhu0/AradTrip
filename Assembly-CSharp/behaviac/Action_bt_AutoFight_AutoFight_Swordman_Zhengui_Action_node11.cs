using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200298F RID: 10639
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node115 : Action
	{
		// Token: 0x06013C52 RID: 80978 RVA: 0x005E9EA8 File Offset: 0x005E82A8
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node115()
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
			item.skillID = 1811;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C53 RID: 80979 RVA: 0x005E9F38 File Offset: 0x005E8338
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6BB RID: 54971
		private List<Input> method_p0;

		// Token: 0x0400D6BC RID: 54972
		private bool method_p1;
	}
}
