using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DC6 RID: 7622
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_node67 : Action
	{
		// Token: 0x06012544 RID: 75076 RVA: 0x0055A058 File Offset: 0x00558458
		public Action_bt_APC_APC_Mishushi_Action_node67()
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
			item.skillID = 9742;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012545 RID: 75077 RVA: 0x0055A0E8 File Offset: 0x005584E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF38 RID: 48952
		private List<Input> method_p0;

		// Token: 0x0400BF39 RID: 48953
		private bool method_p1;
	}
}
