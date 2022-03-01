using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002A62 RID: 10850
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Guanka_apc_guijian_jue_node13 : Action
	{
		// Token: 0x06013DEE RID: 81390 RVA: 0x005F475C File Offset: 0x005F2B5C
		public Action_bt_Guanka_apc_guijian_jue_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
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

		// Token: 0x06013DEF RID: 81391 RVA: 0x005F47ED File Offset: 0x005F2BED
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D861 RID: 55393
		private List<Input> method_p0;

		// Token: 0x0400D862 RID: 55394
		private bool method_p1;
	}
}
