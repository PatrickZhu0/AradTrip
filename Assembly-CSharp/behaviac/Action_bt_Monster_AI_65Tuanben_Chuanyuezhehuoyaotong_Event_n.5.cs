using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D62 RID: 11618
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node20 : Action
	{
		// Token: 0x060143A7 RID: 82855 RVA: 0x00613808 File Offset: 0x00611C08
		public Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node20()
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
			item.skillID = 21882;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143A8 RID: 82856 RVA: 0x00613898 File Offset: 0x00611C98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD72 RID: 56690
		private List<Input> method_p0;

		// Token: 0x0400DD73 RID: 56691
		private bool method_p1;
	}
}
