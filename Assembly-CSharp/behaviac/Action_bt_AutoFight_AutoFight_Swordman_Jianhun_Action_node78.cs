using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002925 RID: 10533
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node78 : Action
	{
		// Token: 0x06013B80 RID: 80768 RVA: 0x005E48A4 File Offset: 0x005E2CA4
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node78()
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
			item.skillID = 1933;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B81 RID: 80769 RVA: 0x005E4934 File Offset: 0x005E2D34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5E5 RID: 54757
		private List<Input> method_p0;

		// Token: 0x0400D5E6 RID: 54758
		private bool method_p1;
	}
}
