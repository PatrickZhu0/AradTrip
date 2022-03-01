using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200274F RID: 10063
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node51 : Action
	{
		// Token: 0x060137DF RID: 79839 RVA: 0x005CF538 File Offset: 0x005CD938
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node51()
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
			item.skillID = 2109;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137E0 RID: 79840 RVA: 0x005CF5C8 File Offset: 0x005CD9C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D23A RID: 53818
		private List<Input> method_p0;

		// Token: 0x0400D23B RID: 53819
		private bool method_p1;
	}
}
