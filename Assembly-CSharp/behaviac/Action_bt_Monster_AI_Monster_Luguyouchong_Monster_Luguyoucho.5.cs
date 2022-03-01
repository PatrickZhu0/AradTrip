using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036D0 RID: 14032
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node4 : Action
	{
		// Token: 0x060155B7 RID: 87479 RVA: 0x00671758 File Offset: 0x0066FB58
		public Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node4()
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
			item.skillID = 5432;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155B8 RID: 87480 RVA: 0x006717E8 File Offset: 0x0066FBE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF89 RID: 61321
		private List<Input> method_p0;

		// Token: 0x0400EF8A RID: 61322
		private bool method_p1;
	}
}
