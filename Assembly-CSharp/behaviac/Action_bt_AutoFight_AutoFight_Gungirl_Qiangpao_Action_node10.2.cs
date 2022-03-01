using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002563 RID: 9571
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node107 : Action
	{
		// Token: 0x0601340F RID: 78863 RVA: 0x005B7D70 File Offset: 0x005B6170
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node107()
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

		// Token: 0x06013410 RID: 78864 RVA: 0x005B7E00 File Offset: 0x005B6200
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE35 RID: 52789
		private List<Input> method_p0;

		// Token: 0x0400CE36 RID: 52790
		private bool method_p1;
	}
}
