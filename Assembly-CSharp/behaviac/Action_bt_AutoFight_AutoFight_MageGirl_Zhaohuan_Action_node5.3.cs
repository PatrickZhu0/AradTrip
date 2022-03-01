using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002755 RID: 10069
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node59 : Action
	{
		// Token: 0x060137EB RID: 79851 RVA: 0x005CF810 File Offset: 0x005CDC10
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node59()
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
			item.skillID = 2118;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137EC RID: 79852 RVA: 0x005CF8A0 File Offset: 0x005CDCA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D248 RID: 53832
		private List<Input> method_p0;

		// Token: 0x0400D249 RID: 53833
		private bool method_p1;
	}
}
