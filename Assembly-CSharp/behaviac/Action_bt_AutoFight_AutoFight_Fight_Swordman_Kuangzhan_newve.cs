using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002397 RID: 9111
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node8 : Action
	{
		// Token: 0x06013094 RID: 77972 RVA: 0x005A2640 File Offset: 0x005A0A40
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node8()
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
			item.skillID = 1609;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013095 RID: 77973 RVA: 0x005A26D0 File Offset: 0x005A0AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAB0 RID: 51888
		private List<Input> method_p0;

		// Token: 0x0400CAB1 RID: 51889
		private bool method_p1;
	}
}
