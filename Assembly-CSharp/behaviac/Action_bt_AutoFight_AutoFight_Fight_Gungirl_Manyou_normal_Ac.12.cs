using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002051 RID: 8273
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node30 : Action
	{
		// Token: 0x06012A3C RID: 76348 RVA: 0x0057794C File Offset: 0x00575D4C
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node30()
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
			item.skillID = 2510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012A3D RID: 76349 RVA: 0x005779DC File Offset: 0x00575DDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C42F RID: 50223
		private List<Input> method_p0;

		// Token: 0x0400C430 RID: 50224
		private bool method_p1;
	}
}
