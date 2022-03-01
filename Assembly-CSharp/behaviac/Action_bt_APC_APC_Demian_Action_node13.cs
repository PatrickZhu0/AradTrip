using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D04 RID: 7428
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Demian_Action_node13 : Action
	{
		// Token: 0x060123CD RID: 74701 RVA: 0x00550D1C File Offset: 0x0054F11C
		public Action_bt_APC_APC_Demian_Action_node13()
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
			item.skillID = 8005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060123CE RID: 74702 RVA: 0x00550DAD File Offset: 0x0054F1AD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDC3 RID: 48579
		private List<Input> method_p0;

		// Token: 0x0400BDC4 RID: 48580
		private bool method_p1;
	}
}
