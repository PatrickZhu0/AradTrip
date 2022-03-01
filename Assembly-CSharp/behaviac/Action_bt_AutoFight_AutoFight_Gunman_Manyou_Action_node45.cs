using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200261C RID: 9756
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node45 : Action
	{
		// Token: 0x0601357E RID: 79230 RVA: 0x005C115C File Offset: 0x005BF55C
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node45()
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
			item.skillID = 1008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601357F RID: 79231 RVA: 0x005C11EC File Offset: 0x005BF5EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFC8 RID: 53192
		private List<Input> method_p0;

		// Token: 0x0400CFC9 RID: 53193
		private bool method_p1;
	}
}
