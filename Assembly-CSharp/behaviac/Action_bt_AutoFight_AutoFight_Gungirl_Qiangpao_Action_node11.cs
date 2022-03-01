using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200251F RID: 9503
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node116 : Action
	{
		// Token: 0x06013387 RID: 78727 RVA: 0x005B601C File Offset: 0x005B441C
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node116()
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
			item.skillID = 2611;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013388 RID: 78728 RVA: 0x005B60AC File Offset: 0x005B44AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDA9 RID: 52649
		private List<Input> method_p0;

		// Token: 0x0400CDAA RID: 52650
		private bool method_p1;
	}
}
