using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020030CC RID: 12492
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node3 : Action
	{
		// Token: 0x06014A52 RID: 84562 RVA: 0x006377C8 File Offset: 0x00635BC8
		public Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node3()
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
			item.skillID = 20644;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014A53 RID: 84563 RVA: 0x00637858 File Offset: 0x00635C58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3BA RID: 58298
		private List<Input> method_p0;

		// Token: 0x0400E3BB RID: 58299
		private bool method_p1;
	}
}
