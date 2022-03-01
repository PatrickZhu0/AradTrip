using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002758 RID: 10072
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node63 : Action
	{
		// Token: 0x060137F1 RID: 79857 RVA: 0x005CF97C File Offset: 0x005CDD7C
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node63()
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
			item.skillID = 2100;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137F2 RID: 79858 RVA: 0x005CFA0C File Offset: 0x005CDE0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D24F RID: 53839
		private List<Input> method_p0;

		// Token: 0x0400D250 RID: 53840
		private bool method_p1;
	}
}
