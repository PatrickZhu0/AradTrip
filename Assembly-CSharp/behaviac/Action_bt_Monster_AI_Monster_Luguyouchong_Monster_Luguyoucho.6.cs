using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036D4 RID: 14036
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node9 : Action
	{
		// Token: 0x060155BF RID: 87487 RVA: 0x0067190C File Offset: 0x0066FD0C
		public Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node9()
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
			item.skillID = 5431;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155C0 RID: 87488 RVA: 0x0067199C File Offset: 0x0066FD9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF91 RID: 61329
		private List<Input> method_p0;

		// Token: 0x0400EF92 RID: 61330
		private bool method_p1;
	}
}
