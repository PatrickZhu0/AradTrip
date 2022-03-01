using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E9B RID: 7835
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_node57 : Action
	{
		// Token: 0x060126E0 RID: 75488 RVA: 0x00563A6C File Offset: 0x00561E6C
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_node57()
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
			item.skillID = 9743;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126E1 RID: 75489 RVA: 0x00563AFC File Offset: 0x00561EFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0CD RID: 49357
		private List<Input> method_p0;

		// Token: 0x0400C0CE RID: 49358
		private bool method_p1;
	}
}
