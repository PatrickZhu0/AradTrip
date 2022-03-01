using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200275B RID: 10075
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node4 : Action
	{
		// Token: 0x060137F7 RID: 79863 RVA: 0x005CFAE8 File Offset: 0x005CDEE8
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node4()
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
			item.skillID = 2111;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137F8 RID: 79864 RVA: 0x005CFB78 File Offset: 0x005CDF78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D256 RID: 53846
		private List<Input> method_p0;

		// Token: 0x0400D257 RID: 53847
		private bool method_p1;
	}
}
