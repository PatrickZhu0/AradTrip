using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002331 RID: 9009
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node64 : Action
	{
		// Token: 0x06012FD5 RID: 77781 RVA: 0x0059CF68 File Offset: 0x0059B368
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node64()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06012FD6 RID: 77782 RVA: 0x0059D04C File Offset: 0x0059B44C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9EF RID: 51695
		private List<Input> method_p0;

		// Token: 0x0400C9F0 RID: 51696
		private bool method_p1;
	}
}
