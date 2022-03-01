using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E71 RID: 7793
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node51 : Action
	{
		// Token: 0x0601268E RID: 75406 RVA: 0x00561C24 File Offset: 0x00560024
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node51()
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
			item.skillID = 9720;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601268F RID: 75407 RVA: 0x00561CB4 File Offset: 0x005600B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C076 RID: 49270
		private List<Input> method_p0;

		// Token: 0x0400C077 RID: 49271
		private bool method_p1;
	}
}
