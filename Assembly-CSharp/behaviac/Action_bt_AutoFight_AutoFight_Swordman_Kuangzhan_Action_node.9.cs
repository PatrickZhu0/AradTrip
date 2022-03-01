using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002963 RID: 10595
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node75 : Action
	{
		// Token: 0x06013BFB RID: 80891 RVA: 0x005E7868 File Offset: 0x005E5C68
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node75()
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
			item.skillID = 1608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013BFC RID: 80892 RVA: 0x005E78F8 File Offset: 0x005E5CF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D660 RID: 54880
		private List<Input> method_p0;

		// Token: 0x0400D661 RID: 54881
		private bool method_p1;
	}
}
