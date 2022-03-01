using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020028E8 RID: 10472
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node49 : Action
	{
		// Token: 0x06013B07 RID: 80647 RVA: 0x005E2128 File Offset: 0x005E0528
		public Action_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node49()
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
			item.skillID = 4015;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013B08 RID: 80648 RVA: 0x005E21B8 File Offset: 0x005E05B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D569 RID: 54633
		private List<Input> method_p0;

		// Token: 0x0400D56A RID: 54634
		private bool method_p1;
	}
}
