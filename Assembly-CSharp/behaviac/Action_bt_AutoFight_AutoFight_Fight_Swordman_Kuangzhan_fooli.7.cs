using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002354 RID: 9044
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node46 : Action
	{
		// Token: 0x06013015 RID: 77845 RVA: 0x0059EC40 File Offset: 0x0059D040
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node46()
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
			item.skillID = 1604;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1200;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1606;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013016 RID: 77846 RVA: 0x0059ED2C File Offset: 0x0059D12C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA2B RID: 51755
		private List<Input> method_p0;

		// Token: 0x0400CA2C RID: 51756
		private bool method_p1;
	}
}
