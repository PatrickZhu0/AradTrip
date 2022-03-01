using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FC2 RID: 8130
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node5 : Action
	{
		// Token: 0x06012921 RID: 76065 RVA: 0x005712DC File Offset: 0x0056F6DC
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node5()
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
			item.skillID = 2518;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012922 RID: 76066 RVA: 0x0057136C File Offset: 0x0056F76C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C313 RID: 49939
		private List<Input> method_p0;

		// Token: 0x0400C314 RID: 49940
		private bool method_p1;
	}
}
