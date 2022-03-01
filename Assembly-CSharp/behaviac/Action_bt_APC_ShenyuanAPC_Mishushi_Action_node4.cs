using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E8F RID: 7823
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_node4 : Action
	{
		// Token: 0x060126C8 RID: 75464 RVA: 0x00563550 File Offset: 0x00561950
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_node4()
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
			item.skillID = 9740;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126C9 RID: 75465 RVA: 0x005635E0 File Offset: 0x005619E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0B5 RID: 49333
		private List<Input> method_p0;

		// Token: 0x0400C0B6 RID: 49334
		private bool method_p1;
	}
}
