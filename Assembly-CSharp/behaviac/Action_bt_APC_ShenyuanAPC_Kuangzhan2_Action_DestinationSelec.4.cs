using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E81 RID: 7809
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node28 : Action
	{
		// Token: 0x060126AD RID: 75437 RVA: 0x00562880 File Offset: 0x00560C80
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node28()
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
			item.skillID = 9702;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126AE RID: 75438 RVA: 0x00562910 File Offset: 0x00560D10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C094 RID: 49300
		private List<Input> method_p0;

		// Token: 0x0400C095 RID: 49301
		private bool method_p1;
	}
}
