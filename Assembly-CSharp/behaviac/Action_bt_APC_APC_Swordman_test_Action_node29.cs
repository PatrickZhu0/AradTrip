using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E0B RID: 7691
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Swordman_test_Action_node29 : Action
	{
		// Token: 0x060125C9 RID: 75209 RVA: 0x0055CD1C File Offset: 0x0055B11C
		public Action_bt_APC_APC_Swordman_test_Action_node29()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060125CA RID: 75210 RVA: 0x0055CDAC File Offset: 0x0055B1AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFB6 RID: 49078
		private List<Input> method_p0;

		// Token: 0x0400BFB7 RID: 49079
		private bool method_p1;
	}
}
